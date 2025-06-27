using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using HarmonyLib;
using RimWorld;
using Verse;

namespace Meditation;

public class Base : Mod
{
    private static List<ThingDef> allMeditationSpots;

    public Base(ModContentPack content) : base(content)
    {
        new Harmony("sf.meditation.comfy").Patch(
            AccessTools.Method(AccessTools.FirstInner(typeof(MeditationUtility),
                type => type.Name.Contains("AllMeditationSpotCandidates") &&
                        typeof(IEnumerator).IsAssignableFrom(type)), "MoveNext"),
            transpiler: new HarmonyMethod(typeof(Base), nameof(Transpiler)));
        LongEventHandler.ExecuteWhenFinished(() =>
        {
            allMeditationSpots = [ThingDefOf.MeditationSpot];
            foreach (var def in DefDatabase<ThingDef>.AllDefs)
            {
                if (def.HasModExtension<BuildingExtension_MeditationOn>())
                {
                    allMeditationSpots.Add(def);
                }
            }
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Func<ThingDef, IEnumerable<Thing>> AllOnMapOfPawnWithDef(Pawn pawn)
    {
        return def => pawn.Map.listerBuildings.AllBuildingsColonistOfDef(def);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Thing> AllMeditationSpotsForPawn(Pawn pawn)
    {
        return allMeditationSpots.SelectMany(AllOnMapOfPawnWithDef(pawn));
    }

    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var list = instructions.ToList();
        var info1 = AccessTools.Method(typeof(ListerBuildings), nameof(ListerBuildings.AllBuildingsColonistOfDef));
        var idx1 = list.FindIndex(ins => ins.Calls(info1)) - 3;
        list.RemoveRange(idx1, 4);
        list.Insert(idx1,
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Base), nameof(AllMeditationSpotsForPawn))));
        return list;
    }
}