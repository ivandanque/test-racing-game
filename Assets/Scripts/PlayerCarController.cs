using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    private CarController carController;
    void Awake()
    {
        carController = GetComponent<CarController>();
    }

    
    void Update()
    {
        carController.SetInputs(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
    }
}
