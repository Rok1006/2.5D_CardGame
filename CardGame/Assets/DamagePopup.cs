using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private Action<DamagePopup> _killAction;
    private float lifeTime = 1f;
    
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    public void init(Action<DamagePopup> killAction)
    {
        _killAction = killAction;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf)
        {
            lifeTime -= Time.deltaTime;
            
        }
        
        if(lifeTime < 0)
        {
            lifeTime = 1f;
            _killAction(this);
        }
    }
}
