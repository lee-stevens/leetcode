# Big-O Notation - TypeScript

## Methods and their O(n)

### Arrays

```TS
let array1: number[] = new Array(5);                     // Empty array of size 5
let array2: number[] = [1, 2, 3, 4, 5];                 // Array with values
let array3: number[] = Array.from([1, 2, 3]);           // Array from iterable
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `array.indexOf()` | O(n) | Linear search through array |
| `array.sort()` | O(n log n) | Timsort algorithm |
| `array.reverse()` | O(n) | In-place reversal |
| `[...array]` | O(n) | Spread operator copies array |
| Binary search (manual) | O(log n) | Requires sorted array |

### Array Methods

```TS
let numbers: number[] = [1, 2, 3, 4, 5];
let strings: string[] = ["a", "b", "c"];
let mixed: (string | number)[] = [1, "hello", 3];
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `array.push()` | O(1) amortized | Add to end |
| `array.pop()` | O(1) | Remove from end |
| `array.unshift()` | O(n) | Add to beginning, shifts all |
| `array.shift()` | O(n) | Remove from beginning, shifts all |
| `array[index]` | O(1) | Direct index access |
| `array.includes()` | O(n) | Linear search |
| `array.splice()` | O(n) | Insertion/deletion with shifting |
| `array.slice()` | O(n) | Creates new array |

### Map<K, V>

```TS
let map1 = new Map<number, string>();                           // Empty map
let map2 = new Map<number, string>([[1, "one"], [2, "two"]]);  // With entries
let map3 = new Map([                                            // Type inference
    [1, "one"],
    [2, "two"]
]);
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `map.set()` | O(1) | Average case |
| `map.get()` | O(1) | Average case |
| `map.has()` | O(1) | Average case |
| `map.delete()` | O(1) | Average case |
| `map.clear()` | O(n) | Removes all entries |

### Set<T>

```TS
let set1 = new Set<number>();                   // Empty set
let set2 = new Set<number>([1, 2, 3]);         // Set from array
let set3 = new Set(["a", "b", "c"]);           // Type inference
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `set.add()` | O(1) | Average case |
| `set.delete()` | O(1) | Average case |
| `set.has()` | O(1) | Average case |
| Union (manual) | O(n + m) | Using spread: `new Set([...set1, ...set2])` |
| Intersection (manual) | O(n) | Using filter + has |

### Objects (as Hash Maps)

```TS
let obj1: { [key: string]: string } = {};                      // Empty object
let obj2: Record<string, number> = { "a": 1, "b": 2 };        // Using Record type
let obj3 = { name: "John", age: 30 } as const;                 // Const assertion
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `obj[key] = value` | O(1) | Average case |
| `obj[key]` | O(1) | Average case |
| `key in obj` | O(1) | Average case |
| `delete obj[key]` | O(1) | Average case |
| `Object.keys()` | O(n) | Returns array of keys |
| `Object.values()` | O(n) | Returns array of values |

### String Operations

```TS
let str1: string = "Hello World";
let str2 = `Template string with ${str1}`;
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `string.substring()` | O(n) | Creates new string |
| `string.indexOf()` | O(n × m) | Where m is search string length |
| `string.includes()` | O(n × m) | Where m is search string length |
| `string.split()` | O(n) | Creates array of strings |
| `array.join()` | O(n) | Where n is total characters |
| `string + string` | O(n + m) | Creates new string |
| Template literals | O(n) | Efficient concatenation |

### Array Higher-Order Methods

All array methods work with any array type in TypeScript

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| `.filter()` | O(n) | Filters array elements |
| `.map()` | O(n) | Transforms each element |
| `.find()` / `.findIndex()` | O(1) to O(n) | Stops at first match |
| `.some()` | O(1) to O(n) | Short-circuits on match |
| `.every()` | O(n) | Must check all elements |
| `.length` | O(1) | Property access |
| `.sort()` | O(n log n) | Timsort algorithm |
| `.reduce()` | O(n) | Iterates all elements |
| `.forEach()` | O(n) | Iterates all elements |

### Specialized Data Structures (Custom Implementation Needed)

```TS
// Queue implementation
class Queue<T> {
    private items: T[] = [];

    enqueue(item: T): void { this.items.push(item); }      // O(1)
    dequeue(): T | undefined { return this.items.shift(); } // O(n) - not optimal
    peek(): T | undefined { return this.items[0]; }        // O(1)
}

// Stack implementation
class Stack<T> {
    private items: T[] = [];

    push(item: T): void { this.items.push(item); }         // O(1)
    pop(): T | undefined { return this.items.pop(); }      // O(1)
    peek(): T | undefined { return this.items[this.items.length - 1]; } // O(1)
}
```

| Method/Operation | Time Complexity | Notes |
|-----------------|----------------|-------|
| Queue operations | See above | Built-in arrays not optimal for queues |
| Stack operations | O(1) | Arrays work well as stacks |

### Important Notes

- **JavaScript Engine**: V8 uses different optimizations that can affect complexity
- **Array Implementation**: JavaScript arrays are actually objects, but engines optimize them
- **Hash Collisions**: Map and Set can degrade to O(n) in worst case scenarios
- **Memory vs Speed**: Spread operator creates new arrays/objects (O(n) space and time)
- **TypeScript Compilation**: Type checking happens at compile time, no runtime overhead
- **Optimal Queue**: For better queue performance, consider using a proper queue implementation or libraries like `collections` or `datastructures-js`

### TypeScript-Specific Features

```TS
// Type guards affect runtime, not complexity
function isString(value: unknown): value is string {
    return typeof value === "string";                       // O(1)
}

// Generics are compile-time only
function identity<T>(arg: T): T {
    return arg;                                             // O(1)
}

// Interface implementation has no runtime cost
interface Comparable {
    compareTo(other: Comparable): number;
}
```