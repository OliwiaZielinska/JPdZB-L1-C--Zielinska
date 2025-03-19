/* Author: Oliwia Zielińska
Linki, z których korzystano podczas realizacji zadania:
STRING W C#: https://4programmers.net/C_sharp/Wprowadzenie/Rozdzia%C5%82_9
LISTY W C#: https://learn.microsoft.com/pl-pl/dotnet/csharp/tour-of-csharp/tutorials/list-collection
SŁOWNIK W C#: https://learn.microsoft.com/pl-pl/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer
KODONY: https://pl.wikipedia.org/wiki/Kodon
TABELA Z BIAŁKAMI: https://zpe.gov.pl/a/przeczytaj/DvjLxZDbh
*/
using System;
using System.Collections.Generic;
using System.Linq;

class Gen
{
    public static void Main (string[] args){
        Gen gen = new Gen();

        // przetestowanie działania funkcji komplement
        Test(gen, "AATTcccggg");
        Test(gen, "AATTCCGG");
        Test(gen, "ATGGCCTTTAAG");
        Test(gen, "");
    }

    public static void Test(Gen gen, string nicKodujaca){
        try{
            Console.WriteLine($"Nić kodująca DNA (5' - 3'): {nicKodujaca}" + 
            "\n" + $"Nić matrycowa DNA (3' - 5'): {string.Join(", ", gen.komplement(nicKodujaca))}" +
            "\n" + $"Nić mRNA (5' - 3'): {string.Join(", ", gen.transkrybuj(gen.komplement(nicKodujaca)))}" +
            "\n" + $"Sekwencja białek: {string.Join(", ", gen.transluj(gen.transkrybuj(gen.komplement(nicKodujaca))))}");
        }
        catch(ArgumentException e){
            Console.WriteLine($"Błąd: {e.Message}");   
        }
    }
    // dla sekwencji nici kodującej DNA znajduje i zwraca sekwencję nici matrycowej

    public string komplement(string nicKodujacaPodana){
        string nicKodujaca = nicKodujacaPodana.ToUpper();
        string zasadyDNA = "ATCG";
        if(nicKodujaca.Length==0){
            throw new ArgumentException("Nie podano nici kodującej!");
        } else if (nicKodujaca.All(c=>zasadyDNA.Contains(c))){
            List<char> nicMatrycowa = new List<char>();
            foreach(char zasada in nicKodujaca){
                if(zasada == 'A'){
                    nicMatrycowa.Add('T');
                } else if(zasada == 'T'){
                    nicMatrycowa.Add('A');
                } else if(zasada == 'C'){
                    nicMatrycowa.Add('G');
                } else {
                    nicMatrycowa.Add('C');
                }
            } return new string(nicMatrycowa.ToArray());
        } else{
            throw new ArgumentException("Podana nic nie jest kodującą nicią DNA!");
        }
    }

    // dla sekwencji nici matrycowej DNA znajduje i zwraca sekwencję RNA
    public string transkrybuj(string nicMatrycowaPodana){
        string nicMatrycowa = nicMatrycowaPodana.ToUpper();
        string zasadyDNA = "ATCG";
        if(nicMatrycowa.Length==0){
            throw new ArgumentException("Nie podano nici matrycowej DNA!");
        } else if (nicMatrycowa.All(c=>zasadyDNA.Contains(c))){
            List<char> sekwencjaRNA = new List<char>();
            foreach(char zasada in nicMatrycowa){
                if(zasada == 'A'){
                    sekwencjaRNA.Add('U');
                } else if(zasada == 'T'){
                    sekwencjaRNA.Add('A');
                } else if(zasada == 'C'){
                    sekwencjaRNA.Add('G');
                } else {
                    sekwencjaRNA.Add('C');
                }
            } return new string(sekwencjaRNA.ToArray());
        } else{
            throw new ArgumentException("Podana nic nie jest matrycową nicią DNA!");
        }
    }

    // dla sekwencji mRNA znajduje i zwraca sekwencję kodowanego białka
    public string transluj(string mRNAPodane){
        Dictionary<string, string> kodonDoAminokwasu = new Dictionary<string, string>
        {
            { "AUG", "Met" }, // Start
            { "UUU", "Phe" }, { "UUC", "Phe" },
            { "UUA", "Leu" }, { "UUG", "Leu" }, { "CUU", "Leu" },{ "CUC", "Leu" },{ "CUA", "Leu" },{ "CUG", "Leu" },
            { "AUU", "Ile" }, { "AUC", "Ile" }, { "AUA", "Ile" },
            { "GUU", "Val" }, { "GUC", "Val" }, { "GUA", "Val" }, { "GUG", "Val" },
            { "UCU", "Ser" }, { "UCC", "Ser" }, { "UCA", "Ser" }, { "UCG", "Ser" },
            { "CCU", "Pro" }, { "CCC", "Pro" }, { "CCA", "Pro" }, { "CCG", "Pro" },
            { "ACU", "Thr" }, { "ACC", "Thr" }, { "ACA", "Thr" }, { "ACG", "Thr" },
            { "GCC", "Ala" }, { "GCU", "Ala" }, { "GCA", "Ala" }, { "GCG", "Ala" },
            { "UAU", "Tyr" }, { "UAC", "Tyr" },
            { "UAA", "Stop" }, { "UAG", "Stop" }, { "UGA", "Stop" },
            { "CAU", "His" }, { "CAC", "His" },
            { "CAA", "Gln" }, { "CAG", "Gln" },
            { "AAU", "Asn" }, { "AAC", "Asn" },
            { "AAA", "Lys" }, { "AAG", "Lys" },
            { "GAU", "Asp" }, { "GAC", "Asp" },
            { "GAA", "Glu" }, { "GAG", "Glu" },
            { "UGU", "Cys" }, { "UGC", "Cys" },
            { "UGG", "Trp" },
            { "CGU", "Arg" }, { "CGC", "Arg" }, { "CGA", "Arg" }, { "CGG", "Arg" }, { "AGA", "Arg" }, { "AGG", "Arg" },
            { "AGU", "Ser" }, { "AGC", "Ser" },
            { "GGU", "Gly" }, { "GGC", "Gly" }, { "GGA", "Gly" }, { "GGG", "Gly" },
        };
        string mRNA = mRNAPodane.ToUpper();
        string zasadyRNA = "AUCG";
        if(mRNA.Length==0){
            throw new ArgumentException("Nie podano sekwencji mRNA!");
        } else if (mRNA.All(c=>zasadyRNA.Contains(c))){
            string bialko = "";
            bool tlumaczenieRozpoczete = false;

            for (int i = 0; i < mRNA.Length - 2; i += 3)
            {
                string kodon = mRNA.Substring(i, 3);
                if (kodonDoAminokwasu.ContainsKey(kodon))
                {
                    if (kodon == "AUG")
                        tlumaczenieRozpoczete = true;
                
                    if (tlumaczenieRozpoczete)
                    {
                        if (kodonDoAminokwasu[kodon] == "Stop")
                            break;
                    
                        bialko += kodonDoAminokwasu[kodon] + "-";
                    }
                }
            }
            return bialko.TrimEnd('-');
        } else{
            throw new ArgumentException("Podana nic nie jest sekwencją mRNA!");
        }
    }
}