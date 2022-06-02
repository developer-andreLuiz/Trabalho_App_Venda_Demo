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
                Label lbl = frame.FindByName<Label>("lblNome");

                if (lbl.Text != null)
                {
                    Global.instancia.id_Categoria_Nivel1 = Global.instancia.listaCategoriaNivel1.Find(x=>x.Nome.Equals(lbl.Text)).Id;
                    Global.instancia.id_Categoria_Nivel2 = 0;
                    Global.instancia.id_Categoria_Nivel3 = 0;
                    Global.instancia.id_Categoria_Nivel4 = 0;


                    //verificacr se tem produto

                    var l = Global.instancia.listaProdutosCategoria.FindAll(x => x.CategoriaNivel1 == Global.instancia.id_Categoria_Nivel1 && x.CategoriaNivel2 == 0 && x.CategoriaNivel3 == 0 && x.CategoriaNivel4 == 0);
                    if (l.Count > 0)
                    {
                        PushAsyncWithoutDuplicate(new PageListarProdutos());
                    }
                    else
                    {
                        PushAsyncWithoutDuplicate(new PageCategoriaFilho());
                    }


                }
            }
            catch { }
        }

    }
}