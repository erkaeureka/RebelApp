namespace Api.Models
{
    public class ArtistViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Streams { get; set; }
        public double Rate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
