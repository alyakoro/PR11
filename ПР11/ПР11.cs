
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ПР11
{
    public struct Work
    {
        public int kod; //код сотрудника
        public double zarabotok; //заработок сотрудника
        public string name; //имя сотрудника
        public string surname; //фамилия сотрудника 
    }


    class ПР11
    {
        enum Name { Иван, Петр, Ирина, Ольга, Ян, Света }
        enum Surname { Сидоров, Андреев, Иванова, Выходова, Юрин, Абрамович }
        enum Telofone { тел3453212, тел453212, тел4532312, тел444, тел3421232, тел3432124}
        private static Type t1 = typeof(Name);
        private static Type t2 = typeof(Surname);
        private static Type t3 = typeof(Telofone);

        static void Main(string[] args)
        {
            int k = 0;
            Work[] w = new Work[6];
            Name[] names;
            names = Enum.GetValues(typeof(Name)).Cast<Name>().ToArray();
            Surname[] surnames;
            surnames = Enum.GetValues(typeof(Surname)).Cast<Surname>().ToArray();
            Telofone[] telofones;
            telofones = Enum.GetValues(typeof(Telofone)).Cast<Telofone>().ToArray();

            Random r = new Random();
            List<string> surname_A = new List<string>();
            String reg = @"...\d{7}";
            String reg_2 = @"[А]";
            
            for (int i = 0; i < w.Length; i++)
            {
                //сравнение телефона определенного сотрудника
                //с регулярным выражением reg ( 3 буквы и 7 цифр )
                string tel = "\nТелефон не верный: ";
                if (Regex.IsMatch(Convert.ToString(telofones[i]), reg)) tel = "\nТелефон: ";

                w[i].kod = i;
                w[i].zarabotok = r.Next(16000, 30000);

                //Сравнение заработной платы с прожиточным минимумом и замена текста
                string zar = "\nЗаработная плата: ";
                if (w[i].zarabotok < 20000) zar = "\nЗаработная плата меньше " +
                        "прожиточного минимума: ";

                //Вывод всей информации
                Console.WriteLine("\nКод сотрудника № " + (i + 1) + 
                    "\nИмя: " + names[i] + 
                    "\nФамилия: " + surnames[i] + 
                     zar + w[i].zarabotok + 
                     tel + telofones[i]);

                //Сравненеи фамилии определенного сотрудника
                //с регулярным выражением reg_2 (Начало фамилии на А)
                if (Regex.IsMatch(Convert.ToString(surnames[i]), reg_2)) 
                    surname_A.Add(Convert.ToString(surnames[i]));
            }
            //Вывод фамилий, что начинаются на А
            foreach (string s in surname_A) Console.WriteLine("\nФамилии на 'А': " + s);
            Console.ReadLine();
        }
    }
}
