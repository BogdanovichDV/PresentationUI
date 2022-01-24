using System.ComponentModel;
using System.Windows;

namespace System.Windows.UI.Controls.Primitives
{
    /// <summary>
    /// Предоставляет вычисляемые значения, на которые можно ссылаться как на источники <seealso cref="FrameworkElement.TemplatedParent"/> при определении шаблонов для <seealso cref="InfoBar"/>.
    /// </summary>
    public class InfoBarTemplateSettings : DependencyObject
    {
        #region Fields
        /// <summary>
        /// Идентифицирует свойство зависимостей <seealso cref="IconElement"/>.
        /// </summary>
        public static readonly DependencyProperty IconElementProperty = DependencyProperty.Register("IconElement", typeof(IconElement), typeof(InfoBarTemplateSettings));
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр класса <seealso cref="InfoBarTemplateSettings"/>.
        /// </summary>
        public InfoBarTemplateSettings()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Получает или задает значок для <seealso cref="InfoBar"/>.
        /// </summary>
        /// <value>
        /// Значок для <seealso cref="InfoBar"/>.
        /// </value>
        [Bindable(true)]
        public IconElement IconElement
        {
            get => (IconElement)GetValue(IconElementProperty);
            set => SetValue(IconElementProperty, value);
        }
        #endregion
    }
}
