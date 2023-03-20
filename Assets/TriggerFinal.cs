using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinal : MonoBehaviour
{  
    public GameObject monstro, coisasnovas, hihihi;
    public Transform reference;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            var m = Instantiate(monstro, reference.position, Quaternion.identity);
            //CopyValues(monstro, m);
            GameObject.Find("Coisi").active=false;
            hihihi.active=true;
            coisasnovas.active=true;
            Destroy(this.gameObject);
        }
    }

    void CopyValues<T>(T from, T to) {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
    }
}
