using Xamarin.Forms;
using ProjetIncident.Core.ViewModel;
namespace ProjetIncident
{
    public partial class ProjetIncidentDetails : ContentPage
    {

        public ProjetIncidentDetails()
        {
            this.BindingContext = new Core.ViewModel.ProjetIncidentDetailsModel();
            ((Core.ViewModel.ProjetIncidentDetailsModel)BindingContext).MonTexte = "Liste des éléments";
            InitializeComponent();
        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            ((Core.ViewModel.ProjetIncidentDetailsModel)BindingContext).MonTexte = "Après clic sur le bouton";
        }

        void Handle_Ajout(object sender, System.EventArgs e)
        {
            ((ProjetIncidentDetailsModel)BindingContext).MaListe.Add("Nouvel élément");
        }

        void Handle_Sup(object sender, System.EventArgs e)
        {
            ((ProjetIncidentDetailsModel)BindingContext).MaListe.Remove(((ProjetIncidentDetailsModel)BindingContext).MaSelection);
        }
    }
}