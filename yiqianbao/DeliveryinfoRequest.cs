using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yiqianbao
{
   //如果好用，请收藏地址，帮忙分享。

    #region 物流回传信息接口

    /// <summary>
    /// 物流回传信息接口
    /// /deliveryinfo
    /// </summary>
    public class DeliveryinfoRequest
    {
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



    public class DeliveryinfoResponse
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("resp_code")]
        public string RespCode { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("resp_msg")]
        public string RespMsg { get; set; }
        /// <summary>
        /// 成功数量
        /// </summary>
        [JsonProperty("success_count")]
        public int SuccessCount { get; set; }
        /// <summary>
        /// 失败数量
        /// </summary>
        [JsonProperty("fail_count")]
        public string FailCount { get; set; }
        /// <summary>
        /// 失败记录列表
        /// </summary>
        [JsonProperty("fail_kuaidi_list")]
        public List<FailkuaidiListItem> FailkuaidiList { get; set; }
    }

    public class FailkuaidiListItem
    {
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
        /// <summary>
        /// 失败原因:
        /// 快递公司名字不匹配
        /// </summary>
        [JsonProperty("fail_reatrue")]
        public string FailReatrue { get; set; }
    }


    #endregion

    //#region 物流详情信息回传更新

    ///// <summary>
    ///// 物流详情信息回传更新
    ////deliverydetail
    ////如果好用，请收藏地址，帮忙分享。
    ///// </summary>
    //public class DeliveryDetailRequest
    //{
    //    List<DeliveryDetailItem> DeliveryDetailList { get; set; }
    //}
    //public class DeliveryDetailItem
    //{
    //    /// <summary>
    //    /// 上海分拨中心/装件入车扫描 
    //    /// </summary>
    //    public string context { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string time { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string ftime { get; set; }
    //}


    //public class DeliveryDetailResponse
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public List<Data_listItem> data_list { get; set; }
    //}
    //public class Data_listItem
    //{
    //    /// <summary>
    //    /// 上海分拨中心/装件入车扫描 
    //    /// </summary>
    //    public string context { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string time { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string ftime { get; set; }
    //}

    

    //#endregion


}
