/*
 * @lc app=leetcode id=77 lang=csharp
 *
 * [77] Combinations
 */

// @lc code=start
public class Solution {
    private List<List<int>> res = new List<List<int>>(); // the output
    private List<int> path = new List<int>(); // the reasonable result for each time

    //back tracking algorithms
    void backtracking(int n, int k, int startIndex){
        // 终止条件
        if(path.size == k){ // when the path is contain k numbers
            res.Push(path);
            return;
        }

        // for each path generation
        for(int i = startIndex; i <= n; i++) {
            // add curent number into the path
            path.Push(i);
            backtracking(n,k,i+1);
        }
    }
    public IList<IList<int>> Combine(int n, int k) {
        

    }
}
// @lc code=end

