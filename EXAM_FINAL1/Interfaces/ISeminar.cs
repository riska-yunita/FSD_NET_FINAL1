using EXAM_FINAL1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXAM_FINAL1.Controllers;
using System.Data.SqlClient;

namespace EXAM_FINAL1.Interfaces;

public interface ISeminar
{
    static string ConnectionString = "Data Source=DESKTOP-1O93DB4\\MSSQLSERVER01;Database=db_seminar;Integrated Security=True;Connect Timeout=30;";
    static SqlConnection connection;
    public void GetAllSeminar();
    public void GetById(int id);
    public void InsertSeminar();
    public void UpdateSeminar();
    public void DeleteSeminar();
}
