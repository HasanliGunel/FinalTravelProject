namespace Entities.Concrete.ViewModel
{
    public class TagBlogVM
    {
        public int ID { get; set; }
        public int BlogId { get; set; }
        public int TagID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string Text { get; set; }
        public int CategoryOfBlogID { get; set; }
        public string CategoryName { get; set; }   
        public string TagName { get; set; }

        public string CommnetPersonName { get; set; }
        public string CommnetPersonEmail { get; set; }
        public string CommnetText { get; set; }
        public DateTime CommentCreateTime {  get; set; }

    }
}
