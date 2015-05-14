function startMatlabApplication(proxy)
%STARTMATLABAPPLICATION Summary of this function goes here
%   Detailed explanation goes here
% res must be a number

    %if (nargin == 0), error('This function must be initiated from an outer process.');
    
    beep
    
    wParam = ceil(rand(1)*100);
    lParam = ceil(rand(1)*100);
    ans1 = proxy.PostMessage1(wParam, lParam)
        
    wParam = ceil(rand(1)*100);
    lParam = ceil(rand(1)*100);
    ans2 = proxy.PostMessage2(wParam, lParam)
    
    %load splat 
    load gong 
    sound(y,Fs)
end

