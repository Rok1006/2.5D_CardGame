using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSpawner : MonoBehaviour
{
    ItemInfo itemInfo;
    public ItemInfo[] itemList;

    public string itemNameInString;
    public TextMeshProUGUI itemName;
    public SpriteRenderer itemImage;
    // Start is called before the first frame update
    void Start()
    {
        var randomItem = Random.Range(0, itemList.Length);
        itemInfo = itemList[randomItem];
        itemName.text = itemInfo.name.ToString();
        itemImage.sprite = itemInfo.itemImage;
        itemNameInString = itemInfo.name.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MoveItemCardDown()
    {
        this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(0, 0, 2.5f);
        
    }

    public void UsedByPlayer()
    {
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward * -1);
        RaycastHit hit;
        if(Physics.Raycast(ray , out hit , 10f))
        {
            if(hit.collider.tag == "Player")
            {
                switch (itemNameInString)
                {
                    case "Normal Elixir":
                        hit.collider.gameObject.GetComponent<Player>().health += 5;
                        break;
                    case "Strong Elixir":
                        hit.collider.gameObject.GetComponent<Player>().health += 8;
                        break;
                    case "Copper Shield":
                        hit.collider.gameObject.GetComponent<Player>().defense += 3;
                        break;
                    case "Gold Shield":
                        hit.collider.gameObject.GetComponent<Player>().defense += 5;
                        break;
                }
            }
        }

        Destroy(gameObject);
    }
}
