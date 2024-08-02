using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public Animations animations;
    public int playerScore = 7; // ���������� ��� �������� ����� ������
    public TMP_Text scoreTextTMP; // ������ �� TextMeshPro UI-�����
    public bool isActive = true;
    public delegate void MethodToCall();
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    void Start()
    {
        // ������������� ��������� �������� �����
        playerScore = 5;
        UpdateScoreText(); // ��������� ��������� ����

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
            // ���������, ���������� �� � ������ ����� ��� ���������� ��������
            if (playerScore >= 1)
            {
                // ���� ����� ����������, ��������� ��������
                animations.GamblingButtPressed();
                PlayRandomClip();
                // ��������� ���� �� ���������� ��������
                playerScore -= 1;
                UpdateScoreText(); // ��������� ��������� ���� ����� ��������� �����
            }
            else
            {
                // ���� ����� ������������, ������� ���������
                Debug.Log("������������ ����� ��� ���������� ��������.");
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
        // ������� ������ � ��������, ������� ����� �������
        MethodToCall[] methods = { Dollar, X, Jackpot, Cherry, Fail };

        // �������� ��������� ������
        int randomIndex = Random.Range(0, methods.Length);

        // �������� ��������� �����
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
        // ��������� TextMeshPro ��������� ���� ��������� �������� �����
        scoreTextTMP.text = playerScore.ToString();
    }
}
