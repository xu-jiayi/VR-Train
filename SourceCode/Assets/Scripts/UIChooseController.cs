using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class UIChooseController : MonoBehaviour {
    //选中则停止旋转
    public GameObject buttonImage = null;
    public string sceneName;
    VRTK_ControllerEvents controller = null;

    void OnTriggerEnter(Collider other)
    {
        controller = other.GetComponentInParent<VRTK_ControllerEvents>();

        if (controller != null)
        {
            buttonImage.GetComponent<Animator>().enabled = false;
          
        }
    }

    void OnTriggerStay(Collider other) {
        if (controller != null && controller.triggerPressed)
        {
            if (this.transform.name == "ExitCol")
            {
                Debug.Log("Quit");
                Application.Quit();
            }
            if (this.transform.name == "StartCol")
            {
                Debug.Log("Start");
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        controller = null;
        buttonImage.GetComponent<Animator>().enabled = true;
    }
}
