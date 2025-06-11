using Verse;

namespace CommsAmbienceUwU
{
    public class CAUWUSettings : ModSettings
    {
        private static CAUWUSettings _instance;
        
        public CAUWUSettings()
        {
            _instance = this;
        }
        
        public static float TradeDialogue_AmbientVolumeMax => _instance._tradeDialogue_AmbientVolumeMax;
        public static float NegotiationDialogue_AmbientVolumeMax => _instance._negotiationDialogue_AmbientVolumeMax;
        
        public float _tradeDialogue_AmbientVolumeMax = 10f;
        public float _negotiationDialogue_AmbientVolumeMax = 10f;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref _tradeDialogue_AmbientVolumeMax, "_tradeDialogue_AmbientVolumeMax", 10f);
            Scribe_Values.Look(ref _negotiationDialogue_AmbientVolumeMax, "_negotiationDialogue_AmbientVolumeMax", 10f);
        }
    }
}