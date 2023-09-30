using UnityEngine;
using UnityEngine.InputSystem;

public class SpellSwitch : MonoBehaviour
{
    [SerializeField] private Spells[] availableSpells; // List of available spells
    private int currentSpellIndex = 0; // Index of the currently selected spell
    private PlayerControls playerControls;

    private void Start()
    {
        // Ensure there are available spells and set the initial spell
        if (availableSpells.Length > 0)
        {
            currentSpellIndex = 0;
            SelectSpell(currentSpellIndex);
        }
    }

    private void Awake()
    {
        playerControls = new PlayerControls();

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        bool isSpellSwitchHeldDown = playerControls.Player.SpellSwitch.ReadValue<float>() > 0.1;
        // Check for input to change the spell
        if (isSpellSwitchHeldDown) // Change this to your desired input key.
        {
            CycleSpell();
        }
    }

    private void CycleSpell()
    {
        // Cycle through the available spells
        currentSpellIndex = (currentSpellIndex + 1) % availableSpells.Length;
        SelectSpell(currentSpellIndex);
    }

    private void SelectSpell(int index)
    {
        // Activate the selected spell and deactivate others
        for (int i = 0; i < availableSpells.Length; i++)
        {
            if (i == index)
            {
                availableSpells[i].Activate();
            }
            else
            {
                availableSpells[i].Deactivate();
            }
        }
    }
}
