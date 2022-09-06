using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardLayers : MonoBehaviour
{
    public GameObject[] objWithLayers;
    public Canvas ui1;
    void Start()
    {
        
    }

    void Update()
    {

    }
    public void ChangeLayers(int num){
        ui1.sortingLayerName = "R"+num;
        for(int i = 0; i<objWithLayers.Length;i++){
            objWithLayers[i].GetComponent<SpriteRenderer>().sortingLayerName = "R"+num;
        }
    }
}
