using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Animator canvasAnim;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider slider;

    public void SceneLoader(int sceneIndex)
    {
        StartCoroutine(Load(sceneIndex));
    }

    public void SceneLoader(string sceneName)
    {
        StartCoroutine(Load(sceneName));
    }

    public void Exit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void PlayMenu()
    {
        if (AnimatorScript.WasOpenned)
            canvasAnim.SetTrigger("PlayMenu");
        else
        {
            canvasAnim.SetTrigger("PlayMenu");
            AnimatorScript.WasOpenned = true;
        }
    }

    IEnumerator Load(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }

    IEnumerator Load(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }
}
