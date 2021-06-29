using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrleansShopContainer.Inventory.Domain
{
    public class CatalogItemGrain : ICatalogItem
    {
        IPersistentState<CatalogItemState> catalogItem;
        
        public CatalogItemGrain([PersistentState("catalogItem", "catalogItemStore")] IPersistentState<CatalogItemState> catalogItem)
        {
            this.catalogItem = catalogItem;
        }

        public async Task<int> AddStock(int quantity)
        {
            int original = this.catalogItem.State.AvailableStock;

            if ((this.catalogItem.State.AvailableStock + quantity) > this.catalogItem.State.MaxStockThreshold)
            {
                this.catalogItem.State.AvailableStock += (this.catalogItem.State.MaxStockThreshold - this.catalogItem.State.AvailableStock);
            }
            else
            {
                this.catalogItem.State.AvailableStock += quantity;
            }

            this.catalogItem.State.OnReorder = false;

            await catalogItem.WriteStateAsync();

            return this.catalogItem.State.AvailableStock - original;
        }

        public Task<CatalogItemDto> GetCatalogInformation()
        {
            return Task.FromResult(new CatalogItemDto(this.catalogItem.State));
        }

        public async Task<int> RemoveStock(int quantityDesired)
        {
            if (this.catalogItem.State.AvailableStock == 0)
            {
                throw new CatalogDomainException($"Empty stock, product item {this.catalogItem.State.Name} is sold out");
            }

            if (quantityDesired <= 0)
            {
                throw new CatalogDomainException($"Item units desired should be greater than zero");
            }

            int removed = Math.Min(quantityDesired, this.catalogItem.State.AvailableStock);

            this.catalogItem.State.AvailableStock -= removed;

            await catalogItem.WriteStateAsync();

            return removed;
        }
    }
}
