using UnityEngine;

public class BeatScaler : MonoBehaviour
{
    public AudioSource audioSource;  // ������������� � �������
    public GameObject targetObject;  // ������, ������� ����� �������� ������
    public float scaleFactor = 1.5f;  // ������������ ���������� �������
    public float smoothness = 0.5f;   // ��������� ������ ���������� ������

    private Vector3 originalScale;  // ������������ ������ �������
    private float[] samples = new float[64];  // ������ ��� �������� ������ �������

    void Start()
    {
        if (targetObject == null)
        {
            targetObject = this.gameObject;  // ���� ������ �� ��������, ������������ �������
        }

        originalScale = targetObject.transform.localScale;  // ���������� �������� ������ �������
    }

    void Update()
    {
        // �������� ������������ ������ �� ��������������
        audioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);

        // ��������� ������� ��������� �������
        float averageAmplitude = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            averageAmplitude += samples[i];
        }
        averageAmplitude /= samples.Length;

        // ������������ ����� ������� �������
        float scale = 1 + averageAmplitude * scaleFactor;

        // ������ �������� ������ �������
        targetObject.transform.localScale = Vector3.Lerp(targetObject.transform.localScale, originalScale * scale, smoothness);
    }
}
