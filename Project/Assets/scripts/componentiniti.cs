using System.Collections.Generic;

public class componentiniti : MonoBehaviour
{
    public GameObject serverGO;
    public GameObject[] urzadzeniaSieciowe;

    public GameObject[] elements;
    //public GameObject pustePole;
    public GameObject[] pustePole;

    [SerializeField] private List<GameObject> urzadzeniaZainicjalizowane;

    //private int numerpola = 0;
    private int k = 0;



    private MLInput.Controller controller;
    public GameObject HeadLocokedCanvas;
    public GameObject controllerInput;

    public GameObject drzwi;
    public GameObject oslonaLewa;
    public GameObject oslonaPrawa;
    public GameObject oslonaTylna;

    private bool flag = true;

    //public GameObject pustepole;


    bool wcisniety = false;
    //////////

    private int numerPolaWybranegoPrzyciskiem = -1;
    private GameObject wybraneUrzadzenie = null;

    //Tablica zapisująca zajęte miejsca w szafie//
    //private bool[] ZajeteMiejsceWSzafie = new bool[42];
    private string[] ZajeteMiejsceWSzafie = new string[42];

    //Komunikat o bledzie
    public GameObject error;

    //przyciski powrotu
    public GameObject wroc_do_menu;
    public GameObject wroc_do_biblioteki;

    //flaga czy wybrana opcja usuwania elementow
    private bool trybUsuwania = false;

    //przyciski...
    public GameObject[] Przyciski = new GameObject[42];

    //Menu//
    public GameObject[] menuWidoki;
    void Start()
    {
        MLInput.Start();
        controller = MLInput.GetController(MLInput.Hand.Right);

        //widoki dezaktywacja
        foreach (GameObject widok in menuWidoki)
        {
            widok.SetActive(false);
        }

        error.SetActive(false);
        wroc_do_menu.SetActive(false);
        wroc_do_biblioteki.SetActive(false);

        menuWidoki[0].SetActive(true);

    }

