using EXAM_FINAL1.Controllers;
using EXAM_FINAL1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_FINAL1.Views;

public static class PesertaView
{
    public static void Home()
    {
        Home menu = new Home();
        RepositoryPeserta repositoryPeserta = new RepositoryPeserta();  

        char select = 'Y';
        do
        {
            Console.Clear();
            Console.WriteLine("== Kelola Data Peserta ==");
            Console.WriteLine("\t1. Lihat Semua Data Peserta");
            Console.WriteLine("\t2. Lihat Data Peserta Berdasarkan ID");
            Console.WriteLine("\t3. Tambahkan Data Peserta");
            Console.WriteLine("\t4. Ubah Data Peserta");
            Console.WriteLine("\t5. Hapus Data Peserta");
            Console.WriteLine("\t6. Kembali Ke Halaman Utama");
            Console.WriteLine();

            Console.Write("Input : ");
            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                Console.Clear();
                repositoryPeserta.GetAllPeserta();

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 2)
            {
                Console.Clear();
                Console.WriteLine("Masukkan Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                repositoryPeserta.GetById(id);

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 3)
            {
                Console.Clear();
                repositoryPeserta.InsertPeserta();

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 4)
            {
                Console.Clear();
                repositoryPeserta.UpdatePeserta();

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 5)
            {
                Console.Clear();
                repositoryPeserta.DeletePeserta();

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 6)
            {
                Console.Clear();
                menu.MenuHome();

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
