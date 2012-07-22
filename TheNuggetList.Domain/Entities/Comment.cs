using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheNuggetList.Domain.Entities
{
    public class Comment : IContentType
    {
        public long ID { get; set; }
        public long ContentTypeID { get; set; }
        public long ContentObjectPK { get; set; }
        public String Content { get; set; }
        public DateTime Created { get; set; }

        public string ContentTypeName
        {
            get { return "Comment"; }
        }

    }
}
