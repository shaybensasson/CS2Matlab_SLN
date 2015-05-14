function res = registerNetClient( comProxy )
%REGISTERNETCLIENT Summary of this function goes here
%   Detailed explanation goes here
    global global_comProxy;
    global_comProxy = comProxy;
    
    comProxy.SayHelloFromMatlab();

    res = 2;

end

