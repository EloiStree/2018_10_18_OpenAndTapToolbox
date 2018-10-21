using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainterCanva2Controller2 : MonoBehaviour {

    public RawImage rawImg;
    public Painter painterCanvas;
    public Material drawOtherRtMat;
    [Range(0f,1f)]
    public float penAlpha = 1f;
    public Color penColor = Color.white;

    private bool _mouseIsDown = false;

    private RenderTexture _rt;
	// Use this for initialization
	void Start () {
        painterCanvas.gameObject.SetActive(true);
        _rt = new RenderTexture(painterCanvas.renderTexWidth, painterCanvas.renderTexHeight, 0, RenderTextureFormat.ARGB32);
        _rt.useMipMap = false;
        if (rawImg.texture != null)
        {
            Graphics.SetRenderTarget (_rt);
            Graphics.Blit(rawImg.texture,_rt);
            RenderTexture.active = null;
        }

        //set mask
        drawOtherRtMat.SetTexture("_MaskTex",rawImg.texture);
        painterCanvas.canvasMat.SetTexture("_MaskTex",rawImg.texture);

        //use rendertexture to replace.
        rawImg.texture = _rt;
	}
	
	// Update is called once per frame
	void Update () {
        penColor.a = 1;
        if(Input.GetMouseButtonDown(0))
        {
            _mouseIsDown = true;
        }
        if(_mouseIsDown && Input.GetMouseButton(0))
        {
            Vector2 pos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(painterCanvas.transform as RectTransform, Input.mousePosition, null, out pos))
            {
                painterCanvas.canvasMat.SetFloat("_Alpha",penAlpha);
                painterCanvas.penColor = penColor;
                painterCanvas.Drawing(pos,null,painterCanvas.renderTexture,false,true);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            _mouseIsDown = false;
            drawOtherRtMat.SetFloat("_Alpha",penAlpha);
            drawOtherRtMat.SetVector("_Color",penColor);
            painterCanvas.DrawRT2OtherRT(painterCanvas.renderTexture,_rt,drawOtherRtMat);
            painterCanvas.ClearCanvas();
            painterCanvas.EndDraw();
        }
	}
}
