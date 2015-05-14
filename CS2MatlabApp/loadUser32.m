if(libisloaded('user32')==0)
    disp('loading dll...')
    loadlibrary('C:\WINDOWS\system32\user32.dll','user32.h');
else
    disp('dll already loaded')
end