﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ypologismosMorion.Models;
using static ypologismosMorion.Models.EidikaMathimataDB;
using static ypologismosMorion.Models.Mathimata;

namespace ypologismosMorion
{
    public partial class MainPage : ContentPage
    {
        double moria;
        int kateuthinsi;

        public MainPage()
        {
            InitializeComponent();
            

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            showEidikaMathimata();
            eidikamathimata_display.HeightRequest = DbData.Count() * 45;
            eidikamathimata_display.ItemsSource = DbData.ToList();
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            kateuthinsi = epilogi.SelectedIndex;
            if (epilogi.SelectedIndex != -1)
            {
                a_mathima_label.IsVisible = true;
                b_mathima_label.IsVisible = true;
                c_mathima_label.IsVisible = true;
                d_mathima_label.IsVisible = true;
                a_mathima.IsVisible = true;
                b_mathima.IsVisible = true;
                c_mathima.IsVisible = true;
                d_mathima.IsVisible = true;
                a_mathima_label.Text = "Έκθεση";
                //e_mathimata_button.IsVisible = true;
                eidika_temp_name_label.IsVisible = true;
                Eidika_temp_switch.IsVisible = true;
                click.IsVisible = true;
                apotelesma.IsVisible = true;
            }


            if (epilogi.SelectedIndex == 0)
            {
                b_mathima_label.Text = "Λατινικά";
                c_mathima_label.Text = "Ιστορία";
                d_mathima_label.Text = "Αρχαία";


            }
            else if (epilogi.SelectedIndex == 1)
            {
                b_mathima_label.Text = "Χημεία";
                c_mathima_label.Text = "Φυσική";
                d_mathima_label.Text = "Μαθηματικά";


            }
            else if (epilogi.SelectedIndex == 2)
            {
                b_mathima_label.Text = "Φυσική";
                c_mathima_label.Text = "Χημεία";
                d_mathima_label.Text = "Βιολογία";

            }
            else
            {
                b_mathima_label.Text = "ΑΕΠΠ";
                c_mathima_label.Text = "ΑΟΘ";
                d_mathima_label.Text = "Μαθηματικά";

            }
        }



        double moriaeidikou = 0;
        bool exeieidiko = false;

        void Result_Clicked(object sender, System.EventArgs e)
        {
            moriatext.Text = epilogi.SelectedItem.ToString() + " : ";
            apotelesmaeidika.Text = null;

            pushData();
            double ap4;

            if ((margins(Mathima_a) && margins(Mathima_b) && margins(Mathima_c) && margins(Mathima_d)))
            {
                apotelesma.TextColor = System.Drawing.Color.Black;
                ap4 = Mathima_a * 200 + Mathima_b * 200 + Mathima_c * 270 + Mathima_d * 330;
                apotelesma.Text = ap4.ToString();
                PouPernw.IsVisible = true;
                moriatext.IsVisible = true;
                moria = ap4;

                if (Eidika_temp_switch.IsToggled)
                {
                    apotelesmaeidika.IsVisible = true;
                    if (marginseidika(Mathima_e))
                    {
                        apotelesmaeidika.TextColor = System.Drawing.Color.Black;
                        moriaeidikou = ap4 + returnValue(Eidika_temp.Text);
                        exeieidiko = true;
                        // Text="Με ειδικά Μαθήματα :"
                        apotelesmaeidika.Text = "Με ειδικά Μαθήματα: " + moriaeidikou.ToString();
                    }
                    else
                    {
                        apotelesmaeidika.TextColor = System.Drawing.Color.Red;
                        apotelesmaeidika.Text = "Σφάλμα στον υπολογισμό με ειδικά μαθήματα";
                    }
                    
                }
                else
                {
                    exeieidiko = false;
                }

            }
            else
            {
                apotelesma.TextColor = System.Drawing.Color.Red;
                apotelesma.Text = "Σφάλμα";
                PouPernw.IsVisible = false;
            }

            if (count != 0)
            {
                EidikaMathimata_layout.IsVisible = false; //kanei to menou poy leei poia eidika mathimata exoun epilextei
                //apotelesmata_list.ItemsSource = DbData.ToList();
                //apotelesmata_list.HeightRequest = DbData.Count() * 25;
            }

        }

        async void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PouPerasaPage(moria, kateuthinsi, exeieidiko, moriaeidikou));
        }

        private double returnValue(string arr)
        {
            double a;
            string value = null;
            if (Device.RuntimePlatform == Device.Android)
            {
                try
                {
                    value = double.Parse(arr.Replace(',', '.'), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture).ToString();
                }
                catch
                {

                }
                
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(arr))
                {
                    value = arr.Replace('.', ',');
                }
            }
            
            double.TryParse(value, out a);
            return a == null ? 0 : a;


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

        private bool marginseidika(double val)
        {
            if (val > 4000 || val < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        private void eidika_mathimata_button_Clicked(object sender, EventArgs e)
        {
            pushData();
            Navigation.PushAsync(new EidikaMathimataSelect(epilogi.SelectedIndex));
        }


        public void showEidikaMathimata()
        {
            if (EidikaMathimataDB.count == 0)
            {
                EidikaMathimata_layout.IsVisible = false;
            }
            else
            {
                EidikaMathimata_layout.IsVisible = true;
            }
            
         

        }
        void pushData()
        {
            Mathima_a = returnValue(a_mathima.Text);
            Mathima_b = returnValue(b_mathima.Text);
            Mathima_c = returnValue(c_mathima.Text);
            Mathima_d = returnValue(d_mathima.Text);
            Mathima_e = returnValue(Eidika_temp.Text);
        }

        private void Eidika_temp_switch_Toggled(object sender, ToggledEventArgs e)
        {
            eidika_temp_label.IsVisible = !eidika_temp_label.IsVisible;
            Eidika_temp.IsVisible = !Eidika_temp.IsVisible;
        }
    }
}
