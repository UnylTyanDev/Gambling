using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Animator animator;

    IEnumerator Wait()
    {
        animator.SetTrigger("OnPressed");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game");

    }

    public void ChangeScene()
    {
        StartCoroutine(Wait());
    }

}
