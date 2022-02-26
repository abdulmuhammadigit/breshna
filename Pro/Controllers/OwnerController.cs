using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pro.Common;
using Pro.DataAccess;
using Pro.Entities;
using Pro.Services.Contracts;
using Pro.ViewModels.DynamicAccess;
using Pro.ViewModels.Owner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pro.Controllers
{
    [DisplayName("مدیریت مالک خانه")]
    [Authorize]
    public class OwnerController : Controller
    {
        private readonly IApplicationOwnerManager _manager;
        private readonly DataBaseContext _context;
        private readonly string NotFoundOwner = " پیدا نشد.";
        private readonly IUnitOfWork _uw;
        private readonly IMapper _mapper;
        public OwnerController(DataBaseContext context, IUnitOfWork uw, IApplicationOwnerManager manager, IMapper mapper)
        {
            _mapper = mapper;
            _uw = uw;
            _context = context;
            _manager = manager;
        }

        [HttpGet, DisplayName("مشاهده لیست صاحبان ملک")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet, DisplayName("درج مشخصات صاحبان ملک")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OwnerViewModel viewModel)
        {
            int idUser = User.Identity.GetUserId<int>();
           if (viewModel.Name != null) {
                Owner owner = new Owner()
                {
                    
                    JaktionNumber=viewModel.JaktionNumber,
                    Rezayat=viewModel.Reazyat,
                    FormNumber = viewModel.FormNumber,
                    AccountBrashna = viewModel.AccountBrashna,
                    Age = viewModel.Age,
                    AirCandition = viewModel.AirCandition,
                    CountLiveINFamily = viewModel.CountLiveINFamily,
                    AreaBuilding = viewModel.AreaBuilding,
                    BillDayDaily = viewModel.BillDayDaily,
                    BillRecive = viewModel.BillRecive,
                    BSolor = viewModel.BSolor,
                    CapacityG = viewModel.CapacityG,
                    CountryLive = viewModel.CountryLive,
                    EAlltime = viewModel.EAlltime,
                    //LiveINFamilyInfo = viewModel.LiveINFamilyInfo,
                    EHour = viewModel.EHour,
                    EmailAddress = viewModel.EmailAddress,
                    Village = viewModel.Village,
                    EMCount = viewModel.EMCount,
                    EType = viewModel.EType,
                    ExpenseG = viewModel.ExpenseG,
                    ExpenseOld = viewModel.ExpenseOld,
                    FatherName = viewModel.FatherName,
                    Floor = viewModel.Floor,
                    Gender = viewModel.Gender,
                    GhastVar = viewModel.GhastVar,
                    Ghozar = viewModel.Ghozar,
                    GhozarLive = viewModel.GhozarLive,
                    HourOnStove = viewModel.HourOnStove,
                    HourUG = viewModel.HourUG,
                    HouseNumber = viewModel.HouseNumber,
                    IncomeMonth = viewModel.IncomeMonth,
                    Kichen = viewModel.Kichen,
                    Land = viewModel.Land,
                
                    LastName = viewModel.LastName,
                    LiveWF = viewModel.LiveWF,
                    LiveWFAge = viewModel.LiveWFAge,
                    Name = viewModel.Name,
                    OwnerId = viewModel.OwnerId,
                    OwnerName = viewModel.OwnerName,
                    OwnerSave = viewModel.OwnerSave,
                    PayForEAT = viewModel.PayForEAT,
                    PayOnTime = viewModel.PayOnTime,
                    Phone = viewModel.Phone,
                    Province = viewModel.Province,
                    ProvinceLive = viewModel.ProvinceLive,
                    RegisterDateTime = DateTime.Now,
                    Room = viewModel.Room,
                    SolorAmountAssets = viewModel.SolorAmountAssets,
                    SourceE = viewModel.SourceE,
                    SourceEType = viewModel.SourceEType,
                    StaffCount = viewModel.StaffCount,
                    Status = viewModel.Status,
                    Suggestion = viewModel.Suggestion,
                    Tazkira = viewModel.Tazkira,
                    TradeHome = viewModel.TradeHome,
                    TradeName = viewModel.TradeName,
                    TradeYear = viewModel.TradeYear,
                    TypeHome = viewModel.TypeHome,
                    TypeIncome = viewModel.TypeIncome,
                    UseGenerator = viewModel.UseGenerator,
                    TypeTrade = viewModel.TypeTrade,
                 
                    VillageLive = viewModel.VillageLive,
                    WantEAT = viewModel.WantEAT,
                    WayContact = viewModel.WayContact,
                    WC = viewModel.WC,
                    WhenUG = viewModel.WhenUG,
                    UserId = idUser,
                };
                await _context.AddAsync(owner);
                await _context.SaveChangesAsync();

                List<PowerMeter> powerMeterList = new List<PowerMeter>();
                if (viewModel.PowerMeters.Count > 0)
                {
                    for (int i = 0; i < viewModel.PowerMeters.Count; i++)
                    {
                        if (viewModel.PowerMeters[i].IDMeter != 0)
                        {
                            PowerMeter powerMeter = new PowerMeter()
                            {
                                OwnerId = owner.OwnerId,
                                DigitalOrAnalog = viewModel.PowerMeters[i].DigitalOrAnalog,
                                IDMeter = viewModel.PowerMeters[i].IDMeter,
                            };
                            powerMeterList.Add(powerMeter);
                        }

                    }
                    await _context.AddRangeAsync(powerMeterList);

                }
                //////////////////////////////////////////////////////////


                List<OwnerLanguage> LanguageList = new List<OwnerLanguage>();
                if (viewModel.Language != null)
                {
                    for (int i = 0; i < viewModel.Language.Length; i++)
                    {
                        if (viewModel.Language[i] != null)
                        {
                            OwnerLanguage language = new OwnerLanguage()
                            {
                                OwnerId = owner.OwnerId,
                                Name = viewModel.Language[i],
                              
                            };
                            LanguageList.Add(language);
                        }

                    }
                    await _context.AddRangeAsync(LanguageList);

                }

                List<OwnerTypeWarming> TypeWarmingList = new List<OwnerTypeWarming>();
                if (viewModel.UseTypeWarming != null)
                {
                    for (int i = 0; i < viewModel.UseTypeWarming.Length; i++)
                    {
                        if (viewModel.UseTypeWarming[i] != null)
                        {
                            OwnerTypeWarming typeWarming = new OwnerTypeWarming()
                            {
                                OwnerId = owner.OwnerId,
                                Name = viewModel.UseTypeWarming[i],

                            };
                            TypeWarmingList.Add(typeWarming);
                        }

                    }
                    await _context.AddRangeAsync(TypeWarmingList);

                }


                /////////////////////////////////////////////////////

                List<Resident> ResidentList = new List<Resident>();
                if (viewModel.Residents.Count > 0)
                {

                    for (int i = 0; i < viewModel.Residents.Count; i++)
                    {
                        if (viewModel.Residents[i].Name != null)
                        {
                            Resident resident = new Resident()
                            {
                                Age = viewModel.Residents[i].Age,
                                OwnerId = owner.OwnerId,
                                Gender = viewModel.Residents[i].Gender,
                                Income = viewModel.Residents[i].Income,
                                Job = viewModel.Residents[i].Job,
                                Name = viewModel.Residents[i].Name,

                            };
                            ResidentList.Add(resident);
                        }

                    }
                    await _context.AddRangeAsync(ResidentList);
                }

                List<EEquipmentCom> eEquipmentComs = new List<EEquipmentCom>();
                if (viewModel.EEquipmentComs.Count > 0)
                {

                    for (int i = 0; i < viewModel.EEquipmentComs.Count; i++)
                    {
                        if (viewModel.EEquipmentComs[i].Name != null)
                        {


                            EEquipmentCom eEquipment = new EEquipmentCom()
                            {
                                AstahlakYear = viewModel.EEquipmentComs[i].AstahlakYear,
                                Count = viewModel.EEquipmentComs[i].Count,
                                Name = viewModel.EEquipmentComs[i].Name,
                                OwnerId = owner.OwnerId,
                                Info= viewModel.EEquipmentComs[i].Info,

                            };
                            eEquipmentComs.Add(eEquipment);

                        }
                    }

                    await _context.AddRangeAsync(eEquipmentComs);

                }

                List<EEquipmentH> eEquipmentH = new List<EEquipmentH>();
                if (viewModel.EEquipmentHs.Count > 0)
                {

                    for (int i = 0; i < viewModel.EEquipmentHs.Count; i++)
                    {
                        if (viewModel.EEquipmentHs[i].Name != null)
                        {

                            EEquipmentH eEquipment = new EEquipmentH()
                            {
                                AstahlakYear = viewModel.EEquipmentHs[i].AstahlakYear,
                                Count = viewModel.EEquipmentHs[i].Count,
                                Name = viewModel.EEquipmentHs[i].Name,
                                OwnerId = owner.OwnerId,


                            };
                            eEquipmentH.Add(eEquipment);
                        }


                    }
                    await _context.AddRangeAsync(eEquipmentH);
                }

                await _context.SaveChangesAsync();

                TempData["Success"] = "با موفقیت ثبت شد.";
                return RedirectToAction("Create");
            }
       
                       TempData["Danger"] = "خطایی رخ داده است.";
                        return View();

        }


        [HttpGet, DisplayName(" نمایش اطلاعات صاحب ملک")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> Info(int id)
        {
            List<PowerMeter> powerMeters = new List<PowerMeter>();
            List<Resident> residents = new List<Resident>();
            List<EEquipmentCom> eEquipmentComs = new List<EEquipmentCom>();
            List<EEquipmentH> eEquipmentHs = new List<EEquipmentH>();
            List<OwnerLanguage> rentLanguages = new List<OwnerLanguage>();
            List<OwnerTypeWarming> rentTypeWarmings = new List<OwnerTypeWarming>();
                    
            Owner owner = new Owner();
            if (id != 0)
            {
                owner =await _context.Owners.FindAsync(id);
                if (owner != null)
                {
                    powerMeters = await _context.PowerMeters.Where(a => a.OwnerId == id).ToListAsync();
                    residents = await _context.Residents.Where(a => a.OwnerId == id).ToListAsync();
                    eEquipmentComs = await _context.EEquipmentComs.Where(a => a.OwnerId == id).ToListAsync();
                    eEquipmentHs = await _context.EEquipmentHs.Where(a => a.OwnerId == id).ToListAsync();
                    rentLanguages = await _context.OwnerLanguages.Where(a => a.OwnerId == id).ToListAsync();
                    rentTypeWarmings = await _context.OwnerTypeWarmings.Where(a => a.OwnerId == id).ToListAsync();
                    
                    ViewBag.PowerMeters = powerMeters;
                    ViewBag.Residents = residents;
                    ViewBag.EEquipmentComs = eEquipmentComs;
                    ViewBag.EEquipmentHs = eEquipmentHs;
                    ViewBag.RentTypeWarmings = rentTypeWarmings.Select(a => a.Name).ToArray();
                    ViewBag.Languages = rentLanguages.Select(a => a.Name).ToArray();

                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return NotFound();
            }

            return View(owner);
        }


        [HttpGet, DisplayName("ویرایش مشخصات صاحبان ملک")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> Edit(int id)
        {
            List<PowerMeter> powerMeters = new List<PowerMeter>();
            List<Resident> residents = new List<Resident>();
            List<EEquipmentCom> eEquipmentComs = new List<EEquipmentCom>();
            List<EEquipmentH> eEquipmentHs = new List<EEquipmentH>();
            List<OwnerLanguage> ownerLanguages = new List<OwnerLanguage>();
            List<OwnerTypeWarming> ownerTypeWarmings = new List<OwnerTypeWarming>();
            Owner owner =new Owner();
            OwnerViewModel ownerowner = new OwnerViewModel();
            if (id != 0)
            {
                 owner = _context.Owners.Find(id);
                if(owner != null)
                {
                    powerMeters =await _context.PowerMeters.Where(a => a.OwnerId == id).ToListAsync();
                    residents = await _context.Residents.Where(a => a.OwnerId == id).ToListAsync();
                    eEquipmentComs = await _context.EEquipmentComs.Where(a => a.OwnerId == id).ToListAsync();
                    eEquipmentHs = await _context.EEquipmentHs.Where(a => a.OwnerId == id).ToListAsync();
                    ownerLanguages = await _context.OwnerLanguages.Where(a => a.OwnerId == id).ToListAsync();
                    ownerTypeWarmings = await _context.OwnerTypeWarmings.Where(a => a.OwnerId == id).ToListAsync();


                    ownerowner.JaktionNumber = owner.JaktionNumber;
                    ownerowner.Reazyat = owner.Rezayat;
                    ownerowner.FormNumber = owner.FormNumber;
                    ownerowner.AccountBrashna = owner.AccountBrashna;
                    ownerowner.Age = owner.Age;
                    ownerowner.AirCandition = owner.AirCandition;
                    ownerowner.CountLiveINFamily = owner.CountLiveINFamily;
                    ownerowner.AreaBuilding = owner.AreaBuilding;
                    ownerowner.BillDayDaily = owner.BillDayDaily;
                    ownerowner.BillRecive = owner.BillRecive;
                    ownerowner.BSolor = owner.BSolor;
                    ownerowner.CapacityG = owner.CapacityG;
                    ownerowner.CountryLive = owner.CountryLive;
                    ownerowner.EAlltime = owner.EAlltime;
                    //ownerowner.LiveINFamilyInfo = owner.LiveINFamilyInfo;
                    ownerowner.EHour = owner.EHour;
                    ownerowner.EmailAddress = owner.EmailAddress;
                    ownerowner.Village = owner.Village;
                    ownerowner.EMCount = owner.EMCount;
                    ownerowner.EType = owner.EType;
                    ownerowner.ExpenseG = owner.ExpenseG;
                    ownerowner.ExpenseOld = owner.ExpenseOld;
                    ownerowner.FatherName = owner.FatherName;
                    ownerowner.Floor = owner.Floor;
                    ownerowner.Gender = owner.Gender;
                    ownerowner.GhastVar = owner.GhastVar;
                    ownerowner.Ghozar = owner.Ghozar;
                    ownerowner.GhozarLive = owner.GhozarLive;
                    ownerowner.HourOnStove = owner.HourOnStove;
                    ownerowner.HourUG = owner.HourUG;
                    ownerowner.HouseNumber = owner.HouseNumber;
                    ownerowner.IncomeMonth = owner.IncomeMonth;
                    ownerowner.Kichen = owner.Kichen;
                    ownerowner.Land = owner.Land;
                    ownerowner.LastName = owner.LastName;
                    ownerowner.LiveWF = owner.LiveWF;
                    ownerowner.LiveWFAge = owner.LiveWFAge;
                    ownerowner.Name = owner.Name;
                    ownerowner.OwnerId = owner.OwnerId;
                    ownerowner.OwnerName = owner.OwnerName;
                    ownerowner.OwnerSave = owner.OwnerSave;
                    ownerowner.PayForEAT = owner.PayForEAT;
                    ownerowner.PayOnTime = owner.PayOnTime;
                    ownerowner.Phone = owner.Phone;
                    ownerowner.Province = owner.Province;
                    ownerowner.ProvinceLive = owner.ProvinceLive;
                    ownerowner.Room = owner.Room;
                    ownerowner.SolorAmountAssets = owner.SolorAmountAssets;
                    ownerowner.SourceE = owner.SourceE;
                    ownerowner.SourceEType = owner.SourceEType;
                    ownerowner.StaffCount = owner.StaffCount;
                    ownerowner.Status = owner.Status;
                    ownerowner.Suggestion = owner.Suggestion;
                    ownerowner.Tazkira = owner.Tazkira;
                    ownerowner.TradeHome = owner.TradeHome;
                    ownerowner.TradeName = owner.TradeName;
                    ownerowner.TradeYear = owner.TradeYear;
                    ownerowner.TypeHome = owner.TypeHome;
                    ownerowner.TypeIncome = owner.TypeIncome;
                    ownerowner.UseGenerator = owner.UseGenerator;
                    ownerowner.TypeTrade = owner.TypeTrade;
                    ownerowner.VillageLive = owner.VillageLive;
                    ownerowner.WantEAT = owner.WantEAT;
                    ownerowner.WayContact = owner.WayContact;
                    ownerowner.WC = owner.WC;
                    ownerowner.WhenUG = owner.WhenUG;
                    ownerowner.EEquipmentComs = eEquipmentComs;
                    ownerowner.EEquipmentHs = eEquipmentHs;
                    ownerowner.Residents = residents;
                    ownerowner.PowerMeters = powerMeters;
                    ownerowner.UseTypeWarming = ownerTypeWarmings.Select(a=>a.Name).ToArray();
                    ownerowner.Language = ownerLanguages.Select(a => a.Name).ToArray();
                    ownerowner.OwnerId = owner.OwnerId;

                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return NotFound();
            }
           
            return View(ownerowner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OwnerViewModel viewModel)
        {
            if (viewModel.OwnerId.ToString() == null)
                return NotFound();
            else
            {
                var owner = await _uw.BaseRepository<Owner>().FindByIdAsync(viewModel.OwnerId);
                if (owner == null)
                    ModelState.AddModelError(string.Empty, NotFoundOwner);
                else
                {////////////////////////////////
                    List<EEquipmentCom> eEquipmentComs = await _context.EEquipmentComs.Where(c => c.OwnerId == viewModel.OwnerId).ToListAsync();

                    if (eEquipmentComs.Count > 0)
                    {
                        foreach (var item in eEquipmentComs)
                        {
                            _context.EEquipmentComs.Remove(item);
                        }
                    }
                    ////////////////////////////////////////////////////////////////
                    List<EEquipmentH> eEquipmentHs = await _context.EEquipmentHs.Where(c => c.OwnerId == viewModel.OwnerId).ToListAsync();

                    if (eEquipmentHs.Count > 0)
                    {
                        foreach (var item in eEquipmentHs)
                        {
                            _context.EEquipmentHs.Remove(item);
                        }
                    }
                    //////////////////////////////////////////
                    List<OwnerTypeWarming> ownerTypeWarmings = await _context.OwnerTypeWarmings.Where(c => c.OwnerId == viewModel.OwnerId).ToListAsync();

                    if (ownerTypeWarmings.Count > 0)
                    {
                        foreach (var item in ownerTypeWarmings)
                        {
                            _context.OwnerTypeWarmings.Remove(item);
                        }
                    }
                    //////////////////////////////////////////
                       List<OwnerLanguage> ownerLanguages = await _context.OwnerLanguages.Where(c => c.OwnerId == viewModel.OwnerId).ToListAsync();

                    if (ownerLanguages.Count > 0)
                    {
                        foreach (var item in ownerLanguages)
                        {
                            _context.OwnerLanguages.Remove(item);
                        }
                    }
                    //////////////////////////////////////////
                    List<PowerMeter> powerMeters = await _context.PowerMeters.Where(c => c.OwnerId == viewModel.OwnerId).ToListAsync();

                    if (powerMeters.Count > 0)
                    {
                        foreach (var item in powerMeters)
                        {
                            _context.PowerMeters.Remove(item);
                        }
                    }
                    //////////////////////////////////////////////
                    List<Resident> residents = await _context.Residents.Where(c => c.OwnerId == viewModel.OwnerId).ToListAsync();

                    if (residents.Count > 0)
                    {
                        foreach (var item in residents)
                        {
                            _context.Residents.Remove(item);
                        }
                    }
                    ///////////////////////////////
                    await _context.SaveChangesAsync();
                    owner.JaktionNumber = viewModel.JaktionNumber;
                    owner.Rezayat = viewModel.Reazyat;
                    owner.FormNumber = viewModel.FormNumber;
                    owner.AccountBrashna = viewModel.AccountBrashna;
                    owner.Age = viewModel.Age;
                    owner.AirCandition = viewModel.AirCandition;
                    owner.CountLiveINFamily = viewModel.CountLiveINFamily;
                    owner.AreaBuilding = viewModel.AreaBuilding;
                    owner.BillDayDaily = viewModel.BillDayDaily;
                    owner.BillRecive = viewModel.BillRecive;
                    owner.BSolor = viewModel.BSolor;
                    owner.CapacityG = viewModel.CapacityG;
                    owner.CountryLive = viewModel.CountryLive;
                    owner.EAlltime = viewModel.EAlltime;
                    //owner.LiveINFamilyInfo = viewModel.LiveINFamilyInfo;
                    owner.EHour = viewModel.EHour;
                    owner.EmailAddress = viewModel.EmailAddress;
                    owner.Village = viewModel.Village;
                    owner.EMCount = viewModel.EMCount;
                    owner.EType = viewModel.EType;
                    owner.ExpenseG = viewModel.ExpenseG;
                    owner.ExpenseOld = viewModel.ExpenseOld;
                    owner.FatherName = viewModel.FatherName;
                    owner.Floor = viewModel.Floor;
                    owner.Gender = viewModel.Gender;
                    owner.GhastVar = viewModel.GhastVar;
                    owner.Ghozar = viewModel.Ghozar;
                    owner.GhozarLive = viewModel.GhozarLive;
                    owner.HourOnStove = viewModel.HourOnStove;
                    owner.HourUG = viewModel.HourUG;
                    owner.HouseNumber = viewModel.HouseNumber;
                    owner.IncomeMonth = viewModel.IncomeMonth;
                    owner.Kichen = viewModel.Kichen;
                    owner.Land = viewModel.Land;
               
                    owner.LastName = viewModel.LastName;
                    owner.LiveWF = viewModel.LiveWF;
                    owner.LiveWFAge = viewModel.LiveWFAge;
                    owner.Name = viewModel.Name;
                    owner.OwnerId = viewModel.OwnerId;
                    owner.OwnerName = viewModel.OwnerName;
                    owner.OwnerSave = viewModel.OwnerSave;
                    owner.PayForEAT = viewModel.PayForEAT;
                    owner.PayOnTime = viewModel.PayOnTime;
                    owner.Phone = viewModel.Phone;
                    owner.Province = viewModel.Province;
                    owner.ProvinceLive = viewModel.ProvinceLive;
                    owner.Room = viewModel.Room;
                    owner.SolorAmountAssets = viewModel.SolorAmountAssets;
                    owner.SourceE = viewModel.SourceE;
                    owner.SourceEType = viewModel.SourceEType;
                    owner.StaffCount = viewModel.StaffCount;
                    owner.Status = viewModel.Status;
                    owner.Suggestion = viewModel.Suggestion;
                    owner.Tazkira = viewModel.Tazkira;
                    owner.TradeHome = viewModel.TradeHome;
                    owner.TradeName = viewModel.TradeName;
                    owner.TradeYear = viewModel.TradeYear;
                    owner.TypeHome = viewModel.TypeHome;
                    owner.TypeIncome = viewModel.TypeIncome;
                    owner.UseGenerator = viewModel.UseGenerator;
                    owner.TypeTrade = viewModel.TypeTrade;
               
                    owner.VillageLive = viewModel.VillageLive;
                    owner.WantEAT = viewModel.WantEAT;
                    owner.WayContact = viewModel.WayContact;
                    owner.WC = viewModel.WC;
                    owner.WhenUG = viewModel.WhenUG;

                    await  _context.SaveChangesAsync();
                    List<PowerMeter> powerMeterList = new List<PowerMeter>();
                    if (viewModel.PowerMeters.Count > 0)
                    {
                        for (int i = 0; i < viewModel.PowerMeters.Count; i++)
                        {
                            if (viewModel.PowerMeters[i].IDMeter != 0)
                            {
                                PowerMeter powerMeter = new PowerMeter()
                                {
                                    OwnerId = owner.OwnerId,
                                    DigitalOrAnalog = viewModel.PowerMeters[i].DigitalOrAnalog,
                                    IDMeter = viewModel.PowerMeters[i].IDMeter,
                                };
                                powerMeterList.Add(powerMeter);
                            }

                        }
                        await _context.AddRangeAsync(powerMeterList);

                    }

                    List<Resident> ResidentList = new List<Resident>();
                    if (viewModel.Residents.Count > 0)
                    {

                        for (int i = 0; i < viewModel.Residents.Count; i++)
                        {
                            if (viewModel.Residents[i].Name != null)
                            {
                                Resident resident = new Resident()
                                {
                                    Age = viewModel.Residents[i].Age,
                                    OwnerId = owner.OwnerId,
                                    Gender = viewModel.Residents[i].Gender,
                                    Income = viewModel.Residents[i].Income,
                                    Job = viewModel.Residents[i].Job,
                                    Name = viewModel.Residents[i].Name,

                                };
                                ResidentList.Add(resident);
                            }

                        }
                        await _context.AddRangeAsync(ResidentList);
                    }

                    List<EEquipmentCom> eEquipmentComsList = new List<EEquipmentCom>();
                    if (viewModel.EEquipmentComs.Count > 0)
                    {

                        for (int i = 0; i < viewModel.EEquipmentComs.Count; i++)
                        {
                            if (viewModel.EEquipmentComs[i].Name != null)
                            {

                              
                                    EEquipmentCom eEquipment = new EEquipmentCom()
                                    {
                                        AstahlakYear = viewModel.EEquipmentComs[i].AstahlakYear,
                                        Count = viewModel.EEquipmentComs[i].Count,
                                        Name = viewModel.EEquipmentComs[i].Name,
                                        Info = viewModel.EEquipmentComs[i].Info,
                                        OwnerId = owner.OwnerId,

                                    };
                                eEquipmentComsList.Add(eEquipment);
                             
                            }

                        }

                        await _context.AddRangeAsync(eEquipmentComsList);

                    }

                    List<EEquipmentH> eEquipmentH = new List<EEquipmentH>();
                    if (viewModel.EEquipmentHs.Count > 0)
                    {

                        for (int i = 0; i < viewModel.EEquipmentHs.Count; i++)
                        {
                            if (viewModel.EEquipmentHs[i].Name != null)
                            {

                                EEquipmentH eEquipment = new EEquipmentH()
                                {
                                    AstahlakYear = viewModel.EEquipmentHs[i].AstahlakYear,
                                    Count = viewModel.EEquipmentHs[i].Count,
                                    Name = viewModel.EEquipmentHs[i].Name,
                                    OwnerId = owner.OwnerId,


                                };
                                eEquipmentH.Add(eEquipment);
                            }


                        }
                        await _context.AddRangeAsync(eEquipmentH);
                    }


                    List<OwnerLanguage> LanguageList = new List<OwnerLanguage>();
                    if (viewModel.Language != null)
                    {
                        for (int i = 0; i < viewModel.Language.Length; i++)
                        {
                            if (viewModel.Language[i] != null)
                            {
                                OwnerLanguage language = new OwnerLanguage()
                                {
                                    OwnerId = owner.OwnerId,
                                    Name = viewModel.Language[i],

                                };
                                LanguageList.Add(language);
                            }

                        }
                        await _context.AddRangeAsync(LanguageList);

                    }

                    List<OwnerTypeWarming> TypeWarmingList = new List<OwnerTypeWarming>();
                    if (viewModel.UseTypeWarming != null)
                    {
                        for (int i = 0; i < viewModel.UseTypeWarming.Length; i++)
                        {
                            if (viewModel.UseTypeWarming[i] != null)
                            {
                                OwnerTypeWarming typeWarming = new OwnerTypeWarming()
                                {
                                    OwnerId = owner.OwnerId,
                                    Name = viewModel.UseTypeWarming[i],

                                };
                                TypeWarmingList.Add(typeWarming);
                            }

                        }
                        await _context.AddRangeAsync(TypeWarmingList);

                    }

                    await _context.SaveChangesAsync();
                    TempData["Success"] = "با موفقیت ثبت شد.";
                    return RedirectToAction("List");
                }
            }
            TempData["Danger"] = "خطایی رخ داده است.";
            return View();
        
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners(string search, string order, int offset, int limit, string sort)
        {
            List<OwnerShowListViewModel> allOwners;
            int total = _context.Owners.Count();

            if (string.IsNullOrWhiteSpace(search))
                search = "";

            if (limit == 0)
                limit = total;

            if (sort == "نام")
            {
                if (order == "asc")
                    allOwners = await _manager.GetPaginateOwnersAsync(offset, limit, "Name", search);
                else
                    allOwners = await _manager.GetPaginateOwnersAsync(offset, limit, "Name desc", search);
            }

      



            else if (sort == "نام کاربر")
            {
                if (order == "asc")
                    allOwners = await _manager.GetPaginateOwnersAsync(offset, limit, "UserName", search);
                else
                    allOwners = await _manager.GetPaginateOwnersAsync(offset, limit, "UserName desc", search);
            }

            else if (sort == "تاریخ ثبت")
            {
                if (order == "asc")
                    allOwners = await _manager.GetPaginateOwnersAsync(offset, limit, "RegisterDateTime", search);
                else
                    allOwners = await _manager.GetPaginateOwnersAsync(offset, limit, "RegisterDateTime desc", search);
            }

            else
                allOwners = await _manager.GetPaginateOwnersAsync(offset, limit, "RegisterDateTime desc", search);

            if (search != "")
                total = _context.Owners.Count();

            return Json(new { total = total, rows = allOwners });

        }



 
        [HttpGet, DisplayName("  حذف ")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!id.ToString().HasValue())
                ModelState.AddModelError(string.Empty, NotFoundOwner);
            else
            {
                var ownder = await _uw.BaseRepository<Owner>().FindByIdAsync(id);
                if (ownder == null)
                    ModelState.AddModelError(string.Empty, NotFoundOwner);
                else
                    return PartialView("_DeleteConfirmation", ownder);
            }
            return PartialView("_DeleteConfirmation");
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Owner model)
        {
            if (model.OwnerId.ToString() == null)
                ModelState.AddModelError(string.Empty, NotFoundOwner);
            else
            {
                var owner = await _uw.BaseRepository<Owner>().FindByIdAsync(model.OwnerId);
                if (owner == null)
                    ModelState.AddModelError(string.Empty, NotFoundOwner);
                else
                {////////////////////////////////
                    List<EEquipmentCom> eEquipmentComs = await _context.EEquipmentComs.Where(c => c.OwnerId == model.OwnerId).ToListAsync();

                    if (eEquipmentComs.Count > 0)
                    {
                        foreach (var item in eEquipmentComs)
                        {
                            _context.EEquipmentComs.Remove(item);
                        }
                    }
                    ////////////////////////////////////////////////////////////////
                    List<EEquipmentH> eEquipmentHs = await _context.EEquipmentHs.Where(c => c.OwnerId == model.OwnerId).ToListAsync();

                    if (eEquipmentHs.Count > 0)
                    {
                        foreach (var item in eEquipmentHs)
                        {
                            _context.EEquipmentHs.Remove(item);
                        }
                    }
                    List<OwnerTypeWarming> ownerTypeWarmings = await _context.OwnerTypeWarmings.Where(c => c.OwnerId == model.OwnerId).ToListAsync();

                    if (ownerTypeWarmings.Count > 0)
                    {
                        foreach (var item in ownerTypeWarmings)
                        {
                            _context.OwnerTypeWarmings.Remove(item);
                        }
                    }
                    //////////////////////////////////////////
                    List<OwnerLanguage> ownerLanguages = await _context.OwnerLanguages.Where(c => c.OwnerId == model.OwnerId).ToListAsync();

                    if (ownerLanguages.Count > 0)
                    {
                        foreach (var item in ownerLanguages)
                        {
                            _context.OwnerLanguages.Remove(item);
                        }
                    }
                    //////////////////////////////////////////
                    List<PowerMeter> powerMeters = await _context.PowerMeters.Where(c => c.OwnerId == model.OwnerId).ToListAsync();

                    if (powerMeters.Count > 0)
                    {
                        foreach (var item in powerMeters)
                        {
                            _context.PowerMeters.Remove(item);
                        }
                    }
                    //////////////////////////////////////////////
                    List<Resident> residents = await _context.Residents.Where(c => c.OwnerId == model.OwnerId).ToListAsync();

                    if (residents.Count > 0)
                    {
                        foreach (var item in residents)
                        {
                            _context.Residents.Remove(item);
                        }
                    }
                    ///////////////////////////////
                    await _context.SaveChangesAsync();
                    _uw.BaseRepository<Owner>().Delete(owner);
                    await _uw.Commit();
                    TempData["notification"] = "حذف اطلاعات با موفقیت انجام شد.";
                    return PartialView("_DeleteConfirmation", owner);
                }
            }
            return PartialView("_DeleteConfirmation");
        }


        [HttpGet, DisplayName("دانلود گروهی")]
        [Authorize]
        public void DownloadExcelAll(string Data)
        {

            var ids = Data.Split(",");

            using (var workBook = new XLWorkbook())
            {
                int currentRow = 1;
                var workSheet = workBook.Worksheets.Add("معلومات فارم صاحب خانه ");
                workSheet.Cell(currentRow, 1).Value = "نمبر فارم";
                workSheet.Cell(currentRow, 2).Value = "نمبر جکشن";
                workSheet.Cell(currentRow, 3).Value = "اسم";
                workSheet.Cell(currentRow, 4).Value = "تخلص";
                workSheet.Cell(currentRow, 5).Value = "اسم پدر";
                workSheet.Cell(currentRow, 6).Value = "نمبر تذکره";
                workSheet.Cell(currentRow, 7).Value = "اکانت برشنا";
                workSheet.Cell(currentRow, 8).Value = "شماره تماس";
                workSheet.Cell(currentRow, 9).Value = "حالت مدنی";
                workSheet.Cell(currentRow, 10).Value = "سن";
                workSheet.Cell(currentRow, 11).Value = "جنسیت ";
               
                workSheet.Cell(currentRow, 12).Value = "نوع درآمد";
                workSheet.Cell(currentRow, 13).Value = "مقدار درآمد ماهانه";
                workSheet.Cell(currentRow, 14).Value = "ولایت";
                workSheet.Cell(currentRow, 15).Value = "والسوالی/ ناحیه";
                workSheet.Cell(currentRow, 16).Value = "گذر";
                workSheet.Cell(currentRow, 17).Value = "نمبر خانه";
                workSheet.Cell(currentRow, 18).Value = "ولایت";
                workSheet.Cell(currentRow, 19).Value = "والسوالی/ ناحیه ";
                workSheet.Cell(currentRow, 20).Value = "گذر";
                workSheet.Cell(currentRow, 21).Value = "کشور";
                workSheet.Cell(currentRow, 22).Value = "آیا شما همراه فامیل در خانه زنده گی می کنید";
                workSheet.Cell(currentRow, 23).Value = "چند سال";
                workSheet.Cell(currentRow, 24).Value = "تعداد ساکنین";
                workSheet.Cell(currentRow, 25).Value = "لست تمام ساکنین به جز صاحب خانه";

                workSheet.Cell(currentRow, 26).Value = "نام";
                workSheet.Cell(currentRow, 27).Value = "وظیفه";
                workSheet.Cell(currentRow, 28).Value = "جنسیت";
                workSheet.Cell(currentRow, 29).Value = "سن";
                workSheet.Cell(currentRow, 30).Value = "درآمد";

                workSheet.Cell(currentRow, 31).Value = "نام";
                workSheet.Cell(currentRow, 32).Value = "وظیفه";
                workSheet.Cell(currentRow, 33).Value = "جنسیت";
                workSheet.Cell(currentRow, 34).Value = "سن";
                workSheet.Cell(currentRow, 35).Value = "درآمد";

                workSheet.Cell(currentRow, 36).Value = "نام";
                workSheet.Cell(currentRow, 37).Value = "وظیفه";
                workSheet.Cell(currentRow, 38).Value = "جنسیت";
                workSheet.Cell(currentRow, 39).Value = "سن";
                workSheet.Cell(currentRow, 40).Value = "درآمد";

                workSheet.Cell(currentRow, 41).Value = "نام";
                workSheet.Cell(currentRow, 42).Value = "وظیفه";
                workSheet.Cell(currentRow, 43).Value = "جنسیت";
                workSheet.Cell(currentRow, 44).Value = "سن";
                workSheet.Cell(currentRow, 45).Value = "درآمد";

                workSheet.Cell(currentRow, 46).Value = "نام";
                workSheet.Cell(currentRow, 47).Value = "وظیفه";
                workSheet.Cell(currentRow, 48).Value = "جنسیت";
                workSheet.Cell(currentRow, 49).Value = "سن";
                workSheet.Cell(currentRow, 50).Value = "درآمد";

                workSheet.Cell(currentRow, 51).Value = "نام";
                workSheet.Cell(currentRow, 52).Value = "وظیفه";
                workSheet.Cell(currentRow, 53).Value = "جنسیت";
                workSheet.Cell(currentRow, 54).Value = "سن";
                workSheet.Cell(currentRow, 55).Value = "درآمد";

                workSheet.Cell(currentRow, 56).Value = "نام";
                workSheet.Cell(currentRow, 57).Value = "وظیفه";
                workSheet.Cell(currentRow, 58).Value = "جنسیت";
                workSheet.Cell(currentRow, 59).Value = "سن";
                workSheet.Cell(currentRow, 60).Value = "درآمد";

                workSheet.Cell(currentRow, 61).Value = "نام";
                workSheet.Cell(currentRow, 62).Value = "وظیفه";
                workSheet.Cell(currentRow, 63).Value = "جنسیت";
                workSheet.Cell(currentRow, 64).Value = "سن";
                workSheet.Cell(currentRow, 65).Value = "درآمد";

                workSheet.Cell(currentRow, 66).Value = "نام";
                workSheet.Cell(currentRow, 67).Value = "وظیفه";
                workSheet.Cell(currentRow, 68).Value = "جنسیت";
                workSheet.Cell(currentRow, 69).Value = "سن";
                workSheet.Cell(currentRow, 70).Value = "درآمد";

                workSheet.Cell(currentRow, 71).Value = "نام";
                workSheet.Cell(currentRow, 72).Value = "وظیفه";
                workSheet.Cell(currentRow, 73).Value = "جنسیت";
                workSheet.Cell(currentRow, 74).Value = "سن";
                workSheet.Cell(currentRow, 75).Value = "درآمد";

                workSheet.Cell(currentRow, 76).Value = "برق شما کدام نوع است";
                workSheet.Cell(currentRow, 77).Value = "شما چند عدد میتر دارید";

                workSheet.Cell(currentRow, 78).Value = "آیدی میتر";
                workSheet.Cell(currentRow, 79).Value = "نوعیت میتر دیجینال یا انالوگ";
                workSheet.Cell(currentRow, 80).Value = "آیدی میتر";
                workSheet.Cell(currentRow, 81).Value = "نوعیت میتر دیجینال یا انالوگ";
                workSheet.Cell(currentRow, 82).Value = "آیدی میتر";
                workSheet.Cell(currentRow, 83).Value = "نوعیت میتر دیجینال یا انالوگ";
                workSheet.Cell(currentRow, 84).Value = "آیدی میتر";
                workSheet.Cell(currentRow, 85).Value = "نوعیت میتر دیجینال یا انالوگ";

                workSheet.Cell(currentRow, 86).Value = "آیا شما جنراتور استفاده می کنید";
                workSheet.Cell(currentRow, 87).Value = "جنراتور به کدام ظرفیت";
                workSheet.Cell(currentRow, 88).Value = "حد اوسط مدت استفاده شما از جنراتور در طول روز چند ساعت است";
                workSheet.Cell(currentRow, 89).Value = "چه وقت از جنراتور استفاده میکنید";
                workSheet.Cell(currentRow, 90).Value = "هزینه سوخت جنراتور شما در یک ماه تقریباً چند افغانی است";
                workSheet.Cell(currentRow, 91).Value = "آیا شما کدام منبع انرژی دیگری دارید";
                workSheet.Cell(currentRow, 92).Value = "اگر جواب بله هست مشخص کنید";
                workSheet.Cell(currentRow, 93).Value = "معلومات تجهیزات برقی ملکیت";

                workSheet.Cell(currentRow, 94).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 95).Value = "تعداد";
                workSheet.Cell(currentRow, 96).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 97).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 98).Value = "تعداد";
                workSheet.Cell(currentRow, 99).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 100).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 101).Value = "تعداد";
                workSheet.Cell(currentRow, 102).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 103).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 104).Value = "تعداد";
                workSheet.Cell(currentRow, 105).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 106).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 107).Value = "تعداد";
                workSheet.Cell(currentRow, 108).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 109).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 110).Value = "تعداد";
                workSheet.Cell(currentRow, 111).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 112).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 113).Value = "تعداد";
                workSheet.Cell(currentRow, 114).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 115).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 116).Value = "تعداد";
                workSheet.Cell(currentRow, 117).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 118).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 119).Value = "تعداد";
                workSheet.Cell(currentRow, 120).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 121).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 122).Value = "تعداد";
                workSheet.Cell(currentRow, 123).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 124).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 125).Value = "تعداد";
                workSheet.Cell(currentRow, 126).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 127).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 128).Value = "تعداد";
                workSheet.Cell(currentRow, 129).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 130).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 131).Value = "تعداد";
                workSheet.Cell(currentRow, 132).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 133).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 134).Value = "تعداد";
                workSheet.Cell(currentRow, 135).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 136).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 137).Value = "تعداد";
                workSheet.Cell(currentRow, 138).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 139).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 140).Value = "تعداد";
                workSheet.Cell(currentRow, 141).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 142).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 143).Value = "تعداد";
                workSheet.Cell(currentRow, 144).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 145).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 146).Value = "تعداد";
                workSheet.Cell(currentRow, 147).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 148).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 149).Value = "تعداد";
                workSheet.Cell(currentRow, 150).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 151).Value = "تعداد اتاق";
                workSheet.Cell(currentRow, 152).Value = "تعداد منزل";
                workSheet.Cell(currentRow, 153).Value = "تعداد تشناب";
                workSheet.Cell(currentRow, 154).Value = "تعداد آشپزخانه ";
                workSheet.Cell(currentRow, 155).Value = "نوعیت مکلیت";
                workSheet.Cell(currentRow, 156).Value = "اندازه تقریبی تعمیر به متر مربع";
                workSheet.Cell(currentRow, 157).Value = "اندازه تقریبی زمین به متر مربع";
                workSheet.Cell(currentRow, 158).Value = "شما در تابستان چند ساعت در روز از ایرکندیشن استفاده میکنید";
                workSheet.Cell(currentRow, 159).Value = "شما از کدام سیستم گرم کننده استفاده میکنید";
                workSheet.Cell(currentRow, 160).Value = "شما در زمستان چند ساعت در روز از بخاری برقی استفاده میکنید";
                workSheet.Cell(currentRow, 161).Value = "آیا از ملکیت برای مقاصد تجاری استفاده میکنید";
                workSheet.Cell(currentRow, 162).Value = "از ملکیت برای کدام مقاصد تجاری استفاده میکنید";
                workSheet.Cell(currentRow, 163).Value = "اسم نهاد تجارتی";
                workSheet.Cell(currentRow, 164).Value = "چند سال";
                workSheet.Cell(currentRow, 165).Value = "چند نفر کارمند مصروف کار در این ملکیت هستند";
                workSheet.Cell(currentRow, 166).Value = "تجهیزات برقی";

                workSheet.Cell(currentRow, 167).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 168).Value = "تعداد";
                workSheet.Cell(currentRow, 169).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 170).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 171).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 172).Value = "تعداد";
                workSheet.Cell(currentRow, 173).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 174).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 175).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 176).Value = "تعداد";
                workSheet.Cell(currentRow, 177).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 178).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 179).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 180).Value = "تعداد";
                workSheet.Cell(currentRow, 181).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 182).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 183).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 184).Value = "تعداد";
                workSheet.Cell(currentRow, 185).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 186).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 187).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 188).Value = "تعداد";
                workSheet.Cell(currentRow, 189).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 190).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 191).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 192).Value = "تعداد";
                workSheet.Cell(currentRow, 193).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 194).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 195).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 196).Value = "تعداد";
                workSheet.Cell(currentRow, 197).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 198).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 199).Value = "تعداد";
                workSheet.Cell(currentRow, 200).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 201).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 202).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 203).Value = "تعداد";
                workSheet.Cell(currentRow, 204).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 205).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 206).Value = "آیا شما بیل برق خود را در وقت معین دریاقت می کنید";
                workSheet.Cell(currentRow, 207).Value = "اگر نخیر، چند روز تاخیر دارد";
                workSheet.Cell(currentRow, 208).Value = "آیا تا حال برای پرداخت بل به صورت قسط وار درخواست نموده اید";
                workSheet.Cell(currentRow, 209).Value = "مبلغ بِل قبلی تان چند بود به افغانی";
                workSheet.Cell(currentRow, 210).Value = "آیا در وقت تعین شده بل خود را پرداخت نموده اید";
                workSheet.Cell(currentRow, 211).Value = "آیا شما 24 ساعت برق دارید";
                workSheet.Cell(currentRow, 212).Value = "گر نخیر، در طول روز چند ساعت دارید";
                workSheet.Cell(currentRow, 213).Value = "اگر نخیر، آیا میخواهید 24 ساعت برق داشته باشید";
                workSheet.Cell(currentRow, 214).Value = "آیا شما حاضر هستید پول بیشتر برای داشتن برق 24 ساعته بپردازید و از هزینه گزاف جنراتور جلو گیری کنید";
                workSheet.Cell(currentRow, 215).Value = "آیا شما میخواهید بخاطر سیستم سولری در خانه تان جهت داشتن برق 24 ساعته و کاهش بل برق، در برنامه سولر شرکت برشنا اشتراک کنید";
                workSheet.Cell(currentRow, 216).Value = "شما چقدر بودجه جهت سرمایه گذاری در برنامه سولری برشنا شرکت دارید";
                workSheet.Cell(currentRow, 217).Value = "لسان را که شما ترجیح میدهد با کارمند ده افغانستان برشنا شرکت در ارتباط باشید، کدام است";
                workSheet.Cell(currentRow, 218).Value = "لطف نموده ایمیل تان را بدهید";
                workSheet.Cell(currentRow, 219).Value = "شما جهت برقراری ارتباط کدام راه ترجیح میدهید";
                workSheet.Cell(currentRow, 220).Value = "از خدمات ما چقدر احساس رضایت دارید";
                workSheet.Cell(currentRow, 221).Value = "نظریات، پیشنهادات خود جهت بهبود خدمات د افغانستان برشنا شرکت با ما شریک بسازید";

                int current = 2;
                foreach (var id in ids)
                {

                    var owner = _context.Rents.Find(id.ToInt());
                    var family = _context.RentResidents.Where(a => a.RentId == id.ToInt()).ToList();
                    var metar = _context.RentPowerMeters.Where(a => a.RentId == id.ToInt()).ToList();
                    var equipmentHs = _context.RentEEquipmentHs.Where(a => a.RentId == id.ToInt()).ToList();
                    var warmings = _context.RentTypeWarmings.Where(a => a.RentId == id.ToInt()).ToList();
                    var equipmentComs = _context.RentEquipmentComs.Where(a => a.RentId == id.ToInt()).ToList();
                    var language = _context.RentLanguages.Where(a => a.RentId == id.ToInt()).ToList();

                    #region Header


                    #endregion

                    #region Body

                    workSheet.Cell(current, 1).Value = owner.FormNumber;
                    workSheet.Cell(current, 2).Value = owner.JaktionNumber;
                    workSheet.Cell(current, 3).Value = owner.Name;
                    workSheet.Cell(current, 4).Value = owner.LastName;
                    workSheet.Cell(current, 5).Value = owner.FatherName;
                    workSheet.Cell(current, 6).Value = owner.Tazkira;
                    workSheet.Cell(current, 7).Value = owner.AccountBrashna;
                    workSheet.Cell(current, 8).Value = owner.Phone;
                    workSheet.Cell(current, 9).Value = owner.Status;
                    workSheet.Cell(current, 10).Value = owner.Age;
                    workSheet.Cell(current, 11).Value = owner.Gender;
                    workSheet.Cell(current, 12).Value = owner.TypeIncome;
                    workSheet.Cell(current, 13).Value = owner.IncomeMonth;
                    workSheet.Cell(current, 14).Value = owner.Province;
                    workSheet.Cell(current, 15).Value = owner.Village;
                    workSheet.Cell(current, 16).Value = owner.Ghozar;
                    workSheet.Cell(current, 17).Value = owner.HouseNumber;
                    workSheet.Cell(current, 18).Value = owner.ProvinceLive;
                    workSheet.Cell(current, 19).Value = owner.VillageLive;
                    workSheet.Cell(current, 20).Value = owner.GhozarLive;
                    workSheet.Cell(current, 21).Value = owner.ProvinceLive;
                    workSheet.Cell(current, 22).Value = owner.LiveWF;
                    workSheet.Cell(current, 23).Value = owner.LiveWFAge;
                    workSheet.Cell(current, 24).Value = owner.CountLiveINFamily;

                    workSheet.Cell(current, 25).Value = "";
                    int col = 26;
                    var familytaken = family.Take(10);
                    foreach (var item in familytaken)
                    {
                        workSheet.Cell(current, col).Value = item.Name;
                        workSheet.Cell(current, col + 1).Value = item.Job;
                        workSheet.Cell(current, col + 2).Value = item.Gender;
                        workSheet.Cell(current, col + 3).Value = item.Age;
                        workSheet.Cell(current, col + 4).Value = item.Income;
                        col = col + 5;

                    }

                    workSheet.Cell(current, 76).Value = owner.EType;
                    workSheet.Cell(current, 77).Value = owner.EMCount;
                    int colm = 78;
                    var metertaken = metar.Take(4);
                    foreach (var item in metertaken)
                    {
                        workSheet.Cell(current, colm).Value = item.IDMeter;
                        workSheet.Cell(current, colm + 1).Value = item.DigitalOrAnalog;
                        colm = colm + 2;
                    }
                    workSheet.Cell(current, 86).Value = owner.UseGenerator;
                    workSheet.Cell(current, 87).Value = owner.CapacityG;
                    workSheet.Cell(current, 88).Value = owner.HourUG;
                    workSheet.Cell(current, 89).Value = owner.WhenUG;
                    workSheet.Cell(current, 90).Value = owner.ExpenseG;
                    workSheet.Cell(current, 91).Value = owner.SourceE;
                    workSheet.Cell(current, 92).Value = owner.EType;
                    workSheet.Cell(current, 93).Value = "معلومات تجهیزات برقی ملکیت";
                    int rowEqui = 94;
                    var equipmenttaken = equipmentHs.Take(19);
                    foreach (var item in equipmenttaken)
                    {
                        workSheet.Cell(current, rowEqui).Value = item.Name;
                        workSheet.Cell(current, rowEqui + 1).Value = item.Count;
                        workSheet.Cell(current, rowEqui + 2).Value = item.AstahlakYear;
                        rowEqui = rowEqui + 3;
                    }
                    workSheet.Cell(current, 151).Value = owner.Room;
                    workSheet.Cell(current, 152).Value = owner.Floor;
                    workSheet.Cell(current, 153).Value = owner.WC;
                    workSheet.Cell(current, 154).Value = owner.Kichen;
                    workSheet.Cell(current, 155).Value = owner.TypeHome;
                    workSheet.Cell(current, 156).Value = owner.AreaBuilding;
                    workSheet.Cell(current, 157).Value = owner.Land;
                    workSheet.Cell(current, 158).Value = owner.AirCandition;

                    var warmingstaken = warmings.Take(1);
                    foreach (var item in warmings)
                    {
                        workSheet.Cell(current, 159).Value = item.Name;

                    }

                    workSheet.Cell(current, 160).Value = owner.HourOnStove;
                    workSheet.Cell(current, 161).Value = owner.TradeHome;
                    workSheet.Cell(current, 162).Value = owner.TypeTrade;
                    workSheet.Cell(current, 163).Value = owner.TradeName;
                    workSheet.Cell(current, 164).Value = owner.TradeYear;
                    workSheet.Cell(current, 165).Value = owner.StaffCount;
                    workSheet.Cell(current, 166).Value = "";
                    int colelec = 167;
                    foreach (var item in equipmentComs)
                    {
                        workSheet.Cell(current, colelec).Value = item.Name;
                        workSheet.Cell(current, colelec + 1).Value = item.Count;
                        workSheet.Cell(current, colelec + 2).Value = item.AstahlakYear;
                        workSheet.Cell(current, colelec + 3).Value = item.Info;
                        colelec = colelec + 4;
                    }

                    workSheet.Cell(current, 206).Value = owner.BillRecive;
                    workSheet.Cell(current, 207).Value = owner.BillDayDaily;
                    workSheet.Cell(current, 208).Value = owner.GhastVar;
                    workSheet.Cell(current, 209).Value = owner.ExpenseOld;
                    workSheet.Cell(current, 210).Value = owner.PayOnTime;
                    workSheet.Cell(current, 211).Value = owner.EAlltime;
                    workSheet.Cell(current, 212).Value = owner.EHour;
                    workSheet.Cell(current, 213).Value = owner.WantEAT;
                    workSheet.Cell(current, 214).Value = owner.PayForEAT;
                    workSheet.Cell(current, 215).Value = owner.BSolor;
                    workSheet.Cell(current, 216).Value = owner.SolorAmountAssets;

                    int lang = 1;
                    foreach (var item in language.Take(1))
                    {
                        workSheet.Cell(current, 217).Value = item.Name;

                    }


                    workSheet.Cell(current, 218).Value = owner.EmailAddress;
                    workSheet.Cell(current, 219).Value = owner.WayContact;
                    workSheet.Cell(current, 220).Value = owner.Rezayat;
                    workSheet.Cell(current, 221).Value = owner.Suggestion;


                    #endregion
                    current++;

                }
                string tempPath = ("D:/ASP.NET CORE/Pro/Pro/wwwroot/files/" + "فورم_صاحب_خانه" + ".xlsx");
                FileInfo info = new FileInfo(tempPath);
                workBook.SaveAs(info.ToString());

                //var nameForm = "نمبر فارم" + "فورم_کرایه_نشین" + ".xlsx";
                //using (var stream = new MemoryStream())
                //{
                //    workBook.SaveAs(stream);

                //    var content = stream.ToArray();

                //    return File(
                //        content,
                //        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                //        nameForm
                //        );
                //}

            }
        }
        [HttpGet, DisplayName("  دانلود ")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public IActionResult DownloadExcel(int id)
        {
            var owner = _context.Owners.Find(id);
            var family = _context.Residents.Where(a => a.OwnerId == id).ToList();
            var metar = _context.PowerMeters.Where(a => a.OwnerId == id).ToList();
            var equipmentHs = _context.EEquipmentHs.Where(a => a.OwnerId == id).ToList();
            var warmings = _context.OwnerTypeWarmings.Where(a => a.OwnerId == id).ToList();
            var equipmentComs = _context.EEquipmentComs.Where(a => a.OwnerId == id).ToList();
            var language = _context.OwnerLanguages.Where(a => a.OwnerId == id).ToList();
            using (var workBook = new XLWorkbook()) {


                var workSheet = workBook.Worksheets.Add("معلومات فارم صاحب خانه");
                int currentRow = 1;

                #region Header
                workSheet.Cell(currentRow, 1).Value = "نمبر فارم";
                workSheet.Cell(currentRow, 2).Value = "نمبر جکشن";
                workSheet.Cell(currentRow, 3).Value = "اسم";
                workSheet.Cell(currentRow, 4).Value = "تخلص";
                workSheet.Cell(currentRow, 5).Value = "اسم پدر";
                workSheet.Cell(currentRow, 6).Value = "نمبر تذکره";
                workSheet.Cell(currentRow, 7).Value = "اکانت برشنا";
                workSheet.Cell(currentRow, 8).Value = "شماره تماس";
                workSheet.Cell(currentRow, 9).Value = "حالت مدنی";
                workSheet.Cell(currentRow, 10).Value = "سن";
                workSheet.Cell(currentRow, 11).Value = "جنسیت ";

                workSheet.Cell(currentRow, 12).Value = "نوع درآمد";
                workSheet.Cell(currentRow, 13).Value = "مقدار درآمد ماهانه";
                workSheet.Cell(currentRow, 14).Value = "ولایت";
                workSheet.Cell(currentRow, 15).Value = "والسوالی/ ناحیه";
                workSheet.Cell(currentRow, 16).Value = "گذر";
                workSheet.Cell(currentRow, 17).Value = "نمبر خانه";
                workSheet.Cell(currentRow, 18).Value = "ولایت";
                workSheet.Cell(currentRow, 19).Value = "والسوالی/ ناحیه ";
                workSheet.Cell(currentRow, 20).Value = "گذر";
                workSheet.Cell(currentRow, 21).Value = "کشور";
                workSheet.Cell(currentRow, 22).Value = "آیا شما همراه فامیل در خانه زنده گی می کنید";
                workSheet.Cell(currentRow, 23).Value = "چند سال";
                workSheet.Cell(currentRow, 24).Value = "تعداد ساکنین";
                workSheet.Cell(currentRow, 25).Value = "لست تمام ساکنین به جز صاحب خانه";

                workSheet.Cell(currentRow, 26).Value = "نام";
                workSheet.Cell(currentRow, 27).Value = "وظیفه";
                workSheet.Cell(currentRow, 28).Value = "جنسیت";
                workSheet.Cell(currentRow, 29).Value = "سن";
                workSheet.Cell(currentRow, 30).Value = "درآمد";

                workSheet.Cell(currentRow, 31).Value = "نام";
                workSheet.Cell(currentRow, 32).Value = "وظیفه";
                workSheet.Cell(currentRow, 33).Value = "جنسیت";
                workSheet.Cell(currentRow, 34).Value = "سن";
                workSheet.Cell(currentRow, 35).Value = "درآمد";

                workSheet.Cell(currentRow, 36).Value = "نام";
                workSheet.Cell(currentRow, 37).Value = "وظیفه";
                workSheet.Cell(currentRow, 38).Value = "جنسیت";
                workSheet.Cell(currentRow, 39).Value = "سن";
                workSheet.Cell(currentRow, 40).Value = "درآمد";

                workSheet.Cell(currentRow, 41).Value = "نام";
                workSheet.Cell(currentRow, 42).Value = "وظیفه";
                workSheet.Cell(currentRow, 43).Value = "جنسیت";
                workSheet.Cell(currentRow, 44).Value = "سن";
                workSheet.Cell(currentRow, 45).Value = "درآمد";

                workSheet.Cell(currentRow, 46).Value = "نام";
                workSheet.Cell(currentRow, 47).Value = "وظیفه";
                workSheet.Cell(currentRow, 48).Value = "جنسیت";
                workSheet.Cell(currentRow, 49).Value = "سن";
                workSheet.Cell(currentRow, 50).Value = "درآمد";

                workSheet.Cell(currentRow, 51).Value = "نام";
                workSheet.Cell(currentRow, 52).Value = "وظیفه";
                workSheet.Cell(currentRow, 53).Value = "جنسیت";
                workSheet.Cell(currentRow, 54).Value = "سن";
                workSheet.Cell(currentRow, 55).Value = "درآمد";

                workSheet.Cell(currentRow, 56).Value = "نام";
                workSheet.Cell(currentRow, 57).Value = "وظیفه";
                workSheet.Cell(currentRow, 58).Value = "جنسیت";
                workSheet.Cell(currentRow, 59).Value = "سن";
                workSheet.Cell(currentRow, 60).Value = "درآمد";

                workSheet.Cell(currentRow, 61).Value = "نام";
                workSheet.Cell(currentRow, 62).Value = "وظیفه";
                workSheet.Cell(currentRow, 63).Value = "جنسیت";
                workSheet.Cell(currentRow, 64).Value = "سن";
                workSheet.Cell(currentRow, 65).Value = "درآمد";

                workSheet.Cell(currentRow, 66).Value = "نام";
                workSheet.Cell(currentRow, 67).Value = "وظیفه";
                workSheet.Cell(currentRow, 68).Value = "جنسیت";
                workSheet.Cell(currentRow, 69).Value = "سن";
                workSheet.Cell(currentRow, 70).Value = "درآمد";

                workSheet.Cell(currentRow, 71).Value = "نام";
                workSheet.Cell(currentRow, 72).Value = "وظیفه";
                workSheet.Cell(currentRow, 73).Value = "جنسیت";
                workSheet.Cell(currentRow, 74).Value = "سن";
                workSheet.Cell(currentRow, 75).Value = "درآمد";

                workSheet.Cell(currentRow, 76).Value = "برق شما کدام نوع است";
                workSheet.Cell(currentRow, 77).Value = "شما چند عدد میتر دارید";

                workSheet.Cell(currentRow, 78).Value = "آیدی میتر";
                workSheet.Cell(currentRow, 79).Value = "نوعیت میتر دیجینال یا انالوگ";
                workSheet.Cell(currentRow, 80).Value = "آیدی میتر";
                workSheet.Cell(currentRow, 81).Value = "نوعیت میتر دیجینال یا انالوگ";
                workSheet.Cell(currentRow, 82).Value = "آیدی میتر";
                workSheet.Cell(currentRow, 83).Value = "نوعیت میتر دیجینال یا انالوگ";
                workSheet.Cell(currentRow, 84).Value = "آیدی میتر";
                workSheet.Cell(currentRow, 85).Value = "نوعیت میتر دیجینال یا انالوگ";

                workSheet.Cell(currentRow, 86).Value = "آیا شما جنراتور استفاده می کنید";
                workSheet.Cell(currentRow, 87).Value = "جنراتور به کدام ظرفیت";
                workSheet.Cell(currentRow, 88).Value = "حد اوسط مدت استفاده شما از جنراتور در طول روز چند ساعت است";
                workSheet.Cell(currentRow, 89).Value = "چه وقت از جنراتور استفاده میکنید";
                workSheet.Cell(currentRow, 90).Value = "هزینه سوخت جنراتور شما در یک ماه تقریباً چند افغانی است";
                workSheet.Cell(currentRow, 91).Value = "آیا شما کدام منبع انرژی دیگری دارید";
                workSheet.Cell(currentRow, 92).Value = "اگر جواب بله هست مشخص کنید";
                workSheet.Cell(currentRow, 93).Value = "معلومات تجهیزات برقی ملکیت";

                workSheet.Cell(currentRow, 94).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 95).Value = "تعداد";
                workSheet.Cell(currentRow, 96).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 97).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 98).Value = "تعداد";
                workSheet.Cell(currentRow, 99).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 100).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 101).Value = "تعداد";
                workSheet.Cell(currentRow, 102).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 103).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 104).Value = "تعداد";
                workSheet.Cell(currentRow, 105).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 106).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 107).Value = "تعداد";
                workSheet.Cell(currentRow, 108).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 109).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 110).Value = "تعداد";
                workSheet.Cell(currentRow, 111).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 112).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 113).Value = "تعداد";
                workSheet.Cell(currentRow, 114).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 115).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 116).Value = "تعداد";
                workSheet.Cell(currentRow, 117).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 118).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 119).Value = "تعداد";
                workSheet.Cell(currentRow, 120).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 121).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 122).Value = "تعداد";
                workSheet.Cell(currentRow, 123).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 124).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 125).Value = "تعداد";
                workSheet.Cell(currentRow, 126).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 127).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 128).Value = "تعداد";
                workSheet.Cell(currentRow, 129).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 130).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 131).Value = "تعداد";
                workSheet.Cell(currentRow, 132).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 133).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 134).Value = "تعداد";
                workSheet.Cell(currentRow, 135).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 136).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 137).Value = "تعداد";
                workSheet.Cell(currentRow, 138).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 139).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 140).Value = "تعداد";
                workSheet.Cell(currentRow, 141).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 142).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 143).Value = "تعداد";
                workSheet.Cell(currentRow, 144).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 145).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 146).Value = "تعداد";
                workSheet.Cell(currentRow, 147).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 148).Value = "تجهیزات برقی";
                workSheet.Cell(currentRow, 149).Value = "تعداد";
                workSheet.Cell(currentRow, 150).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 151).Value = "تعداد اتاق";
                workSheet.Cell(currentRow, 152).Value = "تعداد منزل";
                workSheet.Cell(currentRow, 153).Value = "تعداد تشناب";
                workSheet.Cell(currentRow, 154).Value = "تعداد آشپزخانه ";
                workSheet.Cell(currentRow, 155).Value = "نوعیت مکلیت";
                workSheet.Cell(currentRow, 156).Value = "اندازه تقریبی تعمیر به متر مربع";
                workSheet.Cell(currentRow, 157).Value = "اندازه تقریبی زمین به متر مربع";
                workSheet.Cell(currentRow, 158).Value = "شما در تابستان چند ساعت در روز از ایرکندیشن استفاده میکنید";
                workSheet.Cell(currentRow, 159).Value = "شما از کدام سیستم گرم کننده استفاده میکنید";
                workSheet.Cell(currentRow, 160).Value = "شما در زمستان چند ساعت در روز از بخاری برقی استفاده میکنید";
                workSheet.Cell(currentRow, 161).Value = "آیا از ملکیت برای مقاصد تجاری استفاده میکنید";
                workSheet.Cell(currentRow, 162).Value = "از ملکیت برای کدام مقاصد تجاری استفاده میکنید";
                workSheet.Cell(currentRow, 163).Value = "اسم نهاد تجارتی";
                workSheet.Cell(currentRow, 164).Value = "چند سال";
                workSheet.Cell(currentRow, 165).Value = "چند نفر کارمند مصروف کار در این ملکیت هستند";
                workSheet.Cell(currentRow, 166).Value = "تجهیزات برقی";

                workSheet.Cell(currentRow, 167).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 168).Value = "تعداد";
                workSheet.Cell(currentRow, 169).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 170).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 171).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 172).Value = "تعداد";
                workSheet.Cell(currentRow, 173).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 174).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 175).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 176).Value = "تعداد";
                workSheet.Cell(currentRow, 177).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 178).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 179).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 180).Value = "تعداد";
                workSheet.Cell(currentRow, 181).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 182).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 183).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 184).Value = "تعداد";
                workSheet.Cell(currentRow, 185).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 186).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 187).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 188).Value = "تعداد";
                workSheet.Cell(currentRow, 189).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 190).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 191).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 192).Value = "تعداد";
                workSheet.Cell(currentRow, 193).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 194).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 195).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 196).Value = "تعداد";
                workSheet.Cell(currentRow, 197).Value = "مدت استهلاک";

                workSheet.Cell(currentRow, 198).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 199).Value = "تعداد";
                workSheet.Cell(currentRow, 200).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 201).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 202).Value = "نام تجهیزات برقی";
                workSheet.Cell(currentRow, 203).Value = "تعداد";
                workSheet.Cell(currentRow, 204).Value = "مدت استهلاک";
                workSheet.Cell(currentRow, 205).Value = "سایر معلومات";

                workSheet.Cell(currentRow, 206).Value = "آیا شما بیل برق خود را در وقت معین دریاقت می کنید";
                workSheet.Cell(currentRow, 207).Value = "اگر نخیر، چند روز تاخیر دارد";
                workSheet.Cell(currentRow, 208).Value = "آیا تا حال برای پرداخت بل به صورت قسط وار درخواست نموده اید";
                workSheet.Cell(currentRow, 209).Value = "مبلغ بِل قبلی تان چند بود به افغانی";
                workSheet.Cell(currentRow, 210).Value = "آیا در وقت تعین شده بل خود را پرداخت نموده اید";
                workSheet.Cell(currentRow, 211).Value = "آیا شما 24 ساعت برق دارید";
                workSheet.Cell(currentRow, 212).Value = "گر نخیر، در طول روز چند ساعت دارید";
                workSheet.Cell(currentRow, 213).Value = "اگر نخیر، آیا میخواهید 24 ساعت برق داشته باشید";
                workSheet.Cell(currentRow, 214).Value = "آیا شما حاضر هستید پول بیشتر برای داشتن برق 24 ساعته بپردازید و از هزینه گزاف جنراتور جلو گیری کنید";
                workSheet.Cell(currentRow, 215).Value = "آیا شما میخواهید بخاطر سیستم سولری در خانه تان جهت داشتن برق 24 ساعته و کاهش بل برق، در برنامه سولر شرکت برشنا اشتراک کنید";
                workSheet.Cell(currentRow, 216).Value = "شما چقدر بودجه جهت سرمایه گذاری در برنامه سولری برشنا شرکت دارید";
                workSheet.Cell(currentRow, 217).Value = "لسان را که شما ترجیح میدهد با کارمند ده افغانستان برشنا شرکت در ارتباط باشید، کدام است";
                workSheet.Cell(currentRow, 218).Value = "لطف نموده ایمیل تان را بدهید";
                workSheet.Cell(currentRow, 219).Value = "شما جهت برقراری ارتباط کدام راه ترجیح میدهید";
                workSheet.Cell(currentRow, 220).Value = "از خدمات ما چقدر احساس رضایت دارید";
                workSheet.Cell(currentRow, 221).Value = "نظریات، پیشنهادات خود جهت بهبود خدمات د افغانستان برشنا شرکت با ما شریک بسازید";

                #endregion

                #region Body
                currentRow++;
                workSheet.Cell(currentRow, 1).Value = owner.FormNumber;
                workSheet.Cell(currentRow, 2).Value = owner.JaktionNumber;
                workSheet.Cell(currentRow, 3).Value = owner.Name;
                workSheet.Cell(currentRow, 4).Value = owner.LastName;
                workSheet.Cell(currentRow, 5).Value = owner.FatherName;
                workSheet.Cell(currentRow, 6).Value = owner.Tazkira;
                workSheet.Cell(currentRow, 7).Value = owner.AccountBrashna;
                workSheet.Cell(currentRow, 8).Value = owner.Phone;
                workSheet.Cell(currentRow, 9).Value = owner.Status;
                workSheet.Cell(currentRow, 10).Value = owner.Age;
                workSheet.Cell(currentRow, 11).Value = owner.Gender;
                workSheet.Cell(currentRow, 12).Value = owner.TypeIncome;
                workSheet.Cell(currentRow, 13).Value = owner.IncomeMonth;
                workSheet.Cell(currentRow, 14).Value = owner.Province;
                workSheet.Cell(currentRow, 15).Value = owner.Village;
                workSheet.Cell(currentRow, 16).Value = owner.Ghozar;
                workSheet.Cell(currentRow, 17).Value = owner.HouseNumber;
                workSheet.Cell(currentRow, 18).Value = owner.ProvinceLive;
                workSheet.Cell(currentRow, 19).Value = owner.VillageLive;
                workSheet.Cell(currentRow, 20).Value = owner.GhozarLive;
                workSheet.Cell(currentRow, 21).Value = owner.ProvinceLive;
                workSheet.Cell(currentRow, 22).Value = owner.LiveWF;
                workSheet.Cell(currentRow, 23).Value = owner.LiveWFAge;
                workSheet.Cell(currentRow, 24).Value = owner.CountLiveINFamily;

                workSheet.Cell(currentRow, 25).Value = "";
                int col = 26;
                var familytaken = family.Take(10);
                foreach (var item in familytaken)
                {
                    workSheet.Cell(currentRow, col).Value = item.Name;
                    workSheet.Cell(currentRow, col + 1).Value = item.Job;
                    workSheet.Cell(currentRow, col + 2).Value = item.Gender;
                    workSheet.Cell(currentRow, col + 3).Value = item.Age;
                    workSheet.Cell(currentRow, col + 4).Value = item.Income;
                    col = col + 5;

                }

                workSheet.Cell(currentRow, 76).Value = owner.EType;
                workSheet.Cell(currentRow, 77).Value = owner.EMCount;
                int colm = 78;
                var metertaken = metar.Take(4);
                foreach (var item in metertaken)
                {
                    workSheet.Cell(currentRow, colm).Value = item.IDMeter;
                    workSheet.Cell(currentRow, colm + 1).Value = item.DigitalOrAnalog;
                    colm = colm + 2;
                }
                workSheet.Cell(currentRow, 86).Value = owner.UseGenerator;
                workSheet.Cell(currentRow, 87).Value = owner.CapacityG;
                workSheet.Cell(currentRow, 88).Value = owner.HourUG;
                workSheet.Cell(currentRow, 89).Value = owner.WhenUG;
                workSheet.Cell(currentRow, 90).Value = owner.ExpenseG;
                workSheet.Cell(currentRow, 91).Value = owner.SourceE;
                workSheet.Cell(currentRow, 92).Value = owner.EType;
                workSheet.Cell(currentRow, 93).Value = "معلومات تجهیزات برقی ملکیت";
                int rowEqui = 94;
                var equipmenttaken = equipmentHs.Take(19);
                foreach (var item in equipmenttaken)
                {
                    workSheet.Cell(currentRow, rowEqui).Value = item.Name;
                    workSheet.Cell(currentRow, rowEqui + 1).Value = item.Count;
                    workSheet.Cell(currentRow, rowEqui + 2).Value = item.AstahlakYear;
                    rowEqui = rowEqui + 3;
                }
                workSheet.Cell(currentRow, 151).Value = owner.Room;
                workSheet.Cell(currentRow, 152).Value = owner.Floor;
                workSheet.Cell(currentRow, 153).Value = owner.WC;
                workSheet.Cell(currentRow, 154).Value = owner.Kichen;
                workSheet.Cell(currentRow, 155).Value = owner.TypeHome;
                workSheet.Cell(currentRow, 156).Value = owner.AreaBuilding;
                workSheet.Cell(currentRow, 157).Value = owner.Land;
                workSheet.Cell(currentRow, 158).Value = owner.AirCandition;

                var warmingstaken = warmings.Take(1);
                foreach (var item in warmings)
                {
                    workSheet.Cell(currentRow, 159).Value = item.Name;

                }

                workSheet.Cell(currentRow, 160).Value = owner.HourOnStove;
                workSheet.Cell(currentRow, 161).Value = owner.TradeHome;
                workSheet.Cell(currentRow, 162).Value = owner.TypeTrade;
                workSheet.Cell(currentRow, 163).Value = owner.TradeName;
                workSheet.Cell(currentRow, 164).Value = owner.TradeYear;
                workSheet.Cell(currentRow, 165).Value = owner.StaffCount;
                workSheet.Cell(currentRow, 166).Value = "";
                int colelec = 167;
                foreach (var item in equipmentComs)
                {
                    workSheet.Cell(currentRow, colelec).Value = item.Name;
                    workSheet.Cell(currentRow, colelec + 1).Value = item.Count;
                    workSheet.Cell(currentRow, colelec + 2).Value = item.AstahlakYear;
                    workSheet.Cell(currentRow, colelec + 3).Value = item.Info;
                    colelec = colelec + 4;
                }

                workSheet.Cell(currentRow, 206).Value = owner.BillRecive;
                workSheet.Cell(currentRow, 207).Value = owner.BillDayDaily;
                workSheet.Cell(currentRow, 208).Value = owner.GhastVar;
                workSheet.Cell(currentRow, 209).Value = owner.ExpenseOld;
                workSheet.Cell(currentRow, 210).Value = owner.PayOnTime;
                workSheet.Cell(currentRow, 211).Value = owner.EAlltime;
                workSheet.Cell(currentRow, 212).Value = owner.EHour;
                workSheet.Cell(currentRow, 213).Value = owner.WantEAT;
                workSheet.Cell(currentRow, 214).Value = owner.PayForEAT;
                workSheet.Cell(currentRow, 215).Value = owner.BSolor;
                workSheet.Cell(currentRow, 216).Value = owner.SolorAmountAssets;

                int lang = 1;
                foreach (var item in language.Take(1))
                {
                    workSheet.Cell(currentRow, 217).Value = item.Name;

                }


                workSheet.Cell(currentRow, 218).Value = owner.EmailAddress;
                workSheet.Cell(currentRow, 219).Value = owner.WayContact;
                workSheet.Cell(currentRow, 220).Value = owner.Rezayat;
                workSheet.Cell(currentRow, 221).Value = owner.Suggestion;


                #endregion
                var nameForm = "نمبر فارم" + owner.FormNumber + ".xlsx";
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);

                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        nameForm
                        );
                }
            }
        }
    }
}
