using UnityEngine;

public class File : MonoBehaviour {

    public enum FileType
    {
        Image, Text
    }

    public Transform screenLocation;
    public FileType fileType;
    public Texture2D icon;
    public Texture2D imageContent;
    public string textContent;
}
