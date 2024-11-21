using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;  // �������� �����
    public float dayLength = 24f;  // �������� ������ �� ������������
    public float startTime = 12f;  // ��� ��������� (��������, 12)
    private float time;

    void Update()
    {
        time += Time.deltaTime / dayLength * 24f;  // ����������� ���� (�������)
        if (time >= 24f) time = 0f;  // ��������� ��� ���� �� 0 ���� ��������� �� 24���

        float sunAngle = (time + startTime) % 24f * 15f;  // ����������� ������ �����
        sun.transform.rotation = Quaternion.Euler(sunAngle, 0, 0);  // ������� ��� ������ ��� �����

        // ������ ��� ������� ��� ����� ������� �� ��� ���
        if (time > 6f && time < 18f)
        {
            sun.intensity = Mathf.Lerp(0.2f, 1f, (time - 6f) / 12f);  // ������� ��� ������ ��� ����� ��� �����
        }
        else
        {
            sun.intensity = Mathf.Lerp(1f, 0.2f, (time > 18f ? time - 18f : 6f - time) / 6f);  // ������� ��� ������ �� �����
        }
    }
}

