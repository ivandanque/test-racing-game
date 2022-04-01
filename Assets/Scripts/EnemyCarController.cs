using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarController : MonoBehaviour
{
    private CarController carController;
    private Vector2 targetPosition;

    [SerializeField]
    private Transform targetPositionTransform;

    [SerializeField]
    private List<Node> nodeList;

    [SerializeField]
    private GameObject nodeGroup;

    [SerializeField]
    private int nextNode = 0;

    private void Awake()
    {
        Transform nodesTransform = nodeGroup.transform;
        carController = this.gameObject.GetComponent<CarController>();

        nodeList = new List<Node>();

        foreach (Transform singleNodeTransform in nodesTransform)
        {
            Node node = singleNodeTransform.GetComponent<Node>();
            node.SetNodes(this);
            nodeList.Add(node);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            nextNode = (nextNode + 1) % nodeList.Count;
        }
        Debug.Log((nodeList[nextNode].transform.position));
        SetNoteTarget(nodeList[nextNode].transform.position);

        // Debug.Log("Next node location: " + targetPosition);
        float forwardValue = 0f;
        float turnValue = 0f;

        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        
        Vector2 dirToMovePosition = (targetPosition - currentPosition).normalized;
        // Debug.Log("Current enemy location: " + dirToMovePosition);
        
        float dotProduct = Vector2.Dot(transform.right, dirToMovePosition);
        // Debug.Log("Dot Product: " + dotProduct);

        if (dotProduct > 0)
        {
            forwardValue = 1f;
        }
        else
        {
            forwardValue = -1f;
        }

        float angleToDir = Vector2.SignedAngle(transform.right, dirToMovePosition);

        if (angleToDir > 0)
        {
            turnValue = -1f;
        }
        else
        {
            turnValue = 1f;
        }
        carController.SetInputs(forwardValue, turnValue);
    }

    public void SetNoteTarget(Vector2 node)
    {
        this.targetPosition = node;
    }

    public void EnemyThroughNode(Node node)
    {
        Debug.Log("Node Hit: " + node.name);
        if (nextNode == nodeList.IndexOf(node))
        {
            nextNode = (nextNode + 1) % nodeList.Count;
        }
        
    }
}
