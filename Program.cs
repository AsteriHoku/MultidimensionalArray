﻿string gridString = "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08\n" +
                    "49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00\n" +
                    "81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65\n" +
                    "52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91\n" +
                    "22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80\n" +
                    "24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50\n" +
                    "32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70\n" +
                    "67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21\n" +
                    "24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72\n" +
                    "21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95\n" +
                    "78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92\n" +
                    "16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57\n" +
                    "86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58\n" +
                    "19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40\n" +
                    "04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66\n" +
                    "88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69\n" +
                    "04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36\n" +
                    "20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16\n" +
                    "20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54\n" +
                    "01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";

int[,] grid = ConvertToMultidimensionalArray(gridString, 20, 20);

Console.WriteLine($"grid.GetUpperBound(0) is {grid.GetUpperBound(0)}");
Console.WriteLine($"grid.GetUpperBound(1) is {grid.GetUpperBound(1)}");
Console.WriteLine($"grid.Rank is {grid.Rank}");
Console.WriteLine($"grid.GetLowerBound(0) is {grid.GetLowerBound(0)}");
Console.WriteLine($"grid.GetLowerBound(1) is {grid.GetLowerBound(1)}");
Console.WriteLine($"grid.Length is {grid.Length}");
Console.WriteLine($"        grid is:");
int index = 0;
foreach (var n in grid)
{
    if (index == grid.GetUpperBound(1))
    {
        index = 0;
        Console.WriteLine($"{n}, ");
    }
    else
    {
        index++;
        Console.Write($"{n}, ");
    }
}

Console.WriteLine();

long sum = 0;

for (int i = 0; i <= grid.GetUpperBound(0); i++)
{
    for (int j = 0; j < 20; j++)
    {
        // product for 4 l->r
        if (i < grid.GetUpperBound(1) - 4)
        {
            var prod = grid[i, j] * grid[i + 1, j] * grid[i + 2, j] * grid[i + 3, j];
            if (prod > sum)
            {
                sum = prod;
            }
        }

        // product for 4 t->b
        if (j < grid.GetUpperBound(0) - 4)
        {
            var prod = grid[i, j] * grid[i, j + 1] * grid[i, j + 2] * grid[i, j + 3];
            if (prod > sum)
            {
                sum = prod;
            }

            // product for 4 diagonal pointing down
            // i & j both need to be no less than 4 from bottom right index
            if (i < grid.GetUpperBound(1) - 4)
            {
                var dprod = grid[i, j] * grid[i + 1, j + 1] * grid[i + 2, j + 2] * grid[i + 3, j + 3];
                if (dprod > sum)
                {
                    sum = dprod;
                }
            }

            // product for 4 diagonal pointing up
            // i needs to be at least 4th row, j needs to be no less than 4 from bottom right index
            if (i >= 3)
            {
                var duprod = grid[i, j] * grid[i - 1, j + 1] * grid[i - 2, j + 2] * grid[i - 3, j + 3];
                if (duprod > sum)
                {
                    sum = duprod;
                }
            }
        }
    }
}

Console.WriteLine($"sum is {sum}");


static int[,] ConvertToMultidimensionalArray(string gridString, int rows, int cols)
{
    int[,] grid = new int[rows, cols];
    string[] rowStrings = gridString.Split('\n');

    for (int i = 0; i < rows; i++)
    {
        string[] elementStrings = rowStrings[i].Split(' ');

        for (int j = 0; j < cols; j++)
        {
            grid[i, j] = int.Parse(elementStrings[j]);
        }
    }

    return grid;
}