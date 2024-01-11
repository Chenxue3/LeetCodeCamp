/*
 * @lc app=leetcode id=144 lang=csharp
 *
 * [144] Binary Tree Preorder Traversal
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
    public IList<int> PreorderTraversal(TreeNode root) {
        
        return myTraversal(root, new List<int>());
    }

    private IList<int> myTraversal(TreeNode root, IList<int> result){
        
        if(root == null){
            return result;
        }

        result.Add(root.val);

         myTraversal(root.left, result);
         myTraversal(root.right, result);

        return result;
    }
}
// @lc code=end

