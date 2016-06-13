﻿using Plugin.GoogleAnalytics.Abstractions;
using Plugin.GoogleAnalytics.Abstractions.Model;

namespace Plugin.GoogleAnalytics
{
    public sealed partial class PlatformInfoProvider : IPlatformInfoProvider
    {
        public PlatformInfoProvider()
        {
            var device = new DeviceInfo();
            ScreenResolution = new Dimensions(device.Display.Width, device.Display.Height);
            UserLanguage = device.LanguageCode;
            UserAgent = device.UserAgent;
            ViewPortResolution = new Dimensions(device.Display.Width, device.Display.Height);
            Version = device.VersionNumber;
        }
    }
}