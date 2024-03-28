using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleMouse : MonoBehaviour
{
    public void mouseClick()
    {
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void mouseHover()
    {
        FindObjectOfType<AudioManager>().Play("bubble");
    }
}
