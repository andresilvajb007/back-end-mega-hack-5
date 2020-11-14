using System;
using System.Collections.Generic;

namespace back_end_mega_hack_5.Entidades
{
    public class TipoBoleto
    {
        public int Id { get; set; }

        public string  Descricao { get; set; }

        public virtual IList<Boleto> Boletos { get; set; }

      
        public TipoBoleto()
        {
        }
    }
}
