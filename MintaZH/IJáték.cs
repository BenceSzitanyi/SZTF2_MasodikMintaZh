using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    internal interface IJáték
    {
        public string Nev { get; }
        public bool JátszhatVele(int eletkor);
    }
}
