using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using Cinemachine;
using MoreMountains.FeedbacksForThirdParty;
public class EnemyZoomCard : CameraBehavior
{
    public float sensitivity;
    public float rotationSmoothness;
    private float rotationX;
    private float rotationY;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
    }
    public void Run()
    {
        player.GetFeedbackOfType<MMF_Position>().DestinationPosition = destinaiton;
        player.PlayFeedbacks();
    }
    // Update is called once per frame
    protected override void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnDisable();
            targetCamera.gameObject.SetActive(true);
            player.GetFeedbackOfType<MMF_CinemachineTransition>().Channel = 10;
            
        }

        if (brain.ActiveVirtualCamera.Equals(this.gameObject)){
            MoveCameraRotation();
        }
    }
    private void MoveCameraRotation()
    {
        float targetRotationY = rotationY + Input.GetAxis("Mouse X") * sensitivity;
        float targetRotationX = rotationX + Input.GetAxis("Mouse Y") * -1 * sensitivity;
        targetRotationX = Mathf.Clamp(targetRotationX, -20, 20);
        targetRotationY = Mathf.Clamp(targetRotationY, -20, 20);

        Quaternion targetRotation = Quaternion.Euler(targetRotationX, targetRotationY, 0);

        // Use Quaternion.Lerp for smooth rotation
        this.gameObject.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, targetRotation, 0.8f * Time.deltaTime);
    }
    protected override void OnDisable()
    {
        //base.OnDisable();
        //this.transform.position = targetCamera.transform.position; 
    }
}
