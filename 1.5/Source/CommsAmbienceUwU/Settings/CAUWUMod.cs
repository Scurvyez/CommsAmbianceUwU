using System;
using UnityEngine;
using Verse;

namespace CommsAmbienceUwU
{
    public class CAUWUMod : Mod
    {
        public static CAUWUMod Mod;
        
        private CAUWUSettings _settings;
        private const float _elementHeight = 25f;
        private const float _elementSpacing = 20f;
        private const float _sliderMin = 0f;
        private const float _sliderMax = 10f;
        
        public CAUWUMod(ModContentPack content) : base(content)
        {
            Mod = this;
            _settings = GetSettings<CAUWUSettings>();
        }
        
        public override string SettingsCategory()
        {
            return "CAUWU_ModName".Translate();
        }
        
        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            float halfWidth = inRect.width / 2f;

            Rect leftRect = new (inRect.x, inRect.y, halfWidth - 10f, inRect.height);
            Rect rightRect = new (inRect.x + halfWidth + 10f, inRect.y, halfWidth - 10f, inRect.height);

            DrawLeftSideSettings(leftRect);
            DrawRightSideSettings(rightRect);
            
            _settings.Write();
        }
        
        private void DrawLeftSideSettings(Rect leftRect)
        {
            Listing_Standard listLeft = new ();
            listLeft.Begin(leftRect);

            DrawSettingWithSlider(leftRect, listLeft,
                "CAUWU_TradeDialogue_AmbientVolumeMaxLabel".Translate().Colorize(CAUWULog.MessageMsgCol)
                + _settings._tradeDialogue_AmbientVolumeMax.ToString("F2"),
                "CAUWU_TradeDialogue_AmbientVolumeMaxToolTip".Translate(),
                ref _settings._tradeDialogue_AmbientVolumeMax,
                _sliderMin, _sliderMax,
                AssetManager.TradeDialogue);

            listLeft.End();
        }

        private void DrawRightSideSettings(Rect rightRect)
        {
            Listing_Standard listRight = new ();
            listRight.Begin(rightRect);

            DrawSettingWithSlider(rightRect, listRight,
                "CAUWU_NegotiationDialogue_AmbientVolumeMaxLabel".Translate().Colorize(CAUWULog.MessageMsgCol)
                + _settings._negotiationDialogue_AmbientVolumeMax.ToString("F2"),
                "CAUWU_NegotiationDialogue_AmbientVolumeMaxToolTip".Translate(),
                ref _settings._negotiationDialogue_AmbientVolumeMax,
                _sliderMin, _sliderMax,
                AssetManager.NegotiationDialogue);

            listRight.End();
        }
        
        private static void DrawSettingWithSlider<T>(Rect inRect, Listing_Standard list, string labelText, string tooltipText, ref T settingValue, T minValue, T maxValue, Texture2D texture)
            where T : struct, IConvertible
        {
            float settingFloat = Convert.ToSingle(settingValue);
            float minFloat = Convert.ToSingle(minValue);
            float maxFloat = Convert.ToSingle(maxValue);
            
            Rect labelRect = new (0, list.CurHeight, inRect.width, _elementHeight);
            Widgets.Label(labelRect, labelText);
            TooltipHandler.TipRegion(labelRect, tooltipText);
            
            list.Gap(_elementSpacing);
            
            float sliderWidth = inRect.width / 2;
            Rect sliderRect = new (0, list.CurHeight, sliderWidth, _elementHeight);
            settingFloat = Widgets.HorizontalSlider(sliderRect, settingFloat, minFloat, maxFloat, true);
            settingValue = (T)Convert.ChangeType(settingFloat, typeof(T));
            
            list.Gap(_elementSpacing * 2f);
            
            Rect textureRect = new (0, list.CurHeight, inRect.width, inRect.width);
            if (texture != null)
            {
                GUI.DrawTexture(textureRect, texture);
            }

            list.Gap(_elementSpacing);
        }
    }
}