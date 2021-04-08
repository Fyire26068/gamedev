using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 velocity;

    public LayerMask wallMask;

    private bool walk, walk_left, walk_right, jump;

    public void checkPlayerInput()
    {
        bool input_left = Input.GetKey(KeyCode.LeftArrow);
        bool input_right = Input.GetKey(KeyCode.RightArrow);
        bool input_jump = Input.GetKey(KeyCode.Space);

        walk = input_left || input_right;
        walk_left = input_left && !input_right;
        walk_right = !input_left && input_right;
        jump = input_jump;
    }

    public void updatePlayerPos()
    {
        Vector3 pos = transform.localPosition;
        Vector3 scale = transform.localScale;

        if(walk)
        {
            if(walk_left)
            {
                pos.x -= velocity.x * Time.deltaTime;
                scale.x = -1;
            }
            if(walk_right)
            {
                pos.x += velocity.x * Time.deltaTime;
                scale.x = 1;
            }
            pos = checkWallRays(pos, scale.x)
        }

        transform.localPosition = pos;
        transform.localScale = scale;
        

    }

    public Vector3 checkWallRays(Vector3 pos, float direction)
    {
        Vector2 originTop = new Vector2(pos.x + direction * .4f, pos.y + 1f - 0.2f);
        Vector2 originMid = new Vector2(pos.x + direction * .4f, pos.y);
        Vector2 originBot = new Vector2(pos.x + direction * .4f, pos.y - 1f + 0.2f);

        RaycastHit2D wallTop = Physics2D.Raycast(originTop, new Vector2(direction, 0), velocity.x*Time.deltaTime, wallMask);
        RaycastHit2D wallMid = Physics2D.Raycast(originMid, new Vector2(direction, 0), velocity.x*Time.deltaTime, wallMask);
        RaycastHit2D wallBot = Physics2D.Raycast(originBot, new Vector2(direction, 0), velocity.x*Time.deltaTime, wallMask);
        
        if ((wallTop.collider != null || wallBot.collider != null || wallMid.collider != null))
        {
            pos.x -= velocity.x * Time.deltaTime * direction;

        }
        
        return pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerInput();
        updatePlayerPos();
    }
}
