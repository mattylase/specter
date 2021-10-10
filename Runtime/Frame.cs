using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Specter
{
    public class Frame { }
    internal class DeterministicFrame: Frame { }
    internal class ImperativeFrame: Frame {
        public ImperativeFrame(Vector3 position, Quaternion rotation)
        {
            p = position;
            q = rotation;
        }

        internal Vector3 p;
        internal Quaternion q;
    }
}
