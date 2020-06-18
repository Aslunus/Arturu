using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject dragedObj;
    RayCast inventory;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCast>();
    }

   
    void Update()
    {
        
    } 
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragedObj = gameObject;
        inventory.dragPrefab.SetActive(true);
        inventory.dragPrefab.GetComponent<CanvasGroup>().blocksRaycasts = false;
        if(dragedObj.GetComponent<CurrentItem>())
        {
            int index = dragedObj.GetComponent<CurrentItem>().index;
            inventory.dragPrefab.GetComponent<Image>().sprite = inventory.item[index].icon;
            if (inventory.item[index].CountItem > 1)
            {
                inventory.dragPrefab.transform.GetChild(0).GetComponent<Text>().text = inventory.item[index].CountItem.ToString();
            }
            else
            {
                inventory.dragPrefab.transform.GetChild(0).GetComponent<Text>().text = null;
            }
            if (inventory.dragPrefab.GetComponent<Image>().sprite == null)
            {
                dragedObj = null; 
                inventory.dragPrefab.SetActive(false);
            }

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        inventory.dragPrefab.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragedObj = null;
        inventory.dragPrefab.SetActive(false);
        inventory.dragPrefab.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
