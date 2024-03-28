using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class handlePreGame : MonoBehaviour
{
    public Text preGameText;
    private float speed;
    private float setAlpha;
    bool maxAlpha;
    bool minAlpha;
    // Start is called before the first frame update
    void Start()
    {
        speed = 220;
        setAlpha = 255;
        maxAlpha = true;
        minAlpha = false;
        preGameText.color = new Color32(0, 0, 0, (byte)setAlpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (maxAlpha && !minAlpha)
        {
            //Have yet to hit 0 for alpha
            setAlpha -= Time.deltaTime * speed;
            preGameText.color = new Color32(0, 0, 0, (byte)setAlpha);

            if (setAlpha < 0)
            {
                //Reached 0 for alpha
                setAlpha = 0;
                preGameText.color = new Color32(0, 0, 0, (byte)setAlpha);
                maxAlpha = false;
                minAlpha = true;
            }
        }

        if (!maxAlpha && minAlpha)
        {
            //Have yet to hit 255 for alpha
            setAlpha += Time.deltaTime * speed;
            preGameText.color = new Color32(0, 0, 0, (byte)setAlpha);

            if (setAlpha > 255)
            {
                setAlpha = 255;
                preGameText.color = new Color32(0, 0, 0, (byte)setAlpha);
                maxAlpha = true;
                minAlpha = false;
            }
        }

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //current Index is 1
        }
    }
}
