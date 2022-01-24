using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет значок, который использует изображение в качестве содержимого.
/// </summary>
public sealed class ImageIcon : IconElement
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Source"/>.
    /// </summary>
    public static readonly DependencyProperty SourceProperty =
        DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageIcon),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnSourceChanged)));

    private readonly Image renderer;
    #endregion

    #region Construcotrs
    /// <summary>
    /// Инициализирует статические данные класса <seealso cref="ImageIcon"/>.
    /// </summary>
    static ImageIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageIcon),
            new FrameworkPropertyMetadata(typeof(ImageIcon)));
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="ImageIcon"/>.
    /// </summary>
    public ImageIcon()
    {
        renderer = new();
        renderer.HorizontalAlignment = HorizontalAlignment.Stretch;
        renderer.VerticalAlignment = VerticalAlignment.Stretch;
        renderer.Stretch = Stretch.Uniform;
        renderer.StretchDirection = StretchDirection.Both;
        renderer.Source = Source;
        // Добавьте дочерний элемент управления.
        Children.Add(renderer);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает или задает тип <seealso cref="ImageSource"/> для изображения.
    /// </summary>
    /// <value>
    /// Источник нарисованного изображения. Значение по умолчанию - <see langword="null"/>.
    /// </value>
    [Category("Common Properties")]
    [Description("Получает или задает тип ImageSource для изображения.")]
    public ImageSource Source
    {
        get => (ImageSource)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }
    #endregion

    #region Methods
    private static void OnSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        ImageIcon imageIcon = (ImageIcon)sender;
        imageIcon.renderer.SetValue(Image.SourceProperty, args.NewValue);
    }
    #endregion
}