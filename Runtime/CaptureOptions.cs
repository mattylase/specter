using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Specter
{
    public class CaptureOptions {

        public CaptureRate rate { get; }

        public CaptureOptions(CaptureRate rate)
        {
            rate = rate;
        }


        public struct CaptureRate
        {
            public CaptureRate(float rate)
            {
                Rate = rate;
            }

            public float Rate { get; }
        }
    }
}
