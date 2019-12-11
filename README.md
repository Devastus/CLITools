# CLITools
A small set of utilities and tools for C# command line applications

## Creating new commands
New commands can be written by writing a function with certain signature and attaching the **Command** attribute as follows:
```csharp
//First parameter is the command to invoke with, then it's description
[Command("example", "example description")]
public static void ExampleCommand(string[] args)
{
	foreach(string a in args)
	{
		Console.WriteLine(a);
	}
}
```
This function can then be run with the following command:
```
CompiledExecutable.exe example arg1 arg2 arg3...
```
Function needs to be static, return void and take in an array of string arguments. Arguments need to be parsed inside the function itself.