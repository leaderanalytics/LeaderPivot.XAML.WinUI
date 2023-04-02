using CommunityToolkit.WinUI.UI;
using System.Windows.Input;

namespace LeaderAnalytics.LeaderPivot.XAML.WinUI;

public partial class CellContainer : ContentControl
{
    public int RowSpan { get; set; } = 1;
    public int ColSpan { get; set; } = 1;

    public CellContainer() => DefaultStyleKey = typeof(CellContainer);
}

public abstract partial class BaseCell : ContentControl, INotifyPropertyChanged
{
    public Style ContentStyle
    {
        get { return (Style)GetValue(ContentStyleProperty); }
        set { SetValue(ContentStyleProperty, value); }
    }

    public static readonly DependencyProperty ContentStyleProperty =
        DependencyProperty.Register("ContentStyle", typeof(Style), typeof(BaseCell), new PropertyMetadata(null));

    public BaseCell() => DefaultStyleKey = typeof(BaseCell);

    #region INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler? PropertyChanged;
    public void RaisePropertyChanged([CallerMemberNameAttribute] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public void SetProp<T>(ref T prop, T value, [CallerMemberNameAttribute] string propertyName = "")
    {
        if (!Object.Equals(prop, value))
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }
    }
    #endregion
}

public partial class DimensionContainerCell : BaseCell
{
    public IList<Dimension> Dimensions
    {
        get { return (IList<Dimension>)GetValue(DimensionsProperty); }
        set { SetValue(DimensionsProperty, value); }
    }

    public static readonly DependencyProperty DimensionsProperty =
        DependencyProperty.Register("Dimensions", typeof(IList<Dimension>), typeof(DimensionContainerCell), new PropertyMetadata(null,
            (s, e) => ((DimensionContainerCell)s).RaisePropertyChanged(nameof(DimensionContainerCell.CanHide))));

    public bool IsRows
    {
        get { return (bool)GetValue(IsRowsProperty); }
        set { SetValue(IsRowsProperty, value); }
    }

    public static readonly DependencyProperty IsRowsProperty =
        DependencyProperty.Register("IsRows", typeof(bool), typeof(DimensionContainerCell), new PropertyMetadata(false));


    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(DimensionContainerCell), new PropertyMetadata(null));



    public bool CanHide => (Dimensions?.Count ?? 0) > 1;


    public int MaxDimensions { get; set; }


    public DimensionContainerCell()
    {
        DefaultStyleKey = typeof(DimensionContainerCell);
    }
}

public partial class GroupHeaderCell : BaseCell
{
    public bool IsExpanded
    {
        get { return (bool)GetValue(IsExpandedProperty); }
        set { SetValue(IsExpandedProperty, value); }
    }

    public static readonly DependencyProperty IsExpandedProperty =
        DependencyProperty.Register("IsExpanded", typeof(bool), typeof(GroupHeaderCell), new PropertyMetadata(true));


    public bool CanToggleExpansion
    {
        get { return (bool)GetValue(CanToggleExpansionProperty); }
        set { SetValue(CanToggleExpansionProperty, value); }
    }
    
    public static readonly DependencyProperty CanToggleExpansionProperty =
        DependencyProperty.Register("CanToggleExpansion", typeof(bool), typeof(GroupHeaderCell), new PropertyMetadata(true));


    public string NodeID
    {
        get { return (string)GetValue(NodeIDProperty); }
        set { SetValue(NodeIDProperty, value); }
    }

    public static readonly DependencyProperty NodeIDProperty =
        DependencyProperty.Register("NodeID", typeof(string), typeof(GroupHeaderCell), new PropertyMetadata(null));


    public ICommand ToggleNodeExpansionCommand
    {
        get { return (ICommand)GetValue(ToggleNodeExpansionCommandProperty); }
        set { SetValue(ToggleNodeExpansionCommandProperty, value); }
    }

    public static readonly DependencyProperty ToggleNodeExpansionCommandProperty =
        DependencyProperty.Register("ToggleNodeExpansionCommand", typeof(ICommand), typeof(GroupHeaderCell), new PropertyMetadata(null));


