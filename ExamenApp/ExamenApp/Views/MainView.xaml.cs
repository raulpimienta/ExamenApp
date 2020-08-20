using ExamenApp.Models.Response;
using ExamenApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExamenApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Constants.Config.SYNCFUSION_LICENSE);
            InitializeComponent();
            BindingContext = new MainViewModel();
            LvPopular.SelectionChanged += LvPopular_SelectionChanged;
            LvPopularFilter.SelectionChanged += LvPopularFilter_SelectionChanged;
            LvUpComing.SelectionChanged += LvUpComing_SelectionChanged;
            LvUpComingFilter.SelectionChanged += LvUpComingFilter_SelectionChanged;
            LvTopRated.SelectionChanged += LvTopRated_SelectionChanged;
            LvTopRatedFilter.SelectionChanged += LvTopRatedFilter_SelectionChanged;
        }

        private void LvTopRatedFilter_SelectionChanged(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {
            LvTopRatedFilter.SelectedItems.Clear();
        }

        private void LvTopRated_SelectionChanged(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {
            LvTopRated.SelectedItems.Clear();
        }

        private void LvUpComingFilter_SelectionChanged(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {
            LvUpComingFilter.SelectedItems.Clear();
        }

        private void LvUpComing_SelectionChanged(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {
            LvUpComing.SelectedItems.Clear();
        }

        private void LvPopularFilter_SelectionChanged(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {
            LvPopularFilter.SelectedItems.Clear();
        }

        private void LvPopular_SelectionChanged(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {
            LvPopular.SelectedItems.Clear();
        }

        private async void LvSelection_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if (e.ItemData == null)
                return;

            var item = e.ItemData as ResultMovieList;

            await Navigation.PushModalAsync(new MovieView(item.Id));
        }
    }
}
