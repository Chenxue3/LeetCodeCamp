# Day11

## LeetCode Problems
    
### LC [[20] Valid Parentheses](https://leetcode.com/problems/valid-parentheses/description/)

#### My Idea: 
- Using `Stack`, push a `(\{\[` into the stack, and when meet `)\]\}`, pop it. Finaly, there should be no symbols.
  - Code 
    ```csharp
        /*
        * @lc app=leetcode id=20 lang=csharp
        *
        * [20] Valid Parentheses
        */

        // @lc code=start
        public class Solution {
            public bool IsValid(string s) {
                char[] chars = s.ToCharArray();
                Stack<char> myStack = new Stack<char>();

                foreach (var c in chars)
                {
                    
                    if(c == '[' || c == '{' || c == '('){
                        myStack.Push(c); System.Console.WriteLine(c);
                    
                    }
                    else if(c == '}' || c == ')' || c == ']'){
                        
                        if(myStack.Count == 0){
                            return false;
                        }
                        else{
                            myStack.Pop();
                        }
                    }
                }
                if(myStack.Count > 0){
                    return false;
                }
                else{
                    return true;
                }
            }
        }
        // @lc code=end


    ```
    
    

  | Bugs | Test Case & Excepted Output | My Output | Debug |
  | ---- | --------------------------- | --------- | ----- |
  |   n.a   |`(]` & `false` | `true` |  没有考虑到两边括号数量匹配，样式不匹配的情况     |


  

#### Method one: 

  
  - note: 
    第一种情况，字符串里左方向的括号多余了 ，所以不匹配。

    第二种情况，括号没有多余，但是 括号的类型没有匹配上。

    第三种情况，字符串里右方向的括号多余了，所以不匹配。
  - Code:
    ```csharp
        /*
        * @lc app=leetcode id=20 lang=csharp
        *
        * [20] Valid Parentheses
        */

        // @lc code=start
        public class Solution {
            public bool IsValid(string s) {
                char[] chars = s.ToCharArray();
                Stack<char> myStack = new Stack<char>();

                foreach (var c in chars)
                {
                    
                    if(c == '[' || c == '{' || c == '('){
                        myStack.Push(c); System.Console.WriteLine(c);
                    
                    }
                    else if(c == '}' || c == ')' || c == ']'){
                        
                        if(myStack.Count == 0){
                            return false;
                        }
                        // 添加不匹配的情况检查
                        else if(!isPair(myStack.Peek(),c)){
                            return false;
                        }
                        myStack.Pop();
                        
                    }
                }
                if(myStack.Count > 0){
                    return false;
                }
                else{
                    return true;
                }
            }

            private bool isPair(char a, char b){
                if(a == '('){
                    return b == ')';
                }
                else if(a == '['){
                    return b == ']';
                }
                else if(a == '{'){
                    return b == '}';
                }
                return false;
            }
        }
        // @lc code=end


    ```

### LC [[1047] Remove All Adjacent Duplicates In String](https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/description/)

#### My Idea: 
- 使用双指针，两个指针如果指向的字符相同，就删除这两个字符。慢指针向前一个位置，快指针向后一个位置。使用类似虚拟头结点的方式解决第一个位置。

  - Code 
    ```csharp
    
    ```
    
    

  | Bugs | Test Case & Excepted Output | My Output | Debug |
  | ---- | --------------------------- | --------- | ----- |
  |      | |  |       |
  |      |      |  |

  

#### Method one: 

  
  - note: 
  
  - Code:
    ```csharp
    
    ```