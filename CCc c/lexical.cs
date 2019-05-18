using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CCc_c
{
    class lexical
    {
        String temp;
        bool stop;
        public lexical()
        {
            stop = false;

        }

        public String[] separator(String check,bool chk )
        {
            int count = 0, space = -1;
            bool q = false;
            ArrayList al = new ArrayList();
            check = check.Trim();
          char[] ch = check.ToCharArray();
            int index = 0;
            index = check.IndexOf("**");
            for (int u = 0; u < ch.Length; u++)
            {

            /*    if (ch[u] == '\\')
                {
                    if (u + 1 != ch.Length)
                    {
                        if (ch[u + 1] == '*')
                        {
                            int j = u + 2;
                            temp = "";
                            for (int f1 = space + 1; f1 < u; f1++)
                            {
                                temp = temp + ch[f1].ToString();
                            }
                            //    Console.WriteLine(temp);
                            if (temp != "")
                                al.Add(temp);
                            temp = "";

                            String t1 = ch[u].ToString() + ch[u + 1].ToString();

                            temp = "";

                            while (j != ch.Length)
                            {
                                temp = temp + ch[j].ToString();

                                if(ch[j]=='*')
                                {
                                    if(j+1!=ch.Length)
                                    {
                                        if(ch[j+1]=='\\')
                                        {
                                            u = j + 1;
                                            space = u;
                                            break;
                                        }
                                    }
                                }


                                if (j + 1 == ch.Length)
                                {
                                    break;
                                }
                                else
                                {
                                    j++;
                                }

                               

                            }
                            if (temp != "")
                            {
                                //  Console.WriteLine("asd " + temp);
                                //   al.Add(t1+temp);
                                u = ch.Length - 1;
                                space = u;
                            }
                        }
                    }
                }

                */
                if (ch[u]=='\\')
                {
                    if(u+1!=ch.Length)
                    {
                        if(ch[u+1]=='\\')
                        {
                            int j = u + 2;
                            temp = "";
                            for(int f1=space+1;f1< u;f1++)
                            {
                                temp = temp + ch[f1].ToString();
                            }
                            //    Console.WriteLine(temp);
                            if (temp != "")
                                al.Add(temp);
                            temp = "";

                            String t1 = ch[u].ToString() + ch[u + 1].ToString();
                  
                                temp = "";
                                while (j != ch.Length)
                                {
                                    temp = temp + ch[j].ToString();

                                    if (j + 1 == ch.Length)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        j++;
                                    }

                                }
                       if(temp!="")
                            {
                              //  Console.WriteLine("asd " + temp);
                             //   al.Add(t1+temp);
                               u = ch.Length-1;
                                space = u;
                            }
                            }
                    }
                }


                if (ch[u] == '*')
                {

                    if (u + 1 != ch.Length)
                    {

                        if (ch[u + 1] == '*')
                        {

                            int j = u + 2;
                            temp = "";
                            for (int f1 = space + 1; f1 < u; f1++)
                            {
                                temp = temp + ch[f1].ToString();
                            }
                            //    Console.WriteLine(temp);
                            if(temp!="")
                            al.Add(temp);
                            temp = "";
                            space = u -1;


                            String t1 = ch[u].ToString() + ch[u + 1].ToString();
                            if (j != ch.Length)
                            {
                                //                             Console.WriteLine(j);
                                //    Console.ReadLine();
                                temp = "";
                         
                                while (ch[j] != '*')
                                {
                                    temp = temp + ch[j].ToString();

                                    if (j + 1 == ch.Length)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        j++;
                                    }

                                }

                                if (ch[j] == '*')
                                {
                                    if (j + 1 != ch.Length)
                                    {
                                        if (ch[j + 1] == '*' && j + 1 != ch.Length)
                                        {
                                            // Console.WriteLine(ch[j+1].ToString());
                                            temp = t1 + temp + ch[j].ToString() + ch[j + 1].ToString();
                                            //       Console.WriteLine(temp);
                                            if (temp != "")
                                                al.Add(temp);
                                            if (temp.Contains(" "))
                                            {
                                                q = true;

                                            }
                                            u = j;
                                            space = u+1;
                                            temp = "";
                                        }
                                        else
                                        {
                                            

                                        }
                                    }

                                }
                                else
                                {
                              
                                }
                            }



                        }
                        else
                        {
                            /*       // u = u + 1;
                             //       space = u ;
                                    temp = "";


                                    int j = u+1;
                                    while (ch[j] != '*'||!(Char.IsWhiteSpace(ch[j])) )
                                    {

                                            temp = temp + ch[j].ToString();

                                        if (j + 1 == ch.Length|| Char.IsWhiteSpace(ch[j]))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            j++;
                                        }
                                      //  Console.WriteLine(ch[j].ToString() + " vv");
                                    }
                                  //  al.Add(ch[u].ToString());
                                    if (temp!="")
                                    {
                                        al.Add(ch[u].ToString());

                                        //  Console.WriteLine(temp + "dfdfdfd");
                                        al.Add(temp);
                                        temp = "";

                                    }

                                    u = j;
                                    space = u;
                                      */

                            //   Console.WriteLine(ch[u].ToString() + " vv");
                        }
                    }
                    else
                    {

                    }
                }

                if (ch[u] == '^')
                {


                    if (u + 2 != ch.Length)
                    {
                        int z = u;
                        int j = u+1;
                        // Console.WriteLine("asd " + (z+1));
                        
                            /* for (int z1 = space + 1; z1 < u; z1++)
                             {
                                 temp = temp + ch[z1].ToString();
                             }
                             space = u;
                             al.Add(temp);
                             temp = "";*/
                            temp = "";
                            String t1 = ch[u].ToString();
                            while (ch[j] != '^')
                            {
                                temp = temp + ch[j].ToString();

                                if (j + 1 == ch.Length)
                                {
                                temp = t1 + temp + ch[j].ToString();
                                al.Add(temp);
                                 // Console.WriteLine(temp + "\n");
                                temp = "";
                                u = j;

                                space = u+1;
                                break;
                                }
                                else
                                {
                                    j++;
                                }

                            }
                         //   Console.WriteLine("asd " + ch[j].ToString());
                            if (ch[j] == '^')
                            {
                                
                                if (j + 1 != ch.Length)
                                {
                                         // Console.WriteLine(ch[j-1].ToString());
                                 //       temp = t1 + temp + ch[j].ToString();
                                 //   al.Add(temp);
                              //  Console.WriteLine(temp + "\n");
                          //      temp = "";
                            //        u = j;

                               //     space = j+1;

                                }

                            }
                          
                    }
                }
                    //multiple spaces   
                    // Console.WriteLine("white"+space+ch[u]);
                    if (Char.IsWhiteSpace(ch[u]) )
                      {
                    temp = "";
                       // Console.WriteLine("white"+space);
                          for (int i = space + 1; i < u; i++)
                          {
                              if (!Char.IsWhiteSpace(ch[i]))
                              {
                                  temp = temp + ch[i];
                              }
                          }
                  //  Console.WriteLine(temp + "\n");
                    space = u;
                         if(temp!="")
                         {
                        al.Add(temp);
                   //   Console.WriteLine(temp +"\n");

                             temp = "";

                         }
                      }
                       
                      if (!Char.IsWhiteSpace(ch[u]))
                      {
                          if (u + 1 == ch.Length)
                          {
                       // Console.WriteLine( space);
                    temp="";
                        for (int i = space + 1; i < u + 1; i++)
                              {

                                if (!Char.IsWhiteSpace(ch[i]))
                                  {
                                      temp = temp + ch[i];
                                  }
                              }

                        // Console.WriteLine(temp + "\n");
                        if (temp != "")
                            al.Add(temp);
                              temp = "";
                          }

                      }
                      
                      
            }
            
            String[] tempArray = (String[])al.ToArray(typeof(string));
            al.Clear();
          
            tempArray = sepEnhanced(tempArray);
            tempArray = sepFLT(tempArray);
            tempArray = opSeparator(tempArray);
            return tempArray;
        }

        public String[] sepEnhanced(String[] arr)
        {
            bool m = false,n=false;
            int c = -1;
            DFA d = new DFA();
            ArrayList a = new ArrayList();
            ArrayList try1 = new ArrayList();
            try1.AddRange(arr);
            String[] tempArray = d.punctuators("");

            int i1 =0;

            for (int i = 0; i < arr.Length; i++)
            {
              
                c = -1;
           //    Console.WriteLine("yaar " + arr[i]);
                for (int y = 0; y < tempArray.Length; y++)
                {
               //     Console.WriteLine("yaar " + tempArray[y]);
                    if (arr[i].Contains(tempArray[y]))
                    {
                        //matching(arr[i])==false
                        if (!(arr[i].Contains("**")))
                        {
                           
                          //  Console.WriteLine("yaar " + arr[i]);
                          //  try1.RemoveAt(i);
                            try1.Remove(arr[i]);
                            char[] ch = arr[i].ToCharArray();
                            for (int u = 0; u < ch.Length; u++)
                            {
                                
                                for (int g = 0; g < tempArray.Length; g++)

                                {

                                    if (ch[u].ToString() == (tempArray[g]))
                                    {
                                     //  if(stop==false)
                                        {
                                            temp = "";
                                            for (int x = c + 1; x < u; x++)
                                            {

                                                temp = temp + ch[x];
                                                // Console.WriteLine("yaar " + temp);
                                            }

                                            try
                                            {
                                                if (u + 1 != ch.Length)
                                                {
                                                    if ((ch[u] == '+' && ch[u + 1] == '+') || (ch[u] == '-' && ch[u + 1] == '-') || (ch[u] == '&' && ch[u + 1] == '&') || (ch[u] == '|' && ch[u + 1] == '|') || (ch[u] == '!' && ch[u + 1] == '=') || (ch[u] == '=' && ch[u + 1] == '=') || (ch[u] == '<' && ch[u + 1] == '=') || (ch[u] == '>' && ch[u + 1] == '='))
                                                    {
                                                    
                                                        
                                                        if (temp != "")
                                                        {
                                                            a.Add(temp);
                                                         
                                                            temp = "";
                                                        }
                                                        a.Add(ch[u].ToString() + ch[u + 1].ToString());
                                                        c = u + 1;
                                                        u = u + 1;
                                                        m = true;

                                                    }

                                                    else if ((ch[u] == '+' || ch[u] == '-' || ch[u] == '!' || ch[u] == '=' || ch[u] == '<' || ch[u] == '>' || ch[u] == '/' || ch[u] == '%') && (m != true))
                                                    {
                                                        bool f = false;

                                                        if (u > 1)
                                                        {
                                                            if (ch[u] == '+' || ch[u] == '-')
                                                            {

                                                                if (ch[u - 1] == 'e' && Char.IsDigit(ch[u - 2]))
                                                                {
                                                                    int h = u + 1;
                                                                    temp = temp + ch[u].ToString();
                                                                    while (Char.IsDigit(ch[h]))
                                                                    {
                                                                        temp = temp + ch[h].ToString();
                                                                       
                                                                        if (h + 1 == ch.Length)
                                                                        {
                                                                            a.Add(temp);
                                                                           
                                                                            temp = "";
                                                                            f = true;
                                                                            break;
                                                                        }
                                                                        else
                                                                        {
                                                                            h++;
                                                                        }
                                                                    }
                                                                    u = h;
                                                                    c = u;
                                                                }
                                                            }
                                                        }
                                                        if (temp != "")
                                                        {
                                                            a.Add(temp);

                                                          
                                                            temp = "";
                                                        }
                                                        if(f==false)
                                                        a.Add(ch[u].ToString());
                                                  
                                                        c = u;
                                                        //   m = false;

                                                    }
                                                    else if ((ch[u] != '+' && ch[u] != '-' && ch[u] != '!' && ch[u] != '&' && ch[u] != '|' && ch[u] != '=' && ch[u] != '<' && ch[u] != '>' && ch[u] != '/' && ch[u] != '%'))
                                                    {
                                                        if (temp != "")
                                                        {
                                                            a.Add(temp);
                                                         
                                                            temp = "";
                                                        }
                                                        a.Add(ch[u].ToString());
                                                        c = u;
                                                      
                                                        m = true;
                                                                                         
                                                    }
                                                    //         n = false;
                                                    m = false;
                                                }
                                                else
                                                {
                                                    if (temp != "")
                                                    {
                                                        a.Add(temp);

                                                        temp = "";
                                                    }
                                                    a.Add(ch[u].ToString());
                                                   
                                                    c = u;
                                                    // m = false;
                                                }
                                            }
                                            catch (Exception e)
                                            {

                                            }
                                        }

                                     

                                    }
                                            }

                                if (Char.IsLetterOrDigit(ch[u]))
                                {
                                    if (u + 1 == ch.Length)
                                    {
                                        temp = "";
                                        for (int o = c + 1; o < u + 1; o++)
                                        {
                                            if (!Char.IsWhiteSpace(ch[o]))
                                            {
                                                temp = temp + ch[o];
                                                //   Console.WriteLine("yaar 1  " + temp);
                                            }
                                        }
                                           
                                        if(temp!="")
                                        a.Add(temp);
                                      
                                        temp = "";
                                        c = u;
                                    }

                                }
                                else
                                {
                                    if ((ch[u] == '\"' || ch[u] == '\''  || ch[u] == '~' || ch[u] == '?' || ch[u] == '$' || ch[u] == '#' || ch[u] == '@') && u + 1 == ch.Length)
                                    {
                                        temp = "";
                                        for (int o = c + 1; o < u + 1; o++)
                                        {
                                            if (!Char.IsWhiteSpace(ch[o]))
                                            {
                                                temp = temp + ch[o];
                                                //   Console.WriteLine("yaar 1  " + temp);
                                            }
                                        }
                                        if (temp != "")
                                        {
                                            a.Add(temp);
                                        
                                            temp = "";
                                        }
                                 //       a.Add(ch[u].ToString());
                                        c = u;
                                    }
                                 //   Console.WriteLine(ch[u].ToString() + " d");
                                }
                                String[] p2 = (String[])a.ToArray(typeof(string));

                                a.Clear();
                                if (n != true)
                                {
                                    i1 = i;
                                    n = true;
                                }
                                int count = 0;
                              for (int f = p2.Length - 1; f > -1; f--)
                                    {

                                        try1.Insert(i1, p2[f]);
                                        // Console.WriteLine(i1+ " "+p1[f]);
                                        count++;
                                    }
                                    i1 = i1 + count;
                            
                               
                            }
             
                      
                        }
                    
                        y = tempArray.Length;
                    }


                    
                }

                m = false;
              
            }
        

            String[] p = (String[])try1.ToArray(typeof(string));
          //  p = opSeparator(p);
      //   p = sepFLT(p);
            return p;

        }

        public String[] sepFLT(String[] arr)
        {
            ArrayList a = new ArrayList();
            ArrayList a1 = new ArrayList();
            int c = -1,i1=0,m=-1;
            bool beforedot, afterdot = false,n =false,flo=false,nflo=false;
            String before="", after="";
            ArrayList try1 = new ArrayList();
            try1.AddRange(arr);
         
            for (int o=0;o<arr.Length;o++)
            {
                c = -1;
                char[] ch = arr[o].ToCharArray();
                if(arr[o].Contains("."))
                {
                   
                    try1.Remove(arr[o]);
                for(int i=0;i<arr[o].Length;i++)
                {
                   
                        if (ch[i] == '.')
                        {
                            m = i;
                            //  Console.WriteLine("asd "+ch[i].ToString());
                            beforedot = true;

                            if (i > 0)
                            {
                                int b = i - 1;
                                char prevFloatChar = ch[b];

                                while (!(Char.IsWhiteSpace(prevFloatChar)) && (b != ch.Length))
                                {
                                    if (!Char.IsDigit(prevFloatChar))
                                    {
                                        beforedot = false;
                                    }

                                    before = prevFloatChar + before;

                                    if (b > c + 1)
                                    {
                                        b--;
                                        prevFloatChar = ch[b];
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            int v = i + 1;

                            char nextFloatChar = ch[v];
                            if (Char.IsDigit(nextFloatChar))
                            {
                                afterdot = true;
                            }
                            if (afterdot)
                            {
                                if (nextFloatChar == 'e')
                                {
                                    afterdot = true;
                               //     stop = true;
                                }
                            }

                            while (!(Char.IsWhiteSpace(nextFloatChar)) && (v!=ch.Length))
                            {

                                after = after + nextFloatChar;

                                if (v < ch.Length - 1)
                                {
                                    v++;
                                    nextFloatChar = ch[v];
                                }
                                else
                                {
                                    break;
                                }
                            }

                            if (before.Length <= 0)
                            {
                                beforedot = true;
                            }

                    
                            if ((beforedot) && (afterdot))
                            {
                                a.Add(before + "." + after);
                              //    Console.WriteLine("asd " + before + "." + after);
                                i = v + 1;
                                c = i - 1;
                              }
                            else
                            {
                                if ((beforedot) && (!afterdot))
                                {
                                    if (before.Length > 0)
                                    {
                                        a.Add(before);
                                       //     Console.WriteLine("asd " + before);
                                        c = i - 1;
                                     
                                    }
                                }
                                else if ((!beforedot) && (afterdot))
                                {
                                    a.Add(before);
                                    //    Console.WriteLine("asd " + before );

                                    c = i - 1;
                            /*        if(after.Contains("."))
                                    {

                                    }
                                    else
                                    {
                                        a.Add("."+after);
                                        i = v - 1;
                                    }*/
                                }

                                else
                                {
                                    a.Add(before);
                                   //  Console.WriteLine("asd " + before + ".");
                                    a.Add(".");
                                    c = i;
                                  
                                }
                            }
                    
                            beforedot = false;
                            afterdot = false;
                            before = "";
                            after = "";
                        }

              
                        {
                            if (i + 1 == ch.Length)
                            {
                                if (Char.IsDigit(ch[m + 1]))
                                {
                                    m = m - 1;
                                }
                                temp = "";
                                for (int o1 = m + 1; o1 < i + 1; o1++)
                                {
                                    if (!Char.IsWhiteSpace(ch[o1]))
                                    {
                                        temp = temp + ch[o1].ToString();

                                    }
                                }

                                if (temp != "")
                                    a.Add(temp);
                                temp = "";

                            }

                        }

                    }
                    String[] p1 = (String[])a.ToArray(typeof(string));

                    a.Clear();
                    if (n != true)
                    {
                        i1 = o;
                        n = true;
                    }
                    int count = 1;
                    for (int f = p1.Length - 1; f > -1; f--)
                    {
                 //       Console.WriteLine(try1.IndexOf("++"));
                        try1.Insert(i1, p1[f]);
                 //        Console.WriteLine(i1+ " "+p1[f]);
                //        Console.WriteLine(try1.IndexOf("++"));

                        count++;
                    }
                    i1 = i1 + count;

                }

            }
            
            String[] p = (String[])try1.ToArray(typeof(string));
          // p=   opSeparator(p);

            return p;
        
    }




public String[] opSeparator(String[] arr)
        {
            bool n = false;
            DFA d = new DFA();
            String[] temparray = d.operators("");
            int c = -1,k=0;
            ArrayList a = new ArrayList();
            ArrayList try1 = new ArrayList();
            try1.AddRange(arr);
            int i1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                c = -1;
                if (!(arr[i].StartsWith("**")))
                {
                    if (arr[i].Contains("*"))
                    {
                  
                        try1.Remove(arr[i]);
                        char[] ch = arr[i].ToCharArray();
                        for (int u = 0; u < ch.Length; u++)
                        {
                            if (ch[u] == '*')
                            {
                                temp = "";
                                for(int h=c+1;h< u;h++)
                                {
                                    temp = temp + ch[h].ToString();

                                }
                          
                               c = u;
                                if (temp != "")
                                {
                                    a.Add(temp);

                                    temp = "";
                                }
                                a.Add(ch[u].ToString());
                                //Console.WriteLine("yaar 1  " + ch[u].ToString());
                            }
                            if (Char.IsLetterOrDigit(ch[u]))
                            {
                                if (u + 1 == ch.Length)
                                {
                                    temp = "";
                                    for (int o = c + 1; o < u + 1; o++)
                                    {
                                        if (!Char.IsWhiteSpace(ch[o]))
                                        {
                                            temp = temp + ch[o];
                                            //   Console.WriteLine("yaar 1  " + temp);
                                        }
                                    }
                                    //         Console.WriteLine(temp + "\nd");
                                    if (temp != "")
                                        a.Add(temp);
                                    temp = "";
                                }

                            }
                            else
                            {
                                if ((ch[u] == '\"' || ch[u] == '\'' || ch[u] == '~' || ch[u] == '?' || ch[u] == '$' || ch[u] == '#' || ch[u] == '@' || ch[u] == '&' || ch[u] == '|') && u + 1 == ch.Length)
                                {
                                    temp = "";
                                    for (int o = c + 1; o < u + 1; o++)
                                    {
                                        if (!Char.IsWhiteSpace(ch[o]))
                                        {
                                            temp = temp + ch[o];
                                            //   Console.WriteLine("yaar 1  " + temp);
                                        }
                                    }
                                    if (temp != "")
                                    {
                                        a.Add(temp);
                                        temp = "";
                                    }
                                    //       a.Add(ch[u].ToString());
                                    c = u;
                                }
                                //   Console.WriteLine(ch[u].ToString() + " d");
                            }

                        }
                        if (n != true)
                        {
                            i1 = i;
                            n = true;
                        }
                        String[] p1 = (String[])a.ToArray(typeof(string));
                         a = new ArrayList();
                        int count = 1;
                        for (int f = p1.Length - 1; f > -1; f--)
                        {

                            try1.Insert(i1, p1[f]);
                            // Console.WriteLine(i1+ " "+p1[f]);
                            count++;
                        }
                        i1 = i1 + count;
                    }
                }
            }

            String[] p = (String[])try1.ToArray(typeof(string));
            // p1 = sepFLT(p1);
            return p;
        }

        bool matching(String s)
        {
            for(int i=0;i<s.Length;i++)
            {
                if(s[i]=='*'|| s[i] == '^')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
