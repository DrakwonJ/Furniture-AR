using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InputManager : MonoBehaviour
{
    //[SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;
    //[SerializeField] private GameObject crosshair;
    [SerializeField]
    public GameObject placeObject;
    [SerializeField]
    public GameObject spawnObject;
    [SerializeField]
    private Camera arCamera;
    private static InputManager instance;
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InputManager>();
            }
            return instance;
        }
    }

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            Permission.RequestUserPermission(Permission.Camera);
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
    }

    // Update is called once per frame
    void Update()
    {
        //if (placeObject != null)
         //   TestTextr.name.text = placeObject.name.ToString();
        //else
        //    TestTextr.name.text = "Not spawnObject";
        PlacedByClick();
    }
    float prevTouchDist = 0f;
    // 투명하게 보이게 하기!
    // 조작하고 있는 가구가 투명하게 되고 fix하면 밑에 fadein 실행되면서 불투명해짐
    public void FadeOut()
    {
        if (spawnObject != null && !spawnObject.GetComponent<ItemController>().is_fixed)
        {
            if(spawnObject.GetComponent<MeshRenderer>() != null)
            {
                spawnObject.GetComponent<Renderer>().sharedMaterial.shader = Shader.Find("Legacy Shaders/Transparent/Bumped Diffuse");
                Color c = spawnObject.GetComponent<Renderer>().sharedMaterial.color;
                c.a = 0.8f;
                spawnObject.GetComponent<Renderer>().sharedMaterial.color = c;

                
            }
            else
            {
                foreach (Renderer render in spawnObject.GetComponentsInChildren<Renderer>())
                {
                    render.sharedMaterial.shader = Shader.Find("Legacy Shaders/Transparent/Bumped Diffuse");
                    Color c = render.sharedMaterial.color;
                    c.a = 0.8f;
                    render.sharedMaterial.color = c;
                }
            }
        }
        else
            return;

    }
    // 불투명하게 만들기!
    public void FadeIn()
    {
        if (spawnObject != null)
        {
            if (spawnObject.GetComponent<MeshRenderer>() != null)
            {
                spawnObject.GetComponent<Renderer>().sharedMaterial.shader = Shader.Find("Legacy Shaders/Bumped Diffuse");
                Color c = spawnObject.GetComponent<Renderer>().sharedMaterial.color;
                c.a = 1.0f;
                spawnObject.GetComponent<Renderer>().sharedMaterial.color = c;


            }
            else
            {
                foreach (Renderer render in spawnObject.GetComponentsInChildren<Renderer>())
                {
                    render.sharedMaterial.shader = Shader.Find("Legacy Shaders/Bumped Diffuse");
                    Color c = render.sharedMaterial.color;
                    c.a = 1.0f;
                    render.sharedMaterial.color = c;
                }
            }
        }
        else
            return;
    }

    private void PlacedByClick()
    {
        float scaleSpeed = 10.0f;
        if(Input.touchCount >= 2) 
        {
            if (spawnObject == null)
                return;
            float touchDist = (Input.touches[0].position - Input.touches[1].position).sqrMagnitude;
            if (prevTouchDist == 0)
            {
                prevTouchDist = touchDist;
                return;
            }
            if(prevTouchDist < touchDist)
            {
                Vector3 spawnScale = spawnObject.transform.localScale;
                spawnObject.transform.localScale = new Vector3(
                    spawnScale.x + 1f * scaleSpeed * Time.deltaTime,
                    spawnScale.y + 1f * scaleSpeed * Time.deltaTime,
                    spawnScale.z + 1f * scaleSpeed * Time.deltaTime);
            }
            if(prevTouchDist > touchDist)
            {
                Vector3 spawnScale = spawnObject.transform.localScale;
                spawnObject.transform.localScale = new Vector3(
                    spawnScale.x - 1f * scaleSpeed * Time.deltaTime,
                    spawnScale.y - 1f * scaleSpeed * Time.deltaTime,
                    spawnScale.z - 1f * scaleSpeed * Time.deltaTime);
            }
            prevTouchDist = touchDist;
        }

        // 객체 생성하는 부분에 fadein 해주고 destroy하기 전에 fadeout 해줌

        else if(Input.GetMouseButton(0))
        {
            Ray ray;
            RaycastHit hitObj;
            Vector3 mousePose = Input.mousePosition;

            if (IsPointerOverUI(mousePose))
                return;
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            ray = arCamera.ScreenPointToRay(mousePose);

            if (Physics.Raycast(ray, out hitObj)) // 여기 if문하고 밑에 있는 189줄에 있는 if문 순서 바꿈 그래야 뭔가 더 매끄러움
            {
                if (hitObj.transform.tag == "Furniture")
                {
                    if (spawnObject == null)
                    {
                        spawnObject = hitObj.transform.gameObject;
                        Fixbutton();
                        Fixbutton();
                        FadeOut();
                    }
                    if (hitObj.transform.gameObject == spawnObject)
                        return;

                    if (hitObj.transform.gameObject != spawnObject)
                    {
                        if (spawnObject.GetComponent<ItemController>().is_fixed == false)
                        {
                            FadeIn();
                            Destroy(spawnObject);
                        }

                        spawnObject = hitObj.transform.gameObject;
                        FadeOut();
                    }
                }
            }

            // 여기 fixbutton 을 호출했는데 왠지 약간 오브젝트가 끊겨서 움직임
            // 근데 fix버튼 호출하고 했는데 부드럽더라고
            // 왜그런지 모르겠는데 그래서 생서될 때 두번 호출해서 부드럽게 만듬
            if (_raycastManager.Raycast(mousePose, hits, TrackableType.Planes))
            {

                Pose pose = hits[0].pose;
                if (spawnObject != null && spawnObject.GetComponent<ItemController>().is_fixed == true && placeObject == null)
                    return;
                if (spawnObject == null && placeObject != null)
                {
                    spawnObject = Instantiate(placeObject, pose.position, placeObject.transform.rotation);
                    Fixbutton();
                    Fixbutton();
                    FadeOut();
                    placeObject = null;
                }
                else if (spawnObject != null && spawnObject.GetComponent<ItemController>().is_fixed == false && placeObject != null)
                {
                    FadeIn();
                    Destroy(spawnObject);
                    spawnObject = Instantiate(placeObject, pose.position, placeObject.transform.rotation);
                    Fixbutton();
                    Fixbutton();
                    FadeOut();
                    placeObject = null;
                }
                else if (spawnObject != null && spawnObject.GetComponent<ItemController>().is_fixed == true && placeObject != null)
                {
                    spawnObject = Instantiate(placeObject, pose.position, placeObject.transform.rotation);
                    Fixbutton();
                    Fixbutton();
                    FadeOut();
                    placeObject = null;
                }
                else
                {
                    spawnObject.transform.position = pose.position;
                }
            }
        }
    }

    // fixButton 함수
    public void Fixbutton()
    {
        GameObject targetObject;
        targetObject = InputManager.Instance.spawnObject;
        if (targetObject.GetComponent<ItemController>().is_fixed)
        {
            targetObject.GetComponent<ItemController>().is_fixed = false;
            InputManager.Instance.FadeOut();
            targetObject.GetComponent<Collider>().enabled = false;
        }
        else
        {
            targetObject.GetComponent<ItemController>().is_fixed = true;
            InputManager.Instance.FadeIn();
            targetObject.GetComponent<Collider>().enabled = true;
        }
    }

    public bool IsPointerOverUI(Vector3 mousePose)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(mousePose.x, mousePose.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
    
}