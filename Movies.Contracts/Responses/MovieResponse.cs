﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contracts.Responses
{
    internal class MovieResponse
    {
        public required Guid id { get; init; }
        public required string Title { get; init; }
        public required string YearOfRelease { get; init; }
        public required IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();
    }
}
