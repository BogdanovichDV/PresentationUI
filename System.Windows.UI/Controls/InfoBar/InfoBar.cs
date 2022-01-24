using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;

using System.Windows.UI.Automation.Peers;
using System.Windows.UI.Controls.Primitives;

namespace System.Windows.UI.Controls;

/// <summary>
/// InfoBar - это встроенное уведомление для важных сообщений приложения.
/// </summary>
[TemplatePart(Name = ElementCloseButtonName)]
[TemplatePart(Name = ElementContentRootName)]
[TemplatePart(Name = ElementIconTextBlockName)]
[TemplateVisualState(GroupName = GroupInfoBarStates, Name = StateInfoBarVisible)]
[TemplateVisualState(GroupName = GroupInfoBarStates, Name = StateInfoBarCollapsed)]
[TemplateVisualState(GroupName = GroupCloseButtonStates, Name = StateCloseButtonVisible)]
[TemplateVisualState(GroupName = GroupCloseButtonStates, Name = StateCloseButtonCollapsed)]
[TemplateVisualState(GroupName = GroupIconStates, Name = StateUserIconVisible)]
[TemplateVisualState(GroupName = GroupIconStates, Name = StateStandardIconVisible)]
[TemplateVisualState(GroupName = GroupIconStates, Name = StateNoIconVisible)]
[TemplateVisualState(GroupName = GroupSeverityLevels, Name = StateInformational)]
[TemplateVisualState(GroupName = GroupSeverityLevels, Name = StateSuccess)]
[TemplateVisualState(GroupName = GroupSeverityLevels, Name = StateWarning)]
[TemplateVisualState(GroupName = GroupSeverityLevels, Name = StateError)]
[ContentProperty("Content")]
public class InfoBar : Control
{
    #region Constants
    private const string GroupInfoBarStates = "InfoBarStates";
    private const string StateInfoBarVisible = "InfoBarVisible";
    private const string StateInfoBarCollapsed = "InfoBarCollapsed";

    private const string GroupCloseButtonStates = "CloseButtonStates";
    private const string StateCloseButtonVisible = "CloseButtonVisible";
    private const string StateCloseButtonCollapsed = "CloseButtonCollapsed";

    private const string GroupIconStates = "IconStates";
    private const string StateUserIconVisible = "UserIconVisible";
    private const string StateStandardIconVisible = "StandardIconVisible";
    private const string StateNoIconVisible = "NoIconVisible";

    private const string GroupSeverityLevels = "SeverityLevels";
    private const string StateInformational = "Informational";
    private const string StateSuccess = "Success";
    private const string StateWarning = "Warning";
    private const string StateError = "Error";

    private const string ElementCloseButtonName = "PART_CloseButton";
    private const string ElementContentRootName = "PART_ContentRoot";
    private const string ElementIconTextBlockName = "PART_StandardIcon";
    #endregion

