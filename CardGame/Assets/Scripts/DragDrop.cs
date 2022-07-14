using UnityEngine;

public class DragDrop : MonoBehaviour
{

    public GameObject selectedObject;
    public GameObject selectedObject2;
    private Vector3 position1;
    private Vector3 position2;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameState == 0)
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Player"))
                    {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    selectedObject.GetComponent<Player>().isBeingDragged = true;
                    Cursor.visible = false;
                }
            }

           
            else
            {
                var player = selectedObject.GetComponent<Player>();
                player.isBeingDragged = false;
                if (selectedObject.GetComponent<Player>().isOnPlayerBoard == true)
                {
                    //Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                    //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

                    Vector3 position = player.currentPlayerBoard.transform.position;
                    selectedObject.transform.position = new Vector3(position.x, 0.131f, position.z);

                    selectedObject = null;
                    Cursor.visible = true;
                    
                }
                if (selectedObject.GetComponent<Player>().isOnPlayerBoard != true)
                {
                    //Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                    Vector3 position = player.currentPos;
                    //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                    selectedObject.transform.position = new Vector3(position.x, 0.131f, position.z);

                  
                    selectedObject = null;
                    Cursor.visible = true;
                }
            }
        }

        if (selectedObject != null && GameManager.gameState == 0)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, 2f, worldPosition.z);

            if (Input.GetMouseButtonDown(1))
            {
                selectedObject.transform.rotation = Quaternion.Euler(new Vector3(
                    selectedObject.transform.rotation.eulerAngles.x,
                    selectedObject.transform.rotation.eulerAngles.y + 90f,
                    selectedObject.transform.rotation.eulerAngles.z));
            }
        }
        if (Input.GetMouseButtonDown(0) && GameManager.gameState == 1 && selectedObject != null && selectedObject2 != null)
        {
            Vector3 temp = selectedObject.transform.position;
            selectedObject.transform.position = selectedObject2.transform.position;
            selectedObject2.transform.position = temp;
            selectedObject = null;
            selectedObject2 = null;


        }
            if (Input.GetMouseButtonDown(0) && GameManager.gameState == 1 && selectedObject != null)
        {


            if (selectedObject2 == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Player"))
                    {
                        return;
                    }

                    selectedObject2 = hit.collider.gameObject;
                    position2 = selectedObject2.transform.position;
                    selectedObject2.GetComponent<Renderer>().material.color = Color.blue;
                }

            }



        }

        if (Input.GetMouseButtonDown(0) &&  GameManager.gameState == 1 && selectedObject == null)
        {
           
            
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Player"))
                    {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    position1 = selectedObject.transform.position;
                    selectedObject.GetComponent<Renderer>().material.color = Color.green;
                }
                
            }
          

           
        }
       
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
