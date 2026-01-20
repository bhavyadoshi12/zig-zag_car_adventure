using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    bool faceLeft, firstTab;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameStarted)
        {
            Move();
            CheckInput();
        }

        if(transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
       
    }//Update
    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }//Move
    void CheckInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeDir();
            
        }
    }//CheckInput
    void ChangeDir()
    {
        if(faceLeft)
        {
            faceLeft=false;
            transform.rotation=Quaternion.Euler(0,90,0);
        }
        else
        {
            faceLeft=true;
            transform.rotation=Quaternion.Euler(0,0,0);
        }
    }

}
