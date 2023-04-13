using System;
using System.Collections;

namespace Test;
class Program
{
    static void Main(string[] args)
    {
        // konstruktor BitMatrix(int, int, params int[])
        // macierz 2x2, komplet danych w tablicy
        var m = new BitMatrix(2, 2, new int[] { 1, 0, 0, 1 });
        Console.WriteLine(m);

        m = new BitMatrix(2, 2, 1, 0, 0, 0);
        Console.WriteLine(m);


        // konstruktor BitMatrix(int, int, params int[])
        // macierz 2x2, za dużo danych w tablicy
        var n = new BitMatrix(2, 2, 1, 0, 0, 1, 1, 1, 0);
        Console.WriteLine(n);

        // macierz 3x2, za mało danych w tablicy
        n = new BitMatrix(3, 2, 1, 0, 0, 1, 1);
        Console.WriteLine(n);


        // konstruktor BitMatrix(int[,])
        int[,] arr = new int[,] { { 1, 0, 1 }, { 0, 1, 1 } };
        var o = new BitMatrix(arr);
        Console.WriteLine(arr.GetLength(0) == o.NumberOfRows);
        Console.WriteLine(arr.GetLength(1) == o.NumberOfColumns);
        Console.Write(o.ToString());
        Console.WriteLine();

        var m1 = new BitMatrix(5, 6);
        var m2 = m1;
        Console.WriteLine(m1.Equals(m2));

        var m3 = new BitMatrix(5, 6);
        var m4 = new BitMatrix(6, 5);
        Console.WriteLine(m3.Equals(m4));
    }
}
