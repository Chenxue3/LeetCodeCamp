/*
 * @lc app=leetcode id=700 lang=csharp
 *
 * [700] Search in a Binary Search Tree
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
    public TreeNode SearchBST(TreeNode root, int val) {
        // 递归
        /*
        TreeNode node = null;
        
        if(root == null){
            return null;
        }

        if(root.val == val){
            return root;
        }
        if(root.val < val){
            node = SearchBST(root.right, val);
        }
        else{
            node = SearchBST(root.left, val);
        }

        return node;
        */

        // 迭代
        while(root != null){
            if(root.val == val){
                return root;
            }
            if(root.val < val){
                root = root.right;
            } 
            else if(root.val > val){
                root = root.left;
            }
        }
        return null;
    }
}
// @lc code=end

