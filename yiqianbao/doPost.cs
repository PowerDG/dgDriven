using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tuhu.Yewu.WinService.TmallShopManage.Models;

namespace yiqianbao
{
    public class PinganShopManager
    {
        private readonly string _shopCode;
        //private readonly IPddClient _client;

        public PinganShopManager(string shopCode)
        {
            //this.accessToken = accessToken;
            _shopCode = shopCode;
            //_client = new PddClient(Config.ApiUrl, Config.AppKey, Config.AppSecret);
        }
        public void LogisticsSendAsync(IDictionary<string, LogisticsSendModel[]> source)
        {
            var request = new DeliveryinfoRequest() { ShopId= _shopCode };
            foreach (var item in source)
            {

            }
            var response = new DeliveryinfoResponse();
            //request.LogisticsId = "1274";

        }
        public void post()
        {
            try
            {
                int count = 0;
                var requestCompleted = false;
                //var request = new OrderMqReceiveEventRequest
                //{
                //    EventId = Guid.NewGuid().ToString(),
                //    EventName = eventName + eventSubName,
                //    EventType = eventType,
                //    Data = model,
                //    Description = description
                //};
                do
                {
                    try
                    {
                        var Code = 100;
                            //response = await orderOutreachApiClient.OrderMqReceiveEventAsync(request);
                        if (Code == 10000)
                        {
                            //log.Info($"OrderMqReceiveEventAsyncSuccess,request:{JsonConvert.SerializeObject(request)}");
                            requestCompleted = true;
                            break;
                        }
                        //log.Error($"OrderMqReceiveEventAsyncError1:{response.Message}");
                        count++;
                    }
                    catch (Exception ex)
                    {
                        //log.Error("OrderMqReceiveEventAsyncException.1", ex);
                    }
                    var latencyTime = (int)Math.Pow(2u, (count)) *1000;
                    Thread.Sleep(latencyTime);
                } while (count < 3);
                if (!requestCompleted)
                {

                    //log.Error("OrderMqReceiveEventAsyncException.1", ex);
                }
            }
            catch (Exception ex)
            {
                //log.Error("OrderMqReceiveEventAsyncException.2", ex);
            }
        }
    }
}
