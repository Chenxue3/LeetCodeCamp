/*
 * @lc app=leetcode id=104 lang=csharp
 *
 * [104] Maximum Depth of Binary Tree
 */

// @lc code=start
// 在模板基础的代码上，将返回值变成数列长度即可。
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
    public int MaxDepth(TreeNode root) {
        int res = 0;
        if(root == null){
            return res;
        }

        
        int leftMax = MaxDepth(root.left);
        int rightMax = MaxDepth(root.right);

        return 1 + Math.Max(leftMax,rightMax);
    }
}
// @lc code=end

