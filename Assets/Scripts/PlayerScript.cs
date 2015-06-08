using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
    public GameObject ball;
    public AudioClip hit;
    public AudioClip over;
    public GameObject scoreText;
    public GameObject gameOverPanel;
    public GameObject swap;
    public GameObject bgm;

    public float moveSpeed = 1.0f;
    public float top = 9.5f;
    public float bottom = -9.5f;
    public float left = -5.1f;
    public float right= 5.1f;

    [HideInInspector]
    public static int score = 0;

    private bool isGaming = true;

	private void Start () 
    {
        Instantiate(ball, new Vector3(-10f, -10f, 0f), Quaternion.identity);
        score = 0;
	}
	
	private void Update () 
    {
        if (isGaming)
        {
            Vector2 distanse = new Vector2(Input.acceleration.x, Input.acceleration.y);
            transform.Translate(distanse * moveSpeed);

            Vector3 tempPos = transform.position;
            if (tempPos.x < left)
            {
                tempPos.x = left;
            }
            if (tempPos.x > right)
            {
                tempPos.x = right;
            }
            if (tempPos.y < bottom)
            {
                tempPos.y = bottom;
            }
            if (tempPos.y > top)
            {
                tempPos.y = top;
            }
            transform.position = tempPos;
        }
        else
        {
            transform.position = new Vector3(0f, 0f, 0f);
        }
       
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().PlayOneShot(hit);
            score++;
            scoreText.GetComponent<Text>().text = score.ToString();
            Instantiate(ball, new Vector3(-10f, -10f, 0f), Quaternion.identity);
        }

        if (other.gameObject.tag == "Cloud")
        {
            GetComponent<AudioSource>().PlayOneShot(over);
            GameOver();
        }
    }

    private void GameOver()
    {
        // 停止刷新Cloud
        swap.SetActive(false);

        // 清除所有Player、Ball、Cloud
        isGaming = false;

        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        Destroy(ball);
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");
        foreach(GameObject cloud in clouds)
        {
            Destroy(cloud);
        }

        // 停止背景音乐
        bgm.GetComponent<AudioSource>().Stop();

        // 显示GameOver菜单
        scoreText.SetActive(false);
        gameOverPanel.SetActive(true);
        GameObject.Find("NumText").GetComponent<Text>().text = score.ToString();
        GameObject.Find("BestNumText").GetComponent<Text>().text = SetBest();
    }

    private string SetBest()
    {
        // 读取最好的成绩
        int bestScore = PlayerPrefs.GetInt("BestScore");
        
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        return bestScore.ToString();
    }
}
