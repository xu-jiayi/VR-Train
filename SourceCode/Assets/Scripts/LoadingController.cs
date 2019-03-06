using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour {
    //stayTime时间之后开启另一线程加载下一场景
    public float stayTime = 5f;

    //待加载的场景名称
    public string sceneName;

    // Use this for initialization
    void Start()
    {
        Invoke("EnterBeginScene", stayTime);
    }

    void EnterBeginScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
