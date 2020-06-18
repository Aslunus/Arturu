using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public string NameItem;
    public int id;
    public int CountItem;
    public bool Issackable;
    [Multiline(5)]
    public string DescriptionItem;
    public bool isRemovable;
    public bool isDrop;
    public Sprite icon;
    public UnityEvent customEvent;
    
}
