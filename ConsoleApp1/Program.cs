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
            Console.WriteLine(CoderByteChallange.RomanNumeralReduction("DDLL"));
        }

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
    public class CoderByteChallange
    {
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

