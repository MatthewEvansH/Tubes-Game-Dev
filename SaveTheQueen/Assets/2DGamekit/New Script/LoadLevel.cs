using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public int iLevelToLoad;
    public string sLevelToLoad;
    public bool useIntegerToLoadLevel = false;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Ellen 1")
        {
            // if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            // {
                LoadScene();
            // }
        }
    }
    void LoadScene()
    {
        if (useIntegerToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        } 
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}