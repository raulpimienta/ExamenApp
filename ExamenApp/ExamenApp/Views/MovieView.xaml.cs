using ExamenApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieView : ContentPage
    {
        public MovieView(long movie_id)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Constants.Config.SYNCFUSION_LICENSE);
            InitializeComponent();
            BindingContext = new MovieViewModel(movie_id);
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                 Navigation.PopModalAsync();
            };
            Fr.GestureRecognizers.Add(tapGestureRecognizer);

        }
    }
}