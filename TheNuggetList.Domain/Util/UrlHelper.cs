#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace TheNuggetList.Domain.Util
{
    public class UrlHelper
    {
        public List<string> SplitUrl(string url, Func<string, string> transformUrlPart)
        {
            if (String.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            var urlParts = url.Split('/').Where(part => !String.IsNullOrWhiteSpace(part)).ToList();

            if (transformUrlPart != null)
            {
                urlParts = urlParts.ConvertAll(p => transformUrlPart(p));
            }


            return urlParts;
        }
    }
}