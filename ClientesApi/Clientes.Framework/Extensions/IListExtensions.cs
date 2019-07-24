using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clientes.Framework
{
    public static class IListExtensions
    {
        public static bool IsNull(this IList list)
        {
            return list == null;
        }

        public static bool IsNotNull(this IList list)
        {
            return !list.IsNull();
        }

        public static bool IsEmpty<T>(this IList<T> list)
        {
            return list.IsNull() || (!list.Any());
        }

        public static bool IsNotEmpty<T>(this IList<T> list)
        {
            return !list.IsEmpty();
        }
    }
}
