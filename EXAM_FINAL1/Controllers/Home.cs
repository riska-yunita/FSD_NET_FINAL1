using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXAM_FINAL1.Views;

namespace EXAM_FINAL1.Controllers;

public class Home
{
    public void MenuHome()
    {
        char select = 'Y';
        do
        {
            Console.Clear();
            Console.WriteLine("== SISTEM PENGELOLAAN DATA SEMINAR ==");
            Console.WriteLine("\t1. Kelola Data Seminar");
            Console.WriteLine("\t2. Kelola Data Peserta");
            Console.WriteLine("\t3. Kelola Data Pendaftaran Seminar");
            Console.WriteLine();

            Console.Write("Input : ");
            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                Console.Clear();
                SeminarView.Home();
                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 2)
            {
                Console.Clear();
                PesertaView.Home();

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 3)
            {
                Console.Clear();
                TransaksiView.Home();

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Input yang anda masukkan salah");

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
        } while (select == 'Y' || select == 'y');
    }
}
