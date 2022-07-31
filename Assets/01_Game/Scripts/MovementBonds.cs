using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBonds : MonoBehaviour
{
    Terrain myTerrain;

    public Vector3 terrainSize;
    float xRange;
    float zRange;
    float xPos;
    float zPos;

    public GameObject[] myObjs;
    public string aTag;

    void Start()
    {
        myObjs = GameObject.FindGameObjectsWithTag(UI_Manager.Instance.playersTag);
        myTerrain = GetComponent<Terrain>();

        if (myTerrain)
        {
            terrainSize = myTerrain.terrainData.size;
            xRange = terrainSize.x / 2;
            zRange = terrainSize.z / 2;

            xPos = gameObject.transform.position.x + xRange;
            zPos = gameObject.transform.position.z + zRange;
        }
        else
        {
            Debug.Log("Script is not attached to terrain!");
        }
    }

    private void Update()
    {
        foreach (GameObject myObj in myObjs)
        {
            float xClamp = Mathf.Clamp(myObj.transform.position.x, -xRange + xPos, xRange + xPos);
            float yClamp = Mathf.Clamp(myObj.transform.position.y, 0, 3);
            float zClamp = Mathf.Clamp(myObj.transform.position.z, -zRange + zPos, zRange + zPos);

            myObj.transform.position = new Vector3(xClamp, yClamp, zClamp);
        }
    }
}
