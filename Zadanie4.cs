/* Author: Oliwia Zielińska
Linki, z których korzystano podczas realizacji zadania:
CIĄG FIBONACCIEGO: https://pl.wikipedia.org/wiki/Ci%C4%85g_Fibonacciego
TWORZENIE KLAS W C#: https://www.plukasiewicz.net/CSharp_dla_poczatkujacych/Klasy
KOLEKCJE W C#: https://www.plukasiewicz.net/Csharp_dla_zaawansowanych/Kolekcje
*/
using System;


class Fibonacci
{
    public static void Main(string[] args){
        Fibonacci fibonacci = new Fibonacci();
        Console.WriteLine("N pierwszych elementów ciągu Fibonacciego obliczonych ITERACYJNIE!");

        // poprawne działanie funkcji ciagFibonacciego
        TestCiagu(fibonacci, 10);

        // sprawdzenie wartości brzegowych
        TestCiagu(fibonacci, 1);
        TestCiagu(fibonacci, 0);
        
        // wyrzucenie błędu
        TestCiagu(fibonacci, -1);

         Console.WriteLine("N pierwszych elementów ciągu Fibonacciego obliczonych REKURENCYJNIE!");

        // poprawne działanie funkcji ciagFibonacciego
        TestCiaguRekurencja(fibonacci, 10);

        // sprawdzenie wartości brzegowych
        TestCiaguRekurencja(fibonacci, 1);
        TestCiaguRekurencja(fibonacci, 0);
        
        // wyrzucenie błędu
        TestCiaguRekurencja(fibonacci, -1);
    }

    // PODPUNKT A - ITERACJA
    public static void TestCiagu(Fibonacci fibonacci, int n){
        try{
            List<int> ciag = fibonacci.ciagFibonacciego(n);
            Console.WriteLine($"{n} pierwszych elementów ciągu Fibonacciego wynosi: [{string.Join(", ", ciag)}]");
        } catch (ArgumentException e){
            Console.WriteLine($"Wartość {n} spowoduje pojawienie się błędu: + {e.Message}");
        }
    }
    public List<int> ciagFibonacciego(int n){
        List<int> ciagnElementów = new List<int>();
        if (n<0){
            throw new ArgumentException("Nie da się wypisać n-kolejnych wyrazów ciągu, gdy n < 0!");
        }
        else {
            for (int i=0; i <= n; i++){
                if (i == 0){
                    ciagnElementów.Add(0);
                }
                else if (i == 1){
                    ciagnElementów.Add(1);
                }
                else{
                    ciagnElementów.Add(ciagnElementów[i-2]+ciagnElementów[i-1]);
                }
            }
            return ciagnElementów;
        }
    }

    // PODPUNKT B - REKURENCJA
    public static void TestCiaguRekurencja(Fibonacci fibonacci, int n){
        try{
            List<int> ciagRekurencja = fibonacci.ciagFibonacciegoRek(n);
            Console.WriteLine($"{n} pierwszych elementów ciągu Fibonacciego wynosi: [{string.Join(", ", ciagRekurencja)}]");
        } catch (ArgumentException e){
            Console.WriteLine($"Wartość {n} spowoduje pojawienie się błędu: + {e.Message}");
        }
    }
    public List<int> ciagFibonacciegoRek(int n){
        if (n<0){
            throw new ArgumentException("Nie można wypisać n-kolejnych wyrazów ciągu, gdy n < 0!");
        }
        else {
            List<int> ciagnRekurencja = new List<int>();
            for (int i=0; i<=n; i++){
                ciagnRekurencja.Add(ciagFibonacciegoRekurencja(i));
            }
            return ciagnRekurencja;
        }
    }
    private int ciagFibonacciegoRekurencja(int n){
        if (n==0){
            return 0;
        }
        else if (n==1){
            return 1;
        }
        else{
            return ciagFibonacciegoRekurencja(n-2) + ciagFibonacciegoRekurencja(n-1);
        }
    }
}
