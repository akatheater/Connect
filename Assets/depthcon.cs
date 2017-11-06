using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class depthcon : MonoBehaviour
{
    private bool on = false;
    private void Update()
    {
        if (!on && (transform.position.y < 3.9f))
        {
            on = true;
            GetComponent<DepthOfFieldDeprecated>().enabled = true;
        }

        if (on && (transform.position.y > 3.9f))
        {
            on = false;
            GetComponent<DepthOfFieldDeprecated>().enabled = false;
        }

    }
}
