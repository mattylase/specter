using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Specter
{
    public class CaptureResult
    {

        public Queue<Frame> Frames;
        public CaptureOptions Options;

        public CaptureResult(CaptureOptions options, Queue<Frame> frames)
        {
            Frames = frames;
            Options = options;
        }
    }
}
