using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    [SerializeField] private VoidEventChannal DoorTriggerEventChannel;
    
    private void OnEnable()
    {
       // getatrigger.DoorDelegate += Open;
        DoorTriggerEventChannel.AddListener(Open);
    }
    private void OnDisable()
    {
        //getatrigger.DoorDelegate -= Open;
        DoorTriggerEventChannel.RemoveListener(Open);
    }
    // Start is called before the first frame update
    void Open()
    {
        Destroy(gameObject,5f);
    }
}
