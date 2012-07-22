#region

using System.Collections.Generic;
using System.Linq;
using TheNuggetList.Domain.Services;

#endregion

namespace TheNuggetList.Domain.Util
{
    public class CsvTagsParser : ITagsParser
    {
        #region ITagsParser Members

        public IEnumerable<string> GetList(string tagsString)
        {
            return tagsString.Split(',').ToList();
        }

        #endregion
    }
}