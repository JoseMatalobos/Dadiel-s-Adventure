using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectManagement : MonoBehaviour
{
    public string charSelected;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("Has seleccionado a: " + charSelected);
    }
}
