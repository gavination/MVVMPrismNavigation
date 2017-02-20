using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSample.ViewModels
{
    public class SecondPageViewModel : BindableBase
    {

        private string _label = "This is the second page";
        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }

        }

        private string _buttonText = "Go Back to the First Page";
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        private INavigationService _navigationService;
        public DelegateCommand NavigateToMainPageCommand { get; private set; }

        public SecondPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToMainPageCommand = new DelegateCommand(NavigateToMainPage);
        }

        private void NavigateToMainPage()
        {
            _navigationService.GoBackAsync();

        }



    }
}
