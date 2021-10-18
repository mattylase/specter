namespace Specter
{
    public class CaptureOptions {

        public static CaptureOptions DEFAULT { internal set; get; }

        public Rate CaptureRate { get; private set; }
        public bool FlattenFrames { get; private set; }

        public CaptureOptions(Rate rate, bool flattenFrames)
        {
            CaptureRate = rate;
            FlattenFrames = flattenFrames;
        }


        public struct Rate
        {
            public Rate(float rate)
            {
                Frequency = rate;
            }

            public float Frequency { get; }
        }
    }
}
