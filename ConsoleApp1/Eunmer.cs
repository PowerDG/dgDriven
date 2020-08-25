using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Eunmer
    {
        public static async Task<IEnumerable<int>> SelecttousuIdsByTousuTypeAsync(IEnumerable<int> tousuIds, string tousuType = "", int pageSize = 50)
        {
            var tousuList = new List<int>();
            var currentTousuIds = new List<int>();
            var pageIndex = 1;
            do
            {
                var pageTousus = tousuList.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();//await QueryTousuByTousuIdsAsync(tousuIds, pageIndex, pageSize);
                if (pageTousus.Any())
                {
                    tousuList.AddRange(pageTousus);
                    pageIndex++;
                }
                else
                {
                    break;
                }
            }
            while (pageIndex < 1000);

            if (tousuList.Any())
            { 
                currentTousuIds = tousuList.Distinct().ToList();
            }
            return currentTousuIds;
        }


        /// <summary>
        /// 实际请求    调用采购  提供的接口【分页】
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Dictionary<int, decimal>> GetBasePriceDictAsync(List<int> list, int orderNo, int pageSize, string requestTracked = null)
        {
            Dictionary<int, decimal> dict = new Dictionary<int, decimal>();
            List<OrderListPriceInfo> resultList = new List<OrderListPriceInfo>();
            var pageIndex = 1;
            OrderListWithBaseCostRequest input = new OrderListWithBaseCostRequest();
            do
            {
                input.OrderNo = orderNo;
                input.OrderItemIdList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                //var pageTousus = await QueryTousuByTousuIdsAsync(tousuIds, pageIndex, pageSize);
                if (input.OrderItemIdList.Any())
                {
                    var currentList =   GetBasePriceListAsync(input, requestTracked);
                    if (currentList.Any())
                    {
                        Console.WriteLine($"AddRange currentList  !  {JsonConvert.SerializeObject(currentList)}");
                        resultList.AddRange(currentList);
                    }
                    pageIndex++;
                }
                else
                {
                    Console.WriteLine($"【Any-Empty】 !  {JsonConvert.SerializeObject(input.OrderItemIdList)}");
                    break;
                }
            }
            while (pageIndex < 1000);
            Console.WriteLine($"resultList   !  {JsonConvert.SerializeObject(resultList)}");

            resultList = resultList.Where((x, i) => resultList.FindIndex(z => z.POId == x.POId) == i).ToList();

            Console.WriteLine($"resultList   !  {JsonConvert.SerializeObject(resultList)}");
            dict = resultList.ToDictionary(x => x.POId, x => x.BaseCost);
            return dict;
        }

        public   List<OrderListPriceInfo> GetBasePriceListAsync(OrderListWithBaseCostRequest input, string requestTracked)
        {
            List<OrderListPriceInfo> currentList = new List<OrderListPriceInfo>();
            foreach (var item in input.OrderItemIdList)
            {
                currentList.Add(new OrderListPriceInfo(item,item+10000.321m
                    )) ;
            }
            return currentList;
        }
        public void CountDict201()
        {
            var currentList = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                currentList.Add(10000 + i);
            }
            Console.WriteLine($"currentList  !  {JsonConvert.SerializeObject(currentList)}");
        }

        public void CountDict2()
        {
            var currentList = new List<int>()
            {111,222,333,444,888,555,666,777,999,111,222,333,555,666
            };

            Console.WriteLine($"currentList  !  {JsonConvert.SerializeObject(currentList)}");
            currentList = currentList.Distinct().ToList();

            Console.WriteLine($"currentList  !  {JsonConvert.SerializeObject(currentList)}");
            var c = GetBasePriceDictAsync(currentList, 10010, 3, "11111");

            //var c = currentList.Where((x, i) => currentList.FindIndex(z => z.POId == x.POId) == i).ToList();



            Console.WriteLine($"Hello  !  {JsonConvert.SerializeObject(c)}");
        }

        public void CountDict()
        {
            var currentList = new List<OrderListPriceInfo>()
            {
                new OrderListPriceInfo(111,2312),
                new OrderListPriceInfo(111,23123),
                new OrderListPriceInfo(112,2312),
                new OrderListPriceInfo(112,2111),
                new OrderListPriceInfo(113,2312),
                new OrderListPriceInfo(111,2312)
            };


            var c = currentList.Where((x, i) => currentList.FindIndex(z => z.POId == x.POId) == i).ToList();



            Console.WriteLine($"Hello  !  {JsonConvert.SerializeObject(c)}" );
        }
    }
    //
    // 摘要:
    //     请求获取
    public class OrderListWithBaseCostRequest
    {
        //public OrderListWithBaseCostRequest();

        //
        // 摘要:
        //     模板名称
        [JsonProperty("orderNo")]
        public int OrderNo { get; set; }
        //
        // 摘要:
        //     请求参数
        [JsonProperty("purchaseOrderItemIdList")]
        public List<int> OrderItemIdList { get; set; }
    }
    //
    // 摘要:
    //     订单产品信息
    public class OrderListPriceInfo
    {

        public OrderListPriceInfo(int poid, decimal cost)
        {
            this.POId = poid;
            this.BaseCost = cost;
        }

        //
        // 摘要:
        //     采购子订单号
        [JsonProperty("purchaseOrderItemId")]
        public int POId { get; set; }
        //
        // 摘要:
        //     是否原有底价，若无返回的则为含税成本
        [JsonProperty("isPromotion")]
        public bool IsPromotion { get; set; }
        //
        // 摘要:
        //     成本底价
        [JsonProperty("basePrice")]
        public decimal BaseCost { get; set; }
    }

   
}
