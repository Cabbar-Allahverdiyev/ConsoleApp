using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{

    class Program
    {


        static void Main(string[] args)
        {
            //Console.WriteLine(FirstReverse(Console.ReadLine()));
            // Console.WriteLine(CoderByteChallange.SwapII(Console.ReadLine()));//6Hello4 8World 7 yes3
            //Console.WriteLine(CoderByteChallange.Palindrome(Console.ReadLine()));
            //Console.WriteLine(CoderByteChallange.RomanNumeralReduction("DDLL"));
            // Console.WriteLine(CoderByteChallange.DashInsert("56730"));
            //Console.WriteLine(CoderByteChallange.TwoSum(new int[] { 17, 4, 5, 6, 10, 11, 4, -3, -5, 3, 15, 2, 7 }));
            //Console.WriteLine(CoderByteChallange.FibonacciChecker(34));
            //Console.WriteLine(CoderByteChallange.HappyNumbers(28));Console.WriteLine(CoderByteChallange.HappyNumbers(101));
            //Console.WriteLine(CoderByteChallange.TripleDouble(465555, 5579));Console.WriteLine(CoderByteChallange.TripleDouble(67844, 66237));
            Console.WriteLine(CoderByteChallange.PatternChaser("aabbaa"));
        }

    }



    public static class CoderByteChallange
    {

        public static string PatternChaser(string str)
        {
            if (str.Length > 20) { return null; }
            if (str.Length < 21)
            {
                foreach (char c in str)
                {
                    if (!char.IsLetter(c) && !char.IsDigit(c))
                    {
                        return null;
                    }
                }
            }
            int count = 0;
            string value = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i+1==str.Length)
                {
                    break;
                }
                string removed = str;
                removed=str.Remove(i,  2);
                if (removed.Contains(str[i].ToString() + str[i+1].ToString()))
                {
                    string localStr = str[i].ToString() + str[i + 1].ToString();
                    int locCount = i + 1;
                    for (int j = i+1; j < str.Length; j++)
                    {
                        if (j + 1 == str.Length)
                        {
                            break;
                        }
                        removed=removed.Remove(0, 1);
                        string loclocalStr = localStr;
                        loclocalStr+=str[j+1].ToString();
                        if (removed.Contains(loclocalStr))
                        {
                            int loclocalCount = j+1;
                            if (loclocalStr!=value&&loclocalCount>count)
                            {
                                count = loclocalCount;
                                value = loclocalStr;
                                //continue;
                            }
                        }
                        //continue;
                    }
                    value = localStr;
                    count = locCount;
                }
               
            }
            // code goes here  
            return "yes"+value;

        }
        public static int TripleDouble(int num1, int num2)
        {
            string chars1 = num1.ToString();
            string chars2 = num2.ToString();
            string value1 = "";
            string value2 = "";
            if (chars1.Length >= 3 && chars2.Length >= 2)
            {
                for (int i = 2; i < chars1.Length; i++)
                {
                    if (chars1[i] == chars1[i - 1] && chars1[i - 1] == chars1[i - 2])
                    {
                        value1 = chars1[i].ToString() + chars1[i - 1].ToString() + chars1[i - 2].ToString();
                    }
                    if (value1.Length != 0)
                    {
                        break;
                    }
                }
                for (int i = 1; i < chars2.Length; i++)
                {
                    if (chars2[i] == chars2[i - 1])
                    {
                        value2 = chars2[i].ToString() + chars2[i - 1].ToString();
                    }
                    if (value2.Length != 0)
                    {
                        break;
                    }
                }
                if (value1.Length == 0 || value2.Length == 0) { return 0; }
                if (value1[0] == value2[0]) { return 1; }
            }
            // code goes here  
            return 0;

            
        }
        public static bool HappyNumbers(int n)
        {
            HashSet<int> s = new HashSet<int>();
            s.Add(n);
            while (true)
            {
                if (n == 1) { return true; }
                n = SumDigitSquare(n);
                if (s.Contains(n)) { return false; }
                s.Add(n);
            }
        }

        static int SumDigitSquare(int n)
        {
            int sq = 0;
            while (n > 0)
            {
                int digit = n % 10;
                sq += digit * digit;
                n = n / 10;
            }
            return sq;
        }

        public static void quadrantLocation(string result, int x, int y)
        {
            if (x < 3)
            {
                if (y < 3)
                {
                    result += ",1";
                }
                else if (y >= 3 && y < 6)
                {
                    result += ",2";
                }
                else if (y >= 6 && y < 9)
                {
                    result += ",3";
                }
            }
            else if (x >= 3 && x < 6)
            {
                if (y < 3)
                {
                    result += ",4";
                }
                else if (y >= 3 && y < 6)
                {
                    result += ",5";
                }
                else if (y >= 6 && y < 9)
                {
                    result += ",6";
                }
            }
            else if (x >= 6 && x < 9)
            {
                if (y < 3)
                {
                    result += ",7";
                }
                else if (y >= 3 && y < 6)
                {
                    result += ",8";
                }
                else if (y >= 6 && y < 9)
                {
                    result += ",9";
                }
            }
        }
        // Overload function but this time we want to find the range of the quadrant
        // This will aid for when searching the current quadrant to check if the number repeats
        public static void quadrantLocation(int x, int y, int rowSize, int columnSize)
        {
            if (x < 3)
            {
                rowSize = 3;
                if (y < 3)
                {
                    columnSize = 3;
                }
                else if (y >= 3 && y < 6)
                {
                    columnSize = 6;
                }
                else if (y >= 6 && y < 9)
                {
                    columnSize = 9;
                }
            }
            else if (x >= 3 && x < 6)
            {
                rowSize = 6;
                if (y < 3)
                {
                    columnSize = 3;
                }
                else if (y >= 3 && y < 6)
                {
                    columnSize = 6;
                }
                else if (y >= 6 && y < 9)
                {
                    columnSize = 9;
                }
            }
            else if (x >= 6 && x < 9)
            {
                rowSize = 9;
                if (y < 3)
                {
                    columnSize = 3;
                }
                else if (y >= 3 && y < 6)
                {
                    columnSize = 6;
                }
                else if (y >= 6 && y < 9)
                {
                    columnSize = 9;
                }
            }
        }

        public static string SudokuQuadrantChecker(string strArr, int size)
        {
            // Removing unnecessary characters such as commas and parentheses

            //for (int row = 0; row < size; row++)
            //{
            //    for (int col = 0; col < strArr[row].length(); col++)
            //    {
            //        if (strArr[row][col] == '(' || strArr[row][col] == ')' || strArr[row][col] == ',')
            //        {
            //            strArr[row].erase(strArr[row].begin() + col);
            //        }
            //    }
            //}

            // Analyzing the rules
            string quadrant = "";
            int rowIndex = 0, colIndex = 0;
            for (int x = 0; x < size; x++)
            {
                //for (int current = 0; current < size; current++)
                //{
                //    for (int y = 0; y < size; y++)
                //    {
                //        // Checking for repetition in rows and columns
                //        if (strArr[x][current] == strArr[x][y] && y != current && strArr[x][current] != 'x') // Rows
                //        {
                //            quadrantLocation(quadrant, x, current); // Function call to provide the error location
                //            break;
                //        }
                //        else if (strArr[x][current] == strArr[y][current] && y != x && strArr[x][current] != 'x') // Columns
                //        {
                //            quadrantLocation(quadrant, x, current); // Function call to provide the error location
                //            break;
                //        }
                //        else if (strArr[x][current] != 'x')
                //        {
                //            quadrantLocation(x, current, rowIndex, colIndex); // Function call to provide the current quadrant we need to analyze
                //            int i=0, z=0;
                //            // Switch statements to find the starting index for the current quadrant
                //            switch (rowIndex)
                //            {
                //                case 3:
                //                    i = 0;
                //                    break;
                //                case 6:
                //                    i = 3;
                //                    break;
                //                case 9:
                //                    i = 6;
                //                    break;
                //            }
                //            switch (colIndex)
                //            {
                //                case 3:
                //                    z = 0;
                //                    break;
                //                case 6:
                //                    z = 3;
                //                    break;
                //                case 9:
                //                    z = 6;
                //                    break;
                //            }
                //            // Loop to check if numbers repeat in the current quadrant
                //            //for (i; i < rowIndex; i++)
                //            //{
                //            //    for (z; z < colIndex; z++)
                //            //    {
                //            //        if (x == i && z == current)
                //            //        {
                //            //            continue;
                //            //        }
                //            //        else if (strArr[x][current] == strArr[i][z]) // Check if the numbers repeat
                //            //        {
                //            //            // Function call to find error location when the quadrant contains repeating numbers
                //            //            quadrantLocation(quadrant, i, z);
                //            //            break;
                //            //        }
                //            //    }
                //            //}
                //        }
                //    }
                //}
            }

            if (quadrant.Length > 0)
            {
                quadrant.Remove(quadrant[0] + 0);
                for (int r = 0; r < quadrant.Length; r++) // Safeguard in the case we have the same quadrant listed multiple times
                {
                    if (char.IsDigit(quadrant[r]))
                    {
                        for (int t = 0; t < quadrant.Length; t++)
                        {
                            if (t == r)
                            {
                                continue;
                            }
                            else if (char.IsDigit(quadrant[t]) && quadrant[r] == quadrant[t])
                            {
                                quadrant.Remove(quadrant[0] + t);
                                quadrant.Remove(quadrant[0] + (t - 1));
                            }
                        }
                    }
                }
                return quadrant;
            }
            else
            {
                return "legal";
            }
        }


        public static string FibonacciChecker(int num)
        {
            int fn = 0, firstFn = 1, sum = firstFn + 1;
            while (fn < num)
            {
                if (fn != 0)
                {
                    firstFn = sum;
                    sum = fn;
                }
                fn = sum + firstFn;
            }
            if (fn == num || num == 1 || num == 2)
            {
                return "yes";
            }
            return "no";

        }
        public static string TwoSum(int[] arr)
        {
            string sum = "";
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == arr[0])
                    {
                        sum += $"{arr[i]},{arr[j]} ";
                    }
                }
            }
            if (sum.Length == 0)
            {
                return "-1";
            }
            // code goes here  
            return sum;

        }

        //public static int PermutationStep(int num)
        //{

        //    //string newNum = num.ToString();
        //    //string firstHalf = "";
        //    //string secondHalf = "";
        //    //for (int i = (newNum.Length - 1); i >= 0; i--)
        //    //{

        //    //    if (int.Parse(newNum[i].ToString()) > int.Parse(newNum[i - 1].ToString()))
        //    //    {
        //    //        newNum = (newNum.Substring(i - 1, newNum[i])) + newNum.Substring(2, newNum[i - 1]);
        //    //        firstHalf = newNum.Substring(0, i);
        //    //        secondHalf = newNum.Substring(i);
        //    //        break;
        //    //    }
        //    //    else
        //    //    {
        //    //        return -1;
        //    //    }
        //    //}
        //    //List<char> secondCh = new List<char>();
        //    //foreach (var item in firstHalf)
        //    //{
        //    //    secondCh.Add(item);

        //    //}
        //    //    secondCh.Sort();
        //    //var sorted = secondCh
        //    //return num.ToString().sor;

        //}

        public static List<T> Splice<T>(this List<T> source, int index, int count)
        {
            var items = source.GetRange(index, count);
            source.RemoveRange(index, count);
            return items;
        }

        public static string DashInsert(string str)
        {
            int b = 0;
            while (b < str.Length - 1)
            {
                if (int.Parse(str[b].ToString()) % 2 == 1
                    && int.Parse(str[b + 1].ToString()) % 2 == 1)
                {
                    str = str.Substring(0, b + 1) + "-" + str.Substring(b + 1);
                    b = b + 2;
                }
                else
                {
                    b++;
                }
            }
            return str;
        }

        public static string abcd(string ch)
        {
            if (int.Parse(ch.ToString()) % 2 != 0)
            {
                return ch + "-";
            }
            return ch;
        }

        public static string ChessboardTraveling(string str)
        {
            int t11 = 0, t12 = 0, t21 = 0, t22 = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    for (int j = i + 1; j < str.Length; j++)
                    {
                        if (str[j] == ')')
                        {
                            if (i == 0)
                            {
                                t11 = int.Parse(str[i + 1].ToString());
                                t12 = int.Parse(str[i + 3].ToString());
                            }
                            if (i == 5)
                            {
                                t21 = int.Parse(str[i + 1].ToString());
                                t22 = int.Parse(str[i + 3].ToString());
                            }
                        }
                    }
                }
            }
            int xDiff = t21 - t11;
            int yDiff = t22 - t12;
            return Steps(xDiff, yDiff).ToString();
        }

        private static int Steps(int x, int y)
        {
            if (x < 0 || y < 0)
                return 0;
            if (x == 0 && y == 1)
                return 1;
            if (x == 1 && y == 0)
                return 1;

            return Steps(x - 1, y) + Steps(x, y - 1);
        }



        public static int CoinDeterminer(int num)
        {
            int count = 0;
            int[] numbers = new int[] { 1, 5, 7, 9, 11 };
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (num >= numbers[i])
                {
                    num -= numbers[i];
                    count++;
                }
            }
            return count;

        }
        public static bool SimpleSymbols(string str)
        {
            if (!char.IsSymbol(str[0]) || !char.IsSymbol(str[str.Length - 1]))
            {
                return false;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (i - 1 > 0 && i + 1 < str.Length)
                {
                    if (!char.IsSymbol(str[i]) && !char.IsSymbol(str[i - 1]) && !char.IsSymbol(str[i + 1]))
                    {
                        return false;
                    }
                }


            }
            return true;
        }
        public static string RomanNumeralReduction(string str)
        {
            int number = RomanToDecimal(str);
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romanLiterals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            string roman = "";
            for (int i = 0; i < values.Length; i++)
            {
                while (number >= values[i])
                {
                    number -= values[i];
                    roman += romanLiterals[i];
                }
            }
            return roman.ToString();
        }

        public static int Value(char v)
        {
            switch (v)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return -1;
            }
        }

        public static int RomanToDecimal(string str)
        {
            int res = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int s1 = Value(str[i]);
                if (i + 1 < str.Length)
                {
                    int s2 = Value(str[i + 1]);
                    if (s1 >= s2)
                    {
                        res += s1;
                    }
                    else
                    {
                        res += s2 - s1;
                        i++;
                    }
                }
                else
                {
                    res += s1;
                    i++;
                }
            }
            return res;
        }


        public static int SimpleMode(int[] arr)
        {
            int mode = 0;
            int count2 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j] && i != j)
                    {
                        count++;
                    }
                    if (count > count2)
                    {
                        mode = arr[i];
                        count2 = count;
                        count = 0;
                    }

                }
            }
            if (count2 == 0)
            {
                return -1;
            }
            return mode;


        }



        public static bool Palindrome(string str)
        {

            char[] chars = str.ToCharArray();
            string newStr = "";
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    newStr += chars[i];
                }
            }
            chars = newStr.ToCharArray();
            Array.Reverse(chars);
            string reversedStr = new string(chars);
            if (reversedStr.Equals(newStr))
            {
                return true;
            }
            return false;

        }


        public static string FirstReverse(string str)
        {

            // code goes here  
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            //str = chars.ToString();
            return new string(chars);

        }

        public class OBJ
        {
            public int? FirstIndex { get; set; }
            public int? LastIndex { get; set; }
            public string Numbers { get; set; }
        }

        public static string GetRevorse(string numbers)
        {
            char[] chars = numbers.ToCharArray();
            Array.Reverse(chars);
            numbers = new string(chars);
            return numbers;
        }

        public static OBJ GetNumbers(string text)
        {
            string numbers = "";
            OBJ obj = new OBJ();
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (ch >= 48 && ch <= 57)
                {
                    for (int j = 0; j < i; j++)
                    {
                        char charTwo = text[j];
                        if (ch >= 48 && ch <= 57)
                        {
                            obj.FirstIndex = j;
                            break;
                        }
                    }
                    obj.LastIndex = i;
                    numbers = numbers + ch;
                }
            }
            obj.Numbers = numbers;
            return obj;
        }

        public static string ToLowerAndToUpper(string text)
        {
            string s = "";
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (ch >= 97 && ch <= 122)
                {
                    s = s + ch.ToString().ToUpper();
                }

                else if (ch >= 65 && ch <= 90)
                {
                    s = s + ch.ToString().ToLower();
                }
                else
                {
                    s = s + ch;
                }
            }

            return s;

        }

        public static string SwapII(string str)
        {
            string s = "";
            List<string> strings = str.Split(" ").ToList();
            foreach (string strin in strings)
            {
                string newText = "";
                OBJ numbers = GetNumbers(strin);
                if (numbers.Numbers.Length < 2)
                {
                    s = s + ToLowerAndToUpper(strin);
                }
                else if (numbers.Numbers.Length == 2)
                {
                    string revorcedNumbers = GetRevorse(new string(numbers.Numbers));

                    newText = strin.Substring(0, numbers.FirstIndex ?? 0) + revorcedNumbers[0] + strin
                        .Substring(numbers.FirstIndex + 1 ?? 0, numbers.LastIndex - 1 ?? 0) + revorcedNumbers[1];
                }

                s = s + newText + " ";
            }
            return s;

        }

        private static string SearchingChallenge2(string str)
        {
            int number = int.Parse(str);
            List<int> arr = new List<int>();
            List<int> multiple = new List<int>();
            int sumTotal = 0;

            for (int i = 0; i < number; i++)
            {
                arr.Add(i);
            }
            for (int i = 0; i < arr.Count; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    multiple.Add(i);
                }
            }
            foreach (var item in multiple)
            {
                sumTotal += item;
            }
            return sumTotal.ToString();

        }





        //public static string SearchingChallenge(string str)
        //{
        //    List<Match> matches = new List<Match>();
        //    matches.Add(Regex.Match(str, "/([\\d]+)/g"));
        //    int total = 0;

        //    //foreach (var match in matches)
        //    //{
        //    //    total += ;
        //    //}
        //    for (int i = 0; i < matches.Count; i++)
        //    {
        //        string number = matches[i].ToString();
        //        total += int.Parse(number);
        //    }
        //    return total.ToString();
        //}

        public static string SearchingChallenge(string str)
        {

            // code goes here  
            List<int> adjacentNumbers = new List<int>();
            List<int> separateNumbers = new List<int>();
            int sumAdjectNumber = 0;
            int sumSeparateNumber = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                if (ch >= 48 && ch <= 57)
                {
                    if (i != 0)
                    {
                        if (ch >= 48 && ch <= 57 && str[i - 1] <= 48 && str[i - 1] >= 57)
                        {
                            separateNumbers.Add(int.Parse(ch.ToString()));
                        }
                        else if (ch >= 48 && ch <= 57 && str[i - 1] >= 48 && str[i - 1] <= 57)
                        {
                            string n = ch.ToString() + str[i + 1].ToString();
                            adjacentNumbers.Add(int.Parse(n));
                        }
                    }
                    else if (str[i] == 0 && str[i + 1] >= 48 && str[i + 1] <= 57)
                    {
                        string n = ch.ToString() + str[i + 1].ToString();
                        adjacentNumbers.Add(int.Parse(n));
                    }

                }




            }
            foreach (int number in adjacentNumbers)
            {
                sumAdjectNumber += number;
            }
            foreach (int number in separateNumbers)
            {
                sumSeparateNumber += number;
            }
            return (sumAdjectNumber + sumSeparateNumber).ToString();

        }






        public static string StringChallenge(string str)
        {
            string S = "";

            int c = 0, p1 = 0;

            for (int i = 0; i < str.Length; i++)

            {

                char ch = str[i];

                if (ch >= 97 && ch <= 122)

                {

                    S = S + ch.ToString().ToUpper();

                }

                else if (ch >= 65 && ch <= 90)

                {

                    S = S + ch.ToString().ToLower();

                }

                else if (ch >= 48 && ch <= 57)

                {

                    c++;

                    if (c < 2)

                    {

                        p1 = i;

                        S = S + ch;

                    }

                    else

                    {

                        S = S + S[p1];

                        S = S.Substring(0, p1) + ch + S.Substring(p1 + 1);

                    }

                }

                else

                {

                    S = S + ch;

                }

            }

            return S;

        }
        public class Team
        {
            public string teamName { get; set; }
            public int noOfPlayers { get; set; }

            public Team(string teamName, int noOfPlayers)
            {
                this.teamName = teamName;
                this.noOfPlayers = noOfPlayers;
            }

            public void AddPlayer(int count)
            {
                noOfPlayers = noOfPlayers + count;
            }

            public bool RemovePlayer(int count)
            {
                noOfPlayers = noOfPlayers - count;
                if (noOfPlayers < 0)
                {
                    return false;
                }
                return true;
            }
        }

        public class Subteam : Team
        {

            public Subteam(string teamName, int noOfPlayers) : base(teamName, noOfPlayers)
            {

            }

            public void ChangeTeamName(string name)
            {
                base.teamName = name;
            }

        }

        public class Note
        {
            public string Name { get; set; }
            public string State { get; set; }
        }
        public class NotesStore
        {
            List<Note> _notes;
            public NotesStore()
            {
                _notes = new List<Note>();
            }
            public void AddNote(String state, String name)
            {
                if (name is null)
                {
                    throw new Exception("Name cannot be empty");
                }
                GetNotes(state);
                Note note = new Note();
                note.Name = name;
                note.State = state;
                _notes.Add(note);

            }
            public List<String> GetNotes(String state)
            {
                List<string> notes = new List<string>() { "completed", "active", "others" };
                List<string> searchingNotes = new List<string>();
                foreach (string note in notes)
                {
                    if (note == state)
                    {
                        searchingNotes.Add(note);
                    }
                    else if (note != state)
                    {
                        throw new Exception($"Invalid state {state}");
                    }
                }
                return searchingNotes;
            }
        }

        //var notesStoreObj = new NotesStore();
        //var n = int.Parse(Console.ReadLine());
        //for (var i = 0; i < n; i++)
        //{
        //    var operationInfo = Console.ReadLine().Split(' ');
        //    try

        //    {
        //        if (operationInfo[0] == "AddNote")
        //            notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
        //        else if (operationInfo[0] == "GetNotes")
        //        {
        //            var result = notesStoreObj.GetNotes(operationInfo[1]);
        //            if (result.Count == 0)
        //                Console.WriteLine("No Notes");
        //            else
        //                Console.WriteLine(string.Join(",", result));
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid Parameter");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error: " + e.Message);
        //    }
        //}

        //string text = Console.ReadLine();
        //string[] strings = text.Split(" ");
        //for (int i = 0; i < strings.Length; i++)
        //{
        //    if (i == 0)
        //    {
        //        Console.Write(StringChallenge(strings[i]));
        //    }
        //    else
        //    {
        //        Console.Write(" " + StringChallenge(strings[i]));
        //    }
        //}



        //Console.WriteLine(SearchingChallenge2(Console.ReadLine()));
    }

}

