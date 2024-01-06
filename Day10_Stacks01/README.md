# Day10

## Topic Stack & Queue

### Stack: FILO

C# 中的 `Stack` 类型是一个后进先出（Last-In-First-Out，LIFO）的集合，它用于存储和管理对象。`Stack` 是 .NET 框架中的一部分。

在 C# 的 `Stack` 类中，没有直接提供公开的迭代器来遍历整个栈。你可以通过使用 `foreach` 循环或将 `Stack` 转换为数组或其他集合类型来访问元素。例如：
   
   ```csharp
   Stack<int> myStack = new Stack<int>();
   // 添加元素到栈
   myStack.Push(1);
   myStack.Push(2);
   myStack.Push(3);

   // 使用 foreach 遍历栈
   foreach (int item in myStack)
   {
       Console.WriteLine(item);
   }

   // 转换为数组并遍历
   int[] stackArray = myStack.ToArray();
   for (int i = 0; i < stackArray.Length; i++)
   {
       Console.WriteLine(stackArray[i]);
   }
   ```
在C#中，`Stack` 类提供了一系列基本操作，用于对栈进行常见的操作，包括入栈、出栈、查看栈顶元素等。以下是`Stack` 类的一些基本操作：

1. **创建栈：**
   - 使用`Stack<T>`类来创建栈，其中`T`表示栈中元素的类型。例如：
     ```csharp
     Stack<int> myStack = new Stack<int>();
     ```

2. **入栈（Push）：**
   - 使用`Push`方法将元素添加到栈的顶部。
     ```csharp
     myStack.Push(1);
     myStack.Push(2);
     ```

3. **出栈（Pop）：**
   - 使用`Pop`方法从栈的顶部移除并返回元素。在调用`Pop`之前，应检查栈是否为空。
     ```csharp
     if (myStack.Count > 0)
     {
         int poppedItem = myStack.Pop();
     }
     ```

4. **查看栈顶元素（Peek）：**
   - 使用`Peek`方法可以查看栈的顶部元素，但不会将其从栈中移除。
     ```csharp
     if (myStack.Count > 0)
     {
         int topItem = myStack.Peek();
     }
     ```

5. **检查栈是否为空：**
   - 使用`Count`属性来检查栈中元素的数量，以确定栈是否为空。
     ```csharp
     if (myStack.Count == 0)
     {
         // 栈为空
     }
     ```

6. **清空栈：**
   - 使用`Clear`方法清空栈中的所有元素。
     ```csharp
     myStack.Clear();
     ```

7. **遍历栈：**
   - 尽管 `Stack` 类没有直接提供迭代器，但你可以通过将栈转换为数组或使用 `foreach` 循环来遍历元素。
     ```csharp
     foreach (int item in myStack)
     {
         Console.WriteLine(item);
     }
     ```

这些基本操作使得在C#中使用 `Stack` 类非常灵活，适用于需要后进先出（LIFO）操作的场景，如表达式求值、函数调用追踪等。
### Queue: FIFO
在C#中，`Queue`（队列）是一种先进先出（First-In-First-Out，FIFO）的数据结构，用于存储和管理对象。它属于.NET Framework的一部分，也包括在.NET Core和.NET 5+等后续版本中。

以下是关于C#中`Queue`的一些基本信息：

1. **队列概述：**
   - 队列是一种线性数据结构，元素按照先进先出的原则排列。新元素被添加到队列的末尾，而从队列中移除元素时，总是从队列的前端开始移除。

2. **创建和使用队列：**
   - 使用`Queue<T>`类来创建和操作队列，其中`T`表示队列中元素的类型。例如：
     ```csharp
     Queue<int> myQueue = new Queue<int>();
     ```

3. **基本操作：**
   - 添加元素：使用`Enqueue`方法将元素添加到队列的末尾。
     ```csharp
     myQueue.Enqueue(1);
     myQueue.Enqueue(2);
     ```
   - 移除元素：使用`Dequeue`方法从队列的前端移除并返回元素。
     ```csharp
     int item = myQueue.Dequeue();
     ```

4. **查看队列头部元素：**
   - 使用`Peek`方法可以查看队列的前端元素，但不会将其从队列中移除。
     ```csharp
     int frontItem = myQueue.Peek();
     ```

5. **检查队列是否包含元素：**
   - 使用`Count`属性来获取队列中的元素数量，以及使用`Contains`方法检查是否包含特定元素。

   ```csharp
   if (myQueue.Count > 0)
   {
       // 队列非空
       if (myQueue.Contains(3))
       {
           // 队列包含元素 3
       }
   }
   ```

6. **遍历队列：**
   - 队列本身不提供直接的迭代器，但你可以通过将队列转换为数组或使用`foreach`循环来遍历元素。
   ```csharp
   foreach (int item in myQueue)
   {
       Console.WriteLine(item);
   }
   ```

总体而言，`Queue`在C#中是一个常用的数据结构，适用于需要按照先进先出顺序处理元素的场景，例如任务排队、消息传递等。

## LeetCode Problems
    
### LC [[232] Implement Queue using Stacks](https://leetcode.com/problems/implement-queue-using-stacks/description/)

#### 

  - Code 
    ```csharp
        
    // define the stacks in public
    Stack<int> inStack; 
    Stack<int> outStack;
    public MyQueue() {
        inStack = new Stack<int>();
        outStack = new Stack<int>();
    }
    
    public void Push(int x) {
        inStack.Push(x);
        
        foreach (int item in inStack)
            {
            Console.Write("[{0}]",item);
            }
        Console.Write("\n inStack updated. \n ---\n");
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
    ```
    
    

  | Bugs | Test Case & Excepted Output | My Output | Debug |
  | ---- | --------------------------- | --------- | ----- |
  |   0   | na | na |  不清空OutStack     |


   
### LC [[225] Implement Stack using Queues](https://leetcode.com/problems/implement-queue-using-stacks/description/](https://leetcode.com/problems/implement-stack-using-queues/description/))

#### 

  - Code 
    ```csharp
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
    ```