using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    internal class SajátKészítésűJáték : IJáték
    {
        string nev;
        public string Nev { get { return nev; } }
        public SajátKészítésűJáték(string nev)
        {
            this.nev = nev;
        }
        public virtual bool JátszhatVele(int eletkor)
        {
            return true;
        }
    }

    internal class VeszélyesJáték : SajátKészítésűJáték
    {
        public VeszélyesJáték(string nev) : base(nev)
        {
            
        }

        public override bool JátszhatVele(int eletkor)
        {
            if (eletkor >= 18)
            {
                return true;
            }
            return false;
        }
    }
}
