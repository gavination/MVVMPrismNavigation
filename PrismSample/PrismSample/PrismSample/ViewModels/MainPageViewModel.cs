using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set {  SetProperty(ref _buttonText, value); }
        }

        private INavigationService _navigationService;
        public DelegateCommand NavigateToSecondPageCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToSecondPageCommand = new DelegateCommand(NavigateToSecondPage);
        }

        private void NavigateToSecondPage()
        {
            _navigationService.NavigateAsync("SecondPage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
            ButtonText = "Go to next page";
        }
    }
}
