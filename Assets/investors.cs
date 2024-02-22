using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class investors : MonoBehaviour
{
    public static int invest = 0;
    public TextMeshProUGUI gui;

    // Update is called once per frame
    void Update()
    {
        gui.text = "Investors: " + invest;
    }
}
