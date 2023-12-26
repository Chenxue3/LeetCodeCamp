# 二分搜索

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



![image-20231227123844373](https://gitee.com/susanchan/image-stroge/raw/master/image-20231227123844373.png)