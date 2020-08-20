using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamenApp.Services.Interfaces
{
    [Headers("Content-Type: application/json")]
    public interface IMovieService
    {
        [Get("/top_rated?api_key=c4f24b17214b9b869979a0ff1d7501d3")]
        Task<HttpResponseMessage> top_rated();

        [Get("/upcoming?api_key=c4f24b17214b9b869979a0ff1d7501d3")]
        Task<HttpResponseMessage> upcoming();

        [Get("/popular?api_key=c4f24b17214b9b869979a0ff1d7501d3")]
        Task<HttpResponseMessage> popular();

        [Get("/{movie_id}?api_key=c4f24b17214b9b869979a0ff1d7501d3")]
        Task<HttpResponseMessage> movie(long movie_id);

        [Get("/{movie_id}/credits?api_key=c4f24b17214b9b869979a0ff1d7501d3")]
        Task<HttpResponseMessage> credits(long movie_id);
    }
}
