using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using Cinemachine;

public abstract class CameraBehavior : MonoBehaviour
{
    public MMF_Player player;
    public CinemachineVirtualCamera targetCamera;
    public CinemachineBrain brain;
    public Vector3 destinaiton;

    protected virtual void Start()
    {
        player = this.gameObject.GetComponent<MMF_Player>();
    }


    protected virtual void Update()
    {
        
    }

    protected virtual void OnDisable() {

        this.gameObject.SetActive(false);
    }

    public void PlayFeedbacks()
    {
        player.PlayFeedbacks();
    }
    

    


    
}
