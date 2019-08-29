using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ypologismosMorion.Models;
using System.Linq;

namespace ypologismosMorion
{

    public partial class VaseisPagedb : ContentPage
    {

        bool atoz = true;
       // List<Vaseis> lista2 = VaseisData;
        List<VaseisDBnew> data = new DatabaseManager().GetAllVaseis2019();
        List<VaseisDBnew> selectedVaseis { get; set; }

        public VaseisPagedb()
        {
            InitializeComponent();
            selectedVaseis = data;
            sxoles_vaseis_listview.ItemsSource = selectedVaseis;

            var poleislist = data.GroupBy(item => item.poli)
                           .OrderByDescending(a => a.Count())
                           .Select(x => x.Key)
                           .ToList();
            poleislist.RemoveAll(x => x == null);
            poleislist.Insert(0, "Κανένα");
            selectPoli.ItemsSource = poleislist.ToList();

        }

        private void Sorting_Activated(object sender, EventArgs e)
        {
            sorting();
        }

        private void sxoles_vaseis_listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            sxoles_vaseis_listview.SelectedItem = null;
        }

        string searchbare;
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchbare = e.NewTextValue;
            Filtering();
        }

        private void Πόλη_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void filt_Activated(object sender, EventArgs e)
        {
            Filters.IsVisible = !Filters.IsVisible;
        }

        private void selectPedio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void ApplyFilters_Clicked(object sender, EventArgs e)
        {
            //sxoles_vaseis_listview.ItemsSource = SortedList;
        }

        public void Filtering()
        {
            if(selectPedio.SelectedIndex > 0)
            {
                selectedVaseis = new DatabaseManager().GetVaseis(selectPedio.SelectedIndex);
                sxoles_vaseis_listview.ItemsSource = selectedVaseis;
            }
            else
            {
                selectedVaseis = data;
            }

            if(selectPoli.SelectedIndex > 0)
            {
                selectedVaseis = selectedVaseis.Where(x => x.poli == selectPoli.SelectedItem.ToString()).ToList();
            }

            if(!string.IsNullOrEmpty(searchbare))
            {
                selectedVaseis = selectedVaseis.Where(x => x.sxoli.ToUpper().Contains(searchbare.ToUpper())).ToList();
            }


            sxoles_vaseis_listview.ItemsSource = selectedVaseis;

            //if (EidikesKatigories.SelectedIndex > 0)
            //{
            //    newlist = lista2.Where(x => x.poli == (selectPoli.SelectedIndex > 0 ? selectPoli.SelectedItem.ToString() : x.poli))
            //        .Where(x => (x.pedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.pedio) || x.deuteropedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.deuteropedio) || x.tefaa == true || x.tritopedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.tritopedio)) || x.ApoOlaTaPedia == true || x.tefaa == true)
            //        .Where(x => x.stratiotikesAkatigoria == (EidikesKatigories.SelectedItem == "Στρατιωτικές Ειδ. Κατ. 3648/α"))
            //        .Where(x => x.stratiotikesBkatigoria == (EidikesKatigories.SelectedItem == "Στρατιωτικές Ειδ. Κατ. 3648/β"))
            //        .Where(x => x.triteknoi == (EidikesKatigories.SelectedItem == "Τρίτεκνοι"))
            //        .Where(x => x.politeknoi == (EidikesKatigories.SelectedItem == "Πολύτεκνοι"))
            //        .Where(x => x.monoGiaAstinomikous == (EidikesKatigories.SelectedItem == "Μόνο για Αστυνομικούς"))
            //        .Where(x => x.MonoGiaPirosvestes == (EidikesKatigories.SelectedItem == "Μόνο για Πυροσβέστες"))
            //        .Where(x => x.GelEklisiastikon == (EidikesKatigories.SelectedItem == "ΓΕΛ Εκκλησιαστικών"))
            //        .Where(x => x.sxoli.ToUpper().Contains((!string.IsNullOrEmpty(searchbare)) ? searchbare.ToUpper() : x.sxoli.ToUpper()));

            //}
            //else
            //{
            //    newlist = ListToGetFrom.Where(x => x.poli == (selectPoli.SelectedIndex > 0 ? selectPoli.SelectedItem.ToString() : x.poli))
            //        .Where(x => (x.pedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.pedio) || x.deuteropedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.deuteropedio) || x.tefaa == true || x.tritopedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.tritopedio)) || x.ApoOlaTaPedia == true || x.tefaa == true)
            //        .Where(x => x.sxoli.ToUpper().Contains((!string.IsNullOrEmpty(searchbare)) ? searchbare.ToUpper() : x.sxoli.ToUpper()));

            //}

            //sxoles_vaseis_listview.ItemsSource = newlist;
        }


        private void EidikesKatigories_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void sxoles_vaseis_listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var imported = e.Item as VaseisDBnew;
            Navigation.PushAsync(new SelectedVasiPage(imported));
        }
        public void sorting()
        {

            if (atoz == true)
            {
                selectedVaseis = selectedVaseis.OrderBy(o => o.vasi).ToList();

            }
            else
            {
                selectedVaseis = selectedVaseis.OrderByDescending(o => o.vasi).ToList();
            }
            atoz = !atoz;
            sxoles_vaseis_listview.ItemsSource = selectedVaseis;
        }
    }
}
