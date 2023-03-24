using EBill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace EBill.Repository
{
    interface IData
    {
        void SaveBillDetail(BillDetail details);
        void SaveBIllItems(List<Items> items, SqlConnection con, int id);
        List<BillDetail> GetAllDetail();
        BillDetail GetDetail(int Id);
    }
}