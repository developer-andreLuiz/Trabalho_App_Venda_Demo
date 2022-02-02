using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Venda_Demo.SQLite;
using Trabalho_App_Venda_Demo.SQLite.ModeloDB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Venda_Demo.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCarrinhoDeCompra : ContentPage
    {
        CarrinhoDeCompraSQLite carrinhoDeCompraSQL = new CarrinhoDeCompraSQLite();
        List<CarrinhoDeCompra> lista = new List<CarrinhoDeCompra>();
        private ObservableCollection<CarrinhoDeCompra> listaTela;
        public PageCarrinhoDeCompra()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            listaTela = new ObservableCollection<CarrinhoDeCompra>();
            lista = carrinhoDeCompraSQL.GetAllProduto();
            foreach (var a in lista)
            {
                listaTela.Add(new CarrinhoDeCompra() { id = a.id, codigo = a.codigo, nome = a.nome, img = a.img, valor_venda = a.valor_venda, quantidade = a.quantidade, valor_total = a.valor_total });
            }

            collectionViewTela.ItemsSource = listaTela;
            ExibirValorTotal();
        }
        private void PushAsyncWithoutDuplicate(Page page)
        {
            if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != page.GetType())
            {
                Navigation.PushAsync(page);
            }
        }
        private void imgBtnHome_Clicked(object sender, EventArgs e)
        {
            PushAsyncWithoutDuplicate(new PageCategoriaPai());
        }
        private void imgBtnLixeira_Clicked(object sender, EventArgs e)
        {
            CarrinhoDeCompraSQLite carrinhoDeCompraSQLite = new CarrinhoDeCompraSQLite();
            carrinhoDeCompraSQLite.LimparLista();
            listaTela.Clear();
            ExibirValorTotal();
        }
        private void imgLixeiraLista(object sender, EventArgs e)
        {
            Image imageLixeira = (Image)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)imageLixeira.GestureRecognizers[0];
            CarrinhoDeCompra carrinhoDeCompra = tapGest.CommandParameter as CarrinhoDeCompra;
            carrinhoDeCompraSQL.DeletarProduto(carrinhoDeCompra);
            listaTela.Remove(carrinhoDeCompra);
            ExibirValorTotal();
        }
        private void imgMenosLista(object sender, EventArgs e)
        {
            Image imageMenos = (Image)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)imageMenos.GestureRecognizers[0];
            CarrinhoDeCompra carrinhoDeCompra = tapGest.CommandParameter as CarrinhoDeCompra;

            if (carrinhoDeCompra.quantidade > 1)
            {
                carrinhoDeCompra.quantidade--;
                carrinhoDeCompra.valor_total -= carrinhoDeCompra.valor_venda;
                carrinhoDeCompra.valor_total = (float)Math.Round(carrinhoDeCompra.valor_total, 2);
                carrinhoDeCompraSQL.AtualizarProduto(carrinhoDeCompra);
                listaTela[listaTela.IndexOf(carrinhoDeCompra)].quantidade = carrinhoDeCompra.quantidade;
                listaTela[listaTela.IndexOf(carrinhoDeCompra)].valor_total = carrinhoDeCompra.valor_total;
            }
            else
            {
                carrinhoDeCompraSQL.DeletarProduto(carrinhoDeCompra);
                listaTela.Remove(carrinhoDeCompra);
            }

            ExibirValorTotal();

        }
        private void imgMaisLista(object sender, EventArgs e)
        {
            Image imageMais = (Image)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)imageMais.GestureRecognizers[0];
            CarrinhoDeCompra carrinhoDeCompra = tapGest.CommandParameter as CarrinhoDeCompra;
            carrinhoDeCompra.quantidade++;
            carrinhoDeCompra.valor_total += carrinhoDeCompra.valor_venda;
            carrinhoDeCompra.valor_total = (float)Math.Round(carrinhoDeCompra.valor_total, 2);
            carrinhoDeCompraSQL.AtualizarProduto(carrinhoDeCompra);

            listaTela[listaTela.IndexOf(carrinhoDeCompra)].quantidade = carrinhoDeCompra.quantidade;
            listaTela[listaTela.IndexOf(carrinhoDeCompra)].valor_total = carrinhoDeCompra.valor_total;

            ExibirValorTotal();

        }
        float AtualizarValor()
        {
            float valor = 0;
            List<CarrinhoDeCompra> listCarrinhoCompra = new List<CarrinhoDeCompra>();
            listCarrinhoCompra = carrinhoDeCompraSQL.GetAllProduto();

            foreach (var a in listCarrinhoCompra)
            {
                try
                {
                    valor += a.valor_total;
                }
                catch
                {

                }

            }

            return (float)Math.Round(valor, 2);

        }
        void ExibirValorTotal()
        {
            lblTotal.Text = "R$ " + AtualizarValor().ToString();
        }
    }
}