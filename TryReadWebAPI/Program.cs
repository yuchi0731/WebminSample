using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TryReadWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //讀取外部WebAPI&寫出內容

            // VScode格式化文件alt+shift+f
            //{"success":true,"result":{"resource_id":"A17010000J-000135-MOZ","records":[{"年度":"2009","平均年齡-男":"34.77","平均年齡-女":"31.28"},{"年度":"2010","平均年齡-男":"35.06","平均年齡-女":"31.63"},{"年度":"2011","平均年齡-男":"35.27","平均年齡-女":"31.85"},{"年度":"2012","平均年齡-男":"36.2","平均年齡-女":"32.05"},{"年度":"2013","平均年齡-男":"36.4","平均年齡-女":"32.48"},{"年度":"2014","平均年齡-男":"36.33","平均年齡-女":"32.78"},{"年度":"2015","平均年齡-男":"36.31","平均年齡-女":"33.65"},{"年度":"2016","平均年齡-男":"36.61","平均年齡-女":"33.49"},{"年度":"2017","平均年齡-男":"35.96","平均年齡-女":"33.39"},{"年度":"2018","平均年齡-男":"35.67","平均年齡-女":"33.49"},{"年度":"2019","平均年齡-男":"35.52","平均年齡-女":"33.57"},{"年度":"2020","平均年齡-男":"35.55","平均年齡-女":"33.37"}]}}


            //透過Web把自己的應用程式開放給外部做溝通
            //WebClient可以Dowbload字串or原始html

            WebClient client = new WebClient();


            /* string jsonText = client.DownloadString("https://apiservice.mol.gov.tw/OdService/rest/datastore/A17010000J-000135-MOZ");*///此網頁不是用UTF8所以為亂碼

            byte[] sourceByte = client.DownloadData("https://apiservice.mol.gov.tw/OdService/rest/datastore/A17010000J-000135-MOZ");
            string jsonTextEncoding = Encoding.UTF8.GetString(sourceByte); //轉碼UTF8

            //string googleText = client.DownloadString("https://www.google.com/");


            Rootobject obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(jsonTextEncoding);

            foreach (var item in obj.result.records)
            {
                Console.WriteLine(item.年度);
            }

            //Console.WriteLine(jsonText);
            //Console.WriteLine("-----------------");
            //Console.WriteLine(jsonTextEncoding);
            //Console.WriteLine("-----------------");
            //Console.WriteLine(googleText); //呈現頁面原始html
            Console.ReadLine();
        }

        //public class Temp
        //{
        //    //原始檔案的分類
        //    public bool success { get; set; }

        //    public Temp2 result { get; set; }
        //}
        //public class Temp2
        //{
        //    public string resource_id { get; set; }

        //    public List<Temp3> records { get; set; } //反序列化為List
        //}

        //public class Temp3
        //{
        //    public string 年度 { get; set; }
        //}


        
        /// <summary>
        /// 複製原始檔案內容，選擇性貼上JSON作為類別則會將檔案內容產生Class
        /// </summary>
        public class Rootobject
        {
            public bool success { get; set; }
            public Result result { get; set; }
        }

        public class Result
        {
            public string resource_id { get; set; }
            public Record[] records { get; set; }
        }

        public class Record
        {
            public string 年度 { get; set; }
            public string 平均年齡男 { get; set; }
            public string 平均年齡女 { get; set; }
        }


    }
}
