using System;
using System.Collections.Generic;
using System.Text;
using GladiatorGame;
using System.IO;


// create game reports

namespace GladiatorGame
{
    class report
    {            
        String fileName = @"C:\users\lohta\desktop\Gladiator.txt";
        public void CreateReport(List<String> Slaughtered,string name, int points)
        {


            using (StreamWriter fs = new StreamWriter(fileName, true))
            {
                fs.Write(DateTime.Now + "\n");
                fs.Write($"Gladiator name: {name}\n");
                fs.Write($"You earned: {points} points\n");
                fs.WriteLine("");
                fs.WriteLine("Enemys slaughtered: \n");
                foreach (var item in Slaughtered)
                {
                    fs.WriteLine(item);
                }
                fs.WriteLine("");
            }
        }

        public void DeleteSaves()
        {
            File.WriteAllText(fileName, String.Empty);
        }

    }
}
