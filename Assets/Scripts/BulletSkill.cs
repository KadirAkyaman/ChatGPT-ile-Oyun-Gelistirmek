using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkill : MonoBehaviour
{
    public float maxScale = 5f; // maksimum boyut
    public float growthRate = 0.5f; // büyüme hýzý
    public Color maxColor = Color.red; // maksimum renk

    private float currentScale = 1f; // mevcut boyut
    private bool isMaxSizeReached = false; // maksimum boyuta ulaþýldý mý?

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(GrowAndColorChange());
    }

    IEnumerator GrowAndColorChange()
    {
        while (!isMaxSizeReached)
        {
            currentScale += growthRate * Time.deltaTime;
            if (currentScale >= maxScale)
            {
                currentScale = maxScale;
                isMaxSizeReached = true;
                GetComponent<Renderer>().material.color = maxColor;
            }
            transform.localScale = new Vector3(currentScale, currentScale, currentScale);
            yield return null;
        }
    }
}
