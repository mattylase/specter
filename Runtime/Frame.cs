using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Specter
{
    public class Frame { }
    internal class DeterministicFrame: Frame { }
    internal class ImperativeFrame: Frame {
        public ImperativeFrame(Vector3 position, Quaternion rotation, int step = 1)
        {
            p = position;
            q = rotation;
            s = step;
        }

        internal Vector3 p;
        internal Quaternion q;
        internal int s;

        public override bool Equals(object obj)
        {
            if (!(obj is ImperativeFrame))
            {
                return false;
            }

            var f = (ImperativeFrame) obj;
            return f.p == this.p && f.q == this.q;
        }

        public override string ToString()
        {
            return $"ImperativeFrame(p={p}, q={q}, s={s}";
        }
    }
}
