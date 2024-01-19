# Day21

## LeetCode Problems
    
### LC [[530] Minimum Absolute Difference in BST](https://leetcode.com/problems/minimum-absolute-difference-in-bst/)

#### My Idea: 
BST中，值的大小是由顺序的，所以先中序遍历，得到一个有序的数组，然后再遍历数组，找到最小的差值。

  - Code 
    ```csharp
        /*
        * @lc app=leetcode id=530 lang=csharp
        * 递归法
        * [530] Minimum Absoelute Difference in BST
        */

        // @lc code=start
        public class Solution {
            
            List<int> myList = new List<int>();
            public int GetMinimumDifference(TreeNode root) {
                getOrderedList(root);
                int minNum =  int.MaxValue;
                // 遍历数组，找到最小的差值
                for (int i = 0; i < myList.Count - 1; i++)
                {
                minNum = Math.Min(myList[i + 1] - myList[i], minNum);
                }
                return minNum;
            }

            // 中序遍历，得到一个有序的数组
            public void getOrderedList(TreeNode root){
                if(root == null){
                    return;
                }
                getOrderedList(root.left);
                myList.Add(root.val);
                getOrderedList(root.right);

                return;
            }
        }
        // @lc code=end
    ```
    
    
