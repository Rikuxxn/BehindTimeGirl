using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TextMeshPro�p�̌^
    public Color countdownColor = Color.blue; // �J�E���g�_�E�����̕����F
    public Color countupColor = Color.red;    // �J�E���g�A�b�v���̕����F
    private float countdownTime = 60f; // �J�E���g�_�E���̏�������
    private bool isCountingDown = true; // �J�E���g�_�E�������ǂ���

    void Start()
    {
        // �����ݒ�
        if (timerText != null)
        {
            timerText.color = countdownColor;
            UpdateTimerText(countdownTime);
        }
    }

    void Update()
    {
        if (isCountingDown)
        {
            // �J�E���g�_�E������
            countdownTime -= Time.deltaTime;
            if (countdownTime <= 0)
            {
                countdownTime = 0;
                isCountingDown = false;
                timerText.color = countupColor; // �F��ԂɕύX
            }
            UpdateTimerText(countdownTime);
        }
        else
        {
            // �J�E���g�A�b�v����
            countdownTime += Time.deltaTime;
            UpdateTimerText(countdownTime);
        }
    }

    // �^�C�}�[�̕����\�����X�V
    void UpdateTimerText(float time)
    {
        if (isCountingDown)
        {
            timerText.text = Mathf.CeilToInt(time).ToString(); // �����_�؂�グ
        }
        else
        {
            timerText.text = Mathf.FloorToInt(time).ToString(); // �����_�؂�̂�
        }
    }

    // ���݂̎��Ԃ��擾���郁�\�b�h��ǉ�
    public float GetCurrentTime()
    {
        return countdownTime;
    }

    public bool IsCountingDown()
    {
        return isCountingDown;
    }
}