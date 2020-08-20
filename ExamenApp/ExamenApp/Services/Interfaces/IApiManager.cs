using ExamenApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamenApp.Services.Interfaces
{
    public interface IApiManager
    {
        Task<ResponseMovieList> top_rated();

        Task<ResponseMovieList> upcoming();

        Task<ResponseMovieList> popular();

        Task<ResponseMovie> movie(long movie_id);

        Task<ResponseMovieCredits> credits(long movie_id);
    }
}
