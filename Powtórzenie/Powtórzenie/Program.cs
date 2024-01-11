using System;
using System.Collections.Generic;
using static Programm;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
public class Program1
{
    private static Klient klient = new Klient("Jan", "Kowalski");

    public static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Dodaj książkę do koszyka");
            Console.WriteLine("2. Dodaj elektronikę do koszyka");
            Console.WriteLine("3. Dodaj odzież do koszyka");
            Console.WriteLine("4. Wyświetl cenę koszyka");
            Console.WriteLine("5. Wyjście");

            Console.Write("Wybierz opcję: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    klient.DodajDoKoszyka(new Ksiazka("Wiedźmin", 50, 10));
                    Console.WriteLine("Dodano książkę do koszyka.");
                    break;
                case "2":
                    klient.DodajDoKoszyka(new Elektronika("Laptop", 2500, 5));
                    Console.WriteLine("Dodano elektronikę do koszyka.");
                    break;
                case "3":
                    klient.DodajDoKoszyka(new Odziez("Kurtka", 300, 20));
                    Console.WriteLine("Dodano odzież do koszyka.");
                    break;
                case "4":
                    Console.WriteLine($"Cena koszyka: {klient.ObliczCeneKoszyka()} zł");
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }
    }
}


internal class Programm
{

    public interface IProdukt
    {
        string WyswietlInfo();
        int AktualnaCena();
        int DostępnaIlosc();

    }

    public abstract class Produkt : IProdukt
    {
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public int Ilosc { get; set; }

        protected Produkt(string nazwa, int cena, int ilosc)
        {
            Nazwa = nazwa;
            Cena = cena;
            Ilosc = ilosc;
        }

        public string WyswietlInfo()
        {
            return Nazwa;
        }

        public int AktualnaCena()
        {
            return Cena;
        }

        public int DostępnaIlosc()
        {
            return Ilosc;
        }
    }

    public class Ksiazka : Produkt
    {
        public Ksiazka(string nazwa, int cena, int ilosc) : base(nazwa, cena, ilosc)
        {
        }
    }

    public class Elektronika : Produkt
    {
        public Elektronika(string nazwa, int cena, int ilosc) : base(nazwa, cena, ilosc)
        {
        }
    }

    public class Odziez : Produkt
    {
        public Odziez(string nazwa, int cena, int ilosc) : base(nazwa, cena, ilosc)
        {
        }
    }

    public abstract class Osoba
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }

        protected Osoba(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }
    }

    public class Klient : Osoba
    {

        private List<IProdukt> koszyk = new List<IProdukt>();

        public Klient(string imie, string nazwisko) : base(imie, nazwisko)
        {
        }
        public int Ilosc { get; set; }

        public void DodajDoKoszyka(IProdukt produkt)
        {
            int ilosc = produkt.DostępnaIlosc();


            if (produkt != null && produkt.DostępnaIlosc() > 0)
            {
                koszyk.Add(produkt);
                produkt.DostępnaIlosc(); 
            }
        }

        public int ObliczCeneKoszyka()
        {
            int suma = 0;
            foreach (var produkt in koszyk)
            {
                suma += produkt.AktualnaCena();
            }
            return suma;
        }
    }    
}