using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeShooting : MonoBehaviour 
{
    public float movementSpeed = 0.2f;
    public float fireRate = 0.1f;
    public GameObject projectile;
	public float lenght = 0.5f;
    public float minRanPauseLenght = 1;
    public float maxRanPauseLenght = 1;
    public float minRanStartLenght = 2;
	public float maxRanStartLenght = 2;
    public float audioFadeTime = 1;

    double lastTime = 0;
	double lastTime2 = 0;
	bool shooting = false;
    float pauseLenght;
    bool fadeOutOn = false;
    Vector2 screenBottomLeft;
    AudioSource[] audios;

	void Start () 
    {
        screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        lastTime2 = Random.Range(minRanStartLenght, maxRanStartLenght);
        pauseLenght = Random.Range(minRanPauseLenght, maxRanPauseLenght);

        audios = GetComponents<AudioSource>();

        StartCoroutine(FadeIn(audios[0], audioFadeTime));
        if (this.gameObject.tag == "Fighter")
            StartCoroutine(FadeIn(audios[1], audioFadeTime));
	}
	
	void Update ()
    {
        transform.Translate(Vector2.left * movementSpeed);

		if (lastTime2 >= pauseLenght)
		{
			shooting = true;

			if (lastTime2 >= lenght + pauseLenght)
			{
				shooting = false;
				lastTime2 = 0;
			}
		}

        lastTime2 += Time.deltaTime;

        if (shooting && transform.position.x > screenBottomLeft.x)
		{
			if (lastTime >= fireRate)
			{
				if (this.gameObject.tag == "Fighter") 
				{
					audios[1].Play();
				}
                GameObject proj = Instantiate(projectile, transform.position + projectile.transform.position, projectile.transform.rotation);
                Destroy(proj, 5);
				lastTime = 0;
			}
			else
			{
				lastTime += Time.deltaTime;
			}
		}

        if (transform.position.x <= screenBottomLeft.x && fadeOutOn == false)
        {
            fadeOutOn = true;
            StartCoroutine(FadeOut(audios[0], audioFadeTime));

            if (this.gameObject.tag == "Fighter")
            {
                StartCoroutine(FadeOut(audios[1], audioFadeTime));
            }
        }
	}

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 0;
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        audioSource.volume = 0;

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1;
    }
}
