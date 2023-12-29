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

