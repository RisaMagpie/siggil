using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuBehaviour : MonoBehaviour {

	public void triggerMenuBehaviour(int i)
    {
        switch(i){
            default:
            case (0):
                SceneManager.LoadScene("Table");
                break;
            case (1):
                Application.Quit();
                break;
        }
    }
}
