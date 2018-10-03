using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace ASRR
{
    /// <summary>
    /// Animacje wslizgiwania sie/wyslizgiwania sie
    /// </summary>
    static class SladeInOutAnimation
    {
        /// <summary>
        /// animacja wslizgiwania sie okna z lewej strony
        /// </summary>
        /// <param name="source"></param>
        /// <param name="offset"></param>
        public static void SladeInFromLeft(this FrameworkElement source, double toMargin, double seconds)
        {
            Storyboard sb = new Storyboard();
            
            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = new Thickness(toMargin, 0, 0, 0)
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
            sb.Begin(source);
        }

        /// <summary>
        /// animacja wyslizgiwania sie okna do lewej strony
        /// </summary>
        /// <param name="source"></param>
        public static void SladeOutToLeft(this FrameworkElement source, double toMargin, double seconds)
        {
            source.SladeInFromLeft(toMargin, seconds);
        }

        /// <summary>
        /// animacja wslizgiwania sie okna z prawej strony
        /// </summary>
        /// <param name="source"></param>
        /// <param name="offset"></param>
        public static void SladeInFromRight(this FrameworkElement source, double toMargin, double seconds)
        {
            Storyboard sb = new Storyboard();
            
            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = new Thickness(0, 10, toMargin, 0)
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
            sb.Begin(source);
        }

        /// <summary>
        /// animacja wyslizgiwania sie okna do prawej strony
        /// </summary>
        /// <param name="source"></param>
        public static void SladeOutToRight(this FrameworkElement source, double toMargin, double seconds)
        {
            source.SladeInFromRight(toMargin, seconds);
        }


    }
}
