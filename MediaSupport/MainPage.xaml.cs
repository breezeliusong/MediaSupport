using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MediaSupport
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        MediaPlaybackList list;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaSource mediaSource;
            MediaPlaybackItem mediaPlaybackItem;

            ////Create a new picker
            //var filePicker = new Windows.Storage.Pickers.FileOpenPicker();

            ////Add filetype filters.  In this case wmv and mp4.
            //filePicker.FileTypeFilter.Add(".wmv");
            //filePicker.FileTypeFilter.Add(".mp3");
            //filePicker.FileTypeFilter.Add(".mkv");

            ////Set picker start location to the video library
            //filePicker.SuggestedStartLocation = PickerLocationId.VideosLibrary;

            ////Retrieve file from picker
            //StorageFile file = await filePicker.PickSingleFileAsync();

            //if (file != null)
            //{
            //    mediaSource = MediaSource.CreateFromStorageFile(file);
            //    mediaElement.SetPlaybackSource(mediaSource);
            //    mediaElement.Play();
            //}

            var files = await KnownFolders.MusicLibrary.GetFilesAsync();
            list = new MediaPlaybackList();
            foreach (var file in files)
            {
                mediaSource = MediaSource.CreateFromStorageFile(file);
                mediaPlaybackItem = new MediaPlaybackItem(mediaSource);
                list.Items.Add(mediaPlaybackItem);
            }
            mediaElement.SetPlaybackSource(list);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            list.MoveNext();
        }
    }
}
