using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCameraMove2 : MonoBehaviour
{
    //X���̊p�x�𐧌����邽�߂̕ϐ�
    float angleUp = 60f;
    float angleDown = -60f;

    [SerializeField] GameObject player;

    //Main Camera��Inspector�œ����
    [SerializeField] Camera cam;

    //Camera����]����X�s�[�h
    [SerializeField] float rotate_speed = 3;

    //Axis�̈ʒu���w�肷��ϐ�
    [SerializeField] Vector3 axisPos;

    //�}�E�X�X�N���[���̒l������
    [SerializeField] float scroll;

    //�}�E�X�z�C�[���̒l��ۑ�
    [SerializeField] float scrollLog;

    void Start()
    {
        //Camera��Axis�ɑ��ΓI�Ȉʒu��localPosition�Ŏw��
        cam.transform.localPosition = new Vector3(0, 0, -3);

        //Camera��Axis�̌������ŏ��������낦��
        cam.transform.localRotation = transform.rotation;
    }

    void Update()
    {
        //Axis�̈ʒu���v���C���[�̈ʒu�{axisPos�Ō��߂�
        transform.position = player.transform.position + axisPos;

        //�O�l�̂̎���Camera�̈ʒu�Ƀ}�E�X�X�N���[���̒l�𑫂��Ĉʒu�𒲐�
        //thirdPosAdd = thirdPos + new Vector3(0, 0, scrollLog);

        //�}�E�X�X�N���[���̒l������
        scroll = Input.GetAxis("Mouse ScrollWheel");

        //�}�E�X�X�N���[���̒l�͓������Ȃ���0�ɂȂ�̂ł����ŕۑ�����
        scrollLog += Input.GetAxis("Mouse ScrollWheel");

        //Camera�̈ʒu�AZ���ɃX�N���[������������
        cam.transform.localPosition
            = new Vector3(cam.transform.localPosition.x,
            cam.transform.localPosition.y,
            cam.transform.localPosition.z + scroll);

        //Camera�̊p�x�Ƀ}�E�X����Ƃ����l������
        transform.eulerAngles += new Vector3(
            Input.GetAxis("Mouse Y") * rotate_speed,
            Input.GetAxis("Mouse X") * rotate_speed
            , 0);

        //X���̊p�x
        float angleX = transform.eulerAngles.x;
        //X���̒l��180�x��������360�������ƂŐ������₷������
        if (angleX >= 180)
        {
            angleX = angleX - 360;
        }
        //Mathf.Clamp(�l�A�ŏ��l�A�ő�l�j��X���̒l�𐧌�����
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angleX, angleDown, angleUp),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
}
