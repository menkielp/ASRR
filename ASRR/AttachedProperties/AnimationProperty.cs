using ASRR.Core;
using System.Windows;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Wlasciwosc dolaczana pozwalajaca na animacje
    /// </summary>
    class AnimationProperty
    {
        #region Attached Properties

        /// <summary>
        /// Pobranie wlasciwosci
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Animation GetDoAnimation(DependencyObject obj)
        {
            return (Animation)obj.GetValue(DoAnimationProperty);
        }

        /// <summary>
        /// Ustawienie wlasciwosci
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetDoAnimation(DependencyObject obj, Animation value)
        {
            obj.SetValue(DoAnimationProperty, value);
        }
        
        public static readonly DependencyProperty DoAnimationProperty =
            DependencyProperty.RegisterAttached("DoAnimation", typeof(Animation), typeof(AnimationProperty), new UIPropertyMetadata(DoAnimationPropertyChanged));


        #endregion

        #region PropertyChanged Events

        /// <summary>
        /// Wykonanie przy zmianie wartosci <see cref="DoAnimationProperty"/>
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void DoAnimationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is FrameworkElement control))
                return;

            //Animacja do wykonania
            Animation animation = (Animation)e.NewValue;

            if (animation == Animation.None) return;

            switch(animation)
            {
                case Animation.FadeIn:
                    {
                        control.FadeIn(1.0, 0.3);
                        break;
                    }
                case Animation.FadeOut:
                    {
                        control.FadeOut(0.0, 0.3);
                        break;
                    }
                case Animation.SladeOutToLeft:
                    {
                        control.SladeOutToLeft(-control.ActualWidth, 0.2);
                        break;
                    }
                case Animation.SladeInFromLeft:
                    {
                        control.SladeInFromLeft(0, 0.2);
                        break;
                    }
                case Animation.LightFadeIn:
                    {
                        control.FadeIn(0.3, 0.3);
                        break;
                    }
                case Animation.SladeInFromRight:
                    {
                        control.SladeInFromRight(10, 0.3);
                        break;
                    }
                case Animation.SladeOutToRight:
                    {
                        control.SladeOutToRight(-control.ActualWidth, 0.3);
                        break;
                    }
                default: break;
            }
            
        }

        #endregion

    }
}
