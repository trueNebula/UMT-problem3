# problem3
 
Split array problem

In a given integer array A, we must move every element of A to either list B or list C. (B and C
initially start empty.)
Return true if and only if after such a move, it is possible that the average value of B is equal to
the average value of C, and B and C are both non-empty.

Sample input:
[1,2,3,4,5,6,7,8]
Sample output:
True

Explanation: We can split the array into [1,4,5,8] and [2,3,6,7], and both of them have the average
of 4.5.
Note:
The length of A will be in the range [1, 30].
A[i] will be in the range of [0, 10000].