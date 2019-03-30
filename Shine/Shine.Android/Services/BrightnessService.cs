using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Shine.Droid.Services;
using Shine.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(BrightnessService))]
namespace Shine.Droid.Services
{
    public class BrightnessService : IBrightnessService
    {
        
        public void SetBrightness(float brightness)
        {
            var window = MainActivity.Instance.Window;
            var windowParams = new WindowManagerLayoutParams();

            windowParams.CopyFrom(window.Attributes);
            windowParams.ScreenBrightness = brightness;

            window.Attributes = windowParams;
        }
    }
}