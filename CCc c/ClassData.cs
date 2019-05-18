using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCc_c
{
	class ClassData{
		public String Name ,Type ,	AM ,Category ;

		public bool Assigned, Static;

		 public ClassData()
		 {
			 
		 }

		 public ClassData(ClassData c)
		 {
			Name = c.Name;
			Type = c.Type;
			AM = c.AM;
			Category = c.Category;
			 Assigned = c.Assigned;
			 Static = c.Static;
		}
		 public ClassData(String Name, String Type, String AM, String Category,bool Assigned,bool Static)
		{
			this.Name = Name;
			this.Type = Type;
			this.AM = AM;
			this.Category = Category;
			this.Assigned = Assigned;
			this.Static = Static;
		}

		 public void showtable()
		 {
			 Console.WriteLine("Name : "+Name);
			 Console.WriteLine("Type : " + Type);
			 Console.WriteLine("AM : " + AM);
			 Console.WriteLine("Category : " + Category);
			 Console.WriteLine("Assigned : " + Assigned);
			 Console.WriteLine("Static : " + Static+"\n\n");
		 }
	}
}
