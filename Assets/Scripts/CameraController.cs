using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerCar;
    [SerializeField]
    private bool isFollowing = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isFollowing)
            {
                
                isFollowing = false;
            }
            else
            {
                
                isFollowing = true;
            }
        }

        transform.position = CameraTrack(isFollowing);
        
    }

    private Vector3 CameraTrack(bool isFollowing)
    {
        if (isFollowing)
        {
            return new Vector3(playerCar.transform.position.x, playerCar.transform.position.y, -10f);
        }
        return new Vector3(0f, 0f, -10f);
    }
}
