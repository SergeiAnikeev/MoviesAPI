namespace Movies.Contracts.Requests
{
    public class UpdateMovieRequest
    {
        public required string Title { get; init; }
        public required string YearOfRelease { get; init; }
        public required IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();
    }
}
