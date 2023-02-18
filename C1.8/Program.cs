﻿

using System.Collections;
using static System.Net.WebRequestMethods;
/**
 * Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0.
 * 
 * 1 1 1 1
 * 1 0 1 1
 * 1 1 0 1
 * 
 * 1 0 0 1
 * 0 0 0 0
 * 0 0 0 0
 * 
 * loop through the matrix and create 2 arrays, one for each dimension length
 * if it is 0, put 1
 * Then loop it again, and if row or col is 1, replace for 0
 * rows = [] {1, 0, 1}
 * cols = [] {1, 0, 1, 1}
 */

int[,] input = new int[3, 4] {

    {5,4,5,3},
    {8,0,4,9},
    {4,3,0,6}
};
int[,] expected = new int[3, 4] {
    {5,0,0,3},
    {0,0,0,0},
    {0,0,0,0}
};

int[,] result = ZeroMatrix(input);
System.Diagnostics.Debug.Assert(result.Equals(expected));

static int[,] ZeroMatrix(int[,] input)
{
    int[] rows = new int[input.GetLength(0)];
    int[] cols = new int[input.GetLength(1)];

    for(int row = 0; row < input.GetLength(0); row++ ) { 
        for(int col = 0; col < input.GetLength(1); col++) {
            if (input[row,col] == 0)
            {
                rows[row] = 1;
                cols[col] = 1;    
	        }
	    }
    }
    for(int row = 0; row < input.GetLength(0); row++ ) { 
        for(int col = 0; col < input.GetLength(1); col++) {
            if (rows[row] == 1 || cols[col] == 1)
                input[row, col] = 0;
	    }
    }
    return input;
}