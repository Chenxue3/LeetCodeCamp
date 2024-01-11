/*
 * @lc app=leetcode id=94 lang=csharp
 *
 * [94] Binary Tree Inorder Traversal
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
    public IList<int> InorderTraversal(TreeNode root)
    {
        return myRecursive(root, new List<int>());
    }

    private IList<int> myRecursive(TreeNode root, IList<int> res)
    {
        if (root == null)
        {
            return res;
        }

        myRecursive(root.left, res);
        res.Add(root.val);
        myRecursive(root.right, res);


        return res;

    }
}
// @lc code=end

