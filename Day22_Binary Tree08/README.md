# Day22


## LeetCode Problems
    
### LC [[235] Lowest Common Ancestor of a Binary Search Tree](https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/)


#### Recursion

  - note: 按照BST的性质，如果p和q都在root的左子树上，那么LCA一定在root的左子树上，如果p和q都在root的右子树上，那么LCA一定在root的右子树上，如果p和q分别在root的左右子树上，那么root就是LCA。
  
  - Code:
    ```csharp
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
    ```

#### LC[[701] Insert into a Binary Search Tree](https://leetcode.com/problems/insert-into-a-binary-search-tree/)

  - note: 递归，如果当前节点为空，就返回一个新的节点，如果当前节点的值比val大，就递归到左子树，如果当前节点的值比val小，就递归到右子树，最后返回root。
  - 这道题一开始想太复杂了，想着要找到插入的位置，其实在遍历二叉树的过程中插入就可以了，剩下的遍历会完成整合树的结构的任务。
  
  - Code:
    ```csharp
        public class Solution {
            public TreeNode InsertIntoBST(TreeNode root, int val) {
                if(root == null){
                    return new TreeNode(val);
                }
                if(root.val > val){
                    root.left = InsertIntoBST(root.left, val);
                }
                else{
                    root.right = InsertIntoBST(root.right, val);
                }
                return root;
            }
        }
    ```


#### LC [[450] Delete Node in a BST](https://leetcode.com/problems/delete-node-in-a-bst/)

  - note: 递归，如果当前节点为空，就返回空，如果当前节点的值比key大，就递归到左子树，如果当前节点的值比key小，就递归到右子树，如果当前节点的值等于key，就分三种情况：
    - 如果当前节点没有左子树，就返回右子树
    - 如果当前节点没有右子树，就返回左子树
    - 如果当前节点既有左子树又有右子树，就找到右子树中最小的节点，把当前节点的值替换成右子树中最小的节点的值，然后递归到右子树中删除右子树中最小的节点。
  
  - Code:
    ```csharp
        /*
        * @lc app=leetcode id=450 lang=csharp
        *
        * [450] Delete Node in a BST
        */

        // @lc code=start
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


    ```