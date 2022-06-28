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

    void OutOfBondDestroyer()
    {
        if (transform.position.z > zBound)  // If an object goes past the players view in the game, remove that object
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -zBound)
        {
            GameManager.instance.AddLives(-1);

            Destroy(gameObject);
        }
        else if (transform.position.x > xBound)        //Check if we are off the screen to the right
        {
            GameManager.instance.AddLives(-1);

            Destroy(gameObject);
        }
        else if (transform.position.x < -xBound)        //Check if we are off the screen to the left
        {
            GameManager.instance.AddLives(-1);
            Destroy(gameObject);
        }
    }

    void ProjectileForwardMovement()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);

    }
}


