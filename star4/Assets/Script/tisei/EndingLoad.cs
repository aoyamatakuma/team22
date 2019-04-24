using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingLoad : MonoBehaviour
{

    private AsyncOperation async;
 //   public GameObject LoadingUi;
 //   public Slider Slider;

    public void LoadNextScene()
    {
   //     LoadingUi.SetActive(true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("Title");

        while (!async.isDone)
        {
     //       Slider.value = async.progress;
            yield return null;
        }
    }

    //************ 青山ここから
    public void Update()
    {
        if (Input.GetButton("JumpUp"))
        {
            SceneManager.LoadScene("Title");

        }
    }
    //************ 青山ここまで
}