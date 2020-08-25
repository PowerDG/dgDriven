using System;
using System.Collections.Generic;
using System.Configuration;

namespace Tuhu.Yewu.WinService.TmallShopManage.Models
{
    public abstract class BaseOrderModel
    {
        public virtual string BuyerNick => null;
        public virtual string VenderId => null;
        public abstract DateTime CreateDateTime { get; }
        public abstract DateTime LastUpdateDateTime { get; }
        public abstract string Remark { get; }
        public abstract string SystemRemark { get; }
        public abstract long SumQuantity { get; }
        public abstract decimal SumMoney { get; }
        public abstract decimal? ShippingMoney { get; }
        /// <summary>
        /// 平台优惠
        /// </summary>
        public abstract decimal PlatformDiscount { get; }
        public abstract decimal? SumPaid { get; }
        public virtual string PayMethod => "8pingtai";
        public virtual string PaymentType => "5Special";
        public abstract DateTime? PayTime { get; }
        public abstract string InvoiceTitle { get; }
        public abstract string InvoiceType { get; }
        public abstract string RefNo { get; }
        public abstract string Status { get; }
        public abstract bool IsWaitSellerSendGoods { get; }
        public virtual decimal? InstallFee => null;
        public virtual string PlateNumber => null;

        public virtual string OrderType => "1普通";

        public virtual int? WarehouseID => null;

        public virtual string WarehouseName => null;

        public virtual Service.Shop.Models.ShopModel Shop => null;

        public abstract object RawObject { get; }
        public virtual string AlipayNo => string.Empty;

        public virtual string BuyerAlipayNo => string.Empty;
        public virtual bool IsPresaleOrder => false;

        /// <summary>收货人信息</summary>
        public abstract ConsigneeModel ConsigneeInfo { get; }

        /// <summary>订单明细</summary>
        public abstract IEnumerable<BaseOrderItemModel> Items { get; }
    }

    public abstract class ConsigneeModel
    {
        /// <summary>收货人姓名</summary>
        public abstract string Name { get; }

        /// <summary>收货人手机号</summary>
        public abstract string Cellphone { get; }

        /// <summary>收货人电话号码</summary>
        public virtual string Telphone => null;

        /// <summary>省</summary>
        public abstract string Province { get; }

        /// <summary>市</summary>
        public abstract string City { get; }

        /// <summary>县</summary>
        public abstract string County { get; }

        /// <summary>详细地址</summary>
        public abstract string Address { get; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public abstract Service.UserAccount.Enums.UserCategoryIn Category { get; }

        /// <summary>邮编</summary>
        public virtual string Zip => null;
    }

    public abstract class BaseOrderItemModel
    {
        private static readonly string InstallMoneyProductId;

        static BaseOrderItemModel()
        {
            InstallMoneyProductId = "";// ConfigurationManager.AppSettings["InstallMoneyProductID"];
        }

        /// <summary>平台产品编号</summary>
        public abstract string RefId { get; }

        /// <summary>商家产品编码编号</summary>
        public string Pid { get; set; }

        public string OriginalPid { get; set; }
        /// <summary>成本价</summary>
        public virtual decimal Cost { get; }
        /// <summary>
        /// 第三方产品名称
        /// </summary>
        public abstract string PartnerName { get; }
        /// <summary>产品备注</summary>
        public abstract string Remark { get; }
        /// <summary>
        /// 轮胎周期
        /// </summary>
        public virtual string WeekYear => null;

        /// <summary>数量</summary>
        public abstract long Quantity { get; }

        /// <summary>价格</summary>
        public abstract decimal OriginalPrice { get; }

        /// <summary>价格</summary>
        public abstract decimal Price { get; }

        /// <summary>是否是安装费</summary>
        public virtual bool IsInstallFee => string.Compare(Pid, InstallMoneyProductId, true) == 0;
    }


}
