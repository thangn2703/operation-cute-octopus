using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TouchToStart : MonoBehaviour
{
    void OnTouch(){
        SceneManager.LoadScene(1);
    }
}
