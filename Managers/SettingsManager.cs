﻿using MelonLoader;
using MelonLoader.Utils;
using SelectiveEffects.Properties;

namespace SelectiveEffects.Managers;

internal static partial class SettingsManager
{
    private const string SettingsFileName = $"{MelonBuildInfo.ModName}.cfg";
    private const string SettingsPath = "UserData/" + SettingsFileName;

    private static readonly FileSystemWatcher Watcher = new(MelonEnvironment.UserDataDirectory);

    static SettingsManager()
    {
        Load();

        // Create file at runtime if it doesn't exists
        MelonPreferences.Save();

        Watcher.NotifyFilter = NotifyFilters.LastWrite
                               | NotifyFilters.Size;

        Watcher.Filter = SettingsFileName;
        Watcher.EnableRaisingEvents = true;

        Watcher.Changed += Main.QueueReload;
    }

    internal static void Load()
    {
        MainCategory.Init();
        FeverCategory.Init();
        JudgementCategory.Init();
        HitCategory.Init();
        MusicHeartsCategory.Init();
        MiscCategory.Init();
    }
}