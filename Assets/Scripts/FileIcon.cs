using UnityEngine;
using UnityEngine.UI;

public class FileIcon : MonoBehaviour {

    public File File;

    private Button button;
    private RawImage rawImage;

    void Start()
    {
        // set rawimage to file's icon
        rawImage = GetComponent<RawImage>();
        rawImage.texture = File.icon;

        // dynamically add OSEvents event as listener-
        // since icons can't be baked into the UI, and will be instantiated at runtime,
        // can't statically set the function for OnClick to call
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { OSEvents.InputIconClicked(File); } );
    }
}
