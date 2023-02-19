using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;

    public static bool NewGame = true;
    int maxLvl = 5;

    [Header("Data Permainan")]
    public bool GameAktif;
    public bool GameSelesai;
    public bool SystemAcak;
    public int Target, DataSaatIni;
    public int DataLevel;
    public int DataScore, DataWaktu;

    [Header("Komponen UI")]
    public Text Text_Lvl;
    public Text Text_Time;
    public Text Text_Scr;

    [System.Serializable]

    public class DataGame
    {
        public string Nama;
        public Sprite Gambar;
    }

    [Header("Settingan Standar")]
    public DataGame[] DataPermainan;

    public Obj_TempatDrop[] Drop_Tempat;
    public Obj_Drag[] Drag_Obj;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameAktif = false;
        GameSelesai = false;
        ResetData();
        Target = Drop_Tempat.Length; 
        if (SystemAcak)
            AcakSoal();

        DataSaatIni = 0;
        GameAktif = true;
    }

    void ResetData()
    {
        if (NewGame)
        {
            NewGame = false;
            DataWaktu = 60 / 2;
            DataScore = 0;
            DataLevel = 0;
        }
    }

    // Update is called once per frame

    float s;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            AcakSoal();

        if (GameAktif)
        {
            if (DataWaktu > 0)
            {
                s += Time.deltaTime;
                if (s >= 1)
                {
                    DataWaktu--;
                    s = 0;
                }
            }
          //if (Data.DataWaktu <= 0)
////////////{
////////////////GameAktif = false;
////////////////GameSelesai = true;
////////////}

////////////if (DataSaatIni >= Target)
////////////{
////////////////GameSelesai = true;
////////////////GameAktif = false;

////////////////if (Data.DataLevel < (maxLvl - 1))
////////////////{
////////////////////Data.DataLevel++;
////////////////}
////////////}
        }

        SetInfoUI();
    }

    [HideInInspector]public List<int> _AcakSoal = new List<int>();
    [HideInInspector]public List<int> _AcakPos = new List<int>();
    int rand;
    int rand2;

    public void AcakSoal()
    {
        _AcakSoal.Clear();
        _AcakPos.Clear();

        _AcakSoal = new List<int>(new int[Drag_Obj.Length]);
        for (int i = 0; i < _AcakSoal.Count; i++)
        {
            rand = Random.Range(1, DataPermainan.Length);
            while (_AcakSoal.Contains(rand))
                rand = Random.Range(1, DataPermainan.Length);

            _AcakSoal[i] = rand;

            Drag_Obj[i].ID = rand-1;
            Drag_Obj[i].Teks.text = DataPermainan[rand-1].Nama;
        }

        _AcakPos = new List<int>(new int[Drop_Tempat.Length]);
        for (int i = 0; i < _AcakPos.Count; i++)
        {
            rand2 = Random.Range(1, _AcakSoal.Count+1);
            while (_AcakPos.Contains(rand2))
                rand2 = Random.Range(1, _AcakSoal.Count+1);

            _AcakPos[i] = rand2;

            Drop_Tempat[i].Drop.ID = _AcakSoal[rand2 - 1] - 1;
            Drop_Tempat[i].Gambar.sprite = DataPermainan[Drop_Tempat[i].Drop.ID].Gambar;
        }
    }

    public void SetInfoUI()
    {
        Text_Lvl.text = (DataLevel + 1).ToString();
        
        int Mnt = Mathf.FloorToInt(DataWaktu / 60);
        int Dtk = Mathf.FloorToInt(DataWaktu % 60);
        Text_Time.text = Mnt.ToString("00") + ":" + Dtk.ToString("00");

        Text_Scr.text = DataScore.ToString();


    }
}
