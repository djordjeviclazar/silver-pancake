# silver-pancake: Unicode converter console application

This application can be used to convert unicode hex code to string, or string to hex code. It works with: **UTF8**, **UTF7**, **UTF32**, **Unicode**, and **Big Endian Unicode**.

To run this application first compile it (use Visual Studio, or other tool), and run with paramaters:
1. **Type of conversion** - possible values: **"encode"** (conversion from string to hex); **"decode"**;
2. **Remove whitespace characters** - if you want to remove spaces, tabs, etc from input: **"y"** (to remove); **"n"** (or any other string for no action);
3. **Type of encoding**: **["UTF8" | "UTF7" | "UTF32" | "Unicode" | "Big Endian Unicode"]**
4. **Input** - represents input string or hex value: can be any string if string contains blanks please wrap with "".

## Example
In containing folder run this command from command line:
> UnicodeConverter.exe decode n Unicode "2104400435045B0430043D04200040043E04520435043D04340430043D042100"

Result should be: 

> Срећан рођендан!

## References
Some methods in this implementation can be found on StackOverflow as answers:
1. [Remove whitespaces - answer by slandau](https://stackoverflow.com/a/6219488/13448436)
2. [Convert byte to hexa - answer by Mykroft](https://stackoverflow.com/a/2556329/13448436)
3. [Unicode output on C# console - answer by Michael Yanni](https://stackoverflow.com/a/38533904/13448436)
