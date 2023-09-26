using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using Cinemachine;
using MoreMountains.FeedbacksForThirdParty;

public class PlayerHandCamera : CameraBehavior
{
    // Start is called before the first frame update
    
    protected override void Start()
    {
        base.Start();


    }

    // Update is called once per frame
    protected override void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.W))
        {
            
            targetCamera.gameObject.SetActive(true);
            player.GetFeedbackOfType<MMF_CinemachineTransition>().Channel = 10;
            OnDisable();
        }
       
    }
    protected override void OnDisable()
    {
        this.gameObject.SetActive(false);
    }
}
