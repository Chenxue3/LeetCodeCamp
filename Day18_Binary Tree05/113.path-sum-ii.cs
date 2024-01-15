/*
 * @lc app=leetcode id=113 lang=csharp
 *
 * [113] Path Sum II
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
    private List<List<int>> result = new List<List<int>>();
    private List<int> path = new List<int>();

    // Main function to find paths with the given sum
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        result.Clear();
        path.Clear();
        if (root == null) return result.Select(list => list as IList<int>).ToList();
        path.Add(root.val); // Add the root node to the path
        traversal(root, targetSum - root.val); // Start the traversal
        return result;
    }

    // Recursive function to traverse the tree and find paths
    private void traversal(TreeNode node, int count) {
        // If a leaf node is reached and the target sum is achieved
        if (node.left == null && node.right == null && count == 0) {
            result.Add(new List<int>(path)); // Add a copy of the path to the result
            return;
        }

        // If a leaf node is reached and the target sum is not achieved, or if it's not a leaf node
        if (node.left == null && node.right == null) return;

        // Traverse the left subtree
        if (node.left != null) {
            path.Add(node.left.val);
            count -= node.left.val;
            traversal(node.left, count);    // Recursive call
            count += node.left.val;        // Backtrack
            path.RemoveAt(path.Count - 1); // Backtrack
        }

        // Traverse the right subtree
        if (node.right != null) {
            path.Add(node.right.val);
            count -= node.right.val;
            traversal(node.right, count);   // Recursive call
            count += node.right.val;       // Backtrack
            path.RemoveAt(path.Count - 1); // Backtrack
        }
    }
}

// @lc code=end

