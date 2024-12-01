![Leader Analytics](./logo.png)



# LeaderPivot.XAML.WinUI

Pivot grid control for WinUI

* Easy to implement and configure
* Drag and drop dimensions across axis
* User configurable measures
* Two color themes provided, customize or create your own.


![Leader Analytics pivot grid control](./screencap.png) 

# Getting Started

* Clone this repository and run the demo application.  This repository contains source code for the control as well as a small demo application.

* Create a data structure to model your denormalized data.  See the [`SalesData`](https://github.com/leaderanalytics/LeaderPivot.TestData/blob/main/LeaderPivot.TestData/SalesData.cs) class for an example.

* Create [Dimensions](https://github.com/leaderanalytics/LeaderPivot/blob/main/LeaderPivot/Dimension.cs) and [Measures](https://github.com/leaderanalytics/LeaderPivot/blob/main/LeaderPivot/Measure.cs).    Dimensions are used to group data.  Measures are used to create the values shown in each cell of the pivot table.  Examples are provided in the [TestData](https://github.com/leaderanalytics/LeaderPivot.TestData/blob/main/LeaderPivot.TestData/SalesData.cs) project.

* [Add a LeaderPivot control to your page](https://github.com/leaderanalytics/LeaderPivot.XAML.WinUI/blob/main/LeaderPivot.XAML.WinUI.Host/MainWindow.xaml).  

This control is based on [LeaderPivot](https://github.com/leaderanalytics/LeaderPivot).  [Test data can be found here](https://github.com/leaderanalytics/LeaderPivot.TestData).

A nuget package for LeaderPivot.XAML.WinUI is not available because it is not [reasonably supported](https://learn.microsoft.com/en-us/windows/uwp/winrt-components/creating-windows-runtime-components-in-csharp-and-visual-basic#declaring-types-in-windows-runtime-components).

LeaderPivot for WPF can be found [here](https://github.com/leaderanalytics/LeaderPivot.Blazor).

LeaderPivot for Blazor can be found [here](https://github.com/leaderanalytics/LeaderPivot.Blazor).


Release Notes:
Version 2 - dotnet 9
Version 1 - dotnet 8