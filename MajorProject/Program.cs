
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class Program
{
    public static void Main()
    {
    }

}


class Solutions
{

    public static List<int> permutationEquation(List<int> p)
    {
        List<int> result = new();
        for (var i = 1; i <= p.Count; i++)
        {
            var firstIndex = p.FindIndex(x => x.Equals(i)) + 1;
            var indexValue = p.FindIndex(x => x.Equals(firstIndex)) + 1;
            result.Add(indexValue);
        }

        return result;
    }
    public static List<int> circularArrayRotation(List<int> a, int k, List<int> queries)
    {
        List<int> ret = new List<int>();
        int n = a.Count;

        k = k % n;

        List<int> rotated = new List<int>(new int[n]);
        for (int i = 0; i < n; i++)
        {
            rotated[(i + k) % n] = a[i];
        }

        foreach (int query in queries)
        {
            ret.Add(rotated[query]);
        }

        return ret;
    }
    public static int saveThePrisoner(int n, int m, int s)
    {

        int result = ((m % n) + (s - 1)) % n;
        return result == 0 ? n : result;
    }

    public static int viralAdvertising(int n)
    {
        var likedByPeople = 0;
        var sharedWithPeople = 5;
        for (int i = 1; i <= n; i++)
        {
            likedByPeople += sharedWithPeople / 2;
            sharedWithPeople = (sharedWithPeople / 2) * 3;
        }
        return likedByPeople;
    }

    public static int beautifulDays(int i, int j, int k)
    {
        int beautifulDaysCount = 0;
        for (int _ = i; _ <= j; _++)
        {
            int reversed = Convert.ToInt32(new string(_.ToString().ToCharArray().Reverse().ToArray()));
            int dif = Math.Abs(reversed - _);
            beautifulDaysCount = dif % k == 0 ? beautifulDaysCount + 1 : beautifulDaysCount;
        }

        return beautifulDaysCount;
    }

    public static string angryProfessor(int k, List<int> a)
    {
        int onTime = a.Where(_ => _ <= 0).Count();
        return onTime >= k ? "NO" : "YES";
    }

    public static int utopianTree(int n)
    {
        int height = 1;
        for (int i = 1; i <= n; i++)
        {
            height = i % 2 == 1 ? 2 * height : height + 1;
        }

        return height;
    }
    public static int designerPdfViewer(List<int> h, string word)
    {
        char[] ch = word.ToCharArray();
        int maxHeigh = 0;
        foreach (char c in ch)
        {
            int height = h[c - 'a'];
            maxHeigh = maxHeigh > height ? maxHeigh : height;
        }
        return maxHeigh * ch.Count();
    }
    public static int hurdleRace(int k, List<int> height)
    {
        int maxHeight = height.Max();
        return k > maxHeight ? 0 : maxHeight - k;
    }

    public static int pickingNumbers(List<int> a)
    {
        int cur = 0;
        foreach (int i in a)
        {
            List<int> newArr = a.Where(b => (i - b >= 0 && i - b <= 1)).Select(b => b).ToList();
            int newcount = newArr.Count();
            cur = cur > newcount ? cur : newcount;
        }
        return cur;
    }


    static string catAndMouse(int x, int y, int z)
    {
        int distB = Math.Abs(z - y);
        int distA = Math.Abs(z - x);
        if (distB == distA)
        {
            return "Mouse C";
        }

        if (distB > distA)
        {
            return "Cat A";
        }
        else
        {
            return "Cat B";
        }

    }

    static int getMoneySpent()
    {
        int b = 10;
        int[] keyboards = [3, 1];
        int[] drives = [5, 2, 8];
        var sum = from drive in drives
                  from keyboard in keyboards
                  select drive + keyboard;
        return (sum.Where(x => b >= x).Count() > 0) ? sum.Where(x => b >= x).Max() : -1;

    }


    public static int countingValleys(int steps, string path)
    {
        int depth = 0;
        int valeCounter = 0;
        bool isVale = false;
        foreach (char x in path.ToCharArray())
        {
            switch (x.ToString())
            {
                case "D":
                    depth--;
                    break;
                case "U":
                    depth++;
                    break;

            }
            if (depth < 0 && !isVale)
            {
                valeCounter++;
            }
            if (depth < 0)
            {
                isVale = true;
            }
            else
            {
                isVale = false;
            }
        }
        return valeCounter;
    }

    public static int pageCount(int n, int p)
    {
        int front = p / 2;
        int back = (n / 2) - front;
        return Math.Min(front, back);

    }

    public static int sockMerchant(List<int> ar)
    {
        var groupedSocks = ar.GroupBy(i => i)
                            .Select(g => new { g.Key, Count = g.Count() })
                            .Select(s => new { s.Key, Pair = s.Count / 2 })
                            .Sum(su => su.Pair);
        return 1;
    }


    public static string dayOfProgrammer(int year)
    {
        if (year == 1918)
        {
            return "26.09.1918";
        }
        if (year < 1918)
        {
            bool isLeap = year % 4 == 0;
            return isLeap ? "12.09." + year : "13.09." + year;
        }
        if (year > 1918)
        {
            bool isLeap = year % 400 == 0 || (year % 4 == 0 & year % 100 > 0);
            return isLeap ? "12.09." + year : "13.09." + year;
        }
        return "";
    }

    public static void bonAppetit(List<int> bill, int k, int b)
    {
        int totalSum = bill.Sum();
        int sumExcAna = totalSum - bill[k];
        int anaShouldPay = sumExcAna / 2;
        if (anaShouldPay != b)
        {
            Console.WriteLine(b - anaShouldPay);
        }
        else
        {
            Console.WriteLine("Bon Appetit");
        }
    }





}
