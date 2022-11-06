using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeToOnClick : MonoBehaviour
{
    public KeyCode key;
    public Button button;

    public CostVerification verify;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key) && verify.canInteract)
        {
            button.onClick.Invoke();
        }
    }
}
