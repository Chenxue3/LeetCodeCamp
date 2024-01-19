/*
 * @lc app=leetcode id=501 lang=csharp
 *
 * [501] Find Mode in Binary Search Tree
 */

// @lc code=start
public class Solution
{
    List<int> myList = new List<int>();
    public int[] FindMode(TreeNode root)
    {
        getOrderedList(root);
        int slow = 0, fast = 0, mode = 0;
        List<int> res = new List<int>();

        while (fast != myList.Count)
        {
            if (myList[slow] == myList[fast])
            {
                fast++;
                var curMode = fast - slow + 1;
                if (curMode > mode)
                {
                    res.Clear();
                    res.Add(myList[slow]);
                }
                else if (curMode == mode)
                {
                    res.Add(myList[slow]);
                }
            }
            else
            {
                fast++;
                slow++;
            }
        }
        return res.ToArray(); ;

    }

    public void getOrderedList(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        getOrderedList(root.left);
        myList.Add(root.val);
        getOrderedList(root.right);

        return;
    }
}
// @lc code=end

