using UnityEngine;
using System.Collections;

public class SwapScript : MonoBehaviour 
{
    public GameObject cloud;
    public float leftRange = -9f;
    public float rightRange = 8f;
    public float swapY = -11f;
    public float maxSpeed = 5f;
    public float minSpeed = 1f;

    private float waitTime = 2.0f;
    private float time = 0f;

	private void Start () 
	{
	
	}
	
	private void Update () 
	{
        time += Time.deltaTime;
        if (PlayerScript.score > 10)
        {
            waitTime = 2.0f - (0.2f * PlayerScript.score/10);
            if (waitTime < 0.5f)
            {
                waitTime = 0.5f;
            }
        }
        if (time > waitTime)
        {
            time = 0;
            SwapCloud();
        }
	}

    private void SwapCloud()
    {
        Vector3 randomPos = new Vector3(Random.Range(leftRange, rightRange), swapY, 0f);
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        float rotationSpeed = randomSpeed / 2f;
        GameObject newCloud = Instantiate(cloud) as GameObject;
        newCloud.GetComponent<CloudScript>().SetInit(randomPos, randomSpeed, rotationSpeed);
    }
}
