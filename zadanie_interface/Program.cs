namespace gaaaaaaaaaaaa
{
    internal class Program
    {
        public interface IDokument
        {
            string Tytul { get; }
            DateTime DataUtworzenia { get; }
            void Wyswietl();
        }
        public class Faktura : IDokument
        {
            public string Tytul { get; private set; }
            public DateTime DataUtworzenia { get; private set; }
            public decimal Kwota { get; private set; }
            public void Wyswietl()
            {
                Console.WriteLine("Dokument:Faktura");
                Console.WriteLine($"Tutuł:{Tytul}");
                Console.WriteLine($"Data Utworzenia:{DataUtworzenia}");
                Console.WriteLine($"Kwota: {Kwota}");
            }
            public Faktura(string tytul, DateTime dataUtworzenia, decimal kwota)
            {
                Tytul = tytul;
                DataUtworzenia = dataUtworzenia;
                Kwota = kwota;
            }
        }
        public class Raport : IDokument
        {
            public string Tytul { get; private set; }
            public DateTime DataUtworzenia { get; private set; }
            public string Autor { get; private set; }
            public void Wyswietl()
            {
                Console.WriteLine("Dokument:Faktura");
                Console.WriteLine($"Tutuł:{Tytul}");
                Console.WriteLine($"Data Utworzenia:{DataUtworzenia}");
                Console.WriteLine($"Autor: {Autor}");
            }
            public Raport(string tytul, DateTime dataUtworzenia, string autor)
            {
                Tytul = tytul;
                DataUtworzenia = dataUtworzenia;
                Autor = autor;
            }
        }
        public class Email : IDokument
        {
            public string Tytul { get; private set; }
            public DateTime DataUtworzenia { get; private set; }
            public string Nadawca { get; private set; }
            public void Wyswietl()
            {
                Console.WriteLine("Dokument:Faktura");
                Console.WriteLine($"Tutuł:{Tytul}");
                Console.WriteLine($"Data Utworzenia:{DataUtworzenia}");
                Console.WriteLine($"Nadawca: {Nadawca}");
            }
            public Email(string tytul, DateTime dataUtworzenia, string nadawca)
            {
                Tytul = tytul;
                DataUtworzenia = dataUtworzenia;
                Nadawca = nadawca;
            }
        }
        static void Main(string[] args)
        {
            List<IDokument> dokumenty = new List<IDokument>
            {
                new Faktura("tytul1",new DateTime(2020,2,12,10,50,0),3000),
                new Raport("tytul2",new DateTime(2022,12,15,2,50, 0),"Jan Kowalski"),
                new Email("tytul3",new DateTime(2020,4,8,11,30, 0),"Anna Nowak")
            };
            foreach (IDokument d in dokumenty)
            {
                d.Wyswietl();
            }
        }
    }
}