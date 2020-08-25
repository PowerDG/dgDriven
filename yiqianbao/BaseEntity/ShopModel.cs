#region 程序集 Tuhu.Service.Shop, Version=1.3.3.6, Culture=neutral, PublicKeyToken=adb5f91fad4934fa
// C:\Users\wangshuxin\.nuget\packages\tuhu.service.shop\1.3.3.6\lib\net45\Tuhu.Service.Shop.dll
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
//using Tuhu.Models;
using Tuhu.Service.Shop.Models;

namespace Tuhu.Service.Shop.Models
{
    public class ShopModel// : BaseModel
    {
        //public ShopModel();

        //
        //// 摘要:
        ////     经纬度
        //[CollectionColumnAttribute(new[] { "," }, new[] { })]
        public decimal[] Position { get; set; }
        //
        // 摘要:
        //     联系手机
        public string Mobile { get; set; }
        //
        // 摘要:
        //     门店类型
        public int ShopType { get; set; }
        //
        // 摘要:
        //     门店支持的服务类型
        public int ServiceType { get; set; }
        //
        // 摘要:
        //     喷漆服务类型
        public int MetalServiceType { get; set; }
        //
        // 摘要:
        //     收款方式（例如：支付宝,现金）
        public string Pos { get; set; }
        //
        // 摘要:
        //     营业时间
        public string WorkTime { get; set; }
        //
        // 摘要:
        ////     门店头图
        //[ColumnAttribute("ShopHeadImg", new[] { })]
        //public string HeaderImage { get; set; }
        ////
        //// 摘要:
        ////     门店图片
        //[CollectionColumnAttribute(new[] { ",", ";" }, new[] { })]
        //public string[] Images { get; set; }
        ////
        //// 摘要:
        ////     门店服务
        //[JsonColumn(new[] { "Service" })]
        public IDictionary<string, IDictionary<string, string>> Services { get; set; }
        //
        // 摘要:
        //     暂停营业开始时间
        public DateTime? SuspendStartDateTime { get; set; }
        //
        // 摘要:
        //     暂停营业结束时间
        public DateTime? SuspendEndDateTime { get; set; }
        //
        //// 摘要:
        ////     技术等级
        //[ColumnAttribute("ShopLevel", new[] { })]
        //public decimal TechnicalLevel { get; set; }
        ////
        //// 摘要:
        ////     门店类型划分( 维修厂、4S店、快修店)
        //[ColumnAttribute("ShopBusinessType", new[] { })]
        public string ShopClassification { get; set; }
        //
        // 摘要:
        //     联系电话
        public string Telephone { get; set; }
        //
        // 摘要:
        //     联系人
        public string Contact { get; set; }
        //
        // 摘要:
        //     门店认证品牌
        public string Brand { get; set; }
        //
        // 摘要:
        //     短地址
        public string AddressBrief { get; set; }
        //
        // 摘要:
        //     门店Id
        //[ColumnAttribute("PKID", new[] { })]
        public int ShopId { get; set; }
        //
        // 摘要:
        //     门店简称
        public string SimpleName { get; set; }
        //
        // 摘要:
        //     门店名称
        public string CarparName { get; set; }
        //
        // 摘要:
        //     门店全称
        public string FullName { get; set; }
        //
        // 摘要:
        //     门店公司名称
        public string CompanyName { get; set; }
        //
        // 摘要:
        //     所属省份RegionId
        public int ProvinceId { get; set; }
        //
        // 摘要:
        //     门店信用公示链接
        public string ShopAICUrl { get; set; }
        //
        // 摘要:
        //     所属省份
        public string Province { get; set; }
        //
        // 摘要:
        //     所属城市
        public string City { get; set; }
        //
        // 摘要:
        //     所属城区RegionId
        public int DistrictId { get; set; }
        //
        // 摘要:
        //     所属城区
        public string District { get; set; }
        ////
        //// 摘要:
        ////     门店覆盖地区
        //[CollectionColumnAttribute(new[] { "," }, new[] { })]
        //public string[] Cover { get; set; }
        ////
        //// 摘要:
        ////     SystemLog..ShopCover表的门店覆盖区域
        //public ShopCoverRegionModel CoverRegion { get; set; }
        //
        // 摘要:
        //     门店地址
        public string Address { get; set; }
        //
        // 摘要:
        //     所属城市RegionId
        public int CityId { get; set; }

        //protected override void Parse(DataRow row, PropertyInfo[] properties);
    }
}