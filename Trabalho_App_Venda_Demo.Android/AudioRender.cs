using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using Xamarin.Forms;
using Trabalho_App_Venda_Demo.Droid;

[assembly: Dependency(typeof(AudioRender))]
namespace Trabalho_App_Venda_Demo.Droid
{
    public class AudioRender : IAudioService
    {
        public void PlayAudioFile(string fileName)
        {
            var player = new MediaPlayer();
            var file = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.SetDataSource(file.FileDescriptor, file.StartOffset, file.Length);
            // player.Start();
            //player.Prepared += (s, e) => { player.Start(); };
            //player.Prepare();
        }
    }
}