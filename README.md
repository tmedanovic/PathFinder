# PathFinder
Extendable file manager based on Windows explorer

Please note that this project is in very early stage of development, 
and it's not nearly ready for everyday use.

If you like the idea, consider contributing :)

It has two view modes for now, but there is option to register custom views from plugin host

Tabbed view:
![PathFinder tabbed view](https://cloud.githubusercontent.com/assets/5676600/7072143/673c28b6-deea-11e4-96ba-d39c3bdbfddc.png)

Windows view:
![PathFinder windows view](https://cloud.githubusercontent.com/assets/5676600/6993132/cc6d5b78-daea-11e4-9b7e-b88a2723a4f2.png)

Features:
* Multiple view modes, including tabbed and windows view (custom views)
* Plugin system - it should allow custom toolbars, views, windows, dockable forms (not quite finished yet)
* Single instance
* Register as default file manager (code is done, waiting for UI integration)
* Minimize to taskbar, minimize to tray

Planned in near future:
* Plugin manager, similar to npp
* Installation
* Auto updater

Known limitations:
* Built for x86 - due to dependency on excelent library GongShell which wraps native win32 interfaces to managed world
* Works on Windows vista => (Due to dependency on native interface IExplorerBrowser, compatibility for older versions is considered by using IShellView interface, but this is currently not priority)

