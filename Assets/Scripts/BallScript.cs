using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour 
{
    public float rangeX = 5.1f;
    public float rangeY = 9.5f;
    public Vector2 minDistance = new Vector2(3f, 3f);

	private void Start () 
	{
        Vector3 position = new Vector3(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY), 0f);
        transform.position = position; 
	}
}
