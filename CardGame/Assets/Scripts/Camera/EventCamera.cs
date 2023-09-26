using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCamera : CameraBehavior
{

    protected override void Start()
    {
        base.Start();
        EventHandler.Instance.OnTurnFinished.AddListener(WaitForEvent);
    }

    protected override void Update()
    {
        base.Update();
    }
    private void WaitForEvent()
    {
        player.PlayFeedbacks();
    }
}
