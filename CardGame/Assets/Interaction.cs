using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Interaction : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineVirtualCamera cardCamera;
    public CinemachineVirtualCamera mainCamera;
    public float sensitivity = 2f;
    public float rotationSmoothness = 5f;
    private Quaternion rot;

    private float rotationX;
    private float rotationY;
    private Quaternion targetRotation;

    private bool isRotating;
    private Vector3 lastMousePosition;

    private void Awake()
    {
        virtualCamera = GameObject.Find("vcam").GetComponent<CinemachineVirtualCamera>();
        rot = virtualCamera.transform.rotation;
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layermask = ~LayerMask.GetMask("Ground");

            if (Physics.Raycast(ray, out hit , Mathf.Infinity , layermask))
            {
                if (hit.transform.gameObject.tag == "EnemyCard")
                {
                    ZoomInOnCard("virtualCamera",hit.transform.gameObject);
                }
            }
        }/*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera.Equals(mainCamera))
            {
                cardCamera.gameObject.SetActive(true);
                 ZoomInOnCard("cardCamera", null);
            }
            else
            {
                if (CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera.Equals(cardCamera))
                {
                    cardCamera.gameObject.SetActive(false);
                }
            }
            
        }
        */
        if (virtualCamera.Priority == 15)
        {
            float targetRotationY = rotationY + Input.GetAxis("Mouse X") * sensitivity;
            float targetRotationX = rotationX + Input.GetAxis("Mouse Y") * -1 * sensitivity;
            targetRotationX = Mathf.Clamp(targetRotationX, -20, 20);
            targetRotationY = Mathf.Clamp(targetRotationY, -20, 20);

            Quaternion targetRotation = Quaternion.Euler(targetRotationX, targetRotationY, 0);

            // Use Quaternion.Lerp for smooth rotation
            virtualCamera.transform.rotation = Quaternion.Lerp(virtualCamera.transform.rotation, targetRotation, 0.8f * Time.deltaTime);
        }
    }
    public void ZoomOutOnCard()
    {
        virtualCamera.Priority = 10;
        virtualCamera.transform.rotation = rot;
    }

   

    private void ZoomInOnCard(string name, GameObject card)
    {
        switch(name){
            case "cardCamera":
                cardCamera.Priority = 15;
                break;
            case "virtualCamera":
                virtualCamera.transform.position = card.transform.position + new Vector3(0, 0.8f, -4);
                
                virtualCamera.Priority = 15;
                break;
        }
        
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
