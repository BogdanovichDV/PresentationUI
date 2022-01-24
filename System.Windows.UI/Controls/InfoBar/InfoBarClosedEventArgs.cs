using System;

namespace System.Windows.UI.Controls;

/// <summary>
/// Предоставляет данные для события <seealso cref="InfoBar.Closed"/>.
/// </summary>
public class InfoBarClosedEventArgs : EventArgs
{
    #region Constructors
    /// <summary>
    /// Инициализирует новый экземпляр класса <seealso cref="InfoBarClosedEventArgs"/>.
    /// </summary>
    /// <remarks>
    /// Не предназначен для общего пользования.
    /// </remarks>
    /// <param name="reason">
    /// Константа, указывающая, было ли причиной события <seealso cref="InfoBar.Closed"/>
    /// взаимодействие пользователя (нажатие кнопки «Закрыть») или программное закрытие.
    /// </param>
    internal InfoBarClosedEventArgs(InfoBarCloseReason reason)
    {
        Reason = reason;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Получает константу, указывающую, было ли причиной события <seealso cref="InfoBar.Closed"/>
    /// взаимодействие пользователя (нажатие кнопки «Закрыть») или программное закрытие.
    /// </summary>
    /// <value>
    /// Константа, указывающая, было ли причиной события <seealso cref="InfoBar.Closed"/>
    /// взаимодействие пользователя (нажатие кнопки «Закрыть») или программное закрытие.
    /// </value>
    public InfoBarCloseReason Reason { get; }
    #endregion
}
