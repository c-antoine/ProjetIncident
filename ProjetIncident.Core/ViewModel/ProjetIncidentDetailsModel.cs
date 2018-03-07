using System;
using System.Collections.ObjectModel;

namespace ProjetIncident.Core.ViewModel
{
    public class ProjetIncidentDetailsModel : BaseViewModel
    {
        public ProjetIncidentDetailsModel()
        {
            MaListe = new ObservableCollection<string>();
            MaListe.Add("Elément1");
        }

        public string MonTexte
        {
            get => GetProperty<string>();
            set { SetProperty(value); }
        }

        public string MaSelection
        {
            get => GetProperty<string>();
            set { SetProperty(value); }
        }

        public ObservableCollection<string> MaListe
        {
            get => GetProperty<ObservableCollection<string>>();
            set { SetProperty(value); }
        }
    }
}
