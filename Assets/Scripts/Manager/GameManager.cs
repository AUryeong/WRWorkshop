using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public override void OnReset()
    {
        DontDestroyOnLoad(transform.parent);
    }
}
