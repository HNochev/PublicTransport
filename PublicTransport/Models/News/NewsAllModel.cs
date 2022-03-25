namespace PublicTransport.Models.News
{
    public class NewsAllModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        public string ImgUrl { get; set; }

        public string AuthorId { get; set; }
    }
}
