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

    void Update()
    {
        if (isfloat)
        {
            if (objectB == null)
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(objectA.transform.DOMoveY(transform.position.y + floatingHeight, floatDuration / 2).SetEase(Ease.OutQuad));
                sequence.Play();
            }
            else
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(objectB.transform.DOMoveY(transform.position.y + floatingHeight, floatDuration / 2).SetEase(Ease.OutQuad));
                sequence.OnComplete(() => { isfloat = false; });
                sequence.Play();
            }
        }

        if (Input.GetMouseButtonDown(0) && !inProcess)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (objectA == null)
                {
                    if (hit.transform.gameObject.tag == "Player")
                    {
                        objectA = hit.transform.gameObject;
                        objectAPosition = objectA.transform.position;
                        isfloat = true;
                    }
                }
                else if (objectB == null && hit.transform.gameObject != objectA)
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
    }

    public void CallSwap()
    {
        StartCoroutine("SwapPositions");
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
            sequence.Join(objectB.transform.DOMove(positionA, 0.2f).SetEase(Ease.OutQuad));

            yield return sequence.WaitForCompletion();
        }

        objectA = null;
        objectB = null;
        objectAPosition = Vector3.zero;
        objectBPosition = Vector3.zero;
        inProcess = false;
    }
}
