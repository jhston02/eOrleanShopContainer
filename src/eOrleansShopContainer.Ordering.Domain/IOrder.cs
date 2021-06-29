using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrleansShopContainer.Ordering.Domain
{
    public interface IOrder : IGrainWithIntegerKey
    {
        void SetPaymentId(int id);

        void SetBuyerId(int id);

        void SetAwaitingValidationStatus();

        void SetStockConfirmedStatus();

        void SetPaidStatus();

        void SetShippedStatus();

        void SetCancelledStatus();

        void SetCancelledStatusWhenStockIsRejected(IEnumerable<int> orderStockRejectedItems);

        decimal GetTotal();
    }
}
