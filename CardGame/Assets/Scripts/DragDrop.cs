using UnityEngine;

public class DragDrop : MonoBehaviour
{

    private GameObject selectedObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                    selectedObject.transform.position = new Vector3(position.x, 1.73f, position.z);

                    selectedObject = null;
                    Cursor.visible = true;
                    GameManager.ready++;
                }
                if (selectedObject.GetComponent<Player>().isOnPlayerBoard != true)
                {
                    //Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                    Vector3 position = player.currentPos;
                    //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                    selectedObject.transform.position = new Vector3(position.x, 1.73f, position.z);

                    selectedObject = null;
                    Cursor.visible = true;
                }
            }
        }

        if (selectedObject != null)
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
