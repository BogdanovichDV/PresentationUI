using System.Windows.Media;

namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет источник значков, который использует векторный путь в качестве содержимого.
/// </summary>
public sealed class PathIconSource : IconSource
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Data"/>.
    /// </summary>
    public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register("Data", typeof(Geometry), typeof(PathIconSource),
            new PropertyMetadata(null));
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="PathIconSource"/>.
    /// </summary>
    public PathIconSource()
    {
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает или задает <seealso cref="Geometry"/>, определяющий рисуемую фигуру.
    /// </summary>
    /// <value>
    /// Описание рисуемой фигуры.
    /// </value>
    public Geometry Data
    {
        get => (Geometry)GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Создает новый экземпляр класса <seealso cref="PathIcon"/>.
    /// </summary>
    /// <returns>
    /// Значок пользовательского интерфейса.
    /// </returns>
    protected override IconElement CreateIconElementCore()
    {
        PathIcon pathIcon = new();
        pathIcon.Foreground = Foreground;
        pathIcon.Data = Data;
        return pathIcon;
    }

    /// <summary>
    /// Сопоставляет свойства <seealso cref="PathIconSource"/> со свойствами <seealso cref="PathIcon"/>.
    /// </summary>
    /// <param name="iconSourceProperty">
    /// Идентификатор свойства зависимостей <seealso cref="PathIconSource"/> для сопоставления со свойствами <seealso cref="PathIcon"/>.
    /// </param>
    /// <returns>
    /// Объект, обеспечивающий поддержку выражений значений, привязки данных, анимации и уведомлений об изменении свойств.
    /// </returns>
    protected override DependencyProperty GetIconElementPropertyCore(DependencyProperty iconSourceProperty)
    {
        if (iconSourceProperty == DataProperty)
        {
            return PathIcon.DataProperty;
        }

        return base.GetIconElementPropertyCore(iconSourceProperty);
    }
    #endregion
}
