using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/EventChannals/VoidEventChannel",fileName = "VoidEventChanel")]
public class VoidEventChannal : ScriptableObject
{
    private event System.Action Delegate;

    public void BroadCast()
    {
        Delegate?.Invoke();
    }

    public void AddListener(System.Action action)
    {
        Delegate += action;
    }
    public void RemoveListener(System.Action action)
    {
        Delegate -= action;
    }
}
