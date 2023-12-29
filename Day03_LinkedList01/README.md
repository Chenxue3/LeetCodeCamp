# Day03: Linked List

## Linked List in C#

```c#
public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
```

```c#
public class LinkedList<T>
{
    private Node<T> head;

    public LinkedList()
    {
        head = null;
    }

    // 在链表末尾添加节点
    public void AddLast(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    // 在链表头部添加节点
    public void AddFirst(T data)
    {
        Node<T> newNode = new Node<T>(data);
        newNode.Next = head;
        head = newNode;
    }

    // 打印链表
    public void PrintList()
    {
        Node<T> current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

```

### LC 203 Remove Linked List Elements

- My thought: for the non-dummy head method, I ignore the situation that in this linked list, only one node (ie the head node).

- Method one: delved into 2 way, one is the node need to be deleted is the head node, two is the following nodes. 

  | BUG                      | DEBUG                                                        |
  | ------------------------ | ------------------------------------------------------------ |
  | [7,7,7,7] EO: [], My:[7] | if (head != null && head.val == val)  <br />-><br />while (head != null && head.val == val) |

  ```C#
  /*
   * @lc app=leetcode id=203 lang=csharp
   *
   * [203] Remove Linked List Elements
   */
  
  // @lc code=start
  /**
   * Definition for singly-linked list.
   * public class ListNode {
   *     public int val;
   *     public ListNode next;
   *     public ListNode(int val=0, ListNode next=null) {
   *         this.val = val;
   *         this.next = next;
   *     }
   * }
   */
   
  public class Solution {
      public ListNode RemoveElements(ListNode head, int val) {
  
          
          //while the target node is the head node
          while (head != null && head.val == val){
              head = head.next;
          }
         
         //if head not exist
          if (head == null) {
          return head;
          }
  
  
          ListNode pre = head;
          ListNode cur = head.next;
          while(cur != null){
              if(cur.val == val){
                  pre.next = cur.next;
              }
              else{
                  pre = cur;
              }
              cur = cur.next;
          }
  
          return head;
  
      }
  }
  // @lc code=end
  
  
  ```

- Method Two: Define a dummy node, which next node is the original head node, so that all the nodes can be considered as a normal node

  | Bugs | Test Case & Excepted Output           | My Output | Debug                                                        |
  | ---- | ------------------------------------- | --------- | ------------------------------------------------------------ |
  | 1    | **[1,2,6,3,4,5,6] 6**&**[1,2,3,4,5]** | []        | move to next node, preNode.next = curNode is not moving, should be preNode = curNode |

  ```c#
  /*
   * @lc app=leetcode id=203 lang=csharp
   *
   * [203] Remove Linked List Elements
   */
  
  // @lc code=start
  /**
   * Definition for singly-linked list.
   * public class ListNode {
   *     public int val;
   *     public ListNode next;
   *     public ListNode(int val=0, ListNode next=null) {
   *         this.val = val;
   *         this.next = next;
   *     }
   * }
   */
   
  public class Solution {
      public ListNode RemoveElements(ListNode head, int val) {
  
          if(head == null){
              return head;
          }
          
          //new a dummy node, which the next node is the original head
          ListNode dummyNode = new ListNode(0,head);
          
          ListNode preNode = dummyNode, curNode = head;
  
          while(curNode != null){
              if(curNode.val == val){
                  preNode.next = curNode.next;
                  
              }
              else{
                  preNode = curNode;
              }
              curNode = curNode.next;
          }
  
          return dummyNode.next;
      }
  }
  // @lc code=end
  
  ```

  

## LC [707] Design Linked List

- This is basis of linked list, catch up & review
- Need to pay attention to the boundary control, like count, index and so on

```c#
/*
 * @lc app=leetcode id=707 lang=csharp
 *
 * [707] Design Linked List
 */

// @lc code=start

class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val) { this.val = val; }
}
public class MyLinkedList
{

    ListNode dummyHead;
    int count;
    public MyLinkedList()
    {
        dummyHead = new ListNode(0);
        count = 0;
    }

    public int Get(int index)
    {
        // index out of range
        if (index < 0 || count <= index)
        {
            return -1;
        }

        ListNode curNode = dummyHead;

        for (int i = 0; i <= index; i++)
        {
            curNode = curNode.next;
        }
        return curNode.val;
    }

    public void AddAtHead(int val)
    {
        AddAtIndex(0, val);
    }

    public void AddAtTail(int val)
    {
        AddAtIndex(count, val);
    }

    public void AddAtIndex(int index, int val)
    {
        if (index > count) return;

        //当index小于0的时候，插入到最前面
        index = Math.Max(0, index);

        ListNode curNode = dummyHead;

        //获得需要插入Node的位置
        for (int i = 0; i < index; i++)
        {
            curNode = curNode.next;
        }

        //插入新node
        ListNode newNode = new ListNode(val);
        newNode.next = curNode.next;
        curNode.next = newNode;

        count++;
    }

    public void DeleteAtIndex(int index)
    {
        if (index >= count || index < 0) return;

        ListNode curNode = dummyHead;

        //获得需要删除Node的位置
        for (int i = 0; i < index; i++)
        {
            curNode = curNode.next;
        }

        curNode.next = curNode.next.next;
        count--;
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */
// @lc code=end


```

## LC Reverse Linked List

- My Thought: use a new linked list, and then add the reversed elements one by one. 
- Better: using double pointers or recursive method (TBC)

```C#
```

