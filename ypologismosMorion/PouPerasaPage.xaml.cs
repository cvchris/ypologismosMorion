using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using ypologismosMorion;
using ypologismosMorion.Models;
using static ypologismosMorion.VaseisDB;

namespace ypologismosMorion
{
    public partial class PouPerasaPage : ContentPage
    {
        public PouPerasaPage(double moria, int kateuthinsi, bool exeieidiko, double moriaeidikou)
        {
            InitializeComponent();

            //For Testing
            //Tamoriamou.Text = moria.ToString() + "..." + kateuthinsi.ToString();
            


            sxolespoupernas.ItemsSource = VaseisData.Where(x => (x.vasi <= moria && x.ExeiEidikoMathima == false) || (x.vasi <= moriaeidikou && x.ExeiEidikoMathima == true) && ((x.pedio == (kateuthinsi + 1) || x.deuteropedio == (kateuthinsi + 1) || x.tritopedio == (kateuthinsi + 1) || x.ApoOlaTaPedia==true) || (x.tefaa == true && exeieidiko == true)));
            
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
            
            var imported = e.Item as Vaseis;
            //DisplayAlert(imported.sxoli, imported.vasi + currhaseidikomathima, "OK");
            Navigation.PushAsync(new SelectedVasiPage(imported));
        }
    }
}
