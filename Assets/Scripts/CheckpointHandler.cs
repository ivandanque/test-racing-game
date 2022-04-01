using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    private List<SingleCheckpoint> checkpointGroup;

    [SerializeField]
    private List<Transform> carTransformList;

    [SerializeField]
    private List<int> nextCheckpointList;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");
        checkpointGroup = new List<SingleCheckpoint>();
        foreach (Transform checkpointSingleTransform  in checkpointsTransform)
        {
            SingleCheckpoint singleCheckpoint = checkpointSingleTransform.GetComponent<SingleCheckpoint>();
            singleCheckpoint.SetCheckpoints(this);
            checkpointGroup.Add(singleCheckpoint);
        }

        nextCheckpointList = new List<int>();
        foreach(Transform carTransform in carTransformList)
        {
            nextCheckpointList.Add(1);
        }
    }


    public void CarThroughCheckpoint(SingleCheckpoint sc, Transform carTransform)
    {
        int nextCheckpoint = nextCheckpointList[carTransformList.IndexOf(carTransform)];
        if (checkpointGroup.IndexOf(sc) == nextCheckpoint)
        {
            nextCheckpointList[carTransformList.IndexOf(carTransform)] = (nextCheckpoint + 1) % checkpointGroup.Count;
        }
        //else
        //{
        //    Debug.Log("Wrong");
        //}
    }

    public int GetNextCheckpoint(int carIndex)
    {
        return nextCheckpointList[carIndex];
    }
}
