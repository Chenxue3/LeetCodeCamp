/*
 * @lc app=leetcode id=235 lang=csharp
 *
 * [235] Lowest Common Ancestor of a Binary Search Tree
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // 当前节点的值比两个节点的值都大，两个节点应该在当前节点的左子树
        if(root.val > p.val && root.val > q.val){
            return LowestCommonAncestor(root.left, p, q);
        }
        else if(root.val < q.val && root.val < p.val){
            return LowestCommonAncestor(root.right, p, q);
        }
        // 当遍历到当前节点的值在q和p的值之间，说明p和q分别在当前节点的左子树和右子树，当前节点就是最小公共祖先
        else{
            return root;
        }
    }
}
// @lc code=end

