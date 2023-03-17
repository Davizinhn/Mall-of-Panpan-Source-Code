using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PegarObjeto : MonoBehaviour
{
    public float distance = 2f;
    public float pushForce = 500f;
    public float maxDistanceFromGround = 0.5f;
    public LayerMask collisionLayer;

    private Rigidbody pickedObject;
    public GameObject EPicking;
    public bool estouSegurando = false;
    public List<string> inventory = new List<string>{};

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (!estouSegurando && Physics.Raycast(ray, out hit, distance, collisionLayer))
        {
            if (hit.transform.gameObject.tag == "Pegavel")
            {
                            EPicking.active=true;
                if (Input.GetMouseButtonDown(0))
                {
                    pickedObject = hit.transform.gameObject.GetComponent<Rigidbody>();
                    pickedObject.constraints = RigidbodyConstraints.None;
                    pickedObject.isKinematic = true;
                    pickedObject.freezeRotation = true;
                    pickedObject.useGravity = false;
                    estouSegurando = true;
                }
            }
            else if (hit.transform.gameObject.tag == "Porta")
            {
                                            EPicking.active=true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(hit.transform.gameObject.GetComponent<Animator>().tag != "Abrir")
                    {
                    hit.transform.gameObject.GetComponent<Animator>().Play("Abrir");
                    hit.transform.gameObject.GetComponent<AudioSource>().Play();
                    }   
                }
            }
            else if (hit.transform.gameObject.tag == "Item")
            {
                                            EPicking.active=true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject.Find("TipManager").GetComponent<TipManager>().ShowItem(hit.transform.gameObject.GetComponent<Item>().type.ToString()+" 1x");
                    inventory.Add(hit.transform.gameObject.GetComponent<Item>().type.ToString());
                    Destroy(hit.transform.gameObject);
                }
            }
            else if (hit.transform.gameObject.tag == "Comidinha")
            {
                                            EPicking.active=true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                                            int ha=0;
                                            bool HasStake =false; 
                                            foreach(string item in inventory)
                                            {
                                                bool noneedtosearch = false;
                                                if(item=="Steak" && !noneedtosearch)
                                                {
                                                    HasStake = true;
                                                    noneedtosearch = true;
                                                    for (int i = 0; i < inventory.Count; i++) 
                                                    {
                                                        if(item == inventory[i])
                                                        {
                                                            ha = i;
                                                        }
                                                    }
                                                }
                                            }
                                            if(HasStake)
                                            {    
                                                if(hit.transform.gameObject.GetComponent<ComidaControler>().canAdd)
                                                {
                                                    inventory.RemoveAt(ha);
                                                    hit.transform.gameObject.GetComponent<ComidaControler>().AddComida();
                                                }
                                            }
                                            else if(!HasStake && hit.transform.gameObject.GetComponent<ComidaControler>().canAdd && !hit.transform.gameObject.GetComponent<ComidaControler>().jato)
                                            {
                                                GameObject.Find("TipManager").GetComponent<TipManager>().ShowItem("You don't have any food");
                                            }
                }
            }
            else{
                EPicking.active=false;
            }
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distance, Color.green);
        }else{
                        EPicking.active=false;
        }
        if (estouSegurando)
        {
                        EPicking.active=false;
            if (Input.GetMouseButtonUp(0))
            {
                pickedObject.isKinematic = false;
                pickedObject.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                pickedObject.freezeRotation = true;

                if (IsNearGround(pickedObject))
                {
                    pickedObject.useGravity = true;
                }
                else
                {
                    pickedObject.useGravity = true;
                }

                pickedObject = null;
                estouSegurando = false;
            }
        }

        if (pickedObject != null)
        {
            Vector3 newPosition = Camera.main.transform.position + Camera.main.transform.forward * distance;
            Vector3 direction = newPosition - pickedObject.transform.position;

            RaycastHit obstacleHit;
            if (Physics.Raycast(pickedObject.transform.position, direction, out obstacleHit, direction.magnitude, collisionLayer))
            {
                newPosition = obstacleHit.point;
            }

            pickedObject.MovePosition(newPosition);

            if (Input.GetKey(KeyCode.R))
            {
                pickedObject.AddForce(Camera.main.transform.forward * pushForce, ForceMode.Force);
            }
        }
    }

    bool IsNearGround(Rigidbody rb)
    {
        RaycastHit hit;
        if (rb != null)
        {
            if (Physics.Raycast(rb.transform.position, Vector3.down, out hit, maxDistanceFromGround))
            {
                if (hit.collider.gameObject.CompareTag("Solo"))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
