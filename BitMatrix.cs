using System;
using System.Collections;
using System.Collections.Generic;

// prostokątna macierz bitów o wymiarach m x n
public class BitMatrix : IEquatable<BitMatrix>
{
    private BitArray data;
    public int NumberOfRows { get; }
    public int NumberOfColumns { get; }
    public bool IsReadOnly => false;

    public BitMatrix(int numberOfRows, int numberOfColumns, int defaultValue = 0)
    {
        if (numberOfRows < 1 || numberOfColumns < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");
        data = new BitArray(numberOfRows*numberOfColumns, BitToBool(defaultValue));
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;           
    }
    
    public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
    {
        if (numberOfRows < 1 || numberOfColumns < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");
        data = new BitArray(numberOfRows * numberOfColumns, false);

        if (bits != null)
        {
            for (int i = 0; i < bits.Length && i < data.Length; i++)
            {
                if (bits[i] != 0)
                    data[i] = true;
            }
        }

        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
    }

    public BitMatrix(int[,] bits)
    {
        if (bits is null)
            throw new NullReferenceException("bits cannot be null");

        int numberOfRows = bits.GetLength(0);
        int numberOfColumns = bits.GetLength(1);

        if (numberOfRows < 1 || numberOfColumns < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");

        data = new BitArray(numberOfRows * numberOfColumns, false);

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                if (bits[row, col] != 0)
                    data[row * numberOfColumns + col] = true;
            }
        }

        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
    }

    public BitMatrix(bool[,] bits)
    {
        if (bits is null)
            throw new NullReferenceException("bits cannot be null");

        int numberOfRows = bits.GetLength(0);
        int numberOfColumns = bits.GetLength(1);

        if (numberOfRows < 1 || numberOfColumns < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");

        data = new BitArray(numberOfRows * numberOfColumns, false);

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                if (bits[row, col])
                    data[row * numberOfColumns + col] = true;
            }
        }

        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
    }

    public static int BoolToBit(bool boolValue) => boolValue ? 1 : 0;
    public static bool BitToBool(int bit) => bit != 0;

    public override string ToString()
    {
        var result = "";
        for (int row = 0; row < NumberOfRows; row++)
        {
            for (int col = 0; col < NumberOfColumns; col++)
            {
                int index = row * NumberOfColumns + col;
                result += BoolToBit(data[index]);
            }
            result += Environment.NewLine; // dodanie znaku końca linii
        }
        return result;
    }

    public bool Equals(BitMatrix? matrix)
    {
        if (object.ReferenceEquals(this, matrix)) return true;
        
        if (matrix is null || this.NumberOfRows != matrix.NumberOfRows || this.NumberOfColumns != matrix.NumberOfColumns) return false;

        for (int i = 0; i < data.Length; i++)
        {
            if (this.data[i] != matrix.data[i]) return false;
        } 

        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType()) return false;
        else return Equals((BitMatrix)obj);
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + NumberOfRows.GetHashCode();
        hash = hash * 23 + NumberOfColumns.GetHashCode();
        
        for (int i = 0; i < data.Length; i++)
        {
            hash = hash * 23 + data[i].GetHashCode();
        }
        return hash;
    }

    public static bool operator ==(BitMatrix matrix1, BitMatrix matrix2)
    {
        if (ReferenceEquals(matrix1, matrix2)) return true;

        if (matrix1 is null || matrix2 is null) return false;

        return matrix1.Equals(matrix2);
    }

    public static bool operator !=(BitMatrix matrix1, BitMatrix matrix2)
    {
        return !(matrix1 == matrix2);
    }
}