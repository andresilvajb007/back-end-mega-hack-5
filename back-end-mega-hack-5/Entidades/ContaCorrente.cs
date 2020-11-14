using System;
namespace back_end_mega_hack_5.Entidades
{
    public class ContaCorrente
    {

        public int Id { get; set; }

        public decimal Saldo { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public ContaCorrente()
        {

        }
    }
}
