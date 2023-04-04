using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXAM_FINAL1.Models;

namespace EXAM_FINAL1.Interfaces;

public interface IPeserta
{  
    public void GetAllPeserta();

    public void GetById(int id);

    public void DeletePeserta();

    public void InsertPeserta();

    public void UpdatePeserta();
}
