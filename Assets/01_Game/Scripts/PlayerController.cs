using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string youR_OnSide, activeFwBwAxis, activeTurnAxis;
    string actionStr;
    //  Type t = this.GetType();

    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float turnSpeed = 10.0f;

    public float xRange = 140.0f;
    public float zRange = 140.0f;

    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        activeFwBwAxis = "Vertical" + youR_OnSide;
        activeTurnAxis = "Horizontal" + youR_OnSide;

        if (youR_OnSide == "Left")
            actionStr = "Fire2";  // left alt

        if (youR_OnSide == "Right")
           actionStr = "Fire1";  // right alt
    }

    // Update is called once per frame
    void Update()
    {
        MoveFwBw();
        TurnIt();

        if (Input.GetButtonDown(actionStr))
        {
            Debug.Log("Shoot by " + actionStr);
            Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);

            GameManager.instance.GivenFeeds(1);

        }
    }

    void MoveFwBw()
    {
        verticalInput = Input.GetAxis(activeFwBwAxis);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    void TurnIt()
    {
        horizontalInput = Input.GetAxis(activeTurnAxis);
        float turn = horizontalInput * Time.deltaTime * turnSpeed;
        transform.Rotate(0, turn, 0 , Space.Self);
    }


}
