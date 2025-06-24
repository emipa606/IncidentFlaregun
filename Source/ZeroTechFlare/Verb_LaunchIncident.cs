using RimWorld;
using Verse;

namespace LingGame;

public class Verb_LaunchIncident : Verb
{
    protected override bool TryCastShot()
    {
        var incidentDef = EquipmentSource.GetComp<Verb_LaunchIncidentComp>().IncidentDef;
        var parms = StorytellerUtility.DefaultParmsNow(incidentDef.category, caster.Map);
        incidentDef.Worker.TryExecute(parms);
        EquipmentSource.Destroy();
        return true;
    }
}