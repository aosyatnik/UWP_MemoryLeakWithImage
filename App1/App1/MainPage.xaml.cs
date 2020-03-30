using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainViewModel MainViewModel;

        public MainPage()
        {
            this.InitializeComponent();

            BackgroundImage.ImageOpened += BackgroundImage_Opened;
            ForegroundImage.ImageOpened += ForegroundImage_Opened;
            _imageTimer.Tick += Image_Ended;
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            MainViewModel = MainGrid.DataContext as MainViewModel;
            StartShow();
        }

        private void StartShow()
        {
            ChangeSelectedFile(MainViewModel.Files[0]);
        }

        #region selected file

        private int _index = 0;

        private File _selectedFile;
        private File SelectedFile
        {
            get
            {
                return _selectedFile;
            }

            set
            {
                _selectedFile = value;

                if (_selectedFile is null || String.IsNullOrWhiteSpace(_selectedFile.LocalPath))
                {
                    return;
                }

                var uri = new Uri(BaseUri, _selectedFile.LocalPath);
                _foregroundImageReady = false;
                _backgroundImageReady = false;

                BackgroundImage.Source = new BitmapImage(uri);
                ForegroundImage.Source = new BitmapImage(uri);
            }
        }

        private File _previousFile;
        private File PreviousFile
        {
            get
            {
                return _previousFile;
            }

            set
            {
                _previousFile = value;
                if (_previousFile is null || String.IsNullOrWhiteSpace(_previousFile.LocalPath))
                {
                    return;
                }

                var uri = new Uri(BaseUri, _previousFile.LocalPath);

                PreviousBackgroundImage.Source = new BitmapImage(uri);
                PreviousForegroundImage.Source = new BitmapImage(uri);
            }
        }


        public void ChangeSelectedFile(File file)
        {
            SelectedFile = file;
        }

        #endregion

        #region media opened

        private bool _backgroundImageReady = false;
        public bool BackgroundImageReady
        {
            get
            {
                // If overlay background is solid color, then it's always ready.
                if (MainViewModel.OverlayBackground == OverlayBackground.black ||
                    MainViewModel.OverlayBackground == OverlayBackground.grey ||
                    MainViewModel.OverlayBackground == OverlayBackground.none)
                {
                    return true;
                }

                return _backgroundImageReady;
            }
        }

        private bool _foregroundImageReady = false;
        public bool ForegroundImageReady
        {
            get
            {
                return _foregroundImageReady;
            }
        }

        private async void ForegroundImage_Opened(object sender, RoutedEventArgs e)
        {
            _foregroundImageReady = true;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => StartShowingImage());
        }

        private async void BackgroundImage_Opened(object sender, RoutedEventArgs e)
        {
            _backgroundImageReady = true;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => StartShowingImage());
        }

        private void StartShowingImage()
        {
            if (SelectedFile is null || !ForegroundImageReady || !BackgroundImageReady)
            {
                return;
            }

            PreviousFile = SelectedFile;

            _imageTimer.Interval = TimeSpan.FromSeconds(MainViewModel.DisplayImageTime);
            _imageTimer.Start();
        }

        #endregion

        #region timer 

        private DispatcherTimer _imageTimer = new DispatcherTimer();

        private void Image_Ended(object sender, object e)
        {
            if (_index < MainViewModel.Files.Count - 1)
            {
                _index++;
            }
            else
            {
                _index = 0;
            }

            SelectedFile = MainViewModel.Files[_index];
        }

        #endregion
    }
}
