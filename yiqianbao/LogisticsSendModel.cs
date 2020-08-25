using System.Linq;

namespace Tuhu.Yewu.WinService.TmallShopManage.Models
{
    public class LogisticsSendModel
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public string DeliveryCompany { get; set; }
        public string[] DeliveryCodes { get; set; }
        public string DeliveryType { get; set; }
        public bool IsDummySend => DeliveryType == "1ShopInstall" || DeliveryType == "4NoDelivery" || string.IsNullOrWhiteSpace(DeliveryCompany) || !DeliveryCodes.Any();
        public LogisticsSendItemModel[] Items { get; set; }
    }
    public class LogisticsSendItemModel
    {
        public string RefId { get; set; }
        public int Num { get; set; }
        public string RefProductId { get; set; }
    }
}
