using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// 物流回传信息接口
    /// /deliveryinfo
    /// </summary>
    public class DeliveryinfoRequest
    {
        public DeliveryinfoRequest(string shopId)
        {
            ShopId = shopId;
        }

        public DeliveryinfoRequest( )
        { 
        }

        /// <summary>
        /// 商户编号
        /// </summary>
        ///
        [JsonProperty("shop_id")]
        public string ShopId { get; set; }

        /// <summary>
        /// 子订单列表
        /// </summary>
        [JsonProperty("sub_kuaidi_list")]
        public List<SubKuaidiListItem> SubKuaidiList { get; set; }
    }

    public class SubKuaidiListItem
    {
        /// <summary>
        /// 快递公司
        /// 圆通速递
        /// </summary>
        [JsonProperty("kuaidiname")]
        public string KuaidiName { get; set; }

        /// <summary>
        /// 快递单号
        /// 1、可查询的快递编号值； 2、快递单号值；
        /// </summary>
        [JsonProperty("kuaidinumber")]
        public string KuaidiNumber { get; set; }

        /// <summary>
        /// 快递公司类别
        /// 0— 快递100支持的快递公司；其他值为非快递100支持公司，需约定分配
        /// </summary
        [JsonProperty("kuaiditype")]
        public string KuaidiType { get; set; }

        /// <summary>
        /// 壹钱包父订单号
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// 壹钱包子订单号
        /// </summary>
        [JsonProperty("sub_order_id")]
        public string SubOrderId { get; set; }
    }
}
