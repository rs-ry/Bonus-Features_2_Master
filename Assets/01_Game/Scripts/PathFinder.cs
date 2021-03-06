using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public float maxSpeed = 10;
    public float rotationY_Speed = 10;
    Transform objectToSteer;
    Rigidbody rigidBody;

    Vector3 otherPos_LH;
    Vector3 currentPosInUse_LH = Vector3.zero;
    Transform default_LH;

    bool backToDefault = true;

    // Start is called before the first frame update
    void Start()
    {
        objectToSteer = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody>();
        default_LH = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        {
            // AssigningLHPositios();==========================
            if (backToDefault)
                currentPosInUse_LH = default_LH.position;
            else
                currentPosInUse_LH = otherPos_LH;

            // AdjustingRotation();==========================
            Quaternion rot = objectToSteer.rotation;
            objectToSteer.LookAt(currentPosInUse_LH);
            objectToSteer.rotation = Quaternion.RotateTowards(rot, objectToSteer.rotation, rotationY_Speed * Time.deltaTime);

            if (otherPos_LH != Vector3.zero)
            {
                // moves to Other and
                if (Vector3.Distance(otherPos_LH, objectToSteer.position) < 10)
                {
                    otherPos_LH = Vector3.zero;     // getting back to Default
                }
            }
            else
            {       // enters Default zone
                if (Vector3.Distance(default_LH.position, objectToSteer.position) < 10)
                {
                    backToDefault = false;

                    Vector3 assignable = default_LH.position - objectToSteer.forward * 60;  // 120
                    float posX = assignable.x;
                    float posY = default_LH.transform.position.y;
                    float posZ = assignable.z;
                    otherPos_LH = new Vector3(posX, posY, posZ); // sets up Other
                }
            }
        }

        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * maxSpeed);

    }
}
