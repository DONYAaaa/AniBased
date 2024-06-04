using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

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
            if (d is TextBox textBox)
            {
                if ((string)e.NewValue != null)
                {
                    textBox.GotFocus += RemoveWatermark;
                    textBox.LostFocus += ShowWatermark;
                    ShowWatermark(textBox, null);
                }
                else
                {
                    textBox.GotFocus -= RemoveWatermark;
                    textBox.LostFocus -= ShowWatermark;
                }
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
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = GetWatermark(textBox);
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // Цвет placeholder
            }
        }
    }
}