using Pro.ViewModels.Owner;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Services.Contracts
{
   public interface IApplicationOwnerManager
    {
        Task<List<OwnerShowListViewModel>> GetPaginateOwnersAsync(int offset, int limit, string orderBy, string searchText);
        Task<List<OwnerShowListViewModel>> GetPaginateRentsAsync(int offset, int limit, string orderBy, string searchText);
      
    }
}
