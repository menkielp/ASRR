using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ASRR
{
    /// <summary>
    /// Animacja zmiany koloru dla <see cref="FrameworkElement"/>
    /// </summary>
    static class ChangeColorAnimation
    {
        /// <summary>
        /// animacja zmiany koloru
        /// </summary>
        /// <param name="source"></param>
        /// <param name="brush"></param>
        /// <param name="seconds"></param>
        public static void ChangeColor(this FrameworkElement source, Color brush, double seconds)
        {
            Storyboard sb = new Storyboard();
            ColorAnimation animation = new ColorAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = brush
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Background.(SolidColorBrush.Color)"));
            sb.Children.Add(animation);
            sb.Begin(source);
        }

    }
}
