/*
 * @lc app=leetcode id=454 lang=csharp
 *
 * [454] 4Sum II
 */

// @lc code=start
public class Solution {
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
        //store the sums of nums1 and nums2
        Dictionary<int, int> dic = new Dictionary<int, int>();  

        // all the array have the same length
        int l = nums1.Length;

        for (int num1 = 0; num1 < l; num1++)
        {
            for (int num2 = 0; num2 < l; num2++)
            {
                int sum = nums1[num1] + nums2[num2];
                // add the time of the sum appears as the value, the sum as the key
                if(dic.ContainsKey(sum)){
                    dic[sum]++;
                }else{
                    dic.Add(sum, 1);
                }
            }
        }

        //define a counter to record
        int counter = 0;
        //then calculate the sums of nums3 and nums 4

        for (int num3 = 0; num3 < l; num3++)
        {
            for (int num4 = 0; num4 < l; num4++)
            {
                int minusSum = 0 - nums3[num3] - nums4[num4];
                if(dic.ContainsKey(minusSum)){
                    counter += dic[minusSum];
                }
            }
        }
        return counter;
    }
}
// @lc code=end

