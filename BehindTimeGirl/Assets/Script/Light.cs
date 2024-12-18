using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightWithRange : MonoBehaviour
{
    public Light redLight;                    // �ԐM��
    public Light greenLight;                  // �M��
    public Transform car;                     // �Ԃ�Transform
    public float detectionRange = 10f;        // �M�����Ԃ����m����͈�

    private bool isCarInRange = false;        // �Ԃ��͈͓��ɂ��邩�ǂ���

    void Update()
    {
        // �ԂƂ̋����𑪒�
        float distance = Vector3.Distance(car.position, transform.position);

        // �Ԃ��͈͓��ɂ��邩�𔻒�
        isCarInRange = distance <= detectionRange;

        // �M���̏�Ԃ��X�V
        if (isCarInRange)
        {
            redLight.enabled = true;
            greenLight.enabled = false;
        }
        else
        {
            redLight.enabled = false;
            greenLight.enabled = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Unity�G�f�B�^�Ŕ͈͂������i�I�����̂݁j
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
