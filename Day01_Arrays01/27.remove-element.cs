/*
 * @lc app=leetcode id=27 lang=csharp
 *
 * [27] Remove Element
 */

// @lc code=start
public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int slowPointer = 0;
        int fastPointer = 0;
        for(fastPointer = 0; fastPointer < nums.Length; fastPointer ++){
            if(nums[fastPointer] != val){
                nums[slowPointer] = nums[fastPointer];
                slowPointer ++;
            }
        }
        return slowPointer;
    }
}
// @lc code=end

