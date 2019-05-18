using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCc_c
{
	class semantics
	{

		 

		List<Token> token;
	  String parameterlist="",output="",Ti,Li,Li1,hold="",wait="",tempreturn="";
		int i, check,scope,currentscope,  labels, temps;
		ArrayList words;
		ArrayList tokenvalue;
		ArrayList tokenarray;
		Class classtable;
		ClassData classdatatable;
		FunctionTable functiondatatable;
		Compatibility compat_type;
		List<Class> CTable = new List<Class>();
		List<FunctionTable> functiontable=new List<FunctionTable>();
		Stack stack=new Stack();

		public semantics()
		{ }

		string createproc(int ind)
		{
	return	("\n\n" + CTable[ind].Name + "_" + classdatatable.Name + "_" +
			 classdatatable.Type + "   proc\n");
		}
		string createlabel()
		{
			labels++;
			return ("L" + labels);
		}

		string createtemp()
		{
			temps++;
			return ("T" + temps);
		}
		int createscope()
		{
			scope++;
			stack.Push(scope);
			return scope;
		}

		int destroyscope()
		{
			int temporary = (int) stack.Pop();
			return (temporary - 1);
		}


		int getcurrentclass()
		{
			int position=-1;
			for (int i = 0; i < CTable.Count; i++)
			{
				if (CTable[i].Name.Equals(classtable.Name))
				{
					return position=i;
				}
			}

			return position;
		}

		bool insertclass(Class tableclass)
		{
			 

			for (int i = 0; i < CTable.Count; i++)
			{
				

				if (CTable[i].Name.Equals(tableclass.Name))
				{
				//	Console.WriteLine("check " + CTable[i].Name);
					return false;
				}
				
			}

			return true;

		}

		bool lookupclass(String name, List<Class> classtable)
		{
			//Console.WriteLine("size "+ CTable.Count);

			for (int i = 0; i < CTable.Count; i++)
			{
				if ( classtable[i].Name.Equals(name))
				{
					return true;
				}

				 //Console.WriteLine("checking "+ classtable[i].Name);

			}

			return false;


		}

		bool insertclassdata(ClassData tableclassdata,List<ClassData> datatable)
		{

			 
			for (int i = 0; i < datatable.Count; i++)
			{
				
				if (datatable[i].Name.Equals(tableclassdata.Name))
				{
				//	Console.WriteLine("check " + datatable[i].Name);
					return false;
				}

			}
			
			return true;

		}

		bool insertfunctiondata(FunctionTable table,int scopetemp)
		{


			for (int i = 0; i < functiontable.Count; i++)
			{
				if (functiontable[i].Name.Equals(table.Name) && functiontable[i].Scope == scopetemp)
				{

					return false;
				}

			}

			return true;
		}

		bool insertclassfunction(ClassData tableclassdata, List<ClassData> datatable)
		{


			for (int i = 0; i < datatable.Count; i++)
			{

				if (datatable[i].Name.Equals(tableclassdata.Name)&& datatable[i].Type.Equals(tableclassdata.Type))
				{
					//	Console.WriteLine("check " + datatable[i].Name);
					return false;
				}

			}

			return true;

		}

		public void store()
		{

			String line;
			i = 0;
			words = new ArrayList();
			tokenvalue = new ArrayList();
			tokenarray = new ArrayList();
			try
			{


				//Pass the file path and file name to the StreamReader constructor
				StreamReader sr = new StreamReader("../../TokenSet.txt");

				while ((line = sr.ReadLine()) != null)
				{

					line = line.Trim();
					words.Add(line);



				}
				if ((line = sr.ReadLine()) == null)
				{
					//	tokenvalue.Add("$");
				}

				sr.Close();

				String[] arr = new String[10];
				String name, temp;
				int g = 0;
				int indEnd = 0, indStart = 0;
				for (int i1 = 0; i1 < words.Capacity; i1++)
				{


					name = (words[i1].ToString());
					name = name.Trim();
					//indEnd = name.LastIndexOf(",");
					//indStart = name.IndexOf(",");
					//temp = name.Substring(indStart +1, indEnd -indStart-1);
					//Console.WriteLine(temp + "vp");

					if (name.Contains(""))
					{ 
						if (name.IndexOf(',') == 1)
						{
						 
							indEnd = name.LastIndexOf(",");
							indStart = name.IndexOf(',', 2);
							temp = name.Substring(indStart + 1, indEnd - indStart - 1);
							 
							tokenvalue.Add(temp);
						}
						else
						{
							indEnd = name.LastIndexOf(",");
							indStart = name.IndexOf(",");
							temp = name.Substring(indStart + 1, indEnd - indStart - 1);

							tokenvalue.Add(temp);
							 
						} 



					}

					if (name.Contains(""))
					{

						if (name.IndexOf(',') == 1)
						{
							tokenarray.Add(",");

						}
						else
						{
							tokenarray.Add(name.Substring(1, name.IndexOf(',') - 1));

						}


					}

					else
					{



					}


				}




				Console.ReadLine();

			}
			catch (Exception e)
			{
			//	Console.WriteLine("Exception: " + e.Message);
			}


			String[] p2 = (String[])tokenvalue.ToArray(typeof(string));

			 

			tokenvalue = new ArrayList();

			tokenvalue.AddRange(p2);

			String[] p1 = (String[])tokenarray.ToArray(typeof(string));
			tokenarray = new ArrayList();

			tokenarray.AddRange(p1);

	 //	for (int i = 0; i < p2.Length; i++)
			{
			 //	Console.WriteLine(p2[i] + "   cp");
			}

			check = 0;
		 if (start() == true)
			{

				Console.WriteLine("true " + "\n");
				Console.WriteLine(output);
			}
			else
			{


				Console.WriteLine("false " + "\n");

			} 

			Console.ReadLine();
		}



		bool start()
		{
			classtable=new Class();
			classdatatable=new ClassData();
			functiondatatable=new FunctionTable();
			compat_type=new Compatibility();
			if (tokenarray[i].ToString().Equals("class") || tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("main"))
			{

				//	Console.WriteLine(tokenarray[i].ToString() + "  yaar");
				if (option1())
				{

					if (Main())
					{
						if (option1())
						{
							return true;
						}
					}
				}
			}


			return false;
		}

		bool option1()
		{
			
			if (tokenarray[i].ToString().Equals("class") || tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("main") || tokenarray[i].ToString().Equals("$"))
			{

				if (tokenarray[i].ToString().Equals("class"))
				{
					classtable = new Class();
					classdatatable = new ClassData();
					functiondatatable = new FunctionTable();
					compat_type = new Compatibility();

					classtable.Type = "class";
					i++;
					if (tokenarray[i].ToString().Equals("ID"))
					{
						classtable.Name = tokenvalue[i].ToString();
						// Console.WriteLine("yayar "+ classtable.Name);
						i++;
						if (Extends())
						{
							classtable.AM = "public";
							if (insertclass(classtable))
							{
							CTable.Add(new Class(classtable) );
							int p = getcurrentclass();
							//int a = CTable.Count - 1;
							CTable[p].showtable();
								//	Console.WriteLine("class added "+classtable.Name.ToString());
							}
							else
							{
								Console.WriteLine("Redeclaration Error !");
								return false;
							}
							if (tokenarray[i].ToString().Equals("{"))
							{
								i++;
								if (mstclassbody())
								{
									if (tokenarray[i].ToString().Equals("}"))
									{

										i++;
										 
										if (option1())
										{

											//	check = 1;
											return true;
										}
									}
								}
							}

						}
					}
				}
				else if (tokenarray[i].ToString().Equals("void"))
				{
						
					i++;
					if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;
						if (tokenarray[i].ToString().Equals("("))
						{


							i++;
							if (arguments())
							{

								if (tokenarray[i].ToString().Equals(")"))
								{
									i++;


									if (tokenarray[i].ToString().Equals("{"))
									{

										i++;
										if (mstbody())
										{

											if (Return())
											{
												if (tokenarray[i].ToString().Equals("}"))
												{

													i++;
													if (mstbody1())
													{
														//	Console.WriteLine("asd");
														if (option1())
														{
															//check = 1;
															return true;
														}
													}
												}
											}
										}
									}

								}
							}

						}
					}
				}
				else if (tokenarray[i].ToString().Equals("DT"))
				{

					i++;

					if (body5())
					{
						//Console.WriteLine(tokenarray[i].ToString() + "  aadsds");

						if (mstbody1())
						{

							if (option1())
							{


								//	check = 1;
								return true;
							}
						}
					}
				}

				else if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (body10())
					{
						if (mstbody1())
						{
							if (option1())
							{


								//	check = 1;
								return true;
							}
						}
					}
				}
				else if (tokenarray[i].ToString().Equals("static"))
				{
					i++;
					if (body3())
					{
						if (mstbody1())
						{
							if (option1())
							{


								//	check = 1;
								return true;
							}
						}
					}
				}
				else if (tokenarray[i].ToString().Equals("AM"))
				{

					i++;

					if (option2())
					{

						if (option1())
						{


							//	check = 1;
							return true;
						}
					}

				}


				else if (tokenarray[i].ToString().Equals("class") || tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("main"))
				{

					//	Console.WriteLine(tokenarray[i].ToString() + " 11yaar");
					if (tokenarray[i].ToString().Equals("main"))
					{
						check = 1;
						return true;
					}
					//	Console.WriteLine(tokenarray[i].ToString() + " 11yaar");
					return true;

				}
				else if (tokenarray[i].ToString().Equals("$") && check == 1)
				{

					//	Console.WriteLine(tokenarray[i].ToString() + " 11yaar");
					return true;

				}

				return false;
			}


			return false;
		}

		bool option2()
		{
			if (tokenarray[i].ToString().Equals("class") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("void"))
			{
				if (tokenarray[i].ToString().Equals("class"))
				{
					i++;
					if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;
						if (Extends())
						{
							if (tokenarray[i].ToString().Equals("{"))
							{
								i++;
								if (mstclassbody())
								{
									if (tokenarray[i].ToString().Equals("}"))
									{
										i++;
										return true;
									}

								}

							}

						}
					}
				}
				else if (body2())
				{

					if (mstbody1())
					{
						//Console.WriteLine(tokenarray[i].ToString() + " 11yaar");
						return true;
					}

				}
			}

			return false;
		}

		bool mstbody1()
		{
			if (tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("main") || tokenarray[i].ToString().Equals("class") || tokenarray[i].ToString().Equals("$"))
			{
				if (body1())
				{
					if (mstbody1())
					{
						return true;

					}

				}
				else if (tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("main") || tokenarray[i].ToString().Equals("class") || tokenarray[i].ToString().Equals("$"))
				{
					return true;
				}
				/*        else if()  null k lie
				  {
					return true;
				  }*/
			}

			return false;
		}

		bool body1()
		{
			if (tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("static"))
			{
				if (tokenarray[i].ToString().Equals("AM"))
				{
					i++;
					if (body2())
					{
						return true;

					}
				}
				else if (tokenarray[i].ToString().Equals("void"))
				{
					i++;
					if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;
						if (tokenarray[i].ToString().Equals("("))
						{
							i++;
							if (arguments())
							{
								if (tokenarray[i].ToString().Equals(")"))
								{
									i++;
									if (tokenarray[i].ToString().Equals("{"))
									{
										i++;
										if (mstbody())
										{
											if (Return())
											{
												if (tokenarray[i].ToString().Equals("}"))
												{
													i++;
													return true;

												}

											}

										}
									}
								}

							}
						}
					}
				}
				else if (tokenarray[i].ToString().Equals("DT"))
				{
					i++;
					if (body5())
					{
						return true;

					}
				}
				else if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (body10())
					{
						return true;

					}
				}
				else if (tokenarray[i].ToString().Equals("static"))
				{
					i++;
					if (body3())
					{
						return true;

					}
				}
			}
			return false;
		}

		bool body2()
		{
			if (tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("static"))
			{
				if (Static())
				{
					if (body3())
					{

						return true;
					}

				}

			}

			return false;
		}


		bool body3()
		{
			if (tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID"))
			{
				if (tokenarray[i].ToString().Equals("DT"))
				{
					i++;
					if (body5())
					{

						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (body5())
					{

						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("void"))
				{

					i++;
					if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;
						if (tokenarray[i].ToString().Equals("("))
						{
							i++;
							if (arguments())
							{

								if (tokenarray[i].ToString().Equals(")"))
								{
									i++;
									if (tokenarray[i].ToString().Equals("{"))
									{
										i++;
										if (mstbody())
										{
											if (Return())
											{

												if (tokenarray[i].ToString().Equals("}"))
												{
													i++;
													return true;
												}

											}

										}
									}

								}

							}
						}
					}

				}
			}



			return false;
		}

		bool body4()
		{
			if (tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("ID"))
			{
				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (init())
					{
						if (List())
						{
							return true;
						}
					}
				}
				else if (tokenarray[i].ToString().Equals("["))
				{
					i++;

					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;
						if (array_option())
						{
							return true;
						}
					}
				}
			}


			return false;
		}

		bool body5()
		{
			if (tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("ID"))
			{
				if (tokenarray[i].ToString().Equals("["))
				{

					i++;

					if (tokenarray[i].ToString().Equals("]"))
					{

						i++;
						if (body6())
						{

							return true;
						}
					}
				}
				/*    else if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;

						if (init())
						{

							if (List())
							{
								return true;
							}
						}
					}
				}*/
				else if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;

					if (body13())
					{

						return true;

					}
				}
			}

			return false;
		}

		bool body6()
		{
			if (tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("("))
			{
				//	Console.WriteLine("asd"+ tokenarray[i].ToString());

				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;

					if (body7())
					{

						return true;

					}
				}
				else if (tokenarray[i].ToString().Equals("["))
				{

					i++;

					if (tokenarray[i].ToString().Equals("]"))
					{

						i++;
						if (body8())
						{

							return true;
						}
					}
				}
			}


			return false;
		}

		bool body7()
		{
			if (tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("(") || tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("%"))
			{


				if (tokenarray[i].ToString().Equals("("))
				{
					i++;

					if (arguments())
					{

						if (tokenarray[i].ToString().Equals(")"))
						{
							i++;
							if (tokenarray[i].ToString().Equals("{"))
							{


								i++;
								if (mstbody())
								{

									if (Return())
									{

										if (tokenarray[i].ToString().Equals("}"))
										{
											i++;

											return true;
										}
									}

								}
							}
						}

					}
				}



				else if (new_array())
				{

					return true;
				}
			}


			return false;
		}

		bool body8()
		{
			if (tokenarray[i].ToString().Equals("ID"))
			{
				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (body9())
					{
						return true;
					}
				}
			}


			return false;
		}


		bool body9()
		{
			if (tokenarray[i].ToString().Equals("(") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("="))
			{
				if (tokenarray[i].ToString().Equals("("))
				{
					i++;
					if (arguments())
					{
						if (tokenarray[i].ToString().Equals(")"))
						{
							i++;

							if (tokenarray[i].ToString().Equals("{"))
							{
								i++;
								if (mstbody())
								{
									if (Return())
									{
										if (tokenarray[i].ToString().Equals("}"))
										{
											i++;

											return true;
										}

									}
								}

							}
						}

					}
				}

				else if (array_option2())
				{
					return true;
				}
			}


			return false;

		}

		bool body10()
		{

			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("["))
			{
				if (tokenarray[i].ToString().Equals("ID"))
				{

					i++;

					if (body11())
					{
						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("["))
				{
					i++;

					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;
						if (body6())
						{
							return true;
						}

					}

				}
			}

			return false;
		}

		bool body11()
		{
			if (tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals(",") || tokenarray[i].ToString().Equals("("))
			{
				if (tokenarray[i].ToString().Equals("="))
				{

					i++;
					if (body12())
					{
						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("%"))
				{
					i++;

					return true;

				}
				else if (tokenarray[i].ToString().Equals(","))
				{
					i++;
					if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;
						if (init())
						{
							if (List())
							{
								return true;
							}
						}

					}

				}

				else if (tokenarray[i].ToString().Equals("("))
				{
					i++;
					if (arguments())
					{
						if (tokenarray[i].ToString().Equals(")"))
						{
							i++;
							if (tokenarray[i].ToString().Equals("{"))
							{
								i++;
								if (mstbody())
								{

									if (Return())
									{

										if (tokenarray[i].ToString().Equals("}"))
										{
											i++;

											return true;
										}

									}

								}

							}

						}

					}

				}
			}

			return false;
		}

		bool body12()
		{
			if (tokenarray[i].ToString().Equals("new") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const"))
			{
				if (tokenarray[i].ToString().Equals("new"))
				{

					i++;
					if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;
						if (tokenarray[i].ToString().Equals("("))
						{

							i++;

							if (parameter_option())
							{

								if (tokenarray[i].ToString().Equals(")"))
								{
									i++;

									if (tokenarray[i].ToString().Equals("%"))
									{
										i++;

										return true;
									}

								}
							}
						}

					}

				}

				else if (OE())
				{
					if (List())
					{
						return true;
					}
				}
			}

			return false;

		}

		bool body13()
		{

			if (init())
			{

				if (List())
				{
					return true;
				}
			}

			else if (body7())
			{
				return true;
			}

			return false;
		}

		bool mstclassbody()
		{
			if (tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("}"))
			{
				if (classbody())
				{
					if (mstclassbody())
					{

						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("}"))// null k lie
				{
					return true;
				}
				/*        else if() // null k lie
				  {
					return true;
				  }*/
			}

			return false;
		}

		bool classbody()
		{
			if (tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT"))
			{
				if (tokenarray[i].ToString().Equals("AM"))
				{
					classdatatable.AM = tokenvalue[i].ToString();
					i++;

					if (classbody1())
					{

						return true;
					}
				}

				else if (tokenarray[i].ToString().Equals("static"))
				{
					i++;

					if (classbody2())
					{

						return true;
					}
				}
				else if (tokenarray[i].ToString().Equals("void"))
				{
					parameterlist = "";
					classdatatable.Type = tokenvalue[i].ToString();
					classdatatable.AM = "public";
					classdatatable.Category = "-";
					
					i++;

					if (tokenarray[i].ToString().Equals("ID"))
					{
						classdatatable.Name = tokenvalue[i].ToString();
						i++;
						if (tokenarray[i].ToString().Equals("("))
						{
						currentscope=createscope();
							i++;
							if (arguments())
							{
								classdatatable.Type = parameterlist + "-" + classdatatable.Type;
								int position = getcurrentclass();
								//Console.WriteLine("postion " + position);
								if (insertclassfunction(classdatatable, CTable[position].dataTable))
								{
									CTable[position].dataTable.Add(new ClassData(classdatatable));

									CTable[position].dataTable[CTable[position].dataTable.Count - 1].showtable();
								}
								else
								{
									Console.WriteLine("Function Redeclaration Error\n");
									return false;
								}



								if (tokenarray[i].ToString().Equals(")"))
								{

									output = output+createproc(position);

									i++;

									if (tokenarray[i].ToString().Equals("{"))
									{
										i++;
										if (mstbody())
										{
											if (Return())
											{
												if (tokenarray[i].ToString().Equals("}"))
												{
													currentscope = destroyscope();
													i++;
													output = output + "\n End P\n\n";
													return true;
												}

											}
										}
									}
								}

							}
						}
					}
				}

				else if (tokenarray[i].ToString().Equals("ID"))
				{
					classdatatable.Name = tokenvalue[i].ToString();
					classdatatable.Type= tokenvalue[i].ToString();
					classdatatable.AM = "public";
					classdatatable.Category = "-";

					///Console.WriteLine("yrr  "+ tokenvalue[i-1].ToString());
					if (lookupclass(classdatatable.Name, CTable)==false)
					{
						Console.WriteLine("Class undeclared !");
						return false;
					}
					else
					{

					}

						i++;
					if (classbody7())
					{

						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("DT"))
				{
					parameterlist = "";
					classdatatable.Type = tokenvalue[i].ToString();
					tempreturn = classdatatable.Type;
					i++;
					if (classbody4())
					{

						return true;
					}

				}
			}


			return false;

		}

		bool classbody1()
		{
			if (tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT"))
			{
				if (tokenarray[i].ToString().Equals("static"))
				{
					 
					classdatatable.Static = true;
					i++;
					if (classbody2())
					{

						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("DT"))
				{
					i++;
					if (classbody4())
					{

						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("void"))
				{
					i++;

					if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;
						if (tokenarray[i].ToString().Equals("("))
						{
							i++;
							if (arguments())
							{
								if (tokenarray[i].ToString().Equals(")"))
								{
									i++;

									if (tokenarray[i].ToString().Equals("{"))
									{
										i++;
										if (mstbody())
										{
											if (Return())
											{
												if (tokenarray[i].ToString().Equals("}"))
												{
													i++;
													return true;
												}

											}
										}
									}
								}

							}
						}
					}
				}
				else if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;

					if (classbody6())
					{
						return true;
					}
				}
			}


			return false;
		}


		bool classbody2()
		{
			if (tokenarray[i].ToString().Equals("void") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT"))
			{
				if (tokenarray[i].ToString().Equals("DT"))
				{
					classdatatable.Type = tokenvalue[i].ToString();
					i++;
					if (classbody4())
					{

						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (classbody4())
					{

						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("void"))
				{
					i++;

					if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;
						if (tokenarray[i].ToString().Equals("("))
						{
							i++;
							if (arguments())
							{
								if (tokenarray[i].ToString().Equals(")"))
								{
									i++;

									if (tokenarray[i].ToString().Equals("{"))
									{
										i++;
										if (mstbody())
										{
											if (Return())
											{
												if (tokenarray[i].ToString().Equals("}"))
												{
													i++;
													return true;
												}

											}
										}
									}
								}

							}
						}
					}
				}

			}


			return false;
		}

		bool classbody3()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("["))
			{
				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (init())
					{
						if (List())
						{

							return true;

						}
					}
				}
				else if (tokenarray[i].ToString().Equals("["))
				{
					i++;
					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;
						if (array_option())
						{

							return true;

						}
					}
				}
			}


			return false;
		}

		bool classbody4()
		{

			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("["))
			{
				if (tokenarray[i].ToString().Equals("ID"))
				{
					classdatatable.Name = tokenvalue[i].ToString();
					i++;
					if (classbody13())
					{

						return true;

					}
				}
				else if (tokenarray[i].ToString().Equals("["))
				{
					i++;
					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;
						if (classbody5())
						{

							return true;

						}
					}
				}
			}

			return false;
		}

		bool classbody5()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("["))
			{
				if (tokenarray[i].ToString().Equals("ID"))
				{
					classdatatable.Name = tokenvalue[i].ToString();
					i++;

					if (classbody10())
					{

						return true;

					}

				}
				else if (tokenarray[i].ToString().Equals("["))
				{
					i++;
					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;
						if (classbody11())
						{

							return true;

						}
					}
				}
			}


			return false;
		}

		bool classbody6()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("("))
			{
				if (classbody4())
				{
					return true;
				}

				else if (tokenarray[i].ToString().Equals("("))
				{
					i++;
					if (arguments())
					{
						if (tokenarray[i].ToString().Equals(")"))
						{
							i++;

							if (tokenarray[i].ToString().Equals("{"))
							{
								i++;
								if (mstbody())
								{

									if (tokenarray[i].ToString().Equals("}"))
									{
										i++;
										return true;
									}
								}
							}
						}


					}
				}


			}




			return false;
		}

		bool classbody7()
		{

			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("("))
			{
				if (tokenarray[i].ToString().Equals("ID"))
				{
					classdatatable.Name = tokenvalue[i].ToString();

					i++;
					if (classbody8())
					{

						return true;

					}
				}
				else if (tokenarray[i].ToString().Equals("["))
				{
					i++;
					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;
						if (classbody5())
						{
							return true;
						}
					}
				}

				else if (tokenarray[i].ToString().Equals("("))
				{
					i++;
					if (arguments())
					{
						if (tokenarray[i].ToString().Equals(")"))
						{
							i++;

							if (tokenarray[i].ToString().Equals("{"))
							{
								i++;
								if (mstbody())
								{

									if (tokenarray[i].ToString().Equals("}"))
									{
										i++;
										return true;
									}
								}
							}
						}


					}
				}
			}

			return false;
		}

		bool classbody8()
		{

			if (tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals(",") || tokenarray[i].ToString().Equals("("))
			{
				if (tokenarray[i].ToString().Equals("%"))
				{
					classdatatable.Assigned = false;

					int position = getcurrentclass();
					Console.WriteLine("\n\npostion " + position);
					if (insertclassdata(classdatatable, CTable[position].dataTable))
					{
						CTable[position].dataTable.Add(new ClassData(classdatatable));

						CTable[position].dataTable[CTable[position].dataTable.Count - 1].showtable();
					}
					else
					{
						Console.WriteLine("Variable Redeclaration Error\n");
						return false;
					}
					i++;
					return true;
				}
				else if (tokenarray[i].ToString().Equals("="))
				{
					i++;
					if (classbody9())
					{
						return true;
					}
				}
				else if (tokenarray[i].ToString().Equals(","))
				{
					i++;
					if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;
						if (init())
						{
							if (List())
							{
								return true;
							}
						}
					}
				}

				else if (tokenarray[i].ToString().Equals("("))
				{

					i++;
					if (arguments())
					{
						if (tokenarray[i].ToString().Equals(")"))
						{
							i++;

							if (tokenarray[i].ToString().Equals("{"))
							{
								i++;
								if (mstbody())
								{
									if (Return())
									{
										if (tokenarray[i].ToString().Equals("}"))
										{
											i++;
											return true;
										}

									}
								}
							}
						}

					}
				}
			}
			return false;
		}

		bool classbody9()
		{

			if (tokenarray[i].ToString().Equals("new"))
			{

				if (tokenarray[i].ToString().Equals("new"))
				{
					i++;
					if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;
						if (tokenarray[i].ToString().Equals("("))
						{
							i++;
							if (parameter_option())
							{
								if (tokenarray[i].ToString().Equals(")"))
								{
									i++;
									if (tokenarray[i].ToString().Equals("%"))
									{
										i++;
										return true;
									}
								}
							}
						}
					}
				}
			}

			return false;
		}

		bool classbody10()
		{
			if (tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("("))
			{
				if (array_option1())
				{
					return true;
				}
				else if (tokenarray[i].ToString().Equals("("))
				{
					 
					currentscope = createscope();
				
					i++;
					if (arguments())
					{
						classdatatable.Type = parameterlist + "-" + classdatatable.Type;
						int position = getcurrentclass();
						//Console.WriteLine("postion " + position);
						if (insertclassfunction(classdatatable, CTable[position].dataTable))
						{
							CTable[position].dataTable.Add(new ClassData(classdatatable));

							CTable[position].dataTable[CTable[position].dataTable.Count - 1].showtable();
						}
						else
						{
							Console.WriteLine("Function Redeclaration Error\n");
							return false;
						}

						if (tokenarray[i].ToString().Equals(")"))
						{
							output = output + createproc(position);
							i++;

							if (tokenarray[i].ToString().Equals("{"))
							{
								i++;
								if (mstbody())
								{
									if (Return())
									{
										if (tokenarray[i].ToString().Equals("}"))
										{
											currentscope = destroyscope();
											i++;
											output = output + "\n End P\n\n";
											return true;
										}

									}
								}
							}
						}

					}
				}
			}

			return false;
		}

		bool classbody11()
		{
			if (tokenarray[i].ToString().Equals("ID"))
			{
				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (classbody12())
					{

					}

				}
			}

			return false;
		}

		bool classbody12()
		{
			if (tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("("))
			{
				if (array_option2())
				{
					return true;
				}
				else if (tokenarray[i].ToString().Equals("("))
				{
					i++;
					if (arguments())
					{
						if (tokenarray[i].ToString().Equals(")"))
						{
							i++;

							if (tokenarray[i].ToString().Equals("{"))
							{
								i++;
								if (mstbody())
								{
									if (Return())
									{
										if (tokenarray[i].ToString().Equals("}"))
										{
											i++;
											return true;
										}

									}
								}
							}
						}

					}
				}
			}

			return false;
		}

		bool classbody13()
		{

			if (init())
			{
				int position = getcurrentclass();
				 Console.WriteLine("\n\npostion "+position);
				if (insertclassdata(classdatatable, CTable[position].dataTable))
				{
					CTable[position].dataTable.Add(new ClassData(classdatatable));

					CTable[position].dataTable[CTable[position].dataTable.Count-1].showtable();
				}
				else
				{
					Console.WriteLine("Variable Redeclaration Error\n");
					return false;
				}


				if (List())

				{
					return true;
				}

			}
			else if (classbody10())
			{
				return true;
			}

			return false;
		}

		bool mstbody()
		{
			if (tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("to") || tokenarray[i].ToString().Equals("if"))
			{
				if (mainbody())
				{
					if (mstbody())
					{
						return true;
					}


				}

				/*        else if()  null k lie
				   {
					 return true;
				   }*/
			}
			else if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals("return")) //null k lie
			{
				return true;
			}


			return false;
		}




		bool mainbody()
		{
			if (tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("to") || tokenarray[i].ToString().Equals("if"))
			{


				if (AM())
				{

					if (mainbody1())
					{

						return true;
					}
				}

				else if (tokenarray[i].ToString().Equals("ID"))
				{

					i++;
					if (mainbody4())
					{

						return true;
					}
				}
				else if (loop())
				{

					return true;

				}
				else if (if_else())
				{

					return true;

				}

			}


			return false;
		}




		bool mainbody1()
		{

			if (tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT"))
			{
				if (Static())
				{
					if (mainbody2())
					{
						return true;
					}
				}
				//.	else if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT"))
				{

					//.		return true;

				}
			}



			return false;
		}


		bool mainbody2()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT"))
			{
				if (DT())
				{
					if (mainbody3())
					{
						return true;
					}
				}
			}

			return false;
		}



		bool mainbody3()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("["))
			{
				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;

					if (init())
					{

						if (List())
						{
							return true;
						}
					}


				}

				else if (tokenarray[i].ToString().Equals("["))
				{
					i++;

					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;
						if (array_option())
						{
							return true;
						}
					}

				}




			}

			return false;
		}





		bool mainbody4()
		{

			if (tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("(") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const") || tokenarray[i].ToString().Equals("IncDec") || tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("."))
			{

				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (object_option())
					{
						return true;
					}
				}

				else if (tokenarray[i].ToString().Equals("("))
				{

					i++;
					if (parameters())
					{
						if (tokenarray[i].ToString().Equals(")"))
						{
							i++;

							if (mainbody5())
							{
								if (tokenarray[i].ToString().Equals("%"))
								{
									i++;
									return true;
								}
							}
						}
					}
				}
				else
				if (tokenarray[i].ToString().Equals("="))
				{
					//.Console.WriteLine("äsd");
					i++;
					if (OE())
					{
						//.	Console.WriteLine("asd " + tokenarray[i].ToString());

						if (tokenarray[i].ToString().Equals("%"))
						{
							i++;
							return true;
						}



					}
				}
				else if (choice2())
				{


					if (tokenarray[i].ToString().Equals("%"))
					{
						i++;
						return true;
					}

				}
				/*	else if (tokenarray[i].ToString().Equals("IncDec"))
					{

						i++;
						if (tokenarray[i].ToString().Equals("%"))
						{
							i++;
							return true;

						}
					}
					*/

			}


			return false;
		}



		bool mainbody5()
		{
			//.Console.WriteLine("asd");
			if (tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("to") || tokenarray[i].ToString().Equals("if"))
			{
				if (tokenarray[i].ToString().Equals("="))
				{
					i++;
					if (OE())

						return true;
				}


				/*        else if()  null k lie
					{
					  return true;
					}*/
			}
			else if (tokenarray[i].ToString().Equals("%")) //.null k lie
			{
				return true;
			}


			return false;
		}



		bool mstifloopbody()
		{
			if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals("break") || tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("to") || tokenarray[i].ToString().Equals("if") || tokenarray[i].ToString().Equals("continue"))
			{
				if (ifloopbody())
				{
					if (mstifloopbody())
					{
						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("}")) //null k lie
				{
					return true;
				}
				/*        else if()  null k lie
				   {
					 return true;
				   }*/

			}
			return false;
		}

		bool ifloopbody()
		{
			if (tokenarray[i].ToString().Equals("break") || tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("to") || tokenarray[i].ToString().Equals("if") || tokenarray[i].ToString().Equals("continue"))
			{

				if (AM())
				{

					if (ifloopbody1())
					{
						return true;
					}
				}
				else if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (ifloopbody4())
					{
						return true;
					}
				}
				else if (loop())
				{
					return true;
				}
				else if (if_else())
				{
					return true;
				}
				else if (tokenarray[i].ToString().Equals("break"))
				{
					i++;
					if (tokenarray[i].ToString().Equals("%"))
					{
						i++;
						return true;
					}
				}
				else if (tokenarray[i].ToString().Equals("continue"))
				{
					i++;
					if (tokenarray[i].ToString().Equals("%"))
					{
						i++;
						return true;
					}
				}
			}


			return false;
		}

		bool ifloopbody1()
		{
			if (tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT"))
			{

				if (Static())
				{
					if (ifloopbody2())
					{
						return true;
					}
				}

			}

			return false;
		}

		bool ifloopbody2()
		{

			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT"))
			{

				if (DT())
				{

					if (ifloopbody3())
					{
						return true;
					}
				}
			}


			return false;
		}

		bool ifloopbody3()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("["))
			{
				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;

					if (init())
					{
						if (List())
						{

							return true;
						}
					}
				}
				else if (tokenarray[i].ToString().Equals("["))
				{
					i++;
					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;
						if (array_option())
						{
							return true;
						}
					}
				}

			}

			return false;
		}

		bool ifloopbody4()
		{

			if (tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("(") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const") || tokenarray[i].ToString().Equals("IncDec") || tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("."))
			{
				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (object_option())
					{

						return true;

					}
				}
				else if (tokenarray[i].ToString().Equals("("))
				{
					i++;
					if (parameters())
					{

						if (tokenarray[i].ToString().Equals(")"))
						{
							i++;
							if (ifloopbody5())
							{
								if (tokenarray[i].ToString().Equals("%"))
								{
									i++;
									return true;
								}

							}
						}
					}
				}
				else
					if (tokenarray[i].ToString().Equals("="))
				{
					i++;
					if (OE())
					{
						if (tokenarray[i].ToString().Equals("%"))
						{
							i++;
							return true;
						}
					}
				}
				else if (choice2())
				{

					if (tokenarray[i].ToString().Equals("%"))
					{
						i++;

						return true;

					}

				}

				/*	else if (tokenarray[i].ToString().Equals("IncDec"))
					{
						i++;

						if (tokenarray[i].ToString().Equals("%"))
						{
							i++;
							return true;

						}
					}
					*/
			}

			return false;
		}

		bool ifloopbody5()
		{

			if (tokenarray[i].ToString().Equals("continue") || tokenarray[i].ToString().Equals("break") || tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("to") || tokenarray[i].ToString().Equals("if") || tokenarray[i].ToString().Equals("%"))
			{

				if (tokenarray[i].ToString().Equals("="))
				{
					i++;

					if (OE())
					{

						return true;

					}
				}

				/*        else if()  null k lie
				  {
					return true;
				  }*/
				else if (tokenarray[i].ToString().Equals("%")) //.null k lie
				{
					return true;
				}
			}




			return false;

		}

		bool Main()
		{

			if (tokenarray[i].ToString().Equals("main"))
			{

				if (tokenarray[i].ToString().Equals("main"))
				{
					//Console.WriteLine(tokenarray[i].ToString() + " 11yaar");
					i++;

					if (tokenarray[i].ToString().Equals("("))
					{
						//		Console.WriteLine(tokenarray[i].ToString() + " 11yaar");
						i++;
						if (tokenarray[i].ToString().Equals(")"))
						{
							//		Console.WriteLine(tokenarray[i].ToString() + " 11yaar");
							i++;
							if (tokenarray[i].ToString().Equals("{"))
							{
								//		Console.WriteLine(tokenarray[i].ToString() + " 11yaar");
								i++;
								if (mstbody())
								{
									if (tokenarray[i].ToString().Equals("}"))
									{
										//			Console.WriteLine(tokenarray[i].ToString() + " 11yaar");
										//			Console.WriteLine(i);
										i++;
										return true;

									}

								}

							}

						}

					}
				}


			}

			return false;
		}

		bool AM()
		{
			if (tokenarray[i].ToString().Equals("AM") || tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID"))
			{

				if (tokenarray[i].ToString().Equals("AM"))
				{


					i++;

					return true;

				}
				//. 	else if  (tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID"))//. null k lie
				{
					//.	 	return true;
				}
				/*        else if()  null k lie
				  {
					return true;
				  }*/

			}


			return false;
		}

		bool Static()
		{

			if (tokenarray[i].ToString().Equals("static") || tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID"))
			{
				if (tokenarray[i].ToString().Equals("static"))
				{
					i++;
					return true;

				}
				if (tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID")) // null k lie
				{

					return true;
				}
				/*        else if()  null k lie
				 {
				   return true;
				 }*/

			}


			return false;
		}

		bool Extends()
		{
			if (tokenarray[i].ToString().Equals("extends") || tokenarray[i].ToString().Equals("{"))
			{
				if (tokenarray[i].ToString().Equals("extends"))
				{
					i++;
					if (tokenarray[i].ToString().Equals("ID"))
					{
						 
						if (lookupclass(tokenvalue[i].ToString(), CTable))
						{
							classtable.Extends = tokenvalue[i].ToString();
						//	Console.WriteLine("Class {0}  Found !", tokenvalue[i].ToString());
						}
						else
						{
							Console.WriteLine("Class {0} Not Found !", tokenvalue[i].ToString());
							return false;
						}

						i++;
						return true;

					}

				}
				else if (tokenarray[i].ToString().Equals("{"))   //null k lie
				{
					classtable.Extends = "object";
					return true;
				}
				 

			}


			return false;
		}


		bool Return()
		{
			if (tokenarray[i].ToString().Equals("return"))
			{
				i++;
				if (Return1())
				{

					return true;

				}

			}


			return false;
		}

		bool Return1()
		{

			if (tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const"))
			{
				if (tokenarray[i].ToString().Equals("%"))
				{
					i++;
					return true;
				}
				if (OE())
				{
					compat_type.Operator = "return";
					compat_type.type_1 = tempreturn;
					if (compat_type.compatibility_type(compat_type.type_1, compat_type.type_2, compat_type.Operator) 
						==  false)
					{
						Console.WriteLine("\nReturn type not matched !   \n");
						return false;
					}
					if (tokenarray[i].ToString().Equals("%"))
					{
						i++;
						return true;
					}
				}

			}

			return false;
		}

		bool arguments()
		{
			if (tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals(")"))
			{
				if (tokenarray[i].ToString().Equals("DT"))
				{
					
					functiondatatable.Type= tokenvalue[i].ToString();
					wait = functiondatatable.Type;
					i++;

					if (Return_choice())
					{

						if (tokenarray[i].ToString().Equals("ID"))
						{
							functiondatatable.Name = tokenvalue[i].ToString();
							functiondatatable.Scope = currentscope;
							if (insertfunctiondata(functiondatatable, currentscope))
							{
								functiontable.Add(new FunctionTable(functiondatatable));
							//	Console.WriteLine("added argument "+functiondatatable.Name);
							}
							else
							{
								Console.WriteLine("Redeclaration error !");
								return false;
							}
							i++;

							if (argument1())
							{
								return true;


							}
						}

					}
				}
				else if (tokenarray[i].ToString().Equals("ID"))
				{
					wait= tokenvalue[i].ToString();
				//	wait = functiondatatable.Name;
					//Console.WriteLine("asdasdsd jsadjkdsjjkd" + tokenvalue[i].ToString());
					if (lookupclass(wait, CTable) == false)
					{
						Console.WriteLine("Class undeclared !");
						return false;
					}
					i++;

					if (Return_choice())
					{

						if (tokenarray[i].ToString().Equals("ID"))
						{
							functiondatatable.Name = tokenvalue[i].ToString();
							functiondatatable.Scope = currentscope;
							functiondatatable.Type = wait;
							if (insertfunctiondata(functiondatatable, currentscope))
							{
								functiontable.Add(new FunctionTable(functiondatatable));
								 
							}
							else
							{
								Console.WriteLine("Redeclaration error !");
								return false;
							}
							i++;

							if (argument1())
							{
								return true;


							}
						}

					}
				}
				/*        else if()  null k lie
					 {
					   return true;
					 }*/
				else if (tokenarray[i].ToString().Equals(")"))
				{
					return true;
				}


			}



			return false;
		}

		bool argument1()
		{
			if (tokenarray[i].ToString().Equals(",") || tokenarray[i].ToString().Equals(")"))
			{

				if (tokenarray[i].ToString().Equals(","))
				{
					i++;

					if (argument2())
					{
						return true;
					}
				}
				/*        else if()  null k lie
					 {
					   return true;
					 }*/
				else if (tokenarray[i].ToString().Equals(")"))
				{
					//parameterlist = parameterlist + functiondatatable.Type;
					return true;
				}

			}

			return false;
		}
		bool argument2()
		{

			if (tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID"))
			{
				if (tokenarray[i].ToString().Equals("DT"))
				{
					parameterlist = parameterlist + ",";
					functiondatatable.Type = tokenvalue[i].ToString();
					wait = functiondatatable.Type;
					i++;

					if (Return_choice())
					{

						if (tokenarray[i].ToString().Equals("ID"))
						{
							functiondatatable.Name = tokenvalue[i].ToString();
							functiondatatable.Scope = currentscope;
							if (insertfunctiondata(functiondatatable, currentscope))
							{
								functiontable.Add(new FunctionTable(functiondatatable));
							//	Console.WriteLine("added argument " + functiondatatable.Name);
							}
							else
							{
								Console.WriteLine("Redeclaration error !");
								return false;
							}
							i++;

							if (argument1())
							{
								return true;


							}
						}

					}
				}
				else if (tokenarray[i].ToString().Equals("ID"))
				{
					parameterlist = parameterlist + ",";


					wait = classdatatable.Name;
					wait= tokenvalue[i].ToString();
					if (lookupclass(wait, CTable) == false)
					{
						Console.WriteLine("Class undeclared !");
						return false;
					}
					i++;

					if (Return_choice())
					{

						if (tokenarray[i].ToString().Equals("ID"))
						{
							functiondatatable.Name = tokenvalue[i].ToString();
							functiondatatable.Scope = currentscope;
							functiondatatable.Type = wait;
							if (insertfunctiondata(functiondatatable, currentscope))
							{
								functiontable.Add(new FunctionTable(functiondatatable));

							}
							else
							{
								Console.WriteLine("Redeclaration error !");
								return false;
							}

							i++;

							if (argument1())
							{
								return true;


							}
						}

					}
				}

			}


			return false;
		}

		bool Return_choice()
		{

			if (tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("ID"))
			{
				if (arr())
				{
					return true;


				}
				/*        else if()  null k lie
			  {
				return true;
			  }*/
				else if (tokenarray[i].ToString().Equals("ID")) //null k lie
				{
					parameterlist = parameterlist+wait;
					return true;
				}
			}
			return false;
		}


		bool arr()
		{
			if (tokenarray[i].ToString().Equals("["))
			{

				if (tokenarray[i].ToString().Equals("["))
				{
					i++;

					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;

						if (arr1())
						{
							return true;


						}
					}
				}

			}

			return false;
		}

		bool arr1()
		{

			if (tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("ID"))
			{
				if (tokenarray[i].ToString().Equals("["))
				{
					i++;

					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;

						return true;

					}
				}

				else if (tokenarray[i].ToString().Equals("ID")) //null k lie
				{
					parameterlist = parameterlist + functiondatatable.Type+"[]";
					return true;
				}


				/*        else if()  null k lie
			 {
			   return true;
			 }*/

			}

			return false;
		}

		bool init()
		{

			if (tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals(","))
			{
				if (tokenarray[i].ToString().Equals("="))
				{
					compat_type.Operator = tokenvalue[i].ToString();
					i++;

					if (OE())
					{
						classdatatable.Assigned = true;
						if (!(compat_type.compatibility_type(compat_type.type_1, compat_type.type_2,
							compat_type.Operator)))
						{
							Console.WriteLine("\nCompatibility error\n");
							return false;
						}
						else
							return true;

					}
				}

				else if (tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals(","))
				{
					classdatatable.Assigned = false;
					return true;
				}
				/*        else if()  null k lie
			{
			  return true;
			}*/
			}

			return false;
		}

		bool List()
		{

			if (tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals(","))
			{
				if (tokenarray[i].ToString().Equals(","))
				{
					i++;

					if (tokenarray[i].ToString().Equals("ID"))
					{
						i++;
						if (init())
						{
							if (List())
							{
								return true;

							}

						}

					}
				}
				else if (tokenarray[i].ToString().Equals("%"))
				{
					i++;
					return true;
				}

			}

			return false;
		}


		bool array_option()
		{


			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("["))
			{

				if (tokenarray[i].ToString().Equals("ID"))
				{

					i++;

					if (array_option1())
					{
						return true;

					}


				}
				else if (tokenarray[i].ToString().Equals("["))
				{

					i++;

					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;
						if (tokenarray[i].ToString().Equals("ID"))
						{

							i++;
							if (array_option2())
							{
								return true;

							}

						}

					}
				}


			}
			return false;
		}

		bool array_option1()
		{


			if (tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("="))
			{

				if (tokenarray[i].ToString().Equals("="))
				{
					i++;
					if (array())
					{

						return true;

					}

				}
				else if (tokenarray[i].ToString().Equals("%"))
				{
					classdatatable.Assigned = false;
					int position = getcurrentclass();
					Console.WriteLine("\n\npostion " + position);
					if (insertclassdata(classdatatable, CTable[position].dataTable))
					{
						CTable[position].dataTable.Add(new ClassData(classdatatable));

						CTable[position].dataTable[CTable[position].dataTable.Count - 1].showtable();
					}
					else
					{
						Console.WriteLine("Variable Redeclaration Error\n");
						return false;
					}
					i++;

					i++;
					return true;

				}
			}

			return false;
		}

		bool array()
		{
			if (tokenarray[i].ToString().Equals("{") || tokenarray[i].ToString().Equals("new"))
			{
				if (tokenarray[i].ToString().Equals("{"))
				{

					i++;
					if (OE())
					{
						if (parameter1())
						{
							if (tokenarray[i].ToString().Equals("}"))
							{
								i++;

								if (tokenarray[i].ToString().Equals("%"))
								{
									i++;


									return true;
								}
							}

						}

					}

				}
				else if (tokenarray[i].ToString().Equals("new"))
				{
					i++;
					if (tokenarray[i].ToString().Equals("DT"))
					{
						i++;
						if (tokenarray[i].ToString().Equals("["))
						{
							i++;
							if (OE())
							{
								if (tokenarray[i].ToString().Equals("]"))
								{
									i++;

									if (array1())
									{
										return true;
									}
								}

							}

						}

					}

				}
			}

			return false;
		}

		bool array1()
		{

			if (tokenarray[i].ToString().Equals("{") || tokenarray[i].ToString().Equals("%"))
			{
				if (tokenarray[i].ToString().Equals("%"))
				{
					i++;

					return true;

				}

				else if (tokenarray[i].ToString().Equals("{"))
				{
					i++;

					if (OE())
					{

						if (parameter1())
						{
							if (tokenarray[i].ToString().Equals("}"))
							{
								i++;
								if (tokenarray[i].ToString().Equals("%"))
								{
									i++;
									return true;
								}
							}
						}
					}
				}
			}

			return false;
		}


		bool array_option2()
		{

			if (tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("="))
			{

				if (tokenarray[i].ToString().Equals("%"))
				{
					i++;

					return true;

				}

				else if (tokenarray[i].ToString().Equals("="))
				{

					i++;

					if (array2())
					{

						return true;
					}
				}

			}

			return false;
		}

		bool array2()
		{
			if (tokenarray[i].ToString().Equals("new") || tokenarray[i].ToString().Equals("{"))
			{
				if (tokenarray[i].ToString().Equals("new"))
				{

					i++;

					if (tokenarray[i].ToString().Equals("DT"))
					{
						i++;
						if (tokenarray[i].ToString().Equals("["))
						{

							i++;
							if (OE())
							{

								if (tokenarray[i].ToString().Equals("]"))
								{
									i++;
									if (tokenarray[i].ToString().Equals("["))
									{
										i++;
										if (OE())
										{
											if (tokenarray[i].ToString().Equals("]"))
											{

												i++;
												if (array3())
												{

													return true;
												}
											}


										}
									}
								}


							}
						}

					}
				}
				else if (tokenarray[i].ToString().Equals("{"))
				{
					i++;
					if (tokenarray[i].ToString().Equals("{"))
					{
						i++;
						if (OE())
						{

							if (parameter2())
							{
								if (tokenarray[i].ToString().Equals("}"))
								{
									i++;
									if (moreparameter())
									{
										if (tokenarray[i].ToString().Equals("}"))
										{
											i++;
											if (tokenarray[i].ToString().Equals("%"))
											{
												i++;
												return true;
											}
										}
									}
								}
							}
						}


					}
				}


			}
			return false;

		}

		bool moreparameter()
		{

			if (tokenarray[i].ToString().Equals(",") || tokenarray[i].ToString().Equals("}"))
			{
				if (tokenarray[i].ToString().Equals(","))
				{
					i++;
					if (tokenarray[i].ToString().Equals("{"))
					{
						i++;
						if (OE())
						{
							if (parameter2())
							{
								if (tokenarray[i].ToString().Equals("}"))
								{
									i++;
									if (moreparameter())
									{
										return true;
									}

								}

							}

						}
					}
				}

				else if (tokenarray[i].ToString().Equals("}")) //null k lie
				{
					return true;
				}
				/*        else if()  null k lie
				  {
					return true;
				  }*/

			}


			return false;
		}

		bool new_array()
		{

			if (array_option1())
			{
				return true;
			}
			return false;

		}


		bool array3()
		{
			if (tokenarray[i].ToString().Equals(",") || tokenarray[i].ToString().Equals("{"))
			{

				if (tokenarray[i].ToString().Equals("%"))
				{
					i++;
					return true;
				}
				else if (tokenarray[i].ToString().Equals("{"))
				{
					i++;
					if (tokenarray[i].ToString().Equals("{"))
					{
						i++;
						if (OE())
						{

							if (parameter2())
							{


								if (tokenarray[i].ToString().Equals("}"))
								{
									i++;

									if (moreparameter())
									{

										if (tokenarray[i].ToString().Equals("}"))
										{
											i++;
											if (tokenarray[i].ToString().Equals("%"))
											{
												i++;
												return true;
											}
										}
									}
								}
							}
						}


					}
				}
			}

			return false;
		}

		bool parameter2()
		{

			if (tokenarray[i].ToString().Equals(","))
			{
				i++;
				if (OE())
				{
					return true;

				}
			}
			else if (tokenarray[i].ToString().Equals("}")) //null k lie
			{
				return true;

			}
			return false;
		}
		bool parameter1()
		{

			if (tokenarray[i].ToString().Equals(","))
			{

				if (tokenarray[i].ToString().Equals(","))
				{
					i++;
					if (OE())
					{
						if (parameter1())
						{
							return true;

						}

					}
				}

				/*        else if()  null k lie
					 {
					   return true;
					 }*/

			}
			else if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals(")"))// null k lie
			{
				//Console.WriteLine("asd " + tokenarray[i].ToString());
				//	Console.WriteLine("asdasd");
				return true;
			}
			return false;
		}

		bool parameter_option()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const") || tokenarray[i].ToString().Equals(")"))
			{

				if (OE())
				{

					if (parameter1())
					{

						return true;

					}

				}
				else if (tokenarray[i].ToString().Equals(")")) //null k lie
				{
					return true;
				}
				/*        else if()  null k lie
				  {
					return true;
				  }*/


			}
			return false;
		}

		bool object_option()
		{

			if (tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("%"))
			{

				if (tokenarray[i].ToString().Equals("%"))
				{
					i++;
					return true;
				}


				else if (tokenarray[i].ToString().Equals("="))
				{
					i++;
					if (tokenarray[i].ToString().Equals("new"))
					{
						i++;
						if (tokenarray[i].ToString().Equals("ID"))
						{
							i++;
							if (tokenarray[i].ToString().Equals("("))
							{
								i++;
								if (parameter_option())
								{
									if (tokenarray[i].ToString().Equals("("))
									{
										i++;
										if (tokenarray[i].ToString().Equals("%"))
										{
											i++;
											return true;
										}
									}

								}
							}
						}
					}
				}
			}



			return false;
		}
		bool parameters()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const") || tokenarray[i].ToString().Equals(")"))
			{
				if (OE())
				{
					if (parameter1())
					{
						return true;

					}

				}

				else if (tokenarray[i].ToString().Equals(")")) //. null k lie
				{
					return true;
				}
				/*        else if()  null k lie
				  {
					return true;
				  }*/


			}
			return false;
		}

		bool choice2()
		{


			if (tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals(".") || tokenarray[i].ToString().Equals("IncDec"))
			{


				if (arr2())
				{


					if (choice1())
					{
						return true;

					}

				}
				else if (tokenarray[i].ToString().Equals("."))
				{

					i++;
					if (tokenarray[i].ToString().Equals("ID"))
					{

						i++;

						if (F1())
						{

							return true;

						}
					}
				}
				else if (tokenarray[i].ToString().Equals("IncDec"))
				{

					i++;

					return true;

				}

			}

			return false;
		}

		bool arr2()
		{


			if (tokenarray[i].ToString().Equals("["))
			{

				i++;

				if (OE())
				{


					if (tokenarray[i].ToString().Equals("]"))
					{
						i++;
						if (arr3())
						{
							return true;
						}
					}
				}
			}


			return false;

		}

		bool arr3()
		{


			if (tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("."))
			{
				if (tokenarray[i].ToString().Equals("["))
				{
					i++;
					if (OE())
					{

						if (tokenarray[i].ToString().Equals("]"))
						{
							i++;

							return true;

						}
					}
				}
				/*        else if()  null k lie
				  {
					return true;
				  }*/
				else if (tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("."))// null k lie

				{
					return true;
				}

			}

			return false;

		}


		bool choice3()
		{
			//Console.WriteLine("asd " + tokenarray[i-1].ToString());

			if (tokenarray[i].ToString().Equals("."))
			{

				i++;

				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;

					if (OE())
					{
						return true;

					}
				}
			}
			/*
					   else if ((tokenarray[i].ToString().Equals("MDM") || tokenarray[i].ToString().Equals("PM") || tokenarray[i].ToString().Equals("ROP") || tokenarray[i].ToString().Equals("&&") || tokenarray[i].ToString().Equals("||")))
					   {

						   if (OE())
						   {

							   return true;

						   }
					   }
				   */
			else if (OE())
			{
				//	Console.WriteLine("asd");
				return true;

			}
			else if (tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%"))// null k lie)
			{
				//	Console.WriteLine("asd " + tokenarray[i].ToString());
				return true;

			}

			return false;
		}


		bool choice1()
		{

			//.Console.WriteLine("asd");
			if (tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("."))
			{

				if (tokenarray[i].ToString().Equals("="))
				{
					i++;
					if (OE())
					{
						return true;

					}
				}
			}
			else if (tokenarray[i].ToString().Equals("."))
			{

				i++;
				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;

					if (F1())
					{
						return true;

					}
				}
			}



			else if (tokenarray[i].ToString().Equals("MDM") || tokenarray[i].ToString().Equals("PM") || tokenarray[i].ToString().Equals("ROP") || tokenarray[i].ToString().Equals("&&") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))// null k lie
			{

				return true;
			}

			return false;
		}

		bool loop()
		{
			if (tokenarray[i].ToString().Equals("to"))
			{
				i++;
				if (tokenarray[i].ToString().Equals("("))
				{
					i++;
					if (condition())
					{

						if (tokenarray[i].ToString().Equals(")"))
						{
							i++;
							if (tokenarray[i].ToString().Equals(","))
							{
								i++;
								if (tokenarray[i].ToString().Equals("("))
								{
									i++;
									if (condition2())
									{
										if (tokenarray[i].ToString().Equals(")"))
										{
											i++;
											if (tokenarray[i].ToString().Equals("{"))
											{

												i++;
												if (mstifloopbody())
												{

													if (tokenarray[i].ToString().Equals("}"))
													{
														i++;
														return true;
													}
												}
											}
										}
									}
								}
							}
						}

					}
				}
			}
			return false;
		}

		bool condition()
		{

			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const") || tokenarray[i].ToString().Equals(")"))
			{
				if (OE())
				{
					return true;
				}
				else if (tokenarray[i].ToString().Equals(")")) //null k lie
				{
					return true;
				}
				/*        else if()  null k lie
				 {
				   return true;
				 }*/
			}

			return false;
		}

		bool condition2()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals(")"))
			{

				if (tokenarray[i].ToString().Equals("ID"))
				{
					i++;
					if (condition3())
					{
						return true;
					}
				}
				else if (tokenarray[i].ToString().Equals(")")) //null k lie
				{
					return true;
				}
				/*        else if()  null k lie
				 {
				   return true;
				 }*/

			}
			return false;
		}
		bool condition3()
		{


			if (tokenarray[i].ToString().Equals("IncDec") || tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals("("))
			{

				if (tokenarray[i].ToString().Equals("IncDec"))
				{
					i++;
					if (tokenarray[i].ToString().Equals("%"))
					{
						i++;
						return true;
					}
				}
				else if (F1())
				{


					if (tokenarray[i].ToString().Equals("%"))
					{
						i++;
						return true;
					}

				}

			}

			return false;
		}

		bool if_else()
		{
			if (tokenarray[i].ToString().Equals("if"))
			{

				i++;
				if (tokenarray[i].ToString().Equals("("))
				{
					i++;
					//.Console.WriteLine("asd " + tokenarray[i].ToString());
					if (OE())
					{

						if (tokenarray[i].ToString().Equals(")"))
						{
							Ti = createtemp();

							Li = createlabel();
							output=output+ "\n"+Ti+"=" +hold+"\nif("+Ti+"==false) Jmp "+ Li+ "\n\n";
							hold = "";
							i++;

							if (tokenarray[i].ToString().Equals("{"))
							{
								i++;
								if (mstifloopbody())
								{
									if (tokenarray[i].ToString().Equals("}"))
									{
										i++;
										Li1 = createlabel();
										output = output + "Jmp " + Li1+ "\n";
										if (tokenarray[i].ToString().Equals("else"))
										{

											output = output + "\n" + Li + ":\n\n";
											i++;
											if (tokenarray[i].ToString().Equals("{"))
											{
												i++;
												if (mstifloopbody())
												{
													if (tokenarray[i].ToString().Equals("}"))
													{
														i++;
														//Li = createlabel();
														 output = output + "\n" +Li1 + ":\n\n";

														return true;
													}
												}
											}

											
										}
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		bool OE()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const"))
			{


				if (AE())
				{

					if (OEdash())
					{

						return true;
					}
				}

			}


			return false;
		}

		bool OEdash()
		{
			if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))
			{
				if (tokenarray[i].ToString().Equals("||"))
				{
					i++;
					if (AE())
					{
						if (OEdash())
						{
							return true;
						}
					}
				}


				else if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))// null k lie
				{
					compat_type.type_1 = classdatatable.Type;
					return true;
				}

				/*        else if()  null k lie
				   {
					 return true;
				   }*/

			}

			return false;
		}
		bool AE()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const"))
			{

				if (RE())
				{

					if (AEdash())
					{


						return true;
					}
				}
			}


			return false;
		}
		bool AEdash()
		{
			if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals("&&") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))
			{

				if (tokenarray[i].ToString().Equals("&&"))
				{
					i++;
					if (RE())
					{
						if (AEdash())
						{
							return true;
						}
					}
				}
				else if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))// null k lie
				{
					compat_type.type_1 = classdatatable.Type;
					return true;
				}
				/*        else if()  null k lie
				 {
				   return true;
				 }*/

			}
			return false;
		}
		bool RE()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const"))
			{

				if (E())
				{

					if (REdash())
					{


						return true;
					}
				}

			}

			return false;
		}
		bool REdash()
		{
			if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals("ROP") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals("&&") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))
			{

				if (tokenarray[i].ToString().Equals("ROP"))
				{
					 
					{ hold = hold + tokenvalue[i - 1].ToString() + tokenvalue[i].ToString();}
					i++;
					if (E())
					{
						if (REdash())
						{
							return true;
						}
					}
				}
				else if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals("&&") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))// null k lie
				{
					compat_type.type_1 = classdatatable.Type;
					return true;
				}
				/*        else if()  null k lie
				  {
					return true;
				  }*/

			}
			return false;
		}
		bool E()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const"))
			{

				if (T())
				{


					if (Edash())
					{

						return true;
					}
				}
			}


			return false;
		}
		bool Edash()
		{
			if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals("PM") || tokenarray[i].ToString().Equals("ROP") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals("&&") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))
			{

				if (tokenarray[i].ToString().Equals("PM"))
				{

					i++;

					if (T())
					{

						if (Edash())
						{

							return true;
						}
					}
				}
				else if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals("ROP") || tokenarray[i].ToString().Equals("&&") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))// null k lie
				{
					compat_type.type_1 = classdatatable.Type;
					return true;
				}
				/*        else if()  null k lie
				 {
				   return true;
				 }*/
			}


			return false;
		}

		bool T()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const"))
			{

				if (F())
				{

					if (Tdash())
					{


						return true;
					}
				}

			}

			return false;
		}

		bool Tdash()
		{

			if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals("MDM") || tokenarray[i].ToString().Equals("PM") || tokenarray[i].ToString().Equals("ROP") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals("&&") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))
			{

				if (tokenarray[i].ToString().Equals("MDM"))
				{
					i++;
					if (F())
					{

						if (Tdash())
						{
							return true;
						}
					}
				}

				else if (tokenarray[i].ToString().Equals("}") || tokenarray[i].ToString().Equals("PM") || tokenarray[i].ToString().Equals("ROP") || tokenarray[i].ToString().Equals("&&") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))// null k lie
				{

					compat_type.type_1 = classdatatable.Type;
					return true;
				}
				/*        else if()  null k lie
				  {
					return true;
				  }*/

			}

			return false;
		}

		bool F()
		{
			if (tokenarray[i].ToString().Equals("ID") || tokenarray[i].ToString().Equals("!") || tokenarray[i].ToString().Equals("truefalse") || tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const"))
			{

				if (Const())
				{

					return true;

				}
				else if (tokenarray[i].ToString().Equals("ID"))
				{
					if(hold.Contains("=="))
					hold = hold + tokenvalue[i].ToString();
					i++;

					if (F1())
					{

						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("!"))
				{
					i++;
					if (F())
					{
						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("truefalse"))
				{
					i++;

					return true;

				}

			}

			return false;
		}


		bool F1()
		{

			//	if (tokenarray[i].ToString().Equals(".") || tokenarray[i].ToString().Equals("MDM") || tokenarray[i].ToString().Equals("PM") || tokenarray[i].ToString().Equals("ROP") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals("&&") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("[") || tokenarray[i].ToString().Equals(",") || tokenarray[i].ToString().Equals("(") || tokenarray[i].ToString().Equals("=") || tokenarray[i].ToString().Equals("IncDec"))
			{

				if (tokenarray[i].ToString().Equals("="))
				{

					i++;

					if (OE())
					{
						return true;
					}

				}
				else
					if (choice2())
				{

					return true;
				}

				else if (tokenarray[i].ToString().Equals("("))
				{

					i++;
					if (parameters())
					{

						if (tokenarray[i].ToString().Equals(")"))
						{
							i++;

							if (choice3())
							{

								return true;
							}
						}
					}

				}
				else if (tokenarray[i].ToString().Equals("IncDec"))
				{
					i++;


					//.if (choice1())
					{
						return true;
					}

				}
				else if (tokenarray[i].ToString().Equals("MDM") || tokenarray[i].ToString().Equals("PM") || tokenarray[i].ToString().Equals("ROP") || tokenarray[i].ToString().Equals("&&") || tokenarray[i].ToString().Equals("||") || tokenarray[i].ToString().Equals(")") || tokenarray[i].ToString().Equals("%") || tokenarray[i].ToString().Equals("]") || tokenarray[i].ToString().Equals(","))// null k lie
				{

					return true;
				}

			}


			return false;
		}

		bool Const()
		{
			if (tokenarray[i].ToString().Equals("int_const") || tokenarray[i].ToString().Equals("float_const") || tokenarray[i].ToString().Equals("char_const") || tokenarray[i].ToString().Equals("string_const"))
			{
				//Console.WriteLine("here");
				if (tokenarray[i].ToString().Equals("int_const"))
				{

					 
					compat_type.type_2 = "number";

					i++;

					return true;
				}
				else if (tokenarray[i].ToString().Equals("char_const"))
				{
					 
					compat_type.type_2 = "alphabet";

					i++;
					return true;
				}
				if (tokenarray[i].ToString().Equals("float_const"))
				{
					 
					compat_type.type_2 = "decimal";

					i++;
					return true;
				}
				if (tokenarray[i].ToString().Equals("string_const"))
				{
				 
					compat_type.type_2 = "sentence";

					i++;
					return true;
				}

			}

			return false;
		}

		bool DT()
		{

			if (tokenarray[i].ToString().Equals("DT") || tokenarray[i].ToString().Equals("ID"))
			{

				if (tokenarray[i].ToString().Equals("DT"))
				{

					i++;
					return true;
				}
				else if (tokenarray[i].ToString().Equals("ID"))
				{

					i++;
					Console.WriteLine("asd1 " + tokenarray[i].ToString());
					return true;
				}
			}

			return false;
		}



	}


}
