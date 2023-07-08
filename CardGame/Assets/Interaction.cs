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
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "EnemyCard")
                {
                    ZoomInOnCard(hit.transform.gameObject);
                }
            }
        }
    }
    public void ZoomOutOnCard()
    {
        virtualCamera.Priority = 10;
    }

   

    private void ZoomInOnCard(GameObject card)
    {
        virtualCamera.transform.position = card.transform.position + new Vector3(0,0,-2);
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
