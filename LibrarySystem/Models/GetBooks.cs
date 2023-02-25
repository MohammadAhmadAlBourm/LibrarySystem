namespace LibrarySystem.Models
{
    public class GetBooks
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid AuthorID { get; set; }

        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }

    }
}
