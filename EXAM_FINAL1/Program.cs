using System.Data;
using System.Data.SqlClient;
using EXAM_FINAL1.Controllers;

namespace DatabaseConnectivity;

class Program
{
    static void Main(string[] args)
    {
        Home menu = new Home();
        menu.MenuHome();
    }
}