using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacSwitcher : MonoBehaviour {
    public PlayerController main;
    public PlayerController second;

    private bool isMain = true;

    private void Awake()
    {
        main.active = true;
        second.active = false;
    }
    private void Update()
    {
        if (GameSystem.InputKeys.Switch())
        {
            if (isMain)
            {
                second.active = true;
                main.active = false;
                GetComponent<Tracker>().target = second.transform;
            }
            else
            {
                second.active = false;
                main.active = true;
                GetComponent<Tracker>().target = main.transform;
            }
            isMain = !isMain;
        }
    }
}
