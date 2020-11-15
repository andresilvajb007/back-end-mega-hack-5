using System;
namespace back_end_mega_hack_5.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public virtual ContaCorrente ContaCorrente { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string UrlImagem { get; set; }

        public Cliente()
        {
        }
    }
}
