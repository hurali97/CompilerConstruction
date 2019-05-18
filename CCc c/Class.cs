using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCc_c
{
	 
		interface A { }
		class Class
		{


	public	String Name, Type, AM, Category,Extends;
	public	bool global = false,
				applies = false;

		public	List<ClassData> dataTable = new List<ClassData>();
			//class Class2 : ClassDataTable ,A { }
			public Class(string name, string type, string am, string category, string extends,List<ClassData> DataTable)
			{
				Name = name;
				Type = type;
				AM = am;
				Category = category;
				Extends = extends;
				 dataTable = DataTable;
			}

			public Class()
			{
				
			}

			public Class(Class c)
			{
				Name = c.Name;
				Type = c.Type;
				AM = c.AM;
				Category = c.Category;
				Extends = c.Extends;
				 dataTable = c.dataTable;
		}

			public void showtable()
			{
				Console.WriteLine("Name : " + Name);
				Console.WriteLine("Type : " + Type);
				Console.WriteLine("AM : " + AM);
				Console.WriteLine("Category : " + Category);
				Console.WriteLine("Extends : " + Extends);
			//	Console.WriteLine("Static : " + Static + "\n\n");
			}
	}
	 
}
