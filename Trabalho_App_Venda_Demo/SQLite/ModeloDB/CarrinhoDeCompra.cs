using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace Trabalho_App_Venda_Demo.SQLite.ModeloDB
{
    [Table("CarrinhoDeCompra")]
    public class CarrinhoDeCompra : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int codigo { get; set; }
        public string nome { get; set; }
        public string img { get; set; }
        public float valor_venda { get; set; }

        public int Quantidade;
        public int quantidade
        {
            get
            {
                return Quantidade;
            }
            set
            {
                Quantidade = value;
                PropertyChanged(this, new PropertyChangedEventArgs("quantidade"));
            }
        }








        private float Valor_total;
        public float valor_total
        {
            get
            {
                return Valor_total;
            }
            set
            {
                Valor_total = value;
                PropertyChanged(this, new PropertyChangedEventArgs("valor_total"));
            }
        }







        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
