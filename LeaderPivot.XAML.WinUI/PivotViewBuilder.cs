namespace LeaderAnalytics.LeaderPivot.XAML.WinUI;

public partial class PivotViewBuilder<T> : PivotViewBuilder
{
    private IEnumerable<Dimension<T>> DimensionsT;
    private IEnumerable<Measure<T>> MeasuresT;
    private Func<Task<IEnumerable<T>>> LoadData;
    private MatrixBuilder<T> MatrixBuilder;

    public PivotViewBuilder(IEnumerable<Dimension<T>> dimensions, IEnumerable<Measure<T>> measures, Func<IEnumerable<T>> loadData, bool displayGrandTotals = true)
        : this(dimensions, measures, () => Task.FromResult(loadData()), displayGrandTotals)
    {
        
    }

    public PivotViewBuilder(IEnumerable<Dimension<T>> dimensions, IEnumerable<Measure<T>> measures, Func<Task<IEnumerable<T>>> loadData, bool displayGrandTotals = true)
    {
        DimensionsT = dimensions;
        MeasuresT = measures;
        Dimensions = DimensionsT.ToList<Dimension>();
        Measures = MeasuresT.OrderBy(x => x.Sequence).Cast<Measure>().ToList();
        DisplayGrandTotals = displayGrandTotals;
        LoadData = loadData;
        NodeBuilder<T> nodeBuilder = new NodeBuilder<T>();
        Validator<T> validator = new Validator<T>();
        MatrixBuilder = new MatrixBuilder<T>(nodeBuilder, validator);
    }
    
    public override async Task BuildMatrix(string? nodeID = null)
    {
        if (string.IsNullOrEmpty(nodeID))
        {
            RowDimensions = Dimensions.Where(x => x.IsEnabled && x.IsRow).OrderBy(x => x.Sequence).ToList();
            ColumnDimensions = Dimensions.Where(x => x.IsEnabled && !x.IsRow).OrderBy(x => x.Sequence).ToList();
            HiddenDimensions = Dimensions.Where(x => !x.IsEnabled).OrderBy(x => x.Sequence).ToList();
            Matrix = MatrixBuilder.BuildMatrix(await LoadData(), DimensionsT, MeasuresT, DisplayGrandTotals);
        }
        else
            Matrix = MatrixBuilder.ToggleNodeExpansion(nodeID);
    }
}


public abstract partial class PivotViewBuilder : ObservableObject
{
    [ObservableProperty]
    private bool _DisplayGrandTotals;

    [ObservableProperty]
    private IList<Dimension> _Dimensions;

    [ObservableProperty]
    private IList<Dimension> _RowDimensions;

    [ObservableProperty]
    private IList<Dimension> _ColumnDimensions;

    [ObservableProperty]
    private IList<Dimension> _HiddenDimensions;

    [ObservableProperty]
    private IList<Measure> _Measures;

    [ObservableProperty]
    private LeaderAnalytics.LeaderPivot.Matrix _Matrix;

    public Visibility HiddenDimensionsVisibility => (HiddenDimensions?.Any() ?? false) ? Visibility.Visible : Visibility.Collapsed;

    public abstract Task BuildMatrix(string? nodeID);
}