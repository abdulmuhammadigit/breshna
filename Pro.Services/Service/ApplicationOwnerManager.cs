using Microsoft.EntityFrameworkCore;
using Pro.Common;
using Pro.DataAccess;
using Pro.Services.Contracts;
using Pro.ViewModels.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Services.Service
{
    public class ApplicationOwnerManager : IApplicationOwnerManager
    {
        DataBaseContext _context;
        public ApplicationOwnerManager(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<List<OwnerShowListViewModel>> GetPaginateOwnersAsync(int offset, int limit, string orderBy, string searchText)
        {
            var getDateTimesForSearch = searchText.GetDateTimeForSearch();
            var users = await _context.Owners.Include(s=>s.User)
                  .Where(t => t.Name.Contains(searchText) || t.FatherName.Contains(searchText) || t.LastName.Contains(searchText)  || t.EmailAddress.Contains(searchText)  || t.FormNumber.Contains(searchText) || (t.RegisterDateTime >= getDateTimesForSearch.First() && t.RegisterDateTime <= getDateTimesForSearch.Last()))
                  .OrderByDescending(a => a.RegisterDateTime)
                  .Skip(offset).Take(limit)
                  .Select(a => new OwnerShowListViewModel
                  {
                      FormNumber=a.FormNumber,
                      Phone=a.Phone,
                      LastName=a.LastName,
                      EmailAddress=a.EmailAddress,
                      FatherName=a.FatherName,
                      Id=a.OwnerId,
                      Name=a.Name,
                      PersianRegisterDateTime = DateTimeExtensions.ConvertMiladiToShamsi(a.RegisterDateTime, "yyyy/MM/dd"),
                      UserName = a.User.FirstName,
                     

                  }).AsNoTracking().ToListAsync();

            foreach (var item in users)
                item.Row = ++offset;

            return users;
        }

        public async Task<List<OwnerShowListViewModel>> GetPaginateRentsAsync(int offset, int limit, string orderBy, string searchText)
        {
            var getDateTimesForSearch = searchText.GetDateTimeForSearch();
            var users = await _context.Rents.Include(s => s.User)
                  .Where(t => t.Name.Contains(searchText) || t.FatherName.Contains(searchText) || t.LastName.Contains(searchText) || t.EmailAddress.Contains(searchText) || t.FormNumber.Contains(searchText) || (t.RegisterDateTime >= getDateTimesForSearch.First() && t.RegisterDateTime <= getDateTimesForSearch.Last()))
                  .OrderByDescending(a => a.RegisterDateTime)
                  .Skip(offset).Take(limit)
                  .Select(a => new OwnerShowListViewModel
                  {
                      FormNumber = a.FormNumber,
                      Phone = a.Phone,
                      LastName = a.LastName,
                      EmailAddress = a.EmailAddress,
                      FatherName = a.FatherName,
                      Id = a.RentId,
                      Name = a.Name,
                      PersianRegisterDateTime = DateTimeExtensions.ConvertMiladiToShamsi(a.RegisterDateTime, "yyyy/MM/dd"),
                      UserName = a.User.FirstName,


                  }).AsNoTracking().ToListAsync();

            foreach (var item in users)
                item.Row = ++offset;

            return users;
        }


    }

}
