using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using Cinemachine;
using MoreMountains.FeedbacksForThirdParty;

public class MainStageCamera : CameraBehavior
{
    // Start is called before the first frame update
    public CinemachineVirtualCamera enemyCamera;
    protected override void Start()
    {
        base.Start();
        
        
    }
    

    // Update is called once per frame
    protected override void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layermask = ~LayerMask.GetMask("Ground");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {
                if (hit.transform.gameObject.tag == "EnemyCard")
                {
                    Debug.Log("dfdf");
                    enemyCamera.GetComponent<CameraBehavior>().destinaiton = hit.collider.gameObject.transform.position + new Vector3(0, 0.8f, -4f);
                    enemyCamera.gameObject.GetComponent<EnemyZoomCard>().Run();
                    player.GetFeedbackOfType<MMF_CinemachineTransition>().Channel = 5;
                    
                    OnDisable();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.S)){
            targetCamera.gameObject.SetActive(true);
            player.GetFeedbackOfType<MMF_CinemachineTransition>().Channel = 15;
            OnDisable();
        }
    }
    protected override void OnDisable()
    {
        this.gameObject.SetActive(false);
    }
}
