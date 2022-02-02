using System;
using System.Threading;
using Trabalho_App_Venda_Demo.Servico;
using Trabalho_App_Venda_Demo.Telas;
using Trabalho_App_Venda_Demo.VariaveisGlobais;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Venda_Demo
{
    public partial class App : Application
    {
        public App()
        {
            Thread categoriaNivel2 = new Thread(BuscarCaterogiaNivel2);
            Thread categoriaNivel3 = new Thread(BuscarCaterogiaNivel3);
            Thread categoriaNivel4 = new Thread(BuscarCaterogiaNivel4);
            Thread produto = new Thread(BuscarProduto);
            Thread produtosCategoria = new Thread(BuscarProdutosCategoria);
            
            categoriaNivel2.Start();
            categoriaNivel3.Start();
            categoriaNivel4.Start();
            produto.Start();
            produtosCategoria.Start();


            Global.instancia.id_Categoria_Nivel1 = 0;
            Global.instancia.id_Categoria_Nivel2 = 0;
            Global.instancia.id_Categoria_Nivel3 = 0;
            Global.instancia.id_Categoria_Nivel4 = 0;

            BuscarCaterogiaNivel1();
            InitializeComponent();

            MainPage = new NavigationPage(new PageCategoriaPai());
        }
        void BuscarCaterogiaNivel1()
        {
            ServBuscarCategoriaNivel1.BuscarCategoriaNivel1Resultado();
        }
        static void BuscarCaterogiaNivel2()
        {
            ServBuscarCategoriaNivel2.BuscarCategoriaNivel2Resultado();
        }
        static void BuscarCaterogiaNivel3()
        {
            ServBuscarCategoriaNivel3.BuscarCategoriaNivel3Resultado();
        }
        static void BuscarCaterogiaNivel4()
        {
            ServBuscarCategoriaNivel4.BuscarCategoriaNivel4Resultado();
        }
        static void BuscarProduto()
        {
            ServBuscarProduto.BuscarProdutoResultado();
        }
        static void BuscarProdutosCategoria()
        {
            ServBuscarProdutosCategoria.BuscarProdutosCategoriaResultado();
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
