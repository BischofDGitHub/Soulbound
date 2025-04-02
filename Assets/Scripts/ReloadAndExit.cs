using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAndExit : MonoBehaviour
{
    
    void Update()
    {
        if(Exit())
        {
            GetComponent<ChangeScene>().LoadScene("Main_Menu");
        }


        if(Replay())
        {
            GetComponent<ChangeScene>().ReloadScene();
        }
    }

    private bool Exit()
    {
        return Input.GetKey(KeyCode.Escape);
    }

    private bool Replay()
    {
        return Input.GetKey("space");
    }
}
