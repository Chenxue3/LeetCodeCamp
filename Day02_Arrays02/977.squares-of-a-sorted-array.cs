/*
 * @lc app=leetcode id=977 lang=csharp
 *
 * [977] Squares of a Sorted Array
 */

// @lc code=start
public class Solution {
    public int[] SortedSquares(int[] nums) {
        // the pointer points to the start
        int start = 0;

        // the pointer points to the end
        int end = nums.Length - 1;

        // using k to record the current position for new add elements
        int k = end;

        // define a new array
        int[] sortedArr = new int[nums.Length];

        // loop, ends when the start pointer points to the element that the end pointer has went through.
        while(start <= end){
            // add the bigger one into the end of the new array
            if(nums[start] * nums[start] > nums[end] * nums [end]){
                sortedArr[k--] = nums[start] * nums[start];
                start++;
            }
            else{
                sortedArr[k--] = nums[end] * nums [end];
                end--;
            }
        }
        return sortedArr;
    }
}
// @lc code=end

