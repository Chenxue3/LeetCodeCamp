/*
 * @lc app=leetcode id=151 lang=csharp
 *
 * [151] Reverse Words in a String
 */

// @lc code=start
public class Solution {
    public string ReverseWords(string s) {
        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        int slow = 0, fast = words.Length -1;

        while (slow < fast)
        {
            string temp = words[slow];
            words[slow] = words[fast];
            words[fast] = temp;
            slow ++;
            fast --;
        }

        
        return  String.Join(" ", words);
        
    }
}
// @lc code=end

