using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalManager : MonoBehaviour
{
    public TextMeshProUGUI goalText; // �S�[���\���p��TextMeshPro
    public Timer timerScript; // Timer�X�N���v�g�ւ̎Q�Ƃ�ǉ�

    // �S�[�����Ԃɉ��������b�Z�[�W
    private string GetGoalMessage(float time, bool isCountingDown)
    {
        if (isCountingDown && time <= 0) // �^�C���I�[�o�[
        {
            return "TIME OVER...";
        }
        else if (!isCountingDown) // �J�E���g�A�b�v��
        {
            return "TIME OVER...";
        }
        else if (time <= 30f) // 30�b�ȓ��ŃS�[��
        {
            return "PERFECT GOAL!";
        }
        else if (time <= 45f) // 45�b�ȓ��ŃS�[��
        {
            return "GOOD GOAL!";
        }
        else // 45�b�𒴂����ꍇ
        {
            return "GOAL...";
        }
    }
    void Start()
    {
        // �ŏ��̓S�[�����b�Z�[�W���\���ɂ���
        if (goalText != null)
        {
            goalText.text = "";
        }

        // Timer�X�N���v�g�̎Q�Ƃ��Ȃ��ꍇ�A�V�[��������T��
        if (timerScript == null)
        {
            timerScript = FindObjectOfType<Timer>();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // �v���C���[���S�[���I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        if (other.CompareTag("Player") && timerScript != null)
        {
            DisplayGoalMessage(timerScript.GetCurrentTime(), timerScript.IsCountingDown());
        }
    }

    void DisplayGoalMessage(float time, bool isCountingDown)
    {
        if (goalText != null)
        {
            goalText.text = GetGoalMessage(time, isCountingDown);
        }
    }
}