using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneJump : MonoBehaviour
{
    private Animator anim;

    int level;

    public GameObject loadingScreen;
    public Slider slider;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void FadeToLevel()
    {
        anim.SetTrigger("Fade");
    }

    IEnumerator LoadingScrennOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }


    public void LoadSceneShop()
    {
        level = 1;
        SceneManager.LoadScene(1);
        StartCoroutine(LoadingScrennOnFade());
    }
    public void LoadSceneMenu()
    {
        level = 0;
        SceneManager.LoadScene(0);
        StartCoroutine(LoadingScrennOnFade());
    }
}
