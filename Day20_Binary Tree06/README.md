# Day18


## LeetCode Problems
    
### LC [[513] Find Bottom Left Tree Value](https://leetcode.com/problems/find-bottom-left-tree-value/description/)

#### My Idea: 迭代法 层序遍历

  - Code 
    ```csharp
        /*
        * @lc app=leetcode id=513 lang=csharp
        * 迭代法
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


    ```
    
    

  | Bugs | Test Case & Excepted Output | My Output | Debug |
  | ---- | --------------------------- | --------- | ----- |
  |  0   |[1,2,3] & 1 | 2 |   `if(i == 0){ans = curNode.val;}`应该在for循环中  |
  |   1   |   [1,2,3] & 1   | Time Limit Exceeded | 应该检查当前节点的左右子节点，而不是始终检查根节点的左右子节点`if (root.left != null)` -> `if (curNode.left != null)`|
  

#### Method one: 递归+回溯
  - note: 不回溯的话，在遍历完左边节点之后会把左边节点的深度加在右边节点开始遍历的时候，导致右边节点的深度变大，从而导致错误。

  
  - Code:
    ```csharp
        //递归
        /*
        * @lc app=leetcode id=513 lang=csharp
        *
        * [513] Find Bottom Left Tree Value
        */

        // @lc code=start
       
        public class Solution
        {
            //递归
            int maxDepth = -1;
            int res = 0;
            public int FindBottomLeftValue(TreeNode root)
            {
                Traversal(root, 0);
                return res;
            }
            public void Traversal(TreeNode root, int depth)
            {
                if (root.left == null && root.right == null)
                {
                    if (depth > maxDepth)
                    {
                        maxDepth = depth;
                        res = root.val;
                    }
                    return;
                }
                if (root.left != null)
                {
                    depth++;
                    Traversal(root.left, depth);
                    depth--; // 回溯
                }
                if (root.right != null)
                {
                    depth++;
                    Traversal(root.right, depth + 1);
                    depth--; // 回溯
                }
                return;
            }
        }
        // @lc code=end

### LC [[112] Path Sum](https://leetcode.com/problems/path-sum/description/)
递归法
- Note
  - 递归函数返回值。这里返回bool，表示是否存在这样的路径。有些递归函数返回值是void之类的，是因为需要收集（遍历）所有的节点或者路径，而这题中只需要找到一条路径即可，所以返回bool即可。
```csharp
    /*
 * @lc app=leetcode id=112 lang=csharp
 *
 * [112] Path Sum
 */

// @lc code=start
public class Solution {
    public bool HasPathSum(TreeNode root, int targetSum) {
        if(root == null){
            return false;
        }
        
        return traversal(root, targetSum - root.val);
    }
    private bool traversal(TreeNode node, int count){
        // ending (leaf node)
        if(node.left == null && node.right == null){
            return count == 0 ? true : false;
        }

        // logic
        if(node.left != null){
            count -= node.left.val;
            if(traversal(node.left, count)) return true;
            // 回溯，使得重新遍历的时候count为target的数
            count += node.left.val;
        }
        if(node.right != null){
            count -= node.right.val;
            if(traversal(node.right, count)) return true;
            // 回溯，使得重新遍历的时候count为target的数
            count += node.right.val;
        }

        return false;
    }
}
// @lc code=end

```

### LC [[113] Path Sum II](https://leetcode.com/problems/path-sum-ii/description/)

```csharp
    /*
 * @lc app=leetcode id=113 lang=csharp
 *
 * [113] Path Sum II
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

```