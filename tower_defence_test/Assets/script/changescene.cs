using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changescene : MonoBehaviour
{
    public void Scene1(string SceneName) {  
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);  
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
