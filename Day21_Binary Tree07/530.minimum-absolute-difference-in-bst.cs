/*
 * @lc app=leetcode id=530 lang=csharp
 *
 * [530] Minimum Absolute Difference in BST
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
    List<int> myList = new List<int>();
    public int GetMinimumDifference(TreeNode root) {
        getOrderedList(root);
        int minNum = -1;
        for (int i = 0; i < myList.Count - 1; i++)
        {
           minNum = Math.Min(myList[i + 1] - myList[i], minNum);
        }
        return minNum;
    }

    public void getOrderedList(TreeNode root){
        if(root == null){
            return;
        }
        getOrderedList(root.left);
        myList.Add(root.val);
        getOrderedList(root.right);

        return;
    }
}
// @lc code=end

