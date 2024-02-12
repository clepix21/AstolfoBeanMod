using BepInEx;
using HarmonyLib;
using LethalLib.Modules;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace AstolfoBeanScrap
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class AstolfoBeanMod : BaseUnityPlugin
    {
        const string GUID = "clepix21.lc.AstolfoBeanscrap";
        const string NAME = "Astolfo Bean Scrap";
        const string VERSION = "1.0.0";

        public static AstolfoBeanMod instance;

        void Awake()
        {
            instance = this;

            string assetsdir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "itemastolfo");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetsdir);

            Item AstolfoBean = bundle.LoadAsset<Item>("Assets/AstolfoBeanScrap.asset");

            NetworkPrefabs.RegisterNetworkPrefab(AstolfoBean.spawnPrefab);
            Utilities.FixMixerGroups(AstolfoBean.spawnPrefab);
            Items.RegisterScrap(AstolfoBean, 40, Levels.LevelTypes.All);

            TerminalNode node = ScriptableObject.CreateInstance<TerminalNode>(); 
            node.clearPreviousText = true;
            node.displayText = "The Bean\n\n";
            Items.RegisterShopItem(AstolfoBean, null, null, node, 0);

            Logger.LogInfo("Loaded Astolfo Bean");



        }
    }
}