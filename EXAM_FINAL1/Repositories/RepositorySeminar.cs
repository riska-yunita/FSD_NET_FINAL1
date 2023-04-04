using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_FINAL1.Repositories;

public class RepositorySeminar : Interfaces.ISeminar
{
    static string ConnectionString = "Data Source=DESKTOP-1O93DB4\\MSSQLSERVER01;Database=db_seminar;Integrated Security=True;Connect Timeout=30;";
    static SqlConnection connection;
    public void GetAllSeminar()
    {
        connection = new SqlConnection(ConnectionString);

        //Membuat instance untuk command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_seminar";

        //Membuka koneksi
        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id\t\t\t: " + reader[0]);
                Console.WriteLine("Name\t\t\t: " + reader[1]);
                Console.WriteLine("Benefit\t\t\t: " + reader[2]);
                Console.WriteLine("Pembicara\t\t: " + reader[3]);
                Console.WriteLine("Tanggal Pelaksanaan\t: " + reader[4]);
                Console.WriteLine("Jam\t\t\t: " + reader[5] + " s/d " + reader[6]);
                Console.WriteLine("Harga\t\t\t: " + reader[7]);

                int harga = Convert.ToInt32(reader[7]);
                int isPromo = Convert.ToInt32(reader[8]);
                if (isPromo == 1)
                {
                    Console.WriteLine("Diskon 10%\t\t: " + (harga * 10 / 100));
                }
                else
                {
                    Console.WriteLine("Harga Normal");
                }
                Console.WriteLine("Total Harga\t\t: " + reader[9]);
                Console.WriteLine("==========================================================================");
            }
        }
        else
        {
            Console.WriteLine("Data not found!");
        }
        reader.Close();

        //Menutup koneksi
        connection.Close();
    }

    public void GetById(int id)
    {
        Console.Clear();
        connection = new SqlConnection(ConnectionString);

        //Membuat instance untuk command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_seminar Where id = @id";

        //Membuka koneksi
        connection.Open();

        //Membuat parameter
        SqlParameter pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.Value = id;
        pId.SqlDbType = SqlDbType.VarChar;

        //Menambahkan data parameter
        command.Parameters.Add(pId);

        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id\t\t\t: " + reader[0]);
                Console.WriteLine("Name\t\t\t: " + reader[1]);
                Console.WriteLine("Benefit\t\t\t: " + reader[2]);
                Console.WriteLine("Pembicara\t\t: " + reader[3]);
                Console.WriteLine("Tanggal Pelaksanaan\t: " + reader[4]);
                Console.WriteLine("Jam\t\t\t: " + reader[5] + " s/d " + reader[6]);
                Console.WriteLine("Harga\t\t\t: " + reader[7]);

                int harga = Convert.ToInt32(reader[7]);
                int isPromo = Convert.ToInt32(reader[8]);
                if (isPromo == 1)
                {
                    Console.WriteLine("Diskon 10%\t\t: " + (harga * 10 / 100));
                }
                else
                {
                    Console.WriteLine("Harga Normal");
                }
                Console.WriteLine("Total Harga\t\t: " + reader[9]);
                Console.WriteLine("==========================================================================");
            }
        }
        else
        {
            Console.WriteLine("Data not found!");
        }
        reader.Close();

        //Menutup koneksi
        connection.Close();
    }

    public void DeleteSeminar()
    {
        Console.WriteLine("Masukkan Id : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Clear();
        connection = new SqlConnection(ConnectionString);

        //Membuka koneksi
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            //Membuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM tbl_seminar WHERE id = @id ";
            command.Transaction = transaction;

            //Membuat parameter id
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.VarChar;

            //Menambahkan parameter ke command
            command.Parameters.Add(pId);

            //Menjalankan command
            int result = command.ExecuteNonQuery();
            transaction.Commit();

            if (result > 0)
            {
                Console.WriteLine("Data berhasil dihapus!");
            }
            else
            {
                Console.WriteLine("Data gagal dihapus!");
            }

            //Menutup koneksi
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }
    }

    public void InsertSeminar()
    {
        connection = new SqlConnection(ConnectionString);

        //Membuka koneksi
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            //Membuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO tbl_seminar (name, benefit, pembicara, tgl_acara, jam_mulai, jam_akhir, harga, ispromo, total_harga) VALUES (@name, @benefit, @pembicara, @tgl_acara, @jam_mulai, @jam_akhir, @harga, @ispromo, @total_harga)";
            command.Transaction = transaction;

            //Membuat parameter
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            Console.Write("Masukkan Judul Seminar : ");
            String Name = Console.ReadLine();
            pName.Value = Name;
            pName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pBenefit = new SqlParameter();
            pBenefit.ParameterName = "@benefit";
            Console.Write("Masukkan Benefit Seminar : ");
            String Benefit = Console.ReadLine();
            pBenefit.Value = Benefit;
            pBenefit.SqlDbType = SqlDbType.VarChar;

            SqlParameter pPembicara = new SqlParameter();
            pPembicara.ParameterName = "@pembicara";
            Console.Write("Masukkan Nama Pembicara Seminar : ");
            String Pembicara = Console.ReadLine();
            pPembicara.Value = Pembicara;
            pPembicara.SqlDbType = SqlDbType.VarChar;

            SqlParameter pTgl = new SqlParameter();
            pTgl.ParameterName = "@tgl_acara";
            Console.Write("Masukkan Tanggal Acara Seminar : ");
            String Tgl_Acara = Console.ReadLine();
            pTgl.Value = Tgl_Acara;
            pTgl.SqlDbType = SqlDbType.VarChar;

            SqlParameter pStart = new SqlParameter();
            pStart.ParameterName = "@jam_mulai";
            Console.Write("Masukkan Jam Mulai Seminar : ");
            String Jam_Mulai = Console.ReadLine();
            pStart.Value = Jam_Mulai;
            pStart.SqlDbType = SqlDbType.VarChar;

            SqlParameter pEnd = new SqlParameter();
            pEnd.ParameterName = "@jam_akhir";
            Console.Write("Masukkan Jam Berakhir Seminar : ");
            String Jam_Akhir = Console.ReadLine();
            pEnd.Value = Jam_Akhir;
            pEnd.SqlDbType = SqlDbType.VarChar;

            SqlParameter pHarga = new SqlParameter();
            pHarga.ParameterName = "@harga";
            Console.Write("Masukkan Biaya Seminar : ");
            int Harga = int.Parse(Console.ReadLine());
            pHarga.Value = Harga;
            pHarga.SqlDbType = SqlDbType.VarChar;

            SqlParameter pIsPromo = new SqlParameter();
            pIsPromo.ParameterName = "@ispromo";
            Console.Write("1 (Harga Promo)\n0 (Harga Normal)\t: ");
            String isPromo = Console.ReadLine();
            pIsPromo.Value = isPromo;
            pIsPromo.SqlDbType = SqlDbType.VarChar;

            SqlParameter pTotal_Harga = new SqlParameter();
            pTotal_Harga.ParameterName = "@total_harga";
            pTotal_Harga.SqlDbType = SqlDbType.VarChar;
            if (isPromo == "1")
            {
                int Total_Harga = Harga - (Harga * 10 / 100);
                pTotal_Harga.Value = Total_Harga;
            }
            else
            {
                int Total_Harga = Harga;
                pTotal_Harga.Value = Total_Harga;
            }
            

            //Menambahkan parameter ke command
            command.Parameters.Add(pName);
            command.Parameters.Add(pBenefit);
            command.Parameters.Add(pPembicara);
            command.Parameters.Add(pTgl);
            command.Parameters.Add(pStart);
            command.Parameters.Add(pEnd);
            command.Parameters.Add(pHarga);
            command.Parameters.Add(pIsPromo);
            command.Parameters.Add(pTotal_Harga);
            //Menjalankan command
            int result = command.ExecuteNonQuery();
            transaction.Commit();

            if (result > 0)
            {
                Console.WriteLine("Data berhasil ditambahkan!");
            }
            else
            {
                Console.WriteLine("Data gagal ditambahkan!");
            }

            //Menutup koneksi
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }
    }

    public void UpdateSeminar()
    {
        connection = new SqlConnection(ConnectionString);

        //Membuka koneksi
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            //Membuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE tbl_seminar SET name = @name, benefit=@benefit, pembicara=@pembicara, tgl_acara = @tgl_acara, jam_mulai=@jam_mulai, jam_akhir=@jam_akhir, harga= @harga, ispromo=@ispromo, total_harga=@total_harga WHERE id = @id ";
            command.Transaction = transaction;

            //Membuat parameter id
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            Console.Write("Masukkan Id : ");
            int Id = Convert.ToInt32(Console.ReadLine());
            pId.Value = Id;
            pId.SqlDbType = SqlDbType.VarChar;
            
            GetById(Id);

            //Membuat parameter
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            Console.Write("Masukkan Judul Seminar : ");
            String Name = Console.ReadLine();
            pName.Value = Name;
            pName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pBenefit = new SqlParameter();
            pBenefit.ParameterName = "@benefit";
            Console.Write("Masukkan Benefit Seminar : ");
            String Benefit = Console.ReadLine();
            pBenefit.Value = Benefit;
            pBenefit.SqlDbType = SqlDbType.VarChar;

            SqlParameter pPembicara = new SqlParameter();
            pPembicara.ParameterName = "@pembicara";
            Console.Write("Masukkan Nama Pembicara Seminar : ");
            String Pembicara = Console.ReadLine();
            pPembicara.Value = Pembicara;
            pPembicara.SqlDbType = SqlDbType.VarChar;

            SqlParameter pTgl = new SqlParameter();
            pTgl.ParameterName = "@tgl_acara";
            Console.Write("Masukkan Tanggal Acara Seminar : ");
            String Tgl_Acara = Console.ReadLine();
            pTgl.Value = Tgl_Acara;
            pTgl.SqlDbType = SqlDbType.VarChar;

            SqlParameter pStart = new SqlParameter();
            pStart.ParameterName = "@jam_mulai";
            Console.Write("Masukkan Jam Mulai Seminar : ");
            String Jam_Mulai = Console.ReadLine();
            pStart.Value = Jam_Mulai;
            pStart.SqlDbType = SqlDbType.VarChar;

            SqlParameter pEnd = new SqlParameter();
            pEnd.ParameterName = "@jam_akhir";
            Console.Write("Masukkan Jam Berakhir Seminar : ");
            String Jam_Akhir = Console.ReadLine();
            pEnd.Value = Jam_Akhir;
            pEnd.SqlDbType = SqlDbType.VarChar;

            SqlParameter pHarga = new SqlParameter();
            pHarga.ParameterName = "@harga";
            Console.Write("Masukkan Biaya Seminar : ");
            int Harga = int.Parse(Console.ReadLine());
            pHarga.Value = Harga;
            pHarga.SqlDbType = SqlDbType.VarChar;

            SqlParameter pIsPromo = new SqlParameter();
            pIsPromo.ParameterName = "@ispromo";
            Console.Write("1 (Harga Promo)\n0 (Harga Normal)\t: ");
            String isPromo = Console.ReadLine();
            pIsPromo.Value = isPromo;
            pIsPromo.SqlDbType = SqlDbType.VarChar;

            SqlParameter pTotal_Harga = new SqlParameter();
            pTotal_Harga.ParameterName = "@total_harga";
            pTotal_Harga.SqlDbType = SqlDbType.VarChar;
            if (isPromo == "1")
            {
                int Total_Harga = Harga - (Harga * 10 / 100);
                pTotal_Harga.Value = Total_Harga;
            }
            else
            {
                int Total_Harga = Harga;
                pTotal_Harga.Value = Total_Harga;
            }

            //Menambahkan parameter ke command
            command.Parameters.Add(pId);
            command.Parameters.Add(pName);
            command.Parameters.Add(pBenefit);
            command.Parameters.Add(pPembicara);
            command.Parameters.Add(pTgl);
            command.Parameters.Add(pStart);
            command.Parameters.Add(pEnd);
            command.Parameters.Add(pHarga);
            command.Parameters.Add(pIsPromo);
            command.Parameters.Add(pTotal_Harga);

            //Menjalankan command
            int result = command.ExecuteNonQuery();
            transaction.Commit();

            if (result > 0)
            {
                Console.WriteLine("Data berhasil diubah!");
            }
            else
            {
                Console.WriteLine("Data gagal diubah!");
            }

            //Menutup koneksi
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }
    }
}
