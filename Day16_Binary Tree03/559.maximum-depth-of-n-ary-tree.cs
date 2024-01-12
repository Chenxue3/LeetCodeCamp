/*
 * @lc app=leetcode id=559 lang=csharp
 *
 * [559] Maximum Depth of N-ary Tree
 */

// @lc code=start
/*
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
/*
遍历法
*/
public class Solution
{
    public int MaxDepth(Node root)
    {
        Queue<Node> que = new Queue<Node>();

        int res = 0;

        if(root != null){
            que.Enqueue(root);
        }
        while (que.Count > 0)
        {
            int size = que.Count;
            res++;

            for (int i = 0; i < size; i++)
            {
                // 每一层的遍历

                var curNode = que.Dequeue();
                for (int j = 0; j < curNode.children.Count; j++)
                {
                    if (curNode.children[j] != null)
                    {
                        que.Enqueue(curNode.children[j]);
                    }
                }
            }
        }

        return res;

    }


}
// @lc code=end

