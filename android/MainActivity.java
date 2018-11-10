package com.csci410.liu.projectonevone;

import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Random;

public class MainActivity extends AppCompatActivity {


    private int [][] tempID = {{R.id.x0y0, R.id.x0y1, R.id.x0y2, R.id.x0y3, R.id.x0y4},
            {R.id.x1y0,R.id.x1y1,R.id.x1y2,R.id.x1y3,R.id.x1y4},
            {R.id.x2y0,R.id.x2y1,R.id.x2y2,R.id.x2y3,R.id.x2y4},
            {R.id.x3y0,R.id.x3y1,R.id.x3y2,R.id.x3y3,R.id.x3y4},
            {R.id.x4y0,R.id.x4y1,R.id.x4y2,R.id.x4y3,R.id.x4y4}
    };
    private int [] tempIDuni = {R.id.x0y0, R.id.x0y1, R.id.x0y2, R.id.x0y3, R.id.x0y4,
            R.id.x1y0,R.id.x1y1,R.id.x1y2,R.id.x1y3,R.id.x1y4,
            R.id.x2y0,R.id.x2y1,R.id.x2y2,R.id.x2y3,R.id.x2y4,
            R.id.x3y0,R.id.x3y1,R.id.x3y2,R.id.x3y3,R.id.x3y4,
            R.id.x4y0,R.id.x4y1,R.id.x4y2,R.id.x4y3,R.id.x4y4
    };
    private Button [][] map;
    private Button btn1;
    private Button btn2;
    private SelectionSet Selection;
    private Button[] buttons;

    //private TextView tv2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Selection = new SelectionSet();
        buttons = new Button[25];
        /*for (int x=0; x<5; x++){
            for (int y=0; y<5; y++) {
                //Toast.makeText(MainActivity.this, "id= " + tempID[x][y], Toast.LENGTH_SHORT).show();

                buttons[y+x*5]=(Button)findViewById(tempID[x][y]); //smebaj check here
            }
        }*/
        for (int x=0; x<25; x++) {
            buttons[x]=(Button)findViewById(tempIDuni[x]);
        }

        //int tempid= getResources().getIdentifier("Button","id",this.getApplicationContext().getPackageName());
        //Toast.makeText(MainActivity.this, "id= " + tempid, Toast.LENGTH_SHORT).show();

        map = new Button[5][5];
        for (int i=0; i<5; i++) {
            for (int j=0; j<5; j++) {


                //Toast.makeText(MainActivity.this, "id= " + tempid, Toast.LENGTH_SHORT).show();
                map[i][j] = (Button)findViewById(tempID[i][j]);
                //(map[i][j]).setBackgroundColor(Color.RED);
                final int indexI = i;
                final int indexJ = j;
                map[i][j].setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        //Toast.makeText(MainActivity.this, "id= " + tempid, Toast.LENGTH_SHORT).show();
                        //tv2 = (TextView)findViewById(R.id.tv2);
                        //tv2.setText("");
                        //tv2.setText(map[indexI][indexJ].toString());
                        //tv2.setText(((Button)(map[indexI][indexJ])).getText());
                    }
                });
            }
        }



        btn1 = (Button)findViewById(R.id.btn1);
        btn1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                clearButtons();
                StartRandom(2);
                StartRandom(1);
                StartRandom(1);
                //buttons[1].setBackgroundColor(Color.RED);


            }
        });


    }


    public void clearButtons() {

        for (int i=0; i<25; i++) {
            buttons[i].setBackgroundColor(Color.GRAY);
        }
        Selection.ClearSelection();
    }

    public void StartRandom(int size) {

        boolean drawn = false;
        Random Rand = new Random();
        int x0;
        int y0;
        int pnt;
        int tempCounter=0;
        while (drawn == false) {
            x0 = Rand.nextInt(5);
            y0 = Rand.nextInt(5);
            pnt = x0 + y0*5;
            int direction =Rand.nextInt(2); //has to be ran once
            int leftRight =Rand.nextInt(2); //has to be ran once
            drawn=DrawLine(pnt,size,direction,x0,y0,leftRight);
            tempCounter++;

        }

        Selection.PrintSel();

    }

    public boolean DrawLine(int pnt, int size, int direction, int x0, int y0, int leftRight) { /*leftrightupdown*/

        int step=1;
        boolean drawn=false;
        int X=0;
        int Y=0;
        int[] listX = new int[size];
        int[] listY = new int[size];
        listX[0]=x0;
        listY[0]=y0;
        int condition=0;

        switch (leftRight) {
            case 0:
                break;
            case 1:
                step=-step;
                break;
        }

        for (int i=1; i<size; i++) {
            if (direction==0) {
                listX[i] = listX[0] + (i)*step;
                listY[i] = listY[0];
            }
            else {
                listY[i] = listY[0] + (i)*step; //was +size
                listX[i] = listX[0];
            }

            //building random line
        }

        drawn=Selection.CheckLineCoord(listX,listY,step);

        if (drawn==true) {
            for (int i=0; i<size; i++) {
                Selection.AutoAddSelectionWithValue(listX[i],listY[i],size);
                switch (size) {
                    case 1: //added case 1 smebaj 091118
                        ((Button) buttons[listX[i]+listY[i]*5]).setBackgroundColor(Color.YELLOW);
                        //map[listX[i]+listY[i]*10].Checked=true;
                        break;
                    case 2:
                        ((Button) buttons[listX[i]+listY[i]*5]).setBackgroundColor(Color.RED);
                        //map[listX[i]+listY[i]*10].Checked=true;
                        break;
                    case 3:
                        buttons[listX[i]+listY[i]*5].setBackgroundColor(Color.TRANSPARENT);
                        //checkBoxs[listX[i]+listY[i]*10].Checked=true;
                        break;
                    case 4:
                        buttons[listX[i]+listY[i]*5].setBackgroundColor(Color.BLUE);
                        //checkBoxs[listX[i]+listY[i]*10].Checked=true;
                        break;

                    case 5:
                        buttons[listX[i]+listY[i]*5].setBackgroundColor(Color.GREEN);
                        //checkBoxs[listX[i]+listY[i]*10].Checked=true;
                        break;
                }
                //clickCheckBoxs_CheckedChanged(checkBoxs[listX[i]+listY[i]*10], new EventArgs());
            }

            Selection.PrintSel();


        }

        return drawn;

    }

}
