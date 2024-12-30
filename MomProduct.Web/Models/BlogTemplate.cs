namespace MomProduct.Web.Models
{
    public class BlogTemplate
    {
        public int Id { get; set; }

        public string BlogTitle { get; set; }

        public string BlogDescription { get; set; }

        public string BlogContent { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifyBy { get; set; }
        public string BlogImage { get; set; }

    }
}
