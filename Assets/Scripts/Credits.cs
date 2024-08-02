using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject[] objectsToActivate;  // ������ �������� ��� ���������/�����������
    public float delayBetweenActions = 2f;  // �������� ����� ���������� � ������������ ������� �������

    void Start()
    {
        StartCoroutine(ActivateAndDeactivateObjects());
    }

    IEnumerator ActivateAndDeactivateObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);  // ���������� ������
            yield return new WaitForSeconds(delayBetweenActions);  // ������ �����
            obj.SetActive(false);  // ������������ ������
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }
}
