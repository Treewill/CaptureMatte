using System.Windows;
using System.Windows.Input;

namespace CaptureMatte
{
    /// <summary>
    /// Interaction logic for CaptureMatteWindow.xaml
    /// </summary>
    public partial class CaptureMatteWindow : Window
    {
        public CaptureMatteWindow()
        {
            InitializeComponent();
        }

        private void CaptureMatteWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                e.Handled = true;
                Close();
            }
            else if (e.Key == Key.F11)
            {
                e.Handled = true;
                if (WindowStyle == WindowStyle.None && WindowState == WindowState.Maximized)
                {
                    WindowStyle = WindowStyle.SingleBorderWindow;
                }
                else
                {
                    WindowStyle = WindowStyle.None;
                    WindowState = WindowState.Normal; // Workaround to force resize.
                    WindowState = WindowState.Maximized;
                }
            }
        }

        private void CaptureMatteWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left || WindowState == WindowState.Maximized)
                return;
            e.Handled = true;
            DragMove();
        }

        private void CaptureMatteWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed || WindowState != WindowState.Maximized)
                return;
            e.Handled = true;
            var point = PointToScreen(e.GetPosition(this));
            WindowStyle = WindowStyle.SingleBorderWindow;
            WindowState = WindowState.Normal;
            Left = point.X - Width / 2;
            Top = point.Y - 5;
            DragMove();
        }
    }
}