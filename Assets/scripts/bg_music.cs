using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_music : MonoBehaviour
{
    static bool loaded;

    void Awake()
    {
        if (!loaded)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);

        loaded = true;
    }
}
