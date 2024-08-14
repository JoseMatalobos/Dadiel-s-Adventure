using UnityEngine;
using System.Collections;

public class FireOnOff : MonoBehaviour
{
    GameObject fireOn, fireOff, fireMid;
    void Start()
    {
        fireOn = GameObject.Find("BlocksOn");
        fireOff = GameObject.Find("BlocksOff");
        fireMid = GameObject.Find("BlocksMid");

        fireOn.SetActive(true);
        fireOff.SetActive(false);
        fireMid.SetActive(false);

        StartCoroutine(TurnOnFire());
    }

    IEnumerator TurnOnFire()
    {
        while (true)
        {
            // Apagar fireOn y encender fireMid
            fireMid.SetActive(true);
            fireOn.SetActive(false);

            // Esperar 5 segundos
            yield return new WaitForSeconds(2f);

            // Encender fireOn y apagar fireMid
            fireMid.SetActive(false);
            fireOn.SetActive(true);

            // Esperar otros 5 segundos
            yield return new WaitForSeconds(5f);

            // Encender fireOff y apagar fireOn
            fireOff.SetActive(true);
            fireOn.SetActive(false);

            // Esperar otros 5 segundos
            yield return new WaitForSeconds(5f);
        }
    }
}
