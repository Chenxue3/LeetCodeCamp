# Day24

## Topic Backtracking Basics

- The effectivness of backtracking is not that good, because it is a **brute force** algorithm. Sometime is based on the **pruning**(剪枝) of the search tree. Pruning is the process of **eliminating** some of the nodes (branches) from the search tree, so that the search tree is smaller than the original one.
- Template of a Backtracking algorithm:
  ```csharp
    void backtracking(参数) {
    if (终止条件) {
        存放结果;
        return;
    }

    for (选择：本层集合中元素（树中节点孩子的数量就是集合的大小）) {
        处理节点;
        backtracking(路径，选择列表); // 递归
        回溯，撤销处理结果
    }
    }
```
    

## LeetCode Problems
    
### LC 

#### My Idea: 

  - Code 
    ```csharp
    
    ```
    
    

  | Bugs | Test Case & Excepted Output | My Output | Debug |
  | ---- | --------------------------- | --------- | ----- |
  |      | |  |       |
  |      |      |  |

  

#### Method one: 

  
  - note: 
  
  - Code:
    ```csharp
    
    ```