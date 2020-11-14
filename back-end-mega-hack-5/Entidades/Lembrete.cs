using System;
namespace back_end_mega_hack_5.Entidades
{
    public class Lembrete
    {

        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal ValorBoleto { get; set; }

        public DateTime? DataAviso { get; set; }

        public DateTime? DataDoPagamento { get; set; }

        public Lembrete()
        {
        }
    }
}
