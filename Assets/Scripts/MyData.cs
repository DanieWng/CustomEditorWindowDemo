using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public struct SubtitleData
{
    public string _filename;
    public Color _color;
    public Vector3 _pos;

    public void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        {
            GUILayout.Space(20);

            EditorGUILayout.BeginVertical(GUI.skin.box);

            EditorGUILayout.TextField("File name", _filename);
            EditorGUILayout.ColorField("Color", _color);
            EditorGUILayout.Vector3Field("Position", _pos);
            
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndHorizontal();
    }

    public static SubtitleData CreateSubtitleData()
    {
        SubtitleData ret = new SubtitleData();
        ret._filename = null;
        ret._color = Color.white;
        ret._pos = Vector3.zero;

        return ret;
    }
}

[Serializable]
public class MyData : ScriptableObject
{
    private bool m_isShowSubtitleArray = false;

    [SerializeField]
    private List<SubtitleData> m_subtitleDataList;

    private List<bool> m_isSubtitleDataItemShowList;

    void OnEnable()
    {
        m_subtitleDataList = new List<SubtitleData>();

        m_isSubtitleDataItemShowList = new List<bool>();
    }

    public void OnGUI()
    {
        m_isShowSubtitleArray = EditorGUILayout.Foldout(m_isShowSubtitleArray, "Subtitle List");

        if(m_isShowSubtitleArray)
        {
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Space(20);

                EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(Screen.width-50));

                for(int i=0; i<m_subtitleDataList.Count; i++)
                {
                    m_isSubtitleDataItemShowList[i] = EditorGUILayout.Foldout(m_isSubtitleDataItemShowList[i], "Item: " + i);
                    if(m_isSubtitleDataItemShowList[i])
                    {
                        EditorGUI.indentLevel += 1; // 层次树 +1
                        m_subtitleDataList[i].OnGUI();
                        EditorGUI.indentLevel -= 1; // 层次树 -1
                    }
                }

                if(GUILayout.Button("Add Child"))
                {
                    m_subtitleDataList.Add(SubtitleData.CreateSubtitleData());
                    m_isSubtitleDataItemShowList.Add(true);
                }

                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }

        
    }

}