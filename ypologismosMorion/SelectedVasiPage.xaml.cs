using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ypologismosMorion.VaseisDB;

namespace ypologismosMorion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedVasiPage : ContentPage
    {
        public SelectedVasiPage(Vaseis currentsxoli)
        {
            InitializeComponent();
            this.Title = currentsxoli.sxoli;
            sxoli_label.Text = currentsxoli.sxoli;
            poli_label.Text = currentsxoli.poli;
            vasi_label.Text = currentsxoli.vasi.ToString();

            if (currentsxoli.ExeiEidikoMathima)
            {
                EidikaMathimata_layout.IsVisible = true;
                eidikoMathima_label.Text = currentsxoli.EidikaMathimata;
            }
            if (currentsxoli.stratiotikes || currentsxoli.Astinomikes || currentsxoli.Pirosvestes){
                Stratiotikes_layout.IsVisible = true;
            }
            if (currentsxoli.pedio == 1 || currentsxoli.deuteropedio==1 || currentsxoli.tritopedio==1 || currentsxoli.ApoOlaTaPedia || currentsxoli.tefaa ) {
                protopedio_label.IsVisible = true;
            }
            if (currentsxoli.pedio == 2 || currentsxoli.deuteropedio == 2 || currentsxoli.tritopedio==2|| currentsxoli.ApoOlaTaPedia || currentsxoli.tefaa)
            {
                deuteropedio_label.IsVisible = true;
            }
            if (currentsxoli.pedio == 3 || currentsxoli.deuteropedio == 3 || currentsxoli.tritopedio==3|| currentsxoli.ApoOlaTaPedia || currentsxoli.tefaa)
            {
                tritopedio_label.IsVisible = true;
            }
            if (currentsxoli.pedio == 4 || currentsxoli.deuteropedio == 4 || currentsxoli.tritopedio==4|| currentsxoli.ApoOlaTaPedia || currentsxoli.tefaa)
            {
                tetartopedio_label.IsVisible = true;
            }
            if(currentsxoli.triteknoi)
            {
                triteknoi_layout.IsVisible = true;
            }
            if (currentsxoli.politeknoi){
                politeknoi_layout.IsVisible = true;
            }
            if (currentsxoli.GelEklisiastikon)
                gelekklisiastikon_layout.IsVisible = true;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

           
        }
    }
}
    
