using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    private float speed = 0.1f;
    public TextMeshProUGUI[] objects;
    public string[] strings;
    public GameObject[] stars;
    public AudioSource audioS;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        audioS.clip = clip;
        StartCoroutine( DisplayAll() );
    }

    IEnumerator DisplayAll() {

        StartCoroutine( DisplayText( 0 ) );
        yield return new WaitForSeconds( 2.5f );

        StartCoroutine( DisplayText( 1 ) );
        yield return new WaitForSeconds( 1.5f );
        StartCoroutine( DisplayNumber( 4 ) );
        yield return new WaitForSeconds( 1 );

        StartCoroutine( DisplayText( 2 ) );
        yield return new WaitForSeconds( 1.5f );
        StartCoroutine( DisplayNumber( 5 ) );
        yield return new WaitForSeconds( 1 );

        StartCoroutine( DisplayText( 3 ) );
        yield return new WaitForSeconds( 1.5f );
        StartCoroutine( DisplayNumber( 6 ) );
        yield return new WaitForSeconds( 1 );

        stars[0].SetActive( true );
        stars[1].SetActive( true );
        stars[2].SetActive( true );
        stars[3].SetActive( true );
        stars[4].SetActive( true );

        yield return new WaitForSeconds( 1 );
        
        stars[5].SetActive( true );
        yield return new WaitForSeconds( 0.5f );
        stars[6].SetActive( true );
        yield return new WaitForSeconds( 0.5f );

        if ( Globals.GetResult() ) {
            stars[7].SetActive( true );
            yield return new WaitForSeconds( 0.5f );

            if ( Globals.GetScore() >= 10000 ) {
                stars[8].SetActive( true );
                yield return new WaitForSeconds( 0.5f );

                if ( Globals.GetLostOrders() == 0 ) stars[9].SetActive( true );
                yield return new WaitForSeconds( 0.5f );

            }

        }

        stars[10].SetActive( true );

    }

    IEnumerator DisplayText( int index ) {
        audioS.Play();
        TextMeshProUGUI tmp = objects[index];
        string s = strings[index];
        char[] charArray = s.ToCharArray();
        tmp.SetText("");
        foreach ( char c in charArray ) {
            tmp.SetText( tmp.text += c );
            if (!c.Equals(" ") )yield return new WaitForSeconds( speed );
        }
        audioS.Stop();
    }

    IEnumerator DisplayNumber( int index ) {
        audioS.Play();
        TextMeshProUGUI tmp = objects[index];
        int i = 0;
        if ( index == 4 ) i = Globals.GetPlates();
        else if ( index == 5 ) i = Globals.GetLostOrders();
        else if ( index == 6 ) i = Globals.GetScore();
        else StopCoroutine("DisplayNumber");
        char[] charArray = i.ToString().ToCharArray();
        tmp.SetText("");
        foreach ( char c in charArray ) {
            tmp.SetText( tmp.text += c );
            if (!c.Equals(" ") )yield return new WaitForSeconds( speed );
        }
        audioS.Stop();
    }

    public void ToMenu() {
        SceneManager.LoadScene("MainMenu");
    }

}
