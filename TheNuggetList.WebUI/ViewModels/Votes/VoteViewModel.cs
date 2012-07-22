using System.Web;

namespace TheNuggetList.WebUI.ViewModels.Votes
{
    public class VoteViewModel
    {
        public int VoteCount { get; set; }
        public long ContentTypePK { get; set; }
        public string ContentTypeName { get; set; }

        public string ReturnUrl
        {
            get { return string.Format("?ReturnUrl={0}", HttpContext.Current.Request.Url.AbsolutePath); }
        }
        
        public string UpVoteUrl
        {
            get
            {
                return string.Format("/voting/upvote/{0}/{1}/", this.ContentTypeName, this.ContentTypePK);
            } 
        }
        
        public string DownVoteUrl
        {
            get
            {
                return string.Format("/voting/downvote/{0}/{1}/", this.ContentTypeName, this.ContentTypePK);
            }
        }


        public string UpVoteAjaxUrl
        {
            get
            {
                return string.Format("/voting/upvoteajax/{0}/{1}/", this.ContentTypeName, this.ContentTypePK);
            }
        }

        public string DownVoteAjaxUrl
        {
            get
            {
                return string.Format("/voting/downvoteajax/{0}/{1}/", this.ContentTypeName, this.ContentTypePK);
            }
        }
    }
}