/*
 * @lc app=leetcode id=102 lang=csharp
 *
 * [102] Binary Tree Level Order Traversal
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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        //define the output
        var res = new List<IList<int>>();
        //define the queue
        Queue<TreeNode> myQueue = new Queue<TreeNode>();

        if(root == null){
            return res;
        }

        // add the root value to the queue
        myQueue.Enqueue(root);
        while (myQueue.Count != 0){
            //record the number of the element at current level
            var size = myQueue.Count;

            //record the elements of current level
            var levelRes = new List<int>();

            //add the elements of current level into the res
            for (int i = 0; i < size; i++)
            {   
                var curNode = myQueue.Dequeue();
                levelRes.Add(curNode.val);
                if(curNode.left != null){
                    myQueue.Enqueue(curNode.left);
                }
                if(curNode.right != null){
                    myQueue.Enqueue(curNode.right);
                }
            }

            //add the sub-list of cur-level into the res
            res.Add(levelRes);

        }

        return res;

    }
}
// @lc code=end

