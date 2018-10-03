using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace ASRR
{
    /// <summary>
    /// Animacje pojawania sie i znikania
    /// </summary>
    static class FadeInOutAnimation
    {
        /// <summary>
        /// Animacja pojawiania sie
        /// </summary>
        /// <param name="source"></param>
        public static void FadeIn(this FrameworkElement source, double toOpacity, double seconds)
        {
            Storyboard sb = new Storyboard();
            
            DoubleAnimation animation = new DoubleAnimation()
            {
                To = toOpacity,
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            sb.Children.Add(animation);
            sb.Begin(source);
        }

        /// <summary>
        /// Animacja znikania
        /// </summary>
        /// <param name="source"></param>
        public static void FadeOut(this FrameworkElement source, double toOpacity, double seconds)
        {
            source.FadeIn(toOpacity, seconds);
        }

    }
}
