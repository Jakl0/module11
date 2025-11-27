namespace gaaaaaaaaaaaa
{
    internal class Program
    {
        public abstract class KontoBankowe
        {
            public string NumerKonta {  get;private set; }
            public string Wlasciciel {  get;private set; }
            public decimal Saldo { get; protected set; }
            public abstract decimal ObliczOprocentowanie();
            public virtual void WyswietlInformacje()
            {
                Console.WriteLine($"Numer Konta: {NumerKonta}");
                Console.WriteLine($"Właściciel: {Wlasciciel}");
                Console.WriteLine($"Saldo: {Saldo}");
            }
            public KontoBankowe(string numerKonta, string wlasciciel, decimal saldo)
            {
                NumerKonta = numerKonta;
                Wlasciciel = wlasciciel;
                Saldo = saldo;
            }
            public void Wplac(decimal kwota)
            {
                Saldo += kwota;
            }
            public virtual void Wyplac(decimal kwota) 
            {
                Saldo -= kwota;
            }
        }
        public class KontoOszczednosciowe:KontoBankowe
        {
            public override decimal ObliczOprocentowanie()
            {
                return 5;  
            }
            public KontoOszczednosciowe(string nrkon, string wlas, decimal sal) : base(nrkon, wlas, sal)
            {

            }
        }
        public class KontoStudenckie:KontoBankowe
        {
            public KontoStudenckie(string nrkon, string wlas, decimal sal) : base(nrkon, wlas, sal)
            {

            }
            public override decimal ObliczOprocentowanie()
            {
                return 2;
            }
            
        }
        public class KontoFirmowe:KontoBankowe
        {
            public KontoFirmowe(string nrkon, string wlas, decimal sal) : base(nrkon, wlas, sal)
            {

            }
            public override decimal ObliczOprocentowanie()
            {
                return 0;
            }
            public override void Wyplac(decimal kwota)
            {
                Saldo -= kwota + 2;
            }
        }

        
        static void Main(string[] args)
        {
            List<KontoBankowe> konta = new List<KontoBankowe>
            {
                new KontoOszczednosciowe("2","Jan Nowak",100),
                new KontoStudenckie("1","Karol Drygasiewicz",200),
                new KontoFirmowe("50","Julia Kowalska",20),

            };

            foreach(KontoBankowe a in konta)
            {
                a.WyswietlInformacje();
                a.Wplac(1000);
                Console.WriteLine(a.ObliczOprocentowanie());
            }
            konta[2].Wyplac(50);
            konta[2].WyswietlInformacje();

        }
    }
}