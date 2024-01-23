/*
 * @lc app=leetcode id=538 lang=csharp
 *
 * [538] Convert BST to Greater Tree
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
    public int pre = 0;
    public void Traversal(TreeNode node){
        if(node == null){
            return;
        }
        //因为右总是大于左：
        // right
        Traversal(node.right);
        //mid
        node.val = node.val + pre;
        pre = node.val;
        //left
        Traversal(node.left);

    }
    public TreeNode ConvertBST(TreeNode root) {
        pre = 0;
        Traversal(root);
        return root;
    }
}
// @lc code=end

