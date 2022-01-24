using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет значок, в качестве содержимого которого используется глиф из ресурса SymbolThemeFontFamily.
/// </summary>
public sealed class SymbolIcon : IconElement
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Symbol"/>.
    /// </summary>
    public static readonly DependencyProperty SymbolProperty =
        DependencyProperty.Register("Symbol", typeof(Symbol), typeof(SymbolIcon),
            new FrameworkPropertyMetadata(Symbol.Emoji, OnSymbolChanged));

    private readonly TextBlock renderer;
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует статические данные класса <seealso cref="SymbolIcon"/>.
    /// </summary>
    static SymbolIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SymbolIcon),
            new FrameworkPropertyMetadata(typeof(SymbolIcon)));
        ForegroundProperty.OverrideMetadata(typeof(SymbolIcon),
            new FrameworkPropertyMetadata(OnForegroundChanged));
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="SymbolIcon"/>.
    /// </summary>
    public SymbolIcon()
    {
        renderer = new();
        renderer.Style = null;
        renderer.HorizontalAlignment = HorizontalAlignment.Stretch;
        renderer.VerticalAlignment = VerticalAlignment.Center;
        renderer.TextAlignment = TextAlignment.Center;
        renderer.Foreground = Foreground;
        renderer.FontFamily = new FontFamily("Segoe Fluent Icons");
        renderer.FontSize = 16.0d;
        renderer.FontStyle = FontStyles.Normal;
        renderer.FontWeight = FontWeights.Normal;
        renderer.Text = ConvertToString(Symbol);
        // Добавьте дочерний элемент управления.
        Children.Add(renderer);
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="SymbolIcon"/>, используя указанный символ.
    /// </summary>
    /// <param name="symbol">
    /// Именованная константа перечисления, определяющая используемый глиф Segoe MDL2 Assets.
    /// </param>
    public SymbolIcon(Symbol symbol) : this()
    {
        Symbol = symbol;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает или задает глиф Segoe MDL2 Assets, используемый в качестве содержимого значка.
    /// </summary>
    /// <value>
    /// Именованная константа нумерации, определяющая используемый глиф Segoe MDL2 Assets.
    /// </value>
    [Category("Common Properties")]
    [Description("Получает или задает глиф Segoe MDL2 Assets, используемый в качестве содержимого значка.")]
    [Bindable(true)]
    public Symbol Symbol
    {
        get => (Symbol)GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }
    #endregion

    #region Methods
    private static void OnForegroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        SymbolIcon symbolIcon = (SymbolIcon)sender;
        symbolIcon.renderer.SetValue(TextBlock.ForegroundProperty, args.NewValue);
    }

    private static void OnSymbolChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        SymbolIcon symbolIcon = (SymbolIcon)sender;
        symbolIcon.renderer.SetValue(TextBlock.TextProperty, ConvertToString((Symbol)args.NewValue));
    }

    private static string ConvertToString(Symbol symbol)
    {
        return char.ConvertFromUtf32((int)symbol);
    }
    #endregion
}
