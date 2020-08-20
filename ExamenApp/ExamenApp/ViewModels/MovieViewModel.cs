using ExamenApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExamenApp.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        ResponseMovie _responseMovie;
        public ResponseMovie ResponseMovie
        {
            get { return _responseMovie; }
            set
            {
                _responseMovie = value;
                OnPropertyChanged();
            }
        }

        ResponseMovieCredits _responseMovieCredits;
        public ResponseMovieCredits ResponseMovieCredits
        {
            get { return _responseMovieCredits; }
            set
            {
                _responseMovieCredits = value;
                OnPropertyChanged();
            }
        }

        bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public MovieViewModel(long movie_id)
        {

            Initialize(movie_id);
        }

        public async Task Initialize(long movie_id)
        {
            try
            {
                IsLoading = true;

                var responseMovie = await ApiManager.movie(movie_id);

                foreach (var item in responseMovie.Production_companies)
                {
                    if (String.IsNullOrEmpty(responseMovie.Companies))
                    {
                        responseMovie.Companies = $"{item.Name}";
                    }
                    else
                    {
                        responseMovie.Companies = $"{responseMovie.Companies},{item.Name}";
                    }
                }

                foreach (var item in responseMovie.Genres)
                {
                    if (String.IsNullOrEmpty(responseMovie.Genre))
                    {
                        responseMovie.Genre = $"{item.Name}";
                    }
                    else
                    {
                        responseMovie.Genre = $"{responseMovie.Genre},{item.Name}";
                    }
                }

                ResponseMovie = responseMovie;

                var responseMovieCredits = await ApiManager.credits(movie_id);

                responseMovieCredits.Cast = responseMovieCredits.Cast.Take(10).ToList();

                ResponseMovieCredits = responseMovieCredits;
            }
            catch (Exception)
            {
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}