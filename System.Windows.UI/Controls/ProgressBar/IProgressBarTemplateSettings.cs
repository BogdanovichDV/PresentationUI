using System.Windows.Media;

namespace System.Windows.UI.Controls.Primitives;

/// <summary>
/// Provides calculated values that can be referenced as TemplatedParent sources
/// when defining templates for a <seealso cref="ProgressBar"/> control.
/// Not intended for general use.
/// </summary>
internal interface IProgressBarTemplateSettings
{
    #region Properties
    /// <summary>
    /// Gets the <seealso cref="Rect"/> that describes the clipped area of the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A <seealso cref="Rect"/> that describes the clipped area of the <seealso cref="ProgressBar"/>.
    /// </value>
    RectangleGeometry ClipRect { get; set; }

    /// <summary>
    /// Gets the "From" point of the primary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the"From" point of the primary animation.
    /// </value>
    double ContainerAnimationStartPosition { get; set; }

    /// <summary>
    /// Gets the target midpoint of the container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the midpoint of the animation.
    /// </value>
    double ContainerAnimationMidPosition { get; set; }

    /// <summary>
    /// Gets the target "To" point of the primary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the target "To" point of the primary animation.
    /// </value>
    double ContainerAnimationEndPosition { get; set; }

    /// <summary>
    /// Gets the "From" point of the secondary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the"From" point of the secondary animation.
    /// </value>
    double Container2AnimationStartPosition { get; set; }

    /// <summary>
    /// Gets the target "To" point of the secondary container animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// A double that represents the orientation-specific x- or y-value that is the target "To" point of the secondary animation.
    /// </value>
    double Container2AnimationEndPosition { get; set; }

    /// <summary>
    /// Gets the stopped point of the "Ellipse" animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// The stopped point of the Ellipse animation that animates the <seealso cref="ProgressBar"/>.
    /// This is internally calculated as 1/3 of the <seealso cref="FrameworkElement.ActualWidth"/> of the control.
    /// </value>
    double EllipseAnimationWellPosition { get; set; }

    /// <summary>
    /// Gets the "To" point of the "Ellipse" animation that animates the <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// The "To" point of the "Ellipse" animation that animates the <seealso cref="ProgressBar"/>.
    /// This is internally calculated as 2/3 of the <seealso cref="FrameworkElement.ActualWidth"/> of the control.
    /// </value>
    double EllipseAnimationEndPosition { get; set; }

    /// <summary>
    /// Gets the template-defined diameter of the "Ellipse" element that is animated in a templated <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// The "Ellipse" element width in pixels.
    /// </value>
    double EllipseDiameter { get; set; }

    /// <summary>
    /// Gets the template-defined offset poisition of the "Ellipse" element that is animated in a templated <seealso cref="ProgressBar"/>.
    /// </summary>
    /// <value>
    /// The "Ellipse" element offset in pixels.
    /// </value>
    double EllipseOffset { get; set; }

    /// <summary>
    /// Gets the indicator length delta, which is useful for repositioning transitions.
    /// </summary>
    /// <value>
    /// The delta in pixels.
    /// </value>
    double IndicatorLengthDelta { get; set; }
    #endregion
}
