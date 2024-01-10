/*
 * @lc app=leetcode id=239 lang=csharp
 *
 * [239] Sliding Window Maximum
 */

// @lc code=start
public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        class MyDequeue
        {
            private LinkedList<int> linkedList = new LinkedList<int>();

            public void Enqueue(int n)
            {
                while (linkedList.Count > 0 && linkedList.Last.Value < n)
                {
                    linkedList.RemoveLast();
                }
                linkedList.AddLast(n);
            }

            public int Max()
            {
                return linkedList.First.Value;
            }

            public void Dequeue(int n)
            {
                if (linkedList.First.Value == n)
                {
                    linkedList.RemoveFirst();
                }
            }
        }

        MyDequeue window = new MyDequeue();
        List<int> res = new List<int>();

        // 处理前 k 个元素，构建初始窗口
        for (int i = 0; i < k; i++)
        {
            window.Enqueue(nums[i]);// 留下最大
        }
        

        // 记录当前窗口的最大值
        res.Add(window.Max());

        // 遍历数组，从第 k 个元素开始
        for (int i = k; i < nums.Length; i++)
        {
            // 移除窗口最左边的元素
            window.Dequeue(nums[i - k]);
            // 添加当前元素到窗口
            window.Enqueue(nums[i]);

            Console.WriteLine("Window after sliding:");
            foreach (int n in window.linkedList)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            // 记录当前窗口的最大值
            res.Add(window.Max());
        }

        // 打印最终结果
        Console.WriteLine("Final Result:");
        foreach (int n in res)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();

        // 将结果转换为数组并返回
        return res.ToArray();
    }
}

// @lc code=end

