using System.Collections;
using System.Collections.Generic;
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

            ImperativeFrame first = (ImperativeFrame) frames.Dequeue();

            transform.position = first.p;
            transform.rotation = first.q;

            float timeElapsed = 0f;
            float lerpDuration = result.Options.catureRate.Frequency / options.Speed;

            while (frames.Count != 0)
            {
                var next = (ImperativeFrame) frames.Dequeue();

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
    }
}
