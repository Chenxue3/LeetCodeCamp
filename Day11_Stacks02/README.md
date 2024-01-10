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
    
    

  | Bugs | Test Case & Excepted Output | My Output | Debug                                        |
  | ---- | --------------------------- | --------- | -------------------------------------------- |
  | n.a  | `(]` & `false`              | `true`    | 没有考虑到两边括号数量匹配，样式不匹配的情况 |


  

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
- 使用栈，如果新的和之前栈的peek一样，pop(peek)，继续下一个。下面我使用的是这种方法。

  - Code 
    ```csharp
        /*
        * @lc app=leetcode id=1047 lang=csharp
        *
        * [1047] Remove All Adjacent Duplicates In String
        */

        // @lc code=start
        public class Solution {
            public string RemoveDuplicates(string s) {
                char[] chars = s.ToCharArray();
                Stack<char> myStack = new Stack<char>();

                foreach (var c in chars)
                {
                    if(myStack.Count == 0 || c != myStack.Peek()){
                        myStack.Push(c);
                    }
                    else{
                        myStack.Pop();
                    }
                }

                char[] result = myStack.ToArray();
                Array.Reverse(result); // 因为栈是后进先出，需要反转数组得到正确的顺序
                return new string(result);
            }
        }

        // @lc code=end


    ```
    
    

  | Bugs | Test Case & Excepted Output | My Output | Debug                   |
  | ---- | --------------------------- | --------- | ----------------------- |
  | 0    | Compile Error               | Error     | 忽略Stack为空的情况     |
  | 1    | "qwwc"&"qc"                 | "cq"      | 忽略Stack先进后出的特征 |

  

#### Method one: 使用字符串作为栈

  
  - note: 拿字符串直接作为栈，省去了栈还要转为字符串的操作
  
  - Code:
    ```csharp
    
        public string RemoveDuplicates(string s) {
        //拿字符串直接作为栈，省去了栈还要转为字符串的操作
        
        // StringBuilder的优势在于，可以在原字符串上进行修改，而不用每次都生成一个新的字符串
        StringBuilder res = new StringBuilder();

        foreach(char c in s){
            if(res.Length > 0 && res[res.Length-1] == c){
                // 如果res不为空，且res的最后一个字符和当前字符相同，就删除res的最后一个字符
                res.Remove(res.Length-1, 1);
            }else{
                // 否则，就添加当前字符
                res.Append(c);
            }
        }
       
        return res.ToString();
    }
    ```

### LC [[150] Evaluate Reverse Polish Notation](https://leetcode.com/problems/evaluate-reverse-polish-notation/description/)

#### My Idea: 

  - Code 
    ```csharp
        public class Solution {
            /*
        * @lc app=leetcode id=150 lang=csharp
        *
        * [150] Evaluate Reverse Polish Notation
        */

        // @lc code=start
        public class Solution {
            public int EvalRPN(string[] tokens) {
                int num;
                Stack<int> stack = new Stack<int>();
                // 遍历数组
                foreach(string s in tokens){
                    // 如果是数字，就入栈
                    if(int.TryParse(s, out num)){
                        stack.Push(num);
                    }
                    // 如果是运算符，就出栈两个数字，进行运算，然后把结果入栈
                    else{
                        // 注意，这里的顺序
                        int num1 = stack.Pop();
                        int num2 = stack.Pop();
                        switch (s)
                        {
                            case "+":
                                stack.Push(num1 + num2);
                                break;
                            case "-":
                                stack.Push(num2 - num1);
                                break;
                            case "*":
                                stack.Push(num1 * num2);
                                break;
                            case "/":
                            // 注意，这里的顺序
                                stack.Push(num2 / num1);
                            
                                break;
                            default:
                                break;
                        }
                    }
                }
                // 最后栈里只剩下一个元素，就是结果
                return stack.Pop(); 
            }
        }
    }
    // @lc code=end


    ```
    
    

  | Bugs | Test Case & Excepted Output | My Output | Debug |
  | ---- | --------------------------- | --------- | ----- |
  |      |                             |           |       |
  |      |                             |           |

  