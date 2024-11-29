namespace MintaZH
{
    internal class Program
    {
        static void ElemFelvetelKiiro(IJáték j)
        {
            Console.WriteLine(j.Nev + " felvéve a listába");
        }
        private static void Main(string[] args)
        {
            JatekLista<SajátKészítésűJáték> lista = new JatekLista<SajátKészítésűJáték>(20);
            lista.ÚjJátékFelvéve += ElemFelvetelKiiro;

            SajátKészítésűJáték[] t = new SajátKészítésűJáték[3];

            t[0] = new SajátKészítésűJáték("Nórijó");
            t[1] = new SajátKészítésűJáték("Miszt");
            t[2] = new VeszélyesJáték("Nagyon véres lövölde");

            lista.ÚjJátékFelvétele(t[0]);
            lista.ÚjJátékFelvétele(t[1]);
            lista.ÚjJátékFelvétele(t[2]);

            string keresettNev = lista.JátékKeresés(new VeszélyesJáték("asd")).Nev;
            Console.WriteLine(keresettNev);

            lista.JátékTörlése(t[0]);
            lista.JátékKeresés(t[0]);
        }
    }
}