/*
 * @lc app=leetcode id=110 lang=csharp
 *
 * [110] Balanced Binary Tree
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
    public bool IsBalanced(TreeNode root) {

        return getHeight(root) == -1 ? false : true;

    }

    public int getHeight(TreeNode root){
        if(root == null){
            return 0;
        }

        int left = getHeight(root.left);
        if(left == -1) return -1;

        int right = getHeight(root.right);
        if(right == -1) return -1;

        if(Math.Abs(left - right) > 1){
            return -1;
        }
        // 注意理解这里的返回值
        return 1 + Math.Max(left, right);
    }
    
}
// @lc code=end

