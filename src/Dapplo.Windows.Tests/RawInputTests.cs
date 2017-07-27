﻿//  Dapplo - building blocks for desktop applications
//  Copyright (C) 2016-2017 Dapplo
// 
//  For more information see: http://dapplo.net/
//  Dapplo repositories are hosted on GitHub: https://github.com/dapplo
// 
//  This file is part of Dapplo.Windows
// 
//  Dapplo.Windows is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  Dapplo.Windows is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have a copy of the GNU Lesser General Public License
//  along with Dapplo.Windows. If not, see <http://www.gnu.org/licenses/lgpl.txt>.

#region using

using System.Linq;
using Dapplo.Log;
using Dapplo.Log.XUnit;
using Dapplo.Windows.Input;
using Dapplo.Windows.Input.Enums;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace Dapplo.Windows.Tests
{
    public class RawInputTests
    {
        private static readonly LogSource Log = new LogSource();
        public RawInputTests(ITestOutputHelper testOutputHelper)
        {
            LogSettings.RegisterDefaultLogger<XUnitLogger>(LogLevels.Verbose, testOutputHelper);
        }

        /// <summary>
        ///     Test RawInput.GetAllDevices
        /// </summary>
        [Fact]
        public void Test_RawInput_AllDevices()
        {
            bool foundOneDevice = false;
            foreach (var rawInputDeviceInfo in RawInput.GetAllDevices().OrderBy(information => information.DeviceInfo.Type).ThenBy(information => information.DisplayName))
            {
                Log.Info().WriteLine("RawInput Device {0} with name {1}", rawInputDeviceInfo.DeviceInfo.Type, rawInputDeviceInfo.DisplayName);
                switch (rawInputDeviceInfo.DeviceInfo.Type)
                {
                    case RawInputDeviceTypes.Keyboard:
                        var keyboardInfo = rawInputDeviceInfo.DeviceInfo.Keyboard;
                        Log.Info().WriteLine("Keyboard is of type {0} and subtype {1} and in mode {2}.", keyboardInfo.Type, keyboardInfo.SubType, keyboardInfo.KeyboardMode);
                        Log.Info().WriteLine("Keyboard with {0} key, of which {1} function keys and it has {2} LEDs.", keyboardInfo.NumberOfKeysTotal, keyboardInfo.NumberOfFunctionKeys, keyboardInfo.NumberOfIndicators);
                        break;
                }

                foundOneDevice = true;
            }
            Assert.True(foundOneDevice);
        }
    }
}