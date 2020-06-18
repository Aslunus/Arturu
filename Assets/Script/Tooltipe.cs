using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltipe : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{

    RayCast inventory;

    void OnDisable()
    {
        inventory.tooltipobj.SetActive(false);
    }

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RayCast>();
    }

    void Update()
    {
        inventory.tooltipobj.transform.position = Input.mousePosition;
    }
  public void OnPointerEnter(PointerEventData eventData)
    {
        
        CurrentItem currenitem = GetComponent<CurrentItem>();
        Item item = inventory.item[currenitem.index];
        if(item.id != 0)
        {
           inventory.tooltipobj.SetActive(true);
           inventory.icon.sprite = item.icon;
           inventory.itemNeame.text = item.NameItem;
           inventory.description.text = item.DescriptionItem;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventory.tooltipobj.SetActive(false);
    }

}
