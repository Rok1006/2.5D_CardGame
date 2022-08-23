using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();
    public bool placeItem = false; 
    public bool[] full;
    [SerializeField]private GameObject slotUI; //prefab
    [SerializeField]private GameObject panel;

    void Start()
    {
        PopulateInventory();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            PopulateInventory();
        }
    }
    public void PopulateInventory(){ //at start
        for(int i = 0; i<16; i++){
            GameObject s = Instantiate(slotUI, panel.transform.position, Quaternion.identity);
            s.transform.parent = panel.transform;
            s.transform.localScale = new Vector3(0.1844954f,0.1844954f,0.1844954f);
            slots.Add(s);
        }
    }
    public void PopulateInventWItem(GameObject itemUi){  //make sure it put item only in one slot
        if(placeItem){
           for (int i = 0; i < slots.Count; i++)
           {
               if(full[i] == false){
                    full[i] = true;
                    GameObject item = Instantiate(itemUi, slots[i].transform, false);
                    item.transform.parent = slots[i].transform;
                //     item.transform.localScale = new Vector3(.9f, .9f, .9f);
                   break;
               }
           }
           placeItem = false;
       }

    }
    public void ClearSlot(){

    }
}
