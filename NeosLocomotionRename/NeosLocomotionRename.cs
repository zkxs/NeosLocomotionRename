using FrooxEngine;
using HarmonyLib;
using NeosModLoader;
using System;
using System.Reflection;

namespace NeosLocomotionRename
{
    public class NeosLocomotionRename : NeosMod
    {
        public override string Name => "NeosLocomotionRename";
        public override string Author => "runtime";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/zkxs/NeosLocomotionRename";

        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.michaelripley.NeosLocomotionRename");
            MethodInfo patch = AccessTools.DeclaredMethod(typeof(NeosLocomotionRename), nameof(NeosLocomotionRename.GetLocomotionNamePostfix));

            Type[] moduleTypes = new Type[]
            {
                typeof(LocomotionModule),
                typeof(NoclipLocomotion),
                typeof(GrabWorldLocomotion),
                typeof(SlideLocomotion),
                typeof(TeleportLocomotion),
            };

            foreach (Type moduleType in moduleTypes)
            {
                MethodInfo originalMethod = AccessTools.DeclaredPropertyGetter(moduleType, nameof(LocomotionModule.LocomotionName));
                if (originalMethod == null)
                {
                    Warn($"Could not find {moduleType.Name}.LocomotionName getter, skipping!");
                    break;
                }
                harmony.Patch(originalMethod, postfix: new HarmonyMethod(patch));
                Msg($"{moduleType.Name} patch installed successfully");
            }
        }

        private static void GetLocomotionNamePostfix(LocomotionModule __instance, ref LocaleString __result)
        {
            __result = __instance.Slot.Name;
        }
    }
}
