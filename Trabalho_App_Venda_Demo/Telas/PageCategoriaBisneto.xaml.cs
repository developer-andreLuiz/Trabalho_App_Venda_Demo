using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Venda_Demo.ModeloRetorno;
using Trabalho_App_Venda_Demo.VariaveisGlobais;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Venda_Demo.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCategoriaBisneto : ContentPage
    {
        public PageCategoriaBisneto()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            collectionViewTela.ItemsSource = retornoCategoriaBisneto();
        }
        List<CategoriasNivel4Retorno> retornoCategoriaBisneto()
        {
            List<CategoriasNivel4Retorno> list = new List<CategoriasNivel4Retorno>();

            foreach (var a in Global.instancia.listaCategoriaNivel4)
            {
                if (a.CategoriaNivel1 == Global.instancia.id_Categoria_Nivel1 && a.CategoriaNivel2 == Global.instancia.id_Categoria_Nivel2 && a.CategoriaNivel3 == Global.instancia.id_Categoria_Nivel3)
                {
                    list.Add(a);
                }

            }
            return list;
        }
        private void PushAsyncWithoutDuplicate(Page page)
        {
            if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != page.GetType())
            {
                Navigation.PushAsync(page);
            }
        }
        private async void imgBtnHome_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAudioService>().PlayAudioFile("button.mp3");
            await imgBtnHome.ScaleTo(1.5, 50);
            await imgBtnHome.ScaleTo(1, 50);

            PushAsyncWithoutDuplicate(new PageCategoriaPai());
        }
        private async void imgBtnCarrinho_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAudioService>().PlayAudioFile("button.mp3");
            await imgBtnCarrinho.ScaleTo(1.5, 50);
            await imgBtnCarrinho.ScaleTo(1, 50);

            PushAsyncWithoutDuplicate(new PageCarrinhoDeCompra());
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                Frame frame = (Frame)sender;
                Label x = frame.FindByName<Label>("lblNome");

                if (x.Text != null)
                {
                    foreach (var a in Global.instancia.listaCategoriaNivel4)
                    {
                        if (a.Nome.Equals(x.Text) && a.CategoriaNivel1 == Global.instancia.id_Categoria_Nivel1 && a.CategoriaNivel2 == Global.instancia.id_Categoria_Nivel2 && a.CategoriaNivel3 == Global.instancia.id_Categoria_Nivel3)
                        {
                            Global.instancia.id_Categoria_Nivel4 = a.Id;
                            break;
                        }
                    }

                    PushAsyncWithoutDuplicate(new PageListarProdutos());
                }
            }
            catch { }
        }
    }
}