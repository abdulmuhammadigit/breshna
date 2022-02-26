﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Pro.Common;
using Pro.DataAccess;
using Pro.Entities.identity;
using Pro.Services.Contracts;
using Pro.ViewModels.DynamicAccess;
using Pro.ViewModels.UserManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace Pro.Areas.Admin.Controllers
{
    [DisplayName("مدیریت کاربران")]
    public class UserManagerController : BaseController
    {
        private readonly IApplicationUserManager _userManager;
        private readonly IApplicationRoleManager _roleManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _uw;
        private readonly IEmailSender _emailSender;
        private const string UserNotFound = "کاربر یافت نشد.";
        public UserManagerController(IApplicationUserManager userManager, IMapper mapper, IApplicationRoleManager roleManager, IWebHostEnvironment env, IEmailSender emailSender)
        {
            _userManager = userManager;
            _userManager.CheckArgumentIsNull(nameof(_userManager));

            _mapper = mapper;
            _mapper.CheckArgumentIsNull(nameof(_mapper));

            _roleManager = roleManager;
            _roleManager.CheckArgumentIsNull(nameof(_roleManager));

            _env = env;
            _env.CheckArgumentIsNull(nameof(_env));

            _emailSender = emailSender;
            _emailSender.CheckArgumentIsNull(nameof(_emailSender));
        }

        [HttpGet, DisplayName("مشاهده")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetUsers(string search, string order, int offset, int limit, string sort)
        {
            List<UsersViewModel> allUsers;
            int total = _userManager.Users.Count();

            if (string.IsNullOrWhiteSpace(search))
                search = "";

            if (limit == 0)
                limit = total;

            if (sort == "نام")
            {
                if (order == "asc")
                    allUsers = await _userManager.GetPaginateUsersAsync(offset, limit, "FirstName", search);
                else
                    allUsers = await _userManager.GetPaginateUsersAsync(offset, limit, "FirstName desc", search);
            }

            else if (sort == "نام خانوادگی")
            {
                if (order == "asc")
                    allUsers = await _userManager.GetPaginateUsersAsync(offset, limit, "LastName", search);
                else
                    allUsers = await _userManager.GetPaginateUsersAsync(offset, limit, "LastName desc", search);
            }

            else if (sort == "ایمیل")
            {
                if (order == "asc")
                    allUsers = await _userManager.GetPaginateUsersAsync(offset, limit, "Email", search);
                else
                    allUsers = await _userManager.GetPaginateUsersAsync(offset, limit, "Email desc", search);
            }

            else if (sort == "نام کاربری")
            {
                if (order == "asc")
                    allUsers = await _userManager.GetPaginateUsersAsync(offset, limit, "UserName", search);
                else
                    allUsers = await _userManager.GetPaginateUsersAsync(offset, limit, "UserName desc", search);
            }

            else if (sort == "تاریخ عضویت")
            {
                if (order == "asc")
                    allUsers = await _userManager.GetPaginateUsersAsync(offset, limit, "RegisterDateTime", search);
                else
                    allUsers = await _userManager.GetPaginateUsersAsync(offset, limit, "RegisterDateTime desc", search);
            }

            else
                allUsers = await _userManager.GetPaginateUsersAsync(offset, limit, "RegisterDateTime desc", search);

            if (search != "")
                total = allUsers.Count();

            return Json(new { total = total, rows = allUsers });
        }



        [HttpGet, DisplayName("درج و ویرایش")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> RenderUser(int? userId)
        {
            var user = new UsersViewModel();
            ViewBag.Roles = _roleManager.GetAllRoles();

            if (userId != null)
            {
                user = _mapper.Map<UsersViewModel>(await _userManager.FindUserWithRolesByIdAsync((int)userId));
                user.PersianBirthDate = user.BirthDate.ConvertMiladiToShamsi("yyyy/MM/dd");
            }

            return PartialView("_RenderUser", user);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(UsersViewModel viewModel)
        {
            ViewBag.Roles = _roleManager.GetAllRoles();
            if (viewModel.Id != null)
            {
                ModelState.Remove("Password");
                ModelState.Remove("ConfirmPassword");
                ModelState.Remove("ImageFile");
            }

            if (ModelState.IsValid)
            {
                IdentityResult result = null;
                if (viewModel.ImageFile != null)
                    viewModel.Image = _userManager.CheckAvatarFileName(viewModel.ImageFile.FileName);

                viewModel.Roles = new List<UserRole> { new UserRole { RoleId = (int)viewModel.RoleId } };
                if(viewModel.BirthDate != null)
                {
                    viewModel.BirthDate = viewModel.PersianBirthDate.ConvertShamsiToMiladi();
                }
              
                if (viewModel.Id != null)
                {
                    var user = await _userManager.FindByIdAsync(viewModel.Id.ToString());
                    user.FirstName = viewModel.FirstName;
                    user.LastName = viewModel.LastName;
                    user.BirthDate = viewModel.BirthDate;
                    user.Email = viewModel.Email;
                    user.UserName = viewModel.UserName;
                    user.Gender = viewModel.Gender.Value;
                    user.PhoneNumber = viewModel.PhoneNumber;
                    user.Roles = viewModel.Roles;
                    user.Bio = viewModel.Bio;
                    var userRoles = await _userManager.GetRolesAsync(user);

                    if (viewModel.ImageFile != null)
                    {
                        await viewModel.ImageFile.UploadFileAsync($"{_env.WebRootPath}/avatars/{viewModel.Image}");
                        FileExtensions.DeleteFile($"{_env.WebRootPath}/avatars/{user.Image}");
                        user.Image = viewModel.Image;
                    }

                    result = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    if (result.Succeeded)
                        result = await _userManager.UpdateAsync(user);
                }

                else
                {
                    if(viewModel.Image != null)
                    {
                        await viewModel.ImageFile.UploadFileAsync($"{_env.WebRootPath}/avatars/{viewModel.Image}");
                    }
                    viewModel.EmailConfirmed = true;
                    result = await _userManager.CreateAsync(_mapper.Map<User>(viewModel), viewModel.Password);
                }

                if (result.Succeeded)
                    TempData["notification"] = OperationSuccess;
                else
                    ModelState.AddErrorsFromResult(result);
            }

            return PartialView("_RenderUser", viewModel);
        }


        [HttpGet, DisplayName("حذف")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> Delete(string userId)
        {
            if (!userId.HasValue())
                ModelState.AddModelError(string.Empty, UserNotFound);
            else
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user == null)
                    ModelState.AddModelError(string.Empty, UserNotFound);
                else
                    return PartialView("_DeleteConfirmation", user);
            }
            return PartialView("_DeleteConfirmation");
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(User model)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
                ModelState.AddModelError(string.Empty, UserNotFound);
            else
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    FileExtensions.DeleteFile($"{_env.WebRootPath}/avatars/{user.Image}");
                    TempData["notification"] = DeleteSuccess;
                    return PartialView("_DeleteConfirmation", user);
                }
                else
                    ModelState.AddErrorsFromResult(result);
            }

            return PartialView("_DeleteConfirmation");
        }



        [HttpPost, ActionName("DeleteGroup"), DisplayName("حذف گروهی")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> DeleteGroupConfirmed(string[] btSelectItem)
        {
            if (btSelectItem.Count() == 0)
                ModelState.AddModelError(string.Empty, "هیچ کاربری برای حذف انتخاب نشده است.");
            else
            {
                foreach (var item in btSelectItem)
                {
                    var user = await _userManager.FindByIdAsync(item);
                    var result = await _userManager.DeleteAsync(user);
                    FileExtensions.DeleteFile($"{_env.WebRootPath}/avatars/{user.Image}");
                }
                TempData["notification"] = "حذف گروهی اطلاعات با موفقیت انجام شد..";
            }

            return PartialView("_DeleteGroup");
        }

        [HttpGet, DisplayName("مدیریت کاربر")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> Details(int userId)
        {
            if (userId == 0)
                return NotFound();
            else
            {
                var User = await _userManager.FindUserWithRolesByIdAsync(userId);
                if (User == null)
                    return NotFound();
                else
                    return View(User);
            }
        }



        /// <summary>
        /// فعال و غیر فعال کردن فقل حساب کاربر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ChangeLockOutEnable(int userId)
        {
            var User = await _userManager.FindByIdAsync(userId.ToString());
            string ResultJsonData;
            if (User == null)
            {
                return NotFound();
            }

            else
            {
                if (User.LockoutEnabled)
                {
                    User.LockoutEnabled = false;
                    ResultJsonData = "غیرفعال";
                }

                else
                {
                    User.LockoutEnabled = true;
                    ResultJsonData = "فعال";
                }

                await _userManager.UpdateAsync(User);
                return Json(ResultJsonData);
            }
        }

        /// <summary>
        /// فعال و غیر فعال کردن کاربر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> InActiveOrActiveUser(int userId)
        {
            var User = await _userManager.FindByIdAsync(userId.ToString());
            string ResultJsonData;
            if (User == null)
            {
                return NotFound();
            }

            if (User.IsActive)
            {
                User.IsActive = false;
                ResultJsonData = "غیرفعال";
            }

            else
            {
                User.IsActive = true;
                ResultJsonData = "فعال";
            }

            await _userManager.UpdateAsync(User);
            return Json(ResultJsonData);
        }

        /// <summary>
        /// فعال و غیر فعال کردن احرازهویت دو مرحله ای
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ChangeTwoFactorEnabled(int userId)
        {
            var User = await _userManager.FindByIdAsync(userId.ToString());
            string ResultJsonData;
            if (User == null)
            {
                return NotFound();
            }

            if (User.TwoFactorEnabled)
            {
                User.TwoFactorEnabled = false;
                ResultJsonData = "غیرفعال";
            }

            else
            {
                User.TwoFactorEnabled = true;
                ResultJsonData = "فعال";
            }

            await _userManager.UpdateAsync(User);
            return Json(ResultJsonData);
        }

        /// <summary>
        /// تایید و عدم تایید وضعیت ایمیل کاربر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ChangeEmailConfirmed(int userId)
        {
            var User = await _userManager.FindByIdAsync(userId.ToString());
            string ResultJsonData;
            if (User == null)
            {
                return NotFound();
            }

            if (User.EmailConfirmed)
            {
                ResultJsonData = "تایید نشده";
                User.EmailConfirmed = false;
            }

            else
            {
                User.EmailConfirmed = true;
                ResultJsonData = "تایید شده";
            }

            var Result = await _userManager.UpdateAsync(User);
            return Json(ResultJsonData);
        }

        /// <summary>
        /// تایید و عدم تایید وضعیت شماره موبایل کاربر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ChangePhoneNumberConfirmed(int userId)
        {
            var User = await _userManager.FindByIdAsync(userId.ToString());
            string ResultJsonData;
            if (User == null)
            {
                return NotFound();
            }

            if (User.PhoneNumberConfirmed)
            {
                ResultJsonData = "تایید نشده";
                User.PhoneNumberConfirmed = false;
            }

            else
            {
                ResultJsonData = "تایید شده";
                User.PhoneNumberConfirmed = true;
            }

            var Result = await _userManager.UpdateAsync(User);
            return Json(ResultJsonData);
        }

        /// <summary>
        /// قفل و خروج از حالت قفل حساب کاربر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LockOrUnLockUserAccount(int userId)
        {
            var User = await _userManager.FindByIdAsync(userId.ToString());
            string ResultJsonData;
            if (User == null)
            {
                return NotFound();
            }

            if (User.LockoutEnd == null)
            {
                ResultJsonData = "قفل شده";
                User.LockoutEnd = DateTimeOffset.UtcNow.AddMinutes(20);
            }

            else
            {
                if (User.LockoutEnd > DateTime.Now)
                {
                    ResultJsonData = "قفل نشده";
                    User.LockoutEnd = null;
                }
                else
                {
                    ResultJsonData = "قفل شده";
                    User.LockoutEnd = DateTimeOffset.UtcNow.AddMinutes(20);
                }
            }

            var Result = await _userManager.UpdateAsync(User);
            return Json(ResultJsonData);
        }

        /// <summary>
        /// نمایش صفحه بازنشانی کلمه عبور
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ResetPassword(int userId)
        {
            var User = await _userManager.FindByIdAsync(userId.ToString());
            if (User == null)
            {
                return NotFound();
            }

            var viewModel = new ResetPasswordViewModel
            {
                userId = userId,
                Email = User.Email,
            };

            return View(viewModel);
        }

        /// <summary>
        /// انجام عملیات بازنشانی کلمه عبور
        /// </summary>
        /// <param name="ViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByIdAsync(viewModel.userId.ToString());
                if (User == null)
                    return NotFound();

                await _userManager.RemovePasswordAsync(User);
                var result = await _userManager.AddPasswordAsync(User, viewModel.NewPassword);
                if (result.Succeeded)
                    ViewBag.AlertSuccess = "بازنشانی کلمه عبور با موفقیت انجام شد.";
                else
                    ModelState.AddErrorsFromResult(result);

                viewModel.Email = User.Email;
            }

            return View(viewModel);
        }

        /// <summary>
        /// ارسال ایمیل
        /// </summary>
        /// <param name="ViewModel"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        [DisplayName(" ایمیل")]
        public async Task<IActionResult> SendEmail(string Msg, int page = 1, int row = 10)
        {
         
            if (Msg == "SendEmailSuccess")
                ViewBag.Alert = "ارسال ایمیل به کاربران با موفقیت انجام شد.";

            var PagingModel = PagingList.Create(await _userManager.GetAllUsersWithRolesAsync(), row, page);
            return View(PagingModel);
          
        }
        
    
        public async Task<IActionResult> SendEmail(string[] emails, string subject, string message)
        {

            if (emails != null)
            {
                for (int i = 0; i < emails.Length; i++)
                {
                    await _emailSender.SendEmailAsync(emails[i], subject, message);
                }
            }
            return RedirectToAction("SendEmail", new { Msg = "SendEmailSuccess" });
        }

        /// <summary>
        /// درج کاربر جدید
        /// </summary>
        /// <param name="ViewModel"></param>
        /// <returns></returns>
        /// 

        //    [HttpGet]
        //    public IActionResult Register()
        //    {
        //        ViewBag.AllRoles = _roleManager.Roles.ToList();
        //        return View();
        //    }
        //    [HttpPost]
        //    [AutoValidateAntiforgeryToken]
        //    public async Task<IActionResult> Register(UsersViewModel model, string[] UserRoles)
        //    {

        //        ViewBag.AllRoles = _roleManager.Roles.ToList();

        //        if (ModelState.IsValid)
        //        {
        //            var user = new User()
        //            {
        //                UserName = model.UserName,
        //                Email = model.Email,
        //                EmailConfirmed = true,
        //                PhoneNumber = model.PhoneNumber,
        //                BirthDate = model.BirthDate,
        //                LastName = model.LastName,
        //                FirstName = model.FirstName,
        //                RegisterDateTime = DateTime.Now,


        //            };

        //            var result = await _userManager.CreateAsync(user, model.Password);

        //            if (result.Succeeded)
        //            {
        //                if (UserRoles != null)
        //                {
        //                    await _userManager.AddToRolesAsync(user, UserRoles);
        //                }

        //                return RedirectToAction("Index", "UserManager");
        //            }

        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }

        //        }
        //        return View(model);
        //    }



        //    /// <summary>
        //    /// ویرایش کاربر 
        //    /// </summary>
        //    /// <param name="ViewModel"></param>
        //    /// <returns></returns>
        //    /// 
        //    [HttpGet]
        //    public async Task<IActionResult> Edit(int id)
        //    {
        //        if (id.ToString() == null)
        //            return NotFound();
        //        var User = await _userManager.Users.Where(u => u.Id == id).Select(user => new UsersViewModel
        //        {
        //            Id = user.Id,
        //            Email = user.Email,
        //            UserName = user.UserName,
        //            PhoneNumber = user.PhoneNumber,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            BirthDate = user.BirthDate,
        //            IsActive = user.IsActive,
        //            Image = user.Image,
        //            RegisterDateTime = user.RegisterDateTime,
        //            //    RolesName = user.Roles.Select(u => u.Role.Name),
        //            Roles = user.Roles,
        //            AccessFailedCount = user.AccessFailedCount,
        //            EmailConfirmed = user.EmailConfirmed,
        //            LockoutEnabled = user.LockoutEnabled,
        //            LockoutEnd = user.LockoutEnd,
        //            PhoneNumberConfirmed = user.PhoneNumberConfirmed,
        //            TwoFactorEnabled = user.TwoFactorEnabled,
        //            Gender = user.Gender,
        //        }).FirstOrDefaultAsync();

        //        if (User == null)
        //            return NotFound();
        //        else
        //        {
        //            ViewBag.AllRoles = _roleManager.Roles.ToList();

        //            return View(User);
        //        }
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(UsersViewModel ViewModel, string[] UserRoles)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var User = await _userManager.FindByIdAsync(ViewModel.Id.ToString());
        //            if (User == null)
        //                return NotFound();
        //            else
        //            {
        //                IdentityResult Result;
        //                var RecentRoles = await _userManager.GetRolesAsync(User);
        //                var DeleteRoles = RecentRoles.Except(UserRoles);
        //                var AddRoles = UserRoles.Except(RecentRoles);

        //                Result = await _userManager.RemoveFromRolesAsync(User, DeleteRoles);
        //                if (Result.Succeeded)
        //                {
        //                    Result = await _userManager.AddToRolesAsync(User, AddRoles);
        //                    if (Result.Succeeded)
        //                    {
        //                        User.FirstName = ViewModel.FirstName;
        //                        User.LastName = ViewModel.LastName;
        //                        User.Email = ViewModel.Email;
        //                        User.PhoneNumber = ViewModel.PhoneNumber;
        //                        User.UserName = ViewModel.UserName;
        //                        User.BirthDate = ViewModel.BirthDate;

        //                        Result = await _userManager.UpdateAsync(User);
        //                        if (Result.Succeeded)
        //                        {
        //                            ViewBag.AlertSuccess = "ذخیره تغییرات با موفقیت انجام شد.";
        //                        }
        //                    }
        //                }

        //                if (Result != null)
        //                {
        //                    foreach (var item in Result.Errors)
        //                    {
        //                        ModelState.AddModelError("", item.Description);
        //                    }
        //                }
        //            }
        //        }

        //        ViewBag.AllRoles = _roleManager.Roles.ToList();
        //        return View(ViewModel);
        //    }
        //}







    }
}