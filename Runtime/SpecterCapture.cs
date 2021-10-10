using UnityEngine;

namespace Specter
{
    public class SpecterCapture : MonoBehaviour
    {
        private CaptureOptions _default; 

        void Awake()
        {
            _default = new CaptureOptions(
                    new CaptureOptions.CaptureRate(Time.fixedDeltaTime)
                );
        }

        public void BeginCapture(CaptureMode mode = CaptureMode.Imperative)
        {

        }

        public void PauseCapture()
        {

        }

        public void StopCapture()
        {

        }


        // private methods

    }
}
