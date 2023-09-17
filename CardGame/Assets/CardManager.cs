using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardManager : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> cardBuffer;
    public static List<GameObject> playerCards = new List<GameObject>();
    public float fanRadius = 1.5f; // Radius of the fan arrangement
    public float fanAngle = 30f;   // Angle between each card in the fan
    public Transform playerHand;
    public Transform deck;

    // Start is called before the first frame update
    void Start()
    {
        SetupBuffer();
        CreateDeck(cardBuffer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddCard();
        }
    }
    void CreateDeck(List<GameObject> cards)
    {
        for(int i = 0; i < cards.Count; i++)
        {
            var target = PopCard();
            var card = Instantiate(target, deck.transform.position, target.transform.rotation);
        }
    }
    void AddCard()
    {
        var card = Instantiate(PopCard(), deck.transform.position, Quaternion.identity);
        playerCards.Add(card);
        
        if (playerCards.Count == 1)
        {
            Vector3 localUp = playerHand.transform.up;
            Debug.Log(localUp);
            Vector3 moveVec = localUp * 1.5f;
            card.transform.DOMove(new Vector3(playerHand.transform.position.x , playerHand.transform.position.y, playerHand.transform.position.z) + moveVec, 1f, false);
            Quaternion rotation = playerHand.transform.rotation;
            card.transform.DORotate(rotation.eulerAngles, 1f, RotateMode.FastBeyond360);
            
        }
        else
        {
            StartCoroutine(RotateCard(playerCards.Count, card));
        }



    }
    IEnumerator RotateCard(int num , GameObject card)
    {
        var angle = 120 / 8;
        bool isEven = num % 2 == 0;
        Quaternion rotation = playerHand.transform.rotation;
        
        if (isEven == true)
        {
            
            var evenAngle = num / 2 * angle * 1;
            for(int i = 0; i < num-1; i++)
            {
                playerCards[i].transform.DORotate(rotation.eulerAngles + new Vector3(0, 0, evenAngle - 15 * i), 0.1f).OnComplete(() =>
                {
                    Vector3 localUp = playerCards[i].transform.up;
                    //Debug.Log(localUp);
                    Vector3 moveVec = localUp * 1.5f;

                    // Use local space for movement
                    playerCards[i].transform.DOMove(playerHand.transform.position + moveVec, 1f, false);
                });
                yield return new WaitForSeconds(0.11f);
                Vector3 localUp = playerCards[0].transform.up;


                Vector3 moveVec = new Vector3(-localUp.x, localUp.y, localUp.z) * 1.5f;
                card.transform.DOMove(playerHand.transform.position + moveVec, 0.3f, false).OnComplete(() =>
                {
                    rotation = playerHand.transform.rotation;
                    card.transform.DORotate(rotation.eulerAngles + new Vector3(0, 0, evenAngle - 15 * num), 0.3f);
                });

                   

            }

        }
        else
        {
            angle = 120 / 7;
            float evenAngle = (float)(num-1) / 2 * angle * 1;
            for (int i = 0; i < num; i++)
            {
                playerCards[i].transform.DORotate(rotation.eulerAngles + new Vector3(0, 0, evenAngle - angle * i), 0.1f).OnComplete(() =>
                {
                    int j = i + 1;
                    int distance = num % j;
                    Debug.Log(num + " " + i + " " + distance);
                    Vector3 localUp = playerCards[i].transform.up;
                    //Debug.Log(localUp);
                    float val = 1 + distance * 0.1f;
                    Vector3 moveVec = localUp * 1.5f * val;

                    // Use local space for movement
                    playerCards[i].transform.DOMove(playerHand.transform.position + moveVec, 0.3f, false);
                });
                if(i == num - 1)
                {
                    yield return new WaitForSeconds(0.3f);
                }
                else
                {
                    yield return new WaitForSeconds(0.1f);
                }

               
            }
        }


        yield return null;
    }

    void SetupBuffer()
    {
        cardBuffer = new List<GameObject>();

        for (int i = 0; i < 100; i++)
        {
            GameObject randomCard = GetRandomCard();
            cardBuffer.Add(randomCard);
        }
    }

    GameObject GetRandomCard()
    {
        int randomIndex = Random.Range(0, cards.Count);
        return cards[randomIndex];
    }

    public GameObject PopCard()
    {
        if(cardBuffer.Count == 0)
        {
            SetupBuffer();
        }
        GameObject card = cardBuffer[0];
        cardBuffer.RemoveAt(0);
        return card;
    }
}
