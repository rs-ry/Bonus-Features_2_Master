using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectScaling : MonoBehaviour
{
    public float starvationTimeStep = 1f;
    public float timer = 0.0f;
    public float visualTime = 0.0f;

    public Vector3 downScalingStep = new Vector3(-0.05f, -0.05f, -0.05f);
    public Vector3 upScalingStep = new Vector3(0.09f, 0.09f, 0.09f);

    public float minSize = 4f;
    public float maxSize = 13f;

    public float healthySize;

    public float dfltDdownScalingRange;
    public float dfltUpScalingRange;

    public float currentXSize;

    public float underFeedSliderVal;
    public float overFeedSliderVal;

    public GameObject managerObject;
    GameManager gameManager;
    private void Start()
    {
        managerObject = GameObject.Find("GameManager");

        gameManager = managerObject.GetComponent<GameManager>();

        healthySize = transform.localScale.x;

        dfltDdownScalingRange = healthySize - minSize;
        dfltUpScalingRange = maxSize - healthySize;

    }

    void Update()
    {
        underFeedSliderVal = gameManager.UnderFeedValue(dfltDdownScalingRange, currentXSize, minSize);

        overFeedSliderVal = gameManager.OverFeedValue(dfltUpScalingRange, maxSize, currentXSize);

        currentXSize = gameObject.transform.localScale.x;

        ProcessUnderFeeding();

        MonitoringHealth();
    }

    // PROCESS Scaling 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            ProcessFeeding();
            Destroy(other.gameObject);
        }
    }

    void ProcessUnderFeeding()
    {
        timer += Time.deltaTime;

        if (timer > starvationTimeStep)
        {
            visualTime = timer;
            timer = 0;
            Debug.Log("You are starving.");
            gameObject.transform.localScale += downScalingStep;
        }
    }

    void ProcessFeeding()
    {
        gameObject.transform.localScale += upScalingStep;
        Debug.Log("You have been fed.");
    }

    // Register Helth and Deth statuss
    void MonitoringHealth()
    {
        if (currentXSize < minSize)
        {
            Destroy(gameObject, 0f); Debug.Log("Death coused by starvation!");
        }

        if (currentXSize > maxSize)
        {
            Destroy(gameObject, 0f); Debug.Log("Death coused by overfeeding!");
        }
    }
    /*       
        void HelthIndicator()
        {
            if ((currentXSize < maxSize) && (currentXSize > minSize))
            {
                underFeedSlider.value = underFeedSliderVal;
                overFeedSlider.value = overFeedSliderVal;
            }
        }

        float UnderFeedValue()
        {
            float onePercent = dfltDdownScalingRange * 0.01f;
            float dynamicRange = currentXSize - minSize;
            return 100 - dynamicRange / onePercent;
        }

        float OverFeedValue()
        {
            float onePercent = dfltUpScalingRange * 0.01f;
            float dynamicRange = maxSize - currentXSize;
            return 100 - dynamicRange / onePercent;
        }
 */
}
