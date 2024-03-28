using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neko : MonoBehaviour
{
    public Rigidbody2D nekoBody;
    public float flapStrength;
    public float rotationSpeed;
    public GameObject gameOverSceneObj;
    private scoreHandle scoreHandle;
    public bool notOver = true;
    // Start is called before the first frame update
    void Start()
    {
        scoreHandle = GameObject.FindGameObjectWithTag("scoreHandle").GetComponent<scoreHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nekoBody.velocity = Vector2.up * flapStrength;
            wingSound(notOver);
        }
    }

    


    private void FixedUpdate()
    {
        nekoBody.transform.rotation = Quaternion.Euler(0, 0, nekoBody.velocity.y * rotationSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6 || collision.gameObject.layer == 7 || collision.gameObject.layer == 8)
        {
            FindObjectOfType<AudioManager>().Play("collide");

            FindObjectOfType<AudioManager>().Play("transition");
            Time.timeScale = 0;
            //Score save logic
            int highScore;
            RecordData data = ScoreSave.loadHighScore();
            int playerCurrentScore = scoreHandle.playerScore;
            if(data == null)
            {   
                //Player's first time playing this game
                highScore = 0;
            }
            else
            {
                //Not the first time
                highScore = data.score;
            }
            if(playerCurrentScore > highScore)
            {
                //Save new high score
                ScoreSave.savePlayerHighScore(playerCurrentScore, true);
            }
            else
            {
                //Not a new high score. High score doesn't change
                ScoreSave.savePlayerHighScore(highScore, false);
            }

            notOver = false;
            gameOverSceneObj.SetActive(true);
        }
    }

    public void wingSound(bool notOver)
    {
        if (notOver)
        {
            FindObjectOfType<AudioManager>().Play("wing");
        }
    }
}
