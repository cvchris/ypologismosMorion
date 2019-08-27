using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ypologismosMorion.Models;
using System.Linq;
using static ypologismosMorion.VaseisDB;

namespace ypologismosMorion
{
    /*
               //TO-DO//
        
        * rating
        *ASTINOMIKES SXOLES POTE TO PIANEI STI LISTA ME TO POU MPENO. (FOR V. 1.1)
        * teffaa logic (V 1.1)
        * informations page (V. 1.1)
        * koin kritiria
        * eidikes katigories se main menu
        * στις λογοθεραπειες ισχυει αυτο: Ο υποψήφιος που δηλώνει τμήματα Λογοθεραπείας, πρέπει να γνωρίζει ότι δεν μπορεί να παρακολουθήσει το τμήμα αυτό, αν παρουσιάζει κώφωση-βαρηκοΐα, δυσαρθρία, τραύλισμα, εγκεφαλοπάθεια που επηρεάζει τη λειτουργία λόγου - άρθρωσης ή παθολογική φωνή. Όσοι εισάγονται στα τμήματα αυτά, υποβάλλονται σε σχετικές εξετάσεις με ευθύνη του τμήματος και αν διαπιστωθεί ότι κάποιος παρουσιάζει μια από τις παραπάνω παθήσεις, διαγράφεται από το τμήμα αυτό
        * chechboxes
        
        

            //DONE//
        * crash with - (OK)
        *ADS ios - ios Version (OK)
        * logo kai splash screen (OK)
        * sort the list based on the times a city is being shown. (DONE)
        * POLEIS STO FILTERING (OK)
        * GEL EKKLISIASTIKWN (OK)
        * tritopedio (OK)
    */

    public partial class VaseisPage : ContentPage
    {

        bool atoz = true;
        List<Vaseis> lista2 = VaseisData;
        List<VaseisDBnew> data = new DatabaseManager().GetAllVaseis2019();

        public IEnumerable<Vaseis> newlist = new List<Vaseis>();
        public IEnumerable<Vaseis> ListToGetFrom = new List<Vaseis>();

        public VaseisPage()
        {
            // Lista 2 -> Has every item, also there we define the colleges.
            // List to Get From -> Has everyitem except the "triteknoi, politeknoi, monogiaastinomikous"
            // newlist -> current list, it is the one that is being showed after filters are being applied.
            InitializeComponent();

            ListToGetFrom = lista2.Where(x => x.triteknoi == false && x.politeknoi == false && x.monoGiaAstinomikous == false && x.KoinKritiria == false && x.MonoGiaPirosvestes == false && x.GelEklisiastikon == false && x.stratiotikesAkatigoria == false && x.stratiotikesBkatigoria == false);
            newlist = ListToGetFrom;
            sxoles_vaseis_listview.ItemsSource = ListToGetFrom;
            //data.Where(x => x.)
            var poleislist = lista2.GroupBy(item => item.poli)
                           .OrderByDescending(a => a.Count())
                           .Select(x => x.Key)
                           .ToList()
                           ;
            poleislist.Insert(0, "Κανένα");
            selectPoli.ItemsSource = poleislist.ToList();

            foreach (Vaseis v in lista2)
            {
                if (v.sxoli.StartsWith("ΑΞΙΩΜΑΤΙΚΩΝ ΕΛΛΗΝΙΚΗΣ ΑΣΤΥΝΟΜΙΑΣ"))
                {
                    v.pedio = 1;
                    v.deuteropedio = 2;
                    v.tritopedio = 4;
                }
            }




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

            if (EidikesKatigories.SelectedIndex > 0)
            {
                newlist = lista2.Where(x => x.poli == (selectPoli.SelectedIndex > 0 ? selectPoli.SelectedItem.ToString() : x.poli))
                    .Where(x => (x.pedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.pedio) || x.deuteropedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.deuteropedio) || x.tefaa == true || x.tritopedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.tritopedio)) || x.ApoOlaTaPedia == true || x.tefaa == true)
                    .Where(x => x.stratiotikesAkatigoria == (EidikesKatigories.SelectedItem == "Στρατιωτικές Ειδ. Κατ. 3648/α"))
                    .Where(x => x.stratiotikesBkatigoria == (EidikesKatigories.SelectedItem == "Στρατιωτικές Ειδ. Κατ. 3648/β"))
                    .Where(x => x.triteknoi == (EidikesKatigories.SelectedItem == "Τρίτεκνοι"))
                    .Where(x => x.politeknoi == (EidikesKatigories.SelectedItem == "Πολύτεκνοι"))
                    .Where(x => x.monoGiaAstinomikous == (EidikesKatigories.SelectedItem == "Μόνο για Αστυνομικούς"))
                    .Where(x => x.MonoGiaPirosvestes == (EidikesKatigories.SelectedItem == "Μόνο για Πυροσβέστες"))
                    .Where(x => x.GelEklisiastikon == (EidikesKatigories.SelectedItem == "ΓΕΛ Εκκλησιαστικών"))
                    .Where(x => x.sxoli.ToUpper().Contains((!string.IsNullOrEmpty(searchbare)) ? searchbare.ToUpper() : x.sxoli.ToUpper()));

            }
            else
            {
                newlist = ListToGetFrom.Where(x => x.poli == (selectPoli.SelectedIndex > 0 ? selectPoli.SelectedItem.ToString() : x.poli))
                    .Where(x => (x.pedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.pedio) || x.deuteropedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.deuteropedio) || x.tefaa == true || x.tritopedio == (selectPedio.SelectedIndex > 0 ? selectPedio.SelectedIndex : x.tritopedio)) || x.ApoOlaTaPedia == true || x.tefaa == true)
                    .Where(x => x.sxoli.ToUpper().Contains((!string.IsNullOrEmpty(searchbare)) ? searchbare.ToUpper() : x.sxoli.ToUpper()));

            }

            sxoles_vaseis_listview.ItemsSource = newlist;
        }


        private void EidikesKatigories_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void sxoles_vaseis_listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
            //var imported = e.Item as Vaseis;
            //Navigation.PushAsync(new SelectedVasiPage(imported));
        }
        public void sorting()
        {
            if (atoz == true)
            {
                newlist = newlist.OrderBy(o => o.vasi).ToList();

            }
            else
            {
                newlist = newlist.OrderByDescending(o => o.vasi).ToList();
            }
            atoz = !atoz;
            sxoles_vaseis_listview.ItemsSource = newlist;
        }
    }
}
