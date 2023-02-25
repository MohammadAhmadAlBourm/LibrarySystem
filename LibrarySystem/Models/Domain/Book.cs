namespace LibrarySystem.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid AuthorID { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }

    }

    //public class AuthorList
    //{
    //    public Guid Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }

    //}
}
