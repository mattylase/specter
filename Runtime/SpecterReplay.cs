using System.Collections;
using System;
using UnityEngine;

namespace Specter
{
    public class SpecterReplay : MonoBehaviour
    {
        public void Play(CaptureResult result, PlaybackOptions options)
        {
            if (result.CaptureMode == CaptureMode.Imperative)
            {
                StartCoroutine(PlayImperative(result, options));
            }
        }

        IEnumerator PlayImperative(CaptureResult result, PlaybackOptions options)
        {
            var frames = result.Frames;
            if (frames.Count < 2)
            {
                Debug.Log("Not enough frames to Replay");
                yield break;
            }

            ImperativeFrame first = (ImperativeFrame)frames.Dequeue();

            transform.position = first.p;
            transform.rotation = first.q;

            float timeElapsed = 0f;

            while (frames.Count != 0)
            {
                var next = (ImperativeFrame)frames.Dequeue();
                var lerpDuration = GetLerpDuration(next, result.Options, options);

                while (timeElapsed < lerpDuration)
                {
                    transform.position = Vector3.Lerp(transform.position, next.p, timeElapsed / lerpDuration);
                    transform.rotation = Quaternion.Lerp(transform.rotation, next.q, timeElapsed / lerpDuration);
                    timeElapsed += Time.deltaTime;

                    yield return null;
                }

                timeElapsed = 0f;
            }
        }

        private float GetLerpDuration(Frame frame, CaptureOptions captureOptions, PlaybackOptions playbackOptions)
        {
            if (frame is ImperativeFrame)
            {
                var f = (ImperativeFrame)frame;
                if (captureOptions.FlattenFrames)
                {
                    return (f.s * captureOptions.CaptureRate.Frequency) / playbackOptions.Speed;
                }
                else
                {
                    return captureOptions.CaptureRate.Frequency / playbackOptions.Speed;
                }
            }

            throw new InvalidOperationException("Not supported just yet ;P");
        }
    }
}
