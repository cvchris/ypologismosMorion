using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ypologismosMorion.Models;
//using static ypologismosMorion.VaseisDB;

namespace ypologismosMorion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedVasiPage : ContentPage
    {
        DatabaseManager _databaseManager;
        public SelectedVasiPage(VaseisDBnewWithPedio currentsxoli, int yearSelected)
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager();

            int yearNotSelected = yearSelected == 2019 ? 2018 : 2019;

            //load vasi 2018/2019 if exists
            var vasiInOtherYear = _databaseManager.GetVasi(currentsxoli.Mixanografiko, currentsxoli.Pedio, yearNotSelected);


            if (yearSelected == 2019)
            {
                vasi2019_layout.IsVisible = true;
                vasi2019_label.Text = currentsxoli.vasi.ToString();
                if(vasiInOtherYear != null)
                {
                    vasi2018_layout.IsVisible = true;
                    vasi2018_label.Text = vasiInOtherYear.vasi.ToString();
                }
            }
            else
            {
                vasi2018_layout.IsVisible = true;
                vasi2018_label.Text = currentsxoli.vasi.ToString();
                if (vasiInOtherYear != null)
                {
                    vasi2019_layout.IsVisible = true;
                    vasi2019_label.Text = vasiInOtherYear.vasi.ToString();
                }
            }


            this.Title = currentsxoli.sxoli;
            sxoli_label.Text = currentsxoli.sxoli;
            poli_label.Text = currentsxoli.poli;
            idsxolis.Text = currentsxoli.ID.ToString();
            idryma_label.Text = currentsxoli.idryma;
            kodikosMixanografikou.Text = currentsxoli.Mixanografiko.ToString();



            if (currentsxoli.eidika != null)
            {
                EidikaMathimata_layout.IsVisible = true;
                eidikoMathima_label.Text = currentsxoli.eidika;
            }
            if (currentsxoli.typos.Contains("ΣΤΡΑΤΙΩΤΙΚΕΣ"))
            {
                Stratiotikes_layout.IsVisible = true;
            }

            var pediaPouAnikei = new DatabaseManager().SePoiaPediaAnikei(currentsxoli.Mixanografiko, yearSelected);
            if(pediaPouAnikei.Contains(1))
            {
                protopedio_label.IsVisible = true;
            }
            if (pediaPouAnikei.Contains(2))
            {
                deuteropedio_label.IsVisible = true;
            }
            if (pediaPouAnikei.Contains(3))
            {
                tritopedio_label.IsVisible = true;
            }
            if (pediaPouAnikei.Contains(4))
            {
                tetartopedio_label.IsVisible = true;
            }

            //if(currentsxoli.triteknoi)
            //{
            //    triteknoi_layout.IsVisible = true;
            //}
            //if (currentsxoli.politeknoi){
            //    politeknoi_layout.IsVisible = true;
            //}
            //if (currentsxoli.GelEklisiastikon)
            //    gelekklisiastikon_layout.IsVisible = true;
            //if (currentsxoli.stratiotikesAkatigoria)
            //    stratiotikesA_layout.IsVisible = true;
            //if (currentsxoli.stratiotikesBkatigoria)
            //    stratiotikesB_layout.IsVisible = true;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

           
        }
    }
}
    
