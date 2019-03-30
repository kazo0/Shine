using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemConfiguration;
using Foundation;
using Shine.iOS.Services;
using Shine.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(BrightnessService))]
namespace Shine.iOS.Services
{
    public class BrightnessService : IBrightnessService
    {
        public void SetBrightness(float brightness)
        {
            UIScreen.MainScreen.Brightness = brightness;
        }
    }
}