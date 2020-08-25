using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yiqianbao
{
    public class Request
    {
    }//如果好用，请收藏地址，帮忙分享。

    //#region 物流回传信息接口

    ///// <summary>
    ///// 物流回传信息接口
    ///// 	Sent	已发送
    ///// /deliveryinfo
    ///// </summary>
    //public class DeliveryinfoRequest
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string shop_id { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public List<Sub_kuaidi_listItem> sub_kuaidi_list { get; set; }
    //}

    //public class Sub_kuaidi_listItem
    //{
    //    /// <summary>
    //    /// 圆通速递
    //    /// </summary>
    //    public string kuaidiname { get; set; }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string kuaidinumber { get; set; }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string Kuaiditype { get; set; }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string order_id { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string sub_order_id { get; set; }
    //}



    ////如果好用，请收藏地址，帮忙分享。


    //public class DeliveryinfoResponse
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string resp_code { get; set; }
    //    /// <summary>
    //    /// 成功
    //    /// </summary>
    //    public string resp_msg { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public int Success_count { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string fail_count { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public List<Fail_kuaidi_listItem> fail_kuaidi_list { get; set; }
    //}

    //public class Fail_kuaidi_listItem
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string order_id { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string sub_order_id { get; set; }
    //    /// <summary>
    //    /// 快递公司名字不匹配
    //    /// </summary>
    //    public string fail_reatrue { get; set; }
    //}


    //#endregion

    #region 物流详情信息回传更新

    /// <summary>
    /// 物流详情信息回传更新
    /// Signed	已签收
    //deliverydetail
    //如果好用，请收藏地址，帮忙分享。
    /// </summary>
    public class DeliveryDetailRequest
    {
        List<DeliveryDetailItem> DeliveryDetailList { get; set; }
    }
    public class DeliveryDetailItem
    {
        /// <summary>
        /// 上海分拨中心/装件入车扫描 
        /// </summary>
        public string context { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ftime { get; set; }
    }


    public class DeliveryDetailResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Data_listItem> data_list { get; set; }
    }
    public class Data_listItem
    {
        /// <summary>
        /// 上海分拨中心/装件入车扫描 
        /// </summary>
        public string context { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ftime { get; set; }
    }

    

    #endregion


}
