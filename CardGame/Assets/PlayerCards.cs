using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerCards : MonoBehaviour
{
    public List<AttackPattern> attackPattern;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Initialize()
    {

    }
    private void OnMouseDrag()
    {
        
    }
   

    IEnumerator HighlightCard()
    {
        
        yield return null;
    }

    public IEnumerator DestroyCard()
    {
        Tween tweening = this.gameObject.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InSine).OnComplete(() => { Destroy(this.gameObject); }) ;

        yield return tweening.WaitForCompletion();
    }
}
