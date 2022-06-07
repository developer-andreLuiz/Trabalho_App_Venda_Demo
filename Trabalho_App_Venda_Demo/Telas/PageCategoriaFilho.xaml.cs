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
    public partial class PageCategoriaFilho : ContentPage
    {
        public PageCategoriaFilho()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            collectionViewTela.ItemsSource = retornoCategoriaFilho();
        }
        List<CategoriasNivel2Retorno> retornoCategoriaFilho()
        {
            List<CategoriasNivel2Retorno> list = new List<CategoriasNivel2Retorno>();

            foreach (var a in Global.instancia.listaCategoriaNivel2)
            {
                if (a.CategoriaNivel1 == Global.instancia.id_Categoria_Nivel1)
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
                Label lbl = frame.FindByName<Label>("lblNome");

                if (lbl.Text != null)
                {
                    Global.instancia.id_Categoria_Nivel2 = Global.instancia.listaCategoriaNivel2.Find(x => x.CategoriaNivel1== Global.instancia.id_Categoria_Nivel1 && x.Nome.Equals(lbl.Text)).Id;
                    Global.instancia.id_Categoria_Nivel3 = 0;
                    Global.instancia.id_Categoria_Nivel4 = 0;

                    //verificar se tem produto
                    var l = Global.instancia.listaProdutosCategoria.FindAll(x => x.CategoriaNivel1 == Global.instancia.id_Categoria_Nivel1 && x.CategoriaNivel2 == Global.instancia.id_Categoria_Nivel2);
                    if (l.Count < 13)
                    {
                        Global.instancia.id_Categoria_Nivel3 = -1;
                        Global.instancia.id_Categoria_Nivel4 = -1;
                        PushAsyncWithoutDuplicate(new PageListarProdutos());//junta tudo
                        return;
                    }

                    l = Global.instancia.listaProdutosCategoria.FindAll(x => x.CategoriaNivel1 == Global.instancia.id_Categoria_Nivel1 && x.CategoriaNivel2 == Global.instancia.id_Categoria_Nivel2 && x.CategoriaNivel3 == 0 && x.CategoriaNivel4 == 0);
                    if (l.Count > 0)
                    {
                        PushAsyncWithoutDuplicate(new PageListarProdutos());
                    }
                    else
                    {
                        PushAsyncWithoutDuplicate(new PageCategoriaNeto());
                    }

                }
            }
            catch { }
        }
    }
}