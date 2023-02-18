/* 
 * Rotate Matrix: Given an image represented by an NxN matrix, where each pixel 
 * in the image is 4 bytes, write a method to rotate the image by 90 degrees. 
 * Can you do this in place?

i = 0
j = 3 = n - i to 

(0, 0) -> (0, 3);
(0, 3) -> (3, 3);
(3, 3) -> (3, 0);
(3, 0) -> (0, 0);

(0, 1) -> (1, 3);
(0, 2) -> (2, 3); (

 */

Int64[,] input = new Int64[4, 4] {
    {   1   ,2  ,3  ,4},
    {   5   ,6  ,7  ,8},
    {   9   ,10 ,11 ,12},
    {   13  ,14 ,15 ,16}
};

Int64[,] output = new Int64[4, 4] {
    {   13   ,9  ,5  ,1},
    {   14   ,10 ,6  ,2},
    {   15   ,11 ,7  ,3},
    {   16   ,12 ,8  ,4}
};

rotateInPlace(input);

static void rotateInPlace(Int64[,] matrix)
{
    int n = matrix.GetLength(0);
    for (int i = 0; i < n; i++)
    {
        for(int j = 0; j< n; j++)
        {

        }
    }
}
