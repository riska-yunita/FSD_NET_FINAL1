using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_FINAL1.Interfaces;

public interface ITransaksi
{
    static string ConnectionString = "Data Source=DESKTOP-1O93DB4\\MSSQLSERVER01;Database=db_seminar;Integrated Security=True;Connect Timeout=30;";
    static SqlConnection connection;

    public  void GetAllTransaksi();

    public  void GetById(int id);

    public  void DeleteTransaksi();

    public void InsertTransaksi();

    public void UpdateTransaksi();
}
