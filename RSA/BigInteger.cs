using System;
using System.Collections.Generic;
using System.Text;
namespace RSA_Public_Key_Cryptosystem_Team_12
{
    public class BigInteger
    {
        public string Num; //O(1)
        public string q; //O(1)
        public string r;//O(1)
        public BigInteger() //O(1)
        {
        }
        public BigInteger(string num) //O(1)
        {
            Num = num;  //O(1)
        }
        //_____________________________________________
        // Multiply function 
        // complexity of function multiply o ( N^log(3) ) >>>>>> O(N ^ 1.58 ) 
        //
        public string Multiply(string first, string second) //T(N)=3T(N/2)+O(N)
        {
            var n = Math.Max(first.Length, second.Length);  //O(1)
            var m = Math.Min(first.Length, second.Length);  //O(1)
            if (first.Length == 0 || second.Length == 0)    //O(1)
                return ("0"); //O(1)


            if (n < 9) //O(1)
            {
                return (long.Parse(first) * long.Parse(second)).ToString(); //O(1)     (long can fit 10^18 )
            }
            int N = Math.Min(first.Length, second.Length); //O(1)
            N = N / 2 + N % 2; //O(1)
            string a = first.Remove(first.Length - N);      //O(N) N is Length of string
            string b = first.Substring(first.Length - N);   //O(N) N is Length of string
            string c = second.Remove(second.Length - N);    //O(N) N is Length of string
            string d = second.Substring(second.Length - N); //O(N) N is Length of string


            string ac = Multiply(a, c);
            string bd = Multiply(b, d);
            string ab_cd = Multiply(add(a, b), add(c, d));
            int padding = b.Length + d.Length; //O(1)

            string x = sub(sub(ab_cd, ac), bd); // O ( N )
            string y = x.PadRight(x.Length + padding / 2, '0');                                  // O(N)
            string z = ac.PadRight(ac.Length + padding, '0');                                   //O( N ) 
            return add(y, add(z, bd));             // O( N ) 
        }


        // substract function 
        //__________________________________________________

        public string sub(string a, string b)
        {

            int paddingVal = Math.Max((int)(a.Length - b.Length), 0); //O(1)
            if (b.Length < a.Length) //O(1)
                b = b.PadLeft(b.Length + paddingVal, '0'); //O(N)
            List<char> res_list = new List<char>(); //O(1)
            int carry = 0; //O(1)

            for (int i = a.Length - 1; i >= 0; i--) //O(N)
            {
                if ((int)a[i] - carry >= (int)b[i]) //O(1)
                {
                    res_list.Add((char)((int)a[i] - (int)b[i] - carry + '0')); //O(1)
                    carry = 0; //O(1)
                }
                else //O(1)
                {
                    res_list.Add((char)((int)a[i] - (int)b[i] - carry + 10 + '0')); //O(1)
                    carry = 1; //O(1)
                }

            }
            int j = 1; //O(1)
            string str_result = string.Join("", res_list); //O(N)
            char[] ch_result = str_result.ToCharArray();  //O( N )
            Array.Reverse(ch_result);                   //O(N)
            str_result = new string(ch_result);         //O(N)
            for (int i = 0; i < str_result.Length; i++) //O(N)
            {
                if (str_result[i] == '0') //O(1)
                    j++; //O(1)
                else //O(1)
                    break; //O(1)
            }
            if (j > str_result.Length) //O(1)
                return "0"; //O(1)
            return str_result.Substring(j - 1); // O( N ) 

        }


