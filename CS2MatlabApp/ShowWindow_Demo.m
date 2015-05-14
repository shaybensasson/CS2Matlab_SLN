SysObj = SystemTools;
SysObj.NETFramework();
ProcCred = SysObj.StartProcess('C:\Windows\notepad.exe');
if isempty(ProcCred), return; end

if ~ProcCred.HasExited

    AppSelStats = SysObj.AppSelect(char(ProcCred.MainWindowTitle), 'SW_SHOWNORMAL');
	if AppSelStats>0, disp('SW_SHOWNORMAL: Operation Successfull');
	else disp('SW_SHOWNORMAL: Operation Failed'); return; end
    
    AppSelStats = SysObj.AppSelect(char(ProcCred.MainWindowTitle), 'SW_SHOWMAXIMIZED'); pause(2); 
    if AppSelStats>0, disp('SW_SHOWMAXIMIZED: Operation Successfull');
	else disp('SW_SHOWMAXIMIZED: Operation Failed'); return; end
    
    AppSelStats = SysObj.AppSelect(char(ProcCred.MainWindowTitle), 'SW_SHOWNORMAL'); pause(2); 
    if AppSelStats>0, disp('SW_SHOWNORMAL: Operation Successfull');
	else disp('SW_SHOWNORMAL: Operation Failed'); return; end
    
    AppSelStats = SysObj.AppSelect(char(ProcCred.MainWindowTitle), 'SW_SHOWMAXIMIZED'); pause(2); 
    if AppSelStats>0, disp('SW_SHOWMAXIMIZED: Operation Successfull');
	else disp('SW_SHOWMAXIMIZED: Operation Failed'); return; end
    
    AppSelStats = SysObj.AppSelect(char(ProcCred.MainWindowTitle), 'SW_HIDE'); pause(2); 
    if AppSelStats>0, disp('SW_HIDE: Operation Successfull');
	else disp('SW_HIDE: Operation Failed'); return; end
    
    AppSelStats = SysObj.AppSelect(char(ProcCred.MainWindowTitle), 'SW_SHOW'); pause(2); 
    if AppSelStats>=0, disp('SW_SHOW: Operation Successfull');
	else disp('SW_SHOW: Operation Failed'); return; end
    
    AppSelStats = SysObj.AppSelect(char(ProcCred.MainWindowTitle), 'SW_SHOWMINNOACTIVE'); pause(2); 
    if AppSelStats>0, disp('SW_SHOWMINNOACTIVE: Operation Successfull');
	else disp('SW_SHOWMINNOACTIVE: Operation Failed'); return; end
    
    AppSelStats = SysObj.AppSelect(char(ProcCred.MainWindowTitle), 'SW_RESTORE'); pause(2); 
    if AppSelStats>0, disp('SW_RESTORE: Operation Successfull');
	else disp('SW_RESTORE: Operation Failed'); return; end
    
    AppSelStats = SysObj.AppSelect(char(ProcCred.MainWindowTitle), 'SW_SHOWDEFAULT'); pause(2); 
    if AppSelStats>0, disp('SW_SHOWDEFAULT: Operation Successfull');
	else disp('SW_SHOWDEFAULT: Operation Failed'); return; end
    
else msgbox('The Process has exited');
end