using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerTerminou : MonoBehaviour
{
    public GameObject monstro, Loading;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            monstro.GetComponent<EnemyAI>().canSeguirJogador=false;
            Camera.main.GetComponent<FirstPersonLook>().enabled=false;
            other.gameObject.GetComponent<FirstPersonMovement>().enabled=false;
            other.gameObject.GetComponent<Jump>().enabled=false;
            Loading.active=true;
            StartCoroutine(Teleport());
        }
    }
    
    public IEnumerator Teleport()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Soon");
        Destroy(this.gameObject);
        
    }
}
