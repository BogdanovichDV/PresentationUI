using System.Windows.Media;

namespace System.Windows.UI.Controls.Primitives;

/// <summary>
/// Provides calculated values that can be referenced as TemplatedParent sources
/// when defining templates for a <seealso cref="ProgressBar"/> control.
/// Not intended for general use.
/// </summary>
public class ProgressBarTemplateSettings : DependencyObject, IProgressBarTemplateSettings
{
    #region Fields
    /// <summary>
    /// Identifies the <seealso cref="ClipRect"/> dependency property.
    /// </summary>
    private static readonly DependencyProperty ClipRectProperty =
        DependencyProperty.Register(
            "ClipRect",
            typeof(RectangleGeometry),
            typeof(ProgressBarTemplateSettings));

    /// <summary>
    /// Identifies the <seealso cref="ContainerAnimationStartPosition"/> dependency property.
    /// </summary>
    private static readonly DependencyProperty ContainerAnimationStartPositionProperty =
        DependencyProperty.Register(
            "ContainerAnimationStartPosition",
            typeof(double),
            typeof(ProgressBarTemplateSettings));

    /// <summary>
    /// Identifies the <seealso cref="ContainerAnimationMidPosition"/> dependency property.
    /// </summary>
    private static readonly DependencyProperty ContainerAnimationMidPositionProperty =
        DependencyProperty.Register(
            "ContainerAnimationMidPosition",
            typeof(double),
            typeof(ProgressBarTemplateSettings));

    /// <summary>
    /// Identifies the <seealso cref="ContainerAnimationEndPosition"/> dependency property.
    /// </summary>
    private static readonly DependencyProperty ContainerAnimationEndPositionProperty =
        DependencyProperty.Register(
            "ContainerAnimationEndPosition",
            typeof(double),
            typeof(ProgressBarTemplateSettings));

    /// <summary>
    /// Identifies the <seealso cref="Container2AnimationStartPosition"/> dependency property.
    /// </summary>
    private static readonly DependencyProperty Container2AnimationStartPositionProperty =
        DependencyProperty.Register(
            "Container2AnimationStartPosition",
            typeof(double),
            typeof(ProgressBarTemplateSettings));

    /// <summary>
    /// Identifies the <seealso cref="Container2AnimationEndPosition"/> dependency property.
    /// </summary>
    private static readonly DependencyProperty Container2AnimationEndPositionProperty =
        DependencyProperty.Register(
            "Container2AnimationEndPosition",
            typeof(double),
            typeof(ProgressBarTemplateSettings));

    /// <summary>
    /// Identifies the <seealso cref="EllipseAnimationWellPosition"/> dependency property.
    /// </summary>
    private static readonly DependencyProperty EllipseAnimationWellPositionProperty =
        DependencyProperty.Register(
            "EllipseAnimationWellPosition",
            typeof(double),
            typeof(ProgressBarTemplateSettings));

    /// <summary>
    /// Identifies the <seealso cref="EllipseAnimationEndPosition"/> dependency property.
    /// </summary>
    private static readonly DependencyProperty EllipseAnimationEndPositionProperty =
        DependencyProperty.Register(
            "EllipseAnimationEndPosition",
            typeof(double),
            typeof(ProgressBarTemplateSettings));

    /// <summary>
    /// Identifies the <seealso cref="EllipseDiameter"/> dependency property.
    /// </summary>
    private static readonly DependencyProperty EllipseDiameterProperty =
        DependencyProperty.Register(
            "EllipseDiameter",
            typeof(double),
            typeof(ProgressBarTemplateSettings));

    /// <summary>
    /// Identifies the <seealso cref="EllipseOffset"/> dependency property.
    /// </summary>
    private static readonly DependencyProperty EllipseOffsetProperty =
        DependencyProperty.Register(
            "EllipseOffset",
            typeof(double),
            typeof(ProgressBarTemplateSettings));

