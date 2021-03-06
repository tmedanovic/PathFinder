﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PathFinder.Core;
using PathFinder.Core.Views;
using PathFinder.Core.Windows;
using Webmicrolab.Plugins;

namespace PathFinder.Plugins
{
    public interface IPluginHostPF : IPluginHost
    {
        event EventHandler<NavigatedEventArgs> RootNavigated;

        event EventHandler<ViewChangedEventArgs> ViewStyleChanged;

        event EventHandler<WindowEventArgs> WindowOpened;

        event EventHandler<WindowEventArgs> WindowClosed;

        event EventHandler<EventArgs> ApplicationClosing;

        FormWindowState WindowState { get; }

        IEnumerable<BaseWindow> OpenedWindows { get; }

        void Register(ToolStrip toolStrip);

        void Register(UserControl dockContent, DockFormStyle state);

        void Register(BaseView view);

        void AddWindow(BaseWindow window);

        void ChangeView(Guid view);

        void RegisterKeyStroke(KeystrokeAction keystrokeAction);
    }
}
