using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Venda_Demo.VariaveisGlobais;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Venda_Demo.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCategoriaPai : ContentPage
    {
        public PageCategoriaPai()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            collectionViewTela.ItemsSource = VariaveisGlobais.Global.instancia.listaCategoriaNivel1;
        }
        private void PushAsyncWithoutDuplicate(Page page)
        {
            if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != page.GetType())
            {
                Navigation.PushAsync(page);
            }
        }
        private async void imgBtnMenu_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAudioService>().PlayAudioFile("button.mp3");
            await imgBtnMenu.ScaleTo(1.5, 50);
            await imgBtnMenu.ScaleTo(1, 50);

            PushAsyncWithoutDuplicate(new PageMenu());
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
                    foreach (var a in Global.instancia.listaCategoriaNivel1)
                    {
                        if (a.Nome.Equals(x.Text))
                        {
                            Global.instancia.id_Categoria_Nivel1 = a.Id;
                            break;
                        }
                    }

                    bool filhoLocal = false;

                    foreach (var a in Global.instancia.listaCategoriaNivel2)
                    {
                        if (a.CategoriaNivel1 == Global.instancia.id_Categoria_Nivel1)
                        {
                            filhoLocal = true;
                            break;
                        }
                    }
                    if (filhoLocal)
                    {
                        PushAsyncWithoutDuplicate(new PageCategoriaFilho());
                    }
                    else
                    {
                        Global.instancia.id_Categoria_Nivel2 = 0;
                        Global.instancia.id_Categoria_Nivel3 = 0;
                        Global.instancia.id_Categoria_Nivel4 = 0;
                        PushAsyncWithoutDuplicate(new PageListarProdutos());
                    }

                }
            }
            catch { }
        }

    }
}