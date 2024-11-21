using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;  // Φωτισμός ήλιου
    public float dayLength = 24f;  // Διάρκεια ημέρας σε δευτερόλεπτα
    public float startTime = 12f;  // Ώρα εκκίνησης (μεσημέρι, 12)
    private float time;

    void Update()
    {
        time += Time.deltaTime / dayLength * 24f;  // Υπολογισμός ώρας (κυκλική)
        if (time >= 24f) time = 0f;  // Επαναφορά της ώρας σε 0 όταν ξεπεράσει το 24ωρο

        float sunAngle = (time + startTime) % 24f * 15f;  // Υπολογισμός γωνίας ήλιου
        sun.transform.rotation = Quaternion.Euler(sunAngle, 0, 0);  // Ρύθμιση της γωνίας του ήλιου

        // Αλλαγή της έντασης του φωτός ανάλογα με την ώρα
        if (time > 6f && time < 18f)
        {
            sun.intensity = Mathf.Lerp(0.2f, 1f, (time - 6f) / 12f);  // Αυξάνει την ένταση του ήλιου την ημέρα
        }
        else
        {
            sun.intensity = Mathf.Lerp(1f, 0.2f, (time > 18f ? time - 18f : 6f - time) / 6f);  // Μειώνει την ένταση τη νύχτα
        }
    }
}

