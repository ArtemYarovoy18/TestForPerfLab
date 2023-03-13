//обработка команд
using System.Collections;
using System.Collections.Generic;

Random rnd = new Random();
List<List<string>> listKartIgrokov = new List<List<string>>();

while (true)
{
    string comand = Console.ReadLine();
    string[] comandMas = comand.Split(' ');
    switch (comandMas[0])
    {
        case "start":   //start N C где N-коль-во карт C-коль-во игроков
                        //подготовка колоды
            var koloda = new List<string>();
            var cvet = new List<string> { "R", "G", "B", "W" };
            var a = 0;
            var nomKart = 0;
            listKartIgrokov.Clear();
            foreach (var element in cvet)
            {
                for (int i = 1; i <= 10; i++)
                {
                    koloda.Add(element + i);
                    a++;
                }
            }
            // koloda.ForEach(Console.WriteLine);
            if (Convert.ToInt32(comandMas[1]) * Convert.ToInt32(comandMas[2]) > koloda.Count)
            {
                Console.WriteLine("колоды в 40 карт нехватает. Введите корректную команду!!!");
                break;
            }
            else
            {
                for (int с = 0; с < Convert.ToInt32(comandMas[2]); с++) //по игрокам
                {
                    List<string> kartiIgroka = new List<string>();
                    for (int n = 0; n < Convert.ToInt32(comandMas[1]); n++)//раздаю карты
                    {
                        nomKart = rnd.Next(koloda.Count);
                        kartiIgroka.Add(koloda[nomKart]);
                        koloda.RemoveAt(nomKart);
                    }
                    listKartIgrokov.Add(kartiIgroka);
                }
                /*                foreach (var list in listKartIgrokov)
                                {
                                    Console.WriteLine(String.Join(", ", list));
                                } */
            }
            break;

        case "get-cards":
            if (listKartIgrokov.Count == 0)
            {
                Console.WriteLine("Необходимо раздать карты!!!!");
                break;
            }

            if (Convert.ToInt32(comandMas[1]) > listKartIgrokov.Count)
            {
                Console.WriteLine("Нет такого игрока");
                break;
            }
            else
            {
                Console.WriteLine(comandMas[1] + " " + String.Join(" ", listKartIgrokov[Convert.ToInt32(comandMas[1]) - 1]));
            }
            break;
    }
}