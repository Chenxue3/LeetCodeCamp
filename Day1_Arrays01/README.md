# 二分搜索

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



