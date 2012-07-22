#region

using System.Linq;
using System.Web;

#endregion

namespace TheNuggetList.Domain.Util
{
    public static class DebugHelper
    {
        public static string GetSql(IQueryable query)
        {
            var sql = ((System.Data.Objects.ObjectQuery) query).ToTraceString();
            return sql;
        }

        public static void WriteSqlToResponse(IQueryable query)
        {
            var sql = GetSql(query);
            var wrappedSql = "<div class='sqlwrapper'><code><pre>" + sql + "</pre></code></div>";
            HttpContext.Current.Response.Write(wrappedSql);
        }
    }
}