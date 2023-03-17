using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Steak
    }
    public ItemType type;

    public void Awake()
    {
        this.gameObject.tag="Item";
    }
}
