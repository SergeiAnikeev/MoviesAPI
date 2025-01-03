﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Models
{
    internal class Movie
    {
        public required Guid id { get; init; }
        public required string Title { get; set; }
        public required string YearOfRelease { get; set; }
        public required List<string> Genres { get; init; } = new();
    }
}
