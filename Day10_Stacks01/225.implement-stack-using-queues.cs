/*
 * @lc app=leetcode id=225 lang=csharp
 * 版本二：单队列
 * [225] Implement Stack using Queues
 */

// @lc code=start
public class MyStack {
    Queue<int> myQueue;
    public MyStack() {
        myQueue = new Queue<int>();
    }
    
    public void Push(int x) {
        myQueue.Enqueue(x);
    }
    
    //使用一个队列实现
    public int Pop() {
        //一个队列在模拟栈弹出元素的时候只要将队列头部的元素（除了最后一个元素外） 重新添加到队列尾部，此时再去弹出元素就是栈的顺序了。
        for (var i = 0; i < myQueue.Count-1; i++)
        {
            myQueue.Enqueue(myQueue.Dequeue());
        }
        return myQueue.Dequeue();
    }

    //复用Pop()的代码
    public int Top() {
        int res = Pop();
        myQueue.Enqueue(res);
        return res;
    }
    
    public bool Empty() {
        return (myQueue.Count == 0);
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */
// @lc code=end

