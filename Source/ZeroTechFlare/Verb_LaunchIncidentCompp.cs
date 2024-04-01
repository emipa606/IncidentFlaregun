using RimWorld;
using Verse;

namespace LingGame;

public class Verb_LaunchIncidentCompp : CompProperties
{
    public readonly bool CanSee = false;

    public readonly bool Dingly = false;
    public IncidentDef incidentDef;

    public Verb_LaunchIncidentCompp()
    {
        compClass = typeof(Verb_LaunchIncidentComp);
    }
}