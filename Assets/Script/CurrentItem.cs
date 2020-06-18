using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentItem : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    [HideInInspector]
    public int index;

     GameObject raycastObj;
     RayCast inventory;
   


    void Start()
    {
        raycastObj = GameObject.FindGameObjectWithTag("MainCamera");
        inventory = raycastObj.GetComponent<RayCast>();

    }

  public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if(inventory.item[index].customEvent != null)
            {
                inventory.item[index].customEvent.Invoke();
            }
            if(inventory.item[index].isRemovable)
            {
                Remove();
            }
        }
       
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(inventory.item[index].isDrop)
            {
                Drop();
                Remove();
            }
          
        }
    }
   public void Remove()
    {
         if (inventory.item[index].id != 0)
         { 
                
                if (inventory.item[index].CountItem > 1)
                {
                    inventory.item[index].CountItem--;
                }
                else
                {
                    inventory.item[index] = new Item();
                }


                inventory.DisplayItems();
         }
    }
    public void Drop()
    {
        if (inventory.item[index].id != 0)
        {
            for(int i = 0; i < inventory.database.transform.childCount; i++)
            {
                Item item = inventory.database.transform.GetChild(i).GetComponent<Item>();
                if (item)
                {
                    if (inventory.item[index].id == item.id)
                    {
                         GameObject dropedObj = Instantiate(item.gameObject);
                         dropedObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward*2;
                    }
                }
            }
            
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragedObject = Drag.dragedObj;
        if (dragedObject == null)
        {
            return;
        }
        CurrentItem currentdrageditem = dragedObject.GetComponent<CurrentItem>();
        if(currentdrageditem)
        {
            Item currenItem = inventory.item[GetComponent<CurrentItem>().index];
            inventory.item[GetComponent<CurrentItem>().index] = inventory.item[currentdrageditem.index];
            inventory.item[currentdrageditem.index] = currenItem;
            inventory.DisplayItems();
        }
    }
}
