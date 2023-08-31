using RimWorld;
using Verse;

namespace LingGame;

public class Verb_LaunchIncidentCompp : CompProperties
{
    public bool CanSee = false;

    public bool Dingly = false;
    public IncidentDef incidentDef;

    public Verb_LaunchIncidentCompp()
    {
        compClass = typeof(Verb_LaunchIncidentComp);
    }
}