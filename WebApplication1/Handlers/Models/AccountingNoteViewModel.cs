using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Handlers.Models
{
    public class AccountingNoteViewModel
    {
        //乘載資料用，改成想要的輸出格式用，因直接輸出格式不如預期
        //public string ID { get; set; }

        public int ID { get; set; }
        public string Caption { get; set; }

        public int Amount { get; set; }
        public string ActType { get; set; }
        public string CreateDate { get; set; }

        public string Body { get; set; }
    }
}