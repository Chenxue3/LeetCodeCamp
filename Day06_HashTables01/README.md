# Day05 Hashtable01

## Topic Hash Tables
### 哈希表
在C#中，HashTable 是一个基于哈希表的集合类，它允许你存储键值对，并通过键来检索值。HashTable 是`System.Collections` 命名空间下的一部分。**一般哈希表都是用来快速判断一个元素是否出现集合里。** 遇到哈希表可以加爵的问题，一般用***Arrays(hash value & range small), Set(key-value), Map(big hash value & range)***
```c#
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        // 创建一个 HashTable 实例
        Hashtable myHashTable = new Hashtable();

        // 添加键值对
        myHashTable.Add("Key1", "Value1");
        myHashTable.Add("Key2", "Value2");
        myHashTable.Add("Key3", "Value3");

        // 通过键获取值
        string valueForKey2 = (string)myHashTable["Key2"];
        Console.WriteLine("Value for Key2: " + valueForKey2);

        // 检查某个键是否存在
        if (myHashTable.ContainsKey("Key1"))
        {
            Console.WriteLine("Key1 exists in the HashTable.");
        }

        // 遍历所有键值对
        foreach (DictionaryEntry entry in myHashTable)
        {
            Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
        }
    }
}

```
### 哈希函数
哈希函数，把学生的姓名直接映射为哈希表上的索引，然后就可以通过查询索引下标快速知道这位同学是否在这所学校里。

哈希函数的特性：
- 固定输出长度： 不管输入的数据大小如何，哈希函数生成的哈希值的长度是固定的。这使得哈希值在数据结构中的存储和比较更为高效。
- 快速计算： 哈希函数应该能够在合理的时间内计算出哈希值，以确保对大量数据进行快速的哈希操作。
- 离散性： 相似的输入值应该产生差异很大的哈希值，以避免冲突（多个不同的输入映射到相同的哈希值）。
- 不可逆性： 通常来说，哈希函数是单向的，即从哈希值不能反向得到原始数据。这是为了保护数据的安全性。
- 冲突少： 尽管不可能完全避免冲突，好的哈希函数应该尽量减少冲突的发生，即不同的输入应该映射到不同的哈希值。

```c#
using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override int GetHashCode()
    {
        // 计算哈希值时结合对象的属性
        return Name.GetHashCode() ^ Age.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        // 检查是否是同一对象的引用
        if (ReferenceEquals(this, obj))
            return true;

        // 检查是否为null或者类型不匹配
        if (obj == null || GetType() != obj.GetType())
            return false;

        // 检查属性是否相等
        Person otherPerson = (Person)obj;
        return Name == otherPerson.Name && Age == otherPerson.Age;
    }
}

class Program
{
    static void Main()
    {
        // 创建一个散列数据结构
        var personHashTable = new System.Collections.Hashtable();

        // 添加两个相同属性的不同对象
        var person1 = new Person { Name = "John", Age = 25 };
        var person2 = new Person { Name = "John", Age = 25 };

        personHashTable[person1] = "Person 1 Data";

        // 尝试使用相似属性的对象检索数据
        Console.WriteLine(personHashTable[person2]); // 应该输出 "Person 1 Data"，因为 Equals 方法被覆盖了

        // 注意：在实际项目中，推荐使用泛型的 Dictionary 类型而不是非泛型的 Hashtable 类型。
    }
}
```

如果学生的数量大于哈希表的大小怎么办，此时就算哈希函数计算的再均匀，也避免不了会有几位学生的名字同时映射到哈希表 同一个索引下标的位置。此时使用哈希碰撞。

### 哈希碰撞
A **hash collision** occurs when two different inputs produce the same hash value when processed by a hash function. In other words, two distinct pieces of data result in identical hash codes.
- ***Separate chaining***,where each bucket in the hash table contains a **linked list** of elements that hash to the same value. This way, if a collision occurs, the colliding elements can be stored in the same bucket without conflict.
- ***Open addressing***, where the algorithm looks for the **next available slot** in the hash table when a collision occurs

常见的哈希结构包括 `Dictionary<TKey, TValue>`、`HashSet<T>` 和 `Hashtable`。这些结构使用哈希表来实现，允许快速查找、插入和删除操作。

```csharp
using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 使用 Dictionary<TKey, TValue>
        Dictionary<string, int> ageDictionary = new Dictionary<string, int>();
        ageDictionary["John"] = 25;
        ageDictionary["Jane"] = 30;
        ageDictionary["Bob"] = 28;

        Console.WriteLine("Using Dictionary<TKey, TValue>:");
        foreach (var kvp in ageDictionary)
        {
            Console.WriteLine("Name: " + kvp.Key + ", Age: " + kvp.Value);
        }

        // 使用 HashSet<T>
        HashSet<string> nameSet = new HashSet<string>();
        nameSet.Add("John");
        nameSet.Add("Jane");
        nameSet.Add("Bob");

        Console.WriteLine("\nUsing HashSet<T>:");
        foreach (var name in nameSet)
        {
            Console.WriteLine("Name: " + name);
        }

        // 使用 Hashtable（不推荐）
        Hashtable myHashTable = new Hashtable();
        myHashTable["Key1"] = "Value1";
        myHashTable["Key2"] = "Value2";
        myHashTable["Key3"] = "Value3";

        Console.WriteLine("\nUsing Hashtable (not recommended):");
        foreach (DictionaryEntry entry in myHashTable)
        {
            Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
        }
    }
}
```

这个示例首先使用 `Dictionary<TKey, TValue>` 存储人的姓名和年龄。接着，使用 `HashSet<T>` 存储相同的人名。最后，使用 `Hashtable` 存储键值对。
`Hashtable` 不推荐使用，建议使用 `Dictionary<TKey, TValue>` 作为替代，提供了类型安全性和更好的性能。
## LeetCode Problems

