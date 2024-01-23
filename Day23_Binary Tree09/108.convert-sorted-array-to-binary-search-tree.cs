/*
 * @lc app=leetcode id=108 lang=csharp
 *
 * [108] Convert Sorted Array to Binary Search Tree
 */

// @lc code=start

public class Solution {
    public TreeNode SortedArrayToBST(int[] nums) {
       
        if(nums.Count() == 0){
            return null;
        }
        int mid = (nums.Count() - 1) / 2;
        TreeNode node = new TreeNode(nums[mid]);
        int curRoot = nums[mid];
        node.left = SortedArrayToBST(nums[0..mid]);
        node.right = SortedArrayToBST(nums[(mid + 1)..nums.Count()]);

        return node;

    }
}
// @lc code=end

