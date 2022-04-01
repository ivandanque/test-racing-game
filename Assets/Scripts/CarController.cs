using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float turnSpeed = 200.0f;
    private float move;
    private float rot;
    private bool gamePaused = false;

    public void PauseGame()
    {
        gamePaused = !gamePaused;
    }

    public void SetInputs(float forwardMove, float turnMove)
    {
        move = forwardMove * speed * Time.deltaTime;
        if (move < 0f)
        {
            rot = turnMove * turnSpeed * Time.deltaTime;
        }
        else
        {
            rot = turnMove * -turnSpeed * Time.deltaTime;
        }
        transform.Translate(move, 0f, 0f);
        transform.Rotate(0f, 0f, rot);
    }
}
