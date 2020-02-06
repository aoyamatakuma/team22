using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rogo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("End");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator End()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Title");
    }
}
