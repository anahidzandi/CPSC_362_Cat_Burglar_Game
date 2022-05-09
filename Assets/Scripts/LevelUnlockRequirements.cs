using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelUnlockRequirements : MonoBehaviour
{
    
    public Selectable Level2Button;
    public Selectable Level3Button;

    // Start is called before the first frame update
    void Start()
    {
        if (LevelUnlock.levelsUnlocked < 2)
        {
            Level2Button.interactable = false;
            Level2Button.enabled = false;
        }
        if (LevelUnlock.levelsUnlocked < 3)
        {
            Level3Button.interactable = false;
            Level3Button.enabled = false;
        }
    }
}
