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
            for(int i = start; i < end; i++) answer[start][i] = tmp++;

            //右边列从上到下，顺序填充
            for(int i = start; i < end; i++) answer[i][end] = tmp++;

             //下面行从右到左，顺序填充
            for(int i = end; i > start; i--) answer[end][i] = tmp++;

            //左边列从下到上，顺序填充
            for(int i = end; i > start; i--) answer[i][start] = tmp++;

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

