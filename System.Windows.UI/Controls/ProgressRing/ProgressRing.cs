using System.ComponentModel;
using System.Windows.Controls;

using System.Windows.UI.Controls.Primitives;

namespace System.Windows.UI.Controls;

/// <summary>
/// Представляет элемент управления, который указывает на ход выполнения операции.
/// Типичный внешний вид - кольцеобразный "спиннер".
/// </summary>
[TemplateVisualState(GroupName = GroupSizeStates, Name = StateSmall)]
[TemplateVisualState(GroupName = GroupSizeStates, Name = StateLarge)]
[TemplateVisualState(GroupName = GroupActiveStates, Name = StateActive)]
[TemplateVisualState(GroupName = GroupActiveStates, Name = StateInactive)]
public class ProgressRing : Control
{
    #region Constants
    private const string GroupSizeStates = "SizeStates";
    private const string StateSmall = "Small";
    private const string StateLarge = "Large";
    private const string GroupActiveStates = "ActiveStates";
    private const string StateActive = "Active";
    private const string StateInactive = "Inactive";
    #endregion

    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="IsActive"/>.
    /// </summary>
    public static readonly DependencyProperty IsActiveProperty =
        DependencyProperty.Register("IsActive", typeof(bool), typeof(ProgressRing),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnIsActivePropertyChanged)));

    /// <summary>
    /// Идентифицирует ключ свойства зависимостей <seealso cref="TemplateSettings"/>.
    /// </summary>
    private static readonly DependencyPropertyKey TemplateSettingsPropertyKey =
        DependencyProperty.RegisterReadOnly("TemplateSettings", typeof(ProgressRingTemplateSettings), typeof(ProgressRing),
            new PropertyMetadata(null));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="TemplateSettings"/>.
    /// </summary>
    public static readonly DependencyProperty TemplateSettingsProperty = TemplateSettingsPropertyKey.DependencyProperty;

    private bool m_IsLarge;
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует статические данные класса <seealso cref="ProgressRing"/>.
    /// </summary>
    static ProgressRing()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ProgressRing), new FrameworkPropertyMetadata(typeof(ProgressRing)));
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="ProgressRing"/>.
    /// </summary>
    public ProgressRing()
    {
        ProgressRingTemplateSettings templateSettings = new();
        SetValue(TemplateSettingsPropertyKey, templateSettings);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает или задает значение, указывающее, показывает ли <seealso cref="ProgressRing"/> прогресс.
    /// </summary>
    /// <value>
    /// <see langword="true"/>, если индикатор прогресса показывает прогресс; в противном случае - <see langword="false"/>.
    /// Значение по умолчанию равно <see langword="false"/>.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Получает или задает значение, указывающее, показывает ли ProgressRing прогресс.")]
    public bool IsActive
    {
        get => (bool)GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }

    /// <summary>
    /// Получает объект, который предоставляет вычисляемые значения, на которые можно ссылаться как на источники
    /// TemplateBinding при определении шаблонов для элемента управления <seealso cref="ProgressRing"/>.
    /// </summary>
    /// <value>
    /// Объект, предоставляющий вычисляемые значения для шаблонов.
    /// </value>
    [ReadOnly(true)]
    [Bindable(true)]
    public ProgressRingTemplateSettings TemplateSettings
    {
        get => (ProgressRingTemplateSettings)GetValue(TemplateSettingsProperty);
    }

    private bool IsLarge
    {
        get => m_IsLarge;

        set
        {
            if (m_IsLarge != value)
            {
                m_IsLarge = value;
                ChangeSizeState();
            }
        }
    }
    #endregion

    #region Overridden Methods
    /// <summary>
    /// При переопределении в производном классе вызывается всякий раз, когда код приложения
    /// или внутренние процессы вызывают <seealso cref="FrameworkElement.ApplyTemplate"/>.
    /// </summary>
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        // Обновите визуальное состояние элемента управления.
        ChangeVisualState();
    }

    /// <summary>
    /// Вызывает событие <seealso cref="FrameworkElement.SizeChanged"/>, используя заданную информацию как часть итоговых данных события.
    /// </summary>
    /// <param name="sizeInfo">
    /// Сведения о старом и новом размерах при изменении.
    /// </param>
    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        ApplyTemplateSettings();
        base.OnRenderSizeChanged(sizeInfo);
    }
    #endregion

    #region Methods
    private static void OnIsActivePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        ProgressRing progressRing = (ProgressRing)sender;
        // Обновите визуальное состояние элемента управления.
        progressRing.ChangeVisualState();
    }

    private void ChangeVisualState()
    {
        VisualStateManager.GoToState(this, IsActive ? StateActive : StateInactive, true);
    }

    private void ChangeSizeState()
    {
        VisualStateManager.GoToState(this, IsLarge ? StateLarge : StateSmall, true);
    }

    private void ApplyTemplateSettings()
    {
        IProgressRingTemplateSettings templateSettings = TemplateSettings;

        double width = 0;
        double diamaterValue = 0;
        double anchorPoint = 0;

        if (ActualWidth > 0)
        {
            width = Math.Min(ActualWidth, ActualHeight);
            double diameterAdditive = (width <= 40.0d) ? 1.0d : 0.0d;
            diamaterValue = (width * 0.1d) + diameterAdditive;
            anchorPoint = (width * 0.5d) - diamaterValue;
        }

        Thickness thicknessEllipseOffset = new(0, anchorPoint, 0, 0);

        templateSettings.EllipseDiameter = diamaterValue;
        templateSettings.EllipseOffset = thicknessEllipseOffset;
        templateSettings.MaxSideLength = width;

        IsLarge = width >= 60;
    }
    #endregion
}
