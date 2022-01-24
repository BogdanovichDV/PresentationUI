using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет значок, который использует глиф из указанного шрифта.
/// </summary>
public sealed class FontIcon : IconElement
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="FontFamily"/>.
    /// </summary>
    public static readonly DependencyProperty FontFamilyProperty =
        DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(FontIcon),
            new FrameworkPropertyMetadata(new FontFamily("Segoe Fluent Icons"), OnFontFamilyChanged));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="FontSize"/>.
    /// </summary>
    public static readonly DependencyProperty FontSizeProperty =
        DependencyProperty.Register("FontSize", typeof(double), typeof(FontIcon),
            new FrameworkPropertyMetadata(16.0d, OnFontSizeChanged));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="FontStyle"/>.
    /// </summary>
    public static readonly DependencyProperty FontStyleProperty =
        DependencyProperty.Register("FontStyle", typeof(FontStyle), typeof(FontIcon),
            new FrameworkPropertyMetadata(FontStyles.Normal, OnFontStyleChanged));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="FontWeight"/>.
    /// </summary>
    public static readonly DependencyProperty FontWeightProperty =
        DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(FontIcon),
            new FrameworkPropertyMetadata(FontWeights.Normal, OnFontWeightChanged));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Glyph"/>.
    /// </summary>
    public static readonly DependencyProperty GlyphProperty =
        DependencyProperty.Register("Glyph", typeof(string), typeof(FontIcon),
            new FrameworkPropertyMetadata("\uE11D", OnGlyphChanged));

    private readonly TextBlock renderer;
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует статические данные класса <seealso cref="FontIcon"/>.
    /// </summary>
    static FontIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FontIcon),
            new FrameworkPropertyMetadata(typeof(FontIcon)));
        ForegroundProperty.OverrideMetadata(typeof(FontIcon),
            new FrameworkPropertyMetadata(OnForegroundChanged));
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="FontIcon"/>.
    /// </summary>
    public FontIcon()
    {
        renderer = new();
        renderer.Style = null;
        renderer.HorizontalAlignment = HorizontalAlignment.Stretch;
        renderer.VerticalAlignment = VerticalAlignment.Center;
        renderer.TextAlignment = TextAlignment.Center;
        renderer.Foreground = Foreground;
        renderer.FontFamily = FontFamily;
        renderer.FontSize = FontSize;
        renderer.FontStyle = FontStyle;
        renderer.FontWeight = FontWeight;
        renderer.Text = Glyph;
        // Добавьте дочерний элемент управления.
        Children.Add(renderer);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает или задает шрифт, используемый при отображении глифа значка.
    /// </summary>
    /// <value>
    /// Шрифт, используемый при отображении глифа значка.
    /// </value>
    [Bindable(true)]
    [Category("Appearance")]
    [Localizability(LocalizationCategory.Font)]
    [Description("Получает или задает шрифт, используемый при отображении глифа значка.")]
    public FontFamily FontFamily
    {
        get => (FontFamily)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }

    /// <summary>
    /// Получает или задает размер глифа значка.
    /// </summary>
    /// <value>
    /// Положительное значение, указывающее размер шрифта в пикселях.
    /// </value>
    [Bindable(true)]
    [Category("Appearance")]
    [Localizability(LocalizationCategory.Font)]
    [TypeConverter(typeof(FontSizeConverter))]
    [Description("Получает или задает размер глифа значка.")]
    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    /// <summary>
    /// Получает или задает начертание шрифта для глифа значка.
    /// </summary>
    /// <value>
    /// Именованная константа перечисления, указывающая стиль, в котором отображается значок глифа.
    /// Значение по умолчанию - <seealso cref="FontStretches.Normal"/>.
    /// </value>
    [Bindable(true)]
    [Category("Appearance")]
    [Description("Получает или задает начертание шрифта для глифа значка.")]
    public FontStyle FontStyle
    {
        get => (FontStyle)GetValue(FontStyleProperty);
        set => SetValue(FontStyleProperty, value);
    }

    /// <summary>
    /// Получает или задает толщину глифа значка.
    /// </summary>
    /// <value>
    /// Значение, задающее толщину глифа значка. Значение по умолчанию - <seealso cref="FontWeights.Normal"/>.
    /// </value>
    [Bindable(true)]
    [Category("Appearance")]
    [Description("Получает или задает толщину глифа значка.")]
    public FontWeight FontWeight
    {
        get => (FontWeight)GetValue(FontWeightProperty);
        set => SetValue(FontWeightProperty, value);
    }

    /// <summary>
    /// Получает или задает код символа, определяющий глиф значка.
    /// </summary>
    /// <value>
    /// Шестнадцатеричный код символа для глифа значка.
    /// </value>
    [Category("Common Properties")]
    [Description("Получает или задает код символа, определяющий глиф значка.")]
    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }
    #endregion

    #region Methods
    private static void OnForegroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        FontIcon fontIcon = (FontIcon)sender;
        fontIcon.renderer.SetValue(TextBlock.ForegroundProperty, args.NewValue);
    }

    private static void OnFontFamilyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        FontIcon fontIcon = (FontIcon)sender;
        fontIcon.renderer.SetValue(TextBlock.FontFamilyProperty, args.NewValue);
    }

    private static void OnFontSizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        FontIcon fontIcon = (FontIcon)sender;
        fontIcon.renderer.SetValue(TextBlock.FontSizeProperty, args.NewValue);
    }

    private static void OnFontStyleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        FontIcon fontIcon = (FontIcon)sender;
        fontIcon.renderer.SetValue(TextBlock.FontStyleProperty, args.NewValue);
    }

    private static void OnFontWeightChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        FontIcon fontIcon = (FontIcon)sender;
        fontIcon.renderer.SetValue(TextBlock.FontWeightProperty, args.NewValue);
    }

    private static void OnGlyphChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        FontIcon fontIcon = (FontIcon)sender;
        fontIcon.renderer.SetValue(TextBlock.TextProperty, args.NewValue);
    }
    #endregion
}
