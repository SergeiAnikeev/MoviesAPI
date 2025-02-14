namespace Movies.Application.Models
{
    public class GetAllmoviesOptions
    {
        public string? Title { get; set; }
        public int? YearOfRelease { get; set; }
        public Guid? userId { get; set; }
        public string? SortField { get; set; }
        public SortOrder? SortOrder { get; set; }
    }
    public enum SortOrder
    {
        Unsorted,
        Ascending,
        Descending
    }
}
