using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Good_MatchConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Matcher Match = new Matcher();
            Console.ReadKey();


        }

    }


    public class Matcher
    {

        private string matchingSentence = "";
        private string numberString = "";


        public Matcher()
        {
            getNames();

        }

        private void getNames()
        {
            int count = 0;
            Regex stringCheck = new Regex("[^A-Za-z]");
            string userName = "";

            while (count <= 1)
            {
                count++;

                Console.WriteLine("Please Enter Person {0}'s Name :", count);
                userName = Console.ReadLine().ToLower();


                if (!stringCheck.IsMatch(userName))
                {

                    sentenceBuilder(count, userName);

                }
                else {
                    while (stringCheck.IsMatch(userName))
                    {
                        Console.WriteLine("Please Enter A Valid Input For Person {0}'s Name :", count);
                        userName = Console.ReadLine().ToLower();

                    }

                    sentenceBuilder(count, userName);
                }




            }




            Console.WriteLine("\n");
            setSentenceCounter(matchingSentence);
            countNumberString(numberString);
        }

        private void sentenceBuilder(int count, string Uname) {

            if (count == 2)
            {
                matchingSentence += " matches " + Uname;
            }
            else
            {
                matchingSentence += Uname;
            }

        }


        private void setSentenceCounter(string name) {

            ArrayList usedLetterList = new ArrayList();
            char temp;
            int count = 0;
            while (count < name.Length)
            {
                temp = name[count];
                int tempCount = 0;

                if (!(usedLetterList.Contains(temp) || temp == Convert.ToChar(" ")))
                {

                    int watch = count;

                    while (watch < name.Length)
                    {

                        if (temp == name[watch])
                        {
                            tempCount++;


                        }
                        watch++;
                    }
                    Console.WriteLine("{0} \n {1}", name, numberString);
                    usedLetterList.Add(temp);
                    numberString += tempCount;
                }

                count++;

            }



        }


        private void countNumberString(string numStrng)
        {
            Console.WriteLine("\n");
            string tempNumString = "";
            int frontNum = 0;
            int lastNum = numStrng.Length - 1;

            while (numStrng.Length > 2)
            {

                if (frontNum < lastNum)
                {
                    int adder = int.Parse(Convert.ToString(numStrng[frontNum])) + int.Parse(Convert.ToString(numStrng[lastNum]));
                    tempNumString += Convert.ToString(adder);
                    Console.WriteLine("* {0}",numStrng);
                    Console.WriteLine("    * {0}",tempNumString);
                    frontNum++;
                    lastNum--;

                }
                else if (frontNum == lastNum)
                {

                    tempNumString += numStrng[frontNum];
                    Console.WriteLine("* {0}", numStrng);
                    Console.WriteLine("    * {0}", tempNumString);
                    numStrng = tempNumString;
                    tempNumString = "";
                    frontNum = 0;
                    lastNum = numStrng.Length - 1; ;
                    Console.WriteLine("\n");
                    
                }
                else
                {
                    Console.WriteLine("* {0}", numStrng);
                    Console.WriteLine("    * {0}", tempNumString);
                    numStrng = tempNumString;
                    tempNumString = "";
                    frontNum = 0;
                    lastNum = numStrng.Length - 1;
                    Console.WriteLine("\n");
                   

                }
            }

            Console.WriteLine("{0} : {1}%",matchingSentence, numStrng);

        }






    }


    public class person {

        private string name;
        private char gender;
        private Regex gendertCheck = new Regex("[mf]");
        private Regex inputCheck = new Regex("[^A-Za-z]");

        public person(string aName , char aGender) {

            setName(aName);
            setGender(aGender);
        }



        private Boolean setName(string bName) {

            if (inputCheck.IsMatch(bName)) {
                name = bName;
                return true;

            }
            else{
                return false;
                    

            }
        
        }


        private Boolean setGender(char bGender) {

            if (gendertCheck.IsMatch(Convert.ToString(bGender)))
            {
                gender = bGender;
                return true;

            }
            else
            {
                return false;
            }

        }
          
    }




}

