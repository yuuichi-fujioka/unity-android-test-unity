using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Collections;

public class Test : MonoBehaviour
{

    private long delta = -1;
    private long delta2 = -1;
    private long delta3 = -1;
    private int v;
    private int v2;
    [DllImport("hello-jni")]
    private static extern int HelloWorld();
    [DllImport("hello-jni")]
    private static extern int HelloWorld2(char[] data);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        long t = DateTime.Now.Ticks;
        v = HelloWorld();
        delta = DateTime.Now.Ticks - t;
        t = DateTime.Now.Ticks;
        for (int i = 0; i < 1000; i++)
            HelloWorld();
        delta2 = DateTime.Now.Ticks - t;
        char[] data = new char[1024];
        t = DateTime.Now.Ticks;
        v2 = HelloWorld2(data);
        delta3 = DateTime.Now.Ticks - t;


    }

    void OnGUI()
    {
        GUI.Label(new Rect(30, 30, 200, 200), delta.ToString());
        GUI.Label(new Rect(30, 50, 200, 200), delta2.ToString());
        GUI.Label(new Rect(30, 70, 200, 200), delta3.ToString());
        GUI.Label(new Rect(30, 90, 200, 200), "V6");
        GUI.Label(new Rect(30, 110, 200, 200), v.ToString());
        GUI.Label(new Rect(30, 130, 200, 200), v2.ToString());
    }
}
