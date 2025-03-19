/* Author: Oliwia Zielińska
Linki, z których korzystano podczas realizacji zadania:
PROBLEM COLLATZA: https://pl.wikipedia.org/wiki/Problem_Collatza
LISTY W C#: https://learn.microsoft.com/pl-pl/dotnet/csharp/tour-of-csharp/tutorials/list-collection
*/
using System;
using System.Net;

class Collatz{

    public static void Main(string[] args){
        Collatz collatz = new Collatz();
        
        // poprawne działanie
        TestCollatz(collatz, 5);
        TestCollatz(collatz, 11);
        TestCollatz(collatz, 52);
        TestCollatz(collatz, 100);
        TestCollatz(collatz, 500);
        TestCollatz(collatz, 1245);

        // wyrzucenie błędu
        TestCollatz(collatz, 0);
        TestCollatz(collatz, -7);
    }
    // funkcja testująca
    public static void TestCollatz(Collatz collatz, int c0){
        try{
            List<int> ciag = collatz.collatz(c0);
            Console.WriteLine($"Ciąg o długości: {ciag.Count}, max wartość elementu: {ciag.Max()} dla c0={c0}: [{string.Join(", ", ciag)}]");
        } catch (ArgumentException e){
            Console.WriteLine($"Wartość {c0} spowoduje pojawienie się błędu: + {e.Message}");
        }
    }
    // funkcja collatz
    public List<int> collatz(int c0){
        if (c0 <= 0){
            throw new ArgumentException("C0 musi być liczbą naturalną!");
        }
        else {
            List<int> elementyCiagu = new List<int>();
            elementyCiagu.Add(c0);
             while (c0 != 1){
                // c0 parzyste
                if (c0 % 2 == 0)
                {
                    c0 /= 2;
                } else  // c0 nieparzyste
                {
                    c0 = 3 * c0 + 1;
                }
                elementyCiagu.Add(c0);
            }
            return elementyCiagu;
        }
    }
}
