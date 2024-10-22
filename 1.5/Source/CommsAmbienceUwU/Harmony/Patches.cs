using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace CommsAmbienceUwU
{
    [StaticConstructorOnStartup]
    public class Patches
    {
        static Patches()
        {
            Harmony harmony = new (id: "rimworld.scurvyez.commsambienceuwu");
            
            harmony.Patch(original: AccessTools.Constructor(typeof(Dialog_Trade), new[] { typeof(Pawn), typeof(ITrader), typeof(bool) } ),
                postfix: new HarmonyMethod(typeof(Patches), nameof(Dialog_TradeConstructor_Postfix)));
            
            harmony.Patch(original: AccessTools.Method(typeof(Faction), nameof(Faction.TryOpenComms)),
                postfix: new HarmonyMethod(typeof(Patches), nameof(Faction_TryOpenComms_Postfix)));
        }
        
        private static void Dialog_TradeConstructor_Postfix(Dialog_Trade __instance, Pawn playerNegotiator, ITrader trader, bool giftsOnly)
        {
            if (__instance.soundAmbient == null) return;
            
            foreach (SubSoundDef subSound in __instance.soundAmbient.subSounds)
            {
                subSound.volumeRange = new FloatRange(0f, CAUWUSettings.TradeDialogue_AmbientVolumeMax);
            }
        }
        
        private static void Faction_TryOpenComms_Postfix(Pawn negotiator, Faction __instance)
        {
            if (Find.WindowStack.Windows.Last() is not Dialog_Negotiation dialog_Negotiation) return;
            if (dialog_Negotiation.soundAmbient == null) return;
            
            foreach (SubSoundDef subSound in dialog_Negotiation.soundAmbient.subSounds)
            {
                subSound.volumeRange = new FloatRange(0f, CAUWUSettings.NegotiationDialogue_AmbientVolumeMax);
            }
        }
    }
}