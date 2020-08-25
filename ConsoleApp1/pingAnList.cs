using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
   public class pingAnList
    {
        static readonly List<Tuple<string, List<string>, int, string, string>> PingAnXJPidInfo = new List<Tuple<string, List<string>, int, string, string>> {
            new Tuple<string, List<string>, int, string, string>("壳牌（矿物油）",
                new List<string> { "OL-SH-BXZZ|1", "OL-SH-BXZZ|2" } , 280, "BY-TUHU-BXGSDCBY|157", "新疆平安-壳牌矿物质"),
            new Tuple<string, List<string>, int, string, string>("壳牌（半合成）",
                new List<string> { "OL-SH-BXZZ|3", "OL-SH-BXZZ|5" } , 350, "BY-TUHU-BXGSDCBY|158", "新疆平安-壳牌半合成"),
            new Tuple<string, List<string>, int, string, string>("壳牌（全合成）",
                new List<string> { "OL-SH-BXZZ|5", "OL-SH-BXZZ|6", "OL-SH-BXZZ|7"} , 420, "BY-TUHU-BXGSDCBY|159", "新疆平安-壳牌全合成"),
            new Tuple<string, List<string>, int, string, string>("美孚（半合成）",
                new List<string> { "OL-MO-SUBA-5W30|1", "OL-MO-SUBA-5W40-1|", "OL-MO-SUBA-5W30|2", "OL-MO-SUBA-5W40-1L|","OL-MO-S1000-10W40|1","OL-MO-S1000-5W30|1" }, 370, "BY-TUHU-BXGSDCBY|160", "新疆平安-美孚半合成"),
            new Tuple<string, List<string>, int, string, string>("美孚（全合成）",
                new List<string> { "OL-MO-ONE-5W30-1|", "OL-MO-ONE-5W30-SN-1|", "OL-MO-GONE-0W40-1|", "OL-MO-ONE-5W40-1|", "OL-MO-GONE-0W40-1a|", "OL-MO-S2000-5W30|1", "OL-MO-S2000-5W30|2", "OL-MO-S2000-5W40|1", "OL-MO-S2000-5W40|2" } , 440, "BY-TUHU-BXGSDCBY|161", "新疆平安-美孚全合成"),

        };

        public void Test()
        {
            var orderLists = new List<orderList>();
            //var oillist = orderLists.Where(_ => "Oil".Equals(_.Category, StringComparison.OrdinalIgnoreCase));
            var oilPids = new List<string> { "OL-SH-BXZZ|5", "OL-SH-BXZZ|2" };

            var oilPids2 = new List<string> { "OL-SH-BXZZ|5"  };

            var oilPids3 = new List<string> { "OL-SH-BXZZ|5", "OL-SH-BXZZ|6", "OL-SH-BXZZ|7" };
            //orderLists.Select(_ => _.PID);
            var a = PingAnXJPidInfo
                .Select(_ => oilPids.Except(_.Item2)).ToList();

            var b = a.Where(_ => _.Count() == 0).ToList();
            var c= b
                .Count() == 0;

            if (PingAnXJPidInfo
                .Select(_ => oilPids.Except(_.Item2))
                .Where(_ => _.Count() == 0)
                .Count() == 0)
            {

                  new Tuple<string, bool>($" 订单渠道，机油产品验证不通过；", false);
                //return new Tuple<string, bool>($"{bizOrder.OrderChannel}订单渠道，机油产品验证不通过；", false);
            }


        }
    }
}
