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
        List<VaseisDBnewWithPedio> data = new List<VaseisDBnewWithPedio>();
        List<VaseisDBnewWithPedio> selectedVaseis { get; set; }
        DatabaseManager _dbconnection;

        public VaseisPagedb()
        {
            InitializeComponent();
            var dbconnection = new DatabaseManager();
            _dbconnection = dbconnection;
            selectEtos.SelectedIndex = 0;
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

        public void Filtering()
        {
            if(selectPedio.SelectedIndex > 0)
            {
                selectedVaseis = _dbconnection.GetVaseis(selectPedio.SelectedIndex, Convert.ToInt32(selectEtos.SelectedItem.ToString()));
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
        }


        private void EidikesKatigories_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void sxoles_vaseis_listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var imported = e.Item as VaseisDBnewWithPedio;
            int yearSelected = selectEtos.SelectedItem.ToString() == "2019" ? 2019 : 2018;
            //var db = _dbconnection.GetVasi(imported.Mixanografiko,,yearSelected);
            Navigation.PushAsync(new SelectedVasiPage(imported, yearSelected));
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

        private void SelectEtos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string etosString = selectEtos.SelectedItem.ToString();
            var etos = Convert.ToInt32(etosString);
            selectedVaseis = _dbconnection.GetAllVaseis(etos);
            data = selectedVaseis;
            Filtering();
        }
    }
}
