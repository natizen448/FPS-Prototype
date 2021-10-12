using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField]
    private float rotCamXAxisSpeed = 5; //ī�޶� x�� ȸ���ӵ�
    [SerializeField]
    private float rotCamYAxisSpeed = 3; //ī�޶� y�� ȸ���ӵ�

    private float limitMinX = -80;      //ī�޶� x�� ȸ�� ���� (�ּ�)
    private float limiyMaxX = 50;       //ī�޶� x�� ȸ�� ���� (�ִ�)
    private float eulerAngleX;
    private float eulerAngleY;

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamXAxisSpeed; //���콺 ��/�� �̵����� ī�޶� y�� ȸ��
        eulerAngleX -= mouseY * rotCamYAxisSpeed; //���콺 ��/�Ʒ� �̵����� ī�޶� x�� ȸ��

        //ī�޶� x�� ȸ���� ��� ȸ�� ������ ����
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limiyMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    private float ClampAngle(float angle,float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}