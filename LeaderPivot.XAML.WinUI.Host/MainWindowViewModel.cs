using LeaderAnalytics.LeaderPivot;
using LeaderAnalytics.LeaderPivot.TestData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LeaderAnalytics.LeaderPivot.XAML.WinUI;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LeaderPivot.XAML.WinUI.Host;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private PivotViewBuilder<SalesData> _ViewBuilder;

    [ObservableProperty]
    private bool _IsBusy;
   

    private SalesDataService SalesDataService;
    

    public MainWindowViewModel()
    {
        IsBusy = true;
        SalesDataService = new SalesDataService();
        BuildMatrix();
    }

    private void BuildMatrix()
    {
        List<Dimension<SalesData>> dimensions = SalesDataService.LoadDimensions();
        List<Measure<SalesData>> measures = SalesDataService.LoadMeasures();
        dimensions.First(x => x.DisplayValue == "City").IsEnabled = false;
        ViewBuilder = new PivotViewBuilder<SalesData>(dimensions, measures, LoadData, true);
    }

    public async Task<IEnumerable<SalesData>> LoadDataAsync()
    {
        return await Task.Run(() => SalesDataService.GetSalesData());
        //List<SalesData> salesData = SalesDataService.GetSalesData();
        //return await Task.FromResult(salesData);
    }

    public List<SalesData> LoadData()
    {
        List<SalesData> salesData = SalesDataService.GetSalesData();
        return salesData;
    }
}
