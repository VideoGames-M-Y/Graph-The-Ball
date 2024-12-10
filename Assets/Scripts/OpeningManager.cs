using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningManager : MonoBehaviour{
    [SerializeField] float delay = 2f; 
    [SerializeField] string mainSceneName = "SampleScene"; 

    void Start(){
        Invoke("LoadMainScene", delay);
    }

    void LoadMainScene(){
        SceneManager.LoadScene(mainSceneName);
    }
}
