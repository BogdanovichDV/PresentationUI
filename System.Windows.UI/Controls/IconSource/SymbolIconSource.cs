namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет источник значков, в котором в качестве содержимого используется глиф из шрифта Segoe MDL2 Assets.
/// </summary>
public sealed class SymbolIconSource : IconSource
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Symbol"/>.
    /// </summary>
    public static readonly DependencyProperty SymbolProperty =
        DependencyProperty.Register("Symbol", typeof(Symbol), typeof(SymbolIconSource),
            new PropertyMetadata(Symbol.Emoji));
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="SymbolIconSource"/>.
    /// </summary>
    public SymbolIconSource()
    {
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает или задает глиф Segoe MDL2 Assets, используемый в качестве содержимого значка.
    /// </summary>
    /// <value>
    /// Именованная константа нумерации, определяющая используемый глиф Segoe MDL2 Assets.
    /// </value>
    public Symbol Symbol
    {
        get => (Symbol)GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Создает новый экземпляр класса <seealso cref="SymbolIcon"/>.
    /// </summary>
    /// <returns>
    /// Значок пользовательского интерфейса.
    /// </returns>
    protected override IconElement CreateIconElementCore()
    {
        SymbolIcon symbolIcon = new();
        symbolIcon.Foreground = Foreground;
        symbolIcon.Symbol = Symbol;
        return symbolIcon;
    }

    /// <summary>
    /// Сопоставляет свойства <seealso cref="SymbolIconSource"/> со свойствами <seealso cref="SymbolIcon"/>.
    /// </summary>
    /// <param name="iconSourceProperty">
    /// Идентификатор свойства зависимостей <seealso cref="SymbolIconSource"/> для сопоставления со свойствами <seealso cref="SymbolIcon"/>.
    /// </param>
    /// <returns>
    /// Объект, обеспечивающий поддержку выражений значений, привязки данных, анимации и уведомлений об изменении свойств.
    /// </returns>
    protected override DependencyProperty GetIconElementPropertyCore(DependencyProperty iconSourceProperty)
    {
        if (iconSourceProperty == SymbolProperty)
        {
            return SymbolIcon.SymbolProperty;
        }

        return base.GetIconElementPropertyCore(iconSourceProperty);
    }
    #endregion

}
