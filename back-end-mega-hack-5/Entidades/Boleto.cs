using System;
namespace back_end_mega_hack_5.Entidades
{
    public enum EnumStatusBoleto
    {
        PENDENTE_PAGAMENTO = 0,
        PAGO = 1
   }

    public class Boleto
    {
        public int Id { get; set; }

        public string  Descricao { get; set; }

        public int TipoBoletoId { get; set; }
        public virtual TipoBoleto TipoBoleto { get; set; }

        public decimal Valor { get; set; }

        public DateTime? DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }

        public Boleto()
        {
        }
    }
}
