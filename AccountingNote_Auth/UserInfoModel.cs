using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote_Auth
{
    public class UserInfoModel
    {
        //和DB裡的欄位一致
        public Guid ID { get; set; }


        public string Account { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }


        //public Guid UserGuid//因為ID型別改成Guid，用不到了
        //{
        //    get
        //    {
        //        return this.ID;

        //        //if (Guid.TryParse(this.ID, out Guid tempGuid))
        //        //{
        //        //    return tempGuid;
        //        //}
        //        //else
        //        //{
        //        //    //return null;
        //        //    //因Guid是實質型別無法丟回null

        //        //    return Guid.Empty;

        //        //}
        //    }
        //}


    }
}
