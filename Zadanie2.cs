/* Author: Oliwia Zielińska
Linki, z których korzystano podczas realizacji zadania:
DEFINICJA MULTIZBIORU: https://pl.wikipedia.org/wiki/Multizbi%C3%B3r
TWORZENIE KLAS W C#: https://www.plukasiewicz.net/CSharp_dla_poczatkujacych/Klasy
TABLICE W C#: https://www.plukasiewicz.net/CSharp_dla_poczatkujacych/Tablice
KOLEKCJE W C#: https://www.plukasiewicz.net/Csharp_dla_zaawansowanych/Kolekcje
*/
using System;

public class Wspolne
{   // zdefiniowanie pól klasy
    public int[] x = Array.Empty<int>();
    public int[] y = Array.Empty<int>();

    // metoda do przetestowania działania funkcji wspolne
    public static void Main(string[] args)
    {
        Wspolne wspolneObiekt = new Wspolne();

        // Test poprawnego działania
        TestWspolne(wspolneObiekt, [1,2,3,4], [5, 2, 1, 4]);

        // Drugi test poprawnego działania
        TestWspolne(wspolneObiekt, [1,5,4, 2, 2, 3, 4], [2, 2, 3, 5]);

       // Pusta tablica
        TestWspolne(wspolneObiekt, [], [2, 2, 3, 5]);

        // Drugi multizbiór pusty
        TestWspolne(wspolneObiekt, [1, 2, 2, 3, 4], []);
    }

    public static void TestWspolne(Wspolne wspolneObiekt, int[] x, int[] y)
    {
        try
        {
            List<int> wspolneElementy = wspolneObiekt.wspolne(x, y);
            Console.WriteLine($"Wspólna część multizbiorów [{string.Join(", ", x)}], [{string.Join(", ", y)}] wynosi: [{string.Join(", ", wspolneElementy)}]");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Błąd dla multizbiorów [{string.Join(", ", x)}], [{string.Join(", ", y)}]: {e.Message}");
        }
    }
    // funkcja do zwracania wspólnej części dwóch multizbiorów
    public List<int> wspolne(int[] x, int[] y){
        if (x.Length == 0 || y.Length == 0){
            throw new ArgumentException("Multizbiory nie mogą być zbiorami pustymi!");
        }
        else{
            List<int> wspolneElementy = new List<int>();

            // posortowanie elementów w tablicy, aby łatwiej można było sprawdzić, czy są jednakowe elemnty w zbiorach
            Array.Sort(x);
            Array.Sort(y);

            foreach(int elementA in x){
                if(y.Contains(elementA)==true){
                    wspolneElementy.Add(elementA);
                }
            }
            return wspolneElementy;
        }
    }

}
