using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Image_Crop_GUI
{
    class UGSSJsonResponse
    {
        public string status_code { get; set; }

        public string status_message { get; set; }

        public Biometric payload { get; set; }

    }
}
