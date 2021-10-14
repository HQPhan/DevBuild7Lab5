using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Registration_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a list of userNames
            List<string> userNamesList = new List<string>();
            userNamesList.Add("TheU$3R#");
            userNamesList.Add("TheP4$$word");
            userNamesList.Add("N0One%99");
            
            //Create a list of userPasswords
            List<string> userPWList = new List<string>();
            Console.WriteLine("CREATE YOUR USERNAME AND PASSWORD!\n");
            userNamesList.Add("DkfDt@$t980");
            userNamesList.Add("QWerty$@312");
            userNamesList.Add("FU1m0$R%3");

            //Ask user to create a username
            Console.WriteLine("USERNAME must contain:");
            string req1 = "letters and numbers\tmin 5 letters\tmin 7 characters\tmax 12 characters\n";
            string[] specif1 = req1.Split("\t");
            foreach (string s in specif1)
            {
                Console.WriteLine($"\t{s}");
            }

            //Checking username criteria
            bool lowLetter = true, upLetter = true, numbs = true, specChar = true;
            bool goRange = true, lettersLength = true, again = true;
            int minimum = 7, maximum = 12, letLngth;
            string userName;

            while (again == true)
            {
                userName = Prompt("Enter USERNAME: ");
                lowLetter = HasLetter(userName);
                numbs = HasNumber(userName);
                goRange = RangeCheck(minimum, maximum, userName.Length);
                letLngth = FiveLetters(userName.Length, userName);
                lettersLength = HasFiveLetters(letLngth);
                //Add good username to List and prompts user if username is accepted
                if (lowLetter == true && numbs == true && goRange == true && lettersLength == true)
                {
                    userNamesList.Add(userName);
                    Console.WriteLine($"\nSUCCESS! Your USERNAME is:{userName} ");
                    break;
                }
                else
                {
                    again = true;
                }
            }
            //Ask user to create a password
            Console.WriteLine("");
            Console.WriteLine("PASSWORD must contain:");
            string req2 = "lowercase letter\tuppercase letter\tnumber\tmin 7 characters\tmax 12 characters\tspecial charaters (!@#$%^&*)\n";
            string[] specif2 = req2.Split("\t");
            foreach (string str in specif2)
            {
                Console.WriteLine($"\t{str}");
            }

            //Checking password crtieria
            while (again == true)
            {
                string userPassword = Prompt("Enter a PASSWORD: ");
                lowLetter = HasLetter(userPassword);
                upLetter = HasCapital(userPassword);
                numbs = HasNumber(userPassword);
                goRange = RangeCheck(minimum, maximum, userPassword.Length);
                specChar = HasSpecialChar(userPassword);

                //Add good password to List and prompts user if pw is accepted
                if (lowLetter == true && numbs == true && goRange == true && lettersLength == true)
                {
                    userPWList.Add(userPassword);
                    Console.WriteLine($"\nSUCCESS! Your PASSWORD is:{userPassword} ");
                    break;
                }
                else
                {
                    again = true;
                }
            }
        }
        //Prompts user
        public static string Prompt(string question)
        {
            Console.Write(question);
            string input = Console.ReadLine();
            return input;
        }
        //Checks range of characters
        public static bool RangeCheck(int min, int max, int userLength)
        {
            if (userLength < min)
            {
                Console.WriteLine($"\tHas to be more than {min} characters");
                return false;
            }
            else if (userLength > max)
            {
                Console.WriteLine($"\tHas to be less than {max} characters");
                return false;
            }
            else
            {
                return true;
            }
        }
        //Counts how many letters username has
        public static int FiveLetters(int userLength, string userID)
        {
            int addOneMore = 0;
            for (int i = 0; i <= userLength - 1; i++)
            {
                char[] letter = userID.ToArray();
                if (char.IsLetter(letter[i]))
                {
                    addOneMore += 1;
                }
            }
            return addOneMore;
        }
        //Check if username has at least 5 letters
        public static bool HasFiveLetters(int fiveLetters)
        {
            if (fiveLetters >= 5)
            {
                return true;
            }
            else
            {
                Console.WriteLine("\tNeed at least 5 letters");
                return false;
            }
        }
        //Check if there is a letter
        public static bool HasLetter(string userID)
        {
            if (userID.Any(char.IsLetter))
            {
                return true;
            }
            else 
            {
                Console.WriteLine("\tMissing letter");
                return false;
            }
        }
        //Check if there is a upper case letter
        public static bool HasCapital(string userID)
        {
            if (userID.Any(char.IsUpper))
            {
                return true;
            }
            else
            {
                Console.WriteLine("\tMissing upper case letter");
                return false;
            }
        }
        //Check if there is a number
        public static bool HasNumber(string userID)
        {
            if (userID.Any(char.IsDigit))
            {
                return true;
            }
            else
            {
                Console.WriteLine("\tMissing number");
                return false;
            }
        }
        //Check if there is a special character
        public static bool HasSpecialChar(string userID)
        {
            if (userID.Any(c => !char.IsLetterOrDigit(c)))
            {
                return true;
            }
            else
            {
                Console.WriteLine("\tMissing special character");
                return false;
            }
        }
    }
}
