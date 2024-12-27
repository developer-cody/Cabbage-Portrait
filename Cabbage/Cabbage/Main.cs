using BepInEx;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace Cabbage.Cabbage
{
    [BepInPlugin(Constants.GUID, Constants.Name, Constants.Version)]
    public class Main : BaseUnityPlugin
    {
        public static AssetBundle bundle;
        public static GameObject assetBundleParent;
        public static string assetBundleName = "cabbage";
        public static string parentName = "BundleParent (put objects in here DONT MOVE)";

        void Start()
        {
            GorillaTagger.OnPlayerSpawned(Initialized);
        }

        void Initialized()
        {
            bundle = LoadAssetBundle("Cabbage.Assets." + assetBundleName);
            assetBundleParent = Instantiate(bundle.LoadAsset<GameObject>(parentName));
            assetBundleParent.transform.position = new Vector3(-67.2225f, 11.56f, -82.611f);
            assetBundleParent.name = assetBundleName;
        }

        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}