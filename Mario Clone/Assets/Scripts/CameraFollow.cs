using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    public Transform target;
    public Transform rightbound;
    public Transform leftbound;

    private float camHeigth, camWidth, levelminX, levelmaxX;

    public float smoothDampTime = 0.15f;
    private Vector3 smoothDampVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //calculating camera size
        camHeigth = Camera.main.orthographicSize * 2; 
        camWidth = camHeigth* Camera.main.aspect;

        //getting width of our bound right and left
        float leftBoundWidth =  leftbound.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        float rightBoundWidth = rightbound.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;

        //setting the min and max x cords
        levelminX = leftbound.position.x + leftBoundWidth + (camWidth / 2);   
        levelmaxX = rightbound.position.x + rightBoundWidth - (camWidth / 2) -1;      
    }

    // Update is called once per frame
    void Update()
    {
        // binding the camera to the player and the bounds
        // this will set the player as the target of the camera
        // camera until the camera hits a bound
        // then it will switch the target to the bounds end
        // stop the camera moving with the player
        float targetX = Mathf.Max(levelminX, Mathf.Min(levelmaxX, target.position.x));

        float x = Mathf.SmoothDamp(transform.position.x, targetX, ref smoothDampVelocity.x, smoothDampTime);  
        transform.position = new Vector3(x, transform.position.y, transform.position.z);   
    }
}
