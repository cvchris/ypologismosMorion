using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using ypologismosMorion;
using ypologismosMorion.Models;

namespace ypologismosMorion
{
    public partial class PouPerasaPage : ContentPage
    {
        public PouPerasaPage(double moria, int kateuthinsi, bool exeieidiko, double moriaeidikou)
        {
             InitializeComponent();

            //For Testing
            //Tamoriamou.Text = moria.ToString() + "..." + kateuthinsi.ToString();

            var vaseis = new DatabaseManager().GetVaseis(kateuthinsi+1);

            if(!exeieidiko)
            {
                //& !exei eidiko
                //tsekare ti paizei me tis stratiotikes gt kapoies exoyn titlo sta eidika alla den xreiazetai na exeis moria apo eidika mthimata
                sxolespoupernas.ItemsSource = vaseis.Where(x => x.vasi < moria && (x.eidika == null || x.eidika == "Ισχύουν επιπλέον προϋποθέσεις"));
            }
            else
            {
                sxolespoupernas.ItemsSource = vaseis.Where(x => x.vasi < moria || ( x.eidika != null && x.vasi < (moria + moriaeidikou) && (x.eidika.Contains("Εξέταση σε αγωνίσματα") || x.eidika.Contains("Ειδικά Μαθήματα"))));   
            }



            //sxolespoupernas.ItemsSource = vaseis.Where(x => ((x.vasi <= moria && x.ExeiEidikoMathima == false) || (x.vasi <= moriaeidikou && x.ExeiEidikoMathima == true))
            //&& ((x.pedio == (kateuthinsi + 1) || x.deuteropedio == (kateuthinsi + 1) || x.tritopedio == (kateuthinsi + 1) || x.ApoOlaTaPedia == true) || (x.tefaa == true && exeieidiko == true)) && x.stratiotikesAkatigoria == false && x.stratiotikesBkatigoria == false
            //);
            

        }
        public PouPerasaPage(double moria4 , double moria5 , int kateuthinsi)
        {

        }

        private void sxolespoupernas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            sxolespoupernas.SelectedItem = null;
        }

        private void sxolespoupernas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //throw new NotImplementedException();
            var imported = e.Item as VaseisDBnew;
            //DisplayAlert(imported.sxoli, imported.vasi + currhaseidikomathima, "OK");
            Navigation.PushAsync(new SelectedVasiPage(imported));
        }
    }
}
