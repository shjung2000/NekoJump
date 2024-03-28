using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class handleMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("mainMenu");
    }
    public void PlayButton()
    {
        LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
