using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ASRR
{
    /// <summary>
    /// Animacja zmiany rozmiaru <see cref="FrameworkElement"/>
    /// </summary>
    static class ChangeSizeAnimation
    {

        /// <summary>
        /// animacja zwiekszenie rozmiaru
        /// </summary>
        /// <param name="source"></param>
        /// <param name="seconds">czas trwania animacji</param>
        /// <param name="fromHeight">wysokosc startowa</param>
        /// <param name="fromWidth">szerokosc startowa</param>
        /// <param name="toHeight">wyokosc koncowa</param>
        /// <param name="toWidth">szerokosc koncowa</param>
        public static void IncreaseSize(this FrameworkElement source, double seconds, double toHeight, double toWidth)
        {
            source.IncreaseHeight(new Duration(TimeSpan.FromSeconds(seconds)), toHeight);
            source.IncreaseWidth(new Duration(TimeSpan.FromSeconds(seconds)), toWidth);
        }

        /// <summary>
        /// animacja zmniejszania rozmiaru
        /// </summary>
        /// <param name="source"></param>
        /// <param name="seconds">czas trwania animacji</param>
        /// <param name="fromHeight">wysokosc startowa</param>
        /// <param name="fromWidth">szerokosc startowa</param>
        /// <param name="toHeight">wyokosc koncowa</param>
        /// <param name="toWidth">szerokosc koncowa</param>
        public static void DecreaseSize(this FrameworkElement source, double seconds, double toHeight, double toWidth)
        {
            source.DecreaseHeight(new Duration(TimeSpan.FromSeconds(seconds)), toHeight);
            source.DecreaseWidth(new Duration(TimeSpan.FromSeconds(seconds)), toWidth);
        }

        /// <summary>
        /// animacja zwiekszania wysokosci
        /// </summary>
        /// <param name="source"></param>
        /// <param name="duration"></param>
        /// <param name="fromHeight"></param>
        /// <param name="toHeight"></param>
        public static void IncreaseHeight(this FrameworkElement source, Duration duration, double toHeight)
        {
            Storyboard sb = new Storyboard();
            
            DoubleAnimation animation = new DoubleAnimation()
            {
                To = toHeight,
                Duration = duration
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Height"));
            sb.Children.Add(animation);
            sb.Begin(source);
        }

        /// <summary>
        /// animacja zwiekszania sie szerokosci elementu
        /// </summary>
        /// <param name="source"></param>
        /// <param name="duration"></param>
        /// <param name="fromWidth"></param>
        /// <param name="toWidth"></param>
        public static void IncreaseWidth(this FrameworkElement source, Duration duration, double toWidth)
        {
            Storyboard sb = new Storyboard();
            
            DoubleAnimation animation = new DoubleAnimation()
            {
                To = toWidth,
                Duration = duration
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Width"));
            sb.Children.Add(animation);
            sb.Begin(source);
        }

        /// <summary>
        /// animacja zmniejszania sie wysokosci danego elementu
        /// </summary>
        /// <param name="source"></param>
        /// <param name="duration"></param>
        /// <param name="fromHeight"></param>
        /// <param name="toHeight"></param>
        public static void DecreaseHeight(this FrameworkElement source, Duration duration, double toHeight)
        {
            Storyboard sb = new Storyboard();
            
            DoubleAnimation animation = new DoubleAnimation()
            {
                To = toHeight,
                Duration = duration
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Height"));
            sb.Children.Add(animation);
            sb.Begin(source);
        }

        /// <summary>
        /// animacja zmniejszania sie szerokosci danego elementu
        /// </summary>
        /// <param name="source"></param>
        /// <param name="duration"></param>
        /// <param name="fromWidth"></param>
        /// <param name="toWidth"></param>
        public static void DecreaseWidth(this FrameworkElement source, Duration duration, double toWidth)
        {
            Storyboard sb = new Storyboard();
            
            DoubleAnimation animation = new DoubleAnimation()
            {
                To = toWidth,
                Duration = duration
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Width"));
            sb.Children.Add(animation);
            sb.Begin(source);
        }

    }
}
