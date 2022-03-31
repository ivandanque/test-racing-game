using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCheckpoint : MonoBehaviour
{
    private CheckpointHandler checkHandler;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkHandler.CarThroughCheckpoint(this, collision.transform);
    }

    public void SetCheckpoints(CheckpointHandler ch)
    {
        this.checkHandler = ch;
    }
}
