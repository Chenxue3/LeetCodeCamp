# Day10 String02, KMP

## Topic KMP
### 定义
- **Next Array / 前缀表**: next数组是对于模式串而言的。P 的 next 数组定义为：next[i] 表示 P[0] ~ P[i] 这一个子串，使得前k个字符恰等于后k个字符的最大的k. 特别地，k不能取i+1
- **P**：模式串，Target字符串
- **S**：主串，被匹配的字符串

### Why
- 每次匹配的过程都使用Next Array: 跳过不可能被匹配的字符串
- 不使用KMP算法(时间复杂度: `O(nm)`),使用KMP算法(时间复杂度: `O(n + m)`)

## LeetCode Problems
    
### LC [28: Find the Index of the First Occurrence in a String](https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/description/)

  - Code 
    ```java
        class Solution {
        //前缀表（不减一）Java实现
        public int strStr(String haystack, String needle) {
            if (needle.length() == 0) return 0;
            int[] next = new int[needle.length()];
            getNext(next, needle);

            int j = 0;
            for (int i = 0; i < haystack.length(); i++) {
                while (j > 0 && needle.charAt(j) != haystack.charAt(i)) 
                    j = next[j - 1];
                if (needle.charAt(j) == haystack.charAt(i)) 
                    j++;
                if (j == needle.length()) 
                    return i - needle.length() + 1;
            }
            return -1;

        }
        
        private void getNext(int[] next, String s) {
            int j = 0;
            next[0] = 0;
            for (int i = 1; i < s.length(); i++) {
                while (j > 0 && s.charAt(j) != s.charAt(i)) 
                    j = next[j - 1];
                if (s.charAt(j) == s.charAt(i)) 
                    j++;
                next[i] = j; 
            }
        }
    }
    
    ```


### LC [459: Repeated Substring Pattern](https://leetcode.com/problems/repeated-substring-pattern/description/)
```c#
    // 前缀表不减一
    public bool RepeatedSubstringPattern(string s)
    {
        if (s.Length == 0)
            return false;
        int[] next = GetNext(s);
        int len = s.Length;
        if (next[len - 1] != 0 && len % (len - next[len - 1]) == 0) return true;
        return false;
    }
    public int[] GetNext(string s)
    {
        int[] next = Enumerable.Repeat(0, s.Length).ToArray();
        for (int i = 1, j = 0; i < s.Length; i++)
        {
            while (j > 0 && s[i] != s[j])
                j = next[j - 1];
            if (s[i] == s[j])
                j++;
            next[i] = j;
        }
        return next;
    }
```