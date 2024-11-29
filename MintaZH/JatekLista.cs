using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    internal class ListaElem<T>
    {
        public T Tartalom { get; set; }
        public ListaElem<T> Kovetkezo { get; set; }
    }
    internal class JatekLista<T> where T : IJáték
    {   
        public int EletkorKorlat { get; set; }
        public JatekLista(int eletkorKorlat)
        {
            EletkorKorlat = eletkorKorlat;
        }
    }
}
