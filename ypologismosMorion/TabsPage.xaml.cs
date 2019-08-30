using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ypologismosMorion
{
    public partial class TabsPage : TabbedPage
    {
        public TabsPage()
        {
            InitializeComponent();
            
            this.Children.Add(new MainPage() { Icon = "calculator.png" , Title = "Υπολογισμός"}) ;
            this.Children.Add(new VaseisPagedb() { Icon = "vasiImage.png", Title = "Βάσεις" });
            this.Children.Add(new AboutPage() {Icon="information.png", Title = "Σχετικά"});
            
        }
    }
}
