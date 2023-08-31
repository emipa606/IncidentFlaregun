using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace RimWorld;

public class Verb_MeleeAttackDamageToPart : Verb_MeleeAttack
{
	private IEnumerable<DamageInfo> DamageInfosToApply(LocalTargetInfo target)
	{
		float num = verbProps.AdjustedMeleeDamageAmount(this, CasterPawn);
		float armorPenetration = verbProps.AdjustedArmorPenetration(this, CasterPawn);
		DamageDef def = verbProps.meleeDamageDef;
		BodyPartGroupDef bodyPartGroupDef = null;
		HediffDef hediffDef = null;
		num = Rand.Range(num * 0.8f, num * 1.2f);
		if (CasterIsPawn)
		{
			bodyPartGroupDef = verbProps.AdjustedLinkedBodyPartsGroup(tool);
			if (num >= 1f)
			{
				if (base.HediffCompSource != null)
				{
					hediffDef = base.HediffCompSource.Def;
				}
			}
			else
			{
				num = 1f;
				def = DamageDefOf.Blunt;
			}
		}
		ThingDef source = ((base.EquipmentSource == null) ? CasterPawn.def : base.EquipmentSource.def);
		Vector3 direction = (target.Thing.Position - CasterPawn.Position).ToVector3();
		DamageInfo damageInfo2 = new DamageInfo(def, num, armorPenetration, -1f, caster, null, source);
		damageInfo2.SetBodyRegion(BodyPartHeight.Undefined, BodyPartDepth.Outside);
		damageInfo2.SetWeaponBodyPartGroup(bodyPartGroupDef);
		damageInfo2.SetWeaponHediff(hediffDef);
		damageInfo2.SetAngle(direction);
		yield return damageInfo2;
		if (tool != null && tool.extraMeleeDamages != null)
		{
			foreach (ExtraDamage extraDamage in tool.extraMeleeDamages)
			{
				if (Rand.Chance(extraDamage.chance))
				{
					num = extraDamage.amount;
					damageInfo2 = new DamageInfo(amount: Rand.Range(num * 0.8f, num * 1.2f), def: extraDamage.def, armorPenetration: extraDamage.AdjustedArmorPenetration(this, CasterPawn), angle: -1f, instigator: caster, hitPart: target.Pawn.health.hediffSet.GetNotMissingParts(BodyPartHeight.Undefined, BodyPartDepth.Undefined, verbProps.bodypartTagTarget).RandomElement(), weapon: source);
					damageInfo2.SetBodyRegion(BodyPartHeight.Undefined, BodyPartDepth.Outside);
					damageInfo2.SetWeaponBodyPartGroup(bodyPartGroupDef);
					damageInfo2.SetWeaponHediff(hediffDef);
					damageInfo2.SetAngle(direction);
					yield return damageInfo2;
				}
			}
		}
		if (!surpriseAttack || ((verbProps.surpriseAttack == null || verbProps.surpriseAttack.extraMeleeDamages.NullOrEmpty()) && (tool == null || tool.surpriseAttack == null || tool.surpriseAttack.extraMeleeDamages.NullOrEmpty())))
		{
			yield break;
		}
		IEnumerable<ExtraDamage> enumerable = Enumerable.Empty<ExtraDamage>();
		if (verbProps.surpriseAttack != null && verbProps.surpriseAttack.extraMeleeDamages != null)
		{
			enumerable = enumerable.Concat(verbProps.surpriseAttack.extraMeleeDamages);
		}
		if (tool != null && tool.surpriseAttack != null && !tool.surpriseAttack.extraMeleeDamages.NullOrEmpty())
		{
			enumerable = enumerable.Concat(tool.surpriseAttack.extraMeleeDamages);
		}
		foreach (ExtraDamage extraDamage2 in enumerable)
		{
			int num4 = GenMath.RoundRandom(extraDamage2.AdjustedDamageAmount(this, CasterPawn));
			DamageInfo damageInfo3 = new DamageInfo(armorPenetration: extraDamage2.AdjustedArmorPenetration(this, CasterPawn), def: extraDamage2.def, amount: num4, angle: -1f, instigator: caster, hitPart: null, weapon: source);
			damageInfo3.SetBodyRegion(BodyPartHeight.Undefined, BodyPartDepth.Outside);
			damageInfo3.SetWeaponBodyPartGroup(bodyPartGroupDef);
			damageInfo3.SetWeaponHediff(hediffDef);
			damageInfo3.SetAngle(direction);
			yield return damageInfo3;
		}
	}

	protected override DamageWorker.DamageResult ApplyMeleeDamageToTarget(LocalTargetInfo target)
	{
		DamageWorker.DamageResult result = new DamageWorker.DamageResult();
		foreach (DamageInfo item in DamageInfosToApply(target))
		{
			if (target.ThingDestroyed)
			{
				break;
			}
			result = target.Thing.TakeDamage(item);
		}
		return result;
	}
}
