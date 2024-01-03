# Day08

## Topic Strings
在C#中，`string` 是一个表示字符串的数据类型。它是一个引用类型，表示一个字符序列。在C#中，***字符串是不可变的***，这意味着一旦创建了一个字符串对象，就**不能更改它的内容**。以下是一些常用的`string`类的方法：

1. **字符串的创建与初始化：**
   
   ```csharp
   string str1 = "Hello, World!"; // 使用双引号直接初始化字符串
   string str2 = new string('A', 5); // 使用构造函数初始化指定重复次数的字符
   ```

2. **字符串长度：**
   
   ```csharp
   int length = str1.Length; // 获取字符串的长度
   ```

3. **字符串连接：**
   
   ```csharp
   string concatenated = str1 + " " + str2; // 字符串拼接
   ```

4. **字符串比较：**
   
   ```csharp
   bool isEqual = str1.Equals(str2); // 使用Equals方法比较字符串是否相等
   bool contains = str1.Contains("Hello"); // 检查字符串是否包含特定子串
   ```

5. **字符串查找与替换：**
   
   ```csharp
   int index = str1.IndexOf("World"); // 查找子串的位置，返回索引值
   string replaced = str1.Replace("Hello", "Hi"); // 替换字符串中的子串
   ```

6. **字符串截取与分割：**
   
   ```csharp
   string substring = str1.Substring(0, 5); // 截取子串
   string[] parts = str1.Split(','); // 按指定字符分割字符串
   ```

7. **字符串转换：**
   
   ```csharp
   int num = 42;
   string numStr = num.ToString(); // 将其他类型转换为字符串
   ```

8. **字符串格式化：**
   
   ```csharp
   string formattedString = string.Format("The value is: {0}", num); // 使用格式化字符串
   string interpolatedString = $"The value is: {num}"; // 使用字符串插值
   ```

文档：[System.String 类](https://docs.microsoft.com/en-us/dotnet/api/system.string).
## LeetCode Problems
    
### LC  [344](https://leetcode.com/problems/reverse-string/description/) Reverse String

#### My Idea: 

  - Code 
    ```csharp
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


    ```
    
    

  | Bugs | Test Case & Excepted Output | My Output | Debug |
  | ---- | --------------------------- | --------- | ----- |
  |   0   | out of index| Error |  `while (slow != fast)`->`(slow < fast)`     |
 

  

### LC [541](https://leetcode.com/problems/reverse-string-ii/description/) Reverse String II

#### My Idea: 
重点在于i+=2k,以及由于C#中的String无法被修改，因此需要先转换为Char Array然后再转换为String输出。

  - Code 
    ```csharp
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


    ```
    
    

  | Bugs | Test Case & Excepted Output | My Output | Debug |
  | ---- | --------------------------- | --------- | ----- |
  |   0   |N/A | `Line 5: Char 49: error CS1003: Syntax error, ',' expected (in Solution.cs)` |   `i += 2k` -> `i += 2 * k`    |
 
 ### KC [54](https://kamacoder.com/problempage.php?pid=1064)替换数字

#### My Idea: 
C#中的String无法本地修改，因此使用最基本的方式。先定义一个新的数组，扫描字符串中的每一个char，不是数字的话直接加入新数组，是数组的话新数组中加入number。 
#### Method One:
正则表达式直接替换
```python
import re

s = input()
l = re.sub('\d', 'number',s)

print(l)
```
#### Method Two:
代码随想录，本地替换
```C++
#include<iostream>
using namespace std;
int main() {
    string s;
    while (cin >> s) {
        int count = 0; // 统计数字的个数
        int sOldSize = s.size();
        for (int i = 0; i < s.size(); i++) {
            if (s[i] >= '0' && s[i] <= '9') {
                count++;
            }
        }
        // 扩充字符串s的大小，也就是每个空格替换成"number"之后的大小
        s.resize(s.size() + count * 5);
        int sNewSize = s.size();
        // 从后先前将空格替换为"number"
        for (int i = sNewSize - 1, j = sOldSize - 1; j < i; i--, j--) {
            if (s[j] > '9' || s[j] < '0') {
                s[i] = s[j];
            } else {
                s[i] = 'r';
                s[i - 1] = 'e';
                s[i - 2] = 'b';
                s[i - 3] = 'm';
                s[i - 4] = 'u';
                s[i - 5] = 'n';
                i -= 5;
            }
        }
        cout << s << endl;
    }
}

```

### LC  [151](https://leetcode.com/problems/reverse-words-in-a-string/description/) Reverse Words in a String

#### My Idea: 
1. Slip the String by ' '
2. Store them in an Array
3. Convert to a String
   空间复杂度为O(n),因为C#中String不可本地修改。
  - Code 
    ```csharp
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


    ```
    
    

  | Bugs | Test Case & Excepted Output | My Output | Debug |
  | ---- | --------------------------- | --------- | ----- |
  |   01   |"  hello world  " & "world hello" | "  world hello  " |  ` s.Split(' '); `-> `s.Split(' ', StringSplitOptions.RemoveEmptyEntries);`    |
  |      |      |  |

  
#### Method Two: Space Complexity = O(1), Slow & Fast Pointer
```c++
// 版本二 
    void removeExtraSpaces(string& s) {//去除所有空格并在相邻单词之间添加空格, 快慢指针。
        int slow = 0;  
        for (int i = 0; i < s.size(); ++i) { //
            if (s[i] != ' ') { //遇到非空格就处理，即删除所有空格。
                if (slow != 0) s[slow++] = ' '; //手动控制空格，给单词之间添加空格。slow != 0说明不是第一个单词，需要在单词前添加空格。
                while (i < s.size() && s[i] != ' ') { //补上该单词，遇到空格说明单词结束。
                    s[slow++] = s[i++];
                }
            }
        }
        s.resize(slow); //slow的大小即为去除多余空格后的大小。
}
```

### KC [55](https://kamacoder.com/problempage.php?pid=1065) 右旋字符串 

#### 很巧的思路: 
1. 全部的字符都倒序
2. 把后length-n段的字符再次倒序
3. 得到符合题意的字符 

  - Code 
    ```c++
    // 版本一
    #include<iostream>
    #include<algorithm>
    using namespace std;
    int main() {
        int n;
        string s;
        cin >> n;
        cin >> s;
        int len = s.size(); //获取长度

        reverse(s.begin(), s.end()); // 整体反转
        reverse(s.begin(), s.begin() + n); // 先反转前一段，长度n
        reverse(s.begin() + n, s.end()); // 再反转后一段

        cout << s << endl;

    } 
    
    ```

