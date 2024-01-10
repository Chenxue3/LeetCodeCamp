# Day12

## LeetCode Problems
    
### LC [[239] Sliding Window Maximum](https://leetcode.com/problems/sliding-window-maximum/description/)

#### My Idea: 

  - Code 
    ```csharp
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
                class myDequeue
            {
                // 双向队列
                private LinkedList<int> linkedList = new LinkedList<int>();

                // 向队列尾部添加元素
                public void Enqueue(int n)
                {
                    // 从队尾开始，移除所有小于当前元素的值
                    while (linkedList.Count > 0 && linkedList.Last.Value < n)
                    {
                        // 移除队尾元素, 直到队列为空或者遇到一个大于等于当前元素的值
                        linkedList.RemoveLast();
                    }
                    // 将当前元素添加到队尾，使得队列递减
                    linkedList.AddLast(n);
                }

                // 返回队列头部元素，即当前窗口内的最大值
                public int Max()
                {
                    // 队列头部元素即为当前窗口内的最大值, 因为队列是从大到小排列的
                    return linkedList.First.Value;
                }

                // 从队列头部移除指定元素
                public void Dequeue(int n)
                {
                    if (linkedList.First.Value == n)
                    {
                        linkedList.RemoveFirst();
                    }
                }
            }

            public class Solution
            {
                // 创建一个双向队列, 用于存放当前窗口内的元素
                myDequeue window = new myDequeue();

                // 创建一个列表, 用于存放每个窗口的最大值
                List<int> res = new List<int>();

                // 滑动窗口的最大值
                public int[] MaxSlidingWindow(int[] nums, int k)
                {
                    // 处理前 k 个元素，构建初始窗口
                    for (int i = 0; i < k; i++)
                    {
                        // 将元素添加到窗口
                        window.Enqueue(nums[i]);
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
                        // 记录当前窗口的最大值
                        res.Add(window.Max());
                    }

                    // 将结果转换为数组并返回
                    return res.ToArray();
                }
            }

        }
        }
        // @lc code=end


    ```
    
    

 输入输出范例：
    1. `myDequeue` 类定义了一个私有的 `LinkedList<int>`，用于存储当前窗口内的元素。

    2. `Enqueue` 方法用于向队列中添加元素，但是在添加之前，它会从队尾开始，将小于当前元素的元素都移除。这是因为在滑动窗口的过程中，我们只关心当前窗口内的最大值，不需要保留比当前元素小的值。然后将当前元素添加到队尾。

    3. `Max` 方法用于返回当前窗口内的最大值，即队列的头部元素。

    4. `Dequeue` 方法用于从队列中移除指定的元素。在这个算法中，只有当队列头部的元素等于当前窗口要滑出的元素时，才从队列头部移除。

    5. 在 `MaxSlidingWindow` 方法中，首先通过循环将前 `k` 个元素加入到窗口中，并记录当前窗口的最大值。然后，通过一个循环从第 `k` 个元素开始，依次将窗口的最左边元素移除，将当前元素加入窗口，再记录当前窗口的最大值。这样一直进行下去，直到遍历完整个数组。

    6. 结果最后以数组的形式返回。

    这个算法的关键在于通过双端队列来维护一个递减的顺序，确保队列头部始终是当前窗口内的最大值。通过这种方式，算法在每次滑动窗口时，可以高效地更新最大值，而不需要重新扫描整个窗口。这样，算法的时间复杂度是 O(N)，其中 N 是数组的长度。


