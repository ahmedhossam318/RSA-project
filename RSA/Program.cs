using System;
using System.IO;

namespace RSA_Public_Key_Cryptosystem_Team_12
{

    public class Program
    {


        public static void Main(string[] args)
        {


            long timeBefore = System.Environment.TickCount;      //O(1)                         
            // M is Number of Cases   
             // N Length of string(Number) in each Case        
             // CheckFunction("MultiplyTestCases.txt", "Output/MultiplyTestCases_Output.txt",0);          // O(N^1.58 * M)
              //CheckFunction("AddTestCases.txt", "Output/AddTestCases_Output.txt",1);                    // O(N * M)
              //CheckFunction("SubtractTestCases.txt", "Output/SubtractTestCases_Output.txt",2);         // O(N* M)                                                                                                                                   // CheckFunctionMS2("SampleRSA.txt", "Output/Sample_RSA.txt");
              CheckFunctionMS2("TestRSA.txt", "Output/Complete_RSA.txt");
            //  bouns1("bouns1.txt", "Output/bouns1.txt");
             var temp = new BigInteger("0");
            
            var s = temp.ToAscii("ABCDEFGZ");

            Console.WriteLine(s);
            Console.WriteLine(temp.to_Massege(s));
            long timeAfter = System.Environment.TickCount; //O(1)

            Console.WriteLine ("Finish After  " + ((timeAfter - timeBefore)/60000).ToString() + " Minute"); //O(1)


            Console.WriteLine("     And      " + (((timeAfter - timeBefore) /1000)%60).ToString() + " Second"); //O(1)

            Console.WriteLine("Total Time in ms  "+(timeAfter - timeBefore).ToString()+" ms."  );

        }
        //_________________________________________
        
        
        
        static void CheckFunction(string inputName, string outName,int state)
        {
            File.WriteAllText(outName, String.Empty); //O(1)
            using (System.IO.StreamWriter write_file = new System.IO.StreamWriter(outName, true)) //O(1)
            {
                FileStream file = new FileStream(inputName, FileMode.Open, FileAccess.Read); //O(1)
                StreamReader sr = new StreamReader(file); //O(1)
                var temp = new BigInteger("0"); //
                int cases = int.Parse(sr.ReadLine()); // O(N)   N is  Length of Cases Number 
                for (int i = 0; i < cases; i++) //O(Cases * N ^ log 3) N Length of string (Number) in each Case   
                {
                    if (i > 0) //O(1)
                    {
                        write_file.WriteLine(String.Empty); //O(1)
                    }
                    sr.ReadLine(); //O(1)
                    string x = sr.ReadLine(); //O(N) N Length of string (Number) in each Case   
                    string y = sr.ReadLine(); //O(N) N Length of string (Number) in each Case   
                    if (state == 0)
                    {
                        write_file.WriteLine(temp.Multiply(x, y)); //O(N ^ log(3) ) >>>O(N ^ 1.58) 
                    }
                    else if (state == 1)
                    {
                        write_file.WriteLine(temp.add(x, y));//O(N)
                    }
                    else
                    {
                        write_file.WriteLine(temp.sub(x, y)); //O(N)
                    }
                }
            }
        }

        //__________________________________________________________________
        static void CheckFunctionMS2(string inputName, string outName)
        {
            File.WriteAllText(outName, String.Empty); //O(1)
            using (System.IO.StreamWriter write_file = new System.IO.StreamWriter(outName, true)) //O(1)
            {
                FileStream file = new FileStream(inputName, FileMode.Open, FileAccess.Read); //O(1)
                StreamReader sr = new StreamReader(file); //O(1)
                var temp = new BigInteger("0"); // O( 1 )
                int cases = int.Parse(sr.ReadLine()); // O(N)   N is  Length of Cases Number 
                for (int i = 0; i < cases; i++) //O(Cases * (N ^ 2 ) log (P) ) N Length of string (Number) in each Case   
                {
                    if (i > 0) //O(1)
                    {
                        write_file.WriteLine(String.Empty); //O(1)
                    }

                    string mod = sr.ReadLine(); //O(N) N Length of string (Number) in each Case   
                    string e = sr.ReadLine(); //O(N) N Length of string (Number) in each Case   
                    string m = sr.ReadLine(); //O(N) N Length of string (Number) in each Case
                    string st = sr.ReadLine(); //O(N) N Length of string (Number) in each Case 
                    if (st == "0")  // O(1)
                    {
                        write_file.WriteLine(temp.encryption(m,e,mod)); //  O((N^2) * log(P))
                    }
                    else if (st == "1")   // O(1)
                    {
                        write_file.WriteLine(temp.decryption(m,e,mod)); //  O((N^2) * log(P))
                    }
                }
            }
        }

        static void bouns1(string inputName, string outName)
        {
            File.WriteAllText(outName, String.Empty); //O(1)
            using (System.IO.StreamWriter write_file = new System.IO.StreamWriter(outName, true)) //O(1)
            {
                FileStream file = new FileStream(inputName, FileMode.Open, FileAccess.Read); //O(1)
                StreamReader sr = new StreamReader(file); //O(1)
                var temp = new BigInteger("0"); // O( 1 )
                int cases = int.Parse(sr.ReadLine()); // O(N)   N is  Length of Cases Number 
                for (int i = 0; i < cases; i++) //O(Cases * (N ^ 2 ) log (P) ) N Length of string (Number) in each Case   
                {
                    if (i > 0) //O(1)
                    {
                        write_file.WriteLine(String.Empty); //O(1)
                    }

                    string mod = sr.ReadLine(); //O(N) N Length of string (Number) in each Case   
                    string e = sr.ReadLine(); //O(N) N Length of string (Number) in each Case   
                    string m = sr.ReadLine(); //O(N) N Length of string (Number) in each Case
                    string st = sr.ReadLine(); //O(N) N Length of string (Number) in each Case 
                    if (st == "0")  // O(1)
                    {
                        write_file.WriteLine(temp.encryption(temp.ToAscii(m), e, mod)); //  O((N^2) * log(P))
                    }
                    else if (st == "1")   // O(1)
                    {
                        
                        write_file.WriteLine(temp.to_Massege(temp.decryption(m, e, mod))); //  O((N^2) * log(P))
                    }
                }
            }
        }



    }
}
