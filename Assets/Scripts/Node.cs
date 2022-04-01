using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private EnemyCarController ecc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyCarController>())
        {
            ecc.EnemyThroughNode(this);
        }
        
    }

    public void SetNodes(EnemyCarController ecc)
    {
        this.ecc = ecc;
    }
}
