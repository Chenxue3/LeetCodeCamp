/*
 * @lc app=leetcode id=112 lang=csharp
 *
 * [112] Path Sum
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
    public bool HasPathSum(TreeNode root, int targetSum) {
        if(root == null){
            return false;
        }
        
        return traversal(root, targetSum - root.val);
    }
    private bool traversal(TreeNode node, int count){
        // ending (leaf node)
        if(node.left == null && node.right == null){
            return count == 0 ? true : false;
        }

        // logic
        if(node.left != null){
            count -= node.left.val;
            if(traversal(node.left, count)) return true;
            // 回溯，使得重新遍历的时候count为target的数
            count += node.left.val;
        }
        if(node.right != null){
            count -= node.right.val;
            if(traversal(node.right, count)) return true;
            // 回溯，使得重新遍历的时候count为target的数
            count += node.right.val;
        }

        return false;
    }
}
// @lc code=end

