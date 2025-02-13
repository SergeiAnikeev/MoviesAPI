namespace Movies.Application.Models
{
    public class GetAllmoviesOptions
    {
        public string? Title { get; set; }
        public int? YearOfRelease { get; set; }
        public Guid? userId { get; set; }
    }
}
