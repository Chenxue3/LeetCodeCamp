/*
 * @lc app=leetcode id=111 lang=csharp
 *
 * [111] Minimum Depth of Binary Tree
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
public class Solution
{
    public int MinDepth(TreeNode root)
    {
        int res = 0;
        if (root == null)
        {
            return res;
        }
        int minLeft = MinDepth(root.left);
        int minRight = MinDepth(root.right);

        // handle the situation which the node has only one child
        if(root.left == null && root.right != null){
            return 1 + minRight;
        }
        if(root.right == null && root.left != null){
            return 1 + minLeft;
        }
        return 1 + Math.Min(minLeft,minRight);
    }
}
// @lc code=end

