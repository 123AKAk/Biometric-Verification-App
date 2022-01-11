using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Image_Crop_GUI
{
    class Biometric
    {
        public string bio_fingerprint = null;

        public string bio_passport = null;

        public Biometric(string biofingerprint, string biopassport)
        {
            this.bio_fingerprint = biofingerprint;
            this.bio_passport = biopassport;
        }
    }
}
