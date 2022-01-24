using System;

namespace System.Windows.UI.Controls
{
    /// <summary>
    /// Предоставляет данные для события <seealso cref="InfoBar.Closing"/>.
    /// </summary>
    public class InfoBarClosingEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр класса <seealso cref="InfoBarClosingEventArgs"/>.
        /// </summary>
        /// <remarks>
        /// Не предназначен для общего пользования.
        /// </remarks>
        /// <param name="reason">
        /// Константа, указывающая, было ли причиной события <seealso cref="InfoBar.Closing"/>
        /// взаимодействие пользователя (нажатие кнопки «Закрыть») или программное закрытие.
        /// </param>
        internal InfoBarClosingEventArgs(InfoBarCloseReason reason)
        {
            Reason = reason;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Получает или задает значение, указывающее, следует ли отменить событие <seealso cref="InfoBar.Closing"/> в информационной панели.
        /// </summary>
        /// <value>
        /// Значение - <see langword="true"/>, если событие <seealso cref="InfoBar.Closing"/> отменено; в противном случае - <see langword="false"/>.
        /// </value>
        public bool Cancel { get; set; }

        /// <summary>
        /// Получает константу, указывающую, было ли причиной события <seealso cref="InfoBar.Closing"/>
        /// взаимодействие пользователя (нажатие кнопки «Закрыть») или программное закрытие.
        /// </summary>
        /// <value>
        /// Константа, указывающая, было ли причиной события <seealso cref="InfoBar.Closing"/>
        /// взаимодействие пользователя (нажатие кнопки «Закрыть») или программное закрытие.
        /// </value>
        public InfoBarCloseReason Reason { get; }
        #endregion
    }
}
