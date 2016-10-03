using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class endFloorAction : MonoBehaviour {

    void OnTriggerEnter(Collider col) {

        print("in area");
        if (col.CompareTag("Player"))
        { 
            StartCoroutine(endArea());
        }
    }

    IEnumerator endArea()
    {
        print("ending scene in 3 seconds");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
