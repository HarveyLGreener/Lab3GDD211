using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpFunctionality : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the screen position of objects via pixels
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        //Gets each side of the screen
        float rightSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;
        float topOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottomOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;
        //Checks where object is warping from and chooses where to

        if (screenPos.x <= 0)
        {
            transform.position = new Vector2(rightSideOfScreenInWorld, transform.position.y);
        }
        else if (screenPos.x > Screen.width)
        {
            transform.position = new Vector2(leftSideOfScreenInWorld, transform.position.y);
        }
        if (screenPos.y >= Screen.height)
        {
            transform.position = new Vector2(transform.position.x, bottomOfScreenInWorld);
        }
        else if (screenPos.y <= 0)
        {
            transform.position = new Vector2(transform.position.x, topOfScreenInWorld);
        }
    }
}
