# Binary-Search-Tree

## Technical details:
- implementation of BinarySearchTree with generic ```Node<type>```
    - methods: 
        - ```Insert(T value)```, 
        - ```TryInsert(T value, out Node<T> bst)```, 
        - ```Search(T value)```, 
        - ```Remove(T value)```, 
        - ```RemoveSubtree(T value)```, 
        - ```GetJson()```
- implementation of Balanced BinarySearchTree (DSW) based on BinarySearchTree algorithm
    - help methods:    
        - ```CreateBackbone()```, 
        - ```LeftRotate(Node<T> parent)```, 
        - ```RightRotate(Node<T> parent)```
- creation of timing test to compare mean execution time of creating:
    - regular generic list, 
    - Binary Search Tree, 
    - Balanced Tree.
    
Program return .csv  file with outputs times.

