using System.Linq.Expressions;
using System;

namespace s76ToolBox.GeneralUse.Utilities
{
    public static class ReflectionUtilities
    {
        public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }
    }
}
