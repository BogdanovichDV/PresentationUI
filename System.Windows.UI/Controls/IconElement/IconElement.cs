using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет базовый элемент управления, содержащий значок. Класс является абстрактным.
/// </summary>
public abstract class IconElement : FrameworkElement
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="BitmapScalingMode"/>.
    /// </summary>
    public static readonly DependencyProperty BitmapScalingModeProperty =
        RenderOptions.BitmapScalingModeProperty.AddOwner(typeof(IconElement));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Foreground"/>.
    /// </summary>
    public static readonly DependencyProperty ForegroundProperty =
        TextElement.ForegroundProperty.AddOwner(typeof(IconElement));

    private readonly Grid layoutRoot;
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует статические данные класса <seealso cref="IconElement"/>.
    /// </summary>
    static IconElement()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(IconElement),
            new FrameworkPropertyMetadata(typeof(IconElement)));
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="IconElement"/>.
    /// </summary>
    internal IconElement()
    {
        layoutRoot = new();
        layoutRoot.SnapsToDevicePixels = true;
        layoutRoot.Background = Brushes.Transparent;
        AddVisualChild(layoutRoot);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает коллекцию <seealso cref="UIElementCollection"/> дочерних элементов этого объекта <seealso cref="IconElement"/>.
    /// </summary>
    /// <value>
    /// Объект <seealso cref="UIElementCollection"/>. Значение по умолчанию - пустой объект <seealso cref="UIElementCollection"/>.
    /// </value>
    protected UIElementCollection Children => layoutRoot.Children;

    /// <summary>
    /// Получает количество дочерних объектов <seealso cref="Visual"/> в этом экземпляре объекта <seealso cref="IconElement"/>.
    /// </summary>
    /// <value>
    /// Количество дочерних объектов <seealso cref="Visual"/>.
    /// </value>
    protected override int VisualChildrenCount { get; } = 1;

    /// <summary>
    /// Возвращает или задает <seealso cref="System.Windows.Media.BitmapScalingMode"/> для объекта <seealso cref="IconElement"/>.
    /// </summary>
    /// <value>
    /// Значение <seealso cref="System.Windows.Media.BitmapScalingMode"/> для <seealso cref="IconElement"/>.
    /// </value>
    [Category("Common Properties")]
    [Description("Возвращает или задает BitmapScalingMode для объекта IconElement.")]
    public BitmapScalingMode BitmapScalingMode
    {
        get => (BitmapScalingMode)GetValue(BitmapScalingModeProperty);
        set => SetValue(BitmapScalingModeProperty, value);
    }

    /// <summary>
    /// Возвращает или задает кисть, которая описывает основной цвет.
    /// </summary>
    /// <value>
    /// Кисть, которая заливает основной цвет элемента управления.
    /// Значение по умолчанию — <seealso cref="Brushes.Black"/>.
    /// Однако это значение обычно задается системным ресурсом по умолчанию во время
    /// запуска, который связан с активной темой и другими параметрами.
    /// </value>
    [Bindable(true)]
    [Category("Brushes")]
    [Description("Возвращает или задает кисть, которая описывает основной цвет.")]
    public Brush Foreground
    {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Получает дочерний элемент <seealso cref="Visual"/> данного объекта <seealso cref="IconElement"/> с указанным индексом.
    /// </summary>
    /// <param name="index">
    /// Индекс дочернего объекта <seealso cref="Visual"/>.
    /// </param>
    /// <returns>
    /// Дочерний объект <seealso cref="Visual"/> родительского элемента <seealso cref="IconElement"/>.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Указанный индекс вышел за границы массива, или дочерний объект с индексом не определен.
    /// </exception>
    protected override Visual GetVisualChild(int index)
    {
        if (index is not 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), index,
                "Указанный индекс вышел за границы массива, или дочерний объект с индексом не определен.");
        }

        return layoutRoot;
    }

    /// <summary>
    /// Измеряет дочерние элементы элемента управления <seealso cref="IconElement"/>
    /// для последующего их размещения с помощью метода <seealso cref="FrameworkElement.ArrangeOverride(Size)"/>.
    /// </summary>
    /// <param name="availableSize">
    /// Указывает верхний предел размера, который не должен быть превышен.
    /// </param>
    /// <returns>
    /// Структура <seealso cref="Size"/>, представляющая требуемый размер для размещения содержимого дочерних элементов.
    /// </returns>
    protected override Size MeasureOverride(Size availableSize)
    {
        layoutRoot.Measure(availableSize);
        return layoutRoot.DesiredSize;
    }

    /// <summary>
    /// Упорядочивает содержимое элемента <seealso cref="IconElement"/>.
    /// </summary>
    /// <param name="finalSize">
    /// Задает размер, который данный элемент <seealso cref="IconElement"/> должен использовать для размещения своих дочерних элементов.
    /// </param>
    /// <returns>
    /// Значение типа <seealso cref="Size"/>, представляющее размер данного элемента <seealso cref="IconElement"/> и его дочерних элементов при размещении.
    /// </returns>
    protected override Size ArrangeOverride(Size finalSize)
    {
        layoutRoot.Arrange(new Rect(finalSize));
        return finalSize;
    }
    #endregion
}
