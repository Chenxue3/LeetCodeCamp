    /*
    * @lc app=leetcode id=541 lang=csharp
    *
    * [541] Reverse String II
    */

    // @lc code=start
    public class Solution {
        public string ReverseStr(string s, int k) {
            char[] chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i += (2*k))
            {
                /*reverse the first k characters */
                // to avoid the length out of index
                int len = Math.Min(k, chars.Length - i);
                
                Array.Reverse(chars, i, len);
            }
            
            return new string(chars);
        }
    }
    // @lc code=end

