/*
 * @lc app=leetcode id=116 lang=csharp
 *
 * [116] Populating Next Right Pointers in Each Node
 */

// @lc code=start
/*
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution
{
    public Node Connect(Node root)
    {
        Queue<Node> que = new Queue<Node>();

        if (root != null)
        {
            que.Enqueue(root);
        }

        while (que.Count > 0)
        {

            var queSize = que.Count;
            for (int i = 0; i < queSize; i++)
            {
                var cur = que.Dequeue();

                // 当这个节点不是这一层的最后得节点
                if (i != queSize - 1)
                {
                    // 当前节点指向下一个节点
                    cur.next = que.Peek();
                }
                // 否则指向空
                else
                {
                    cur.next = null;
                }

                if (cur.left != null)
                {
                    que.Enqueue(cur.left);
                }
                if (cur.right != null)
                {
                    que.Enqueue(cur.right);
                }
            }
        }

        return root;
    }
}
// @lc code=end

