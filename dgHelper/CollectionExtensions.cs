using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionExtensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Checks whatever given collection object is not null and has any item.
        /// </summary>
        public static bool IsNotNullOrEmpty<T>(this ICollection<T> source)
        {
            if ((source != null) && source.Any())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whatever given collection object is null or has no item.
        /// 【录自ABP3.8】
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }

    }
    public class Compare<T, C> : IEqualityComparer<T>
    {
        private Func<T, C> _getField;
        public Compare(Func<T, C> getfield)
        {
            this._getField = getfield;
        }
        public bool Equals(T x, T y)
        {
            return EqualityComparer<C>.Default.Equals(_getField(x), _getField(y));
        }
        public int GetHashCode(T obj)
        {
            return EqualityComparer<C>.Default.GetHashCode(this._getField(obj));
        }
    }
    public static class CommonHelper
    {
        /// <summary>
        /// 自定义Distinct扩展方法
        /// </summary>
        /// <typeparam name="T">要去重的对象类</typeparam>
        /// <typeparam name="C">自定义去重的字段类型</typeparam>
        /// <param name="source">要去重的对象</param>
        /// <param name="getfield">获取自定义去重字段的委托</param>
        /// <returns></returns>
        public static IEnumerable<T> MyDistinct<T, C>(this IEnumerable<T> source, Func<T, C> getfield)
        {
            return source.Distinct(new Compare<T, C>(getfield));
        }
    }
    public class Class1
    {
    }
}
