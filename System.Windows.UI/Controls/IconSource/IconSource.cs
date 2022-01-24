using System.Collections.Generic;
using System.Windows.Media;

namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет базовый класс для источника значка.
/// </summary>
public abstract class IconSource : DependencyObject
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Foreground"/>.
    /// </summary>
    public static readonly DependencyProperty ForegroundProperty =
        DependencyProperty.Register("Foreground", typeof(Brush), typeof(IconSource),
            new PropertyMetadata(Brushes.Black));

    private readonly List<WeakReference> CreatedIconElements;
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="IconSource"/>.
    /// </summary>
    internal IconSource()
    {
        CreatedIconElements = new List<WeakReference>();
    }
    #endregion

    #region Properties
    /// <summary>
    /// Возвращает или задает кисть, которая описывает основной цвет.
    /// </summary>
    /// <value>
    /// Кисть, которая заливает основной цвет элемента управления.
    /// Значение по умолчанию — <seealso cref="Brushes.Black"/>.
    /// Однако это значение обычно задается системным ресурсом по умолчанию во время
    /// запуска, который связан с активной темой и другими параметрами.
    /// </value>
    public Brush Foreground
    {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Создает новый экземпляр элемента значка.
    /// </summary>
    /// <returns>
    /// Значок пользовательского интерфейса.
    /// </returns>
    protected abstract IconElement CreateIconElementCore();

    /// <summary>
    /// Создает новый экземпляр элемента значка.
    /// </summary>
    /// <returns>
    /// Значок пользовательского интерфейса.
    /// </returns>
    public IconElement CreateIconElement()
    {
        IconElement iconElement = CreateIconElementCore();
        CreatedIconElements.Add(new WeakReference(iconElement));
        return iconElement;
    }

    /// <summary>
    /// Сопоставляет свойства <seealso cref="IconSource"/> со свойствами <seealso cref="IconElement"/>.
    /// </summary>
    /// <param name="iconSourceProperty">
    /// Идентификатор свойства зависимостей <seealso cref="IconSource"/> для сопоставления со свойствами <seealso cref="IconElement"/>.
    /// </param>
    /// <returns>
    /// Объект, обеспечивающий поддержку выражений значений, привязки данных, анимации и уведомлений об изменении свойств.
    /// </returns>
    protected virtual DependencyProperty GetIconElementPropertyCore(DependencyProperty iconSourceProperty)
    {
        if (iconSourceProperty == ForegroundProperty)
        {
            return IconElement.ForegroundProperty;
        }

        return null;
    }

    /// <summary>
    /// Вызывается каждый раз, когда обновляется действительное значение любого свойства
    /// зависимостей для данного <seealso cref="IconElement"/>.
    /// Конкретное измененное свойство зависимостей сообщается в данных события.
    /// </summary>
    /// <param name="args">
    /// Данные события, в которых будет содержаться интересующий идентификатор свойства зависимостей,
    /// метаданные свойства для типа, а также старое и новое значения.
    /// </param>
    protected sealed override void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
    {
        base.OnPropertyChanged(args);

        DependencyProperty iconProperty = GetIconElementPropertyCore(args.Property);

        if (iconProperty is not null)
        {
            for (int i = 0; i < CreatedIconElements.Count;)
            {
                WeakReference iconReference = CreatedIconElements[i];

                if (iconReference.Target is IconElement element)
                {
                    object localValue = ReadLocalValue(args.Property);

                    if (localValue == DependencyProperty.UnsetValue)
                    {
                        element.ClearValue(iconProperty);
                    }
                    else
                    {
                        element.SetValue(iconProperty, args.NewValue);
                    }

                    i++;
                }
                else
                {
                    // Убираем пустые ссылки.
                    CreatedIconElements.RemoveAt(i);
                }
            }
        }
    }
    #endregion
}
