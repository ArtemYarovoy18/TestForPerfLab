//обработка команд
using System.Collections;
using System.Collections.Generic;

string comand = Console.ReadLine();
string[] comandMas= comand.Split(' ');
Random rnd = new Random();
List<List<string>> listKartIgrokov = new List<List<string>>();
List<string> kartiIgroka = new List<string>();

switch (comandMas[0])
{
    case "start":   //start N C где N-коль-во карт C-коль-во игроков
        //подготовка колоды
        var koloda = new List<string>();
        var cvet = new List<string> {"R","G","B","W"};
        var a = 0;
        var nomKart = 0;
        foreach (var element in cvet)
        {
            for (int i = 1; i <= 10; i++)
            {
                koloda.Add(element + i);
                a++;
            }
        }
      koloda.ForEach(Console.WriteLine);



        if (Convert.ToInt32(comandMas[1])* Convert.ToInt32(comandMas[2]) > koloda.Count)
        { 
            Console.WriteLine("колоды в 40 карт нехватает. Введите корректную команду!!!");
            break;
        }
        else
        {

            for (int i = 0; i < Convert.ToInt32(comandMas[2]); i++) //по игрокам
            {
                for (int j = 0; j < Convert.ToInt32(comandMas[1]); j++)//раздаю карты
                {
                    nomKart = rnd.Next(koloda.Count);
                    kartiIgroka.Add(koloda[nomKart]);
                    koloda.RemoveAt(nomKart);
                }
                
                
                
                listKartIgrokov.Add(kartiIgroka);
              //  kartiIgroka.ForEach(Console.Write);
                //Console.WriteLine();
                kartiIgroka.Clear();
            }
            Console.WriteLine("sfgergweeg   "+listKartIgrokov.Count);
            Console.WriteLine("sfgergweqfveeg   " + listKartIgrokov[1]);

            foreach (var list in listKartIgrokov)
            {
                Console.WriteLine(String.Join(", ", list));
            }
        }
        break;




    case "get-cards":
        Console.WriteLine("Ваше имя - Tom");
        break;
}