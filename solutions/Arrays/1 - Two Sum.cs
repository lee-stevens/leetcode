/**
* Problem: #1
* Title: two Sum
* Description: Return an array of two indexes of `nums`, that when added together, produce `target`
* Tags: <<Array>>
*/


// First pass
// O(n*2) - Basic, but expensive solution
using System;
using System.Collections.Generic;
public class SolutionA
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] indexes = new int[2];
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                int result = nums[i] + nums[j];
                if (i != j && result == target)
                {
                    indexes = [i, j];
                }
            }
        }
        return indexes;
    }
}

// Second pass O(n*2)
// Array.IndexOf still searches the all elements of nums, therefore still O(n) inside a O(n) loop
public class SolutionB
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] indexes = new int[2];
        for (int i = 0; i < nums.Length; i++)
        {
            int tar = target - nums[i];
            int b = Array.IndexOf(nums, tar);
            if (b != -1 && i != b)
            {
                indexes = [i, b];
            }
        }
        return indexes;
    }
}

// Third pass O(n) - Top 99% from someone else
// For each num in nums, check if we already have a complimentary key already in map,
// if true, then we have our match,
// if false, then add this value to the dictionary, and move on
public class SolutionC
{
    public int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int, int>(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            // If our map, already has a key which is the same as the compliment,
            // Then get the value (which is actually the index)
            int compliment = target - nums[i];
            if (map.TryGetValue(compliment, out int j))
            {
                return [i, j];
            }

            // Map the value (Now the key), to the index (which was the key)
            map[nums[i]] = i;
        }

        return [];
    }
}