    /// <summary>
    /// Identifies the <seealso cref="IndicatorLengthDelta"/> dependency property.
    /// </summary>
    private static readonly DependencyProperty IndicatorLengthDeltaProperty =
        DependencyProperty.Register(
            "IndicatorLengthDelta",
            typeof(double),
            typeof(ProgressBarTemplateSettings));
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProgressBarTemplateSettings"/> class.
    /// </summary>
    internal ProgressBarTemplateSettings()
    {
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the <seealso cref="Rect"/> that describes the clipped area of the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A <seealso cref="Rect"/> that describes the clipped area of the <seealso cref="ProgressBar"/>.
    /// </value>
    public RectangleGeometry ClipRect => (RectangleGeometry)GetValue(ClipRectProperty);

    /// <summary>
    /// Gets the "From" point of the primary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the"From" point of the primary animation.
    /// </value>
    public double ContainerAnimationStartPosition => (double)GetValue(ContainerAnimationStartPositionProperty);

    /// <summary>
    /// Gets the target midpoint of the container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the midpoint of the animation.
    /// </value>
    public double ContainerAnimationMidPosition => (double)GetValue(ContainerAnimationMidPositionProperty);

    /// <summary>
    /// Gets the target "To" point of the primary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the target "To" point of the primary animation.
    /// </value>
    public double ContainerAnimationEndPosition => (double)GetValue(ContainerAnimationEndPositionProperty);

    /// <summary>
    /// Gets the "From" point of the secondary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the"From" point of the secondary animation.
    /// </value>
    public double Container2AnimationStartPosition => (double)GetValue(Container2AnimationStartPositionProperty);

    /// <summary>
    /// Gets the target "To" point of the secondary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the target "To" point of the secondary animation.
    /// </value>
    public double Container2AnimationEndPosition => (double)GetValue(Container2AnimationEndPositionProperty);

    /// <summary>
    /// Gets the stopped point of the "Ellipse" animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// The stopped point of the Ellipse animation that animates the <seealso cref="ProgressBar"/>.
    /// This is internally calculated as 1/3 of the <seealso cref="FrameworkElement.ActualWidth"/> of the control.
    /// </value>
    public double EllipseAnimationWellPosition => (double)GetValue(EllipseAnimationWellPositionProperty);

    /// <summary>
    /// Gets the "To" point of the "Ellipse" animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// The "To" point of the "Ellipse" animation that animates the <seealso cref="ProgressBar"/>.
    /// This is internally calculated as 2/3 of the <seealso cref="FrameworkElement.ActualWidth"/> of the control.
    /// </value>
    public double EllipseAnimationEndPosition => (double)GetValue(EllipseAnimationEndPositionProperty);

    /// <summary>
    /// Gets the template-defined diameter of the "Ellipse" element that is animated in a templated <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <remarks>
    /// This value might be 4, 5, or 6 pixels. This is controlled by the animations that exist in default ProgressBar templates.
    /// </remarks>
    /// <value>
    /// The "Ellipse" element width in pixels.
    /// </value>
    public double EllipseDiameter => (double)GetValue(EllipseDiameterProperty);

    /// <summary>
    /// Gets the template-defined offset poisition of the "Ellipse" element that is animated in a templated <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <remarks>
    /// EllipseOffset might be 4, 7, or 9 pixels. This is controlled by the animations that exist in default <seealso cref="ProgressBar"/> templates.
    /// </remarks>
    /// <value>
    /// The "Ellipse" element offset in pixels.
    /// </value>
    public double EllipseOffset => (double)GetValue(EllipseOffsetProperty);

    /// <summary>
    /// Gets the indicator length delta, which is useful for repositioning transitions.
    /// </summary>
    /// <value>
    /// The delta in pixels.
    /// </value>
    public double IndicatorLengthDelta => (double)GetValue(IndicatorLengthDeltaProperty);
    #endregion

    #region Interface Implementation
    /// <summary>
    /// Gets the <seealso cref="Rect"/> that describes the clipped area of the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A <seealso cref="Rect"/> that describes the clipped area of the <seealso cref="ProgressBar"/>.
    /// </value>
    RectangleGeometry IProgressBarTemplateSettings.ClipRect
    {
        get => (RectangleGeometry)GetValue(ClipRectProperty);
        set => SetValue(ClipRectProperty, value);
    }

    /// <summary>
    /// Gets the "From" point of the primary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the"From" point of the primary animation.
    /// </value>
    double IProgressBarTemplateSettings.ContainerAnimationStartPosition 
    { 
        get => (double)GetValue(ContainerAnimationStartPositionProperty);
        set => SetValue (ContainerAnimationStartPositionProperty, value);
    }

    /// <summary>
    /// Gets the target midpoint of the container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the midpoint of the animation.
    /// </value>
    double IProgressBarTemplateSettings.ContainerAnimationMidPosition
    {
        get => (double)GetValue(ContainerAnimationMidPositionProperty);
        set => SetValue(ContainerAnimationMidPositionProperty, value);
    }

    /// <summary>
    /// Gets the target "To" point of the primary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the target "To" point of the primary animation.
    /// </value>
    double IProgressBarTemplateSettings.ContainerAnimationEndPosition
    {
        get => (double)GetValue(ContainerAnimationEndPositionProperty);
        set => SetValue(ContainerAnimationEndPositionProperty, value);
    }

    /// <summary>
    /// Gets the "From" point of the secondary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the"From" point of the secondary animation.
    /// </value>
    double IProgressBarTemplateSettings.Container2AnimationStartPosition
    {
        get => (double)GetValue(Container2AnimationStartPositionProperty);
        set => SetValue(Container2AnimationStartPositionProperty, value);
    }

    /// <summary>
    /// Gets the target "To" point of the secondary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the target "To" point of the secondary animation.
    /// </value>
    double IProgressBarTemplateSettings.Container2AnimationEndPosition
    {
        get => (double)GetValue(Container2AnimationEndPositionProperty);
        set => SetValue(Container2AnimationEndPositionProperty, value);
    }

    /// <summary>
    /// Gets the stopped point of the "Ellipse" animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// The stopped point of the Ellipse animation that animates the <seealso cref="ProgressBar"/>.
    /// This is internally calculated as 1/3 of the <seealso cref="FrameworkElement.ActualWidth"/> of the control.
    /// </value>
    double IProgressBarTemplateSettings.EllipseAnimationWellPosition
    {
        get => (double)GetValue(EllipseAnimationWellPositionProperty);
        set => SetValue(EllipseAnimationWellPositionProperty, value);
    }

    /// <summary>
    /// Gets the "To" point of the "Ellipse" animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// The "To" point of the "Ellipse" animation that animates the <seealso cref="ProgressBar"/>.
    /// This is internally calculated as 2/3 of the <seealso cref="FrameworkElement.ActualWidth"/> of the control.
    /// </value>
    double IProgressBarTemplateSettings.EllipseAnimationEndPosition
    {
        get => (double)GetValue(EllipseAnimationEndPositionProperty);
        set => SetValue(EllipseAnimationEndPositionProperty, value);
    }

    /// <summary>
    /// Gets the template-defined diameter of the "Ellipse" element that is animated in a templated <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <remarks>
    /// This value might be 4, 5, or 6 pixels. This is controlled by the animations that exist in default ProgressBar templates.
    /// </remarks>
    /// <value>
    /// The "Ellipse" element width in pixels.
    /// </value>
    double IProgressBarTemplateSettings.EllipseDiameter
    {
        get => (double)GetValue(EllipseDiameterProperty);
        set => SetValue(EllipseDiameterProperty, value);
    }

    /// <summary>
    /// Gets the template-defined offset poisition of the "Ellipse" element that is animated in a templated <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <remarks>
    /// EllipseOffset might be 4, 7, or 9 pixels. This is controlled by the animations that exist in default <seealso cref="ProgressBar"/> templates.
    /// </remarks>
    /// <value>
    /// The "Ellipse" element offset in pixels.
    /// </value>
    double IProgressBarTemplateSettings.EllipseOffset
    {
        get => (double)GetValue(EllipseOffsetProperty);
        set => SetValue(EllipseOffsetProperty, value);
    }

    /// <summary>
    /// Gets the indicator length delta, which is useful for repositioning transitions.
    /// </summary>
    /// <value>
    /// The delta in pixels.
    /// </value>
    double IProgressBarTemplateSettings.IndicatorLengthDelta
    {
        get => (double)GetValue(IndicatorLengthDeltaProperty);
        set => SetValue(IndicatorLengthDeltaProperty, value);
    }
    #endregion
}
