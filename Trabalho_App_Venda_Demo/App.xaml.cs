using System;
using System.Collections.Generic;
using System.Threading;
using Trabalho_App_Venda_Demo.ModeloRetorno;
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

            while (true)
            {
                if (Global.instancia.pronto==6)
                {
                    //Apenas Produtos Habilitados
                    Global.instancia.listaProdutos = Global.instancia.listaProdutos.FindAll(x=>x.Habilitado==true);

                    //Apenas Produtos Categoria de Produtos Habilitados
                    var listaProdutoCategoria = new List<ProdutosCategoriaRetorno>();
                    listaProdutoCategoria.AddRange(Global.instancia.listaProdutosCategoria);
                    foreach (var item in listaProdutoCategoria)
                    {
                        var l = Global.instancia.listaProdutos.FindAll(x => x.Id == item.Produto);
                        if (l.Count==0)
                        {
                            Global.instancia.listaProdutosCategoria.Remove(item);
                        }
                    }

                    //Apenas  Categoria1 com Produtos Habilitados
                    var listaCategoria1 = new List<CategoriasNivel1Retorno>();
                    listaCategoria1.AddRange(Global.instancia.listaCategoriaNivel1);
                    foreach (var item in listaCategoria1)
                    {
                        var l = Global.instancia.listaProdutosCategoria.FindAll(x=>x.CategoriaNivel1==item.Id);
                        if (l.Count == 0)
                        {
                            Global.instancia.listaCategoriaNivel1.Remove(item);
                        }
                    }

                    //Apenas  Categoria2 com Produtos Habilitados
                    var listaCategoria2 = new List<CategoriasNivel2Retorno>();
                    listaCategoria2.AddRange(Global.instancia.listaCategoriaNivel2);
                    foreach (var item in listaCategoria2)
                    {
                        var l = Global.instancia.listaProdutosCategoria.FindAll(x => x.CategoriaNivel2 == item.Id);
                        if (l.Count == 0)
                        {
                            Global.instancia.listaCategoriaNivel2.Remove(item);
                        }
                    }
                    
                    //Apenas  Categoria3 com Produtos Habilitados
                    var listaCategoria3 = new List<CategoriasNivel3Retorno>();
                    listaCategoria3.AddRange(Global.instancia.listaCategoriaNivel3);
                    foreach (var item in listaCategoria3)
                    {
                        var l = Global.instancia.listaProdutosCategoria.FindAll(x => x.CategoriaNivel3 == item.Id);
                        if (l.Count == 0)
                        {
                            Global.instancia.listaCategoriaNivel3.Remove(item);
                        }
                    }

                    //Apenas  Categoria4 com Produtos Habilitados
                    var listaCategoria4 = new List<CategoriasNivel4Retorno>();
                    listaCategoria4.AddRange(Global.instancia.listaCategoriaNivel4);
                    foreach (var item in listaCategoria4)
                    {
                        var l = Global.instancia.listaProdutosCategoria.FindAll(x => x.CategoriaNivel4 == item.Id);
                        if (l.Count == 0)
                        {
                            Global.instancia.listaCategoriaNivel4.Remove(item);
                        }
                    }



                    break;
                }
            }

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
