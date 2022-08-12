using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCInfoMenu : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[]pos;

    public GameObject Indicate;
    bool on = false;
    void Start()
    {
        Indicate.SetActive(false);
    }


    void Update()
    {
        if(on){
            Indicate.SetActive(true);
            on = false;
        }else{
            Indicate.SetActive(false);
        }
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for(int i = 0;i<pos.Length;i++){
            pos[i] = distance * i;
        }
        if(Input.GetMouseButton(0)){
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }else{
            on = true;
            for(int i = 0;i<pos.Length;i++){
                if(scroll_pos < pos[i] + (distance/2) && scroll_pos > pos[i] - (distance/2)){
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }
        for(int i = 0;i<pos.Length;i++){
                if(scroll_pos < pos[i] + (distance/2) && scroll_pos > pos[i] - (distance/2)){
                    transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.826994f,3.954711f),0.1f);
                    transform.GetChild(i).transform.GetChild(2).gameObject.SetActive(false); //the black cover on top
                    //NOcover
                    for(int a = 0;a < pos.Length; a++){
                        if(a!=i){ //if not the one viewing
                            transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(1.498135f,3.242863f),0.1f);
                            transform.GetChild(a).transform.GetChild(2).gameObject.SetActive(true); //the black cover on top
                        }
                    }
                }
        }
    }
}
