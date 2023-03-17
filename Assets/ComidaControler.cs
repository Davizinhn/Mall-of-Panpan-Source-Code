using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidaControler : MonoBehaviour
{
    public int precisodesse;
    public int tenhoesses;
    bool A = true;
    public bool canAdd = true;
    public AudioSource tummmm;

    public void Update()
    {   
        if(precisodesse==tenhoesses && A==true)
        {
            A = false;
            StartCoroutine(abrirportinha());
        }
    }

    IEnumerator abrirportinha()
    {
        yield return new WaitForSeconds(3f);
        // coisas
        Debug.Log("debig");
        this.gameObject.tag="Untagged";
        StopCoroutine(abrirportinha());
    }

    public void AddComida()
    {
        canAdd=false;
        tummmm.Play();
        tenhoesses = tenhoesses+1;
        StartCoroutine(podeVoltar());
    }

    IEnumerator podeVoltar()
    {
        yield return new WaitForSeconds(2.25f);
        canAdd = true;
        StopCoroutine(podeVoltar());
    }
}
