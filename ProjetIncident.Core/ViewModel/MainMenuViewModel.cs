using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ProjetIncident.Core.ViewModel
{
    public class MainMenuViewModel : BaseViewModel
    {

        public class MenuItem
        {
            private Page _page;
            private Type _pageType;
            private object _viewModel;
            private Type _viewModelType;
            private object[] _viewModelCtorParams;

            public string ImageName { get; }
            public string Title { get; }
            public Page Page
            {
                get
                {
                    if (_page == null && _pageType != null) _page = (Page)Activator.CreateInstance(_pageType);
                    return _page;
                }
            }
            public object ViewModel
            {
                get
                {
                    if (_viewModel == null && _viewModelType != null) _viewModel = Activator.CreateInstance(_viewModelType, _viewModelCtorParams);
                    return _viewModel;
                }
            }

            public MenuItem(string imageName, string title,
                            Page page, object viewModel = null)
            {
                ImageName = imageName;
                Title = title;
                _page = page;
                _viewModel = viewModel;
                _pageType = null;
                _viewModelType = null;
                _viewModelCtorParams = null;
            }

            public MenuItem(string imageName, string title,
                            Type pageType, Type viewModelType = null,
                            params object[] viewModelCtorParams)
                : this(imageName, title, (Page)null, (object)null)
            {
                _pageType = pageType;
                _viewModelType = viewModelType;
                _viewModelCtorParams = viewModelCtorParams;
            }
        }


        public string MenuTitle
        {
            get { return (string)GetContent(); }
            set { SetProperty(value); }
        }

        public ObservableCollection<MenuItem> Menus
        {
            get { return (ObservableCollection<MenuItem>)GetContent(); }
            private set { SetProperty(value); }
        }


#pragma warning disable 4014
        public MenuItem SelectedMenu
        {
            get { return (MenuItem)GetContent(); }
            set
            {
                if (SetProperty(value) && value != null)
                {
                    SelectedMenu = null;
                    if (value.Page == null)
                        NavigationService.GetCurrent().NavigateToRootPage();
                    else
                        NavigationService.GetCurrent().NavigateToWithoutPush(value.Page, value.ViewModel);
                }
            }
        }
#pragma warning restore 4014

        public MainMenuViewModel()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    MenuTitle = "Menu";
                    break;
                default:
                    MenuTitle = "GraphismExamples";
                    break;
            }

            Menus = new ObservableCollection<MenuItem>();
            Menus.Add(new MenuItem("home.png", "Accueil", typeof(ProjetIncidentHome), typeof(ProjetIncidentViewModel)));
            //Menus.Add(new MenuItem("settings.png", "Paramètres", typeof(Views.SettingsPage), typeof(SettingsViewModel)));
        }
    }
}
