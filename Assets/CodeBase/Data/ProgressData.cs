using System;

namespace CodeBase.Data
{
    [Serializable]
    public class ProgressData
    {
        public SettingsData SettingsData = new();
    }

    [Serializable]
    public class SettingsData
    {
        public bool IsSoundEnabled;
    }
}