using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CCc_c
{
	
    class Program
    {

	

        static void Main(string[] args)
        {

		
		 		FileStream filestream = File.Open("../../TokenSet.txt", FileMode.Open);
							  filestream.SetLength(0);
							  filestream.Close();


							 bool chk = false;
									  int count = 0;
										 String line;
										 try
										 {
											// Console.WriteLine("ertr");
											 //Pass the file path and file name to the StreamReader constructor
											 StreamReader sr = new StreamReader("../../ReadInput.txt");

											 while ((line = sr.ReadLine()) != null)
											 {
												 //Console.WriteLine(line);
												 lexical l1 = new lexical();
												 DFA d = new DFA("", count+1);
												 // Console.WriteLine(d.flt("99.98e1"));
												 line = line.Trim();
												 String[] words = l1.separator(line,chk);

												 for (int i = 0; i < words.Length; i++)
												 {
											d.check(words[i], count+1);
							 //// Console.WriteLine(words[i]);
												 }
												 count++;
											 }
											 if ((line = sr.ReadLine()) == null)
											 {
												 chk = true;
												 DFA d = new DFA("", count );
												 d.check("$", count);
											 }
												 //close the file
												 sr.Close();
							 // d.keywords("");
										  // Console.WriteLine(  d.str("**asd**"));
											 Console.Read();

										 }
										 catch (Exception e)
										 {
											 Console.WriteLine("Exception: " + e.Message);
										 }
									 	//  syntax s = new syntax();
									   semantics s1=new semantics();
						 				    s1.store();
				 // s.store();

										Console.ReadLine();
									
		}
	}
}
