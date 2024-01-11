/*
 * @lc app=leetcode id=107 lang=csharp
 *
 * [107] Binary Tree Level Order Traversal II
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
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        Queue<TreeNode> que = new Queue<TreeNode>();
        var res = new List<IList<int>>();
        var reversRes = new List<IList<int>>();

        if (root == null)
        {
            return res;
        }

        que.Enqueue(root);
        while (que.Count > 0)
        {
            var levelList = new List<int>();
            var queSize = que.Count;
            for (int i = 0; i < queSize; i++)
            {
                var cur = que.Dequeue();
                levelList.Add(cur.val);

                if (cur.left != null)
                {
                    que.Enqueue(cur.left);
                }
                if (cur.right != null)
                {
                    que.Enqueue(cur.right);
                }
            }
            res.Add(levelList);
        }

        for (int i = 0; i < res.Count; i++)
        {
            reversRes.Add(res[res.Count -1- i]);
        }
        
        return reversRes;
    }
}
// @lc code=end

