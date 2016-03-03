using UnityEngine;
using System.Collections;

public class TimerController : MonoBehaviour {
    float timeSeconds = 0.0f;
    bool timing = false;

    float bonus = 2.0f;

    [SerializeField] GameObject raceUI;
    [SerializeField] GameObject finalUI;
    [SerializeField] UnityEngine.UI.Text output;
    [SerializeField] UnityEngine.UI.Text final;
    [SerializeField] GameObject cameraObj;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (timing)
            timeSeconds += Time.deltaTime;

        output.text = "Time: " + timeSeconds;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<TimerTrigger>() != null && collider.GetComponent<TimerTrigger>().isStart())
        {
            timing = true;
        }
        else if (collider.GetComponent<TimerTrigger>() != null && !collider.GetComponent<TimerTrigger>().isStart())
        {
            timing = false;
            FinalTime();
        }
    }

    public void FinalTime()
    {
        raceUI.SetActive(false);
        finalUI.SetActive(true);

        cameraObj.GetComponent<MouseLook>().lockCursor = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        timeSeconds = Mathf.Max(timeSeconds - (bonus * gameObject.GetComponent<CollectorController>().getNumCollectibles()), 0.0f);
        final.text = "Congratulations! Final Time: " + timeSeconds;
    }
}
