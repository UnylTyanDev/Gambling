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
            Debug.LogWarning("Нет триггеров для активации.");
            return;
        }

        // Выбираем случайный индекс
        int randomIndex = Random.Range(0, failTriggers.Length);

        // Активация случайного триггера
        string triggerName = failTriggers[randomIndex];
        machine_animator.SetTrigger(triggerName);
        StartCoroutine(PlaySadReactionWithDelay());

        Debug.Log("Активирован триггер: " + triggerName);
    }


    private IEnumerator WaitAndExecute()
    {
        // Генерация случайного времени задержки от 3 до 4 секунд
        float delay = Random.Range(3f, 4f);
        yield return new WaitForSeconds(delay);

        // Здесь можно добавить код, который должен выполниться после задержки
        Debug.Log("Задержка завершена!");
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
        // Воспроизведение случайного грустного звукового клипа
        PlayRandomSadClip();

        // Ожидание настроенной задержки (например, 1.5 секунды)
        yield return new WaitForSeconds(1f);

        // Вызов реакции после задержки
        gamblerreaction.SadReaction();
    }

    private IEnumerator PlayHappyReactionWithDelay()
    {
        // Воспроизведение случайного грустного звукового клипа
        PlayRandomHappyClip();

        // Ожидание настроенной задержки (например, 1.5 секунды)
        yield return new WaitForSeconds(1f);

        // Вызов реакции после задержки
        gamblerreaction.HappyReaction();
    }
}
