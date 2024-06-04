using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Documents;

namespace AniBased.View.Resource
{
    public static class WatermarkService
    {
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(WatermarkService), new PropertyMetadata(default(string), OnWatermarkChanged));

        public static void SetWatermark(UIElement element, string value)
        {
            element.SetValue(WatermarkProperty, value);
        }

        public static string GetWatermark(UIElement element)
        {
            return (string)element.GetValue(WatermarkProperty);
        }

        private static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Control control)
            {
                control.Loaded += Control_Loaded;
                if (control is TextBox textBox)
                {
                    textBox.GotFocus += RemoveWatermark;
                    textBox.LostFocus += ShowWatermark;
                }
                else if (control is PasswordBox passwordBox)
                {
                    passwordBox.PasswordChanged += (sender, args) => ShowWatermark(passwordBox);
                }

                ShowWatermark(control);
            }
        }

        private static void Control_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Control control)
            {
                ShowWatermark(control);
            }
        }

        private static void RemoveWatermark(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == GetWatermark(textBox))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new SolidColorBrush(Colors.White); // Цвет текста при вводе
            }
        }

        private static void ShowWatermark(object sender, RoutedEventArgs e)
        {
            if (sender is Control control)
            {
                ShowWatermark(control);
            }
        }

        private static void ShowWatermark(Control control)
        {
            if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = GetWatermark(textBox);
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // Цвет placeholder
            }
            else if (control is PasswordBox passwordBox)
            {
                if (string.IsNullOrEmpty(passwordBox.Password))
                {
                    AddWatermark(passwordBox);
                }
                else
                {
                    RemoveWatermark(passwordBox);
                }
            }
        }

        private static void AddWatermark(Control control)
        {
            var adornerLayer = AdornerLayer.GetAdornerLayer(control);
            if (adornerLayer != null)
            {
                adornerLayer.Add(new WatermarkAdorner(control, GetWatermark(control)));
            }
        }

        private static void RemoveWatermark(Control control)
        {
            var adornerLayer = AdornerLayer.GetAdornerLayer(control);
            if (adornerLayer != null)
            {
                var adorners = adornerLayer.GetAdorners(control);
                if (adorners != null)
                {
                    foreach (var adorner in adorners)
                    {
                        if (adorner is WatermarkAdorner)
                        {
                            adornerLayer.Remove(adorner);
                        }
                    }
                }
            }
        }
    }
}