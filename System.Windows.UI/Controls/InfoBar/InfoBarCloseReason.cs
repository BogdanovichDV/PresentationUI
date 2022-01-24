namespace System.Windows.UI.Controls
{
    /// <summary>
    /// Определяет константы, указывающие причину закрытия информационной панели.
    /// </summary>
    public enum InfoBarCloseReason
    {
        /// <summary>
        /// Информационная панель была закрыта пользователем, нажав кнопку закрытия.
        /// </summary>
        CloseButton = 0,

        /// <summary>
        /// Информационная панель была закрыта программно.
        /// </summary>
        Programmatic = 1
    }
}
