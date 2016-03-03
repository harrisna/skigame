using UnityEngine;
using System.Collections;

public class TimerTrigger : MonoBehaviour {
    [SerializeField] private bool start = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool isStart()
    {
        return start;
    }
}
