using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour 
{
    public float moveSpeed = 3f;
    private float destoryY = 11f;

	private void Start () 
	{
        
	}
	
	private void Update () 
	{
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime, Space.World);
        AutoDestory();
	}

    public void SetInit(Vector3 position, float moveSpeed, float rotationSpeed)
    {
        transform.position = position;
        this.moveSpeed = moveSpeed;
        Animator animator = GetComponent<Animator>();
        animator.speed = 1.0f * rotationSpeed;
    }

    private void AutoDestory()
    {
        if (transform.position.y > destoryY)
        {
            Destroy(gameObject);
        }
    }
}
