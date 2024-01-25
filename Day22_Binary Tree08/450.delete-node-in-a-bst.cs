/*
 * @lc app=leetcode id=450 lang=csharp
 *
 * [450] Delete Node in a BST
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
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        // 终止条件：节点为空
        if (root == null)
        {
            return null;
        }

        // 当前值大于期望值，说明期望值在左子树，遍历左子树
        if (root.val > key)
        {
            root.left = DeleteNode(root.left, key);
        }

        // 当前值小于期望值，遍历右子树
        else if (root.val < key)
        {
            root.right = DeleteNode(root.right, key);
        }

        // 当当前节点的值等于期望值
        else
        {
            // 如果没有左子树：删除当前节点，只需要返回右子树即可，如果右子树也为空也可以，直接返回null
            if (root.left == null)
            {
                return root.right;
            }

             // 如果没有右子树：删除当前节点，只需要返回左子树即可
            else if (root.right == null)
            {
                return root.left;
            }

            // 如果两个子树都有
            else
            {
                // 在右子树找到值最小的节点
                TreeNode minNode = FindMin(root.right);

                // 将当前值替换为右子树的最小值
                root.val = minNode.val;

                // 在当前节点的右子树中，删除刚刚用于替换的值
                root.right = DeleteNode(root.right, minNode.val);
            }
        }
        return root;
    }
    private TreeNode FindMin(TreeNode node)
    {
        // 右子树的最左节点就是最小值
        while (node.left != null)
        {
            node = node.left;
        }
        return node;
    }
}
// @lc code=end

