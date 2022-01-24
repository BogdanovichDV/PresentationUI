using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

using System.Windows.UI.Controls.Primitives;

namespace System.Windows.UI.Controls;

/// <summary>
/// Represents a control that indicates the progress of an operation.
/// </summary>
[TemplatePart(Type = typeof(Grid), Name = ElementLayoutRootName)]
[TemplatePart(Type = typeof(Rectangle), Name = ElementDeterminateProgressBarIndicatorName)]
[TemplatePart(Type = typeof(Rectangle), Name = ElementIndeterminateProgressBarIndicatorName)]
[TemplatePart(Type = typeof(Rectangle), Name = ElementIndeterminateProgressBarIndicator2Name)]
[TemplateVisualState(GroupName = GroupCommonStates, Name = StateError)]
[TemplateVisualState(GroupName = GroupCommonStates, Name = StatePaused)]
[TemplateVisualState(GroupName = GroupCommonStates, Name = StateIndeterminate)]
[TemplateVisualState(GroupName = GroupCommonStates, Name = StateIndeterminateError)]
[TemplateVisualState(GroupName = GroupCommonStates, Name = StateIndeterminatePaused)]
[TemplateVisualState(GroupName = GroupCommonStates, Name = StateDeterminate)]
[TemplateVisualState(GroupName = GroupCommonStates, Name = StateUpdating)]
public class ProgressBar : RangeBase
{
    #region Constants
    private const string GroupCommonStates = "CommonStates";
    private const string StateError = "Error";
    private const string StatePaused = "Paused";
    private const string StateIndeterminate = "Indeterminate";
    private const string StateIndeterminateError = "IndeterminateError";
    private const string StateIndeterminatePaused = "IndeterminatePaused";
    private const string StateDeterminate = "Determinate";
    private const string StateUpdating = "Updating";

    private const string ElementLayoutRootName = "LayoutRoot";
    private const string ElementDeterminateProgressBarIndicatorName = "DeterminateProgressBarIndicator";
    private const string ElementIndeterminateProgressBarIndicatorName = "IndeterminateProgressBarIndicator";
    private const string ElementIndeterminateProgressBarIndicator2Name = "IndeterminateProgressBarIndicator2";
    #endregion