    void Update()
    {

        //Menu//
        if (controller.TriggerValue > 0.9f && wcisniety == false)
        {
            RaycastHit hit;

            if (Physics.Raycast(controllerInput.transform.position, controllerInput.transform.forward, out hit))
            {
                //----------------------------Widok Otwierania/Zamykania------------------------------
                if (hit.transform.gameObject.name == "otworz")
                {
                    menuWidoki[0].SetActive(false);
                    menuWidoki[1].SetActive(true);
                    wroc_do_menu.SetActive(true);

                    wcisniety = true;
                }

                //drzwi
                if (hit.transform.gameObject.name == "znika")
                {

                    drzwi.SetActive(false);
                    this.flag = false;
                    wcisniety = true;

                }

                if (hit.transform.gameObject.name == "pokazuje")
                {

                    drzwi.SetActive(true);
                    this.flag = true;
                    wcisniety = true;

                }

                //sciana lewa
                if (hit.transform.gameObject.name == "znikaLO")
                {

                    oslonaLewa.SetActive(false);
                    this.flag = false;
                    wcisniety = true;

                }

                if (hit.transform.gameObject.name == "pokazujeLO")
                {

                    oslonaLewa.SetActive(true);
                    this.flag = true;
                    wcisniety = true;

                }

                //sciana lewa
                if (hit.transform.gameObject.name == "znikaPO")
                {

                    oslonaPrawa.SetActive(false);
                    this.flag = false;
                    wcisniety = true;

                }

                if (hit.transform.gameObject.name == "pokazujePO")
                {

                    oslonaPrawa.SetActive(true);
                    this.flag = true;
                    wcisniety = true;

                }

                //sciana tylna
                if (hit.transform.gameObject.name == "znikaTO")
                {

                    oslonaTylna.SetActive(false);
                    this.flag = false;
                    wcisniety = true;

                }

                if (hit.transform.gameObject.name == "pokazujeTO")
                {

                    oslonaTylna.SetActive(true);
                    this.flag = true;
                    wcisniety = true;

                }
                //=================================================================================


                //----------------------------Przycisk powrotu do menu glownego-------------------------------
                if (hit.transform.gameObject.name == "wroc_do_menu")
                {
                    foreach (GameObject widok in menuWidoki)
                    {
                        widok.SetActive(false);
                    }

                    menuWidoki[0].SetActive(true);
                    menuWidoki[2].SetActive(false);
                    wroc_do_menu.SetActive(false);
                    wroc_do_biblioteki.SetActive(false);
                    wcisniety = true;

                    error.SetActive(false);

                    trybUsuwania = false;
                }

                //=================================================================================

                //----------------------------Przycisk powrotu do biblioteki------------------------------- NIEDZIALA! 
                if (hit.transform.gameObject.name == "wroc_do_biblioteki")
                {
                    foreach (GameObject widok in menuWidoki)
                    {
                        widok.SetActive(false);
                    }

                    menuWidoki[2].SetActive(true);

                    wcisniety = true;

                    error.SetActive(false);
                    wroc_do_biblioteki.SetActive(false);
                }

                //=================================================================================


                //-------------------------------------Widok Biblioteka z podstronami-----------------------------------
                if (hit.transform.gameObject.name == "buduj")
                {
                    menuWidoki[0].SetActive(false);
                    menuWidoki[2].SetActive(true);
                    wroc_do_menu.SetActive(true);
                    wcisniety = true;
                }

                //-------------------------------------Widok usuwania-----------------------------------
                if (hit.transform.gameObject.name == "usun")
                {
                    menuWidoki[0].SetActive(false);
                    wroc_do_menu.SetActive(true);
                    wcisniety = true;

                    trybUsuwania = true;
                }


                //---------------------------Podkategorie-------------------------------------------------------------
                if (hit.transform.gameObject.name == "macierzeDyskowe")
                {
                    menuWidoki[2].SetActive(false);
                    menuWidoki[8].SetActive(true);
                    wroc_do_menu.SetActive(true);
                    wroc_do_biblioteki.SetActive(true);
                    wcisniety = true;

                }

                if (hit.transform.gameObject.name == "przelacznikiSieciowe")
                {
                    menuWidoki[2].SetActive(false);
                    menuWidoki[9].SetActive(true);
                    wroc_do_menu.SetActive(true);
                    wroc_do_biblioteki.SetActive(true);
                    wcisniety = true;
                }

                if (hit.transform.gameObject.name == "serwery")
                {
                    menuWidoki[2].SetActive(false);
                    menuWidoki[7].SetActive(true);
                    wroc_do_menu.SetActive(true);
                    wroc_do_biblioteki.SetActive(true);
                    wcisniety = true;
                }

                if (hit.transform.gameObject.name == "ups")
                {
                    menuWidoki[2].SetActive(false);
                    menuWidoki[10].SetActive(true);
                    wroc_do_menu.SetActive(true);
                    wroc_do_biblioteki.SetActive(true);
                    wcisniety = true;

                }
                //=====================================================================================================

                //-----------------------------Macierze dyskowe-----------------------------------------

                if (hit.transform.gameObject.name == "bcs-ess16nhdd")
                {
                    menuWidoki[8].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[0];
                }

                if (hit.transform.gameObject.name == "powervault_md1400")
                {
                    menuWidoki[8].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[1];
                }

                if (hit.transform.gameObject.name == "qnap_ts-1231xu-rp")
                {
                    menuWidoki[8].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[2];
                }

                //----------------------------Przelaczniki sieciowe--------------------------------
                if (hit.transform.gameObject.name == "t1600g-52ts_tp-link")
                {
                    menuWidoki[9].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[3];
                }

                if (hit.transform.gameObject.name == "tl-sf1024_tp-link")
                {
                    menuWidoki[9].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[4];
                }

                if (hit.transform.gameObject.name == "tl-sg1048_tp-link")
                {
                    menuWidoki[9].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[5];
                }

                //-------------------------Serwery------------------------------------------
                if (hit.transform.gameObject.name == "poweredge_r240")
                {
                    menuWidoki[7].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[6];
                }

                if (hit.transform.gameObject.name == "poweredge_r540")
                {
                    menuWidoki[7].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[7];
                }

                if (hit.transform.gameObject.name == "proliant_dl160_gen10")
                {
                    menuWidoki[7].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[8];
                }

                if (hit.transform.gameObject.name == "proliant_dl380_gen10")
                {
                    menuWidoki[7].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[9];
                }

                //--------------------------Zasilacze UPS---------------------------------
                if (hit.transform.gameObject.name == "smt1500rmi2unc_apc_smart-ups_x")
                {
                    menuWidoki[10].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[10];
                }

                if (hit.transform.gameObject.name == "smx120bp")
                {
                    menuWidoki[10].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[11];
                }

                if (hit.transform.gameObject.name == "smx2200hv")
                {
                    menuWidoki[10].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wcisniety = true;
                    wybraneUrzadzenie = urzadzeniaSieciowe[12];
                }

                //=================================================================================

                //---------------------Widok wybor pola w ktorym ma sie nalezc urzadzenei--------------
                if (hit.transform.gameObject.name == "prawo2/4")
                {
                    menuWidoki[3].SetActive(false);
                    menuWidoki[4].SetActive(true);
                    wroc_do_menu.SetActive(true);
                    wroc_do_biblioteki.SetActive(true);
                    wcisniety = true;
                }

                if (hit.transform.gameObject.name == "prawo3/4")
                {
                    menuWidoki[4].SetActive(false);
                    menuWidoki[5].SetActive(true);
                    wroc_do_menu.SetActive(true);
                    wroc_do_biblioteki.SetActive(true);
                    wcisniety = true;
                }

                if (hit.transform.gameObject.name == "prawo4/4")
                {
                    menuWidoki[5].SetActive(false);
                    menuWidoki[6].SetActive(true);
                    wroc_do_menu.SetActive(true);
                    wroc_do_biblioteki.SetActive(true);
                    wcisniety = true;
                }

                if (hit.transform.gameObject.name == "lewo3/4")
                {
                    menuWidoki[6].SetActive(false);
                    menuWidoki[5].SetActive(true);
                    wroc_do_menu.SetActive(true);
                    wroc_do_biblioteki.SetActive(true);
                    wcisniety = true;
                }

                if (hit.transform.gameObject.name == "lewo2/4")
                {
                    menuWidoki[5].SetActive(false);
                    menuWidoki[4].SetActive(true);
                    wroc_do_menu.SetActive(true);
                    wroc_do_biblioteki.SetActive(true);
                    wcisniety = true;
                }

                if (hit.transform.gameObject.name == "lewo1/4")
                {
                    menuWidoki[4].SetActive(false);
                    menuWidoki[3].SetActive(true);
                    wroc_do_menu.SetActive(true);
                    wroc_do_biblioteki.SetActive(true);
                    wcisniety = true;
                }

                if (hit.transform.gameObject.name == "wyjdz")
                {
                    wcisniety = true;
                    Application.Quit();
                }

                //-----------------Wstawienie urzadzenia w wybrane pole---------------
                for (int i = 0; i < 42; ++i)
                {
                    //Wyłącza nam przyciski tych pol, ktore sa zajete   
                    if (ZajeteMiejsceWSzafie[i] != null)
                    {
                        Przyciski[i].SetActive(false);
                    }

                    if (ZajeteMiejsceWSzafie[i] == null)
                    {
                        //Debug.Log("Zwalniam numer: " + i + " " + ZajeteMiejsceWSzafie[i]);

                        Przyciski[i].SetActive(true);
                    }

                    if (hit.transform.gameObject.name == "" + i.ToString())
                    {
                        numerPolaWybranegoPrzyciskiem = i;

                        if (wybraneUrzadzenie != null && numerPolaWybranegoPrzyciskiem != -1)
                        {

                            //Sprawdzamy czy jest wystarczajaco miejsca zeby zmiescil sie element
                            if (numerPolaWybranegoPrzyciskiem > 40 || (WysokoscElementuWR(wybraneUrzadzenie) == 2 && ZajeteMiejsceWSzafie[numerPolaWybranegoPrzyciskiem + 1] != null))
                            {
                                //Debug.Log("Kolizja!");
                                error.SetActive(true);
                                foreach (GameObject widok in menuWidoki)
                                {
                                    widok.SetActive(false);
                                }
                            }
                            else if (numerPolaWybranegoPrzyciskiem > 39 || (WysokoscElementuWR(wybraneUrzadzenie) == 3 && (ZajeteMiejsceWSzafie[numerPolaWybranegoPrzyciskiem + 1] != null || ZajeteMiejsceWSzafie[numerPolaWybranegoPrzyciskiem + 2] != null)))
                            {
                                //Debug.Log("Kolizja!");
                                error.SetActive(true);
                                foreach (GameObject widok in menuWidoki)
                                {
                                    widok.SetActive(false);
                                }
                            }
                            else if (numerPolaWybranegoPrzyciskiem > 38 || (WysokoscElementuWR(wybraneUrzadzenie) == 4 && (ZajeteMiejsceWSzafie[numerPolaWybranegoPrzyciskiem + 1] != null || ZajeteMiejsceWSzafie[numerPolaWybranegoPrzyciskiem + 2] != null || ZajeteMiejsceWSzafie[numerPolaWybranegoPrzyciskiem + 3] != null)))
                            {
                                //Debug.Log("Kolizja!");
                                error.SetActive(true);
                                foreach (GameObject widok in menuWidoki)
                                {
                                    widok.SetActive(false);
                                }
                            }
                            else
                            {
                                UmiescElement(numerPolaWybranegoPrzyciskiem, wybraneUrzadzenie);
                                numerPolaWybranegoPrzyciskiem = -1;
                                wybraneUrzadzenie = null;

                                menuWidoki[3].SetActive(false);
                                menuWidoki[4].SetActive(false);
                                menuWidoki[5].SetActive(false);
                                menuWidoki[6].SetActive(false);

                                menuWidoki[2].SetActive(true);

                                wcisniety = true;

                            }

                        }
                    }
                }

                //================================================================================

                //-----------------Wstawienie urzadzenia w wybrane pole wybranego w szafie---------------
                /*                for (int i = 0; i < 42; ++i)
                                {

                                    string NameGameObject = "pole_0" + i.ToString();
                                    GameObject uchwyt = GameObject.Find(NameGameObject);


                                    if (hit.transform.gameObject.name == "pole_0" + i.ToString())
                                    {
                                        numerPolaWybranegoPrzyciskiem = i;

                                        if (wybraneUrzadzenie != null && numerPolaWybranegoPrzyciskiem != -1)
                                        {
                                            UmiescElement(numerPolaWybranegoPrzyciskiem, wybraneUrzadzenie);
                                            numerPolaWybranegoPrzyciskiem = -1;
                                            wybraneUrzadzenie = null;

                                            menuWidoki[3].SetActive(false);
                                            menuWidoki[4].SetActive(false);
                                            menuWidoki[5].SetActive(false);
                                            menuWidoki[6].SetActive(false);

                                            menuWidoki[2].SetActive(true);

                                            wcisniety = true;
                                        }


                                    }
                                }
                */
                //================================================================================


                //Usuwanie elementow po kliknieciu na element
                if (trybUsuwania == true)
                {

                    for (int m = 0; m < ZajeteMiejsceWSzafie.Length; ++m)
                    {
                        if (hit.transform.gameObject.name == ZajeteMiejsceWSzafie[m])
                        {

                            ZajeteMiejsceWSzafie[m] = null;
                            wcisniety = true;


                            //Przyciski[m].SetActive(true);

                        }
                        //Debug.Log(m + " : " + ZajeteMiejsceWSzafie[m]);
                    }

                    for (int m = 0; m < urzadzeniaZainicjalizowane.Count; ++m)
                    {
                        if (hit.transform.gameObject.name == urzadzeniaZainicjalizowane[m].name)
                        {
                            urzadzeniaZainicjalizowane.RemoveAt(m);
                            //Debug.Log("Lista usun");
                            Destroy(GameObject.Find(hit.transform.gameObject.name));
                            k--;
                            wcisniety = true;
                            break;
                        }
                    }

                }



                //Debug.Log("Klikniety element: " + hit.transform.gameObject.name);


            }
        }

        if (wcisniety == true && controller.TriggerValue == 0.0f)
        {
            wcisniety = false;
        }


        /* //-----Proba zrobienia podswietlenia-----
         if (controller.TriggerValue < 0.9f)
         {

             RaycastHit hit;
             if (Physics.Raycast(controllerInput.transform.position, controllerInput.transform.forward, out hit))
             {



                 *//*for (int i = 0; i < 42; ++i)
                 {

                     if (hit.transform.gameObject.name == "pole_0" + i.ToString())
                     {

                         string NameGameObject = "pole_0" + i.ToString();
                         uchwyt = GameObject.Find(NameGameObject);
                         uchwyt.GetComponent<Renderer>().material.color = Color.green;
                         Debug.Log(NameGameObject);
                     }
                     else
                     {
                         if (uchwyt != null)
                             uchwyt.GetComponent<Renderer>().material.color = Color.red;
                     }
                 }
 */
        /*
            }

        }
*/
        ////////

        /*        if (Input.GetKeyDown(KeyCode.A))
                {
                    foreach (GameObject element in elements)
                    {
                        element.SetActive(true);
                    }
                }

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    foreach (GameObject element in elements)
                    {
                        element.SetActive(false);

                    }
                }*/

        /*        foreach (String el in ZajeteMiejsceWSzafie)
                {
                    Debug.Log(el);
                }*/
    }

