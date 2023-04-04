using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXAM_FINAL1.Models;

namespace EXAM_FINAL1.Repositories;

public class RepositoryPeserta : Interfaces.IPeserta
{
    static string ConnectionString = "Data Source=DESKTOP-1O93DB4\\MSSQLSERVER01;Database=db_seminar;Integrated Security=True;Connect Timeout=30;";
    static SqlConnection connection;
    
    public void GetAllPeserta()
    {
        connection = new SqlConnection(ConnectionString);

        //Membuat instance untuk command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_peserta";

        //Membuka koneksi
        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id\t\t: " + reader[0]);
                Console.WriteLine("Nama\t\t: " + reader[1]);
                Console.WriteLine("Email\t\t: " + reader[2]);
                Console.WriteLine("Nomor HP\t: " + reader[3]);
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
        command.CommandText = "SELECT * FROM tbl_peserta Where id = @id";

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
                Console.WriteLine("Id\t\t: " + reader[0]);
                Console.WriteLine("Nama\t\t: " + reader[1]);
                Console.WriteLine("Email\t\t: " + reader[2]);
                Console.WriteLine("Nomor HP\t: " + reader[3]);
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

    public void DeletePeserta()
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
            command.CommandText = "DELETE FROM tbl_peserta WHERE id = @id ";
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

    public void InsertPeserta()
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
            command.CommandText = "INSERT INTO tbl_peserta (name, email, phone_number) VALUES (@name, @email, @phone_number)";
            command.Transaction = transaction;
            Console.WriteLine("============PENDAFTARAN PESERTA SEMINAR ONLINE===================== ");

            //Membuat parameter
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            Console.Write("Nama Lengkap\t: ");
            String Name = Console.ReadLine();
            pName.Value = Name;
            pName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            Console.Write("Email\t\t: ");
            String Email = Console.ReadLine();
            pEmail.Value = Email;
            pEmail.SqlDbType = SqlDbType.VarChar;

            SqlParameter pPhone_number = new SqlParameter();
            pPhone_number.ParameterName = "@phone_number";
            Console.Write("Nomor Handphone\t: ");
            String Phone_number = Console.ReadLine();
            pPhone_number.Value = Phone_number;
            pPhone_number.SqlDbType = SqlDbType.VarChar;

            //Menambahkan parameter ke command
            command.Parameters.Add(pName);
            command.Parameters.Add(pEmail);
            command.Parameters.Add(pPhone_number);

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

    public void UpdatePeserta()
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
            command.CommandText = "UPDATE tbl_peserta SET name = @name, email=@email, phone_number=@phone_number WHERE id = @id ";
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
            Console.Write("Nama Lengkap\t: ");
            String Name = Console.ReadLine();
            pName.Value = Name;
            pName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            Console.Write("Email\t\t: ");
            String Email = Console.ReadLine();
            pEmail.Value = Email;
            pEmail.SqlDbType = SqlDbType.VarChar;

            SqlParameter pPhone_number = new SqlParameter();
            pPhone_number.ParameterName = "@phone_number";
            Console.Write("Nomor Handphone\t: ");
            String Phone_number = Console.ReadLine();
            pPhone_number.Value = Phone_number;
            pPhone_number.SqlDbType = SqlDbType.VarChar;

            //Menambahkan parameter ke command
            command.Parameters.Add(pId);
            command.Parameters.Add(pName);
            command.Parameters.Add(pEmail);
            command.Parameters.Add(pPhone_number);

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