using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour {
    [SerializeField] int next;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(next);
    }
}
