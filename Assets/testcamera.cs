using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
public class testcamera : MonoBehaviour
{
    public int FileCounter = 0;

    private void LateUpdate()
    {
        if (Keyboard.current.kKey.isPressed)
        {
            CamCapture();
        }
    }

    void CamCapture()
    {
        Camera Cam = GetComponent<Camera>();

        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = Cam.targetTexture;

        Cam.Render();

        Texture2D Image = new Texture2D(4096, 4096);
        Image.ReadPixels(new Rect(0, 0, 4096, 4096), 0, 0);
        Image.Apply();
        RenderTexture.active = currentRT;

        var Bytes = Image.EncodeToPNG();
        Destroy(Image);
        print(Application.dataPath);
        File.WriteAllBytes(Application.dataPath + "/Backgrounds/" + FileCounter + ".png", Bytes);
        FileCounter++;
    }

}
