using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
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
}
