namespace LibrarySystem.Models.ViewModel
{
    public class BookViewModel
    {
        public Guid id { get; set; }
        public string title { get; set; }

        public Guid author_id { get; set; }

        public string publisher { get; set; }
        public DateTime publish_date { get; set; }
        public string isbn { get; set; }

    }

    //public class AuthorList
    //{
    //    public Guid id { get; set; }
    //    public string first_name { get; set; }
    //    public string last_name { get; set; }
    //}
}
