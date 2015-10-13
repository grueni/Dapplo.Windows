﻿/*
 * dapplo - building blocks for desktop applications
 * Copyright (C) 2015 Robin Krom
 * 
 * For more information see: http://dapplo.net/
 * dapplo repositories are hosted on GitHub: https://github.com/dapplo
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace Dapplo.Windows.Enums
{
	[Flags]
	public enum WindowPlacementFlags : uint
	{
		// The coordinates of the minimized window may be specified.
		// This flag must be specified if the coordinates are set in the ptMinPosition member.
		WPF_SETMINPOSITION = 0x0001,
		// If the calling thread and the thread that owns the window are attached to different input queues, the system posts the request to the thread that owns the window. This prevents the calling thread from blocking its execution while other threads process the request.
		WPF_ASYNCWINDOWPLACEMENT = 0x0004,
		// The restored window will be maximized, regardless of whether it was maximized before it was minimized. This setting is only valid the next time the window is restored. It does not change the default restoration behavior.
		// This flag is only valid when the SW_SHOWMINIMIZED value is specified for the showCmd member.
		WPF_RESTORETOMAXIMIZED = 0x0002
	}
}
