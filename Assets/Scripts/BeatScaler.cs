using UnityEngine;

public class BeatScaler : MonoBehaviour
{
    public AudioSource audioSource;  // Аудиоисточник с музыкой
    public GameObject targetObject;  // Объект, который будет изменять размер
    public float scaleFactor = 1.5f;  // Максимальное увеличение размера
    public float smoothness = 0.5f;   // Насколько плавно изменяется размер

    private Vector3 originalScale;  // Оригинальный размер объекта
    private float[] samples = new float[64];  // Массив для хранения данных спектра

    void Start()
    {
        if (targetObject == null)
        {
            targetObject = this.gameObject;  // Если объект не назначен, использовать текущий
        }

        originalScale = targetObject.transform.localScale;  // Запоминаем исходный размер объекта
    }

    void Update()
    {
        // Получаем спектральные данные из аудиоисточника
        audioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);

        // Вычисляем среднюю амплитуду спектра
        float averageAmplitude = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            averageAmplitude += samples[i];
        }
        averageAmplitude /= samples.Length;

        // Рассчитываем новый масштаб объекта
        float scale = 1 + averageAmplitude * scaleFactor;

        // Плавно изменяем размер объекта
        targetObject.transform.localScale = Vector3.Lerp(targetObject.transform.localScale, originalScale * scale, smoothness);
    }
}
