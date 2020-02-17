using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Countdown : MonoBehaviour
{
    public float initialDelay;
    public TextureScript three;
    public TextureScript two;
    public TextureScript one;
    public TextureScript go;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(this.initialDelay);
        this.three.FadeIn();
        yield return new WaitForSeconds(1);
        this.three.FadeOut();
        this.two.FadeIn();
        yield return new WaitForSeconds(1);
        this.two.FadeOut();
        this.one.FadeIn();
        yield return new WaitForSeconds(1);
        this.one.FadeOut();
        this.go.FadeIn();
        yield return new WaitForSeconds(1);
        this.go.FadeOut();
    }

    public virtual void Update()
    {
    }

}