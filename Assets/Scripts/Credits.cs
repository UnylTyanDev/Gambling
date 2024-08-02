using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject[] objectsToActivate;  // Массив объектов для активации/деактивации
    public float delayBetweenActions = 2f;  // Задержка между активацией и деактивацией каждого объекта

    void Start()
    {
        StartCoroutine(ActivateAndDeactivateObjects());
    }

    IEnumerator ActivateAndDeactivateObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);  // Активируем объект
            yield return new WaitForSeconds(delayBetweenActions);  // Делаем паузу
            obj.SetActive(false);  // Деактивируем объект
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }
}
