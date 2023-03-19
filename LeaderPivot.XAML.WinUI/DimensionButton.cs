namespace LeaderAnalytics.LeaderPivot.XAML.WinUI;

public partial class DimensionButton : ContentControl
{
    public ICommand MenuCommand
    {
        get { return (ICommand)GetValue(MenuCommandProperty); }
        set { SetValue(MenuCommandProperty, value); }
    }

    public static readonly DependencyProperty MenuCommandProperty =
        DependencyProperty.Register("MenuCommand", typeof(ICommand), typeof(DimensionButton), new PropertyMetadata(null));


    public object CommandParameter
    {
        get { return (object)GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }

    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register("CommandParameter", typeof(object), typeof(DimensionButton), new PropertyMetadata(null));


    public Dimension Dimension
    {
        get { return (Dimension)GetValue(DimensionProperty); }
        set { SetValue(DimensionProperty, value); }
    }

    public static readonly DependencyProperty DimensionProperty =
        DependencyProperty.Register("Dimension", typeof(Dimension), typeof(DimensionButton), new PropertyMetadata(null));


    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(DimensionButton), new PropertyMetadata(null));



    public Style ButtonStyle
    {
        get { return (Style)GetValue(ButtonStyleProperty); }
        set { SetValue(ButtonStyleProperty, value); }
    }

    public static readonly DependencyProperty ButtonStyleProperty =
        DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(DropDownButton), new PropertyMetadata(null));


    public Style ListBoxStyle
    {
        get { return (Style)GetValue(ListBoxStyleProperty); }
        set { SetValue(ListBoxStyleProperty, value); }
    }

    public static readonly DependencyProperty ListBoxStyleProperty =
        DependencyProperty.Register("ListBoxStyle", typeof(Style), typeof(DropDownButton), new PropertyMetadata(null));



    public Style ListBoxItemStyle
    {
        get { return (Style)GetValue(ListBoxItemStyleProperty); }
        set { SetValue(ListBoxItemStyleProperty, value); }
    }

    public static readonly DependencyProperty ListBoxItemStyleProperty =
      DependencyProperty.Register("ListBoxItemStyle", typeof(Style), typeof(DropDownButton), new PropertyMetadata(null));


    public DimensionButton()
    {
        DefaultStyleKey = typeof(DimensionButton);
        MenuCommand = new RelayCommand<DimensionAction>(x  => Command?.Execute(new DimensionEventArgs {DimensionID = Dimension.ID, Action = x}));
    }
}
