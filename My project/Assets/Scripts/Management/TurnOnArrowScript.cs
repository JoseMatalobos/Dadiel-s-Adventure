using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnArrowScript : MonoBehaviour
{
    ArrowMovement arrowScript;
    void Awake()
    {
        arrowScript = GetComponent<ArrowMovement>();
    }

    void Start()
    {
        arrowScript.enabled = true;
    }
}
