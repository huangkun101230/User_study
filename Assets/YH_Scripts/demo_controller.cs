using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

public class demo_controller : MonoBehaviour
{
    public Texture2D fig_1_final_2_2;
    public Texture2D fig_1_final_30;
    public Texture2D fig_1_final_60;
    public Texture2D fig_1_final_90;
    public Texture2D fig_1_final_whole;

    public Texture2D fig_2_final_2_2;
    public Texture2D fig_2_final_30;
    public Texture2D fig_2_final_60;
    public Texture2D fig_2_final_90;
    public Texture2D fig_2_final_whole;

    public Texture2D fig_3_final_2_2;
    public Texture2D fig_3_final_30;
    public Texture2D fig_3_final_60;
    public Texture2D fig_3_final_90;
    public Texture2D fig_3_final_whole;

    public Texture2D fig_4_final_2_2;
    public Texture2D fig_4_final_30;
    public Texture2D fig_4_final_60;
    public Texture2D fig_4_final_90;
    public Texture2D fig_4_final_whole;

    public Texture2D fig_5_final_2_2;
    public Texture2D fig_5_final_30;
    public Texture2D fig_5_final_60;
    public Texture2D fig_5_final_90;
    public Texture2D fig_5_final_whole;

    public Texture2D fig_6_final_2_2;
    public Texture2D fig_6_final_30;
    public Texture2D fig_6_final_60;
    public Texture2D fig_6_final_90;
    public Texture2D fig_6_final_whole;

    public Dictionary<int, Texture2D> fig1;
    public Dictionary<int, Texture2D> fig2;
    public Dictionary<int, Texture2D> fig3;
    public Dictionary<int, Texture2D> fig4;
    public Dictionary<int, Texture2D> fig5;
    public Dictionary<int, Texture2D> fig6;

    public Dictionary<int, Dictionary<int, Texture2D>> schema;
    private int fig_number;
    private int current_image_number;

    public Material mat;

    public String file_name;


    // Start is called before the first frame update
    void Start()
    {
        fig_number = 1;
        current_image_number = 1;

        fig1 = new Dictionary<int, Texture2D>();
        fig2 = new Dictionary<int, Texture2D>();
        fig3 = new Dictionary<int, Texture2D>();
        fig4 = new Dictionary<int, Texture2D>();
        fig5 = new Dictionary<int, Texture2D>();
        fig6 = new Dictionary<int, Texture2D>();
        schema = new Dictionary<int, Dictionary<int, Texture2D>>();

        // schema
        fig1.Add(1, fig_1_final_2_2);
        fig1.Add(2, fig_1_final_30);
        fig1.Add(3, fig_1_final_60);
        fig1.Add(4, fig_1_final_90);
        fig1.Add(5, fig_1_final_whole);

        fig2.Add(1, fig_2_final_2_2);
        fig2.Add(2, fig_2_final_30);
        fig2.Add(3, fig_2_final_60);
        fig2.Add(4, fig_2_final_90);
        fig2.Add(5, fig_2_final_whole);

        fig3.Add(1, fig_3_final_2_2);
        fig3.Add(2, fig_3_final_30);
        fig3.Add(3, fig_3_final_60);
        fig3.Add(4, fig_3_final_90);
        fig3.Add(5, fig_3_final_whole);

        fig4.Add(1, fig_4_final_2_2);
        fig4.Add(2, fig_4_final_30);
        fig4.Add(3, fig_4_final_60);
        fig4.Add(4, fig_4_final_90);
        fig4.Add(5, fig_4_final_whole);

        fig5.Add(1, fig_5_final_2_2);
        fig5.Add(2, fig_5_final_30);
        fig5.Add(3, fig_5_final_60);
        fig5.Add(4, fig_5_final_90);
        fig5.Add(5, fig_5_final_whole);

        fig6.Add(1, fig_6_final_2_2);
        fig6.Add(2, fig_6_final_30);
        fig6.Add(3, fig_6_final_60);
        fig6.Add(4, fig_6_final_90);
        fig6.Add(5, fig_6_final_whole);

        schema.Add(1, fig1);
        schema.Add(2, fig2);
        schema.Add(3, fig3);
        schema.Add(4, fig4);
        schema.Add(5, fig5);
        schema.Add(6, fig6);

        right_key_pressed = false;
        left_key_pressed = false;

        generate_random_list();

       // clean_save_data();

        mat.mainTexture = schema[fig_number][random_to_sorted[current_image_number]];
        RenderSettings.skybox = mat;

    }

    // Update is called once per frame

    private bool right_key_pressed;
    private bool left_key_pressed;

    private Dictionary<int, int> random_to_sorted; // key: random index, value: image index

