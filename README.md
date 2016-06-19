# Numerics.NET

[![Build](https://ci.appveyor.com/api/projects/status/xr8gf9exgnuq9a71?svg=true)](https://ci.appveyor.com/project/skthomasjr/numerics)
[![Release](https://img.shields.io/github/release/skthomasjr/Numerics.svg?maxAge=2592000)](https://github.com/skthomasjr/Numerics/releases)
[![NuGet](https://img.shields.io/nuget/v/Numerics.NET.svg)](https://www.nuget.org/packages/Numerics.NET)
[![License](https://img.shields.io/github/license/skthomasjr/Numerics.svg?maxAge=2592000)](LICENSE.md)
[![Author](https://img.shields.io/badge/author-Scott%20K.%20Thomas%2C%20Jr.-blue.svg?maxAge=2592000)](https://www.linkedin.com/in/skthomasjr)
[![Join the chat at https://gitter.im/skthomasjr/Numerics](https://badges.gitter.im/skthomasjr/Numerics.svg)](https://gitter.im/skthomasjr/Numerics?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Numerics.NET is a library to support obscure operations and convenience methods pertaining to numbers.

##### Number Ranges
```c#
// Create a range of 1000.
var startRange = new Range(1000);

// Split the range into 5 equal ranges.
var myRanges range.Split(5);
Debug.WriteLine(myRanges.First().Start);
Debug.WriteLine(myRanges.First().Stop);
Debug.WriteLine(myRanges.First().Length);
```

##### Enumerate Int32 or Int64
```c#
foreach (var index in 1000.AsEnumerable())
{
  Debug.WriteLine(index);
}
```
