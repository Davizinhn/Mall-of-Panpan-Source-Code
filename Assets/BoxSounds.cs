using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxSounds : MonoBehaviour
{
    public AudioClip[] clips;
    public Vector3 spawnPos;
        public LayerMask collisionLayer;

    private void OnCollisionEnter(Collision collision)
    {
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(clips[Random.RandomRange(0, clips.Length - 1)]);
            if(!GameObject.FindWithTag("Player").GetComponent<PegarObjeto>().estouSegurando && collision.transform.tag=="Solo" || !GameObject.FindWithTag("Player").GetComponent<PegarObjeto>().estouSegurando && collision.transform.tag=="Pegavel")
            {
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
       
    }

    private void OnCollisionExit(Collision collision)
    {
            if(collision.transform.tag=="Pegavel")
            {
                this.gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeAll;
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            }
       
    }

    public void Awake()
    {
                        spawnPos = this.gameObject.transform.position;
    }

    public void Update()
    {        
        this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, 0.5f, collisionLayer))
            {
                if (hit.transform.gameObject.tag == "Pegavel" || hit.transform.gameObject.tag == "Solo")
                {
                    this.gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeAll;
                    this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
                }
            }
            else
            {
                if(!GameObject.FindWithTag("Player").GetComponent<PegarObjeto>().estouSegurando)
                {
                    this.gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
                    this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                    this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
                }
            }
        if(this.transform.position.y < -45)
        {
            this.gameObject.transform.position = spawnPos;
        }
    }
}