    #region Fields
    /// <summary>
    /// Идентифицирует свойство зависимостей для ограниченного доступа на запись
    /// к доступному только для чтения свойству зависимостей <seealso cref="TemplateSettings"/>.
    /// </summary>
    private static readonly DependencyPropertyKey TemplateSettingsPropertyKey =
        DependencyProperty.RegisterReadOnly("TemplateSettings", typeof(InfoBarTemplateSettings), typeof(InfoBar),
            new FrameworkPropertyMetadata(null));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="ActionButton"/>.
    /// </summary>
    public static readonly DependencyProperty ActionButtonProperty =
        DependencyProperty.Register("ActionButton", typeof(ButtonBase), typeof(InfoBar),
            new FrameworkPropertyMetadata(null));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="CloseButtonCommand"/>.
    /// </summary>
    public static readonly DependencyProperty CloseButtonCommandProperty =
        DependencyProperty.Register("CloseButtonCommand", typeof(ICommand), typeof(InfoBar),
            new FrameworkPropertyMetadata(null));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="CloseButtonCommandParameter"/>.
    /// </summary>
    public static readonly DependencyProperty CloseButtonCommandParameterProperty =
        DependencyProperty.Register("CloseButtonCommandParameter", typeof(object), typeof(InfoBar),
            new FrameworkPropertyMetadata(null));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="CloseButtonStyle"/>.
    /// </summary>
    public static readonly DependencyProperty CloseButtonStyleProperty =
        DependencyProperty.Register("CloseButtonStyle", typeof(Style), typeof(InfoBar),
            new FrameworkPropertyMetadata(null));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Content"/>.
    /// </summary>
    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register("Content", typeof(object), typeof(InfoBar),
            new FrameworkPropertyMetadata(null));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="ContentTemplate"/>.
    /// </summary>
    public static readonly DependencyProperty ContentTemplateProperty =
        DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(InfoBar),
            new FrameworkPropertyMetadata(null));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="IconSource"/>.
    /// </summary>
    public static readonly DependencyProperty IconSourceProperty =
        DependencyProperty.Register("IconSource", typeof(IconSource), typeof(InfoBar),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnIconSourceChanged)));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="IsClosable"/>.
    /// </summary>
    public static readonly DependencyProperty IsClosableProperty =
        DependencyProperty.Register("IsClosable", typeof(bool), typeof(InfoBar),
            new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnIsClosableChanged)));
    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="IsIconVisible"/>.
    /// </summary>
    public static readonly DependencyProperty IsIconVisibleProperty =
        DependencyProperty.Register("IsIconVisible", typeof(bool), typeof(InfoBar),
            new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnIsIconVisibleChanged)));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="IsOpen"/>.
    /// </summary>
    public static readonly DependencyProperty IsOpenProperty =
        DependencyProperty.Register("IsOpen", typeof(bool), typeof(InfoBar),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnIsOpenChanged)));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Severity"/>.
    /// </summary>
    public static readonly DependencyProperty SeverityProperty =
        DependencyProperty.Register("Severity", typeof(InfoBarSeverity), typeof(InfoBar),
            new FrameworkPropertyMetadata(InfoBarSeverity.Informational, new PropertyChangedCallback(OnSeverityChanged)),
            new ValidateValueCallback(ValidateSeverity));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Title"/>.
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(InfoBar),
            new FrameworkPropertyMetadata(string.Empty));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="Message"/>.
    /// </summary>
    public static readonly DependencyProperty MessageProperty =
        DependencyProperty.Register("Message", typeof(string), typeof(InfoBar),
            new FrameworkPropertyMetadata(string.Empty));

    /// <summary>
    /// Идентифицирует свойство зависимостей <seealso cref="TemplateSettings"/>.
    /// </summary>
    public static readonly DependencyProperty TemplateSettingsProperty =
        TemplateSettingsPropertyKey.DependencyProperty;

    private ButtonBase m_CloseButton;
    private InfoBarCloseReason m_LastCloseReason = InfoBarCloseReason.Programmatic;
    #endregion

    #region Constructors
    /// <summary>
    /// Инициализирует статические данные класса <seealso cref="InfoBar"/>.
    /// </summary>
    static InfoBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(InfoBar),
            new FrameworkPropertyMetadata(typeof(InfoBar)));
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="InfoBar"/>.
    /// </summary>
    public InfoBar()
    {
        TemplateSettings = new InfoBarTemplateSettings();
    }
    #endregion


    #region Properties
    /// <summary>
    /// Получает или задает кнопку действия информационной панели.
    /// </summary>
    /// <value>
    /// Кнопка действия на информационной панели. По умолчанию - <see langword="null"/>.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Получает или задает кнопку действия информационной панели.")]
    public ButtonBase ActionButton
    {
        get => (ButtonBase)GetValue(ActionButtonProperty);
        set => SetValue(ActionButtonProperty, value);
    }

    /// <summary>
    /// Получает или задает команду, вызываемую при нажатии кнопки закрытия на информационной панели.
    /// </summary>
    /// <value>
    /// Команда, вызываемая при нажатии кнопки закрытия на информационной панели. По умолчанию - <see langword="null"/>.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Получает или задает команду, вызываемую при нажатии кнопки закрытия на информационной панели.")]
    public ICommand CloseButtonCommand
    {
        get => (ICommand)GetValue(CloseButtonCommandProperty);
        set => SetValue(CloseButtonCommandProperty, value);
    }

    /// <summary>
    /// Получает или задает параметр, передаваемый команде для кнопки закрытия на информационной панели.
    /// </summary>
    /// <value>
    /// Параметр, передаваемый команде для кнопки закрытия на информационной панели. По умолчанию - <see langword="null"/>.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Получает или задает параметр, передаваемый команде для кнопки закрытия на информационной панели.")]
    public object CloseButtonCommandParameter
    {
        get => (ButtonBase)GetValue(CloseButtonCommandParameterProperty);
        set => SetValue(CloseButtonCommandParameterProperty, value);
    }

    /// <summary>
    /// Получает или задает стиль для применения к кнопке закрытия на информационной панели.
    /// </summary>
    /// <value>
    /// Стиль, применяемый к кнопке закрытия на информационной панели.
    /// </value>
    [Bindable(true)]
    [Description("Получает или задает стиль для применения к кнопке закрытия на информационной панели.")]
    public Style CloseButtonStyle
    {
        get => (Style)GetValue(CloseButtonStyleProperty);
        set => SetValue(CloseButtonStyleProperty, value);
    }

    /// <summary>
    /// Получает или задает содержимое XAML, которое отображается под заголовком и сообщением в информационной панели.
    /// </summary>
    /// <value>
    /// Содержимое XAML, которое отображается под заголовком и сообщением в информационной панели.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Получает или задает содержимое XAML, которое отображается под заголовком и сообщением в информационной панели.")]
    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    /// <summary>
    /// Получает или задает шаблон данных для <seealso cref="Content"/>.
    /// </summary>
    /// <value>
    /// Шаблон данных, который используется для отображения содержимого информационной панели.
    /// </value>
    [Bindable(true)]
    [Description("Получает или задает шаблон данных для InfoBar.Content.")]
    public DataTemplate ContentTemplate
    {
        get => (DataTemplate)GetValue(ContentTemplateProperty);
        set => SetValue(ContentTemplateProperty, value);
    }

    /// <summary>
    /// Получает или задает графическое содержимое, которое будет отображаться рядом с заголовком и сообщением на информационной панели.
    /// </summary>
    /// <value>
    /// Графический контент, который будет отображаться рядом с заголовком и сообщением на информационной панели.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Получает или задает графическое содержимое, которое будет отображаться рядом с заголовком и сообщением на информационной панели.")]
    public IconSource IconSource
    {
        get => (IconSource)GetValue(IconSourceProperty);
        set => SetValue(IconSourceProperty, value);
    }

    /// <summary>
    /// Получает или задает значение, указывающее, может ли пользователь закрыть информационную панель.
    /// </summary>
    /// <value>
    /// <see langword="true"/>, если пользователь может закрыть информационную панель; в противном случае - <see langword="false"/>. По умолчанию - <see langword="true"/>.
    /// </value>        
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Получает или задает значение, указывающее, может ли пользователь закрыть информационную панель.")]
    public bool IsClosable
    {
        get => (bool)GetValue(IsClosableProperty);
        set => SetValue(IsClosableProperty, value);
    }

    /// <summary>
    /// Получает или задает значение, указывающее, отображается ли значок на информационной панели.
    /// </summary>
    /// <value>
    /// <see langword="true"/>, если значок виден; в противном случае - <see langword="false"/>. По умолчанию - <see langword="true"/>.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Получает или задает значение, указывающее, отображается ли значок на информационной панели.")]
    public bool IsIconVisible
    {
        get => (bool)GetValue(IsIconVisibleProperty);
        set => SetValue(IsIconVisibleProperty, value);
    }

    /// <summary>
    /// Возвращает или задает значение, указывающее, открыта ли информационная панель.
    /// </summary>
    /// <value>
    /// <see langword="true"/>, если информационная панель открыта; в противном случае - <see langword="false"/>. По умолчанию - <see langword="false"/>.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Возвращает или задает значение, указывающее, открыта ли информационная панель.")]
    public bool IsOpen
    {
        get => (bool)GetValue(IsOpenProperty);
        set => SetValue(IsOpenProperty, value);
    }

    /// <summary>
    /// Получает или задает тип информационной панели для применения согласованного цвета состояния, значка и параметров вспомогательных технологий в зависимости от важности уведомления.
    /// </summary>
    /// <value>
    /// Стиль информационной панели, указывающий на важность уведомления. Значение по умолчанию - <seealso cref="InfoBarSeverity.Informational"/>.
    /// </value>        
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Получает или задает тип информационной панели для применения согласованного цвета состояния, значка и параметров вспомогательных технологий в зависимости от важности уведомления.")]
    public InfoBarSeverity Severity
    {
        get => (InfoBarSeverity)GetValue(SeverityProperty);
        set => SetValue(SeverityProperty, value);
    }

    /// <summary>
    /// Получает или задает заголовок информационной панели.
    /// </summary>
    /// <value>
    /// Заголовок информационной панели. По умолчанию - пустая строка.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Получает или задает заголовок информационной панели.")]
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// Получает или задает сообщение информационной панели.
    /// </summary>
    /// <value>
    /// Сообщение информационной панели. По умолчанию - пустая строка.
    /// </value>
    [Bindable(true)]
    [Category("Common Properties")]
    [Description("Получает или задает сообщение информационной панели.")]
    public string Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    /// <summary>
    /// Предоставляет вычисляемые значения, на которые можно ссылаться как на источники <seealso cref="FrameworkElement.TemplatedParent"/>
    /// при определении шаблонов для информационной панели. Не предназначен для общего пользования.
    /// </summary>
    /// <value>
    /// Объект, предоставляющий вычисляемые значения для шаблонов.
    /// </value>
    [ReadOnly(true)]
    [Bindable(true)]
    public InfoBarTemplateSettings TemplateSettings
    {
        get => (InfoBarTemplateSettings)GetValue(TemplateSettingsProperty);
        init => SetValue(TemplateSettingsPropertyKey, value);
    }
    #endregion

    #region Events
    /// <summary>
    /// Происходит после нажатия кнопки закрытия на информационной панели.
    /// </summary>
    public event EventHandler<object> CloseButtonClick;

    /// <summary>
    /// Происходит после закрытия информационной панели.
    /// </summary>
    public event EventHandler<InfoBarClosingEventArgs> Closing;

    /// <summary>
    /// Происходит непосредственно перед закрытием информационной панели.
    /// </summary>
    public event EventHandler<InfoBarClosedEventArgs> Closed;
    #endregion

    #region Overridden Methods
    /// <summary>
    /// Предоставляет соответствующую <seealso cref="InfoBarAutomationPeer"/> реализацию для этого элемента управления в составе инфраструктуры WPF.
    /// </summary>
    /// <returns>
    /// Реализация <seealso cref="AutomationPeer"/>, зависящая от конкретного типа.
    /// </returns>
    protected override AutomationPeer OnCreateAutomationPeer()
    {
        return new InfoBarAutomationPeer(this);
    }

    /// <summary>
    /// При переопределении в производном классе вызывается всякий раз, когда код приложения
    /// или внутренние процессы вызывают <seealso cref="FrameworkElement.ApplyTemplate"/>.
    /// </summary>
    public override void OnApplyTemplate()
    {
        if (m_CloseButton is not null)
        {
            m_CloseButton.Click -= OnCloseButtonClick;
        }

        base.OnApplyTemplate();

        m_CloseButton = GetTemplateChild(ElementCloseButtonName) as ButtonBase;

        if (m_CloseButton is not null)
        {
            m_CloseButton.Click += OnCloseButtonClick;

            ToolTip toolTip = new();
            toolTip.Content = "Зыкрыть";
            ToolTipService.SetToolTip(m_CloseButton, toolTip);
        }

        UpdateVisibility();
        UpdateSeverity();
        UpdateIcon();
        UpdateIconVisibility();
        UpdateCloseButton();
    }
    #endregion

    #region Methods
    private void OnCloseButtonClick(object sender, RoutedEventArgs e)
    {
        CloseButtonClick?.Invoke(this, null);
        m_LastCloseReason = InfoBarCloseReason.CloseButton;
        IsOpen = false;
    }

    private void RaiseClosingEvent()
    {
        InfoBarClosingEventArgs args = new(m_LastCloseReason);
        Closing?.Invoke(this, args);

        if (args.Cancel)
        {
            // Разработчик отменил событие RaiseClosingEvent(),
            // поэтому нам нужно вернуть свойство IsOpen на true.
            IsOpen = true;
        }
        else
        {
            UpdateVisibility();
            RaiseClosedEvent();
        }
    }

    private void RaiseClosedEvent()
    {
        InfoBarClosedEventArgs args = new(m_LastCloseReason);
        Closed?.Invoke(this, args);
    }

    private static void OnIsClosableChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        InfoBar infoBar = (InfoBar)sender;
        infoBar.UpdateCloseButton();
    }

    private static void OnIsIconVisibleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        InfoBar infoBar = (InfoBar)sender;
        infoBar.UpdateIconVisibility();
    }

    private static void OnIconSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        InfoBar infoBar = (InfoBar)sender;
        infoBar.UpdateIcon();
        infoBar.UpdateIconVisibility();
    }

    private void UpdateIcon()
    {
        InfoBarTemplateSettings templateSettings = TemplateSettings;

        if (IconSource is IconSource source)
        {
            templateSettings.IconElement = source.CreateIconElement();
        }
        else
        {
            templateSettings.IconElement = null;
        }
    }

    private static bool ValidateSeverity(object value)
    {
        InfoBarSeverity severity = (InfoBarSeverity)value;
        return severity is InfoBarSeverity.Informational or InfoBarSeverity.Success or InfoBarSeverity.Warning or InfoBarSeverity.Error;
    }

    private static void OnIsOpenChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        InfoBar infoBar = (InfoBar)sender;
        bool isOpen = (bool)args.NewValue;

        if (isOpen)
        {
            // Сбрасываем причину закрытия на значение по умолчанию programmatic.
            infoBar.m_LastCloseReason = InfoBarCloseReason.Programmatic;
            infoBar.UpdateVisibility();
        }
        else
        {
            infoBar.RaiseClosingEvent();
        }
    }

    private static void OnSeverityChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        InfoBar infoBar = (InfoBar)sender;
        infoBar.UpdateSeverity();
    }

    private void UpdateCloseButton()
    {
        if (IsClosable)
        {
            VisualStateManager.GoToState(this, StateCloseButtonVisible, false);
        }
        else
        {
            VisualStateManager.GoToState(this, StateCloseButtonCollapsed, false);
        }
    }

    private void UpdateIconVisibility()
    {
        if (IsIconVisible)
        {
            if (IconSource is null)
            {
                VisualStateManager.GoToState(this, StateStandardIconVisible, false);
            }
            else
            {
                VisualStateManager.GoToState(this, StateUserIconVisible, false);
            }
        }
        else
        {
            VisualStateManager.GoToState(this, StateNoIconVisible, false);
        }
    }

    private void UpdateSeverity()
    {
        string severityState = StateInformational;

        switch (Severity)
        {
            case InfoBarSeverity.Success:
                severityState = StateSuccess;
                break;
            case InfoBarSeverity.Warning:
                severityState = StateWarning;
                break;
            case InfoBarSeverity.Error:
                severityState = StateError;
                break;
        };

        VisualStateManager.GoToState(this, severityState, false);
    }

    private void UpdateVisibility()
    {
        if (IsOpen)
        {
            VisualStateManager.GoToState(this, StateInfoBarVisible, false);
        }
        else
        {
            VisualStateManager.GoToState(this, StateInfoBarCollapsed, false);
        }
    }
    #endregion
}
