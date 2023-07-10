using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Interaction : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
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

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "EnemyCard")
                {
                    ZoomInOnCard(hit.transform.gameObject);
                }
            }
        }

        if (virtualCamera.Priority == 15)
        {
            
                rotationY += Input.GetAxis("Mouse X") * sensitivity;
                rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
                rotationX = Mathf.Clamp(rotationX, -10, 10);
            rotationY = Mathf.Clamp(rotationY, -10, 10);   // to stop the player from looking above/below 90

            virtualCamera.transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
                //var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);
                //virtualCamera.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
            
        }
    }
    public void ZoomOutOnCard()
    {
        virtualCamera.Priority = 10;
        virtualCamera.transform.rotation = rot;
    }

   

    private void ZoomInOnCard(GameObject card)
    {
        virtualCamera.transform.position = card.transform.position + new Vector3(0,0,-4);
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
