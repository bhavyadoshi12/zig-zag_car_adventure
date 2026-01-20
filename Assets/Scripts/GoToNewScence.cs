using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewScence : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Invoke("GotoScene",5); 
    }//Start

    void GotoScene()
    {
        SceneManager.LoadScene("ChooseCar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
