using System.Windows;
using System.Windows.Input;

namespace CookBook.App.Controls
{
    public partial class ButtonWithIcon
    {
        public string TextContent
        {
            get => (string)GetValue(TextContentProperty);
            set => SetValue(TextContentProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public string IconSource
        {
            get => (string)GetValue(IconSourceProperty);
            set => SetValue(IconSourceProperty, value);
        }

        public static readonly DependencyProperty TextContentProperty = DependencyProperty.Register(
            nameof(TextContent), typeof(string), typeof(ButtonWithIcon), new PropertyMetadata(default));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            nameof(Command), typeof(ICommand), typeof(ButtonWithIcon));

        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register(
            nameof(IconSource), typeof(string), typeof(ButtonWithIcon), new PropertyMetadata(default));

        public ButtonWithIcon()
        {
            InitializeComponent();
        }
    }
}
