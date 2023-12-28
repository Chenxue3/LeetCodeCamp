# 二分搜索&双指针

## 二分搜索

### Leetcode704

*左闭右闭*： 每一次循环都包括最左边和最右边`while(left<=right)`。因此init右边节点不能超出array的长度。

每次update的时候都要去除被检查过的节点，ie每次middle更新都要+1或者-1去掉之前的left/right

*左闭右开*： 每一次循环都包括最左边，不包括最右边`while(left<right)`。因此init右边节点可以是array的长度。

每次update的时候都要去除被检查过的节点，ie每次middle更新都要+1去掉之前的left，right则没有被检查过所有可以middle=right.

图示如下：

![image-20231227123844373](https://gitee.com/susanchan/image-stroge/raw/master/image-20231227123844373.png)

```c#
// @lc code=start
//[left, right]
public class Solution {
    public int Search(int[] nums, int target) {
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right){
            int middle = (right - left) / 2 + left;
            if(nums[middle] == target){
                return middle;
            }
            if(nums[middle]>target){
                right = middle -1;
            }
            else if(nums[middle]<target){
                left = middle +1;
            }
        }
        return -1;
    }
}

// @lc code=start
// [left, right]
public class Solution {
    public int Search (int[] nums, int target){
        int left = 0;
        // the right element is not included, so here the nums.Length is also not included
        int right = nums.Length;

        while (left < right){
            int middle = (right + left) / 2 ;
            if(nums[middle] == target){
                
                return middle;
            }
            if(nums[middle] > target){
                right = middle;
            }
            else if(nums[middle] < target){
                 left = middle +1;
            }
        }
        return -1;
    }
}
```



## 双指针

### Leetcode 27

大致思路：定义一个慢指针和一个快指针，init都是0，也就是从第一个元素开始遍历。当快指针指向不需要删除的元素时候，慢指针和快指针都向后移动一个位置，将快指针指向的元素赋值给慢指针（当两者指向同一个元素，说明没有需要删除的元素。当两者指向两个元素，说明删除了部分的元素。）。当快指针指向需要被删除的元素的时候，慢指针不动，快指针向后移动一个位置。当快指针移动到尽头，结束程序，慢指针指向的位置之前的数列是删除了target元素的数列。

如图：

![image-20231227231956562](https://gitee.com/susanchan/image-stroge/raw/master/image-20231227231956562.png)

```C#
/*
 * @lc app=leetcode id=27 lang=csharp
 *
 * [27] Remove Element
 */

// @lc code=start
public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int slowPointer = 0; //slow pointer
        int fastPointer = 0; // fast pointer
        
        //fast point update each time
        for(fastPointer = 0; fastPointer < nums.Length; fastPointer ++){ 
            
            // when the fast pointer points to a non-target value, assign this value to the place that the slow pointer points to
            if(nums[fastPointer] != val){
                nums[slowPointer] = nums[fastPointer];
                slowPointer ++;
            }
            
            //else, only update the fast pointer
        }
        
        return slowPointer;
    }
}
// @lc code=end

```

