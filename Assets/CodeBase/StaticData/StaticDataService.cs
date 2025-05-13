using System;
using CodeBase.UI.AbstractWindow;
using CodeBase.UI.Sound;
using CodeBase.UI.Sound.Configs;

namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService, IDisposable
    {
        public void LoadAll()
        {
            
        }

        public SoundConfig GetSoundConfig(SoundTypeId soundTypeId)
        {
            return null;
        }

        public TWindow GetWindow<TWindow>() where TWindow : AbstractWindowBase
        {
            return null;
        }

        public SoundPlayerView GetSoundPlayerViewPrefab()
        {
            return null;
        }

        public void Dispose()
        {
            
        }
    }
}