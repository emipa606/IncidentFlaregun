using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace LingGame;

public class Verb_LaunchIncidentComp : ThingComp
{
    public IncidentDef incidentDef;

    public Verb_LaunchIncidentCompp Props => (Verb_LaunchIncidentCompp)props;

    public override string TransformLabel(string label)
    {
        if (Props.CanSee && incidentDef != null)
        {
            return incidentDef.LabelCap + " " + label;
        }

        return base.TransformLabel(label);
    }

    public override void PostDraw()
    {
        base.PostDraw();
        if (Props.Dingly)
        {
            incidentDef = Props.incidentDef;
        }
        else if (incidentDef == null)
        {
            incidentDef = DefDatabase<IncidentDef>.AllDefs.RandomElement();
        }
    }

    public override void PostExposeData()
    {
        base.PostExposeData();
        Scribe_Defs.Look(ref incidentDef, "incidentDef");
    }

    public override IEnumerable<Gizmo> CompGetGizmosExtra()
    {
        if (!Props.CanSee)
        {
            yield break;
        }

        yield return new Command_Action
        {
            defaultLabel = "QieHuanShiJian".Translate(),
            icon = ContentFinder<Texture2D>.Get("LingUI/QeHuanShiJian"),
            action = delegate
            {
                var list = new List<DebugMenuOption>();
                foreach (var current2 in DefDatabase<IncidentDef>.AllDefs)
                {
                    list.Add(new DebugMenuOption(string.Concat(new object[] { current2.LabelCap }),
                        DebugMenuOptionMode.Action, delegate { incidentDef = current2; }));
                }

                Find.WindowStack.Add(new Dialog_DebugOptionListLister(list));
            }
        };
    }
}