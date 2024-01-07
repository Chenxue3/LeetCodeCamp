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

