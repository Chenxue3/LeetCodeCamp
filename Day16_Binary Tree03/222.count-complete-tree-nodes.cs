/*
 * @lc app=leetcode id=222 lang=csharp
 *
 * [222] Count Complete Tree Nodes
 */


public class Solution {
    public int CountNodes(TreeNode root) {
        return helper(root);
    }

    /* Type */
    public int helper(TreeNode root){
        /* return condition */
        int num = 0;
        if(root == null){
            return 0;
        }

        /* logic of each time */
       int leftNum = helper(root.left);
       int rightNum = helper(root.right);

       return 1 + leftNum + rightNum; 
    }
}
// @lc code=end

