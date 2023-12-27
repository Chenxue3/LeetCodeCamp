/*
 * @lc app=leetcode id=209 lang=csharp
 *
 * [209] Minimum Size Subarray Sum
 */

// @lc code=start
public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int slowPointer, fastPointer = 0;
        int subLength = int.MaxValue;
        int subSum = 0;

        for(fastPointer = 0; fastPointer< nums.Length; fastPointer++){
            subSum += nums[fastPointer];

            while(subSum >= target){
                if(subLength <= fastPointer - slowPointer + 1){
                    subLength =  fastPointer - slowPointer + 1;
                };
                subSum -= nums[slowPointer++];
            }
        }

        return subLength == int.MaxValue ? 0 : subLength; 
    
    }
      
}
// @lc code=end

