# Day15

## Binary Tree Level Order Traversal 二叉树的层序遍历

- 二叉树的层序遍历(广度优先遍历)：从上到下，从左到右依次遍历每一层的节点
  - 借用一个辅助数据结构即**队列**来实现，队列先进先出，符合一层一层遍历的逻辑，而用**栈先进后出适合模拟深度优先遍历也就是递归的逻辑。**
    - 代码如下
        ```csharp
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            // res: 用于存储最终结果
            IList<IList<int>> res = new List<IList<int>>();

            // 特殊情况处理. 如果根节点为空, 直接返回空的结果集
            if (root == null)
            {
                return res;
            }

            // 借助队列来实现层序遍历
            Queue<TreeNode> queue = new Queue<TreeNode>();

            // 首先将根节点入队
            queue.Enqueue(root);

            // 当队列不为空时, 说明还有节点没有遍历到
            while (queue.Count > 0)
            {
                // 获取当前队列的长度, 这个长度相当于当前这一层的节点个数
                int count = queue.Count;

                // 定义一个集合存储当前层的结果
                List<int> list = new List<int>();

                // 遍历这一层的所有节点, 把他们全部从队列中移出来, 并把他们的值加入到集合中
                for (int i = 0; i < count; i++)
                {
                    // 出队
                    TreeNode node = queue.Dequeue();

                    // 把出队节点的值加入到集合中
                    list.Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                // 将当层结果加入到最终结果集中
                res.Add(list);
            }
            return res;
        }
        ```

## LeetCode Problems
    
### LC [[102] Binary Tree Level Order Traversal](https://leetcode.com/problems/binary-tree-level-order-traversal/description/)

  - Code 
    ```csharp
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


    ```
    
### LC [[104] Maximum Depth of Binary Tree](https://leetcode.com/problems/maximum-depth-of-binary-tree/description/)
- 层序遍历法
  - Code 
    ```csharp
        /*
        * @lc app=leetcode id=104 lang=csharp
        *
        * [104] Maximum Depth of Binary Tree
        */

        // @lc code=start
        // 在模板基础的代码上，将返回值变成数列长度即可。
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
            public int MaxDepth(TreeNode root) {
                Queue<TreeNode> que = new Queue<TreeNode>();
                var res = new List<IList<int>>();

                if(root == null){
                    return res.Count;
                }

                que.Enqueue(root);
                while(que.Count > 0){
                    var levelList = new List<int>();
                    var queSize = que.Count;
                    for (int i = 0; i < queSize; i++)
                    {
                        var cur = que.Dequeue();
                        levelList.Add(cur.val);

                        if(cur.left != null){
                            que.Enqueue(cur.left);
                        }
                        if(cur.right != null){
                            que.Enqueue(cur.right);
                        }
                    }
                    res.Add(levelList);
                }

                return res.Count;
            }
        }
        // @lc code=end


    ```
- 递归法
  ```csharp
    /*
    * @lc app=leetcode id=104 lang=csharp
    *
    * [104] Maximum Depth of Binary Tree
    */

    // @lc code=start
    // 在模板基础的代码上，将返回值变成数列长度即可。
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
        public int MaxDepth(TreeNode root) {
            int res = 0;
            if(root == null){
                return res;
            }

            
            int leftMax = MaxDepth(root.left);
            int rightMax = MaxDepth(root.right);

            return 1 + Math.Max(leftMax,rightMax);
        }
    }
    // @lc code=end
    ```

### LC [[107] Binary Tree Level Order Traversal II](https://leetcode.com/problems/binary-tree-level-order-traversal-ii/description/)

  - Code 
    ```csharp
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


    ```


    
### LC [[116] Populating Next Right Pointers in Each Node](https://leetcode.com/problems/populating-next-right-pointers-in-each-node/description/)
- 迭代法（层序遍历）
  - Code 
    ```csharp
        /*
        * @lc app=leetcode id=116 lang=csharp
        *
        * [116] Populating Next Right Pointers in Each Node
        */

        // @lc code=start
        /*
        public class Node {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() {}

            public Node(int _val) {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next) {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
        */

        public class Solution {
            public Node Connect(Node root) {
                Queue<Node> que = new Queue<Node>();

                if (root != null)
                {
                    que.Enqueue(root);
                }

                while (que.Count > 0)
                {
                    
                    var queSize = que.Count;
                    for (int i = 0; i < queSize; i++)
                    {
                        var cur = que.Dequeue();

                        // 当这个节点不是这一层的最后得节点
                        if(i != queSize - 1){
                            // 当前节点指向下一个节点
                            cur.next = que.Peek();
                        }
                        // 否则指向空
                        else{
                            cur.next = null;
                        }
                        
                        if (cur.left != null)
                        {
                            que.Enqueue(cur.left);
                        }
                        if (cur.right != null)
                        {
                            que.Enqueue(cur.right);
                        }
                    }
                }

                return root;
            }
        }
        // @lc code=end


    ```
- 递归法
    ```csharp
        /*
        * @lc app=leetcode id=116 lang=csharp
        *
        * [116] Populating Next Right Pointers in Each Node
        */

        // @lc code=start
        /*
        public class Node {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() {}

            public Node(int _val) {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next) {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
        */

        public class Solution {
            public Node Connect(Node root) {
                if (root == null) {
                    return null;
                }
                
                ConnectNodes(root.left, root.right);
                
                return root;
            }

            private void ConnectNodes(Node node1, Node node2) {
                if (node1 == null || node2 == null) {
                    return;
                }

                // 将左子节点的 next 指向右子节点
                node1.next = node2;

                // 递归连接当前节点的左右子节点
                ConnectNodes(node1.left, node1.right);
                ConnectNodes(node2.left, node2.right);

                // 连接跨越父节点的两个子树
                ConnectNodes(node1.right, node2.left);
            }
        }
        // @lc code=end
    ```


### LC [[226] Invert Binary Tree](https://leetcode.com/problems/invert-binary-tree/description/)
递归法
  - Code 
    ```csharp
        /*
        * @lc app=leetcode id=226 lang=csharp
        *
        * [226] Invert Binary Tree
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
            public TreeNode InvertTree(TreeNode root) {
                return InvertHelper(root);
            }

            private TreeNode InvertHelper(TreeNode root){
                if(root == null){
                    return root;
                }

                swap(root);

                InvertHelper(root.left);
                InvertHelper(root.right);

                return root;
                
            }

            public void swap(TreeNode node) {
                TreeNode temp = node.left;
                node.left = node.right;
                node.right = temp;
            }
        }
        // @lc code=end


    ```

### LC [[101] Symmetric Tree](https://leetcode.com/problems/symmetric-tree/description/)

  - Code 
    ```csharp
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


    ```