/*
 * @lc app=leetcode id=349 lang=csharp
 *
 * [349] Intersection of Two Arrays
 */

// @lc code=start

public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        // define a set 1 to record the numbers in nums 1
        HashSet<int> hashSetNums1 = new HashSet<int>();
        
        foreach (var item in nums1)
        {
            hashSetNums1.Add(item);
        }

        // define a set to record numbers that return
        HashSet<int> ans = new HashSet<int>();

        // if nums1 has the same number, add to the ans set
        foreach (var num in nums2)
        {
            if (hashSetNums1.Contains(num))     
            {
                ans.Add(num);
            }
        }

        return ans.ToArray();
    }
}
// @lc code=end

