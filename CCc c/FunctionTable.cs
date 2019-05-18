using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCc_c
{
	class FunctionTable
	{
		public String Name ,Type ;

		public bool Assigned;

		public int Scope ;

		public FunctionTable(string name, string type, int scope, bool assigned)
		{
			Name = name;
			Type = type;
			Scope = scope;
			Assigned = assigned;
		}

		public FunctionTable()
		{
			
		}

		public FunctionTable(FunctionTable f)
		
		{
			Name = f.Name;
			Type = f.Type;
			Scope = f.Scope;
			Assigned = f.Assigned;
		}
	}
}
