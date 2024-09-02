namespace postgresql
{
    internal class Book
    {
        public int id { get; set; }
        public string? title { get; set; }

        public int author_id { get; set; }
        public Author author_ { get; set; }
        public short? public_year { get; set; }
    }
}
