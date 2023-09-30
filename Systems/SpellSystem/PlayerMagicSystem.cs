using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    [SerializeField] private Spells spellToCast;

    [SerializeField] private float maxEnergy = 100f;
    [SerializeField] private float currentEnergy;
    [SerializeField] private float energyRechargeRate = 2f;
    [SerializeField] private float timeToWaitForRecharge = 1f;
    private float currentEnergyRechargeTimer;
    [SerializeField] private float timeBetweenCasts = 0.25f;
    private float currentCastTimer;
    
    [SerializeField] private Transform castPoint;

    private bool castingMagic = false;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();

        currentEnergy = maxEnergy;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        bool isSpellCastHeldDown = playerControls.Player.SpellCast.ReadValue<float>() > 0.1;
        bool hasEnoughEnergy = currentEnergy - spellToCast.SpellToCast.EnergyCost >= 0f;
        
        if (!castingMagic && isSpellCastHeldDown && hasEnoughEnergy)
        {
            castingMagic = true;
            currentEnergy -= spellToCast.SpellToCast.EnergyCost;
            currentCastTimer = 0;
            currentEnergyRechargeTimer = 0;
            CastSpell();
        }

        if (castingMagic)
        {
            currentCastTimer += Time.deltaTime;

            if (currentCastTimer > timeBetweenCasts) castingMagic = false;
        }

        if (currentEnergy < maxEnergy && !castingMagic && !isSpellCastHeldDown) 
        {
            if (currentEnergyRechargeTimer > timeToWaitForRecharge)
            
             currentEnergyRechargeTimer += Time.deltaTime;
            {
                currentEnergy += energyRechargeRate * Time.deltaTime;
            if (currentEnergy > maxEnergy) currentEnergy = maxEnergy;
            }      
        }

    }

    void CastSpell()
    {
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }

}
