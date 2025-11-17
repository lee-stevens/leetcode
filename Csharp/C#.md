# C#

## Good-to-Knows

### Out Keyword

```CS
// Two steps - less efficient
if (map.ContainsKey(compliment))        // Step 1: Check if exists
{
    int j = map[compliment];            // Step 2: Get the value
    return [i, j];
}

// One step - more efficient
if (map.TryGetValue(compliment, out int j))  // Check AND get in one line
{
    return [i, j];  // j is already populated
}
```

## Easy Optimisations

### HashSet versus Arrays

Searching/Contains

```CS
// Slow
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
if (numbers.Contains(3))  // O(n) - searches entire list

// Fast
HashSet<int> numbers = new HashSet<int> { 1, 2, 3, 4, 5 };
if (numbers.Contains(3))  // O(1) - hash lookup
```

Index of Element

```CS
// Slow
int[] nums = { 1, 2, 3, 4, 5 };
int index = Array.IndexOf(nums, 3);  // O(n) - linear search

// Fast
var map = new Dictionary<int, int>();
for (int i = 0; i < nums.Length; i++)
{
    map[nums[i]] = i;
}
int index = map[3];  // O(1) - hash lookup
```

Counting

```CS
Dictionary<int, int> counts = new Dictionary<int, int>();
foreach (int num in nums)
{
    counts[num] = counts.TryGetValue(num, out int count) ? count + 1 : 1;
}
```

Remove Duplicates

```CS
// Slow
int[] unique = nums.Distinct().ToArray();  // Works but creates intermediate enumerable

// Fast
int[] unique = new HashSet<int>(nums).ToArray();
```

String Builders

```CS
// Slow
string result = "";
for (int i = 0; i < 1000; i++)
{
    result += i.ToString();  // Creates new string each time!
}

// Fast
StringBuilder sb = new StringBuilder();
for (int i = 0; i < 1000; i++)
{
    sb.Append(i);  // Modifies buffer in place
}
string result = sb.ToString();
```
