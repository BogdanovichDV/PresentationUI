namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет источник значка, который использует растровое изображение в качестве своего содержимого.
/// </summary>
public sealed class BitmapIconSource : IconSource
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="ShowAsMonochrome"/>.
    /// </summary>
    public static readonly DependencyProperty ShowAsMonochromeProperties =
        DependencyProperty.Register("ShowAsMonochrome", typeof(bool), typeof(BitmapIconSource),
            new PropertyMetadata(false));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="UriSource"/>.
    /// </summary>
    public static readonly DependencyProperty UriSourceProperty =
        DependencyProperty.Register("UriSource", typeof(Uri), typeof(BitmapIconSource),
            new PropertyMetadata(null));
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="BitmapIconSource"/>.
    /// </summary>
    public BitmapIconSource()
    {
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает или задает значение, указывающее, отображается ли растровое изображение в одном цвете.
    /// </summary>
    /// <value>
    /// Значение <see langword="true"/>, чтобы растровое изображение отображалось одним цветом;
    /// <see langword="false"/>, чтобы растровое изображение отображалось в полном цвете.
    /// Значение по умолчанию - <see langword="false"/>.
    /// </value>
    public bool ShowAsMonochrome
    {
        get => (bool)GetValue(ShowAsMonochromeProperties);
        set => SetValue(ShowAsMonochromeProperties, value);
    }

    /// <summary>
    /// Получает или задает универсальный идентификатор ресурса (URI)
    /// растрового изображения для использования в качестве содержимого значка.
    /// </summary>
    /// <value>
    /// <seealso cref="Uri"/> растрового изображения для использования в качестве содержимого значка.
    /// Значение по умолчанию - <see langword="null"/>.
    /// </value>
    public Uri UriSource
    {
        get => (Uri)GetValue(UriSourceProperty);
        set => SetValue(UriSourceProperty, value);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Создает новый экземпляр класса <seealso cref="BitmapIcon"/>.
    /// </summary>
    /// <returns>
    /// Значок пользовательского интерфейса.
    /// </returns>
    protected override IconElement CreateIconElementCore()
    {
        BitmapIcon bitmapIcon = new();
        bitmapIcon.Foreground = Foreground;
        bitmapIcon.UriSource = UriSource;
        bitmapIcon.ShowAsMonochrome = ShowAsMonochrome;
        return bitmapIcon;
    }

    /// <summary>
    /// Сопоставляет свойства <seealso cref="BitmapIconSource"/> со свойствами <seealso cref="BitmapIcon"/>.
    /// </summary>
    /// <param name="iconSourceProperty">
    /// Идентификатор свойства зависимостей <seealso cref="BitmapIconSource"/> для сопоставления со свойствами <seealso cref="BitmapIcon"/>.
    /// </param>
    /// <returns>
    /// Объект, обеспечивающий поддержку выражений значений, привязки данных, анимации и уведомлений об изменении свойств.
    /// </returns>
    protected override DependencyProperty GetIconElementPropertyCore(DependencyProperty iconSourceProperty)
    {
        if (iconSourceProperty == ShowAsMonochromeProperties)
        {
            return BitmapIcon.ShowAsMonochromeProperties;
        }
        else if (iconSourceProperty == UriSourceProperty)
        {
            return BitmapIcon.UriSourceProperty;
        }

        return base.GetIconElementPropertyCore(iconSourceProperty);
    }
    #endregion
}
