# Day20


## LeetCode Problems
    
### LC [[654] Maximum Binary Tree](https://leetcode.com/problems/maximum-binary-tree/)

#### Note
- 但凡构造二叉树，都使用前序遍历的思路，因为前序遍历的第一个元素就是根节点，然后根据根节点的值，将数组分为左右两部分，分别递归构造左右子树即可。
- C# 中的数组切片，可以使用 `myArray.Take(index).ToArray()` , `myArray.Skip(index).ToArray()` 来实现。分别表示取前 index 个元素，和跳过前 index 个元素。
- 这道题总体而言不是很难，具体的实现上在初始化的时候使用-1的index和maxInt的值，这样可以避免在递归的时候进行边界判断，这样代码会更加简洁。
  - Code 
    ```csharp
            /*
            * @lc app=leetcode id=654 lang=csharp
            *
            * [654] Maximum Binary Tree
            */

            // @lc code=start
        public class Solution {
            public TreeNode ConstructMaximumBinaryTree(int[] nums) {
                
                if(nums == null || nums.Length == 0) {
                    return null;
                }

                int maxValue = int.MinValue;
                int maxIndex = -1;

                for (var i = 0; i < nums.Length; i++) 
                {
                    if (nums[i] > maxValue) {
                        maxIndex = i;
                        maxValue = nums[i];
                    }
                }

                
                TreeNode node = new TreeNode(nums[maxIndex]);

                //left
                node.left = ConstructMaximumBinaryTree(nums.Take(maxIndex).ToArray());

                //right
                node.right = ConstructMaximumBinaryTree(nums.Skip(maxIndex + 1).ToArray());


                //return
                return node;
                
            }
        }
        // @lc code=end


    ```
    
### [[617] Merge Two Binary Trees](https://leetcode.com/problems/merge-two-binary-trees/)

- 这道题使用递归，终止条件确认后很简单
```csharp
/*
 * @lc app=leetcode id=617 lang=csharp
 *
 * [617] Merge Two Binary Trees
 */
public class Solution {
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        
        // ending condition
        if(root1 == null){
            return root2;
        }
        if(root2 == null){
            return root1;
        }

        //logic
        TreeNode node = new TreeNode();
        node.val = root1.val + root2.val;
        node.left = MergeTrees(root1.left, root2.left);
        node.right = MergeTrees(root1.right, root2.right);

        return node;
        
        
    }
}
```
### LC[[700] Search in a Binary Search Tree](https://leetcode.com/problems/search-in-a-binary-search-tree/)
- BST的特性是左子树的值小于根节点，右子树的值大于根节点，所以可以根据这个特性进行查找。
- 迭代法也不需要使用栈来深度搜索或者队列来广搜

```csharp
    public class Solution {
        public TreeNode SearchBST(TreeNode root, int val) {
            // 递归
            TreeNode node = null;
            
            if(root == null){
                return null;
            }

            if(root.val == val){
                return root;
            }
            if(root.val < val){
                node = SearchBST(root.right, val);
            }
            else{
                node = SearchBST(root.left, val);
            }

            return node;
            

            // 迭代
            while(root != null){
                if(root.val == val){
                    return root;
                }
                if(root.val < val){
                    root = root.right;
                } 
                else if(root.val > val){
                    root = root.left;
                }
            }
            return null;
        }
    }
```


### LC[[701] Insert into a Binary Search Tree](https://leetcode.com/problems/insert-into-a-binary-search-tree/)
- 基本很简单，递归，小心等于的情况
```csharp
/*
 * @lc app=leetcode id=98 lang=csharp
 *
 * [98] Validate Binary Search Tree
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
    public bool IsValidBST(TreeNode root) {
        // 中序遍历
        List<int> myArray = helper(root, new List<int>());
        for (int i = 1; i < myArray.Count; i++)
        {
            if(myArray[i-1] >= myArray[i]){
                return false;
            }
        }
        
        return true;
    }

     private List<int> helper(TreeNode root, List<int> res)
    {
        if (root == null)
        {
            return res;
        }

        helper(root.left, res);
        res.Add(root.val);
        helper(root.right, res);


        return res;

    }
}
// @lc code=end

```