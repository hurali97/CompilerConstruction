using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCc_c
{
    class Token
    {
     public  ArrayList token = new ArrayList();
      public  String value, classname;
          public     int linenumber;

        public Token(String val, string cl, int v)
        {

            this.value = val;
            this.classname = cl;
            this.linenumber = v;
            writer();
        }

       
        public void writer()
        {

            FileStream fs = new FileStream("../../TokenSet.txt", FileMode.Append);
            StreamWriter writer = new StreamWriter(fs);

            // writer.Write("The value is:");
            writer.WriteLine("(" + this.value + "," + this.classname + ","+this.linenumber +")");
            writer.Close();
            fs.Close();
            arraylist();

        }

      

        public void arraylist()
        {

            int i = 0;
            StreamReader sr = new StreamReader("../../TokenSet.txt");

         //   Console.WriteLine("The value added in the arraylist is:\n");
            string s = sr.ReadLine();
            token.Add(s);
          //  Console.WriteLine(token[i].ToString());
            i++;
            sr.Close();
        }

    }
}
