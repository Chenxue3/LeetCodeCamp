/*
 * @lc app=leetcode id=101 lang=csharp
 *
 * [101] Symmetric Tree
 */

// @lc code=start
//  注意是要对比一棵树的左子树和右子树，不是单单是左节点和右节点
public class Solution {
    public bool IsSymmetric(TreeNode root) {
        if(root == null){
            return true;
        }
        return helper(root.left, root.right);
    }

    public bool helper(TreeNode left, TreeNode right){
        /* 终止条件 */
        // 排除形状不同
        if(left == null && right != null){
            return false;
        }
        if(left == null && right == null){
            return true;
        }
        if(left != null && right == null){
            return false;
        }
        // 排除数值不同的情况
        if(left.val != right.val){
            return false;
        }

        
        /* 单层逻辑：*/

        // 最外层的节点是否相同
        bool outside = helper(left.left, right.right);
        // 中间节点是否相同
        bool insider = helper(left.right, right.left);

        return outside & insider;

    }
}
// @lc code=end

