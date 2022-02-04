using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Trabalho_App_Venda_Demo.SQLite.ModeloDB;

namespace Trabalho_App_Venda_Demo.SQLite
{
    public class CarrinhoDeCompraSQLite : IDisposable
    {
        private SQLiteConnection conexaoSQLite;
        public CarrinhoDeCompraSQLite()
        {
            var config = DependencyService.Get<IConfig>();
            string caminho = config.ObterCaminho("database.sqlite");
            conexaoSQLite = new SQLiteConnection(caminho);
            conexaoSQLite.CreateTable<CarrinhoDeCompra>();
        }
        public void Dispose()
        {
            conexaoSQLite.Dispose();
        }
        public void InserirProduto(CarrinhoDeCompra carrinhoDeCompra)
        {
            conexaoSQLite.Insert(carrinhoDeCompra);
        }
        public void AtualizarProduto(CarrinhoDeCompra carrinhoDeCompra)
        {
            conexaoSQLite.Update(carrinhoDeCompra);
        }
        public void DeletarProduto(CarrinhoDeCompra carrinhoDeCompra)
        {
            conexaoSQLite.Delete(carrinhoDeCompra);
        }
        public void LimparLista()
        {
            conexaoSQLite.DeleteAll<CarrinhoDeCompra>();
        }
        public CarrinhoDeCompra GetProduto(int codigo)
        {
            return conexaoSQLite.Table<CarrinhoDeCompra>().Where(a => a.codigo == codigo).FirstOrDefault();
        }
        public List<CarrinhoDeCompra> GetAllProduto()
        {
            return conexaoSQLite.Table<CarrinhoDeCompra>().ToList();
        }

    }
}
