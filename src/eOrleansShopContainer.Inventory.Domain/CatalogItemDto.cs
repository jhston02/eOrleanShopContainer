using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrleansShopContainer.Inventory.Domain
{
    [Serializable]
    public class CatalogItemDto
    {
        public CatalogItemDto(CatalogItemState state)
        {
            this.Id = state.Id;
            this.Name = state.Name;
            this.Description = state.Description;
            this.Price = state.Price;
            this.PictureFileName = state.PictureFileName;
            this.PictureUri = state.PictureUri;
            this.CatalogTypeId = state.CatalogTypeId;
            this.CatalogType = state.CatalogType;
            this.CatalogBrandId = state.CatalogBrandId;
            this.CatalogBrand = state.CatalogBrand;
            this.AvailableStock = state.AvailableStock;
            this.MaxStockThreshold = state.MaxStockThreshold;
            this.OnReorder = state.OnReorder;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public string PictureFileName { get; private set; }

        public string PictureUri { get; private set; }

        public int CatalogTypeId { get; private set; }

        public string CatalogType { get; private set; }

        public int CatalogBrandId { get; private set; }

        public string CatalogBrand { get; private set; }

        // Quantity in stock
        public int AvailableStock { get; private set; }

        // Available stock at which we should reorder
        public int RestockThreshold { get; private set; }

        // Maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses)
        public int MaxStockThreshold { get; private set; }

        /// <summary>
        /// True if item is on reorder
        /// </summary>
        public bool OnReorder { get; private set; }
    }
}
