using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Venda_Demo.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMenu : ContentPage
    {
        public PageMenu()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btnMeusPedidos_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnCentralAtendimento_Clicked(object sender, EventArgs e)
        {
            try
            {
                Chat.Open("+55021987788440", "");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void btnPoliticaPrivacidade_Clicked(object sender, EventArgs e)
        {

        }

        private void btnConfiguracoes_Clicked(object sender, EventArgs e)
        {

        }
    }
}