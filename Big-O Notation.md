# Big-O Notation

## Methods and their O(n)

### Collections & Arrays

```CS
int[] array1 = new int[5];                           // Empty array of size 5
int[] array2 = { 1, 2, 3, 4, 5 };                   // Array with values
int[] array3 = new int[] { 1, 2, 3 };               // Explicit type with values
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `Array.IndexOf()` | O(n) | Linear search through array |
| `Array.Sort()` | O(n log n) | Quick sort algorithm |
| `Array.Reverse()` | O(n) | In-place reversal |
| `Array.Copy()` | O(n) | Copies n elements |
| `Array.BinarySearch()` | O(log n) | Requires sorted array |

### List<T>

```CS
List<int> list1 = new List<int>();                  // Empty list
List<int> list2 = new List<int> { 1, 2, 3 };       // List with initial values
List<string> list3 = new() { "a", "b", "c" };      // C# 9+ target-typed new
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `list.Add()` | O(1) amortized | O(n) when resizing needed |
| `list.Insert(index, item)` | O(n) | Shifts elements after index |
| `list.Remove(item)` | O(n) | Searches + shifts elements |
| `list.RemoveAt(index)` | O(n) | Shifts elements after index |
| `list[index]` | O(1) | Direct index access |
| `list.Contains()` | O(n) | Linear search |
| `list.IndexOf()` | O(n) | Linear search |
| `list.Sort()` | O(n log n) | Quick sort algorithm |

### Dictionary<TKey, TValue>

```CS
Dictionary<int, string> dict1 = new Dictionary<int, string>();                          // Empty dictionary
Dictionary<int, string> dict2 = new Dictionary<int, string> { {1, "one"}, {2, "two"} }; // With values
Dictionary<int, string> dict3 = new() { [1] = "one", [2] = "two" };
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `dict.Add()` | O(1) | Average case |
| `dict[key]` (get/set) | O(1) | Average case |
| `dict.ContainsKey()` | O(1) | Average case |
| `dict.Remove()` | O(1) | Average case |
| `dict.TryGetValue()` | O(1) | Average case |

### HashSet<T>

```CS
HashSet<int> set1 = new HashSet<int>();             // Empty set
HashSet<int> set2 = new HashSet<int> { 1, 2, 3 };   // Set with values
HashSet<string> set3 = new() { "a", "b", "c" };     // Target-typed
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `set.Add()` | O(1) | Average case |
| `set.Remove()` | O(1) | Average case |
| `set.Contains()` | O(1) | Average case |
| `set.UnionWith()` | O(n + m) | Where m is size of other set |
| `set.IntersectWith()` | O(n) | Average case |

### Queue<T> & Stack<T>

```CS
Queue<int> queue1 = new Queue<int>();                   // Empty queue
Queue<int> queue2 = new Queue<int>(new[] { 1, 2, 3 });  // From array
Stack<int> stack1 = new Stack<int>();                   // Empty stack
Stack<int> stack2 = new Stack<int>(new[] { 1, 2, 3 });  // From array (reversed!)

```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `queue.Enqueue()` | O(1) | Add to end |
| `queue.Dequeue()` | O(1) | Remove from front |
| `queue.Peek()` | O(1) | View front element |
| `stack.Push()` | O(1) | Add to top |
| `stack.Pop()` | O(1) | Remove from top |
| `stack.Peek()` | O(1) | View top element |

### LinkedList<T>

```CS
LinkedList<int> linked1 = new LinkedList<int>();    // Empty linked list
LinkedList<int> linked2 = new LinkedList<int>(new[] { 1, 2, 3 }); // From array
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `list.AddFirst()` | O(1) | Add to beginning |
| `list.AddLast()` | O(1) | Add to end |
| `list.RemoveFirst()` | O(1) | Remove from beginning |
| `list.RemoveLast()` | O(1) | Remove from end |
| `list.Find()` | O(n) | Must traverse list |

### String Operations

```CS
StringBuilder sb1 = new StringBuilder();             // Empty
StringBuilder sb2 = new StringBuilder("Hello");      // With initial string
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `string.Substring()` | O(n) | Creates new string |
| `string.IndexOf()` | O(n × m) | Where m is search string length |
| `string.Contains()` | O(n × m) | Where m is search string length |
| `string.Split()` | O(n) | Creates array of strings |
| `string.Join()` | O(n) | Where n is total characters |
| `StringBuilder.Append()` | O(1) amortized | Much better than string + |
| `string + string` | O(n + m) | Creates new string each time |

### LINQ Methods

LINQ can be applied to any IEnumerable<T> or IEnumerable in C#

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `.Where()` | O(n) | Filters collection |
| `.Select()` | O(n) | Projects each element |
| `.First()` / `.FirstOrDefault()` | O(1) to O(n) | Stops at first match |
| `.Any()` | O(1) to O(n) | Short-circuits on match |
| `.All()` | O(n) | Must check all elements |
| `.Count()` | O(1) or O(n) | O(1) if collection has Count property |
| `.OrderBy()` | O(n log n) | Sorting operation |
| `.Sum()` / `.Average()` | O(n) | Iterates all elements |
| `.Distinct()` | O(n) | Uses HashSet internally |
| `.GroupBy()` | O(n) | Uses Dictionary internally |

### Important Notes

- **Amortized O(1)**: Operation is usually O(1), but occasionally O(n) (like when resizing)
- **Average Case**: Hash-based structures can degrade to O(n) in worst case with poor hash distribution
- **Sorted Collections**: `SortedDictionary<K,V>` and `SortedSet<T>` have O(log n) for most operations
