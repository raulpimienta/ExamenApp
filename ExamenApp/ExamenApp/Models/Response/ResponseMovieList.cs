using ExamenApp.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExamenApp.Models.Response
{
    public class ResponseMovieList
    {

        [JsonProperty("results")]
        public List<ResultMovieList> Results { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int Total_results { get; set; }

        [JsonProperty("dates")]
        public Dates Dates { get; set; }

        [JsonProperty("total_pages")]
        public int Total_pages { get; set; }
    }
    public class Dates
    {
        [JsonProperty("maximum")]
        public string Maximum { get; set; }

        [JsonProperty("minimum")]
        public string Minimum { get; set; }
    }

    public class ResultMovieList
    {

        [JsonProperty("popularity")]
        public float Popularity { get; set; }

        [JsonProperty("vote_count")]
        public int Vote_count { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        private string _poster_path;
        [JsonProperty("poster_path")]
        public string Poster_path
        {
            get { return _poster_path; }
            set
            {
                if (value == null) { value = ""; }
                value = $"{Config.URLImages}{value}";
                _poster_path = value;

                if (value != "")
                {
                    ImageMovie = Helpers.HelperMethods.GetImage(value);
                }
            }
        }

        public ImageSource ImageMovie { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string Backdrop_path { get; set; }

        [JsonProperty("original_language")]
        public string Original_language { get; set; }

        [JsonProperty("original_title")]
        public string Original_title { get; set; }

        [JsonProperty("genre_ids")]
        public List<int> Genre_ids { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("vote_average")]
        public float Vote_average { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public string Release_date { get; set; }
    }

}
