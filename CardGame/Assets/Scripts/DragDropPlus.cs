using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragDropPlus : MonoBehaviour
{
    private GameObject objectA;
    private GameObject objectB;
    private Vector3 objectAPosition;
    private Vector3 objectBPosition;
    private bool inProcess;
    private bool isfloat;
    public float floatingHeight = 1f; // The height at which the object will float
    public float floatDuration = 2f; // The duration of each floating cycle
    public float bounceHeight = 0.2f; // The height of the bounce
    private bool isInSequenceA;
    private bool isInSequenceB;
    public PlayerCards playerCard;
    [SerializeField]
    private BezierCurve indicator;

    //card hover things
    private Vector3 originalPos;
    private bool isOver = false;
    
    private Tween moveTween;
    public Vector3 ogPos;
    private GameObject currentCard;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && playerCard != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layermask = ~LayerMask.GetMask("Ground");

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {
                if(hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("found");
                    var player = hit.collider.gameObject.GetComponent<PlayerBase>();
                    foreach(var attackPattern in playerCard.attackPattern)
                    {
                        player.attackPattern.Add(attackPattern);
                    }
                }
            }
            indicator.HideSphere();
            playerCard.StartCoroutine("DestroyCard");

        }
      
        //CheckCardHover();
        if (Input.GetMouseButtonDown(0) && !inProcess)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layermask = ~LayerMask.GetMask("Ground");

            if (Physics.Raycast(ray, out hit,Mathf.Infinity,layermask))
            {
                if (hit.collider.gameObject.tag == "DirectionCard")
                {
                    playerCard = hit.collider.gameObject.GetComponent<PlayerCards>();
                    if (isOver == false)
                    {
                        indicator.InitializeSphere();
                        currentCard = hit.collider.gameObject;
                        isOver = true;
                        originalPos = hit.collider.gameObject.transform.position;
                        //Debug.Log(originalPos.position);
                        if (isOver)
                        {
                            moveTween = hit.collider.transform.DOMove(hit.collider.transform.position + hit.collider.transform.up * 1, 0.4f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
                        }
                        //StartCoroutine("HighlightCard");
                    }
                    else
                    {
                        if(currentCard != null)
                        {
                            if (hit.collider.gameObject.Equals(currentCard))
                            {
                                if (moveTween != null)
                                {
                                    // Kill the stored moveTween
                                    moveTween.Kill();
                                    moveTween = null; // Set the moveTween instance to null
                                }
                                indicator.HideSphere();
                                //Debug.Log(originalPos.position);
                                hit.collider.transform.DOMove(originalPos, 0.4f).SetEase(Ease.InOutSine).OnComplete(() =>
                                {
                                    isOver = false;
                                });
                            }
                            else
                            {
                                moveTween.Kill();
                                moveTween = null;
                                indicator.HideSphere();
                                currentCard.transform.DOMove(originalPos, 0.2f).SetEase(Ease.InOutSine).OnComplete(() =>
                                {
                                    currentCard = hit.collider.gameObject;
                                    isOver = false;
                                });
                                originalPos = hit.collider.transform.position;
                                
                            }
                        }
                        
                    }
                }
                
                if (objectA == null)
                {
                    if (hit.transform.gameObject.tag == "Player")
                    {
                        objectA = hit.transform.gameObject;
                        objectAPosition = objectA.transform.position;
                        isfloat = true;
                    }
                }
                else if (objectB == null && hit.transform.gameObject != objectA && isfloat == false)
                {
                    if (hit.transform.gameObject.tag == "Player")
                    {
                        objectB = hit.transform.gameObject;
                        objectBPosition = objectB.transform.position;
                        isfloat = true;
                    }
                }
            }
        }
        if (isfloat == true)
        {
            if (objectB == null && isInSequenceA == false)
            {
                isInSequenceA = true;
                Sequence sequence = DOTween.Sequence();
                
                sequence.Append(objectA.transform.DOMoveY(transform.position.y + floatingHeight, floatDuration / 2).SetEase(Ease.OutQuad));
                sequence.OnComplete(() => { isfloat = false; isInSequenceA = false; sequence.Kill(); });
                sequence.Play();
            }
            else if(isInSequenceB == false && objectB != null)
            {
                isInSequenceB = true;
                Sequence sequence = DOTween.Sequence();
                Debug.Log("running");
                sequence.Append(objectB.transform.DOMoveY(transform.position.y + floatingHeight, floatDuration / 2).SetEase(Ease.OutQuad));
                sequence.OnComplete(() => { isfloat = false; Debug.Log("done"); isInSequenceB = false; sequence.Kill(); });
                sequence.Play();

            }
        }
    }

 
   
    public void CallSwap()
    {
        StartCoroutine("SwapPositions");
    }

    private void ResetCards()
    {
        List<Tween> activeTweens = DOTween.PlayingTweens();

        foreach(Tween tween in activeTweens)
        {
            GameObject tweenObject = tween.target as GameObject;

        }
    }

    IEnumerator SwapPositions()
    {
        inProcess = true;
        if (objectA != null && objectB != null)
        {
            Vector3 positionA = objectAPosition;
            Vector3 positionB = objectBPosition;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(objectA.transform.DOMove(positionB, 0.2f).SetEase(Ease.OutQuad));
            sequence.Append(objectB.transform.DOMove(positionA, 0.2f).SetEase(Ease.OutQuad));

            yield return sequence.WaitForCompletion();
        }

        objectA = null;
        objectB = null;
        objectAPosition = Vector3.zero;
        objectBPosition = Vector3.zero;
        inProcess = false;
    }
}
