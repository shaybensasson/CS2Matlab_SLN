clc;
%s = 5; 
%A = [1.5, 2, 9];
hWnd = double(0);
wParam = double(0);
lParam = double(20);
disp('1st time ...');
hWnd = sampleMex(hWnd, wParam, lParam)

%{
wParam = double(321);
lParam = double(654);

disp('2nd time ...');
hWnd = sampleMex(hWnd, wParam, lParam)

%sampleMex.showNotepad();
%}