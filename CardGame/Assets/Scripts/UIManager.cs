using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Hover")]
    [SerializeField]private GameObject hover1;
    [SerializeField]private GameObject hover2;
    [SerializeField]private GameObject PlayerCInfo;
    void Start()
    {
        hover1.SetActive(false);
        hover2.SetActive(false);
        PlayerCInfo.SetActive(false);
    }
    public void Hover1(){
        hover1.SetActive(true);
    }
    public void Hover2(){
        hover2.SetActive(true);
    }
    public void HoverOFF(){
        hover1.SetActive(false);
        hover2.SetActive(false);
    }
    //Button Function
    public void Inventory(){
        //shows item collected
    }
    public void CardInfo(){
        PlayerCInfo.SetActive(true);
    }
    public void CardInfoClose(){
        PlayerCInfo.SetActive(false);
    }

}