        //___________________________________________
        // Add function 
        public string add(string a, string b) //O(N)
        {
            if (a.Length > b.Length) //O(N)
            {
                string temp = a;//O(N)
                a = b;//O(N)
                b = temp;//O(N)
            }
            List<char> res_list = new List<char>(); // O(1)
            int n1_size = a.Length;         // O( 1 )
            int n2_size = b.Length;         // O( 1 )
            int size_of_larger = n2_size - n1_size; //O(1)
            int carry = 0;                  //O(1)
            int sum_temp;                   //O(1)
            for (int i = n1_size - 1; i >= 0; i--) //O(N)
            {
                sum_temp = ((int)(a[i] - '0') + (int)(b[i + size_of_larger] - '0') + carry); //O(1)
                res_list.Add((char)(sum_temp % 10 + '0')); //O(1)
                carry = sum_temp / 10; //O(1)
            }
            for (int i = n2_size - n1_size - 1; i >= 0; i--) //O(N) 
            {
                sum_temp = ((int)(b[i] - '0') + carry);  //O(1)
                res_list.Add((char)(sum_temp % 10 + '0'));  //O(1)
                carry = sum_temp / 10;                  //O(1)
            }
            if (carry > 0) //O(1)
                res_list.Add((char)(carry + '0'));         //O(1)


            string str_result = string.Join("", res_list); //O(N)
            char[] ch_result = str_result.ToCharArray();  //O( N )
            Array.Reverse(ch_result);                   //O(N)
            str_result = new string(ch_result);         //O(N)
            return str_result;                          //O(1)
        }
        //___________________________________________
        public bool Is_smaller(string a, string b)    // O ( N ) 
        {
            if (a.Length < b.Length)    // O( 1  )
                return true;             // O( 1  )
            else if (a.Length > b.Length)   // O( 1  )
                return false;                 // O( 1  )
            int size = a.Length;                 // O( 1  )
            for (int i = 0; i < size; i++)       // O ( N ) 
            {
                if ((a[i] - '0') < (b[i] - '0'))   // O( 1  )
                    return true;         // O( 1  )
                else if ((a[i] - '0') > (b[i] - '0'))    // O( 1  )
                    return false;     // O( 1  )
            }
            return false;    // O( 1  )
        }


        public (string, string) div(string a, string b) //O(N) T(N)=T(N/2)+N
        {
            if (!Is_smaller(a, b)) //O(N)
            {
                (q, r) = div(a, b: add(b, b)); 
                q = add(q, q);    //O(N)
                if (Is_smaller(r, b))     //O(N)
                    return (q, r);    //O(1) 
                else
                    return (add(q, "1"), sub(r, b)); //O(N)
            }
            return ("0", a);  //O(1) 
        }

        public string mod_of_power(string b, string p, string mod)   //T(P/2)+N^log(3)  O((N^2) * log(P))
        {
            if (p == "0")    //O(1) 
                return "1";   //O(1) 
            else
            {
                string tmp = div(mod_of_power(b, (div(p, "2")).Item1, mod), mod).Item2;  
                if (div(p, "2").Item2 == "0")   // O( N)
                    return div(Multiply(tmp, tmp), mod).Item2;   // O( N ^ log( 3 ) )>>> O(N^ 1.58)

                else
                    return div(Multiply(div(Multiply(tmp, tmp), mod).Item2, div(b, mod).Item2), mod).Item2; // O( N ^ log( 3 ) )>>> O(N^ 1.58)
            }
        }

        public string encryption(string m, string e, string n)    //  O((N^2) * log(P))
        {

            return mod_of_power(m, e, n);   //  O((N^2) * log(P))
        }

        public string decryption(string m, string d, string n)   //  O((N^2) * log(P))
        {
            return mod_of_power(m, d, n);    //  O((N^2) * log(P))
        }

        public string ToAscii (string s )   // O(N) 
        {
            List<char> l_res = new List<char>(); // O(1)

            for (int i = 0;i < s.Length; i++) // O(N)
            {
                int x = (int)s[i];   // O(1)
                x += 100;   // O(1)
                char tmp = (char)(x % 10 + '0');   // O(1)
                x /= 10;    // O(1)
                char tmp2 = (char)(x % 10 + '0');   // O(1)
                x /= 10;    // O(1)
                l_res.Add((char)(x % 10 + '0'));    // O(1)
                l_res.Add(tmp2); // O(1)
                l_res.Add(tmp); // O(1)

            }
            string str_result = string.Join("", l_res); // O(N)
            return str_result;  // O(1)
        }
        public string to_Massege(string s) // O(N^2)
        {
            StringBuilder tmp=new StringBuilder(); // O(1)
            StringBuilder res = new StringBuilder();  // O(1)
            for (int i = 0; i+2 < s.Length; i+=3) // O(N)
            {
                tmp.Append(s[i]);   // O(1)
                tmp.Append(s[i+1]); // O(1)
                tmp.Append(s[i + 2]); // O(1)
                int num =int.Parse(tmp.ToString());  // O(1)
                tmp.Clear();    // O(N)
                num -= 100;      // O(1)
                res.Append((char)(num));  // O(1)

            }
            return res.ToString();  // O(N)
        }

        }
}

