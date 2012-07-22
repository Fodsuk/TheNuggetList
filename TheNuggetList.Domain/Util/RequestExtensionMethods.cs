#region

using System.Web;

#endregion

namespace TheNuggetList.Domain.Util
{
    public static class RequestExtensionMethods
    {
        public static string AddToQueryString(this HttpRequestBase request, string name, object value)
        {
            return AddToQueryString(request, name, value.ToString());
        }

        public static string AddToQueryString(this HttpRequestBase request, string name, string value)
        {
            var qs = HttpUtility.ParseQueryString(request.QueryString.ToString());

            qs[name] = value;

            return request.Url.AbsolutePath + "?" + qs;
        }
    }
}