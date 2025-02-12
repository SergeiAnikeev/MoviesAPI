﻿using Dapper;
using Movies.Application.Database;

namespace Movies.Application.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public RatingRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<float?> GetRatingAsync(Guid movieId, CancellationToken token = default)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
            return await connection.QuerySingleOrDefaultAsync<float?>(new CommandDefinition("""
                SELECT round(AVG(r.rating),1)
                FROM ratings r
                WHERE movieid = @MovieId
                """, new { movieId },cancellationToken: token
            ));
        }
        public async Task<bool> RateMovieAsync(Guid movieId, int rating, Guid userId, CancellationToken token = default)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
            var result = await connection.ExecuteAsync(new CommandDefinition("""
                INSERT INTO ratings (userid, movieid, rating)
                VALUES (@userId, @movieId, @rating)
                ON CONFLICT (userid, movieid) 
                DO UPDATE SET rating = EXCLUDED.rating;
                """, new { userId, movieId, rating }, cancellationToken: token
            ));
            return result > 0;
        }
        public async Task<(float? Rating, int? UserRating)> GetRatingAsync(Guid movieId, Guid userId, CancellationToken token = default)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
            return await connection.QuerySingleOrDefaultAsync<(float?,int?)>(new CommandDefinition("""
                SELECT round(AVG(r.rating),1),
                (select rating 
                from ratings 
                where movieid = @MovieId and userid = @UserId limit 1)
                FROM ratings r
                WHERE movieid = @MovieId
                """, new { movieId,userId }, cancellationToken: token
            ));
        }
    }
}
