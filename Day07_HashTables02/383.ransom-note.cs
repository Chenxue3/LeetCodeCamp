/*
 * @lc app=leetcode id=383 lang=csharp
 *
 * [383] Ransom Note
 */

// @lc code=start
public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        int[] hashArray = new int[26];

        foreach (var item in magazine)
        {
            hashArray[item - 'a']++;
        }

        foreach (var letter in ransomNote)
        {
            hashArray[letter - 'a']--;
        }

        for (int i = 0; i < hashArray.Length; i++)
        {
            if(hashArray[i] < 0){
                return false;
            }
        }

        return true;
    }
}
// @lc code=end

