using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    public float speed = 3.0f;           // �G�̈ړ����x
    public float moveTime = 2.0f;       // �����_���Ɉړ����鎞��
    public float waitTime = 1.0f;       // �ړ���ɑҋ@���鎞��
    private float timer;                // �^�C�}�[
    private Vector3 moveDirection;      // �ړ�����
    private bool isWaiting = false;     // �ҋ@��Ԃ��ǂ���

    void Start()
    {
        timer = moveTime;               // �����^�C�}�[��ݒ�
        ChooseDirection();              // �����ړ�����������
    }

    void Update()
    {
        if (isWaiting)
        {
            // �ҋ@��Ԃ̏���
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isWaiting = false;
                timer = moveTime;
                ChooseDirection();      // ���̈ړ�����������
            }
        }
        else
        {
            // �ړ���Ԃ̏���
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isWaiting = true;
                timer = waitTime;       // �ҋ@�^�C���ɐ؂�ւ�
            }
        }
    }

    // �ړ������������_���Ɍ��肷��֐� (X������)
    void ChooseDirection()
    {
        // X�������ɍ��E�ǂ��炩�������_���őI��
        float randomX = Random.Range(-1.0f, 1.0f);
        moveDirection = new Vector3(randomX, 0, 0).normalized; // X���̕�����ݒ�
    }
}
