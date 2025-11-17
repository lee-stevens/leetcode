# C# GC

## Overview

### ✅ C# Garbage Collection Cheat Sheet (Interview-Ready)

## 1. What GC Does

- Allocates memory for new objects
- Finds unreachable objects
- Frees their memory
- Compacts the heap (except LOH)
- Runs automatically in the CLR

## 🧱 2. .NET Managed Heap Layout

### Small Object Heap (SOH)

- Gen 0 → newly allocated, short-lived
- Gen 1 → survivors of Gen 0
- Gen 2 → long-lived objects (configs, caches)

### Large Object Heap (LOH)

- Objects ≥ 85 KB
- Not compacted (fragmentation possible)
- Collected with Gen 2

## 🔄 3. GC Cycle Stages

### Mark → Sweep → Compact

#### Mark

GC identifies all objects reachable from roots:

- stack variables
- static fields
- CPU registers
- pinned handles

#### Sweep

Unmarked objects = garbage → reclaimed.

#### Compact

Moves surviving objects together → reduces fragmentation.
(LOH is not compacted.)

## 🚀 4. When GC Runs

Triggered when:

- Gen 0 fills (most common)
- Allocation fails
- System is under memory pressure
- You explicitly call GC.Collect() (rarely appropriate)

## 🧬 5. Generational GC (Why It Exists)

- Most objects die young → optimize for Gen 0
- Older generations collected less often
- Reduces pause times
- Improves performance dramatically

## 🧪 6. GC Modes

### Workstation GC

- Default for desktop apps
- Focus on smooth UI responsiveness
- Smaller, more frequent collections

### Server GC

- ASP.NET / backend workloads
- Multiple GC threads
- Higher throughput
- Larger heaps

### Background GC

- Non-blocking Gen 2 collections
- Minimizes pause times

## 🔌 7. SafeHandle, IDisposable, Finalizers

GC handles memory but not unmanaged resources.

### IDisposable

Use for:

- Database connections
- File handles
- Sockets
- Native resources

Pattern:

```csharp
using var file = File.OpenRead("data.txt");
```

### Finalizer (~ClassName)

- Runs before object is reclaimed
- Slow, unpredictable
- Should be avoided unless absolutely needed
- Typically paired with SafeHandle

## 📦 8. Boxing & the GC

Boxing a value type creates a heap allocation, increasing GC pressure.

Avoid:

```csharp
object o = 5; // boxing
```

## 🧲 9. Pinned Objects

Pinned objects cannot be moved during compaction.

Created through:

- fixed blocks
- GCHandle.Alloc(obj, GCHandleType.Pinned)

Too many pinned objects → heap fragmentation → slower GC.

## 📚 10. Common Interview Questions (and short answers)

**Q: What triggers GC?**

Gen 0 overflow, allocation failure, memory pressure.

**Q: Why generational GC?**

Most objects die early → faster collection in Gen 0.

**Q: What lives on the LOH?**

Objects ≥ 85 KB; not compacted.

**Q: Should you call GC.Collect()?**

Only in very rare, controlled scenarios (profiling, after huge object disposal).

**Q: Difference between Finalizer and IDisposable?**

- Finalizer: last-resort cleanup, nondeterministic
- IDisposable: deterministic cleanup for unmanaged resources

**Q: What are GC roots?**

Locations the GC starts from (stack, static fields, CPU registers).

⭐ 11. Quick Sketch to Memorize

+-----------------------+
|        Gen 0          |  Fast, frequent
+-----------------------+
|        Gen 1          |  Survivors
+-----------------------+
|        Gen 2          |  Long-lived
+-----------------------+
|         LOH           |  ≥ 85 KB, not compacted
+-----------------------+