    public GroupHeaderCell() => DefaultStyleKey = typeof(GroupHeaderCell);
    
}

public partial class GrandTotalHeaderCell : BaseCell 
{
    public GrandTotalHeaderCell() => DefaultStyleKey = typeof(GrandTotalHeaderCell);
}

public partial  class GrandTotalCell : BaseCell
{
    public GrandTotalCell() => DefaultStyleKey = typeof(GrandTotalCell);
}

public partial  class MeasureCell : BaseCell 
{
    public MeasureCell() => DefaultStyleKey = typeof(MeasureCell);
}

public partial class MeasureContainerCell : BaseCell
{


    public IList<Selectable<Measure>> Measures
    {
        get { return (IList<Selectable<Measure>>)GetValue(MeasuresProperty); }
        set { SetValue(MeasuresProperty, value); }
    }

    public static readonly DependencyProperty MeasuresProperty =
        DependencyProperty.Register("Measures", typeof(IList<Selectable<Measure>>), typeof(MeasureContainerCell), new PropertyMetadata(null));


    public Style ReloadButtonStyle
    {
        get { return (Style)GetValue(ReloadButtonStyleProperty); }
        set { SetValue(ReloadButtonStyleProperty, value); }
    }

    public static readonly DependencyProperty ReloadButtonStyleProperty =
        DependencyProperty.Register("ReloadButtonStyle", typeof(Style), typeof(MeasureContainerCell), new PropertyMetadata(null));

    public Style MeasureCheckBoxStyle
    {
        get { return (Style)GetValue(MeasureCheckBoxStyleProperty); }
        set { SetValue(MeasureCheckBoxStyleProperty, value); }
    }

    public static readonly DependencyProperty MeasureCheckBoxStyleProperty =
        DependencyProperty.Register("MeasureCheckBoxStyle", typeof(Style), typeof(MeasureContainerCell), new PropertyMetadata(null));


    public Style HiddenDimensionsListBoxStyle
    {
        get { return (Style)GetValue(HiddenDimensionsListBoxStyleProperty); }
        set { SetValue(HiddenDimensionsListBoxStyleProperty, value); }
    }

    public static readonly DependencyProperty HiddenDimensionsListBoxStyleProperty =
        DependencyProperty.Register("HiddenDimensionsListBoxStyle", typeof(Style), typeof(MeasureContainerCell), new PropertyMetadata(null));

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(MeasureContainerCell), new PropertyMetadata(null));


    public Dimension SelectedHiddenDimension
    {
        get { return (Dimension)GetValue(SelectedHiddenDimensionProperty); }
        set { SetValue(SelectedHiddenDimensionProperty, value); }
    }

    public static readonly DependencyProperty SelectedHiddenDimensionProperty =
        DependencyProperty.Register("SelectedHiddenDimension", typeof(Dimension), typeof(MeasureContainerCell), new PropertyMetadata(null,(s,e) => {
                // https://github.com/microsoft/XamlBehaviors/issues/240
                // Can't handle combobox selected item command so fire the command when selected item changes
            ((MeasureContainerCell)s).Command?.Execute(new DimensionEventArgs { DimensionID = ((Dimension)e.NewValue).DisplayValue, Action = DimensionAction.UnHide });
        }));


    public MeasureContainerCell() => DefaultStyleKey = typeof(MeasureContainerCell);
}

public partial class MeasureLabelCell : BaseCell 
{
    public MeasureLabelCell() => DefaultStyleKey = typeof(MeasureLabelCell);
}

public partial class MeasureTotalLabelCell : BaseCell
{
    public MeasureTotalLabelCell() => DefaultStyleKey = typeof(MeasureTotalLabelCell);
}

public partial class TotalCell : BaseCell 
{
    public TotalCell() => DefaultStyleKey = typeof(TotalCell);
}

public partial class TotalHeaderCell : BaseCell 
{
    public TotalHeaderCell() => DefaultStyleKey = typeof(TotalHeaderCell);
}
