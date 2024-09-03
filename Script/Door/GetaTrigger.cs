using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private VoidEventChannal DoorTriggerEventChannel;
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        DoorTriggerEventChannel.BroadCast();
    }
}
