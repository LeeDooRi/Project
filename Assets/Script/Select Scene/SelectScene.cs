using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class SelectScene : MonoBehaviour
{
    void Start()
    { }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Voyager Android");
    }


}
