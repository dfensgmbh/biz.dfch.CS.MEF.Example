[![License](https://img.shields.io/badge/license-Apache%20License%202.0-blue.svg)](https://github.com/dfensgmbh/biz.dfch.CS.MEF.Example/blob/master/LICENSE)

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
  
  Typing a not implemented operation symbol like 1^2 causes the message: `Operation not found!`
