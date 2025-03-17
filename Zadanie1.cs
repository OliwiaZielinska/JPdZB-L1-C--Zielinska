/* Author: Oliwia Zielińska
Linki, z których korzystano podczas realizacji zadania:
WZÓR HARONA: https://pl.wikipedia.org/wiki/Wz%C3%B3r_Herona
TWORZENIE KLAS W C#: https://dev-hobby.pl/csharp/funkcje-metody-w-c/ oraz https://www.plukasiewicz.net/CSharp_dla_poczatkujacych/Klasy
*/
using System;

public class Heron
{   // zdefiniowanie pól klasy
    public int a;
    public int b;
    public int c;

    // metoda do przetestowania działania funkcji herona
    /*public static void Main(string[] args)
    {
        Heron heronObiekt = new Heron();

        // Test poprawnego działania
        TestHerona(heronObiekt, 3, 4, 5);

        // Drugi test poprawnego działania
        TestHerona(heronObiekt, 7, 5, 10);

        // Test dla ujemnego boku
        TestHerona(heronObiekt, -3, 4, 2);

        // Test dla boku o długości 0
        TestHerona(heronObiekt, 3, 4, 0);

        // Test dla boków, które nie utworzą trójkąta
        TestHerona(heronObiekt, 1, 1, 2);
    }
*/
    public static void TestHerona(Heron heronObiekt, int a, int b, int c)
    {
        try
        {
            double S = heronObiekt.heron(a, b, c);
            Console.WriteLine($"Pole S dla trójkąta o bokach {a}, {b}, {c} wynosi: {S}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Błąd dla boków {a}, {b}, {c}: {e.Message}");
        }
    }


    // funkcja do wyliczania pola trójkąta S wykorzystująca wzór Herona
    public double heron(int a, int b, int c){
    if (a <= 0 || b <= 0 || c <= 0){
        throw new ArgumentException("Boki trójkąta nie mogą być liczbami ujemnymi lub równymi 0!");
    }
    double obwod = (0.5)*(a+b+c);
    double S = Math.Sqrt(obwod*(obwod-a)*(obwod-b)*(obwod-c));
    if (S <= 0){
        throw new ArgumentException("Z podanych długości boków nie można utworzyć trójkąta!");
    }
    return S;
    }
}
