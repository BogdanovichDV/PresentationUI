using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Shapes;

namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет значок, в качестве содержимого которого используется векторный путь.
/// </summary>
public sealed class PathIcon : IconElement
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Data"/>.
    /// </summary>
    public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register("Data", typeof(Geometry), typeof(PathIcon),
            new FrameworkPropertyMetadata(null, OnDataPropertyChanged));

    private readonly Path renderer;
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует статические данные класса <seealso cref="PathIcon"/>.
    /// </summary>
    static PathIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(PathIcon),
            new FrameworkPropertyMetadata(typeof(PathIcon)));
        ForegroundProperty.OverrideMetadata(typeof(PathIcon),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnForegroundPropertyChanged)));
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="PathIcon"/>.
    /// </summary>
    public PathIcon()
    {
        renderer = new();
        renderer.HorizontalAlignment = HorizontalAlignment.Stretch;
        renderer.VerticalAlignment = VerticalAlignment.Stretch;
        renderer.Stretch = Stretch.Uniform;
        renderer.Fill = Foreground;
        renderer.Data = Data;
        // Добавьте дочерний элемент управления.
        Children.Add(renderer);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает или задает <seealso cref="Geometry"/>, определяющий рисуемую фигуру.
    /// </summary>
    /// <value>
    /// Описание рисуемой фигуры.
    /// </value>
    [Category("Common Properties")]
    [Description("Получает или задает Geometry, определяющий рисуемую фигуру.")]
    public Geometry Data
    {
        get => (Geometry)GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }
    #endregion

    #region Methods
    private static void OnDataPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        PathIcon pathIcon = (PathIcon)sender;
        pathIcon.renderer.SetValue(Path.DataProperty, args.NewValue);
    }

    private static void OnForegroundPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        PathIcon pathIcon = (PathIcon)sender;
        pathIcon.renderer.SetValue(Shape.FillProperty, args.NewValue);
    }
    #endregion
}
