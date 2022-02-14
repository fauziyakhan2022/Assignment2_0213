/* 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] number1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int position = SearchInsert(number1, target);
            Console.WriteLine("Insert Position of the target is : {0}", position);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string para = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonW = MostCommonWord(para, banned);
            Console.WriteLine("Most frequent word is {0}:", commonW);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_num = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_num);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint1 = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint1);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }




        //Question 1:


        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.

                ArrayList arr = new ArrayList();
                ArrayList arr1 = new ArrayList();
                //adding the number1 array elements to the arraylist arr
                for (int i = 0; i < nums.Length; i++)
                {
                    arr.Add(nums[i]);
                }
                //adding the target element entered by the user. We have to find the index of this target element once it is inserted into the array
                arr.Add(target);
                //sorting the arraylist in the ascending order
                arr.Sort();
                //returning the index of the target element in the array
                return arr.IndexOf(target);
            }
            catch (Exception)
            {
                throw;
            }
        }




        //Question 2



        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                //write your code here.
                string paragraph1 = paragraph;

                //remove all the punctuatons from the paragraph
                paragraph1 = Regex.Replace(paragraph1, @"[^\w\d\s]", "");

                //convert the pargraph to lowercase to be readable based on the requirement
                string wordlowercase = paragraph1.ToLower();
                //storing each word in the paragraph as an array
                string[] words = wordlowercase.Split(" ");

                SortedDictionary<String, int> dict = new SortedDictionary<String, int>();

                //looping through the paragraph
                for (int i = 0; i < words.Length; i++)
                {

                    //if the dictionary does not contain the word add it
                    if (dict.ContainsKey(words[i]))
                    {
                        //if the word is present it increments the count by 1 if it is match. The key is the word and the value is getting stored as the sum
                        dict[words[i]] += 1;
                    }
                    else
                    {
                        //if the word is not presemt , it will add the word to the dictionary
                        dict.Add(words[i], 1);
                    }

                }
                //once all the words are added, remove the banned word from the paragraph
                dict.Remove(banned[0]);
                //arranging the dictionary in the descending order and getting the maximum value of it
                var max = dict.OrderByDescending(d => d.Value).First();
                //getting the key corresponding to the maximum value
                var key = max.Key;
                return key;
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Question 3:


        public static int FindLucky(int[] arr)
        {
            try
            {
                //write your code here.

                SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
                List<int> list1 = new List<int>();

                for (int i = 0; i < arr.Length; i++)
                {
                    //if the dictionary contains the key add it to the given value 
                    if (dict.ContainsKey(arr[i]))
                    {
                        dict[arr[i]] += 1;
                    }
                    else
                    {
                        //if the value is not presnt , then  add the value as 1 corresponding to the key, which is the element of the array
                        dict.Add(arr[i], 1);
                    }
                }
                //for every pair in the dictionary if the key equal to the value add it the list list1
                foreach (var v in dict)
                {
                    if (v.Key == v.Value)
                    {
                        list1.Add(v.Value);

                    }
                    else
                    {
                        //breaking from the loop otherwise
                        break;
                    }

                }
                //if there are no elements correspinding to the requirement ie.where the key and value are equal return 0.  
                if (list1.Count == 0 || list1.Max() == 0)
                {
                    return 0;

                }
                else
                {
                    //else return the maximum value of the list1
                    return list1.Max();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        //Question 4:


        public static string GetHint(string secret, string guess)
        {
            try
            {
                int count = 0;
                int sum = 0;
                string x = "";
                string y = "";
                for (int j = 0; j < guess.Length; j++)
                {
                    //if the value of secret and guess is equal increase count
                    if (secret[j] == guess[j])
                    {
                        count += 1;
                    }
                    else
                    {
                        //add the values to the valriables x and y
                        x += secret[j];
                        y += guess[j];
                    }
                }
                //looping through each character in the string x
                foreach (char a in x)
                {
                    int flag = 0;
                    for (int k = 0; k < y.Length; k++)
                    {
                        //if corresponding y chracter is wual to the character in  string x, set the flag, increment the sum and remove the character from string y which has the guess 
                        if (y[k] == a && flag == 0)
                        {
                            sum += 1;
                            y = y.Remove(k, 1);
                            flag = 1;
                        }
                    }
                }
                //storing the value of bulls as count and sum as cow
                string z = count.ToString() + "A" + sum.ToString() + "B";
                return z;
            }
            catch (Exception)
            {

                throw;
            }
        }



        //Question 5:


        public static List<int> PartitionLabels(string s)
        {
            try
            {
                //write your code here.
                List<int> ans = new List<int>();
                if (s.Length == 0)
                {
                    return ans;
                }
                //converting the string s into a character array
                char[] arr = s.ToCharArray();
                HashSet<char> alreadyRead = new HashSet<char>();

                int[] next1 = new int[s.Length];
                //reading the character from the array and then reads the next character in the array
                foreach (char c in arr)
                    next1[c - 'a']++;
                int count = 0;

                foreach (char c in arr)
                {
                    count++;
                    //adding the read character in the hashset
                    alreadyRead.Add(c);
                    if (--next1[c - 'a'] == 0)
                    {
                        alreadyRead.Remove(c);
                        if (alreadyRead.Count == 0)
                        {
                            ans.Add(count);
                            count = 0;
                        }
                    }
                }
                return ans;
                //return new List<int>() { };
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Question 6


        public static List<int> NumberOfLines(int[] widths, string S)
        {
            try
            {
                int row = 1;
                int sum = 0;
                int temporary = 0;
                List<int> list = new List<int>();

                //converting the string to character
                Char[] c = S.ToCharArray();


                foreach (Char ch in c)
                {
                    //the temporary value 
                    temporary = widths[ch - 97];

                    if (sum + temporary > 100)
                    {
                        //if the value of sum of temp and sum is > 100, start a new row and set sum as temp
                        row++;
                        sum = temporary;
                    }
                    else
                    {
                        //else add temp to the value of sum
                        sum += temporary;
                    }
                }
                list.Add(row);
                list.Add(sum);

                return list;
            }
            catch (Exception)
            {
                throw;
            }

        }




        //Question 7:


        public static bool IsValid(string s)
        {
            try
            {
                var list = new List<char>();
                //traverse the input string s
                for (int i = 0; i < s.Length; i++)
                {
                    //check the type of brackets
                    if (s[i] == ')' || s[i] == '}' || s[i] == ']')
                    {
                        if (list.Count() == 0)
                            return false;
                        //check if the open is not equal to the closing brackets. If not equal return true
                        var c = list[list.Count() - 1];
                        if ((c == '(' && s[i] != ')') || (c == '[' && s[i] != ']') || (c == '{' && s[i] != '}'))
                            return false;

                        list.RemoveAt(list.Count() - 1);
                        continue;
                    }

                    list.Add(s[i]);
                }

                return list.Count() == 0;
            }
            catch (Exception)
            {
                throw;
            }
        }




        //Question 8


        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //write your code here.

                string str = "";
                int count = 0;
                //store the morse equivalent of each alphabet in key value format
                Dictionary<char, string> textToMorse = new Dictionary<char, string>()
                { { 'a', ".-"}, { 'b', "-..."},  { 'c', "-.-."},  { 'd', "-.."},  { 'e', "."},  { 'f', "..-."},  { 'g', "--."},  { 'h', "...."},  { 'i', ".."},  { 'j', ".---"},  { 'k', "-.-"},  { 'l', ".-.."},
                  { 'm', "--"},  { 'n', "-."},  { 'o', "---"},  { 'p', ".--."},  { 'q', "--.-"},  { 'r', ".-."},  { 's', "..."},  { 't', "-"},  { 'u', "..-"},  { 'v', "...-"},  { 'w', ".--"},  { 'x', "-..-"},  { 'y', "-.--"},  { 'z', "--.."}};
                List<string> morseofWords = new List<string>();
                //reads each word in the array
                for (int i = 0; i < words.Length; i++)
                {
                    if (i == words.Length)
                        break;
                    else
                    {
                        //reads each character in each word
                        foreach (char c in words[i])
                        {
                            count++;
                            //for each value in the dictionary matching with the character  the key , it Converts the word to its morse code.
                            foreach (var v in textToMorse)
                            {
                                if (c == v.Key)
                                {
                                    //store the Morse code value in a string
                                    str += v.Value;
                                    //if the value length of each word is reached, add it to the list. make the string value to null and set count to 0.
                                    if (count == words[i].Length)
                                    {
                                        morseofWords.Add(str);
                                        str = "";
                                        count = 0;

                                    }

                                }
                            }
                        }

                    }
                }
                //checking  if there are duplicate morsecode for more than one word. It will return the count of only distinct strings
                return morseofWords.Distinct().Count();
            }

            catch (Exception)
            {
                throw;
            }
        }






        //Question 9:


        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }



        //Question 10:



        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
