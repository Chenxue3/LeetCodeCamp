/*
 * @lc app=leetcode id=344 lang=csharp
 *
 * [344] Reverse String
 */

// @lc code=start
public class Solution {
    public void ReverseString(char[] s) {
         int slow = 0, fast = s.Length-1;
         while (slow < fast)
         {
            char temp = s[slow];
            s[slow] = s[fast];
            s[fast] = temp;
            slow++;
            fast--;
         }
    }
}
// @lc code=end

