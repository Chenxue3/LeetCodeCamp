/*
 * @lc app=leetcode id=513 lang=csharp
 *
 * [513] Find Bottom Left Tree Value
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
    public int FindBottomLeftValue(TreeNode root)
    {
        Queue<TreeNode> que = new Queue<TreeNode>();

        if (root != null)
        {
            que.Enqueue(root);
        }
        
        int ans = 0;
        while (que.Count != 0)
        {
           
            int size = que.Count;
            for (var i = 0; i < size; i++)
            {
                var curNode = que.Peek();
                que.Dequeue();
                if(i == 0){
                    ans = curNode.val;
                }
                if (curNode.left != null)
                {
                    que.Enqueue(curNode.left);
                }
                if (curNode.right != null)
                {
                    que.Enqueue(curNode.right);
                }
            }

        }
        return ans;
    }
}
// @lc code=end

