using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine.IO;

public class CamController : MonoBehaviour
{
    public Camera cameraToCapture; // camera that will be taking the pictures
    public RenderTexture renderTexture; // turns those pictures into textures 
    public GameObject gridContainer; // display images in a grid
    public GameObject imagePrefab; // to instantiate new images
    public GameObject imageCanvas; // canvas that plasters the images on screen

    public List<GameObject> capturedImages = new List<GameObject>(); // to store new images within a 3x2 grid

    private bool canTakePic;

    void OnGUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canTakePic = false;
        imageCanvas.SetActive(false);

        if (cameraToCapture != null) // if in use
        {
            // sets target texture to the image captured
            cameraToCapture.targetTexture = renderTexture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x")) // set up cam frame ui
        {
            Debug.Log("can take picture");
            canTakePic = true;
        } 

        if (Input.GetKeyDown("c") && canTakePic == true)
        {
            CaptureImage();
            Debug.Log("cam button pressed");
        }
    }

    private void CaptureImage()
    {
        // gives new images the same dimensions and color as the render texture
        Texture2D capturedTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        // current render texture is set to the image taken
        RenderTexture.active = renderTexture;

        // applies pixels from render texture to captured texture
        capturedTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        capturedTexture.Apply();
        RenderTexture.active = null;

        GameObject newImageObj = Instantiate(imagePrefab, gridContainer.transform);
        Image newImage = newImageObj.GetComponent<Image>();

        newImage.sprite = Sprite.Create(capturedTexture, new Rect(0, 0, capturedTexture.width, capturedTexture.height), new Vector2(0.5f, 0.5f));

        // adds new image to the array
        capturedImages.Add(newImageObj);
    }

    public void OpenDisplay()
    {
        imageCanvas.SetActive(!imageCanvas.activeSelf);
    }
}
