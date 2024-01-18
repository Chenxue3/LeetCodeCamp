/*
 * @lc app=leetcode id=617 lang=csharp
 *
 * [617] Merge Two Binary Trees
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
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        
        // ending condition
        if(root1 == null){
            return root2;
        }
        if(root2 == null){
            return root1;
        }

        //logic
        TreeNode node = new TreeNode();
        node.val = root1.val + root2.val;
        node.left = MergeTrees(root1.left, root2.left);
        node.right = MergeTrees(root1.right, root2.right);

        return node;
        
        
    }
}
// @lc code=end

