using System.ComponentModel;
using System.Windows.Media;

namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет источник значков, в котором используется глиф из указанного шрифта.
/// </summary>
public sealed class FontIconSource : IconSource
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="FontFamily"/>.
    /// </summary>
    public static readonly DependencyProperty FontFamilyProperty =
        DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(FontIconSource),
            new PropertyMetadata(new FontFamily("Segoe Fluent Icons")));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="FontSize"/>.
    /// </summary>
    public static readonly DependencyProperty FontSizeProperty =
        DependencyProperty.Register("FontSize", typeof(double), typeof(FontIconSource),
            new PropertyMetadata(16.0d));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="FontStyle"/>.
    /// </summary>
    public static readonly DependencyProperty FontStyleProperty =
        DependencyProperty.Register("FontStyle", typeof(FontStyle), typeof(FontIconSource),
            new PropertyMetadata(FontStyles.Normal));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="FontWeight"/>.
    /// </summary>
    public static readonly DependencyProperty FontWeightProperty =
        DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(FontIconSource),
            new PropertyMetadata(FontWeights.Normal));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Glyph"/>.
    /// </summary>
    public static readonly DependencyProperty GlyphProperty =
        DependencyProperty.Register("Glyph", typeof(string), typeof(FontIconSource),
            new PropertyMetadata("\uE11D"));
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="FontIconSource"/>.
    /// </summary>
    public FontIconSource()
    {
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает или задает шрифт, используемый при отображении глифа значка.
    /// </summary>
    /// <value>
    /// Шрифт, используемый при отображении глифа значка.
    /// </value>
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
    [TypeConverter(typeof(FontSizeConverter))]
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
    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Создает новый экземпляр класса <seealso cref="FontIcon"/>.
    /// </summary>
    /// <returns>
    /// Значок пользовательского интерфейса.
    /// </returns>
    protected override IconElement CreateIconElementCore()
    {
        FontIcon fontIcon = new();
        fontIcon.Foreground = Foreground;
        fontIcon.FontFamily = FontFamily;
        fontIcon.FontSize = FontSize;
        fontIcon.FontStyle = FontStyle;
        fontIcon.FontWeight = FontWeight;
        fontIcon.Glyph = Glyph;
        return fontIcon;
    }

    /// <summary>
    /// Сопоставляет свойства <seealso cref="FontIconSource"/> со свойствами <seealso cref="FontIcon"/>.
    /// </summary>
    /// <param name="iconSourceProperty">
    /// Идентификатор свойства зависимостей <seealso cref="FontIconSource"/> для сопоставления со свойствами <seealso cref="FontIcon"/>.
    /// </param>
    /// <returns>
    /// Объект, обеспечивающий поддержку выражений значений, привязки данных, анимации и уведомлений об изменении свойств.
    /// </returns>
    protected override DependencyProperty GetIconElementPropertyCore(DependencyProperty iconSourceProperty)
    {
        if (iconSourceProperty == FontFamilyProperty)
        {
            return FontIcon.FontFamilyProperty;
        }
        else if (iconSourceProperty == FontSizeProperty)
        {
            return FontIcon.FontSizeProperty;
        }
        else if (iconSourceProperty == FontStyleProperty)
        {
            return FontIcon.FontStyleProperty;
        }
        else if (iconSourceProperty == FontWeightProperty)
        {
            return FontIcon.FontWeightProperty;
        }
        else if (iconSourceProperty == GlyphProperty)
        {
            return FontIcon.GlyphProperty;
        }

        return base.GetIconElementPropertyCore(iconSourceProperty);
    }
    #endregion
}
