﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Auth;
using Movies.API.Mapping;
using Movies.Application.Models;
using Movies.Application.Services;
using Movies.Contracts.Requests;

namespace Movies.API.Controllers.V2
{
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [Authorize]
        [HttpPut(ApiEndpoints.V2.Movies.Rate)]
        public async Task<IActionResult> RateMovie([FromRoute] Guid id, [FromBody] RateMovieRequest request, CancellationToken token)
        {
            var userId = HttpContext.GetUserId();
            var result = await _ratingService.RateMovieAsync(id, request.Rating, userId.Value, token);
            return result ? Ok() : NotFound();
        }

        [Authorize]
        [HttpDelete(ApiEndpoints.V2.Movies.DeleteRating)]
        public async Task<IActionResult> DeleteMovie([FromRoute] Guid id, CancellationToken token)
        {
            var userId = HttpContext.GetUserId();
            var result = await _ratingService.DeleteRatingAsync(id, userId.Value, token);
            return result ? Ok() : NotFound();
        }

        [Authorize]
        [HttpGet(ApiEndpoints.V2.Ratings.GetUserRatings)]
        public async Task<IActionResult> GetUserRatings(CancellationToken token = default)
        {
            var userId = HttpContext.GetUserId();
            var ratings = await _ratingService.GetRatingsForUserAsync(userId.Value, token);
            var ratingsResponse = ratings.MapToResponse();
            return Ok(ratingsResponse);
        }
    }
}
