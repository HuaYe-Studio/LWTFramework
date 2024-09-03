using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetect : MonoBehaviour
{
    [SerializeField] private float detectionRadius=0.1f;
    [SerializeField] private LayerMask GoundLayer;
    private Collider[] colliders=new Collider[1];
   
    // Start is called before the first frame update
    public bool onGorund
    {
        get
        {
             Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius,GoundLayer);
             if (hitColliders .Length>0)
             {
                 return true;
             }

             return false;
        }
    }
}
