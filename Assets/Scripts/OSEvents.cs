using UnityEngine;

public class OSEvents : MonoBehaviour {

    public delegate void FileIconClicked(File file);
    public static event FileIconClicked OnFileIconClicked;

    public static void InputIconClicked(File file)
    {
        OnFileIconClicked(file); 
    }

}