    #region Fields        
    /// <summary>
    /// Identifies the <seealso cref="IsIndeterminate"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsIndeterminateProperty =
        DependencyProperty.Register("IsIndeterminate", typeof(bool), typeof(ProgressBar),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnIsIndeterminateChanged)));

    /// <summary>
    /// Identifies the <seealso cref="ShowError"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty ShowErrorProperty =
        DependencyProperty.Register("ShowError", typeof(bool), typeof(ProgressBar),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnShowErrorChanged)));

    /// <summary>
    /// Identifies the <seealso cref="ShowPaused"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty ShowPausedProperty =
        DependencyProperty.Register("ShowPaused", typeof(bool), typeof(ProgressBar),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnShowPausedChanged)));

    /// <summary>
    /// Identifies the <seealso cref="TemplateSettings"/> dependency property key.
    /// </summary>
    private static readonly DependencyPropertyKey TemplateSettingsPropertyKey =
        DependencyProperty.RegisterReadOnly("TemplateSettings",typeof(ProgressBarTemplateSettings),typeof(ProgressBar),
            new PropertyMetadata(null));

    /// <summary>
    /// Identifies the <seealso cref="TemplateSettings"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty TemplateSettingsProperty =
        TemplateSettingsPropertyKey.DependencyProperty;

    private Grid m_layoutRoot;
    private Rectangle m_determinateProgressBarIndicator;
    private Rectangle m_indeterminateProgressBarIndicator;
    private Rectangle m_indeterminateProgressBarIndicator2;
    #endregion

    #region Constructors
    static ProgressBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ProgressBar),
            new FrameworkPropertyMetadata(typeof(ProgressBar)));
        ValueProperty.OverrideMetadata(typeof(ProgressBar),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnRangeBasePropertyChanged)));
        MinimumProperty.OverrideMetadata(typeof(ProgressBar),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnRangeBasePropertyChanged)));
        MaximumProperty.OverrideMetadata(typeof(ProgressBar),
            new FrameworkPropertyMetadata(100.0d, new PropertyChangedCallback(OnRangeBasePropertyChanged)));
        PaddingProperty.OverrideMetadata(typeof(ProgressBar),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPaddingChanged)));
    }

    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProgressBar"/> class.
    /// </summary>
    public ProgressBar()
    {
        ProgressBarTemplateSettings templateSettings = new();
        SetValue(TemplateSettingsPropertyKey, templateSettings);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets a value that indicates whether the progress bar reports generic progress
    /// with a repeating pattern or reports progress based on the Value property.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the progress bar reports generic progress with a repeating pattern;
    /// <see langword="false"/> if the progress bar reports progress based on the Value property.
    /// The default is <see langword="false"/>.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Gets or sets a value that indicates whether the progress bar reports generic progress with a repeating pattern or reports progress based on the Value property.")]
    public bool IsIndeterminate
    {
        get => (bool)GetValue(IsIndeterminateProperty);
        set => SetValue(IsIndeterminateProperty, value);
    }

    /// <summary>
    /// Gets or sets a value that indicates whether the progress bar
    /// should use visual states that communicate an Error state to the user.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the progress bar should use visual states
    /// that communicate an Error state to the user; otherwise, <see langword="false"/>.
    /// The default is <see langword="false"/>.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Gets or sets a value that indicates whether the progress bar should use visual states that communicate an Error state to the user.")]
    public bool ShowError
    {
        get => (bool)GetValue(ShowErrorProperty);
        set => SetValue(ShowErrorProperty, value);
    }

    /// <summary>
    /// Gets or sets a value that indicates whether the progress bar
    /// should use visual states that communicate a Paused state to the user.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the progress bar should use visual states
    /// that communicate a Paused state to the user; otherwise, <see langword="false"/>.
    /// The default is <see langword="false"/>.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Gets or sets a value that indicates whether the progress bar should use visual states that communicate a Paused state to the user.")]
    public bool ShowPaused
    {
        get => (bool)GetValue(ShowPausedProperty);
        set => SetValue(ShowPausedProperty, value);
    }

    /// <summary>
    /// Gets an object that provides calculated values that can be referenced as TemplateBinding
    /// sources when defining templates for a <seealso cref="ProgressBar"/> control.
    /// </summary>
    /// <value>
    /// An object that provides calculated values for templates.
    /// </value>
    [ReadOnly(true)]
    [Bindable(true)]
    public ProgressBarTemplateSettings TemplateSettings
    {
        get => (ProgressBarTemplateSettings)GetValue(TemplateSettingsProperty);
        init => SetValue(TemplateSettingsPropertyKey, value);
    }
    #endregion

    #region Overridden Methods
    /// <summary>
    /// When overridden in a derived class, is invoked whenever application code
    /// or internal processes call <seealso cref="FrameworkElement.ApplyTemplate"/>.
    /// </summary>
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        // NOTE: Example of how named parts are loaded from the template. Important to remember that it's possible for
        // any of them not to be found, since devs can replace the template with their own.

        m_layoutRoot = GetTemplateChild(ElementLayoutRootName) as Grid;
        m_determinateProgressBarIndicator = GetTemplateChild(ElementDeterminateProgressBarIndicatorName) as Rectangle;
        m_indeterminateProgressBarIndicator = GetTemplateChild(ElementIndeterminateProgressBarIndicatorName) as Rectangle;
        m_indeterminateProgressBarIndicator2 = GetTemplateChild(ElementIndeterminateProgressBarIndicator2Name) as Rectangle;

        UpdateStates();
    }

    /// <summary>
    /// Вызывает событие <seealso cref="FrameworkElement.SizeChanged"/>, используя заданную информацию как часть итоговых данных события.
    /// </summary>
    /// <param name="sizeInfo">
    /// Сведения о старом и новом размерах при изменении.
    /// </param>
    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);
        UpdateWidthBasedTemplateSettings();
        SetProgressBarIndicatorWidth();
    }
    #endregion

    #region Methods
    private static void OnRangeBasePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        ProgressBar progressBar = (ProgressBar)sender;
        progressBar.SetProgressBarIndicatorWidth();
    }

    private static void OnIsIndeterminateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        ProgressBar progressBar = (ProgressBar)sender;
        progressBar.SetProgressBarIndicatorWidth();
        progressBar.UpdateStates();
    }

    private static void OnShowErrorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        ProgressBar progressBar = (ProgressBar)sender;
        progressBar.UpdateStates();
    }

    private static void OnShowPausedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        ProgressBar progressBar = (ProgressBar)sender;
        progressBar.UpdateStates();
    }

    private static void OnPaddingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        ProgressBar progressBar = (ProgressBar)sender;
        progressBar.SetProgressBarIndicatorWidth();
    }

    private void UpdateStates()
    {
        if (ShowError && IsIndeterminate)
        {
            VisualStateManager.GoToState(this, StateIndeterminateError, true);
            Debug.WriteLine("StateIndeterminateError");
        }
        else if (ShowError)
        {
            VisualStateManager.GoToState(this, StateError, true);
            Debug.WriteLine("StateError");
        }
        else if (ShowPaused && IsIndeterminate)
        {
            VisualStateManager.GoToState(this, StateIndeterminatePaused, true);
            Debug.WriteLine("StateIndeterminatePaused");
        }
        else if (ShowPaused)
        {
            VisualStateManager.GoToState(this, StatePaused, true);
            Debug.WriteLine("StatePaused");
        }
        else if (IsIndeterminate)
        {
            VisualStateManager.GoToState(this, StateIndeterminate, true);
            UpdateWidthBasedTemplateSettings();
            Debug.WriteLine("StateIndeterminate");
        }
        else if (!IsIndeterminate)
        {
            VisualStateManager.GoToState(this, StateDeterminate, true);
            Debug.WriteLine("StateDeterminate");
        }
    }

    private void SetProgressBarIndicatorWidth()
    {
        IProgressBarTemplateSettings templateSettings = TemplateSettings;

        if (m_layoutRoot is Grid progressBar)
        {
            if (m_determinateProgressBarIndicator is Rectangle determinateProgressBarIndicator)
            {
                double progressBarWidth = progressBar.ActualWidth;
                double prevIndicatorWidth = determinateProgressBarIndicator.ActualWidth;
                double maximum = Maximum;
                double minimum = Minimum;
                Thickness padding = Padding;

                // Adds "Updating" state in between to trigger RepositionThemeAnimation Visual Transition
                // in ProgressBar.xaml when reverting back to previous state
                VisualStateManager.GoToState(this, StateUpdating, true);
                Debug.WriteLine("StateUpdating");

                if (IsIndeterminate)
                {
                    determinateProgressBarIndicator.Width = 0;

                    if (m_indeterminateProgressBarIndicator is Rectangle indeterminateProgressBarIndicator)
                    {
                        // 40% of ProgressBar Width
                        indeterminateProgressBarIndicator.Width = progressBarWidth * 0.4;
                    }

                    if (m_indeterminateProgressBarIndicator2 is Rectangle indeterminateProgressBarIndicator2)
                    {
                        // 60% of ProgressBar Width
                        indeterminateProgressBarIndicator2.Width = progressBarWidth * 0.6;
                    }
                }
                else if (maximum - minimum > double.Epsilon)
                {
                    double maxIndicatorWidth = progressBarWidth - (padding.Left + padding.Right);
                    double increment = maxIndicatorWidth / (maximum - minimum);
                    double indicatorWidth = increment * (Value - minimum);
                    double widthDelta = indicatorWidth - prevIndicatorWidth;
                    templateSettings.IndicatorLengthDelta = -widthDelta;
                    determinateProgressBarIndicator.Width = indicatorWidth;
                }
                else
                {
                    // Error
                    determinateProgressBarIndicator.Width = 0;
                }

                // Reverts back to previous state
                UpdateStates();
            }
        }
    }

    private void UpdateWidthBasedTemplateSettings()
    {
        IProgressBarTemplateSettings templateSettings = TemplateSettings;

        double width = 0;
        double height = 0;

        if (m_layoutRoot is Grid progressBar)
        {
            width = progressBar.ActualWidth;
            height = progressBar.ActualHeight;
        }

        // Indicator width at 40% of ProgressBar
        double indeterminateProgressBarIndicatorWidth = width * 0.4;
        // Indicator width at 60% of ProgressBar
        double indeterminateProgressBarIndicatorWidth2 = width * 0.6;

        // Position at -100%
        templateSettings.ContainerAnimationStartPosition = indeterminateProgressBarIndicatorWidth * -1.0;
        // Position at 300%
        templateSettings.ContainerAnimationEndPosition = indeterminateProgressBarIndicatorWidth * 3.0;

        // Position at -150%
        templateSettings.Container2AnimationStartPosition = indeterminateProgressBarIndicatorWidth2 * -1.5;
        // Position at 166%
        templateSettings.Container2AnimationEndPosition = indeterminateProgressBarIndicatorWidth2 * 1.66;

        // Position at 50%
        templateSettings.ContainerAnimationMidPosition = width * 0.2;

        Thickness padding = Padding;

        RectangleGeometry clipRect = new();
        clipRect.Rect = new Rect(padding.Left, padding.Top, width - (padding.Right + padding.Left), height - (padding.Bottom + padding.Top));
        templateSettings.ClipRect = clipRect;

        templateSettings.EllipseAnimationEndPosition = 1.0 / 3.0 * width;
        templateSettings.EllipseAnimationWellPosition = 2.0 / 3.0 * width;

        if (width <= 180.0)
        {
            // Small ellipse diameter and offset.
            templateSettings.EllipseDiameter = 4.0;
            templateSettings.EllipseOffset = 4.0;
        }
        else if (width <= 280.0)
        {
            // Medium ellipse diameter and offset.
            templateSettings.EllipseDiameter = 6.0;
            templateSettings.EllipseOffset = 7.0;
        }
        else
        {
            // Large ellipse diameter and offset
            templateSettings.EllipseDiameter = 6.0;
            templateSettings.EllipseOffset = 9.0;
        }
    }
    #endregion
}
