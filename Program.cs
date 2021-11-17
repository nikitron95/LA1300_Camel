using System;
using System.IO;
using static System.Console;

namespace Julians_Hilfe
{
    class Program
    {
        static void Main()
        {
            string inPath = @"..\..\..\Vokabeln.csv";
            string text = File.ReadAllText(inPath);
            string[] lines = text.Split("\r\n");
            int words = lines.Length;
            string[] german = new string[words - 1];
            string[] english = new string[words - 1];

            for (int line = 0; line < lines.Length - 1; line++)
            {
                try
                {
                    string[] items = lines[line].Split(',');
                    english[line] = items[0];
                    german[line] = items[1].Replace("\"", string.Empty); 
                }
                catch
                {

                }
            }

            bool isContinue = false;
            for (int i = 0; i < german.Length; i++)
            {
                if (english[i] == "")
                {
                    Clear();
                }
                else
                {
                    WriteLine("Gib die Überstzung dieses Wortes ein. (Beachte, dass alle Umlaute ae und so weiter geschrieben werden)");
                    WriteLine(english[i]);

                    string Eingabe = ReadLine();

                    if (Eingabe == german[i])
                    {
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine("Richtig");
                        ResetColor();
                        WriteLine("Drücke eine beliebige Taste um fortzufahren.");
                        ReadKey(true);
                    }
                    else if (Eingabe == "")
                    {
                        isContinue = true;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("falsch");
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine("Richtig wäre " + german[i]);
                        ResetColor();
                        WriteLine("Drücke eine beliebige Taste um fortzufahren.");
                        ReadKey(true);
                    }
                    Clear();




                    while (isContinue)
                    {
                        string fud = @"TReffen sie eine auswahl:
    Bestätigen sie ihre auswahl mit den passenden buchstaben
    Wollen sie die LIste erneut lernen [L]
    Wollen sie das Programm beenden? [B]";

                        WriteLine(fud);

                        string answer = Console.ReadLine();

                        switch (answer)
                        {
                            case "L":
                                isContinue = false;
                                Main();
                                break;
                            case "B":
                                Environment.Exit(0);

                                break;
                            case "el oreo":
                                WriteLine("He's hungry and want's some Oreo's");

                                break;
                        }
                    }
                }
            }
        }
    }
}