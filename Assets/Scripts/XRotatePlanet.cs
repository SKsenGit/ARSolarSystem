using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotatePlanet : MonoBehaviour
{
    public Transform aroundPoint;//������ ������ ������� ���������
    public float circleInSecond = 1f;//������ � �������

    public float offsetSin = 1; //���� �������� �� 1, �� ����� �������� ��������
    public float offsetCos = 1;

    float dist;
    float circleRadians = Mathf.PI * 2;
    float currentAng = 0;

    void Start()
    {
        dist = (transform.position - aroundPoint.position).magnitude;
    }

    void Update()
    {
        Vector3 p = aroundPoint.position;
        p.x += Mathf.Sin(currentAng) * dist * offsetSin;
        p.z += Mathf.Cos(currentAng) * dist * offsetCos;
        transform.position = p;

        currentAng += circleRadians * circleInSecond * Time.deltaTime;
    }
}

