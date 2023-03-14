using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject activeThis;
    public void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player")
        {
            activeThis.active=true;
            Destroy(this.gameObject);
        }
    }
}
