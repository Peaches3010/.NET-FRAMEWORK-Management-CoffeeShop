using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLCF.DTO
{
   public class BillInfo
    {

        public BillInfo(int id, int billID, int foodID, int count)
        {
            this.ID = id;
            this.BilliD = billID;
            this.FoodiD = foodID;
            this.Count = count;
        }
        public BillInfo (DataRow row)
        {
            this.ID = (int)row["id"];
            this.BilliD = (int)row["idBill"];
            this.FoodiD = (int)row["idFood"];
            this.Count = (int)row["count"];
        }

        private int iD;
        private int billiD;
        private int foodiD;
        private int count;

        public int ID { get => iD; set => iD = value; }
        public int BilliD { get => billiD; set => billiD = value; }
        public int FoodiD { get => foodiD; set => foodiD = value; }
        public int Count { get => count; set => count = value; }
    }
}
