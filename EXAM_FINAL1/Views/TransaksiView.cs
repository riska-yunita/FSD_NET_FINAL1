using EXAM_FINAL1.Controllers;
using EXAM_FINAL1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_FINAL1.Views;

public class TransaksiView
{
    public static void Home()
    {
        Home menu = new Home();
        RepositoryTransaksi repositoryTransaksi = new RepositoryTransaksi();

        char select = 'Y';
        do
        {
            Console.Clear();
            Console.WriteLine("== Kelola Data Pendaftaran Seminar ==");
            Console.WriteLine("\t1. Lihat Semua Daftar Pendaftaran Seminar");
            Console.WriteLine("\t2. Lihat Daftar Pendaftaran Seminar Berdasarkan ID");
            Console.WriteLine("\t3. Tambahkan Data Pendaftaran Seminar");
            Console.WriteLine("\t4. Ubah Data Pendaftaran Seminar");
            Console.WriteLine("\t5. Hapus Data Pendaftaran Seminar");
            Console.WriteLine("\t6. Kembali Ke Halaman Utama");
            Console.WriteLine();

            Console.Write("Input : ");
            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                Console.Clear();
                repositoryTransaksi.GetAllTransaksi();

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 2)
            {
                Console.Clear();
                Console.WriteLine("Masukkan Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                repositoryTransaksi.GetById(id);

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 3)
            {
                Console.Clear();
                repositoryTransaksi.InsertTransaksi();

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 4)
            {
                Console.Clear();
                repositoryTransaksi.UpdateTransaksi();

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 5)
            {
                Console.Clear();
                repositoryTransaksi.DeleteTransaksi();

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
