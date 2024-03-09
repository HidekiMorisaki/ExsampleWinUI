using Microsoft.UI.Xaml;
using MvvmGen;
using System;
using WinRT.Interop;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ExsampleWinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Handle = this;
        }

        public static MainWindow Handle { get; private set; }

        //private void myButton_Click(object sender, RoutedEventArgs e)
        //{
        //    myButton.Content = "Clicked";
        //}

        private async void buttonFilePicker_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.Pickers.FileOpenPicker fileOpenPicker = new()
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                FileTypeFilter = { ".jpg", ".jpeg", ".png", ".png", ".gif" },
            };

            nint windowHandle = WindowNative.GetWindowHandle(MainWindow.Handle);
            InitializeWithWindow.Initialize(fileOpenPicker, windowHandle);
            Windows.Storage.StorageFile file = await fileOpenPicker.PickSingleFileAsync();
        }
    }
}
