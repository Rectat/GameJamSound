using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PwrUP : MonoBehaviour
{
    // rng:
    public System.Random rndDir = new();

    public int speedSelRng = 0;

    public int xSpeed = -10;
    public int ySpeed = -10;
    public int dirCntr = 0;
    public int[] speeds = {10, -10};
    public int[] directions = { 0, 1 }; // holds either up or down.
    public int dir = 0; // direction.


    // Start is called before the first frame update
    void Start()
    {
        dir = rndDir.Next(directions.Length);
    }

    // method to call unity's object finder and return it's GameObject:
    GameObject findObjByName(string objName)
    {
        GameObject obj = GameObject.Find(objName);
        return obj;
    }

    // Update is called once per frame:
    void Update()
    {
        // get the ball object and all compinents:
        GameObject pdl1 = findObjByName("paddle1");
        GameObject pdl2 = findObjByName("paddle2");
        GameObject ball = findObjByName("ball");

        // get collider boxes:
        BoxCollider2D ballCol = ball.GetComponent<BoxCollider2D>();
        Paddle script = pdl1.GetComponent<Paddle>();
        Paddle script2 = pdl2.GetComponent<Paddle>();

        // get this object's boxCollider:
        BoxCollider2D pwrUpCol = gameObject.GetComponent<BoxCollider2D>();

        if(dir == 0)
        {
            ySpeed = -10;
        }
        if(dir == 1)
        {
            ySpeed = 10;
        }

        // movement logic:
        if (dirCntr == 50)
        {
            if(dir == 0)
            {
                dir = 1;
            }
            else
            {
                dir = 0;
            }

            dirCntr = 0;
        }

        if (gameObject.transform.position[0] <= -150)
        {
            Destroy(gameObject);
        }
        dirCntr += 1;
        gameObject.transform.Translate(xSpeed, ySpeed, 0); // move the ball down.


        if (pwrUpCol.IsTouching(ballCol))
        {
            if(script.powerUp == 1)
            {
                script.powerUp = 2;
                script2.powerUp = 2;
            }
            else
            {
                script.powerUp = 1;
                script2.powerUp = 1;
            }
            
            Destroy(gameObject);
        }
        


        // check if colliding with the ball:
        
    }
}
