using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace System.Windows.UI.Controls.Primitives;

/// <summary>
/// Представляет панель, которая размещает свои элементы по горизонтали, если есть доступное пространство, в противном случае по вертикали.
/// </summary>
public sealed class InfoBarPanel : Panel
{
    #region Fields
    /// <summary>
    /// Идентифицирует присоединенное свойство зависимостей HorizontalOrientationMargin.
    /// </summary>
    public static readonly DependencyProperty HorizontalOrientationMarginProperty =
        DependencyProperty.RegisterAttached("HorizontalOrientationMargin", typeof(Thickness), typeof(InfoBarPanel),
            new FrameworkPropertyMetadata(default(Thickness),
                FrameworkPropertyMetadataOptions.AffectsParentMeasure |
                FrameworkPropertyMetadataOptions.AffectsParentArrange));

    /// <summary>
    /// Идентифицирует присоединенное свойство зависимостей VerticalOrientationMargin.
    /// </summary>
    public static readonly DependencyProperty VerticalOrientationMarginProperty =
        DependencyProperty.RegisterAttached("VerticalOrientationMargin", typeof(Thickness), typeof(InfoBarPanel),
            new FrameworkPropertyMetadata(default(Thickness),
                FrameworkPropertyMetadataOptions.AffectsParentMeasure |
                FrameworkPropertyMetadataOptions.AffectsParentArrange));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="HorizontalOrientationPadding"/>.
    /// </summary>
    public static readonly DependencyProperty HorizontalOrientationPaddingProperty =
        DependencyProperty.Register("HorizontalOrientationPadding", typeof(Thickness), typeof(InfoBarPanel),
            new FrameworkPropertyMetadata(default(Thickness),
                FrameworkPropertyMetadataOptions.AffectsMeasure |
                FrameworkPropertyMetadataOptions.AffectsArrange));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="VerticalOrientationPadding"/>.
    /// </summary>
    public static readonly DependencyProperty VerticalOrientationPaddingProperty =
        DependencyProperty.Register("VerticalOrientationPadding", typeof(Thickness), typeof(InfoBarPanel),
            new FrameworkPropertyMetadata(default(Thickness),
                FrameworkPropertyMetadataOptions.AffectsMeasure |
                FrameworkPropertyMetadataOptions.AffectsArrange));

