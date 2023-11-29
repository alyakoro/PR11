using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР11_2
{
    public struct Work
    {
        public string work; //поля фамилии и имя
        public string dolgost; //полу должности
        public uint oklad; //поле оклада
        public string kod; //поле код
    }
    internal class Program
    {
        static void Main()
        {
            ArrayList work = new ArrayList();
            work.AddRange(new string[] { "Иван Сидоров", "Петр Андреев", "Ирина Иванова", "Ольга Выходова", "Ян Юрин" });
            ArrayList dolgost = new ArrayList();
            dolgost.AddRange(new string[] { "повар", "кондитер", "пекарь", "тестомес", "кондитер" });
            ArrayList oklad = new ArrayList();
            oklad.AddRange(new uint[] { 25000, 12464, 35654, 34231, 20453 });
            ArrayList kod = new ArrayList();
            kod.AddRange(new string[] { "СИ001", "АП002", "ИИ003", "ВО004", "ЮЯ005" });

            //
            Console.Write("Текущее содержание списка сотрудников: \n\n");
            for (int i = 0; i < work.Count; i++) Console.Write(kod[i] + " " +
                work[i] + " " + dolgost[i] + " " + oklad[i] + " руб/месяц\n");
            //
            Console.WriteLine("\nСписок сотрудников по алфавиту");
            foreach (object w in work) Console.WriteLine(w);

            string ex = "";
            while(ex != "exit")
            {
                Console.WriteLine("\n1. Добавить сотрудника \n2. Уволить сотрудника:");
                int kk = Convert.ToInt16(Console.ReadLine());
                if (kk == 1)
                {
                    Console.Write("Введите имя и фамилию сотрудника: ");
                    work.Add(Console.ReadLine());
                    Console.Write("Введите должность сотрудника: ");
                    dolgost.Add(Console.ReadLine());
                    Console.Write("Введите оклад сотрудника: ");
                    oklad.Add(Console.ReadLine());
                    Console.Write("Введите код сотрудника: ");
                    kod.Add(Console.ReadLine());

                }
                else if (kk == 2)
                {
                    int un = 0;
                    Console.WriteLine("\nВведите код уволенного сотрудника: ");
                    string k = Console.ReadLine();
                    for (int i = 0; i < kod.Count; i++)
                    {
                        if (k == Convert.ToString(kod[i]))
                        {
                            un = kod.IndexOf(k);
                            Console.WriteLine("\nСотрудник уволен: " + work[un] + " " + kod[un] + "\n");
                            kod.RemoveAt(un);
                            work.RemoveAt(un);
                            dolgost.RemoveAt(un);
                            oklad.RemoveAt(un);
                        }
                    }
                }
                else Console.WriteLine("\nВведите повторно!");
            

            Console.Write("\nСодержимое с изменениями\n");
            for (int j = 0; j < kod.Count; j++) Console.WriteLine(kod[j] + " " + work[j] +
                " " + dolgost[j] + " " + oklad[j] + " руб/месяц");
            Console.Write("\nДля выхода, введите exit: ");
            ex = Console.ReadLine();
            }
        }
    }
}
