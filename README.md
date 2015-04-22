# csharp-natural-sort

Simple implementation of IComparer for "natural" sorting of mixed content types such as numeric, datetime and strings via "chunks" aka "tokens".

Has support for natural sorting of Dictionary/Hashtables by a specific column as well as Lists/Arrays.

#### Getting Started

```powershell
csc.exe /t:library /out:NaturalSort.dll NaturalSort.cs
```

```csharp
IComparer<object> sortCompare;
sortCompare = new NaturalSort();
List<object> lTest = JSON.Deserialize<List<object>>(jsonString);
lTest.Sort(sortCompare);
```

## Examples

#### Sorting values in lists:

```JSON
 in: ["img100.jpg","img10.jpg","img2.jpg"]
out: ["img2.jpg","img10.jpg","img100.jpg"] (90ms)
```


```JSON
 in: ["car.mov","01alpha.sgi","001alpha.sgi","my.string_41299.tif","organic2.0001.sgi"]
out: ["001alpha.sgi","01alpha.sgi","car.mov","my.string_41299.tif","organic2.0001.sgi"] (8ms)
```

```JSON
 in: ["./system/kernel/js/01_ui.core.js","./system/kernel/js/00_jquery-1.3.2.js","./system/kernel/js/02_my.desktop.js"]
out: ["./system/kernel/js/00_jquery-1.3.2.js","./system/kernel/js/01_ui.core.js","./system/kernel/js/02_my.desktop.js"] (2ms)
```

```JSON
 in: ["1.0.2","1.0.1","1.0.0","1.0.9"]
out: ["1.0.0","1.0.1","1.0.2","1.0.9"] (10ms)
```

```JSON
 in: ["10/12/2008","10/11/2008","10/11/2007","10/12/2007"]
out: ["10/11/2007","10/12/2007","10/11/2008","10/12/2008"] (0ms)
```

```JSON
 in: ["2/15/2009 1:46 PM","1/15/2009 1:45 PM","2/15/2009 1:45 AM"]
out: ["1/15/2009 1:45 PM","2/15/2009 1:45 AM","2/15/2009 1:46 PM"] (0ms)
```

```JSON
 in: ["Saturday, July 3, 2010 1:45:30 PM","Saturday, July 3, 2010 1:45:29 PM","Monday, August 2, 2010 1:45:01 PM","Monday, May 3, 2010 1:45:00 PM"]
out: ["Monday, May 3, 2010 1:45:00 PM","Saturday, July 3, 2010 1:45:29 PM","Saturday, July 3, 2010 1:45:30 PM","Monday, August 2, 2010 1:45:01 PM"] (0ms)
```

```JSON
 in: ["192.168.0.100","192.168.0.1","192.168.1.1","192.168.0.250"]
out: ["192.168.0.1","192.168.0.100","192.168.0.250","192.168.1.1"] (2ms)
```

```JSON
 in: ["asd1.3",2,"asd1.2",1]
out: [1,2,"asd1.2","asd1.3"] (1ms)
```

```JSON
 in: ["z22","z20","z 19","z1","z 0","y 1"]
out: ["y 1","z 0","z1","z 19","z20","z22"] (1ms)
```

```JSON
 in: ["001","0034","01","0001","0032"]
out: ["0001","001","0032","0034","01"] (0ms)
```

#### Sorting by specific column in nested dictionary in list

```JSON
 in: [{"col":"img100.jpg"},{"col":"img10.jpg"},{"col":"img2.jpg"}]
out: [{"col":"img2.jpg"},{"col":"img10.jpg"},{"col":"img100.jpg"}] (1ms)
```

```JSON
 in: [{"col":"1.0.2"},{"col":"1.0.1"},{"col":"1.0.0"},{"col":"1.0.9"}]
out: [{"col":"1.0.0"},{"col":"1.0.1"},{"col":"1.0.2"},{"col":"1.0.9"}] (2ms)
```

```JSON
 in: [{"col":"10/12/2008"},{"col":"10/11/2008"},{"col":"10/11/2007"},{"col":"10/12/2007"}]
out: [{"col":"10/11/2007"},{"col":"10/12/2007"},{"col":"10/11/2008"},{"col":"10/12/2008"}] (0ms)
```

```JSON
 in: [{"col":"192.168.0.100"},{"col":"192.168.0.1"},{"col":"192.168.1.1"},{"col":"192.168.0.250"}]
out: [{"col":"192.168.0.1"},{"col":"192.168.0.100"},{"col":"192.168.0.250"},{"col":"192.168.1.1"}] (1ms)
```

```JSON
 in: [{"col":"asd1.3"},{"col":2},{"col":"asd1.2"},{"col":1}]
out: [{"col":1},{"col":2},{"col":"asd1.2"},{"col":"asd1.3"}] (1ms)
```

Automatically exported from code.google.com/p/csharp-natural-sort
