/*
 * @lc app=leetcode id=98 lang=csharp
 *
 * [98] Validate Binary Search Tree
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
    public bool IsValidBST(TreeNode root) {
        // 中序遍历
        List<int> myArray = helper(root, new List<int>());
        for (int i = 1; i < myArray.Count; i++)
        {
            if(myArray[i-1] >= myArray[i]){
                return false;
            }
        }
        
        return true;
    }

     private List<int> helper(TreeNode root, List<int> res)
    {
        if (root == null)
        {
            return res;
        }

        helper(root.left, res);
        res.Add(root.val);
        helper(root.right, res);


        return res;

    }
}
// @lc code=end

