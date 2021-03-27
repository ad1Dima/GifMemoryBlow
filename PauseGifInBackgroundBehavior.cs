using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace GifMemoryBlow
{
    public class PauseGifInBackgroundBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            if (!(associatedObject is Image image))
                return;

            AssociatedObject = image;
            Window.Current.VisibilityChanged += Window_VisibilityChanged;
        }

        private void Window_VisibilityChanged(object sender, Windows.UI.Core.VisibilityChangedEventArgs e)
        {
            if (!(AssociatedObject is Image image)
                || !(image.Source is BitmapImage bitmap)
                || !bitmap.IsAnimatedBitmap)
                return;

            if (e.Visible)
            {
                bitmap.Play();
            }
            else
            {
                bitmap.Stop();
            }
        }

        public void Detach()
        {
            AssociatedObject = null;
            Window.Current.VisibilityChanged -= Window_VisibilityChanged;
        }
    }
}