    void generate_random_list()
    {
        List<int> random_list = new List<int>();
        random_to_sorted = new Dictionary<int, int>();

        random_list.Add(1);
        random_list.Add(2);
        random_list.Add(3);
        random_list.Add(4);
        random_list.Add(5);

        for (int i = 0; i < 5; i++)
        {
            int random_index = UnityEngine.Random.Range(0, 5 - i);
            int temp = random_list[i];
            random_list[i] = random_list[i + random_index];
            random_list[i + random_index] = temp;

        }

        for (int i = 0; i < 5; i++)
        {
            random_to_sorted.Add(random_list[i], i + 1);
        }
        // String debug_string = random_list[0].ToString() + " " + random_list[1].ToString() + " " + random_list[2].ToString() + " " + random_list[3].ToString() + " " + random_list[4].ToString();
        // Debug.Log(debug_string);
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
            
       // }

        // if (Input.GetKey(KeyCode.DownArrow))

        if (Input.GetKey(KeyCode.RightArrow) && !right_key_pressed)
        {
            current_image_number++;
            current_image_number = Mathf.Clamp(current_image_number, 1, 5);


            mat.mainTexture = schema[fig_number][random_to_sorted[current_image_number]];
            RenderSettings.skybox = mat;
            right_key_pressed = true;
        }
        
        if (!Input.GetKey(KeyCode.RightArrow) && right_key_pressed)
        {
            right_key_pressed = false;
        }
                    
        if (Input.GetKey(KeyCode.LeftArrow) && !left_key_pressed)
        {
            current_image_number--;
            current_image_number = Mathf.Clamp(current_image_number, 1, 5);


            mat.mainTexture = schema[fig_number][random_to_sorted[current_image_number]];
            RenderSettings.skybox = mat;
            left_key_pressed = true;
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && left_key_pressed)
        {
            left_key_pressed = false;
        }
   
    }

    /*
    private int rank_A;
    private int rank_B;
    private int rank_C;
    private int rank_D;
    private int rank_E;
    private int best_index;
    private int worst_index;
    private bool is_good;

    void clean_save_data()
    {
        rank_A = -1;
        rank_B = -1;
        rank_C = -1;
        rank_D = -1;
        rank_E = -1;

        best_index = -1;
        worst_index = -1;
        is_good = false;
    }
    */

    void OnGUI()
    {
        if (GUILayout.Button("Next Scene"))
        {
            // first: save
            // String file_name = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
            String saving_file_name = file_name + "_" + fig_number.ToString() + ".txt";

            String content = "";// =  + ",";
            for (int i = 1; i <= 5; i++)
            {
                content += i.ToString() + "->" + random_to_sorted[i].ToString() + ",";
            }


            /*
            String content = fig_number.ToString() + ",";
            content += (is_good ? "1" : "0") + ",";
            content += best_index + ",";
            content += worst_index + ",";
            content += random_to_sorted[rank_A].ToString() + ",";
            content += random_to_sorted[rank_B].ToString() + ",";
            content += random_to_sorted[rank_C].ToString() + ",";
            content += random_to_sorted[rank_D].ToString() + ",";
            content += random_to_sorted[rank_E].ToString();
            */

            StreamWriter writer = new StreamWriter(saving_file_name, true);
            writer.WriteLine(content);
            writer.Close();


            // then clean data and re-generate random list

            generate_random_list();

            // finally go to next scene
            if (fig_number <= 6) fig_number++;
            if (fig_number == 7) fig_number = 1;

            current_image_number = 1;

            mat.mainTexture = schema[fig_number][random_to_sorted[current_image_number]];
            RenderSettings.skybox = mat;
        }

        //if ((GUILayout.Button("is best?"))) { best_index = current_image_number; }
        //if ((GUILayout.Button("is worst?"))) { worst_index = current_image_number; }
        //if (!is_good && GUILayout.Button("is good?")) { is_good = true;}
        //if (is_good && GUILayout.Button("is bad")) { is_good = false; }
        //if (rank_A == -1 && GUILayout.Button("set rank A")) { rank_A = current_image_number; }
        //if (rank_B == -1 && GUILayout.Button("set rank B")) { rank_B = current_image_number; }
        //if (rank_C == -1 && GUILayout.Button("set rank C")) { rank_C = current_image_number; }
        //if (rank_D == -1 && GUILayout.Button("set rank D")) { rank_D = current_image_number; }
        //if (rank_E == -1 && GUILayout.Button("set rank E")) { rank_E = current_image_number; }
        //if (GUILayout.Button("reset rank")) { rank_A = -1; rank_B = -1; rank_C = -1; rank_D = -1; rank_E = -1; }

        //GUI.Box(new Rect(0, Screen.height / 2     , 100, 20), "is good? " + (is_good ? "Yes" : "No"));
        //GUI.Box(new Rect(0, Screen.height / 2 + 20, 100, 20), "rank_A index : "  + rank_A.ToString());
        //GUI.Box(new Rect(0, Screen.height / 2 + 40, 100, 20), "rank_B index : " + rank_B.ToString());
        //GUI.Box(new Rect(0, Screen.height / 2 + 60, 100, 20), "rank_C index : " + rank_C.ToString());
        //GUI.Box(new Rect(0, Screen.height / 2 + 80, 100, 20), "rank_D index : " + rank_D.ToString());
        //GUI.Box(new Rect(0, Screen.height / 2 + 100, 100, 20), "rank_E index : " + rank_E.ToString());
        //GUI.Box(new Rect(0, Screen.height / 2 + 120, 100, 20), "best index : " + best_index.ToString());
        //GUI.Box(new Rect(0, Screen.height / 2 + 140, 100, 20), "worst index : " + worst_index.ToString());


        GUI.Box(new Rect(Screen.width - 100, 0, 100, 20), fig_number.ToString() + " index:" + current_image_number.ToString() + " real:" + random_to_sorted[current_image_number].ToString());

        gameObject.GetComponent<TextMesh>().text = fig_number.ToString() + "-" + current_image_number.ToString();
    }


}
