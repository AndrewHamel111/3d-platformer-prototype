using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            TrueAwake();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void TrueAwake()
    {
        //Cursor.visible = false;
        //Application.targetFrameRate = 144;
    }
}
