using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

namespace AniBased.View.Resource
{
    class WatermarkAdorner : Adorner
    {
        private readonly ContentPresenter _contentPresenter;

        public WatermarkAdorner(UIElement adornedElement, object watermark) : base(adornedElement)
        {
            _contentPresenter = new ContentPresenter
            {
                Content = watermark,
                Opacity = 0.5,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 0, 0, 0)
            };

            IsHitTestVisible = false;
            AddVisualChild(_contentPresenter);
        }

        protected override Visual GetVisualChild(int index)
        {
            return _contentPresenter;
        }

        protected override int VisualChildrenCount => 1;

        protected override Size ArrangeOverride(Size finalSize)
        {
            _contentPresenter.Arrange(new Rect(finalSize));
            return finalSize;
        }
    }
}