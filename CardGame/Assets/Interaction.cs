using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Interaction : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        virtualCamera = GameObject.Find("vcam").GetComponent<CinemachineVirtualCamera>();
    }

    private void OnMouseDown()
    {
        // Zoom in on the clicked card
        ZoomInOnCard();

        // Hide other cards
       // HideOtherCards();
    }

    private void ZoomInOnCard()
    {
        virtualCamera.transform.position = this.transform.position;
        virtualCamera.Priority = 15;
    }

    private void HideOtherCards()
    {
        // Get all the card game objects in the scene
        GameObject[] cardObjects = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject cardObject in cardObjects)
        {
            // Exclude the clicked card
            if (cardObject != gameObject)
            {
                // Disable or hide the other card game objects
                cardObject.SetActive(false);
            }
        }
    }
}
