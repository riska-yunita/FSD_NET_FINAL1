using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_FINAL1.Models;

internal class TransaksiModel
{
    public int id { get; set; }
    public string tgl_transaksi { get; set; }
    public int id_peserta { get; set; }
    public int id_seminar { get; set; }
}
