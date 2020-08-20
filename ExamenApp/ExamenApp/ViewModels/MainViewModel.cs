using ExamenApp.Models.Response;
using ExamenApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExamenApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        List<ResultMovieList> _listTopRated;
        public List<ResultMovieList> ListTopRated
        {
            get { return _listTopRated; }
            set
            {
                _listTopRated = value;
                OnPropertyChanged();
            }
        }

        List<ResultMovieList> _listTopRatedFilter;
        public List<ResultMovieList> ListTopRatedFilter
        {
            get { return _listTopRatedFilter; }
            set
            {
                _listTopRatedFilter = value;
                OnPropertyChanged();
            }
        }

        List<ResultMovieList> _listPopular;
        public List<ResultMovieList> ListPopular
        {
            get { return _listPopular; }
            set
            {
                _listPopular = value;
                OnPropertyChanged();
            }
        }

        List<ResultMovieList> _listPopularFilter;
        public List<ResultMovieList> ListPopularFilter
        {
            get { return _listPopularFilter; }
            set
            {
                _listPopularFilter = value;
                OnPropertyChanged();
            }
        }

        List<ResultMovieList> _listUpComing;
        public List<ResultMovieList> ListUpComing
        {
            get { return _listUpComing; }
            set
            {
                _listUpComing = value;
                OnPropertyChanged();
            }
        }

        List<ResultMovieList> _listUpComingFilter;
        public List<ResultMovieList> ListUpComingFilter
        {
            get { return _listUpComingFilter; }
            set
            {
                _listUpComingFilter = value;
                OnPropertyChanged();
            }
        }

        bool _isVisibleList;
        public bool IsVisibleList
        {
            get { return _isVisibleList; }
            set
            {
                _isVisibleList = value;
                OnPropertyChanged();
            }
        }

        bool _isVisibleListFilter;
        public bool IsVisibleListFilter
        {
            get { return _isVisibleListFilter; }
            set
            {
                _isVisibleListFilter = value;
                OnPropertyChanged();
            }
        }

        bool _isVisibleNotResultsTopRated;
        public bool IsVisibleNotResultsTopRated
        {
            get { return _isVisibleNotResultsTopRated; }
            set
            {
                _isVisibleNotResultsTopRated = value;
                OnPropertyChanged();
            }
        }

        bool _isVisibleNotResultsUpComing;
        public bool IsVisibleNotResultsUpComing
        {
            get { return _isVisibleNotResultsUpComing; }
            set
            {
                _isVisibleNotResultsUpComing = value;
                OnPropertyChanged();
            }
        }

        bool _isVisibleNotResultsPopular;
        public bool IsVisibleNotResultsPopular
        {
            get { return _isVisibleNotResultsPopular; }
            set
            {
                _isVisibleNotResultsPopular = value;
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



        private string _filter;
        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                OnPropertyChanged();
                this.FilterMovies();
            }
        }

        private void FilterMovies()
        {
            try
            {

                if (String.IsNullOrEmpty(Filter))
                {
                    IsVisibleListFilter = false;

                    IsVisibleList = true;

                    IsVisibleNotResultsTopRated = false;

                    IsVisibleNotResultsUpComing = false;

                    IsVisibleNotResultsPopular = false;
                }
                else if (Filter.Length >= 3)
                {
                    IsVisibleListFilter = true;

                    IsVisibleList = false;

                    ListTopRatedFilter = ListTopRated.Where(x => x.Title.Contains(Filter)).ToList();

                    IsVisibleNotResultsTopRated = ListTopRatedFilter.Count < 1;

                    ListUpComingFilter = ListUpComing.Where(x => x.Title.Contains(Filter)).ToList();

                    IsVisibleNotResultsUpComing = ListUpComingFilter.Count < 1;

                    ListPopularFilter = ListPopular.Where(x => x.Title.Contains(Filter)).ToList();

                    IsVisibleNotResultsPopular = ListPopularFilter.Count < 1;


                }
            }
            catch (Exception)
            {

            }


        }

        public MainViewModel()
        {

            InitializeLists();
        }

        public async Task InitializeLists()
        {
            try
            {

                IsLoading = true;

                IsVisibleList = true;

                IsVisibleListFilter = false;

                var responseTopRated = await ApiManager.top_rated();

                ListTopRated = responseTopRated.Results.ToList();

                var responseUpComing = await ApiManager.upcoming();

                ListUpComing = responseUpComing.Results.ToList();

                var responsePopular = await ApiManager.popular();

                ListPopular = responsePopular.Results.ToList();


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
