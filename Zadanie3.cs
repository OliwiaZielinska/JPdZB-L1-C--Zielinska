/* Author: Oliwia Zielińska
Linki, z których korzystano podczas realizacji zadania:
TWORZENIE KLAS W C#: https://www.plukasiewicz.net/CSharp_dla_poczatkujacych/Klasy
KOLEKCJE W C#: https://www.plukasiewicz.net/Csharp_dla_zaawansowanych/Kolekcje
TYP GENERYCZNY W C#: https://www.plukasiewicz.net/Csharp_dla_zaawansowanych/Typy_generyczne
*/
using System;
using System.Collections.Generic;

class PodzbioryZadanie
{
    public static void Main(string[] args)
    {   PodzbioryZadanie podzbioryZadanie = new PodzbioryZadanie();
        // przetestowanie poprawnego działania funkcji Podzbiory
        TestPodzbiory(podzbioryZadanie, new List<char> { 'a', 'b', 'c', 'd' });
        TestPodzbiory(podzbioryZadanie, new List<char> { 'a', 'b', 'c', 'd', 'e' });
        TestPodzbiory(podzbioryZadanie, new List<char> { '1', '2', '3', '5' });
        
        // przetestowanie wyrzucenia wyjątku
        TestPodzbiory(podzbioryZadanie, new List<char> {' '});
    }

    public static void TestPodzbiory(PodzbioryZadanie podzbioryZadanie, List<char> zbior)
    {
        try
        {
            List<List<char>> wynik = Podzbiory(zbior);
            foreach (var podzbior in wynik)
            {
                Console.WriteLine($"Zbiór {{ {string.Join(", ", zbior)} }} ma następujące podzbiory: {{ {string.Join(", ", podzbior)} }}");
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Zbiór {{ {string.Join(", ", zbior)} }} wyrzuca następujący błąd: {e.Message}");
        }
    }

    // funkcja do wypisania wszystkich podzbiorów zbioru x
    static List<List<T>> Podzbiory<T>(List<T> zbior)
    {
        if (zbior == null)
        {
            throw new ArgumentNullException(nameof(zbior), "Zbiór nie może być null");
        }

        List<List<T>> wynik = new List<List<T>>();
        int liczbaPodzbiorow = (int)Math.Pow(2, zbior.Count);
        
        for (int i = 0; i < liczbaPodzbiorow; i++)
        {
            List<T> podzbior = new List<T>();
            for (int j = 0; j < zbior.Count; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    podzbior.Add(zbior[j]);
                }
            }
            wynik.Add(podzbior);
        }
        
        return wynik;
    }
}