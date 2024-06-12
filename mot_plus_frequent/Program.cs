using System;
using System.Diagnostics.Tracing;

class Program
{
    public static void Main(string[] args)
    {
        char[] delimiters = new char[] { ' ', ',', '-', '.', '?', '!', '(', ')' };
        Console.Write("veillez rentrer votre paragraphe: ");
        string userEntry1 = Console.ReadLine();
        string[] paragraphe = userEntry1.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        List<string> motsParagraphe = new List<string>(paragraphe);
        Console.Write("veillez rentre vos mots interdits: ");
        string userEntry2 = Console.ReadLine();
        string[] interdits = userEntry2.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        List<string> motsInterdits = new List<string>(interdits);
        //éliminer les mots interdits de la liste motsParagraphe
        foreach (string badword in interdits) 
        {
            foreach (string mot in motsParagraphe)
            {
                motsParagraphe.Remove(badword);
            }
        }
        //créer un dictionaire des { mots : frequence }
        Dictionary<string, int> motsFrequence = new Dictionary<string, int>();

        foreach (string mots in motsParagraphe)
        {
            if (motsFrequence.ContainsKey(mots))
            {
                motsFrequence[mots]++;
            }
            else
            {
                motsFrequence[mots] = 1;
            }
        }
        // ranger le dictionaire 'motsFrequence' du plus à moins frequent
        string lePlusFrequent = motsFrequence.OrderByDescending(x => x.Value).First().Key;
        Console.WriteLine("le mot le plus frequent: " + lePlusFrequent);
    }
}