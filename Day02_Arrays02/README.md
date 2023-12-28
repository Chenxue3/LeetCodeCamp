# Day02

## Double Pointers

### LeetCode977: Squares of a sorted array

- My Thought: First within a time of O(n), git a new array of a squared array. Then sort the new array, the time complexity depends on the sorting algorithms. the final TC will be about$O(nlogn)-O(n^2)$
- The Double Pointer: define a new array, define a pointer point to the start and another pointer point to the end of the original array. Compare the square number of these two pointers. Add the larger one to the end of the new array. See the Diagram below:
  ![image-20231228103003980](https://gitee.com/susanchan/image-stroge/raw/master/image-20231228103003980.png)

- Mistakes I made: at first time,  I used `while(start == end)`, and it turns out it will skip the case when the start pointer and the end pointer point to the same element. 

  ```c#
  /*
   * @lc app=leetcode id=977 lang=csharp
   *
   * [977] Squares of a Sorted Array
   */
  
  // @lc code=start
  public class Solution {
      public int[] SortedSquares(int[] nums) {
          // the pointer points to the start
          int start = 0;
  
          // the pointer points to the end
          int end = nums.Length - 1;
  
          // using k to record the current position for new add elements
          int k = end;
  
          // define a new array
          int[] sortedArr = new int[nums.Length];
  
          // loop, ends when the start pointer points to the element that the end pointer has went through.
          while(start <= end){
              // add the bigger one into the end of the new array
              if(nums[start] * nums[start] > nums[end] * nums [end]){
                  sortedArr[k--] = nums[start] * nums[start];
                  start++;
              }
              else{
                  sortedArr[k--] = nums[end] * nums [end];
                  end--;
              }
          }
          return sortedArr;
      }
  }
  // @lc code=end
  
  
  ```

  

### LeetCode [209] Minimum Size Subarray Sum

- My thought: 2 pointers, when current subarray not satisfied, fast pointer move to next. when satisfied, record the current length and the slow pointer move to the next. Which can pass some of the test cases, but the TC will be $O(n^2)$. Time Limit Exceeded.

  ```c#
  /*
   * @lc app=leetcode id=209 lang=csharp
   *
   * [209] Minimum Size Subarray Sum
   */
  
  // @lc code=start
  public class Solution {
      public int MinSubArrayLen(int target, int[] nums) {
          int slowPointer = 0;
          int fastPointer = 0;
          int subLength = 0;
  
          while (fastPointer < nums.Length){ 
              
              // 计算出当前两个指针中间元素的和
              int currentSum = 0;
              int i = slowPointer;
              while( i<=fastPointer){
                  currentSum += nums[i];
                  i++;
              }
              // 当目前两个指针中间元素的和大于等于target的时候，计算sub数组长度
              if(currentSum >= target){
               	  //计算当前sub数组长度
                  int curSubLength = fastPointer - slowPointer + 1;
                //如果原来的subLength大于当前的sub数组长度，替换为当前的数组长度
                  if(subLength == 0 || subLength > curSubLength){
                      subLength = curSubLength;
                  }
                  //慢指针向后移动一位
                  slowPointer++;
              }
              else{
              //当目前两个指针中间元素的和小target的时候，快指针向后移动一位
              fastPointer++;
              }
              
          }
          return result;
  
      }
  }
  // @lc code=end
  ```
  

- Slide Method: Calculate the sum while the point move:

  ```c#
  /*
   * @lc app=leetcode id=209 lang=csharp
   *
   * [209] Minimum Size Subarray Sum
   */
  
  // @lc code=start
  public class Solution {
      public int MinSubArrayLen(int s, int[] nums) {
          int ans = int.MaxValue;
          int start = 0, end = 0;//定义开始位置指针和结束位置指针
          int sum = 0; //定义指针中间元素之和
          while (end < nums.Length)  {//当结束位置指针停在最后一个元素的时候结束loop
              sum += nums[end]; //sum加上当前end指针指向的数字
              while (sum >= s)  //在每次循环的时候，就将end指针指向过的数字相加
              {//当sum大于target的数字的时候，检查是否是当前最小subLength
                  ans = Math.Min(ans, end - start + 1);//替换
                  sum -= nums[start]; //将start指针指向的数字减去
                  start++;//start指针后移
              }
              end++; // 当前的sum比target小，end指针后移
  
          }
          return ans == int.MaxValue ? 0 : ans;
      }
  }
  // @lc code=end
  
  
  /*
   * @lc app=leetcode id=209 lang=csharp
   *
   * [209] Minimum Size Subarray Sum
   */
  
  // @lc code=start
  public class Solution {
      public int MinSubArrayLen(int target, int[] nums) {
          int slowPointer = 0, fastPointer = 0;
          int subLength = int.MaxValue;
          int subSum = 0;
  
          for(fastPointer = 0; fastPointer< nums.Length; fastPointer++){
              subSum += nums[fastPointer];
  
              while(subSum >= target){
                  subLength = Math.Min(subLength, fastPointer - slowPointer + 1);
                  subSum -= nums[slowPointer];
                  slowPointer++;
              }
          }
  
          return subLength == int.MaxValue ? 0 : subLength; 
      
      }
        
  }
  // @lc code=end
  ```

## LetCode 59

- Point is focus on the boundary control in loops.

```c#
/*
 * @lc app=leetcode id=59 lang=csharp
 *
 * [59] Spiral Matrix II
 */

// @lc code=start
public class Solution {
    public int[][] GenerateMatrix(int n) {
        //定义输出的matrix
        int[][] answer = new int[n][];
        
        //使输出的matrix的每一层长度和n相同
        for(int i = 0; i < n; i++)
            answer[i] = new int[n];

        //定义每次循环的开始节点、结束节点
        int start = 0;
        int end = n - 1;

        //定义当前被填充的数字
        int tmp = 1; 

        //当被填充的数字小于n*n（总共要被填充的数字）
        while(tmp < n * n)
        {
            //上面行从左到右，顺序填充
            for(int i = start; i < end; i++) 
                answer[start][i] = tmp++;

            //右边列从上到下，顺序填充
            for(int i = start; i < end; i++) 
                answer[i][end] = tmp++;

             //下面行从右到左，顺序填充
            for(int i = end; i > start; i--) 
                answer[end][i] = tmp++;

            //左边列从下到上，顺序填充
            for(int i = end; i > start; i--) 
                answer[i][start] = tmp++;

            //一圈结束，内圈开始
            start++;
            end--;
        }

        // 当偶数时
        if(n % 2 == 1) answer[n / 2][n / 2] = tmp;
        return answer;
    }
}
// @lc code=end


```

