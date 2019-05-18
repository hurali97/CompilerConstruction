using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CCc_c
{
	class DFA
	{
		List<Token> tokens;
		int states,initial, finalst;
		int[,] transitiontable;
		String[] RE;

		String cls;
		String opt,input;

		public DFA()
		{


		}
	   public DFA(String inp, int c)
		{

			this.input = inp;

			check(input,c);
		}
		public DFA(String opt, String cls) {

			this.cls = cls;
			this.opt = opt;

		}


	 public   DFA(int st, int inist, int finst, int[,] transtb, String[] re )
		{
			this.states = st;
			this.initial = inist;
			this.finalst = finst;
			this.transitiontable = transtb;
			this.RE = re;
	  
		}

		public void check(String forcheck, int c)
		{
			if(forcheck!="")
			while (true)
			{
				if (integer(forcheck))
				{
				 //  Console.WriteLine("The given word is an integer");
					
					Token t = new Token( "int_const", forcheck, c);
					break;
				}


			else    if (character(forcheck))
				{
				  //  Console.WriteLine("The given word is a character");
					Token t = new Token( "char_const", forcheck, c);
					break;
				}


				else if (flt(forcheck))
				{
				  //  Console.WriteLine("The given word is a float");
					Token t = new Token( "float_const", forcheck, c);
					break;
				}

				else if (identifier(forcheck))
				{
				 //   Console.WriteLine("The given word is an identifier");
					Token t = new Token("ID", forcheck, c);
					break;
				}

				else if (str(forcheck))
				{
				  //  Console.WriteLine("The given word is an identifier");
					Token t = new Token( "string_const",forcheck, c);
					break;
				}
				else if (keywords(forcheck)!="not found")
				{
					//  Console.WriteLine("The given word is an identifier");
					Token t = new Token( keywords(forcheck), forcheck,c);
					break;
				}
				else if (oper(forcheck) != "not found")
				{
					//  Console.WriteLine("The given word is an identifier");
					Token t = new Token( oper(forcheck),forcheck, c);
					break;
				}
				else if (punct(forcheck) != "not found")
				{
					//  Console.WriteLine("The given word is an identifier");
					Token t = new Token( punct(forcheck),forcheck, c);
					break;
				}
				else if (forcheck.Equals("$"))
				{
					//  Console.WriteLine("The given word is an identifier");
					Token t = new Token("$", "",c);
					break;
				}
				else
				{
				   Token t = new Token("InvalidTK", forcheck, c);
					break;

				}
			}

			//             Console.WriteLine("Notmatched");

		}
		public bool identifier(String check)
{
	   

		  String[] RE = new String[4];
		   RE[0] = "[@]";
				 RE[1] = "[A-Za-z]";
				 RE[2] = "[0-9]";
				 RE[3] = "[_]";

   states= 4;       //Total number of states in finite automata
	 
	   //Initial state    
		initial = 0;

		//Final state
		finalst = 2;
		  
		//tT
	  
		transitiontable = new int[,]{{1,3,3,3},{3,2,2,3},{3,2,2,2},{3,3,3,3}};

	 DFA dfa = new DFA(states, initial, finalst,transitiontable, RE);
   
	   if(dfa.Validate(check))
	   {
				return true;
	   }

			return false;     
}

	public bool integer(String check)
	{
	  
		String[] RE = new String[2];
		RE[0] = "[+ -]";
		RE[1] = "[0-9]";
		

		states = 4;       //Total number of states in finite automata

		//Initial state    
		initial = 0;

		//Final state
		finalst = 2;

		//tT

		transitiontable = new int[,] { { 1, 2 }, { 3, 2 }, { 3, 2 }, { 3, 3 } };

		DFA dfa = new DFA(states, initial, finalst, transitiontable, RE);

		if (dfa.Validate(check))
		{
				return true;
		}
			return false;
	}

	public bool character(String check)
	{
		

		String[] RE = new String[4];

		RE[0] = "[\\^]";
		RE[1] = "(\\\\n|\\\\r|\\\\t|\\\\b|\\\\0|\\\\(\"))";
		RE[2] = "[\\\\]";
		RE[3] = "[A-Za-z]|[0-9]|[, . ? ; : [ ] { } = + - _ ! @ # $ % ^ & * ( ) | / ` ~]";


		states = 6;       //Total number of states in finite automata

		//Initial state    
		initial = 0;

		//Final state
		finalst = 3;

		//tT

		transitiontable = new int[,] { { 1, 5, 5, 5 }, { 5, 2, 4, 2 }, { 3, 5, 5, 5 }, { 5, 5, 5, 5 }, { 2, 5, 2, 2 }, { 5, 5, 5, 5 } };

		DFA dfa = new DFA(states, initial, finalst, transitiontable, RE);

		if (dfa.Validate(check))
		{
				return true;
		}
			return false;
	}

		public bool flt(String check)
		{
			Console.WriteLine(check);

			String[] RE = new String[4];

			
			RE[0] = "[0-9]";
			RE[1] = "[+-]";
			RE[2] = "[.]";
			RE[3] = "[eE]";


			states = 7;       //Total number of states in finite automata

			//Initial state    
			initial = 0;

			//Final state
			finalst = 3;

			//tT

			transitiontable = new int[,] { { 1, 1, 2, 6 }, { 1, 6, 2, 6 }, { 3, 6, 6, 6 }, { 3, 6, 6, 4 }, { 3, 5, 6, 6 }, { 3, 6, 6, 6 }, { 6, 6, 6, 6 } };

			DFA dfa = new DFA(states, initial, finalst, transitiontable, RE);

			if (dfa.Validate(check))
			{
				return true;
			}
			return false;
		}

		public bool str(String check)
	{

		String[] RE = new String[4];

	   
		RE[0] = "[*]";
		RE[1] = "[\\\\]";
	   RE[2] = "[nrtob\"]";
		RE[3] = "[a-zA-z0-9+-@$# %^!~*_'&():;{}-]";


		states = 8;       //Total number of states in finite automata

		//Initial state    
		initial = 0;

		//Final state
		finalst = 6;

		//tT

		transitiontable = new int[,] {  { 1,7,7,7 }, { 2,7,7,7 }, { 7,4,3,3 }, { 5,4,3,3 }, { 7,3,3,7 }, { 6,7, 7, 7 }, { 7,7,7, 7 }, { 7, 7, 7,7 } };
		   // transitiontable = new int[,] { { 1, 4, 4 }, { 3, 1, 2 }, { 1, 1, 1 }, { 4, 4, 4 }, { 4, 4, 4 } };

			DFA dfa = new DFA(states, initial, finalst, transitiontable, RE);
		if (dfa.Validate(check))
		{
				return true;
		}
			return false;

	}

	public bool Validate(String input)
	{

		int cs = initial;
	   

		char[] c = input.ToCharArray();
		for (int i = 0; i < c.Length;i++ )
		{
			if(cs!=-1)
			{ cs = transition(cs, c[i]); }
			
		}
		   
	   

		if (finalst == cs)
		{
			return true;
		}

		else
		{
			return false;
		}
	}

	public int transition(int st,char ch)
	{

		int index = 0;
		int j;
	   

		Match m1;


		for (j = 0; j < RE.Length; j++)
		{
		   
			
			Regex regex = new Regex(RE[j]);
			
				m1 = regex.Match(ch.ToString());

				if (m1.Success)
				{

					index = j;
					return transitiontable[st, index];
				   
				}
			
			

		} //for end             

		return -1;
	}
		public String oper(String check)
		{
			String[] vp = new String[] { "+", "-", "*", "/", "&&", "||", "!", "<", ">", "==", "!=", "<=", ">=", "++", "--","=" };
			String[] cp = new String[] { "PM", "PM", "MDM", "MDM", "&&", "||", "!", "ROP", "ROP", "ROP", "ROP", "ROP", "ROP", "IncDec", "IncDec", "=" };


			for(int i=0;i<vp.Length;i++)
			{
				if(vp[i].Equals(check))
				{
					return cp[i];
				}

			}

			return "not found";
		}
		public String[] operators(String check)
		{
			 /*
			op[0].Add(new DFA("+","Arithmetic"));
			op[0].Add(new DFA("-", "Arithmetic"));
			op[0].Add(new DFA("*", "Arithmetic"));
			op[0].Add(new DFA("/", "Arithmetic"));
		   // op[0].Add(new DFA("%", "Arithmetic"));


			op[1].Add(new DFA("&&", "Logical"));
			op[1].Add(new DFA("||", "Logical"));
			op[1].Add(new DFA("!", "Logical"));

			op[2].Add(new DFA("<", "Relational"));
			op[2].Add(new DFA(">", "Relational"));
			op[2].Add(new DFA("==", "Relational"));
			op[2].Add(new DFA("!=", "Relational"));
			op[2].Add(new DFA("<=", "Relational"));
			op[2].Add(new DFA(">=", "Relational"));

			op[3].Add(new DFA("++", "Inc Dec"));
			op[3].Add(new DFA("--", "Inc Dec"));


			op[4].Add(new DFA("=", "Assignment"));
			*/
			String[] array = new String[10];
			array[0] = "+";
			array[1] = "-";
			array[2] = "*";
			array[3] = "/";

			// array[4] = "&&";
			array[4] = "&";
		   // array[5] = "||";
			array[5] = "|";
			array[6] = "!";

			array[7] = "<";
			array[8] = ">";
			//array[9] = "==";
			array[9] = "=";
		   // array[10] = "!=";
		   // array[11] = "<=";
		   // array[12] = ">=";

		   // array[13] = "++";
		   // array[14] = "--";

		   // array[15] = "=";
		   

			return array;
		}
		public String punct(String check)
		{
			String[] vp = new String[] { "%","(",")","{","}","[","]",",", ";", ":", "**", "^","."};
			String[] cp = new String[] { "%", "(",")","{","}","[","]",",",";",":","**","^","." };

			for(int i=0;i<vp.Length;i++)
			{
				if(vp[i].Equals(check))
				{
					return cp[i];
				}
			}

			return "not found";
		}
		public String[] punctuators(String check)
		{
			ArrayList punc = new ArrayList();
		  

			//punc.Add("%");
		   punc.Add("(");
			punc.Add(")");
			punc.Add("{");
			punc.Add("}");
			
			punc.Add("[");
			punc.Add("]");
	  
			punc.Add(",");
			punc.Add(";");
			punc.Add(":");
	   
			punc.Add("+");
			punc.Add("=");
			punc.Add("-");
			punc.Add("&");
			punc.Add("%");
			punc.Add("!");
			punc.Add("|");
			punc.Add("<");
			punc.Add(">");
			punc.Add("/");
			String[] w = (String[])punc.ToArray(typeof(string));

			return w;


		}
 
		public String keywords(String check)
		{
			
			ArrayList[] key = new ArrayList[13];
			String[] vp = new String[] {"main", "bool", "number", "decimal" , "alphabet", "sentence", "to", "if", "else", "null", "static", "section", "period", "resume", "public", "private", "extend", "back", "create", "valid", "invalid"};
			String[] cp = new String[] { "main", "bool", "DT", "DT", "DT", "DT", "to", "if", "else", "void", "static", "class", "break", "continue", "AM", "AM", "extends", "return", "new", "truefalse", "truefalse" };

			
/*
			key[0] = new ArrayList();
				key[0].Add(new DFA("number", "Data types"));
				key[0].Add(new DFA("decimal", "Data types"));
				key[0].Add(new DFA("alphabet", "Data types"));
				key[0].Add(new DFA("sentence", "Data types"));

			key[1].Add(new DFA("to", "Loop"));
			key[2].Add(new DFA("if", "If"));
			key[3].Add(new DFA("else", "Else"));
			key[4].Add(new DFA("Null", "Void"));
			key[5].Add(new DFA("Static", "Static"));
			key[6].Add(new DFA("Session", "class"));
			key[7].Add(new DFA("period", "break"));
			key[8].Add(new DFA("resume", "continue"));
			key[9].Add(new DFA("public", "AM"));
			key[9].Add(new DFA("private", "AM"));
			key[10].Add(new DFA("extend", "Extend"));
			key[11].Add(new DFA("back", "return"));
			key[12].Add(new DFA("create", "new"));
			key[13].Add(new DFA("valid", "TF"));
			key[13].Add(new DFA("invalid", "TF"));
			*/
			for (int e = 0; e < vp.Length; e++)
				{
				   if(vp[e].Equals(check))
				{
					return cp[e];
				}
					
				}
			
		   return "not found";
			
		}

		public String validation(String check)
		{

			String a = "";

		  

			return a;
		
		}



	}


}
