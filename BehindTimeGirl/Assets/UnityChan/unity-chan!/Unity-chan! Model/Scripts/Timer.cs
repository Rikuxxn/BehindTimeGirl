using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�R���|�[�l���g���g�p���邽��

public class CountdownAndAddTimer : MonoBehaviour
{
    public Text timerText; // �^�C�}�[��\������Text�R���|�[�l���g
    private float timer = 30f; // �����^�C�}�[�l�i�J�E���g�_�E���J�n�l�j
    private bool isCountingDown = true; // ���݃J�E���g�_�E�������ǂ���

    void Start()
    {
        UpdateTimerDisplay(); // �����\�����X�V
    }

    void Update()
    {
        if (isCountingDown)
        {
            // �J�E���g�_�E������
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 0f;
                isCountingDown = false; // �J�E���g�_�E���I��
                timerText.color = Color.red; // �e�L�X�g�̐F��ԂɕύX
            }
        }
        else
        {
            // ���Z����
            timer += Time.deltaTime;
        }

        UpdateTimerDisplay(); // �\�����X�V
    }

    void UpdateTimerDisplay()
    {
        if (isCountingDown)
        {
            timerText.color = Color.blue; // �J�E���g�_�E�����͐F
        }

        // �����_�ȉ���؂�̂Ăĕb����\��
        timerText.text = Mathf.FloorToInt(timer).ToString();
    }
}
