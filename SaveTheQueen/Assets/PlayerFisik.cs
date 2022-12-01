using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFisik : MonoBehaviour{
    public string nextScene;
    public void OnCollisionEnter2D (Collision2D collision){
        if(collision.gameObject.tag == "gantiscene"){
            Transition.transition.changeScene(nextScene);
        }
    }
}
