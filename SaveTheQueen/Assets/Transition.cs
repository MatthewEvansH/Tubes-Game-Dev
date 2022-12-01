using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour{ 

    public static Transition transition;
    void Awake(){
        transition = this;
    }
    public void changeScene(string nameScene){
        SceneManager.LoadScene(nameScene);

    }
}