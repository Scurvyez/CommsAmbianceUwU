using UnityEngine;
using Verse;

namespace CommsAmbienceUwU
{
    [StaticConstructorOnStartup]
    public static class AssetManager
    {
        public static readonly Texture2D TradeDialogue = ContentFinder<Texture2D>.Get("CommsAmbienceUwU/UI/TradeDialogue");
        public static readonly Texture2D NegotiationDialogue = ContentFinder<Texture2D>.Get("CommsAmbienceUwU/UI/NegotiationDialogue");
    }
}