    private bool m_isVertical;
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="InfoBarPanel"/>.
    /// </summary>
    public InfoBarPanel()
    {
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает и задает расстояние между краями <seealso cref="InfoBarPanel"/> и его дочерними элементами, когда панель ориентирована горизонтально.
    /// </summary>
    /// <value>
    /// Расстояние между краями <seealso cref="InfoBarPanel"/> и его дочерних элементов, когда панель ориентирована горизонтально.
    /// </value>
    [Bindable(true)]
    [Category("Layout")]
    [Description("Получает и задает расстояние между краями InfoBarPanel и его дочерними элементами, когда панель ориентирована горизонтально.")]
    public Thickness HorizontalOrientationPadding
    {
        get => (Thickness)GetValue(HorizontalOrientationPaddingProperty);
        set => SetValue(HorizontalOrientationPaddingProperty, value);
    }

    /// <summary>
    /// Получает и задает расстояние между краями <seealso cref="InfoBarPanel"/> и его дочерними элементами, когда панель ориентирована вертикально.
    /// </summary>
    /// <value>
    /// Расстояние между краями <seealso cref="InfoBarPanel"/> и его дочерних элементов, когда панель ориентирована вертикально.
    /// </value>
    [Bindable(true)]
    [Category("Layout")]
    [Description("Получает и задает расстояние между краями InfoBarPanel и его дочерними элементами, когда панель ориентирована вертикально.")]
    public Thickness VerticalOrientationPadding
    {
        get => (Thickness)GetValue(VerticalOrientationPaddingProperty);
        set => SetValue(VerticalOrientationPaddingProperty, value);
    }
    #endregion

    #region AttachedProperty
    /// <summary>
    /// Возвращает значение присоединенного свойства HorizontalOrientationMargin для указанного объекта зависимости.
    /// </summary>
    /// <param name="target">
    /// Объект зависимости, для которого требуется получить значение свойства HorizontalOrientationMargin.
    /// </param>
    /// <returns>
    /// Текущее значение присоединенного свойства HorizontalOrientationMargin в заданном объекте зависимости.
    /// </returns>
    /// <exception cref="ArgumentNullException"/>
    public static Thickness GetHorizontalOrientationMargin(DependencyObject target)
    {
        if (target is null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        return (Thickness)target.GetValue(HorizontalOrientationMarginProperty);
    }

    /// <summary>
    /// Задает значение присоединенного свойства HorizontalOrientationMargin для указанного объекта зависимости.
    /// </summary>
    /// <param name="target">
    /// Объект зависимости, для которого необходимо установить значение свойства HorizontalOrientationMargin.
    /// </param>
    /// <param name="value">
    /// Новое значение, которое необходимо присвоить свойству.
    /// </param>
    /// <exception cref="ArgumentNullException"/>
    public static void SetHorizontalOrientationMargin(DependencyObject target, Thickness value)
    {
        if (target is null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        target.SetValue(HorizontalOrientationMarginProperty, value);
    }

    /// <summary>
    /// Возвращает значение присоединенного свойства VerticalOrientationMargin для указанного объекта зависимости.
    /// </summary>
    /// <param name="target">
    /// Объект зависимости, для которого требуется получить значение свойства VerticalOrientationMargin.
    /// </param>
    /// <returns>
    /// Текущее значение присоединенного свойства VerticalOrientationMargin в заданном объекте зависимости.
    /// </returns>
    /// <exception cref="ArgumentNullException"/>
    public static Thickness GetVerticalOrientationMargin(DependencyObject target)
    {
        if (target is null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        return (Thickness)target.GetValue(VerticalOrientationMarginProperty);
    }

    /// <summary>
    /// Задает значение присоединенного свойства VerticalOrientationMargin для указанного объекта зависимости.
    /// </summary>
    /// <param name="target">
    /// Объект зависимости, для которого необходимо установить значение свойства VerticalOrientationMargin/>.
    /// </param>
    /// <param name="value">
    /// Новое значение, которое необходимо присвоить свойству.
    /// </param>
    /// <exception cref="ArgumentNullException"/>
    public static void SetVerticalOrientationMargin(DependencyObject target, Thickness value)
    {
        if (target is null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        target.SetValue(VerticalOrientationMarginProperty, value);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Измеряет размер в структуре, требуемый для дочерних элементов, и определяет размер для <seealso cref="InfoBarPanel"/>.
    /// </summary>
    /// <param name="availableSize">
    /// Доступный размер, который этот элемент может предоставить дочерним элементам.
    /// </param>
    /// <returns>
    /// Размер, определяемый данным элементом для своих потребностей во время структурирования на основе вычисления размеров дочерних элементов.
    /// </returns>
    protected override Size MeasureOverride(Size availableSize)
    {
        Size desiredSize = new();

        double totalWidth = 0;
        double totalHeight = 0;
        double widthOfWidest = 0;
        double heightOfTallest = 0;
        double heightOfTallestInHorizontal = 0;
        int nItems = 0;

        double minHeight = Parent is FrameworkElement parent ? parent.MinHeight - (Margin.Top + Margin.Bottom) : 0;

        UIElementCollection children = InternalChildren;
        int childCount = children.Count;

        foreach (UIElement child in children)
        {
            child.Measure(availableSize);
            Size childDesiredSize = child.DesiredSize;

            if (childDesiredSize.Width != 0 && childDesiredSize.Height != 0)
            {
                // Суммируем ширину всех элементов, если они были расположены горизонтально.
                Thickness horizontalMargin = GetHorizontalOrientationMargin(child);
                // Игнорируем левое поле первого и правое поле последнего дочернего элемента.
                totalWidth += childDesiredSize.Width + (nItems > 0 ? horizontalMargin.Left : 0) + (nItems < childCount - 1 ? horizontalMargin.Right : 0);

                // Суммируем высоту всех элементов, если они были расположены вертикально.
                Thickness verticalMargin = GetVerticalOrientationMargin(child);
                // Игнорируем верхнее поле первого и нижнее поле последнего дочернего элемента.
                totalHeight += childDesiredSize.Height + (nItems > 0 ? verticalMargin.Top : 0) + (nItems < childCount - 1 ? verticalMargin.Bottom : 0);

                if (childDesiredSize.Width > widthOfWidest)
                {
                    widthOfWidest = childDesiredSize.Width;
                }

                if (childDesiredSize.Height > heightOfTallest)
                {
                    heightOfTallest = childDesiredSize.Height;
                }

                double childHeightInHorizontal = childDesiredSize.Height + horizontalMargin.Top + horizontalMargin.Bottom;

                if (childHeightInHorizontal > heightOfTallestInHorizontal)
                {
                    heightOfTallestInHorizontal = childHeightInHorizontal;
                }

                nItems++;
            }
        }

        // Поскольку эта панель находится внутри столбца сетки размером *, значение availableSize.Width не должно быть бесконечным
        // Если внутри панели только один элемент, мы будем считать его вертикальным (так поля работают лучше)
        // Кроме того, если высота любого элемента выше, чем желаемая минимальная высота информационной панели,
        // элементы должны быть расположены вертикально, даже если они могут показаться подходящими из-за переноса текста.

        if (nItems == 1 || totalWidth > availableSize.Width || (minHeight > 0 && heightOfTallestInHorizontal > minHeight))
        {
            m_isVertical = true;
            Thickness verticalPadding = VerticalOrientationPadding;

            desiredSize.Width = widthOfWidest + verticalPadding.Left + verticalPadding.Right;
            desiredSize.Height = totalHeight + verticalPadding.Top + verticalPadding.Bottom;
        }
        else
        {
            m_isVertical = false;
            Thickness horizontalPadding = HorizontalOrientationPadding;

            desiredSize.Width = totalWidth + horizontalPadding.Left + horizontalPadding.Right;
            desiredSize.Height = heightOfTallest + horizontalPadding.Top + horizontalPadding.Bottom;
        }

        return desiredSize;
    }

    /// <summary>
    /// Размещает дочерние элементы и определяет размер для <seealso cref="InfoBarPanel"/>.
    /// </summary>
    /// <param name="finalSize">
    /// Итоговая область в родительском элементе, которую этот элемент должен использовать для размещения себя и своих дочерних элементов.
    /// </param>
    /// <returns>
    /// Фактический используемый размер.
    /// </returns>
    protected override Size ArrangeOverride(Size finalSize)
    {
        Size result = finalSize;

        if (m_isVertical)
        {
            // Вертикальное расположение элементов.
            Thickness verticalOrientationPadding = VerticalOrientationPadding;
            double verticalOffset = verticalOrientationPadding.Top;

            bool hasPreviousElement = false;

            foreach (UIElement child in InternalChildren)
            {
                if (child is FrameworkElement)
                {
                    Size desiredSize = child.DesiredSize;

                    if (desiredSize.Width != 0 && desiredSize.Height != 0)
                    {
                        Thickness verticalMargin = GetVerticalOrientationMargin(child);

                        verticalOffset += hasPreviousElement ? verticalMargin.Top : 0;
                        child.Arrange(new Rect(verticalOrientationPadding.Left + verticalMargin.Left, verticalOffset, desiredSize.Width, desiredSize.Height));
                        verticalOffset += desiredSize.Height + verticalMargin.Bottom;

                        hasPreviousElement = true;
                    }
                }
            }
        }
        else
        {
            // Горизонтальное расположение элементов.
            Thickness horizontalOrientationPadding = HorizontalOrientationPadding;
            double horizontalOffset = horizontalOrientationPadding.Left;
            bool hasPreviousElement = false;

            UIElementCollection children = InternalChildren;
            int childCount = children.Count;

            for (int i = 0; i < childCount; i++)
            {
                if (children[i] is FrameworkElement child)
                {
                    Size desiredSize = child.DesiredSize;

                    if (desiredSize.Width != 0 && desiredSize.Height != 0)
                    {
                        Thickness horizontalMargin = GetHorizontalOrientationMargin(child);

                        horizontalOffset += hasPreviousElement ? horizontalMargin.Left : 0;

                        if (i < childCount - 1)
                        {
                            child.Arrange(new Rect(horizontalOffset, horizontalOrientationPadding.Top + horizontalMargin.Top, desiredSize.Width, desiredSize.Height));
                        }
                        else
                        {
                            child.Arrange(new Rect(horizontalOffset, horizontalOrientationPadding.Top + horizontalMargin.Top,
                                Math.Max(desiredSize.Width, finalSize.Width - horizontalOffset), desiredSize.Height));
                        }

                        horizontalOffset += desiredSize.Width + horizontalMargin.Right;
                        hasPreviousElement = true;
                    }
                }
            }
        }

        return result;
    }
    #endregion
}
