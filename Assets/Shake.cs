using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    [SerializeField] public AutoRunner autorunner;
    // Update is called once per frame
    void Update()
    {
            if(start) {
                start = false;
                StartCoroutine(Shaking());
            }
    }

    IEnumerator Shaking() {
        Vector3 startPosition = transform.position;
        autorunner.active = false;
        float elapsedTime = 0f;
        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        autorunner.active = true;
        transform.position = startPosition;
    }
}
