using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeToOnClick : MonoBehaviour
{
    public KeyCode key;

    public Button button;

    public bool needsVerified;

    public CostVerification verify;

    public GameObject companion;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // verify companion is dead to allow use of revive item
        if (button.CompareTag("Revive Button"))
        {
            companion = GameObject.FindWithTag("Friendly");

            if (Input.GetKeyDown(key) && verify.canInteract && companion == null
            )
            {
                button.onClick.Invoke();
            }
        }
        else if (Input.GetKeyDown(key) && verify.canInteract)
        {
            button.onClick.Invoke();
        }
    }
}
