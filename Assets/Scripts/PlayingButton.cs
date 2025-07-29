using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayingButton : MonoBehaviour
{
    public void OnClickRe()
    {
        SceneManager.LoadScene(0);
    }
}
