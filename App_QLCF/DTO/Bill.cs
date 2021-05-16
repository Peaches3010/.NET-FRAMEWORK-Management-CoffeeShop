using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLCF.DTO
{
    public class Bill
    {
        public Bill (int id, DateTime? dateCheckIn, DateTime? dateCheckOut,int idTable ,int status )
        {
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status; 
        }

        public Bill (DataRow row)
        {
            ID = (int)row["id"];
            DateCheckIn = (DateTime?)row["dateCheckIn"];
            if (row["dateCheckOut"] != DBNull.Value)
            {
                DateCheckOut = (DateTime?)row["dateCheckOut"];
            }
         
            Status = (int)row["status"];
        }
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int iD;
        private int status;


        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int ID { get => iD; set => iD = value; }
        public int Status { get => status; set => status = value; }
      
    }
}
