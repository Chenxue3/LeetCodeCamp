# Day07

## Dictionary in C#
`Dictionary<TKey, TValue>` 是 C# 中用于存储键值对的泛型集合，它提供了高效的键值对查找、插入和删除操作。以下是对 `Dictionary<TKey, TValue>` 的详细介绍以及具体的示例代码：

- 特点：

  1. **键值对存储：** `Dictionary<TKey, TValue>` 存储键值对，其中每个键必须是唯一的。

  2. **泛型：** `Dictionary<TKey, TValue>` 是泛型类型，可以存储任意类型的键和值。

  3. **快速查找：** 通过键进行快速查找，具有常数时间复杂度（O(1)）的性能。

  4. **无序：** `Dictionary<TKey, TValue>` 中的键值对没有特定的顺序。如果需要有序的集合，可以考虑使用 `SortedDictionary<TKey, TValue>`。

- 常用方法和属性：

    1. **`Add(TKey key, TValue value)`：** 向字典中添加键值对。

    2. **`Remove(TKey key)`：** 从字典中移除指定键的键值对。

    3. **`ContainsKey(TKey key)`：** 判断字典中是否包含指定的键。

    4. **`ContainsValue(TValue value)`：** 判断字典中是否包含指定的值。

    5. **`Keys`：** 获取包含字典中所有键的集合。

    6. **`Values`：** 获取包含字典中所有值的集合。

    7. **`Count`：** 获取字典中键值对的数量。

    8. **`Clear()`：** 清空字典中的所有键值对。

- 示例代码：

    ```csharp
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            // 创建一个 Dictionary 实例，用于存储人的姓名和年龄
            Dictionary<string, int> ageDictionary = new Dictionary<string, int>();

            // 添加键值对
            ageDictionary.Add("John", 25);
            ageDictionary.Add("Jane", 30);
            ageDictionary.Add("Bob", 28);

            // 通过键查找值
            Console.WriteLine("Age of John: " + ageDictionary["John"]);

            // 判断是否包含某个键
            if (ageDictionary.ContainsKey("Jane"))
            {
                Console.WriteLine("Jane's age is in the dictionary.");
            }

            // 遍历所有键值对
            Console.WriteLine("All people and their ages:");
            foreach (var kvp in ageDictionary)
            {
                Console.WriteLine("Name: " + kvp.Key + ", Age: " + kvp.Value);
            }

            // 获取所有键和值的集合
            var allNames = ageDictionary.Keys;
            var allAges = ageDictionary.Values;

            // 移除某个键值对
            ageDictionary.Remove("Bob");

            // 获取字典中键值对的数量
            Console.WriteLine("Number of people in the dictionary: " + ageDictionary.Count);

            // 清空字典
            ageDictionary.Clear();

            // 检查字典是否为空
            if (ageDictionary.Count == 0)
            {
                Console.WriteLine("Dictionary is empty.");
            }
        }
    }
    ```


## LeetCode Problems
    
### LC [454] [4Sum II](https://leetcode.com/problems/4sum-ii/description/)

#### Idea: 
**一般哈希表都是用来快速判断一个元素是否出现集合里。**。这个题可以先使用一个哈希表存储nums1和nums2中的两数之和，然后再寻找nums3和nums4中的两数之和与第一个哈希表中的数的和是否能为0.

  - Code 
    ```csharp
            /*
            * @lc app=leetcode id=454 lang=csharp
            *
            * [454] 4Sum II
            */

            // @lc code=start
            public class Solution {
                public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
                    //store the sums of nums1 and nums2
                    Dictionary<int, int> dic = new Dictionary<int, int>();  

                    // all the array have the same length
                    int l = nums1.Length;

                    for (int num1 = 0; num1 < l; num1++)
                    {
                        for (int num2 = 0; num2 < l; num2++)
                        {
                            int sum = nums1[num1] + nums2[num2];
                            // add the time of the sum appears as the value, the sum as the key
                            if(dic.ContainsKey(sum)){
                                dic[sum]++;
                            }else{
                                dic.Add(sum, 1);
                            }
                        }
                    }

                    //define a counter to record
                    int counter = 0;
                    //then calculate the sums of nums3 and nums 4

                    for (int num3 = 0; num3 < l; num3++)
                    {
                        for (int num4 = 0; num4 < l; num4++)
                        {
                            int minusSum = 0 - nums3[num3] - nums4[num4];
                            if(dic.ContainsKey(minusSum)){
                                counter += dic[minusSum];
                            }
                        }
                    }
                    return counter;
                }
            }
            // @lc code=end


    ```
    
    


### LC [383](https://leetcode.com/problems/ransom-note/description/) Ransom Note

#### My Idea: Using Hash Array to solve, samilar to LC242

  - Code 
    ```csharp
        /*
        * @lc app=leetcode id=383 lang=csharp
        *
        * [383] Ransom Note
        */

        // @lc code=start
        public class Solution {
            public bool CanConstruct(string ransomNote, string magazine) {
                int[] hashArray = new int[26];

                foreach (var item in magazine)
                {
                    hashArray[item - 'a']++;
                }

                foreach (var letter in ransomNote)
                {
                    hashArray[letter - 'a']--;
                }

                for (int i = 0; i < hashArray.Length; i++)
                {
                    if(hashArray[i] < 0){
                        return false;
                    }
                }

                return true;
            }
        }
        // @lc code=end


    ```
    
    


  

