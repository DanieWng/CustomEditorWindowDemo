using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


public class MyFirstWindow : EditorWindow
{
    private Vector2 m_scrollPos = Vector2.zero;

    private MyData m_myData;

    [MenuItem("Window/Custom/My First Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MyFirstWindow));
    }

    void OnEnable()
    {
        hideFlags = HideFlags.HideAndDontSave;

        if(m_myData == null)
        {
            m_myData = (MyData)CreateInstance(typeof(MyData));
        }
    }

    void OnGUI()
    {
        m_scrollPos = EditorGUILayout.BeginScrollView(m_scrollPos, true, false, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height));

        m_myData.OnGUI();

        EditorGUILayout.EndScrollView();
    }   

    
}