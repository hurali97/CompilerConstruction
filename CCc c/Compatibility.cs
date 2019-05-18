using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCc_c
{
	class Compatibility
	{
		public String type_1, type_2,Operator;


		public Compatibility(string type1, string type2, string Oper )
		{
			type_1 = type1;
			type_2 = type2;
			Operator = Oper ;
		}

		public Compatibility()
		{
			
		}

		public bool compatibility_type(string ty1, string ty2, string opr)
		{

			switch (opr)
			{
				case "=":
				{
					if (ty1.Equals(ty2))
					{
						return true;
					}
					break;
				}
				case "return":
				{
					if (ty1.Equals(ty2))
					{
						return true;
					}
					break;
				}
				default:
					break;
			}

			return false;
		}
	}
}
