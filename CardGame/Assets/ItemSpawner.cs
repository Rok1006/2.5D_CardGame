using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSpawner : MonoBehaviour
{
    ItemInfo itemInfo;
    public ItemInfo[] itemList;

    public TextMeshProUGUI itemName;
    public SpriteRenderer itemImage;
    // Start is called before the first frame update
    void Start()
    {
        var randomItem = Random.Range(0, itemList.Length);
        itemInfo = itemList[randomItem];
        itemName.text = itemInfo.name.ToString();
        itemImage.sprite = itemInfo.itemImage;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