    public void UmiescElement(int numerpola, GameObject komponent)
    {
        int numerPolaOdZera = numerpola;
        numerpola--;
        komponent.name += "_" + k;
        urzadzeniaZainicjalizowane.Add(Instantiate(komponent, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(270, 90, 0)));
        //Debug.Log("nazwa urzadzenai w liscie: " + urzadzeniaZainicjalizowane[k].name);

        int LiczbaZajetychMiejsc = 0;
        //Ustawienie obiektu w odpowiedni sposob czyli dolna krawedz rowna sie dolenj krawedzi pustego pola
        if (urzadzeniaZainicjalizowane[k].GetComponent<BoxCollider>().bounds.extents.y < 0.02222502f && urzadzeniaZainicjalizowane[k].GetComponent<BoxCollider>().bounds.extents.y > 0.0f)
        {
            Vector3 switchShift = new Vector3(pustePole[numerpola].transform.position.x, pustePole[numerpola].transform.position.y, pustePole[numerpola].transform.position.z);
            urzadzeniaZainicjalizowane[k].transform.position += switchShift;
            switchShift = new Vector3(0.0f, -0.02222502f, urzadzeniaZainicjalizowane[k].GetComponent<BoxCollider>().bounds.extents.z);
            urzadzeniaZainicjalizowane[k].transform.position += switchShift;
            LiczbaZajetychMiejsc = 1;

        }
        else if (urzadzeniaZainicjalizowane[k].GetComponent<BoxCollider>().bounds.extents.y < 0.04445002f && urzadzeniaZainicjalizowane[k].GetComponent<BoxCollider>().bounds.extents.y > 0.02222501f)
        {
            Vector3 switchShift = new Vector3(pustePole[numerpola].transform.position.x, pustePole[numerpola].transform.position.y, pustePole[numerpola].transform.position.z);
            urzadzeniaZainicjalizowane[k].transform.position += switchShift;
            switchShift = new Vector3(0.0f, -0.02222502f, urzadzeniaZainicjalizowane[k].GetComponent<BoxCollider>().bounds.extents.z);
            urzadzeniaZainicjalizowane[k].transform.position += switchShift;
            LiczbaZajetychMiejsc = 2;
        }
        else if (urzadzeniaZainicjalizowane[k].GetComponent<BoxCollider>().bounds.extents.y < 0.06667502f && urzadzeniaZainicjalizowane[k].GetComponent<BoxCollider>().bounds.extents.y > 0.04445001f)
        {
            Vector3 switchShift = new Vector3(pustePole[numerpola].transform.position.x, pustePole[numerpola].transform.position.y, pustePole[numerpola].transform.position.z);
            urzadzeniaZainicjalizowane[k].transform.position += switchShift;
            switchShift = new Vector3(0.0f, -0.02222502f, urzadzeniaZainicjalizowane[k].GetComponent<BoxCollider>().bounds.extents.z);
            urzadzeniaZainicjalizowane[k].transform.position += switchShift;
            LiczbaZajetychMiejsc = 3;
        }
        else
        {
            Vector3 switchShift = new Vector3(pustePole[numerpola].transform.position.x, pustePole[numerpola].transform.position.y, pustePole[numerpola].transform.position.z);
            urzadzeniaZainicjalizowane[k].transform.position += switchShift;
            switchShift = new Vector3(0.0f, -0.02222502f, urzadzeniaZainicjalizowane[k].GetComponent<BoxCollider>().bounds.extents.z);
            urzadzeniaZainicjalizowane[k].transform.position += switchShift;
            LiczbaZajetychMiejsc = 4;
        }


        for (int i = 0; i < LiczbaZajetychMiejsc; ++i)
        {
            ZajeteMiejsceWSzafie[numerPolaOdZera + i] = urzadzeniaZainicjalizowane[k].name;
        }

        k++;
    }

    public int WysokoscElementuWR(GameObject wybranyelement)
    {
        int rozmiar = 0;

        GameObject GO1 = Instantiate(wybranyelement, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(270, 90, 0));
        //Debug.Log("Nazwa: " + GO1.name +" "+ GO1.GetComponent<BoxCollider>().bounds.extents.y);

        if (GO1.GetComponent<BoxCollider>().bounds.extents.y < 0.02222502f && GO1.GetComponent<BoxCollider>().bounds.extents.y > 0.0f)
        {
            rozmiar = 1;
        }
        else if (GO1.GetComponent<BoxCollider>().bounds.extents.y < 0.04445002f && GO1.GetComponent<BoxCollider>().bounds.extents.y > 0.02222501f)
        {
            rozmiar = 2;
        }
        else if (GO1.GetComponent<BoxCollider>().bounds.extents.y < 0.06667502f && GO1.GetComponent<BoxCollider>().bounds.extents.y > 0.04445001f)
        {
            rozmiar = 3;
        }
        else
        {
            rozmiar = 4;
        }

        Destroy(GO1);

        return rozmiar;

    }

    public void UkryjMenu()
    {
        foreach (GameObject widok in menuWidoki)
        {
            widok.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        MLInput.Stop();
    }
}
