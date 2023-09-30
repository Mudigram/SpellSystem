using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "SpellsAbility/Spells")]
public class SpellScriptableObject : ScriptableObject
{
   public float DamageAmount =10f;
   public float EnergyCost = 5f;
   public float Lifetime = 2f;
   public float Speed = 15f;
   public float SpellRadius = 0.5f;
   public float maxEnergy = 100f;
   public float currentEnergy;
   public float energyRechargeRate = 2f;
   public float timeToWaitForRecharge = 1f;
}
