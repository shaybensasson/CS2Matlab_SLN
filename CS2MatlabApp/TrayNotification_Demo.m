SysTObj = SystemTools; SysTObj.NETFramework();
NotificationIcon = SysTObj.Notify('Message...', ...
                   'Message Heading', 'Tray Icon ToolTip', [pwd '\icon.ico']);
               
pause(5); NotificationIcon.Visible = false;NotificationIcon.Dispose();