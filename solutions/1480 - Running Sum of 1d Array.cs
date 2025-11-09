/**
* Problem: #1480
* Title: Running Sum of 1d Array
* Description: Given an array of ints, produce a new array of a running sum of the 1d ints array
* Tags: <<Arrays>>,
*/

// First pass O(n) - 0ms
public class Solution
{
  public int[] RunningSum(int[] nums)
  {
    int[] runningSum = new int[nums.Length];
    runningSum[0] = nums[0];
    for (int i = 1; i < nums.Length; i++)
    {
      runningSum[i] = runningSum[i - 1] + nums[i];
    }
    return runningSum;
  }
}


// From Claude Sonnet - 0ms
public class SolutionB {
  public int[] RunningSum(int[] nums) {
    for (int i = 1; i < nums.Length; i++) {
      nums[i] += nums[i - 1];
    }
    return nums;
  }
}