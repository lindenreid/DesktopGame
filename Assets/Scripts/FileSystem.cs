using UnityEngine;
using UnityEngine.UI;

public class FileSystem : MonoBehaviour {

    private HardDrive HardDrive;

    public Canvas MainCanvas;
    public GameObject IconPrefab;
    public GameObject ImageContentPrefab;
    public GameObject TextContentPrefab;

    void Start ()
    {
        HardDrive = GetComponent<HardDrive>();

        // display all desktop icons
        Directory desktop = GameObject.FindWithTag("Desktop").GetComponent<Directory>();
        for(int i=0; i<desktop.Files.Count; i++)
        {
            DisplayIcon(desktop.Files[i]);
        }
	}

    void OnEnable()
    {
        OSEvents.OnFileIconClicked += HandleFileIconClicked;
    }

    void OnDisable()
    {
        OSEvents.OnFileIconClicked -= HandleFileIconClicked;
    }

    private void DisplayIcon(File file)
    {
        Vector3 screenLocation = new Vector3(0,0,0);

        GameObject newIcon = Instantiate(IconPrefab, screenLocation, Quaternion.identity) as GameObject;
        newIcon.transform.parent = MainCanvas.transform;
        newIcon.GetComponent<FileIcon>().File = file;
    }

    private void DisplayImageContent(File file)
    {
        Vector3 screenLocation = new Vector3(0, 0, 0);

        GameObject newImageContent = Instantiate(ImageContentPrefab, screenLocation, Quaternion.identity) as GameObject;
        newImageContent.transform.parent = MainCanvas.transform;
        newImageContent.GetComponent<RawImage>().texture = file.imageContent;
    }

    public void HandleFileIconClicked(File file)
    {
        if(file.fileType == File.FileType.Image)
            DisplayImageContent(file);
    }

}
