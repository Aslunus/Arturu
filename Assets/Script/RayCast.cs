using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    [HideInInspector]
    public List<Item> item;

    public GameObject database;

    public GameObject CellContainer;
    public KeyCode ShowInventory;
    public KeyCode TakeButton;
    public float Range = 4f;
    public MouseControl mouse;
    public ControllerPLayer player;
    public GameObject point;
    public GameObject dragPrefab;
    public GameObject fire;
    public GameObject fire2;

    public CurrentItem currentitem;

    [Header("Massage")]
    public GameObject MassagerManager;
    public GameObject Massag;

    [Header("Tooltip")]
    public GameObject tooltipobj;
    public Image icon;
    public Text itemNeame;
    public Text description;

    

   


    void Start()
    {

        tooltipobj.SetActive(false);

        item = new List<Item>();
        CellContainer.SetActive(false);

        for (int i = 0; i < CellContainer.transform.childCount; i++)
        {
            CellContainer.transform.GetChild(i).GetComponent<CurrentItem>().index = i;
        }

        for (int i = 0; i < CellContainer.transform.childCount; i++)
        {
            item.Add(new Item());
        }

    }

 
    void Update()
    {
        
        ToggleInventory();
        Raycassst();


    }
    void Raycassst()

    {
        if (Input.GetKeyDown(TakeButton))
        {
            Debug.DrawRay(transform.position, transform.forward * 4f, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hit, Range))

                if (hit.collider.GetComponent<Item>())
                {
                    Item currentItem = hit.collider.GetComponent<Item>();
                    DisplayItems();
                    Massage(currentItem);
                    AddItem(hit.collider.GetComponent<Item>());
                }
        }
    }
    public void AddItem(Item currentItem)
    {
            if(currentItem.Issackable)
            {
                AddstackItem(currentItem);
            }
            else
            {
                AddunstackItem(currentItem); 
            }
    }
    void AddunstackItem(Item currentItem)
        {
            for (int i = 0; i < item.Count; i++)
            {
                if (item[i].id == 0)
                {
                   
                    item[i] = currentItem;
                    item[i].CountItem = 1;
                    DisplayItems();
                    Destroy(currentItem.gameObject);
                    break;

                }
            }
        }
    void AddstackItem(Item currentItem)
        {
            for (int i =0; i< item.Count; i++)
            {
                if(item[i].id == currentItem.id)
                {
                    item[i].CountItem++;
                    DisplayItems();
                    Destroy(currentItem.gameObject);
                    return;
                }
            }
            AddunstackItem(currentItem);
        }
    void ToggleInventory()
        {
            if (Input.GetKeyDown(ShowInventory))
            {
                if (CellContainer.activeSelf)
                {
                    CellContainer.SetActive(false);
                    player.enabled = true;
                    player.GetComponent<MouseControl>().enabled = true;
                    mouse.enabled = true;
                    Cursor.visible = false;
                    point.SetActive(true);
                  
                }
                else
                {
                    CellContainer.SetActive(true);
                    player.enabled = false;
                    player.GetComponent<MouseControl>().enabled = false;
                    mouse.enabled = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    point.SetActive(false);
                   
                }
            }
            //if(Input.GetKeyDown(KeyCode.Keypad1))
            //{
            //    if (fire.activeSelf /*|| fire2.activeSelf*/)
            //    {
            //       fire.SetActive(false);
               
            //    }
                 
             
            //}

            //if (Input.GetKeyDown(KeyCode.Keypad2))
            //{
            //     if (fire2.activeSelf)
            //     {
            //        fire2.SetActive(false);
            //     }
            //}
    }
    void Massage(Item currentItem)
    {
            GameObject msgObj = Instantiate(Massag);
            msgObj.transform.SetParent(MassagerManager.transform);

            Text msgtxt = msgObj.transform.GetChild(1).GetComponent<Text>();
            msgtxt.text = currentItem.NameItem;
            
            Image msgImg = msgObj.transform.GetChild(0).GetComponent<Image>();
            msgImg.sprite = currentItem.icon;
    }

    public void DisplayItems()
    {
        for (int i = 0; i < item.Count; i++)
        {
            Transform cell = CellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Transform count = icon.GetChild(0);
            Text txt = count.GetComponent<Text>();
            Image img = icon.GetComponent<Image>();

            if (item[i].id != 0)
            {

                img.enabled = true;
                img.sprite = item[i].icon;
                if (item[i].CountItem > 1)
                {
                    txt.text = item[i].CountItem.ToString();
                }
                else
                {
                    txt.text = null;
                }
            }
            else
            {
                img.enabled = false;
                img.sprite = null;
                txt.text = null;
            }
        }
    }
}
