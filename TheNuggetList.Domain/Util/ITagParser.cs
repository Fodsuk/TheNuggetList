#region

using System.Collections.Generic;

#endregion

namespace TheNuggetList.Domain.Util
{
    public interface ITagsParser
    {
        IEnumerable<string> GetList(string tags);
    }
}