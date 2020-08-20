using ExamenApp.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExamenApp.Models.Response
{
    public class ResponseMovie
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        private string _backdrop_path;
        [JsonProperty("backdrop_path")]
        public string Backdrop_path
        {
            get { return _backdrop_path; }
            set
            {
                if (value == null) { value = ""; }
                value = $"{Config.URLImages500}{value}";
                _backdrop_path = value;

                if (value != "")
                {
                    ImageBackDrop = Helpers.HelperMethods.GetImage(value);
                }
            }
        }

        public ImageSource ImageBackDrop { get; set; }

        [JsonProperty("belongs_to_collection")]
        public object Belongs_to_collection { get; set; }

        [JsonProperty("budget")]
        public int Budget { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        public string Genre { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("imdb_id")]
        public string Imdb_id { get; set; }

        [JsonProperty("original_language")]
        public string Original_language { get; set; }

        [JsonProperty("original_title")]
        public string Original_title { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public float Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string Poster_path { get; set; }

        [JsonProperty("production_companies")]
        public List<Production_Companies> Production_companies { get; set; }

        public string Companies { get; set; }

        [JsonProperty("production_countries")]
        public Production_Countries[] Production_countries { get; set; }

        [JsonProperty("release_date")]
        public string Release_date { get; set; }

        [JsonProperty("revenue")]
        public int Revenue { get; set; }

        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        [JsonProperty("spoken_languages")]
        public List<Spoken_Languages> spoken_languages { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public float Vote_average { get; set; }

        [JsonProperty("vote_count")]
        public int Vote_count { get; set; }
    }

    public class Genre
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Production_Companies
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("logo_path")]
        public string Logo_path { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin_country")]
        public string Origin_country { get; set; }
    }

    public class Production_Countries
    {

        [JsonProperty("iso_3166_1")]
        public string Iso_3166_1 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Spoken_Languages
    {
        [JsonProperty("iso_639_1")]
        public string Iso_639_1 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
