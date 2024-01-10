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

