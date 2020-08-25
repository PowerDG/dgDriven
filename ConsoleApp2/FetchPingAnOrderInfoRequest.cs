using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public  class FetchPingAnOrderInfoRequest
    {
        public string MerchantId { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>
        public string RefId { get; set; }

        /// <summary>
        /// 请求参数按照字母先后顺序排列
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {

            var json = JsonConvert.SerializeObject(this);
            Console.WriteLine(json);
            return json;

        }
    }
}
