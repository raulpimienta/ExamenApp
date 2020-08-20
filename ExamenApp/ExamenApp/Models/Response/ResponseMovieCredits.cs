using ExamenApp.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExamenApp.Models.Response
{
    public class ResponseMovieCredits
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cast")]
        public List<Cast> Cast { get; set; }

        [JsonProperty("Crew")]
        public List<Crew> crew { get; set; }
    }

    public class Cast
    {
        [JsonProperty("cast_id")]
        public int Cast_id { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("credit_id")]
        public string Credit_id { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        private string _profile_path;
        [JsonProperty("profile_path")]
        public string Profile_path
        {
            get { return _profile_path; }
            set
            {
                if (value == null) { value = ""; }
                _profile_path = value;

                if (value != "")
                {
                    value = $"{Config.URLImages}{value}";
                    ImageProfile = Helpers.HelperMethods.GetImage(value);
                }
                else
                {
                    ImageProfile = FileImageSource.FromFile("fakeUser.png");
                }
            }
        }

        public ImageSource ImageProfile { get; set; }
    }

    public class Crew
    {
        [JsonProperty("credit_id")]
        public string Credit_id { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profile_path")]
        public string Profile_path { get; set; }

    }

}
