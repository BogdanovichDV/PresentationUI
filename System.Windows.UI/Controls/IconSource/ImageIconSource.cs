using System.Windows.Media;

namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет источник значков, который использует изображение в качестве содержимого.
/// </summary>
public sealed class ImageIconSource : IconSource
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Source"/>.
    /// </summary>
    public static readonly DependencyProperty SourceProperty =
        DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageIconSource),
            new PropertyMetadata(null));
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="ImageIconSource"/>.
    /// </summary>
    public ImageIconSource()
    {
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает или задает тип <seealso cref="ImageSource"/> для изображения.
    /// </summary>
    /// <value>
    /// Источник нарисованного изображения. Значение по умолчанию - <see langword="null"/>.
    /// </value>
    public ImageSource Source
    {
        get => (ImageSource)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Создает новый экземпляр класса <seealso cref="ImageIcon"/>.
    /// </summary>
    /// <returns>
    /// Значок пользовательского интерфейса.
    /// </returns>
    protected override IconElement CreateIconElementCore()
    {
        ImageIcon imageIcon = new();
        imageIcon.Foreground = Foreground;
        imageIcon.Source = Source;
        return imageIcon;
    }

    /// <summary>
    /// Сопоставляет свойства <seealso cref="ImageIconSource"/> со свойствами <seealso cref="ImageIcon"/>.
    /// </summary>
    /// <param name="iconSourceProperty">
    /// Идентификатор свойства зависимостей <seealso cref="ImageIconSource"/> для сопоставления со свойствами <seealso cref="ImageIcon"/>.
    /// </param>
    /// <returns>
    /// Объект, обеспечивающий поддержку выражений значений, привязки данных, анимации и уведомлений об изменении свойств.
    /// </returns>
    protected override DependencyProperty GetIconElementPropertyCore(DependencyProperty iconSourceProperty)
    {
        if (iconSourceProperty == SourceProperty)
        {
            return ImageIcon.SourceProperty;
        }

        return base.GetIconElementPropertyCore(iconSourceProperty);
    }
    #endregion

}
