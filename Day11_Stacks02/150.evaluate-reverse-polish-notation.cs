/*
 * @lc app=leetcode id=150 lang=csharp
 *
 * [150] Evaluate Reverse Polish Notation
 */

// @lc code=start
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
        foreach(string s in tokens){
           if(int.TryParse(s, out num)){
                stack.Push(num);
            }else{
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
                        stack.Push(num2 / num1);
                        break;
                    default:
                        break;
                }
            }
        }
        return stack.Pop(); 
    }
}
// @lc code=end


}
// @lc code=end

