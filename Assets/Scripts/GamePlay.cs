using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public Animations animations;
    public int playerScore = 7; // Переменная для хранения счета игрока
    public TMP_Text scoreTextTMP; // Ссылка на TextMeshPro UI-текст
    public bool isActive = true;
    public delegate void MethodToCall();
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    void Start()
    {
        // Устанавливаем начальное значение счета
        playerScore = 5;
        UpdateScoreText(); // Обновляем текстовое поле

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void GamblingButtonPressed()
    {
        if (isActive)
        {
            isActive = false;
            // Проверяем, достаточно ли у игрока очков для выполнения действия
            if (playerScore >= 1)
            {
                // Если очков достаточно, выполняем действие
                animations.GamblingButtPressed();
                PlayRandomClip();
                // Списываем очки за выполнение действия
                playerScore -= 1;
                UpdateScoreText(); // Обновляем текстовое поле после изменения счета
            }
            else
            {
                // Если очков недостаточно, выводим сообщение
                Debug.Log("Недостаточно очков для выполнения действия.");
                SceneManager.LoadScene("Lose");
            }
        }
    }

    void PlayRandomClip()
    {
        if (audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomIndex];
            audioSource.Play();
        }
    }

    public void GamblerFate()
    {
        CallRandomFate();
    }

    public void CallRandomFate()
    {
        // Создаем массив с методами, которые можно вызвать
        MethodToCall[] methods = { Dollar, X, Jackpot, Cherry, Fail };

        // Выбираем случайный индекс
        int randomIndex = Random.Range(0, methods.Length);

        // Вызываем выбранный метод
        methods[randomIndex]();
    }

    public void Dollar()
    {
        animations.DollarFate();
        Debug.Log("DOLLARS! Yay!");
        isActive = true;
    }

    public void X()
    {
        animations.XFate();
        Debug.Log("Aw dang it!");
        isActive = true;
    }

    public void Jackpot()
    {
        animations.JackpotFate();
        Debug.Log("JACKPOT BABY!");
        isActive = true;
    }

    public void Cherry()
    {
        animations.CherryFate();
        Debug.Log("Cherry!");
        isActive = true;
    }

    public void Fail()
    {
        animations.FailFate();
        Debug.Log("Nothing. Just a mess.");
        isActive = true;
    }

    public void UpdateScoreText()
    {
        // Обновляем TextMeshPro текстовое поле значением текущего счета
        scoreTextTMP.text = playerScore.ToString();
    }
}
