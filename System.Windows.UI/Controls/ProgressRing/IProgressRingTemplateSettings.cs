namespace System.Windows.UI.Controls.Primitives;

/// <summary>
/// Предоставляет вычисленные значения, на которые можно ссылаться как на источники TemplatedParent
/// при определении шаблонов для элемента управления <seealso cref="ProgressRing"/>.
/// </summary>
/// <remarks>
/// Не предназначен для общего использования.
/// </remarks>
internal interface IProgressRingTemplateSettings
{
    #region Properties
    /// <summary>
    /// Получает или задает диаметр эллипса, который анимируется в <seealso cref="ProgressRing"/>.
    /// </summary>
    /// <value>
    /// Ширина эллипса в пикселях.
    /// </value>
    double EllipseDiameter { get; set; }

    /// <summary>
    /// Получает или задает позицию смещения эллипса, который анимируется в <seealso cref="ProgressRing"/>.
    /// </summary>
    /// <value>
    /// Смещение в пикселях.
    /// </value>
    Thickness EllipseOffset { get; set; }

    /// <summary>
    /// Получает или задает максимальный ограничивающий размер кольца прогресса при отображении.
    /// </summary>
    /// <value>
    /// Максимальный ограничивающий размер кольца прогресса, отображаемый в пикселях.
    /// </value>
    double MaxSideLength { get; set; }
    #endregion
}