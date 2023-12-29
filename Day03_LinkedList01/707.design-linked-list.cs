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

