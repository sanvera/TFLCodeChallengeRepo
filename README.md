# TFLCodeChallengeRepo
This repository is created for TFL code challenge by Abdurrahman Sanver

## Assembly Information
This project is developed with .NET Core 2.1
**Please install [.NET Core 2.1 or higher](https://www.microsoft.com/net/download/core)  if not already installed.**

## How to add/modify API Key
The application id and api key are required to get the information from TFL. These values are easily addable and also modifiable by using any kind of text editor.

After opening appSettings.json file under RoadTracker project folder you can change the following values. 
"app_id" holds the application id value
"app_key" holds the application key value
"service_root_url" holds the URL of TFL road status service you might only need to change when the service URL of TFL will change in the future.

You do not need to build the solution after every change. You must save the appSettings.json and the changes will take place immediately.

## How to build the code
###### Please install [.NET Core SDK 2.1 or higher](https://www.microsoft.com/net/download/core)  if not already installed.
### 1.Building the solution with MS Visual Studio
You can open the solution by double clicking the RoadTracker.sln icon inside the root folder.
After openning the solution you can simply build the solution by clicking Build Solution under Build menu.
You can also press Ctrl+Shift+B to build the solution.
### 2.Building the solution by using PowerShell or Command Line
First you must navigate to the solution folder which contains the RoadTracker.sln file.
Just simply write "dotnet build" and it will start building the solution.


## How to run the output
###### Please install [.NET Core Runtime 2.1 or higher](https://www.microsoft.com/net/download/core)  if not already installed.

### 1.Using PowerShell or Command Line
1. Open PowerShell or Command Line and navigate to RoadTracker project directory which contains the Program.cs file.
2. Write "dotnet run" and add the string road name you want to track the road status. 
i.e: dotnet run A2 
3. Check the last exit code by typing $lastexitcode

### 2.Using Visual Studio
If you wish to use command line inside Visual Studio to test the output, there are several ways to do this:
#### Using Package Managing Console
1. Click Package Manager Console under Tools->Nuget Package manager
2. Navigate to RoadTracker project directory which contains the Program.cs file.
3. Write "dotnet run" and add the string road name you want to track the road status. (i.e: dotnet run A2)
4. Check the last exit code by typing $lastexitcode

#### Using Powershell Tools for Visual Studio 
1. Click Extensions Under the Tools menu
2. Browse for PowerShell Tools for Visual Studio
3. Download the extension and close Visual Studio. It will start installing the extension.
4. Reopen the solution in Visual Studio
5. Click PowerShell Interactive Window under View->Other Windows menu.
6. Navigate to RoadTracker project directory which contains the Program.cs file.
7. Write "dotnet run" and add the string road name you want to track the road status. (i.e: dotnet run A2) 
8. Check the last exit code by typing $lastexitcode

## How to run tests written in the project
### Using Visual Studio Test Explorer
1. Click "Test Explorer" under Test->Windows menu if it is not already open on your screen.
2. Select the tests you want to run, right click and select "Run Selected Tests".
3. If you want run all tests, then simply click "Run All" on the Test Explorer pane.

### Using Command line or PowerShell
1. Navigate to RoadTracker solution directory which contains the RoadTracker.sln file.
2. Type "dotnet test" to run all tests
3. You can also run a specific test by typing dotnet test --filter "FullyQualifiedName=YourNamespace.TestClass1.Test1"
i.e: dotnet test --filter "FullyQualifiedName=Tests.RoadStatusFinderTests.GetValidRoadShouldReturnNullWhenTheRoadArrayIsInValid"
