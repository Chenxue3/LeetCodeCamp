/*
 * @lc app=leetcode id=242 lang=csharp
 *
 * [242] Valid Anagram
 */

// @lc code=start
public class Solution {
    public bool IsAnagram(string s, string t) {
        int[] record = new int[26];

        // scan string s, record the relevant data
        for (int i = 0; i < s.Length; i++)
        {
            
            record[s[i] - 'a']++;
        }

        // scan string t, dele ttehe relevant data
        for (int j = 0; j < t.Length; j++)
        {
            record[t[j] - 'a']--;
        }

        //check all the value in the hash table
        foreach (var item in record)
        {
            //if not clear, return false
            if(item != 0){
                return false;
            }
        }

        return true;
    }
}
// @lc code=end

