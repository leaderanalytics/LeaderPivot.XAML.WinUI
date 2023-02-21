﻿namespace LeaderAnalytics.LeaderPivot.XAML.WinUI;

public class DimensionEventArgs  
{
    //  Dimension.DisplayName is guaranteed to be unique and is also the ID
    public string DimensionID { get; set; }
    public DimensionAction Action { get; set; }
}
