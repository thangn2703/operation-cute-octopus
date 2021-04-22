using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TouchToStart : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    void OnTouch(){
        SceneManager.LoadScene(sceneToLoad);
    }
}
