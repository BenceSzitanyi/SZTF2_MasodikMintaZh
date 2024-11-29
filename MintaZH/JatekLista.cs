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
        public delegate void ÚjJátékFelvéveKezelo(IJáték obj);
        public event ÚjJátékFelvéveKezelo ÚjJátékFelvéve;
        int eletKorlat;
        public int EletkorKorlat 
        {
            get
            { 
                return eletKorlat;
            }

            set
            {
                eletKorlat = value;
                NemMegfeleloTorloBejaro();
            } 
        }
        private ListaElem<T> fej;

        public JatekLista(int eletkorKorlat)
        {
            this.EletkorKorlat = eletkorKorlat;
            fej = null;
        }

        private void NemMegfeleloTorloBejaro()
        {
            ListaElem<T> p = fej;
            while (p != null)
            {
                if (!p.Tartalom.JátszhatVele(eletKorlat))
                {
                    JátékTörlése(p.Tartalom);
                }
                p = p.Kovetkezo;
            }
        }
        
        public void ÚjJátékFelvétele(T tartalom, bool vegere = true)
        {
            if (vegere)
            {
                //ListaVégére beszuras
                if (tartalom.JátszhatVele(EletkorKorlat))
                {
                    ListaElem<T> uj = new ListaElem<T>();
                    uj.Tartalom = tartalom;
                    if (fej == null)
                    {
                        fej = uj;
                    }
                    else
                    {
                        ListaElem<T> p = fej;
                        ListaElem<T> e = null;
                        while (p != null)
                        {
                            e = p;
                            p = p.Kovetkezo;
                        }
                        p = uj;
                        e.Kovetkezo = p;
                    }
                    ÚjJátékFelvéve?.Invoke(tartalom);
                }
            }
            else
            {
                //Lista elejére
                ListaElem<T> uj = new ListaElem<T>();
                uj.Tartalom = tartalom;
                uj.Kovetkezo = fej;
                fej = uj;
            }
        }

        public void JátékTörlése(T torlendo)
        {
            ListaElem<T> p = fej;
            ListaElem<T> e = null;

            while (p != null && !p.Tartalom.Equals(torlendo))
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (p != null)
            {
                //megtaláltam az elemet
                if (e == null)
                {
                    fej = p.Kovetkezo;
                }
                else
                {
                    e.Kovetkezo = p.Kovetkezo;
                }
            }
            else
            {
                //nem találtam meg
                throw new ArgumentException("Nincs ilyen elem a listában");
            }
        }

        public T JátékKeresés(T keresett)
        {
            ListaElem<T> p = fej;
            ListaElem<T> e = null;
            while (p != null && !p.Tartalom.Equals(keresett))
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (p != null)
            {
                e.Kovetkezo = p.Kovetkezo;
                p.Kovetkezo = fej;
                fej = p;
                return p.Tartalom;
            }
            else { throw new ArgumentException("Nincs ilyen elem"); }
        }

    }
}
