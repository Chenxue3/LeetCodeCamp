# Day16
## Complete Binary Tree
Complete Binary Tree is a binary tree in which all the levels are completely filled except possibly the lowest one, which is filled from the left.
![Alt text](image.png)

## LeetCode Problems
    
### LC [[559] Maximum Depth of N-ary Tree](https://leetcode.com/problems/maximum-depth-of-n-ary-tree/)


  - Code 
    ```csharp
        /*
        递归法
        */
        public class Solution {
            public int MaxDepth(Node root) {
                int res = 0;
                /* 终止条件 */
                if(root == null){
                    return 0;
                }

                /* logic */
                // 遍历当前节点的子节点
                for (int i = 0; i < root.children.Count; i++)
                {
                    res =  Math.Max(res, MaxDepth(root.children[i]));
                }
                return res + 1;
            }
        }
        // @lc code=end
    ```
    
    ```csharp
        /*
        遍历法
        */
        public class Solution
        {
            public int MaxDepth(Node root)
            {
                Queue<Node> que = new Queue<Node>(); // 使用泛型队列存储节点

                int res = 0;

                if(root != null){
                    que.Enqueue(root); // 将根节点加入队列
                }
                while (que.Count > 0)
                {
                    int size = que.Count; // 获取当前层的节点数
                    res++; // 深度加一

                    for (int i = 0; i < size; i++)
                    {
                        // 每一层的遍历

                        var curNode = que.Dequeue(); // 取出队列中的节点
                        for (int j = 0; j < curNode.children.Count; j++)
                        {
                            if (curNode.children[j] != null)
                            {
                                que.Enqueue(curNode.children[j]); // 将子节点加入队列
                            }
                        }
                    }
                }

                return res; // 返回树的最大深度

            }
        }
    ```
  
### LC [[111] Minimum Depth of Binary Tree](https://leetcode.com/problems/minimum-depth-of-binary-tree/description/)
使用递归：分别计算左右子树的最小深度，然后取最小值，最后加上根节点的深度1即可。
  - Code 
    ```csharp
        /*
        * @lc app=leetcode id=111 lang=csharp
        *
        * [111] Minimum Depth of Binary Tree
        */
        // 迭代
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            int depth = 0;
            var que = new Queue<TreeNode>();
            que.Enqueue(root);
            while (que.Count > 0)
            {
                int size = que.Count;
                depth++;
                for (int i = 0; i < size; i++)
                {
                    var node = que.Dequeue();
                    if (node.left != null)
                        que.Enqueue(node.left);
                    if (node.right != null)
                        que.Enqueue(node.right);
                    if (node.left == null && node.right == null)
                        return depth;
                }
            }
            return depth;
        }  
       //递归法
        public class Solution
        {
            public int MinDepth(TreeNode root)
            {
                int res = 0;
                if (root == null)
                {
                    return res;
                }
                int minLeft = MinDepth(root.left);
                int minRight = MinDepth(root.right);

                // handle the situation which the node has only one child
                if(root.left == null && root.right != null){
                    return 1 + minRight;
                }
                if(root.right == null && root.left != null){
                    return 1 + minLeft;
                }
                return 1 + Math.Min(minLeft,minRight);
            }
        }
        // @lc code=end


    ```


### LC [[222] Count Complete Tree Nodes](https://leetcode.com/problems/count-complete-tree-nodes/description/)
  - Code

```csharp
/*
 * @lc app=leetcode id=222 lang=csharp
 *
 * [222] Count Complete Tree Nodes
 */


public class Solution {
    public int CountNodes(TreeNode root) {
        return helper(root);
    }

    /* Type */
    public int helper(TreeNode root){
        /* return condition */
        int num = 0;
        if(root == null){
            return 0;
        }

        /* logic of each time */
       int leftNum = helper(root.left);
       int rightNum = helper(root.right);

       return 1 + leftNum + rightNum; 
    }
}
// @lc code=end

```

完全二叉树的解法：
```csharp
/*
 * @lc app=leetcode id=222 lang=csharp
 *
 * [222] Count Complete Tree Nodes
 */
 public int CountNodes(TreeNode root)
{
    if (root == null) return 0;
    var left = root.left;
    var right = root.right;
    int leftDepth = 0, rightDepth = 0;
    while (left != null)
    {
        left = left.left;
        leftDepth++;
    }
    while (right != null)
    {
        right = right.right;
        rightDepth++;
    }
    if (leftDepth == rightDepth)
        return (int)Math.Pow(2, leftDepth+1) - 1; // 相当于2^2，返回满足满二叉树的子树节点数量
    return CountNodes(root.left) + CountNodes(root.right) + 1;

}
```