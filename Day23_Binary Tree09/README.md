# Day22 Binary Tree08

## LeetCode Problems
    
### LC [[669] Trim a Binary Search Tree](https://leetcode.com/problems/trim-a-binary-search-tree/)

- 这道题主要在于处理root节点的是否超边界值的问题。因为给出的是BST，所以root节点的值大于high，就不需要考虑右子树了，直接返回左子树的trim结果；反之，root节点的值小于low，就不需要考虑左子树了，直接返回右子树的trim结果。这里的trim结果就是递归调用trimBST函数。root的值在边界中间，就返回左右子树的trim值。

  - Code:
    ```csharp
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


    ```

### LC [[108] Convert Sorted Array to Binary Search Tree](https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/)

#### My Idea: 
- 一个高度平衡二叉树是指一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 
- 这道题的结果***不唯一***
- 掌握数组的展开（数组分割）方法：
  - `nums[0..mid]` 是 C# 8.0 中引入的**范围运算符**（Range Operator）的一种用法。这个语法允许你从数组或集合中选择一个子集，非常方便。具体来说，`nums[0..mid]` 表示的是从数组 `nums` 的索引 0 开始，一直到 `mid-1` 的元素。这个范围是一个半开放区间，包括索引 0，但不包括 `mid`。
     ```csharp
    int[] nums = {1, 2, 3, 4, 5, 6, 7, 8, 9};
    ```
    如果我们使用 `nums[0..5]`，则表示选择了从索引 0 到索引 4 的元素，结果是一个包含 `{1, 2, 3, 4, 5}` 的子数组。
- Code 
```csharp
    /*
    * @lc app=leetcode id=108 lang=csharp
    *
    * [108] Convert Sorted Array to Binary Search Tree
    */

    // @lc code=start

    public class Solution {
        public TreeNode SortedArrayToBST(int[] nums) {
        
            if(nums.Count() == 0){
                return null;
            }
            int mid = (nums.Count() - 1) / 2;
            TreeNode node = new TreeNode(nums[mid]);
            int curRoot = nums[mid];
            node.left = SortedArrayToBST(nums[0..mid]);
            var iLeft = mid + 1;
            var iRight = nums.Count();
            node.right = SortedArrayToBST(nums[iLeft..iRight]);

            return node;

        }
    }
    // @lc code=end


```
### LC [[538] Convert BST to Greater Tree](https://leetcode.com/problems/convert-bst-to-greater-tree/)

#### My Idea: 
- 比较暴力的一个想法：把BST转换成一个数组，然后对数组进行处理，再转换成BST。
#### Reverse Inorder Traversal + Double Pointer
- 逆中序遍历，然后用一个变量记录当前节点的值，然后把当前节点的值加到这个变量上，再把这个变量赋值给当前节点。
- 基于BST的特性，使用一个pre值记录当前（比当前值大的值的）和。
- Code
```csharp
    /*
    * @lc app=leetcode id=538 lang=csharp
    *
    * [538] Convert BST to Greater Tree
    */

    // @lc code=start

        public class Solution {
        public int pre = 0;
        public void Traversal(TreeNode node){
            if(node == null){
                return;
            }
            //因为右总是大于左：
            // right
            Traversal(node.right);
            //mid
            node.val = node.val + pre;
            pre = node.val;
            //left
            Traversal(node.left);

        }
        public TreeNode ConvertBST(TreeNode root) {
            pre = 0;
            Traversal(root);
            return root;
        }
    }
    // @lc code=end
```