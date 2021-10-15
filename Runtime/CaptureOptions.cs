namespace Specter
{
    public class CaptureOptions {

        public static CaptureOptions DEFAULT { internal set; get; }

        public Rate catureRate { get; }

        public CaptureOptions(Rate rate)
        {
            catureRate = rate;
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
