using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXAM_FINAL1.Controllers;
using EXAM_FINAL1.Repositories;

namespace EXAM_FINAL1.Views;

public static class SeminarView
{
    //Menampilkan data yang didapat dari repository berbentuk console
    public static void Home()
    {
        Home menu = new Home();
        RepositorySeminar repositorySeminar = new RepositorySeminar();

        char select = 'Y';
        do
        {
            Console.Clear();
            Console.WriteLine("== Kelola Data Seminar ==");
            Console.WriteLine("\t1. Lihat Semua Daftar Seminar");
            Console.WriteLine("\t2. Lihat Daftar Seminar Berdasarkan ID");
            Console.WriteLine("\t3. Tambahkan Data Seminar");
            Console.WriteLine("\t4. Ubah Data Seminar");
            Console.WriteLine("\t5. Hapus Data Seminar");
            Console.WriteLine("\t6. Kembali Ke Halaman Utama");
            Console.WriteLine();
            
            Console.Write("Input : ");
            int input = int.Parse(Console.ReadLine());
            
            if (input == 1)
            {
                Console.Clear();
                repositorySeminar.GetAllSeminar();

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 2)
            {
                Console.Clear() ;
                Console.WriteLine("Masukkan Id : ");
                int Id = Convert.ToInt32(Console.ReadLine());
                repositorySeminar.GetById(Id);

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 3)
            {
                Console.Clear();
                repositorySeminar.InsertSeminar();
                
                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 4)
            {
                Console.Clear();
                repositorySeminar.UpdateSeminar();

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 5)
            {
                Console.Clear();
                repositorySeminar.DeleteSeminar();

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
        } while (select == 'Y' || select == 'y') ;
    }
}
