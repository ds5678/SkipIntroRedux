using MelonLoader;
using UnityEngine;

namespace SkipIntroRedux
{
    public class Implementation : MelonMod
    {
        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
        }
    }
}
