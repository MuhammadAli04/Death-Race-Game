using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TextureScript : MonoBehaviour
{
    public bool isVisibleAtStart;
    public bool fadeInAtStart;
    public float fadeInDelay;
    public float fadeInSpeed;
    public Rect textureRect;
    public Texture2D texture;
    public int depth;
    private bool isVisible;
    public float alpha; //an alpha of 1 means the texture is opaque, 0 means completely see-through. This variable changes to fade in and out.
    private bool isFadingIn;
    private Color guiColor; //includes gui alpha variable
    private bool isFadingOut;
    public virtual void Awake()
    {
        this.guiColor = Color.white;
        if (this.isVisibleAtStart == false)
        {
            this.isVisible = false;
        }
    }

    public virtual IEnumerator Start()
    {
        if (this.fadeInAtStart == true)
        {
            yield return new WaitForSeconds(this.fadeInDelay);
            this.FadeIn();
        }
    }

    public virtual void Update()
    {
        if (this.isFadingIn == true)
        {
            this.alpha = this.alpha + this.fadeInSpeed;
            if (this.alpha > 1)
            {
                //finished fading in
                this.alpha = 1;
                this.isFadingIn = false;
            }
        }
        if (this.isFadingOut == true)
        {
            this.alpha = this.alpha - this.fadeInSpeed;
            if (this.alpha < 0)
            {
                //finished fading out
                this.alpha = 0;
                this.isFadingOut = false;
            }
        }
    }

    public virtual void OnGUI()
    {
        GUI.depth = this.depth;
        this.guiColor.a = this.alpha;
        GUI.color = this.guiColor;
        if (this.isVisible == true)
        {
            GUI.DrawTexture(this.textureRect, this.texture, ScaleMode.StretchToFill, true, 10f);
        }
    }

    public virtual void FadeIn()
    {
        this.alpha = 0;
        this.isFadingIn = true;
    }

    public virtual void FadeOut()
    {
        this.alpha = 1;
        this.isFadingOut = true;
    }

    public TextureScript()
    {
        this.fadeInSpeed = 0.1f;
        this.isVisible = true;
    }

}