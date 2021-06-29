using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrleansShopContainer.Inventory.Domain
{
    public interface ICatalogItem : IGrainWithIntegerKey
    {
        Task<int> RemoveStock(int quantityDesired);
        Task<int> AddStock(int quantity);
        Task<CatalogItemDto> GetCatalogInformation();
    }
}
