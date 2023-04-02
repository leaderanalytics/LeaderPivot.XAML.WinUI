using CommunityToolkit.WinUI.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LeaderAnalytics.LeaderPivot.XAML.WinUI;

public sealed partial class LeaderPivotControl : Control
{
    #region Properties
    public PivotViewBuilder ViewBuilder
    {
        get { return (PivotViewBuilder)GetValue(ViewBuilderProperty); }
        set { SetValue(ViewBuilderProperty, value); }
    }

    public static readonly DependencyProperty ViewBuilderProperty =
        DependencyProperty.Register("ViewBuilder", typeof(PivotViewBuilder), typeof(LeaderPivotControl), new PropertyMetadata(null, async (s, e) => await ((LeaderPivotControl)s).BuildGrid(null)));


    public bool DisplayGrandTotalOption
    {
        get { return (bool)GetValue(DisplayGrandTotalOptionProperty); }
        set { SetValue(DisplayGrandTotalOptionProperty, value); }
    }

    public static readonly DependencyProperty DisplayGrandTotalOptionProperty =
        DependencyProperty.Register("DisplayGrandTotalOption", typeof(bool), typeof(LeaderPivotControl), new PropertyMetadata(true));


    public bool DisplayDimensionButtons
    {
        get { return (bool)GetValue(DisplayDimensionButtonsProperty); }
        set { SetValue(DisplayDimensionButtonsProperty, value); }
    }

    public static readonly DependencyProperty DisplayDimensionButtonsProperty =
        DependencyProperty.Register("DisplayDimensionButtons", typeof(bool), typeof(LeaderPivotControl), new PropertyMetadata(true));


    public bool DisplayMeasureSelectors
    {
        get { return (bool)GetValue(DisplayMeasureSelectorsProperty); }
        set { SetValue(DisplayMeasureSelectorsProperty, value); }
    }

    public static readonly DependencyProperty DisplayMeasureSelectorsProperty =
        DependencyProperty.Register("DisplayMeasureSelectors", typeof(bool), typeof(LeaderPivotControl), new PropertyMetadata(true));


    public bool DisplayReloadDataButton
    {
        get { return (bool)GetValue(DisplayReloadDataButtonProperty); }
        set { SetValue(DisplayReloadDataButtonProperty, value); }
    }

