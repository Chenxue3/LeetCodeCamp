/*
 * @lc app=leetcode id=654 lang=csharp
 *
 * [654] Maximum Binary Tree
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        
        if(nums == null || nums.Length == 0) {
            return null;
        }

        int maxValue = int.MinValue;
        int maxIndex = -1;

          for (var i = 0; i < nums.Length; i++) 
          {
            if (nums[i] > maxValue) {
                maxIndex = i;
                maxValue = nums[i];
            }
        }

        
        TreeNode node = new TreeNode(nums[maxIndex]);

        //left
        node.left = ConstructMaximumBinaryTree(nums.Take(maxIndex).ToArray());

        //right
        node.right = ConstructMaximumBinaryTree(nums.Skip(maxIndex + 1).ToArray());


        //return
        return node;
        
    }
}
// @lc code=end

