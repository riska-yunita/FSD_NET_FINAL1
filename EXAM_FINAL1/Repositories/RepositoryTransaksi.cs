using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_FINAL1.Repositories;

public class RepositoryTransaksi:Interfaces.ITransaksi
{
    static string ConnectionString = "Data Source=DESKTOP-1O93DB4\\MSSQLSERVER01;Database=db_seminar;Integrated Security=True;Connect Timeout=30;";
    static SqlConnection connection;

    public  void GetAllTransaksi()
    {
        connection = new SqlConnection(ConnectionString);

        //Membuat instance untuk command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_transaksi";

        //Membuka koneksi
        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id Transaksi\t\t: " + reader[0]);
                Console.WriteLine("Tanggal Transaksi\t: " + reader[1]);
                Console.WriteLine("Id Peserta\t\t: " + reader[2]);
                Console.WriteLine("Id Seminar\t\t: " + reader[3]);
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

    public  void GetById(int id)
    {
        Console.Clear();
        connection = new SqlConnection(ConnectionString);

        //Membuat instance untuk command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_transaksi Where id = @id";

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
                Console.WriteLine("Id Transaksi\t\t: " + reader[0]);
                Console.WriteLine("Tanggal Transaksi\t: " + reader[1]);
                Console.WriteLine("Id Peserta\t\t: " + reader[2]);
                Console.WriteLine("Id Seminar\t\t: " + reader[3]);
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

    public  void DeleteTransaksi()
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
            command.CommandText = "DELETE FROM tbl_transaksi WHERE id = @id ";
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

    public void InsertTransaksi()
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
            command.CommandText = "INSERT INTO tbl_transaksi (tgl_transaksi, id_peserta, id_seminar) VALUES (@tgl_transaksi, @id_peserta, @id_seminar)";
            command.Transaction = transaction;
            
            Console.WriteLine("============PENDAFTARAN PESERTA SEMINAR ONLINE===================== ");
           
            SqlParameter pTgl = new SqlParameter();
            pTgl.ParameterName = "@tgl_transaksi";
            String Tgl_Transaksi = DateTime.Now.ToString("d");
            pTgl.Value = Tgl_Transaksi;
            pTgl.SqlDbType = SqlDbType.VarChar;

            SqlParameter pId_seminar = new SqlParameter();
            pId_seminar.ParameterName = "@id_seminar";
            Console.Write("Id Seminar\t: ");
            int Id_Seminar = Int32.Parse(Console.ReadLine());
            pId_seminar.Value = Id_Seminar;
            pId_seminar.SqlDbType = SqlDbType.VarChar;

            SqlParameter pId_peserta = new SqlParameter();
            pId_peserta.ParameterName = "@id_peserta";
            Console.Write("Id Peserta\t: ");
            int Id_Peserta = Int32.Parse(Console.ReadLine());
            pId_peserta.Value = Id_Peserta;
            pId_peserta.SqlDbType = SqlDbType.VarChar;

            //Menambahkan parameter ke command

            command.Parameters.Add(pTgl);
            command.Parameters.Add(pId_seminar);
            command.Parameters.Add(pId_peserta);

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

    public void UpdateTransaksi()
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
            command.CommandText = "UPDATE tbl_peserta SET id_seminar=@id_seminar, id_peserta=@id_peserta WHERE id = @id ";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id_seminar";
            Console.Write("Id Transaksi\t: ");
            int Id = Int32.Parse(Console.ReadLine());
            pId.Value = Id;
            pId.SqlDbType = SqlDbType.VarChar;

            GetById(Id);

            SqlParameter pId_seminar = new SqlParameter();
            pId_seminar.ParameterName = "@id_seminar";
            Console.Write("Id Seminar\t: ");
            int Id_Seminar = Int32.Parse(Console.ReadLine());
            pId_seminar.Value = Id_Seminar;
            pId_seminar.SqlDbType = SqlDbType.VarChar;

            SqlParameter pId_peserta = new SqlParameter();
            pId_peserta.ParameterName = "@id_peserta";
            Console.Write("Id Peserta\t: ");
            int Id_Peserta = Int32.Parse(Console.ReadLine());
            pId_peserta.Value = Id_Peserta;
            pId_peserta.SqlDbType = SqlDbType.VarChar;

            //Menambahkan parameter ke command
            command.Parameters.Add(pId_seminar);
            command.Parameters.Add(pId_peserta);

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
