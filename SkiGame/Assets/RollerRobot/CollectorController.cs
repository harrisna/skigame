using UnityEngine;
using System.Collections;

public class CollectorController : MonoBehaviour {

    private int collectibles = 0;
    [SerializeField]
    UnityEngine.UI.Text output;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        output.text = "Enerjuice: " + collectibles;

    }

    void OnTriggerEnter (Collider collider) {
        if (collider.GetComponent<CollectibleController>() != null)
        {
            collider.GetComponent<CollectibleController>().Acquire();
            collectibles++;
        }
    }

    public int getNumCollectibles()
    {
        return collectibles;
    }
}
