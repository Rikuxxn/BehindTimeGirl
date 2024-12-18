using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMoverWithTrigger : MonoBehaviour
{
    public Vector3 direction = Vector3.forward; // �ړ������i�f�t�H���g�͑O���j
    public float speed = 5f;                   // �ړ����x
    public Transform player;                   // �v���C���[�I�u�W�F�N�g��Transform
    public float activationRange = 10f;        // �N������͈͂̔��a

    private bool isActive = false;             // �ړ����A�N�e�B�u���ǂ���
    private bool hasStarted = false;           // ��x�ł��ړ����J�n�������ǂ���
    private float activeTime = 0f;             // �A�N�e�B�u�ɂȂ��Ă���̌o�ߎ���

    void Update()
    {
        if (!hasStarted)
        {
            // �v���C���[�Ƃ̋����𑪒�
            float distance = Vector3.Distance(player.position, transform.position);

            // �͈͓��Ȃ�ړ����J�n
            if (distance <= activationRange)
            {
                isActive = true;
                hasStarted = true; // ��x�ł��N���������Ƃ��L�^
            }
        }

        // �A�N�e�B�u�ȏꍇ�Ɉړ�����
        if (isActive)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);

            // �o�ߎ��Ԃ��J�E���g
            activeTime += Time.deltaTime;

            // 10�b�o�߂�����폜
            if (activeTime >= 5f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Unity�G�f�B�^�Ŕ͈͂������i�I�����̂݁j
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, activationRange);
    }
}
