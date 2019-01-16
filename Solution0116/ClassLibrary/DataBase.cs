using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DataBase
    {
        //private string strConnection1 = string.Format("server={0};user={1};password={2};database={3}", "192.168.3.142", "root", "1234", "test");
        //private string strConnection2 = string.Format("server={0};user={1};password={2};database={3}", "192.168.3.155", "root", "1234", "test");

        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();

                string path = "\\public\\DBinfo.json";

                FileStream fs = File.OpenRead(path);
                string result = "";
                //byte[] b = new byte[1024];
                //UTF8Encoding temp = new UTF8Encoding(true);

                //while (fs.Read(b, 0, b.Length) > 0)
                //{
                //    result = temp.GetString(b);
                //    Console.WriteLine(result);
                //}
                result = new StreamReader(File.OpenRead(path)).ReadToEnd();
                fs.Close();
                JObject jo = JsonConvert.DeserializeObject<JObject>(result);
                Hashtable map = new Hashtable(); 
                foreach (JProperty jp in jo.Properties())
                {
                    map.Add(jp.Name, jp.Value);
                    Console.WriteLine("{0} , {1}", jp.Name, jp.Value);
                }
                
                conn.ConnectionString = string.Format("server={0};user={1};password={2};database={3}", map["server"].ToString(), map["user"].ToString(), map["password"].ToString(), map["database"].ToString());//strConnection1;
                //Console.WriteLine("접속디비정보 ==> "+conn.ConnectionString);
                conn.Open();
                
                return conn;
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
