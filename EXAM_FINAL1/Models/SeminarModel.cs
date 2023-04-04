using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_FINAL1.Models;

public static class SeminarModel
{
    //Berisi entitas-entitas database
    public static int id { get; set; }
    public static string name { get; set; }
    public static string benefit { get; set; }
    public static string pembicara { get; set; }
    public static string tgl_acara { get; set; }
    public static string jam_mulai { get; set; }
    public static string jam_akhir { get; set; }
    public static int harga { get; set; }
    public static bool promo { get; set; }
    public static bool total_harga { get; set; }
}
