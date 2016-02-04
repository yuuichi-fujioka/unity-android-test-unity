using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Collections;

namespace Hoge
{
    public class Test : MonoBehaviour
    {

        private long delta = -1;
        private long delta2 = -1;
        private long delta3 = -1;
        private long delta4 = -1;
        private long delta5 = -1;
        private long delta6 = -1;
        private long delta7 = -1;
        private int v;
        private int v2;
        private int v3;
        private int v4;
        private int v5;
        private int v6;
        private static bool called;
        [DllImport("hello-jni")]
        private static extern int HelloWorld();
        [DllImport("hello-jni")]
        private static extern int HelloWorld2(char[] data);
        delegate int Callback(int v);
        [DllImport("hello-jni")]
        private static extern int HelloWorld3(Callback callback);
        [DllImport("hello-jni")]
        private static extern int HelloWorld4(Callback callback);

        private AndroidJavaClass hoge;

        public static int Hello(int v)
        {
            called = true;
            return 1093;
        }

        // Use this for initialization
        void Start()
        {
            hoge = new AndroidJavaClass("jp.test.lib.Hoge");
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

            t = DateTime.Now.Ticks;
            v3 = HelloWorld3(Hello);
            delta4 = DateTime.Now.Ticks - t;

            t = DateTime.Now.Ticks;
            v4 = HelloWorld4(Hello);
            delta5 = DateTime.Now.Ticks - t;

            t = DateTime.Now.Ticks;
            v5 = hoge.CallStatic<int>("Hello");
            delta6 = DateTime.Now.Ticks - t;

            object[] param = new object[] { data };
            t = DateTime.Now.Ticks;
            v6 = hoge.CallStatic<int>("Hello2", param);
            delta7 = DateTime.Now.Ticks - t;
        }

        void OnGUI()
        {
            GUI.Label(new Rect(30, 30, 200, 200), v.ToString());
            GUI.Label(new Rect(60, 30, 200, 200), delta.ToString());
            GUI.Label(new Rect(90, 30, 200, 200), delta2.ToString());
            GUI.Label(new Rect(30, 50, 200, 200), v2.ToString());
            GUI.Label(new Rect(60, 50, 200, 200), delta3.ToString());
            GUI.Label(new Rect(30, 70, 200, 200), v3.ToString());
            GUI.Label(new Rect(60, 70, 200, 200), delta4.ToString());
            GUI.Label(new Rect(90, 70, 200, 200), called.ToString());
            GUI.Label(new Rect(30, 90, 200, 200), v4.ToString());
            GUI.Label(new Rect(60, 90, 200, 200), delta5.ToString());
            GUI.Label(new Rect(30, 110, 200, 200), v5.ToString());
            GUI.Label(new Rect(60, 110, 200, 200), delta6.ToString());
            GUI.Label(new Rect(30, 130, 200, 200), v6.ToString());
            GUI.Label(new Rect(60, 130, 200, 200), delta7.ToString());
            GUI.Label(new Rect(30, 20, 200, 200), "V9");
        }
    }
}