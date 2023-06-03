using cev.api.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cev.api.Domain.ModelsDb
{
    public class VendaDb
    {
        [Key]
        [Column("id_db")]
        public int IdDb { get; set; }
        [Column("id_venda")]
        public int IdVenda { get; set; }
        [Column("data_venda")]
        public DateTime DataVenda { get; set; }
        [Column("forma_pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        [Column("vendedor_id")]
        public int VendedorId { get; set; }
        [Column("produto_id")]
        public int ProdutoId { get; set; }
        [Column("produto_valor")]
        public double ProdutoValor { get; set; }
        [Column("quantidade")]
        public int Quantidade { get; set; }
    }
}