### LC  [242] Valid Anagram

#### Hash Method思路:
1. 都是小写，a-z的ascll码是连续递增的。数值范围小，使用Array数据结构。First go through the string1, add 1 to each letters in the hash array they appear in the string1, then go through string2, minus 1 when a letter appears, if the final hash array with a hash value equals to 0, then return true.
2. 需要把字符映射到数组也就是哈希表的索引下标上，因为字符a到字符z的ASCII是26个连续的数值，所以字符a映射为下标0，相应的字符z映射为下标25。遍历字符串s的时候，只需要将 `s[i] - 'a'` 所在的元素做+1 操作即可，并不需要记住字符a的ASCII，只要求出一个相对数值就可以了。 这样就将字符串s中字符出现的次数，统计出来了。

  - Code 
    ```c#
    /*
    * @lc app=leetcode id=242 lang=csharp
    *
    * [242] Valid Anagram
    */
    
    // @lc code=start
    public class Solution {
    public bool IsAnagram(string s, string t) {
        int[] record = new int[26];
    
        // scan string s, record the relevant data
        for (int i = 0; i < s.Length; i++)
        {
            
            record[s[i] - 'a']++;
        }
    
        // scan string t, dele ttehe relevant data
        for (int i = 0; i < t.Length; i++)
        {
            record[t[i] - 'a']--;
        }
    
        //check all the value in the hash table
        foreach (var item in record)
        {
            //if not clear, return false
            if(item != 0){
                return false;
            }
        }
    
        return true;
        }
    }
    // @lc code=end
    
    ```
    
### LC [349] Intersection of Two Arrays

#### Hash Set 思路: 
使用数组来做哈希的题目，是因为题目都 **限制了数值的大小**。而这道题目没有限制数值的大小，就无法使用数组来做哈希表了。而且如果哈希值比较少、特别分散、跨度非常大，使用数组就造成空间的极大浪费。*但是不能直接使用Set，直接使用set不仅占用空间比数组大，而且速度要比数组慢，set把数值映射到key上都要做hash计算。*

`HashSet<T>` 是 C# 中的一种集合类型，用于存储不重复的元素。它基于哈希表的数据结构，提供了快速的查找、插入和删除操作。以下是 `HashSet<T>` 的一些重要特点和使用方法：

- 特点：

   1. **不包含重复元素：** `HashSet<T>` 不允许包含重复的元素。每个元素都必须是唯一的。

   2. **基于哈希表：** 底层实现使用哈希表，这使得查找、插入和删除的性能都是常数时间复杂度（O(1)），在平均情况下。

   3. **无序集合：** `HashSet<T>` 中的元素没有特定的顺序。如果需要有序的集合，可以考虑使用 `SortedSet<T>`。

   4. **泛型：** `HashSet<T>` 是泛型类型，可以存储任意类型的元素。

-  常用方法和属性：

   1. **`Add(T item)`：** 向集合中添加元素。

   2. **`Remove(T item)`：** 从集合中移除指定的元素。

   3. **`Contains(T item)`：** 判断集合中是否包含指定的元素。

   4. **`Count`：** 获取集合中元素的数量。

   5. **`Clear()`：** 清空集合中的所有元素。

   6. **`UnionWith(IEnumerable<T> other)`：** 将当前集合与另一个集合取并集。

   7. **`IntersectWith(IEnumerable<T> other)`：** 将当前集合与另一个集合取交集。

   8. **`ExceptWith(IEnumerable<T> other)`：** 将当前集合与另一个集合取差集。

   9. **`SymmetricExceptWith(IEnumerable<T> other)`：** 将当前集合与另一个集合取对称差集。

- 示例代码：

    ```csharp
    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            // 创建一个 HashSet
            HashSet<string> names = new HashSet<string>();
    
            // 添加元素
            names.Add("John");
            names.Add("Jane");
            names.Add("Bob");
    
            // 判断元素是否存在
            Console.WriteLine("Does 'Jane' exist in the set? " + names.Contains("Jane"));
    
            // 移除元素
            names.Remove("Bob");
    
            // 遍历所有元素
            Console.WriteLine("Elements in the set:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
    
            // 其他集合操作
            HashSet<string> otherNames = new HashSet<string> { "Alice", "Jane", "Eve" };
            names.UnionWith(otherNames);
    
            Console.WriteLine("\nAfter union with another set:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
    ```



- Code 
    ```csharp
            /*
    * @lc app=leetcode id=349 lang=csharp
    *
    * [349] Intersection of Two Arrays
    */
    
    // @lc code=start
    
    public class Solution {
        public int[] Intersection(int[] nums1, int[] nums2) {
            // define a set 1 to record the numbers in nums 1
            HashSet<int> hashSetNums1 = new HashSet<int>();
            
            foreach (var item in nums1)
            {
                hashSetNums1.Add(item);
            }
    
            // define a set to record numbers that return
            HashSet<int> ans = new HashSet<int>();
    
            // if nums1 has the same number, add the the ans set
            foreach (var num in nums2)
            {
                if (hashSetNums1.Contains(num))     
                {
                    ans.Add(num);
                }
            }
    
            return ans.ToArray();
        }
    }
    // @lc code=end


​    

  | Bugs | Test Case & Excepted Output | My Output | Debug |
  | ---- | --------------------------- | --------- | ----- |
  |    Error  |n.a |Cannot implicitly convert type `'System.Collections.Generic.HashSet<int>'` to `'int[]' (in Solution.cs)`  |  `return ans` -> `return ans.ToArray()`  |
  |      |      |  |

  

