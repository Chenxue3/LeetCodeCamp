/*
 * @lc app=leetcode id=232 lang=csharp
 *
 * [232] Implement Queue using Stacks
 */

// @lc code=start
public class MyQueue {

    // define the stacks in public
    Stack<int> inStack; 
    Stack<int> outStack;
    public MyQueue() {
        inStack = new Stack<int>();
        outStack = new Stack<int>();
    }
    
    public void Push(int x) {
        inStack.Push(x);
    }
    
    public int Pop() {
        moveElements();
        return outStack.Pop();
    }
    
    public int Peek() {
       moveElements();
       return outStack.Peek();
    }
    
    public bool Empty() {
        return (inStack.Count == 0 && outStack.Count == 0);
    }

    public void moveElements(){
        if(outStack.Count == 0){
            while (inStack.Count != 0)
            {
                outStack.Push(inStack.Pop());            
            }
        }
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
// @lc code=end

