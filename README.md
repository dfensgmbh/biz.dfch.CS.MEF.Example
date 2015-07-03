# MEF Example

This repository contains extended source code of the [Simple Calculator MEF Application Simple calculator](https://code.msdn.microsoft.com/windowsdesktop/Simple-Calculator-MEF-1152654e)


This example shows the usage of the [Managed Extensibility Framework (MEF)](https://msdn.microsoft.com/en-us/library/dd460648(v=vs.110).aspx)


## Compilation

1. Open `Program.cs`
2. In the `app.config`, specify the path to the Extensions folder on your local computer

  ```
  <add key="ExtensionsFolder" value="Extensions"/>
  ```

You can specify a relative or a full path and even reference parent paths such as `..\..\Extensions`.

**HINT**: Every time a new part is added to the `Extensions` project it has to be rebuilt to make the part available to the calculator.


## Test the project

1. Run the project
2. A command window appears.
3. Type addition or subtraction commands
  * 1+1
  * 1-2
4. Try to type multiplication or division commands
  * 1*2
  * 1/2
  
  The following message will be displayed: `Operation not found!`
