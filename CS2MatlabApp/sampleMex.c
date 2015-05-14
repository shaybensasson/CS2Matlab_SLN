#include "windows.h"
#include "mex.h"

#define WM_USER_1	WM_USER + 1

void mexFunction(int nlhs, mxArray *plhs[], int nrhs,
                 const mxArray *prhs[])
{
    
    /* check for proper number of arguments */
    if(nrhs!=3) {
        mexErrMsgIdAndTxt("MyToolbox:sampleMex:nrhs","3 inputs required.");
    }
    if(nlhs!=1) {
        mexErrMsgIdAndTxt("MyToolbox:sampleMex:nlhs","1 output required.");
    }
    
    /* Examine input (right-hand-side) arguments. 
    mexPrintf("\nThere are %d right-hand-side argument(s).", nrhs);
    
    int i;
    for (i=0; i<nrhs; i++)  {
        mexPrintf("\n\tInput Arg %i is of type:\t%s ",i,mxGetClassName(prhs[i]));
    }
    */
    
    /* Examine output (left-hand-side) arguments. 
    mexPrintf("\n\nThere are %d left-hand-side argument(s).\n", nlhs);
    */
    
    //showNotepad();
    int hWnd = (int)mxGetScalar(prhs[0]);
    int wParam = (int)mxGetScalar(prhs[1]);
    int lParam = (int)mxGetScalar(prhs[2]);
        
    mexPrintf("called sampleMex(%d, %d, %d)\n", hWnd, wParam, lParam);
    
    //int hWnd = 0;
    if (!hWnd || !IsWindow(hWnd)) {
        //mexPrintf("looking for window ...\n");
        //hWnd = FindWindowA(NULL, "Untitled - Notepad");
        hWnd = FindWindowA(NULL, "Matlab-to-Unity Messanger Window");
        if (hWnd)
            mexPrintf("found window: %d\n", (int)hWnd);
        else
            mexErrMsgIdAndTxt("MyToolbox:sampleMex","Could not find 'Messanger' window.");
    }
    
	//SetForegroundWindow(hWnd);
    PostMessage(hWnd, WM_USER_1, wParam, lParam);
    
    plhs[0] = mxCreateNumericMatrix(1, 1, mxDOUBLE_CLASS, mxREAL);

    // fill in output parameter
    double * data = (double *) mxGetData(plhs[0]);
    data[0] = (double)(int)hWnd; 
}