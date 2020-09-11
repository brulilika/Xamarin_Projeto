using Projeto.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DirectPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
