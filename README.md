# Binary-Search-Tree

## Technical details:
- implementation of BinarySearchTree with generic ```Node<type>```
    - methods: 
        ```c#
        Insert(T value)
        TryInsert(T value, out Node<T> bst), 
        Search(T value), 
        Remove(T value), 
        RemoveSubtree(T value), 
        GetJson()
- implementation of Balanced BinarySearchTree (DSW) based on BinarySearchTree algorithm
    - help methods:    
        ```c#
        CreateBackbone(), 
        LeftRotate(Node<T> parent), 
        RightRotate(Node<T> parent)
- creation of timing test to compare mean execution time of creating:
    - regular generic list, 
    - Binary Search Tree, 
    - Balanced Tree.
    
Program return .csv  file with outputs times.

### Simple example of Balanced Tree with 4 nodes:
- Before remove: 

![image](https://user-images.githubusercontent.com/30668073/60334878-d3ddff00-999c-11e9-9052-6c5c24eb222f.png)
```JSON
{
    "Value":2,
    "LeftChild":{
        "Value":1,
        "LeftChild":{
            "Value":0,
            "LeftChild":null,
            "RightChild":null
            },
        "RightChild":null
        },
    "RightChild":{
        "Value":3,
        "LeftChild":null,
        "RightChild":null
        }
} 
```
- After remove 1:

![image](https://user-images.githubusercontent.com/30668073/60335057-36cf9600-999d-11e9-9bd1-4a5bfab3d1a5.png)

```JSON
{
    "Value":2,
    "LeftChild":{
        "Value":0,
        "LeftChild":null,
        "RightChild":null
        },
    "RightChild":{
        "Value":3,
        "LeftChild":null,
        "RightChild":null
        }
}
```

