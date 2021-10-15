using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Specter
{
    public class SpecterCapture : MonoBehaviour
    {
        private CaptureOptions activeOptions;
        private CaptureMode activeMode;
        private bool capturing = false;
        private bool paused = false;
        private Queue<Frame> frames;

        void Awake()
        {
            CaptureOptions.DEFAULT = new CaptureOptions(
                    new CaptureOptions.Rate(Time.fixedDeltaTime)
                );
        }

        public void BeginCapture(CaptureMode mode = CaptureMode.Imperative, CaptureOptions options = null)
        {
            activeMode = mode;

            if (mode == CaptureMode.Imperative)
            {
                var opts = options ?? CaptureOptions.DEFAULT;
                CaptureImperative(opts);
            }
        }

        public void PauseCapture()
        {
            paused = true;
        }

        public CaptureResult StopCapture()
        {
            capturing = false;
            paused = false;

            return new CaptureResult(activeMode, activeOptions, frames);
        }

        // private methods
        private void CaptureImperative(CaptureOptions options)
        {
            if (capturing)
            {
                throw new InvalidOperationException("Capturing must be stopped via StopCapture before calling BeginCapture again");
            }

            activeOptions = options;
            capturing = true;
            StartCoroutine(ImperativeCoroutine(options));
        }

        private IEnumerator ImperativeCoroutine(CaptureOptions options)
        {
            frames = new Queue<Frame>();
            while(capturing)
            {
                if (paused)
                {
                    yield return null;
                }

                frames.Enqueue(new ImperativeFrame(transform.position, transform.rotation));
                yield return new WaitForSeconds(options.catureRate.Frequency);
            }
        }
    }
}
