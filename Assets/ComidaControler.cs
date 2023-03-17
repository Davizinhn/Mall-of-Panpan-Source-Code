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
    public GameObject portaparapoder;
    public bool jato;

    public void Update()
    {   
        if(precisodesse==tenhoesses && A==true)
        {
            A = false;
            jato = true;
            StartCoroutine(abrirportinha());
        }
    }

    IEnumerator abrirportinha()
    {
        yield return new WaitForSeconds(3f);
        // coisas
        portaparapoder.tag="Porta";
        this.gameObject.GetComponent<EnemyAI>().canSeguirJogador=true;
        this.gameObject.tag="Untagged";
        this.gameObject.active=false;
                this.gameObject.active=true;
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
