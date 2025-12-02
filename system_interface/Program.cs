using static gaaaaaaaaaaaa.Program;

namespace gaaaaaaaaaaaa
{
    internal class Program
    {
        public interface IPracownik
        {
            string Imie { get; }
            string Nazwisko { get; }
            decimal ObliczPensje();

        }
        public interface ISposobWyplaty
        {
            string NazwaSposobu { get; }
            void WyplacPieniadze(decimal kwota, string odbiorca);
        }
        public class PracownikEtatowy : IPracownik {
            public string Imie { get; private set; }
            public string Nazwisko { get; private set; }
            public int StalaPensja { get; private set; }
            public decimal ObliczPensje()
            {
                return StalaPensja;
            }
            public PracownikEtatowy(string imie,string nazwisko, int stalaPensja)
            {
                Imie = imie;
                Nazwisko = nazwisko;
                StalaPensja = stalaPensja;
            }
        }
        public class PracownikGodzinowy:IPracownik
        {
            public string Imie { get; private set; }
            public string Nazwisko { get; private set; }
            public decimal StawkaGodzinowa { get; private set; }
            public int LiczbaGodzin { get; private set; }
            public decimal ObliczPensje()
            {
                return StawkaGodzinowa*LiczbaGodzin;
            }
            public PracownikGodzinowy(string im,string naz,decimal staw,int godz)
            {
                Imie = im;
                Nazwisko = naz;
                StawkaGodzinowa = staw;
                LiczbaGodzin = godz;
            }
        }
        public class PracownikKomisowy : IPracownik
        {
            public string Imie { get; private set; }
            public string Nazwisko { get; private set; }
            public int pensjaPodst { get; private set; }
            public int procent {  get; private set; }
            public decimal ObliczPensje()
            {
                return pensjaPodst + pensjaPodst * (procent / 100);
            }
            public PracownikKomisowy(string imie,string nazw,int pensj,int proc)
            {
                Imie = imie;
                Nazwisko = nazw;
                pensjaPodst = pensj;
                procent = proc;
            }
        }
        public class PrzelewBankowy : ISposobWyplaty
        {
            public string NazwaSposobu { get; private set; }
            public void WyplacPieniadze(decimal kwota, string odbiorca)
            {
                Console.WriteLine($"{odbiorca} otrzymał/a {kwota} zł poprzez przelew bankowy");
            }
        }
        public class Gotowka : ISposobWyplaty
        {
            public string NazwaSposobu { get; private set; }
            public void WyplacPieniadze(decimal kwota, string odbiorca)
            {
                Console.WriteLine($"{odbiorca} otrzymał/a {kwota} zł gotówką");
            }
        }
        public class Czek : ISposobWyplaty
        {
            public string NazwaSposobu { get; private set; }
            public void WyplacPieniadze(decimal kwota, string odbiorca)
            {
                Console.WriteLine($"{odbiorca} otrzymał/a {kwota} zł poprzez czek");
            }
        }
        public class SystemWyplat
        {
            public void WyplacPensje(IPracownik pracownik,ISposobWyplaty sposob)
            {
                sposob.WyplacPieniadze(pracownik.ObliczPensje(), (pracownik.Imie + " " + pracownik.Nazwisko));
            }
            public void WyplacPensjeWszystkim(List<IPracownik> pracowniki,ISposobWyplaty domyslnySposob)
            {
                foreach (IPracownik pracownik in pracowniki) {
                    domyslnySposob.WyplacPieniadze(pracownik.ObliczPensje(), (pracownik.Imie + " " + pracownik.Nazwisko));
                }
            }
            public void GenerujRaport(List<IPracownik> pracowniki)
            {
                foreach (IPracownik prac in pracowniki)
                {
                    Console.WriteLine($"Pracownik: {prac.Imie} {prac.Nazwisko}");
                    Console.WriteLine($"Pensja: {prac.ObliczPensje()} zł");
                }
            }
        }
        static void Main(string[] args)
        {
            Random r = new Random();

            List<IPracownik> pracowniks = new List<IPracownik>
            {
                new PracownikEtatowy("Janusz","Kowalski",6300),
                new PracownikGodzinowy("Agnieszka","Łapaj",20,170),
                new PracownikKomisowy("Michał","Musiał",4000,7),
                new PracownikEtatowy("Aleksandra","Szłoda", 5000),
                new PracownikKomisowy("Paweł","Nowak",3400,15)
            };
            List<ISposobWyplaty> sposobyy = new List<ISposobWyplaty>
            {
                new PrzelewBankowy(),
                new Gotowka(),
                new Czek()
            };
            SystemWyplat system = new SystemWyplat();
            foreach (IPracownik prac in pracowniks)
            {
                system.WyplacPensje(prac , sposobyy[r.Next(0,3)] );
            }
            Console.WriteLine();
            system.GenerujRaport(pracowniks);
        }
    }
}
