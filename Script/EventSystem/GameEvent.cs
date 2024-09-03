using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour

{
    public static GameEvents current;
    // Start is called before the first frame update
    private void Awake()
    {
        current = this;
    }

    public event Action OnDoorwayTriggerEnter;
    public event Action OnDoorwayTriggerExit;

    public void DoorwayTriggerExit()
    {
        if (OnDoorwayTriggerExit != null)
        {
            OnDoorwayTriggerExit();
        }
    }

    public void DoorwayTriggerEnter()
    {
        if (OnDoorwayTriggerEnter != null)
        {
            OnDoorwayTriggerEnter();
        }
    }
    // Update is called once per frame
    
}
