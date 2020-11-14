using System;
namespace back_end_mega_hack_5.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public virtual ContaCorrente ContaCorrente { get; set; }
        

        public Cliente()
        {
        }
    }
}
