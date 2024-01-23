/*
 * @lc app=leetcode id=669 lang=csharp
 *
 * [669] Trim a Binary Search Tree
 */

// @lc code=start


public class Solution {
    public TreeNode TrimBST(TreeNode root, int low, int high) {
        if(root == null){
            return null;
        }

        if(root.val > high){
            return TrimBST(root.left, low, high);
        }


        if(root.val < low){
            return TrimBST(root.right, low, high);
        }

        root.left = TrimBST(root.left, low, high);
        root.right = TrimBST(root.right, low, high);

        return root;
    }
}
// @lc code=end

