/*
 * @lc app=leetcode id=24 lang=csharp
 *
 * [24] Swap Nodes in Pairs
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
    public ListNode SwapPairs(ListNode head) {
        ListNode dummyHead = new ListNode(-1,head);
        
        ListNode curNode = dummyHead;

        while(curNode.next != null && curNode.next.next != null){
            ListNode tempNode1 = curNode.next;
            ListNode tempNode2 = curNode.next.next.next;
            //step1
            curNode.next = tempNode1.next;

            //step 2
            curNode.next.next = tempNode1;

            //step 3
            curNode.next.next.next = tempNode2;

            curNode =curNode.next.next;
        }

        return dummyHead.next;

    }
}
// @lc code=end

