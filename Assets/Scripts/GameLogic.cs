using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    static public GameLogic solo;
    public float restartDelay = 2f;
    private void Awake()
    {
        if (solo == null)
        {
            solo = this;
        }
        else
        {
            Debug.LogError("GameLogic.Awake()");
        }
    }
    public void DelayRestart()
    {
        Invoke("Restart", restartDelay);
    }
    public void Restart()
    {
        SceneManager.LoadScene("BasicLevel");
    }
}
