using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuhu.Yewu.WinService.TmallShopManage.Models;

namespace Tuhu.Yewu.WinService.TmallShopManage.Manager
{
    public interface IShopManage
    {
        BaseOrderModel[] DownloadOrder(DateTime startDateTime, DateTime endDateTime);
        bool UpdateMemo(string orderId, string sellerMemo);
        IEnumerable<string> LogisticsSend(IDictionary<string, LogisticsSendModel[]> source);
        /// <summary>
        /// 下载售后
        /// </summary>
        /// <param name="shopCode"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>       
        /// <returns></returns>
        Task DownLoadAfterSale(string shopCode, DateTime startDateTime, DateTime endDateTime);
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="shopCode"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        Task CancelOrder(string shopCode, DateTime startDateTime, DateTime endDateTime);
    }
}
