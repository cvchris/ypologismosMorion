﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ypologismosMorion.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ypologismosMorion.Models.EidikaMathimataDB;
using static ypologismosMorion.Models.Mathimata;

namespace ypologismosMorion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EidikaMathimataSelect : ContentPage
    {

        public int selected_kat_public;
        
        public EidikaMathimataSelect(int selected_kateuthinsi)
        {
            DbData.Clear();
            InitializeComponent();
            selected_kat_public = selected_kateuthinsi;
            ChangeLabel(selected_kateuthinsi);
            var e_math = returnValue(e_mathima_entry.Text);
            if (e_mathima_switch.IsToggled && margins(e_math))
            {
                //we have to return the right pedio and the value added with the other matthimata.
                //we make the calculations


            }
            //to see how it returns the data..
        }

        private void BackButton_Clicked(object sender, EventArgs e, int selected_kateuthinsi)
        {

            forReturn();
            Navigation.PopAsync();
        }


        void ChangeLabel(int selected_kateuthinsi)
        {
            if (selected_kateuthinsi == 0)
            {
                e_mathima_label.Text = "Βιολογία Γ.Π.";
            }
            else if (selected_kateuthinsi == 1)
            {
                e_mathima_label.Text = "Βιολογία Κατ.";
            }
            else if (selected_kateuthinsi == 2)
            {
                e_mathima_label.Text = "Μαθηματικά";
            }
            else if (selected_kateuthinsi == 3)
            {
                e_mathima_label.Text = "Βιολογία Γ.Π.";
            }
        }
        void ChangePickerLabel()
        {

        }
        private bool margins(double val)
        {
            if (val > 20 || val < 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private double returnValue(string arr)
        {
            double a = 0;
            if (!string.IsNullOrWhiteSpace(arr))
            {
                a = Convert.ToDouble(arr);
            }
            return a;
        }

        private void e_mathima_switch_Toggled(object sender, ToggledEventArgs e)
        {
            e_mathima_entry.IsVisible = !e_mathima_entry.IsVisible;
            if (!e_mathima_switch.IsToggled)
            {
                e_mathima_entry.Text = null;
            }

        }

        void agglika_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            agglika.IsVisible = !agglika.IsVisible;
            if (!agglika_switch.IsToggled)
            {
                agglika.Text = null;
            }
            if (agglika_switch.IsToggled != agglika.IsVisible)
            {
                agglika_switch.IsToggled = !agglika_switch.IsToggled;
            }
        }

        void gallika_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            gallika.IsVisible = !gallika.IsVisible;
            if (!gallika_switch.IsToggled)
            {
                gallika.Text = null;
            }
        }

        void forReturn()
        {
            count = 0;

            if (e_mathima_switch.IsToggled)
            {
                var v = Convert.ToDouble(e_mathima_entry.Text);
                if (selected_kat_public == 0)
                {
                    //*290

                    DbData.Add(new EidikaMathimataProperties { eidikomathima = "Βιολογία Γ.Π.",  moria = (v * 290 + Mathima_a * 240 + Mathima_c * 200 + Mathima_d * 200), pediopouanoigei="Επιστήμης Υγείας" });
                    EidikaMathimataDB.count++;
                }
                else if(selected_kat_public == 3){
                    DbData.Add(new EidikaMathimataProperties { eidikomathima = "Βιολογία Γ.Π.", moria = (v * 290 + Mathima_a * 240 + Mathima_b * 200 + Mathima_d * 200), pediopouanoigei = "Επιστήμης Υγείας" });
                }
                else if (selected_kat_public == 1)
                {
                    DbData.Add(new EidikaMathimataProperties { eidikomathima = "Βιολογία Κατ.", moria = (v * 330 + Mathima_a * 200 + Mathima_b * 200 + Mathima_c * 270 ), pediopouanoigei = "Επιστήμης Υγείας" });
                }
                else
                {
                    DbData.Add(new EidikaMathimataProperties { eidikomathima = "Μαθηματικά", moria = (v * 330 + Mathima_a * 200 + Mathima_b * 200 + Mathima_c * 270), pediopouanoigei = "Θετικών Επιστημών" });
                }
                EidikaMathimataDB.count++;
            }
            if (agglika_switch.IsToggled)
            {
                DbData.Add(new EidikaMathimataProperties { eidikomathima = "Αγγλικά", vathmos = Convert.ToDouble(agglika.Text) });
                count++;
            }
            if (gallika_switch.IsToggled)
            {
                DbData.Add(new EidikaMathimataProperties { eidikomathima = "Γαλλικά", vathmos = Convert.ToDouble(gallika.Text) });
            }
            if (germanika_switch.IsToggled)
            {
                DbData.Add(new EidikaMathimataProperties { eidikomathima = "Γερμανικά", vathmos = Convert.ToDouble(germanika.Text) });
            }
            if (italika_switch.IsToggled)
            {
                DbData.Add(new EidikaMathimataProperties { eidikomathima = "Ιταλικά", vathmos = Convert.ToDouble(italika.Text) });
            }
            if (ispanika_switch.IsToggled)
            {
                DbData.Add(new EidikaMathimataProperties { eidikomathima = "Ισπανικά", vathmos = Convert.ToDouble(ispanika.Text) });
            }
            if (agonismata_switch.IsToggled)
            {
                DbData.Add(new EidikaMathimataProperties { eidikomathima = "Αγωνίσματα", vathmos = Convert.ToDouble(agonisma1.Text), vathmos2 = Convert.ToDouble(agonisma2.Text), vathmos3 = Convert.ToDouble(agonisma3.Text) });
            }
            if (sxedio_switch.IsToggled)
            {
                DbData.Add(new EidikaMathimataProperties { eidikomathima = "Σχέδιο", vathmos = Convert.ToDouble(eleuthero_sxedio_entry.Text), vathmos2 = Convert.ToDouble(grammiko_sxedio_entry.Text) });
            }
            if (mousiki_switch.IsToggled)
            {
                DbData.Add(new EidikaMathimataProperties { eidikomathima = "Μουσική", vathmos = Convert.ToDouble(armonia_entry.Text), vathmos2 = Convert.ToDouble(mousiki_akoustiki_entry.Text) });
            }
            // for debug DisplayAlert("aaa", DbData.Count().ToString(), "cancel");
            
        }
        




    }
}