using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        // �ڱ༭����ֹͣ����ģʽ
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // �ڹ�������Ϸ���˳�Ӧ��
        Application.Quit();
#endif
    }
}
