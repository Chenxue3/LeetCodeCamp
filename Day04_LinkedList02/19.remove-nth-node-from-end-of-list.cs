/*
 * @lc app=leetcode id=19 lang=csharp
 *
 * [19] Remove Nth Node From End of List
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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode dummyHead = new ListNode(-1,head);

        ListNode slow = dummyHead;
        ListNode fast = dummyHead;

        int i = n;
        while(i != 0 && fast != null){
            fast = fast.next;
            i--;
        }
        
        while(fast.next != null){
            slow = slow.next;
            fast = fast.next;
        }

        slow.next = slow.next.next;
       
        return dummyHead.next;
    }
}
// @lc code=end
