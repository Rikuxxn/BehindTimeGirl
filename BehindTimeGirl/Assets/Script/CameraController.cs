using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;       // �v���C���[��Transform
    public Vector3 offset;         // �J�����ƃv���C���[�Ԃ̌Œ�I�t�Z�b�g
    public float lookAtOffsetX = -15f; // �v���C���[�����񂹂ɂ��邽�߂̎��_�I�t�Z�b�g

    // Start is called before the first frame update
    void Start()
    {
        // �����ʒu��ݒ�i�v���C���[�̈ʒu�ƃI�t�Z�b�g����Ɍv�Z�j
        transform.position = player.position + offset;
    }

    // LateUpdate�͂��ׂĂ�Update��ɌĂяo�����
    void LateUpdate()
    {
        // �v���C���[�̈ʒu�Ɋ�Â��ăJ�����ʒu���X�V
        transform.position = player.position + offset;

        // �J�����̎��_���v���C���[�Ɍ�����i�������񂹁j
        Vector3 lookAtTarget = player.position;
        lookAtTarget.x -= lookAtOffsetX;
        transform.LookAt(lookAtTarget);
    }
}
