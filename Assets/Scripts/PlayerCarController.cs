using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float turnSpeed = 200.0f;
    private float move;
    private float rot;
    private bool gamePaused = false;

    void Update()
    {
        move = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        if (move < 0f) {
            rot = Input.GetAxisRaw("Horizontal") * turnSpeed * Time.deltaTime;
        } else {
            rot = Input.GetAxisRaw("Horizontal") * -turnSpeed * Time.deltaTime;
        }

        transform.Translate(move, 0f, 0f);
        transform.Rotate(0f, 0f, rot);
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;
    }
}
