using UnityEngine;
using System.Collections;

public class ballLogic : MonoBehaviour {
    public float waittime = 5;

    void Awake()
    {
        StartCoroutine(alivethendie());
    }

    IEnumerator alivethendie()
    {
        yield return new WaitForSeconds(1);
        while (transform.parent != null)
        {
            yield return new WaitForSeconds(.5f);
        }

        yield return new WaitForSeconds(waittime);
        Destroy(gameObject);
    }
}
