using System;

namespace Refactoring.Sample.ComposingMethods.ExtractVariable
{
    public class Solution
    {
        private readonly string platform;
        private readonly string browser;
        private int resize;

        void RenderBanner()
        {
            bool isMac = platform.ToUpper().IndexOf("MAC") > -1;
            bool isIE = browser.ToUpper().IndexOf("IE") > -1;
            bool wasResized = resize > 0;
            bool canShowPopup = isMac && isIE && WasInitialized() && wasResized;
            
            if (canShowPopup)
            {
                // do something
            }
        }

        private bool WasInitialized()
        {
            throw new NotImplementedException();
        }
    }
}