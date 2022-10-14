using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

public class demo_controller : MonoBehaviour
{
    // !!!IMPORTANT!!!: if you add a new test group, you need edit this number
    private const int total_fig_groups = 6;

    // !!!IMPORTANT!!!: if you add a new test group, you need create your new group name/oneoff/percolumn
    public String    fig_1_name;
    public Texture2D fig_1_oneoff;
    public Texture2D fig_1_percolumn;

    public String    fig_2_name;
    public Texture2D fig_2_oneoff;
    public Texture2D fig_2_percolumn;

    public String    fig_3_name;
    public Texture2D fig_3_oneoff;
    public Texture2D fig_3_percolumn;

    public String    fig_4_name;
    public Texture2D fig_4_oneoff;
    public Texture2D fig_4_percolumn;

    public String    fig_5_name;
    public Texture2D fig_5_oneoff;
    public Texture2D fig_5_percolumn;

    public String    fig_6_name;
    public Texture2D fig_6_oneoff;
    public Texture2D fig_6_percolumn;

    // !!!IMPORTANT!!!: if you add a new test group, you need create add the new Dictionary
    public Dictionary<int, Texture2D> fig1;
    public Dictionary<int, Texture2D> fig2;
    public Dictionary<int, Texture2D> fig3;
    public Dictionary<int, Texture2D> fig4;
    public Dictionary<int, Texture2D> fig5;
    public Dictionary<int, Texture2D> fig6;

    public Dictionary<int, Dictionary<int, Texture2D>> schema;
    public Dictionary<int, String> schema_fig_group_name;
    private int current_group_number;
    private int current_image_number;

    public Material mat;

    void Start()
    {
        current_group_number = 1;
        current_image_number = 1;

        // !!!IMPORTANT!!!: if you add a new test group, initialize it here
        fig1 = new Dictionary<int, Texture2D>();
        fig2 = new Dictionary<int, Texture2D>();
        fig3 = new Dictionary<int, Texture2D>();
        fig4 = new Dictionary<int, Texture2D>();
        fig5 = new Dictionary<int, Texture2D>();
        fig6 = new Dictionary<int, Texture2D>();

        schema = new Dictionary<int, Dictionary<int, Texture2D>>();
        schema_fig_group_name = new Dictionary<int, String>();

        // schema
        // !!!IMPORTANT!!!: if you add a new test group, add the two picture to the Dictionary, 1 MUST be oneoff and 2 MUST be per_column
        fig1.Add(1, fig_1_oneoff);
        fig1.Add(2, fig_1_percolumn);

        fig2.Add(1, fig_2_oneoff);
        fig2.Add(2, fig_2_percolumn);

        fig3.Add(1, fig_3_oneoff);
        fig3.Add(2, fig_3_percolumn);

        fig4.Add(1, fig_4_oneoff);
        fig4.Add(2, fig_4_percolumn);

        fig5.Add(1, fig_5_oneoff);
        fig5.Add(2, fig_5_percolumn);

        fig6.Add(1, fig_6_oneoff);
        fig6.Add(2, fig_6_percolumn);

        // !!!IMPORTANT!!!: if you add a new test group, add it to the schema here
        schema.Add(1, fig1);
        schema.Add(2, fig2);
        schema.Add(3, fig3);
        schema.Add(4, fig4);
        schema.Add(5, fig5);
        schema.Add(6, fig6);

        // !!!IMPORTANT!!!: if you add a new test group, add the name to the name sheet here
        schema_fig_group_name.Add(1, fig_1_name);
        schema_fig_group_name.Add(2, fig_2_name);
        schema_fig_group_name.Add(3, fig_3_name);
        schema_fig_group_name.Add(4, fig_4_name);
        schema_fig_group_name.Add(5, fig_5_name);
        schema_fig_group_name.Add(6, fig_6_name);

        right_key_pressed = false;
        left_key_pressed = false;

        generate_random_list();
        generate_random_group_order();

        mat.mainTexture = schema[random_to_sorted_for_group_order[current_group_number]][random_to_sorted[current_image_number]];
        RenderSettings.skybox = mat;

    }



    private bool right_key_pressed;
    private bool left_key_pressed;

    // key: random index, value: image index
    // note in 14th Oct: it is used for each picture in a group
    private Dictionary<int, int> random_to_sorted;

    // key: random index, value: group index
    // note in 14th Oct: it is used for group
    private Dictionary<int, int> random_to_sorted_for_group_order;

    void generate_random_list()
    {
        List<int> random_list = new List<int>();
        random_to_sorted = new Dictionary<int, int>();

        random_list.Add(1);
        random_list.Add(2);

        for (int i = 0; i < 2; i++)
        {
            int random_index = UnityEngine.Random.Range(0, 2 - i);
            int temp = random_list[i];
            random_list[i] = random_list[i + random_index];
            random_list[i + random_index] = temp;

        }

        for (int i = 0; i < 2; i++)
        {
            random_to_sorted.Add(random_list[i], i + 1);
        }
    }

    void generate_random_group_order()
    {
        List<int> random_list = new List<int>();
        random_to_sorted_for_group_order = new Dictionary<int, int>();

        for (int i = 1; i <= total_fig_groups; i++) {
            random_list.Add(i);
        }

        for (int i = 0; i < total_fig_groups; i++) {
            int random_index = UnityEngine.Random.Range(0, total_fig_groups - i);
            int temp = random_list[i];
            random_list[i] = random_list[i + random_index];
            random_list[i + random_index] = temp;
        }

        for (int i = 0; i < total_fig_groups; i++)
        {
            random_to_sorted_for_group_order.Add(random_list[i], i + 1);
        }
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) && !right_key_pressed)
        {
            current_image_number++;
            current_image_number = Mathf.Clamp(current_image_number, 1, 2);


            mat.mainTexture = schema[random_to_sorted_for_group_order[current_group_number]][random_to_sorted[current_image_number]];
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
            current_image_number = Mathf.Clamp(current_image_number, 1, 2);


            mat.mainTexture = schema[random_to_sorted_for_group_order[current_group_number]][random_to_sorted[current_image_number]];
            RenderSettings.skybox = mat;
            left_key_pressed = true;
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && left_key_pressed)
        {
            left_key_pressed = false;
        }
   
    }

    void OnGUI()
    {
        if (GUILayout.Button("Next Scene"))
        {
            // re-generate random list and go to next scene
            generate_random_list();
            if (current_group_number <= total_fig_groups) current_group_number++;

            // if current scene is the final one and jump the the new rounds, we need to generate a new group order for the new tester
            if (current_group_number == (total_fig_groups + 1)) {
                generate_random_group_order();
                current_group_number = 1;
            }

            current_image_number = 1;

            mat.mainTexture = schema[random_to_sorted_for_group_order[current_group_number]][random_to_sorted[current_image_number]];
            RenderSettings.skybox = mat;
        }

        GUI.Box(new Rect(Screen.width - 300, 0, 300, 30), current_group_number.ToString() + "/" + total_fig_groups.ToString() +" Scene name: " + schema_fig_group_name[random_to_sorted_for_group_order[current_group_number]]);
        GUI.Box(new Rect(Screen.width - 300, 30, 300, 30), "Image index: [" + current_image_number.ToString() + "] Read image: [" + (random_to_sorted[current_image_number] == 1 ? "oneoff]" : "percolumn]"));

        gameObject.GetComponent<TextMesh>().text = current_group_number.ToString() + "-" + current_image_number.ToString();
    }


}
