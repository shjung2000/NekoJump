using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerLogic : MonoBehaviour
{
    private scoreHandle scoreHandle;
    // Start is called before the first frame update
    void Start()
    {
        scoreHandle = GameObject.FindGameObjectWithTag("scoreHandle").GetComponent<scoreHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.layer == 3)
        {
            //Neko Layer is number 3
            FindObjectOfType<AudioManager>().Play("point");
            scoreHandle.addScore();

        }
    }

}
