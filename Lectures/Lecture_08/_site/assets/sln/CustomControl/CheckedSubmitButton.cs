using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControl
{
    public class CheckedSubmitButton : Control
    {
        public static readonly DependencyProperty CheckTextProperty = DependencyProperty.Register(
            nameof(CheckText), typeof(string), typeof(CheckedSubmitButton), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register(
            nameof(ButtonText), typeof(string), typeof(CheckedSubmitButton), new PropertyMetadata(default(string)));


        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            nameof(Command), typeof(ICommand), typeof(CheckedSubmitButton), new PropertyMetadata(default(ICommand)));

        private Button checkedSubmitButton_Button;


        private CheckBox checkedSubmitButton_CheckBox;

        static CheckedSubmitButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckedSubmitButton),
                new FrameworkPropertyMetadata(typeof(CheckedSubmitButton)));
        }

        public string CheckText
        {
            get => (string) GetValue(CheckTextProperty);
            set => SetValue(CheckTextProperty, value);
        }

        public string ButtonText
        {
            get => (string) GetValue(ButtonTextProperty);
            set => SetValue(ButtonTextProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public event EventHandler<RoutedEventArgs> Checked;
        public event EventHandler<RoutedEventArgs> Clicked;

        public override void OnApplyTemplate()
        {
            checkedSubmitButton_CheckBox = GetTemplateChild<CheckBox>("CheckedSubmitButton_CheckBox");
            checkedSubmitButton_Button = GetTemplateChild<Button>("CheckedSubmitButton_Button");

            checkedSubmitButton_CheckBox.Checked += (sender, args) => Checked?.Invoke(sender, args);
            checkedSubmitButton_Button.Click += (sender, args) => Clicked?.Invoke(sender, args);
        }

        private T GetTemplateChild<T>(string name) where T : DependencyObject
        {
            if (!(GetTemplateChild(name) is T child)) throw new NullReferenceException(name);

            return child;
        }
    }
}