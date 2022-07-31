using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    private float zBound = 145;

    private float xBound = 145;

    public float projectileSpeed;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ProjectileForwardMovement();

        OutOfBondDestroyer();
    }

    void ProjectileForwardMovement()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
    }

    void OutOfBondDestroyer()
    {
        if ((transform.position.z > zBound) || (transform.position.z < -zBound) || (transform.position.x > xBound) || (transform.position.x < -xBound))
        {
            Destroy(gameObject);
            UI_Manager.Instance.WastedFeeds(1);
        }
    }


}


