using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarController : MonoBehaviour
{
    private CarController carController;

    private void Awake()
    {
        
    }

    private void Start()
    {
        carController = this.gameObject.GetComponent<CarController>();
    }
    private void Update()
    { 
        carController.SetInputs(1.0f, 0.0f);
    }
}
