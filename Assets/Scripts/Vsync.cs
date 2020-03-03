using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vsync : MonoBehaviour
{
    public int TragetFrameRate = 60;
    void Awake()
    {
#if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = TragetFrameRate;
#endif
    }
}

