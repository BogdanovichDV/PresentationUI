using System.ComponentModel;

namespace System.Windows.UI.Controls.Primitives;

/// <summary>
/// Предоставляет вычисленные значения, на которые можно ссылаться как на источники TemplatedParent
/// при определении шаблонов для элемента управления <seealso cref="ProgressRing"/>.
/// </summary>
/// <remarks>
/// Не предназначен для общего использования.
/// </remarks>
public sealed class ProgressRingTemplateSettings : DependencyObject, IProgressRingTemplateSettings
{
    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="EllipseDiameter"/>.
    /// </summary>
    private static readonly DependencyProperty EllipseDiameterProperty =
        DependencyProperty.Register("EllipseDiameter", typeof(double), typeof(ProgressRingTemplateSettings));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="EllipseOffset"/>.
    /// </summary>
    private static readonly DependencyProperty EllipseOffsetProperty =
        DependencyProperty.Register("EllipseOffset", typeof(Thickness), typeof(ProgressRingTemplateSettings));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="MaxSideLength"/>.
    /// </summary>
    private static readonly DependencyProperty MaxSideLengthProperty =
        DependencyProperty.Register("MaxSideLength", typeof(double), typeof(ProgressRingTemplateSettings));
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="ProgressRingTemplateSettings"/>.
    /// </summary>
    internal ProgressRingTemplateSettings()
    {
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает диаметр эллипса, который анимируется в <seealso cref="ProgressRing"/>.
    /// </summary>
    /// <value>
    /// Ширина эллипса в пикселях.
    /// </value>
    [ReadOnly(true)]
    [Bindable(true)]
    public double EllipseDiameter => (double)GetValue(EllipseDiameterProperty);

    /// <summary>
    /// Получает позицию смещения эллипса, который анимируется в <seealso cref="ProgressRing"/>.
    /// </summary>
    /// <value>
    /// Смещение в пикселях.
    /// </value>
    [ReadOnly(true)]
    [Bindable(true)]
    public Thickness EllipseOffset => (Thickness)GetValue(EllipseOffsetProperty);

    /// <summary>
    /// Получает максимальный ограничивающий размер кольца прогресса при отображении.
    /// </summary>
    /// <value>
    /// Максимальный ограничивающий размер кольца прогресса, отображаемый в пикселях.
    /// </value>
    [ReadOnly(true)]
    [Bindable(true)]
    public double MaxSideLength => (double)GetValue(MaxSideLengthProperty);
    #endregion

    #region Interface Implementation
    /// <summary>
    /// Получает или задает диаметр эллипса, который анимируется в <seealso cref="ProgressRing"/>.
    /// </summary>
    /// <value>
    /// Ширина эллипса в пикселях.
    /// </value>
    double IProgressRingTemplateSettings.EllipseDiameter
    { 
        get => (double)GetValue(EllipseDiameterProperty);
        set => SetValue(EllipseDiameterProperty, value);
    }

    /// <summary>
    /// Получает или задает позицию смещения эллипса, который анимируется в <seealso cref="ProgressRing"/>.
    /// </summary>
    /// <value>
    /// Смещение в пикселях.
    /// </value>
    Thickness IProgressRingTemplateSettings.EllipseOffset 
    {
        get => (Thickness)GetValue(EllipseOffsetProperty);
        set => SetValue(EllipseOffsetProperty, value);
    }

    /// <summary>
    /// Получает или задает максимальный ограничивающий размер кольца прогресса при отображении.
    /// </summary>
    /// <value>
    /// Максимальный ограничивающий размер кольца прогресса, отображаемый в пикселях.
    /// </value>
    double IProgressRingTemplateSettings.MaxSideLength
    {
        get => (double)GetValue(MaxSideLengthProperty);
        set => SetValue(MaxSideLengthProperty, value);
    }
    #endregion
}
