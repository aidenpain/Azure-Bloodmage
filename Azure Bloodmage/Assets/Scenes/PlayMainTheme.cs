﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMainTheme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
