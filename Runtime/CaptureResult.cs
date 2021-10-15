using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Specter
{
    public class CaptureResult
    {

        public Queue<Frame> Frames;
        public CaptureOptions Options;
        public CaptureMode CaptureMode;

        public CaptureResult(CaptureMode mode, CaptureOptions options, Queue<Frame> frames)
        {
            CaptureMode = mode;
            Frames = frames;
            Options = options;
        }
    }
}
