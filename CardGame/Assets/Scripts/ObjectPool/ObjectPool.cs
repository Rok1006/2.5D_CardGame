using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using TMPro;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] public DamagePopup popup;
    [SerializeField] private int amount = 10;
    private ObjectPool<DamagePopup> _pool;
    
    // Start is called before the first frame update
    void Start()
    {
        _pool = new ObjectPool<DamagePopup>(() =>
        {
           
            return Instantiate(popup);

        }, popup =>
       {
           popup.gameObject.SetActive(true);
       },
        popup =>
        {
            popup.gameObject.SetActive(false);
        }, popup =>
        {
            Destroy(popup.gameObject);
        }, false, 10, 20
        );
        EventHandler.Instance.onEnemyAttack.AddListener(Spawn);
       
    }

    public void Spawn(DamageFeedback feedback)
    {
        var obj = _pool.Get();
        Debug.Log(obj.gameObject.name);
        obj.gameObject.transform.position = feedback.position;
        obj.gameObject.GetComponent<TMP_Text>().text = feedback.damage.ToString();
        obj.init(DeSpawn);
    }

    public void DeSpawn(DamagePopup damagePopup)
    {
        
        _pool.Release(damagePopup);
        
    }

    
}
