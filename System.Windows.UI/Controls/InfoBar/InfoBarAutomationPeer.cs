using System.Windows.Automation.Peers;
using System.Windows.UI.Controls;

namespace System.Windows.UI.Automation.Peers;

/// <summary>
/// Предоставляет типы <seealso cref="InfoBar"/> для модели автоматизации пользовательского интерфейса.
/// </summary>
public class InfoBarAutomationPeer : FrameworkElementAutomationPeer
{
    #region Constructors
    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="InfoBarAutomationPeer"/>.
    /// </summary>
    /// <param name="owner">
    /// Рабочая область метаданных <seealso cref="InfoBar"/>,
    /// связанная с этим соединением <seealso cref="InfoBarAutomationPeer"/>.
    /// </param>
    public InfoBarAutomationPeer(InfoBar owner) : base(owner)
    {
    }
    #endregion

    #region Methods
    /// <summary>
    /// Получает имя объекта <seealso cref="InfoBar"/>, который связан
    /// с данным объектом <seealso cref="InfoBarAutomationPeer"/>.
    /// Данный метод вызывается методом <seealso cref="AutomationPeer.GetClassName"/>.
    /// </summary>
    /// <returns>
    /// Имя объекта <seealso cref="InfoBar"/>.
    /// </returns>
    protected override string GetClassNameCore()
    {
        return "InfoBar";
    }

    /// <summary>
    /// Получает тип элемента управления для объекта <seealso cref="InfoBar"/>,
    /// связанного с данным объектом <seealso cref="InfoBarAutomationPeer"/>.
    /// Данный метод вызывается методом <seealso cref="AutomationPeer.GetAutomationControlType"/>
    /// </summary>
    /// <returns>
    /// Значение перечисления <seealso cref="AutomationControlType.StatusBar"/>.
    /// </returns>
    protected override AutomationControlType GetAutomationControlTypeCore()
    {
        return AutomationControlType.StatusBar;
    }
    #endregion
}
