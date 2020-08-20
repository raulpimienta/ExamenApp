using ExamenApp.Services;
using ExamenApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExamenApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public IApiManager ApiManager;
        protected BaseViewModel()
        {
            ApiManager = new ApiManager();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(
        [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }
    }
}
