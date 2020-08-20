using ExamenApp.Constants;
using ExamenApp.Models.Response;
using ExamenApp.Services.Interfaces;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamenApp.Services
{
    public class ApiManager : IApiManager
    {
        JsonSerializerSettings _nullJsonSerializeSettings;
        IMovieService _movieService;

        public ApiManager()
        {
            _movieService = RestService.For<IMovieService>(Constants.Config.ApiMovieURL);

            _nullJsonSerializeSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        public async Task<ResponseMovieList> top_rated()
        {
            ResponseMovieList result = new ResponseMovieList();
            try
            {

                var response = await _movieService.top_rated().ConfigureAwait(false);

                var responseString = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<ResponseMovieList>(responseString, _nullJsonSerializeSettings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public async Task<ResponseMovieList> upcoming()
        {
            ResponseMovieList result = new ResponseMovieList();
            try
            {

                var response = await _movieService.upcoming().ConfigureAwait(false);

                var responseString = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<ResponseMovieList>(responseString, _nullJsonSerializeSettings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public async Task<ResponseMovieList> popular()
        {
            ResponseMovieList result = new ResponseMovieList();
            try
            {

                var response = await _movieService.popular().ConfigureAwait(false);

                var responseString = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<ResponseMovieList>(responseString, _nullJsonSerializeSettings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public async Task<ResponseMovie> movie(long movie_id)
        {
            ResponseMovie result = new ResponseMovie();
            try
            {

                var response = await _movieService.movie(movie_id).ConfigureAwait(false);

                var responseString = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<ResponseMovie>(responseString, _nullJsonSerializeSettings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public async Task<ResponseMovieCredits> credits(long movie_id)
        {
            ResponseMovieCredits result = new ResponseMovieCredits();
            try
            {

                var response = await _movieService.credits(movie_id).ConfigureAwait(false);

                var responseString = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<ResponseMovieCredits>(responseString, _nullJsonSerializeSettings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

    }
}
