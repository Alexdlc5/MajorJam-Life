using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    public Button zoomin;
    public Button zoomout;
    public Button reset;
    // Start is called before the first frame update
    void Start()
    {
        zoomin.onClick.AddListener(zoomIn);
        zoomout.onClick.AddListener(zoomOut);
        reset.onClick.AddListener(Reset);
    }
    private void zoomIn()
    {
        if (cinemachine.m_Lens.OrthographicSize - 5 > 0)
        {
            cinemachine.m_Lens.OrthographicSize -= 5;
        }
    }
    private void zoomOut()
    {
        cinemachine.m_Lens.OrthographicSize += 5;
    }
    private void Reset()
    {
        GameObject.FindGameObjectWithTag("Cursor").transform.position = Vector2.zero;
        cinemachine.m_Lens.OrthographicSize = 25.36f;
    }
}
