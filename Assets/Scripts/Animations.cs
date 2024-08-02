using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public GamePlay gameplay;
    public GamblerReaction gamblerreaction;
    public Animator animator;
    public Animator machine_animator;
    public string[] failTriggers;
    public AudioClip[] sadaudioClips;
    public AudioClip[] happyaudioClips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void GamblingButtPressed()
    {
        animator.SetTrigger("OnPressed");
        machine_animator.SetTrigger("Pressed");
        StartCoroutine(WaitAndExecute());

    }

    public void DollarFate()
    {
        gameplay.playerScore += 5;
        machine_animator.SetTrigger("DOLLARS");
        gameplay.UpdateScoreText();
        StartCoroutine(PlayHappyReactionWithDelay());
    }

    public void XFate()
    {
        gameplay.playerScore -= 10;
        machine_animator.SetTrigger("EPIC_FAIL_X");
        gameplay.UpdateScoreText();
        StartCoroutine(PlaySadReactionWithDelay());
    }

    public void JackpotFate()
    {
        gameplay.playerScore += 30;
        machine_animator.SetTrigger("JACKPOT");
        gameplay.UpdateScoreText();
        StartCoroutine(PlayHappyReactionWithDelay());
    }

    public void CherryFate()
    {
        gameplay.playerScore += Random.Range(1, 10);
        machine_animator.SetTrigger("CHERRY");
        gameplay.UpdateScoreText();
        StartCoroutine(PlayHappyReactionWithDelay());
    }

    public void FailFate()
    {
        if (failTriggers.Length == 0)
        {
            Debug.LogWarning("��� ��������� ��� ���������.");
            return;
        }

        // �������� ��������� ������
        int randomIndex = Random.Range(0, failTriggers.Length);

        // ��������� ���������� ��������
        string triggerName = failTriggers[randomIndex];
        machine_animator.SetTrigger(triggerName);
        StartCoroutine(PlaySadReactionWithDelay());

        Debug.Log("����������� �������: " + triggerName);
    }


    private IEnumerator WaitAndExecute()
    {
        // ��������� ���������� ������� �������� �� 3 �� 4 ������
        float delay = Random.Range(3f, 4f);
        yield return new WaitForSeconds(delay);

        // ����� ����� �������� ���, ������� ������ ����������� ����� ��������
        Debug.Log("�������� ���������!");
        gameplay.GamblerFate();

    }

    void PlayRandomHappyClip()
    {
        if (happyaudioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, happyaudioClips.Length);
            audioSource.clip = happyaudioClips[randomIndex];
            audioSource.Play();
        }
    }

    void PlayRandomSadClip()
    {
        if (sadaudioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, sadaudioClips.Length);
            audioSource.clip = sadaudioClips[randomIndex];
            audioSource.Play();
        }
    }

    private IEnumerator PlaySadReactionWithDelay()
    {
        // ��������������� ���������� ��������� ��������� �����
        PlayRandomSadClip();

        // �������� ����������� �������� (��������, 1.5 �������)
        yield return new WaitForSeconds(1f);

        // ����� ������� ����� ��������
        gamblerreaction.SadReaction();
    }

    private IEnumerator PlayHappyReactionWithDelay()
    {
        // ��������������� ���������� ��������� ��������� �����
        PlayRandomHappyClip();

        // �������� ����������� �������� (��������, 1.5 �������)
        yield return new WaitForSeconds(1f);

        // ����� ������� ����� ��������
        gamblerreaction.HappyReaction();
    }
}
