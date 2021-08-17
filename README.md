# VPNStatus
 Small Windows util for connecting and disconnecting a rasdial compatible VPN connection directly from a tray icon. Also provides immediate visibility of connection status.

 This was written to solve a specific irritation during the first COVID-19 lockdown in 2020 - bouncing between being connected to a VPN and not!
 I found myself doing this a lot and the native Windows experience is long winded at best, this little tool simply needed writing.


# Usage

1. Update the "VPNConnectionName" setting to the name of a configured VPN (can be found in Settings -> Network & Internet -> VPN in Windows 10)

2. Build the app

3. Run the executable - a small white lock icon will display in the tray (remember to set it as always visible via Settings -> Personalisation -> Taskbar -> Select which icons appear on the taskbar, or just dragging it to the tray)

4. Right click the icon, choose "Connect"

5. The icon will turn green when the connection is ready, your VPN is now connected

6. Right click the icon, choose "Disconnect" - your VPN is now disconnected

