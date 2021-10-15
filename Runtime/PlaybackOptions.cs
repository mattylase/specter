using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Specter
{
    public class PlaybackOptions
    {
        public float Speed { get; private set; }

        public PlaybackOptions(float speed = 1)
        {
            Speed = speed;
        }
    }
}
