/*
 * @lc app=leetcode id=145 lang=csharp
 *
 * [145] Binary Tree Postorder Traversal
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
    public IList<int> PostorderTraversal(TreeNode root) {
        //注意这里只能使用new创建List不能创建IList
        return myRecursive(root, new List<int>());
    }
    
    private IList<int> myRecursive(TreeNode root, IList<int> res){
        if(root == null){
            return res;
        }

        myRecursive(root.left,res);
        myRecursive(root.right,res);
        res.Add(root.val);

        return res;
        
    }
}
// @lc code=end