    public static readonly DependencyProperty DisplayReloadDataButtonProperty =
        DependencyProperty.Register("DisplayReloadDataButton", typeof(bool), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public int CellPadding
    {
        get { return (int)GetValue(CellPaddingProperty); }
        set { SetValue(CellPaddingProperty, value); }
    }

    public static readonly DependencyProperty CellPaddingProperty =
        DependencyProperty.Register("CellPadding", typeof(int), typeof(LeaderPivotControl), new PropertyMetadata(4));


    public Thickness CellBorderThickness
    {
        get { return (Thickness)GetValue(CellBorderThicknessProperty); }
        set { SetValue(CellBorderThicknessProperty, value); }
    }

    public static readonly DependencyProperty CellBorderThicknessProperty =
        DependencyProperty.Register("CellBorderThickness", typeof(Thickness), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public Brush CellBorderBrush
    {
        get { return (Brush)GetValue(CellBorderBrushProperty); }
        set { SetValue(CellBorderBrushProperty, value); }
    }

    public static readonly DependencyProperty CellBorderBrushProperty =
        DependencyProperty.Register("CellBorderBrush", typeof(Brush), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public bool IsBusy
    {
        get { return (bool)GetValue(IsBusyProperty); }
        set { SetValue(IsBusyProperty, value); }
    }

    public static readonly DependencyProperty IsBusyProperty =
        DependencyProperty.Register("IsBusy", typeof(bool), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public Style MeasureCellStyle
    {
        get { return (Style)GetValue(MeasureCellStyleProperty); }
        set { SetValue(MeasureCellStyleProperty, value); }
    }

    public static readonly DependencyProperty MeasureCellStyleProperty =
        DependencyProperty.Register("MeasureCellStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public Style TotalCellStyle
    {
        get { return (Style)GetValue(TotalCellStyleProperty); }
        set { SetValue(TotalCellStyleProperty, value); }
    }

    public static readonly DependencyProperty TotalCellStyleProperty =
        DependencyProperty.Register("TotalCellStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));



    public Style GrandTotalCellStyle
    {
        get { return (Style)GetValue(GrandTotalCellStyleProperty); }
        set { SetValue(GrandTotalCellStyleProperty, value); }
    }

    public static readonly DependencyProperty GrandTotalCellStyleProperty =
        DependencyProperty.Register("GrandTotalCellStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));



    public Style GroupHeaderCellStyle
    {
        get { return (Style)GetValue(GroupHeaderCellStyleProperty); }
        set { SetValue(GroupHeaderCellStyleProperty, value); }
    }

    public static readonly DependencyProperty GroupHeaderCellStyleProperty =
        DependencyProperty.Register("GroupHeaderCellStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));



    public Style TotalHeaderCellStyle
    {
        get { return (Style)GetValue(TotalHeaderCellStyleProperty); }
        set { SetValue(TotalHeaderCellStyleProperty, value); }
    }

    public static readonly DependencyProperty TotalHeaderCellStyleProperty =
        DependencyProperty.Register("TotalHeaderCellStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));



    public Style GrandTotalHeaderCellStyle
    {
        get { return (Style)GetValue(GrandTotalHeaderCellStyleProperty); }
        set { SetValue(GrandTotalHeaderCellStyleProperty, value); }
    }

    public static readonly DependencyProperty GrandTotalHeaderCellStyleProperty =
        DependencyProperty.Register("GrandTotalHeaderCellStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));



    public Style MeasureTotalLabelCellStyle
    {
        get { return (Style)GetValue(MeasureTotalLabelCellStyleProperty); }
        set { SetValue(MeasureTotalLabelCellStyleProperty, value); }
    }

    public static readonly DependencyProperty MeasureTotalLabelCellStyleProperty =
        DependencyProperty.Register("MeasureTotalLabelCellStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public Style MeasureContainerCellStyle
    {
        get { return (Style)GetValue(MeasureContainerCellStyleProperty); }
        set { SetValue(MeasureContainerCellStyleProperty, value); }
    }

    public static readonly DependencyProperty MeasureContainerCellStyleProperty =
        DependencyProperty.Register("MeasureContainerCellStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public Style DimensionContainerCellStyle
    {
        get { return (Style)GetValue(DimensionContainerCellStyleProperty); }
        set { SetValue(DimensionContainerCellStyleProperty, value); }
    }

    public static readonly DependencyProperty DimensionContainerCellStyleProperty =
        DependencyProperty.Register("DimensionContainerCellStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public Style MeasureLabelCellStyle
    {
        get { return (Style)GetValue(MeasureLabelCellStyleProperty); }
        set { SetValue(MeasureLabelCellStyleProperty, value); }
    }

    public static readonly DependencyProperty MeasureLabelCellStyleProperty =
        DependencyProperty.Register("MeasureLabelCellStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public Style DimensionButtonStyle
    {
        get { return (Style)GetValue(DimensionButtonStyleProperty); }
        set { SetValue(DimensionButtonStyleProperty, value); }
    }

    public static readonly DependencyProperty DimensionButtonStyleProperty =
        DependencyProperty.Register("DimensionButtonStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public Style MeasureCheckboxStyle
    {
        get { return (Style)GetValue(MeasureCheckboxStyleProperty); }
        set { SetValue(MeasureCheckboxStyleProperty, value); }
    }

    public static readonly DependencyProperty MeasureCheckboxStyleProperty =
        DependencyProperty.Register("MeasureCheckboxStyle", typeof(Style), typeof(LeaderPivotControl), new PropertyMetadata(null));

    #endregion


    #region Commands

    public ICommand ReloadDataCommand
    {
        get { return (ICommand)GetValue(ReloadDataCommandProperty); }
        set { SetValue(ReloadDataCommandProperty, value); }
    }

    public static readonly DependencyProperty ReloadDataCommandProperty =
        DependencyProperty.Register("command", typeof(ICommand), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public ICommand DimensionEventCommand
    {
        get { return (ICommand)GetValue(DimensionEventCommandProperty); }
        set { SetValue(DimensionEventCommandProperty, value); }
    }

    public static readonly DependencyProperty DimensionEventCommandProperty =
        DependencyProperty.Register("DimensionEventCommand", typeof(ICommand), typeof(LeaderPivotControl), new PropertyMetadata(null));



    public IRelayCommand ToggleMeasureEnabledCommand
    {
        get { return (IRelayCommand)GetValue(ToggleMeasureEnabledCommandProperty); }
        set { SetValue(ToggleMeasureEnabledCommandProperty, value); }
    }

    public static readonly DependencyProperty ToggleMeasureEnabledCommandProperty =
        DependencyProperty.Register("ToggleMeasureEnabledCommand", typeof(IRelayCommand), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public ICommand DragItemsStartingCommand
    {
        get { return (ICommand)GetValue(DragItemsStartingCommandProperty); }
        set { SetValue(DragItemsStartingCommandProperty, value); }
    }

    public static readonly DependencyProperty DragItemsStartingCommandProperty =
        DependencyProperty.Register("DragItemsStartingCommand", typeof(ICommand), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public ICommand DragOverCommand
    {
        get { return (ICommand)GetValue(DragOverCommandProperty); }
        set { SetValue(DragOverCommandProperty, value); }
    }

    public static readonly DependencyProperty DragOverCommandProperty =
        DependencyProperty.Register("DragOverCommand", typeof(ICommand), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public ICommand DragEnterCommand
    {
        get { return (ICommand)GetValue(DragEnterCommandProperty); }
        set { SetValue(DragEnterCommandProperty, value); }
    }

    public static readonly DependencyProperty DragEnterCommandProperty =
        DependencyProperty.Register("DragEnterCommand", typeof(ICommand), typeof(LeaderPivotControl), new PropertyMetadata(null));


    public ICommand DropCommand
    {
        get { return (ICommand)GetValue(DropCommandProperty); }
        set { SetValue(DropCommandProperty, value); }
    }

    public static readonly DependencyProperty DropCommandProperty =
        DependencyProperty.Register("DropCommand", typeof(ICommand), typeof(LeaderPivotControl), new PropertyMetadata(null));


    #endregion

    private byte[,]? table;
    private Grid grid;
    private ICommand toggleNodeExpansionCommand;
    private bool IsLoaded;

    public LeaderPivotControl()
    {
        this.DefaultStyleKey = typeof(LeaderPivotControl);
        ReloadDataCommand = new AsyncRelayCommand(() => BuildGrid(null));
        DimensionEventCommand = new AsyncRelayCommand<object>(DimensionEventCommandHandler);
        toggleNodeExpansionCommand = new AsyncRelayCommand<string>(x => BuildGrid(x));
        DragItemsStartingCommand = new RelayCommand<DragItemsStartingEventArgs>(DragItemsStartingCommandHandler);
        DragOverCommand = new RelayCommand<DragEventArgs>(DragOverCommandHandler);
        DragEnterCommand = new RelayCommand<DragEventArgs>(DragEnterCommandHandler);
        DropCommand = new RelayCommand<DragEventArgs>(DropCommandHandler);
        ToggleMeasureEnabledCommand = new AsyncRelayCommand<object>(ToggleMeasureEnabledCommandHandler, (o) => {

            // The intent of this logic is to require at least one measure to be selected.
            // Therefore, the checkbox should be enabled if any of the following is true:
            // 1.) Checkbox is unchecked - user should always be able to select (check) a measure.
            // 2.) More than one checkbox is checked.

            Selectable<Measure> m = o as Selectable<Measure>;
            
            if (m is null)
                return false;

            bool canExecute = !m.IsSelected || ViewBuilder.Measures.Count(x => x.Item.IsEnabled) > 1;
            return canExecute;
        });

        Loaded += OnLoaded;
    }

    protected async void OnLoaded(object sender, RoutedEventArgs e)
    { 
        IsLoaded = true;
        Loaded -= OnLoaded;
        await BuildGrid(null);
    }

    protected override void OnApplyTemplate()
    {
        grid = (Grid)GetTemplateChild("PART_Grid");
        base.OnApplyTemplate();
    }

    public async Task BuildGrid(string? nodeID)
    {
        if(!IsLoaded)
            return;

        // Row span takes precidence over column span.
        // If a cell spans multiple rows, cells in the second and subsequent rows are pushed to the right - not down.
        // A cell is never pushed down to a lower row - it is pushed to the right.  Therefore a cells row index in the matrix is
        // always the same as it's row number in the grid.
        IsBusy = true;
        await ViewBuilder.BuildMatrix(nodeID);
        grid.Children.Clear();
        grid.RowDefinitions.Clear();
        grid.ColumnDefinitions.Clear();
        int rowCount = ViewBuilder.Matrix.Rows.Count;
        int columnCount = ViewBuilder.Matrix.Rows[0].Cells.Sum(x => x.ColSpan);

        table = new byte[rowCount, columnCount];

        for (int j = 0; j < columnCount; j++)
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

        for (int i = 0; i < rowCount; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            int columnIndex = 0;

            for (int j = 0; j < ViewBuilder.Matrix.Rows[i].Cells.Count; j++)
            {
                MatrixCell? mCell = ViewBuilder.Matrix.Rows[i].Cells[j];

                BaseCell cell = mCell.CellType switch
                {
                    CellType.Measure => new MeasureCell(),
                    CellType.Total => new TotalCell(),
                    CellType.GrandTotal => new GrandTotalCell(),
                    CellType.GroupHeader => new GroupHeaderCell { NodeID = mCell.NodeID, IsExpanded = mCell.IsExpanded, CanToggleExpansion = mCell.CanToggleExapansion, ToggleNodeExpansionCommand = toggleNodeExpansionCommand },
                    CellType.TotalHeader => new TotalHeaderCell(),
                    CellType.GrandTotalHeader => new GrandTotalHeaderCell(),
                    CellType.MeasureTotalLabel => new MeasureTotalLabelCell(),
                    CellType.MeasureLabel when i == 0 && j == 0 => new MeasureContainerCell() { Measures = ViewBuilder.Measures, Command = DimensionEventCommand },
                    CellType.MeasureLabel when i == 0 && j == 1 => new DimensionContainerCell { Dimensions = ViewBuilder.ColumnDimensions, IsRows = false },
                    CellType.MeasureLabel => new MeasureLabelCell(),
                    _ => throw new NotImplementedException($"Cell type not recognised: {mCell.CellType}.")
                };    

                Style? style = cell switch
                {
                    MeasureCell => MeasureCellStyle,
                    TotalCell => TotalCellStyle,
                    GrandTotalCell => GrandTotalCellStyle,
                    GroupHeaderCell => GroupHeaderCellStyle,
                    TotalHeaderCell => TotalHeaderCellStyle,
                    GrandTotalHeaderCell => GrandTotalHeaderCellStyle,
                    MeasureTotalLabelCell => MeasureTotalLabelCellStyle,
                    MeasureContainerCell => MeasureContainerCellStyle,
                    DimensionContainerCell => DimensionContainerCellStyle,
                    MeasureLabelCell => MeasureLabelCellStyle,
                    _ => throw new NotImplementedException($"Object type not recognised: {cell.GetType()}.")
                };

                if (style != null)
                    cell.Style = style;

                CellContainer container = new CellContainer();

                container.RowSpan = mCell.RowSpan;
                container.ColSpan = mCell.ColSpan;
                container.Content = cell;
                cell.Content = mCell.Value?.ToString();
                columnIndex = IncrementCol(i, columnIndex, container);
                Grid.SetRow(container, i);
                Grid.SetRowSpan(container, container.RowSpan);
                Grid.SetColumn(container, columnIndex);
                Grid.SetColumnSpan(container, container.ColSpan);
                grid.Children.Add(container);
            }
        }
        IsBusy = false;
    }

    public async Task DimensionEventCommandHandler(object o)
    {
        // https://github.com/microsoft/microsoft-ui-xaml/issues/7633
        DimensionEventArgs dimensionEvent = o as DimensionEventArgs;

        if (dimensionEvent == null)
            throw new ArgumentNullException(nameof(dimensionEvent));
        if (dimensionEvent.Action == DimensionAction.NoOp)
            return;

        Dimension dimension = ViewBuilder.Dimensions.First(x => x.DisplayValue == dimensionEvent.DimensionID);

        var x = dimensionEvent.Action switch
        {
            DimensionAction.SortAscending => dimension.IsAscending = true,
            DimensionAction.SortDescending => dimension.IsAscending = false,
            DimensionAction.Hide => dimension.IsEnabled = false,
            DimensionAction.UnHide => dimension.IsEnabled = true,
            _ => throw new Exception($"DimensionAction not recognised: {dimensionEvent.Action}"),
        };
        await BuildGrid(null);
    }

    private int IncrementCol(int rowIndex, int colIndex, CellContainer cell)
    {
        while (table[rowIndex, colIndex] == 1)
            colIndex++;

        for (int r = rowIndex; r < rowIndex + cell.RowSpan; r++)
            for (int c = colIndex; c < colIndex + cell.ColSpan; c++)
                table[r, c] = 1;

        return colIndex;
    }


    private async Task ToggleMeasureEnabledCommandHandler(object o)
    {
        Selectable<Measure> measure = o as Selectable<Measure>;

        measure.Item.IsEnabled = measure.IsSelected;
        ToggleMeasureEnabledCommand.NotifyCanExecuteChanged();
        await BuildGrid(null);
    }


    private void DragItemsStartingCommandHandler(DragItemsStartingEventArgs e)
    {
        e.Data.RequestedOperation = DataPackageOperation.Move;
        Dimension sourceItem = e.Items[0] as Dimension;
        IList<Dimension> dimensions = sourceItem.IsRow ? ViewBuilder.RowDimensions : ViewBuilder.ColumnDimensions;
        e.Data.Properties.Add("Dimension", sourceItem);
        

        // If source dimensions has exactly one dimension, count dimensions on cross axis.
        // If cross axis has exactly one dimension allow the drag and swap axis for each 
        // dimension on drop. 
        // Otherwise do not allow the drag if source dimensions has only one dimension.

        if (dimensions.Count == 1)
        {
            IList<Dimension> crossAxisDimensions = sourceItem.IsRow ? ViewBuilder.ColumnDimensions : ViewBuilder.RowDimensions;

            if (crossAxisDimensions.Count > 1)
                e.Cancel = true;
        }
    }

    private void DragOverCommandHandler(DragEventArgs e)
    {
        e.AcceptedOperation = DataPackageOperation.Move;
    }

    private void DragEnterCommandHandler(DragEventArgs e)
    {
        e.DragUIOverride.IsGlyphVisible = false;
        
    }

    private async void DropCommandHandler(DragEventArgs e)
    {
        // https://github.com/dotnet/maui/issues/13770
        ListView dropTarget = e.OriginalSource as ListView;
        Dimension sourceDimension = e.Data.Properties["Dimension"] as Dimension;
        DragOperationDeferral def = e.GetDeferral();
        Windows.Foundation.Point pos = e.GetPosition(dropTarget.ItemsPanelRoot);
        int index = 0;
        
        // Get a reference to the first item in the ListView
        ListViewItem sampleItem = (ListViewItem)dropTarget.ContainerFromIndex(0);

        // Adjust itemHeight for margins
        double itemWidth = sampleItem.ActualWidth + sampleItem.Margin.Left + sampleItem.Margin.Right;

        // Find index based on dividing number of items by width of each item
        index = Math.Min(dropTarget.Items.Count - 1, (int)(pos.X / itemWidth));

        // Find the item being dropped on top of.
        ListViewItem targetItem = (ListViewItem)dropTarget.ContainerFromIndex(index);

        // If the drop position is more than half-way down the item being dropped on
        //      top of, increment the insertion index so the dropped item is inserted
        //      below instead of above the item being dropped on top of.
        Windows.Foundation.Point positionInItem = e.GetPosition(targetItem);
        
        if (positionInItem.X > itemWidth / 2)
            index++;

        // Don't go out of bounds
        index = Math.Min(dropTarget.Items.Count - 1, index);
        
        IList<Dimension> sourceDimensions = sourceDimension.IsRow ? ViewBuilder.RowDimensions : ViewBuilder.ColumnDimensions;
        IList<Dimension> crossAxisDimensins = sourceDimension.IsRow ? ViewBuilder.ColumnDimensions : ViewBuilder.RowDimensions;
        Dimension targetDimension = targetItem.Content as Dimension;
        
        
        
        if (sourceDimension.IsRow != targetDimension.IsRow)
        {
            // we are dragging across axis

            // if each axis has only one dimension, swap the remaining dimension
            if (crossAxisDimensins.Count == 1 && sourceDimensions.Count == 1)
            {
                Dimension otherDimension = crossAxisDimensins.First();
                crossAxisDimensins.Remove(otherDimension);
                sourceDimensions.Add(otherDimension);
                otherDimension.IsRow = !otherDimension.IsRow;
            }
            
            sourceDimensions.Remove(sourceDimension);
            crossAxisDimensins.Add(sourceDimension);
            sourceDimension.IsRow = !sourceDimension.IsRow;
            sourceDimensions = crossAxisDimensins;
        }
        
        sourceDimension.Sequence = index;
        
        foreach (Dimension d in sourceDimensions.Where(x => x != sourceDimension && x.Sequence >= sourceDimension.Sequence))
            d.Sequence++;

        e.AcceptedOperation = DataPackageOperation.Move;
        def.Complete();
        await BuildGrid(null);
    }
}
