using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerCards : MonoBehaviour
{
    private Transform originalPos;
    private bool isOver = false;
    public List<AttackPattern> attackPattern;
    private Tween moveTween;
    public Vector3 ogPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if(isOver == false)
        {

            isOver = true;
            originalPos = this.gameObject.transform;
            if (isOver)
            {
                moveTween = this.transform.DOMove(this.transform.position + transform.up * 1, 0.4f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            }
            //StartCoroutine("HighlightCard");
        }
        
    }
    private void OnMouseExit()
    {
        if (moveTween != null)
        {
            // Kill the stored moveTween
            moveTween.Kill();
            moveTween = null; // Set the moveTween instance to null
        }
        this.transform.DOMove(originalPos.position, 0.4f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            isOver = false;
        });

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
}
