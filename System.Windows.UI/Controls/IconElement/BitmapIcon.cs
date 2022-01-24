using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет значок, в качестве содержимого которого используется растровое изображение.
/// </summary>
public sealed class BitmapIcon : IconElement
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="ShowAsMonochrome"/>.
    /// </summary>
    public static readonly DependencyProperty ShowAsMonochromeProperties =
        DependencyProperty.Register("ShowAsMonochrome", typeof(bool), typeof(BitmapIcon),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender,
                new PropertyChangedCallback(OnShowAsMonochromeChanged)));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="UriSource"/>.
    /// </summary>
    public static readonly DependencyProperty UriSourceProperty =
        DependencyProperty.Register("UriSource", typeof(Uri), typeof(BitmapIcon),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender,
                new PropertyChangedCallback(OnUriSourceChanged)));

    private ImageSource source;
    

    private readonly Image renderer;
    private ImageBrush opacityMaskBrush;
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует статические данные класса <seealso cref="BitmapIcon"/>.
    /// </summary>
    static BitmapIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(BitmapIcon),
            new FrameworkPropertyMetadata(typeof(BitmapIcon)));
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="BitmapIcon"/>.
    /// </summary>
    public BitmapIcon()
    {
        opacityMaskBrush = new();
        opacityMaskBrush.Stretch = Stretch.Uniform;

        renderer = new();
        renderer.HorizontalAlignment = HorizontalAlignment.Stretch;
        renderer.VerticalAlignment = VerticalAlignment.Stretch;
        renderer.Stretch = Stretch.Uniform;
        renderer.StretchDirection = StretchDirection.Both;
        UpdateVisibility();
        UpdateImageSource();
        // Добавьте дочерний элемент управления.
        Children.Add(renderer);
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

    private Brush? OpacityMaskBrush { get; set; }
    #endregion

    #region Methods
    protected override void OnRender(DrawingContext drawingContext)
    {
        if (ShowAsMonochrome)
        {
            drawingContext.PushOpacityMask(OpacityMaskBrush);
            drawingContext.DrawRectangle(Foreground, null, new Rect(RenderSize));

        }
    }

    private static void OnShowAsMonochromeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        BitmapIcon icon = (BitmapIcon)sender;
        icon.UpdateVisibility();
    }

    private static void OnUriSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        BitmapIcon icon = (BitmapIcon)sender;
        icon.UpdateImageSource();
    }

    private void UpdateVisibility()
    {
        renderer.Visibility = ShowAsMonochrome ? Visibility.Hidden : Visibility.Visible;
    }

    private void UpdateImageSource()
    {
        if (UriSource is Uri uriSource)
        {
            ImageSource imageSource = new BitmapImage(uriSource);
            renderer.Source = imageSource;
            ImageBrush opacityMaskBrush = new(imageSource);
            opacityMaskBrush.Stretch = Stretch.Uniform;
            OpacityMaskBrush = opacityMaskBrush;
        }
        else
        {
            renderer.ClearValue(Image.SourceProperty);
            OpacityMaskBrush = null;
        }
    }
    #endregion
}
