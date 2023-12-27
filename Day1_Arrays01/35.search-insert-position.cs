/*
 * @lc app=leetcode id=35 lang=csharp
 *
 * [35] Search Insert Position
 */

// @lc code=start
public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int left = 0;
        int right = nums.Length - 1;
        while(left <= right){
            int middle = (left + right) / 2;

            if(nums[middle] == target){
                return middle;
            }
            if(nums[middle] > target){
                right = middle -1;
            }
            else if(nums[middle] < target){
                left = middle + 1;
               
            }
        }
        return left;
    }
}
// @lc code=end

