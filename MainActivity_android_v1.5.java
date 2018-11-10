import java.util.Random;
import java.awt.event.*;
//import java.awt.event;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import java.awt.Color;
import java.awt.*;


public class MainActivity extends JFrame{

	private JPanel jp;
	private JButton [][] map;
	private JButton btn1;
	private JButton btn2;
	private SelectionSet Selection;
	private JButton[] buttons;
	//private TextView tv2;


	public MainActivity(){
	
		super("Tutorial - Bryan");
		setSize(400,300); //10248768, 800*600
		setResizable(true);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setLocationRelativeTo(null);

	        jp = new JPanel();
		map = new JButton[5][5];
		btn1 = new JButton("Shuffle"); 
		Selection = new SelectionSet();
		buttons = new JButton[25];

		getContentPane().setBackground(Color.YELLOW);
		getContentPane().add(jp);
	}

	public static void main(String[] args) {

		//new MainActivity().setVisible(true);
		MainActivity t = new MainActivity();
		t.setVisible(true);
		t.startIt();

	}


        protected void startIt() {
      	        jp.setLayout(new FlowLayout());

		for (int x=0; x<25; x++){ //smebaj changed it to one loop only smebaj 091118
			buttons[x]= new JButton("btn " + x);
			jp.add(buttons[x]);
		}
		

		for (int i=0; i<5; i++) {
			for (int j=0; j<5; j++) {
				map[i][j] = buttons[j+i*5];
				final int indexI = i;
				final int indexJ = j;
		    	}
		}

		jp.setBounds(60,400,220,30);
		jp.setBackground(Color.RED);
		btn1.setBackground(Color.BLACK);

		btn1.addActionListener(new ActionListener() {
			@Override
		    	public void actionPerformed(ActionEvent v) {
		    		clearButtons();
				StartRandom(2);
				StartRandom(1);
				StartRandom(1);
		    	}
		});

		jp.setVisible(true);
		btn1.setVisible(true);
		jp.add(btn1);
		add(jp);
	    }

	    public void clearButtons() {

		    for (int i=0; i<25; i++) {
			    buttons[i].setBackground(Color.WHITE);
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
						    ((JButton) buttons[listX[i]+listY[i]*5]).setBackground(Color.GRAY);
						    //map[listX[i]+listY[i]*10].Checked=true;
						    break;
					    case 2:
						    ((JButton) buttons[listX[i]+listY[i]*5]).setBackground(Color.RED);
						    //map[listX[i]+listY[i]*10].Checked=true;
						    break;
					    case 3:
						    buttons[listX[i]+listY[i]*5].setBackground(Color.YELLOW);
						    //checkBoxs[listX[i]+listY[i]*10].Checked=true;
						    break;
					    case 4:
						    buttons[listX[i]+listY[i]*5].setBackground(Color.BLUE);
						    //checkBoxs[listX[i]+listY[i]*10].Checked=true;
						    break;

					    case 5:
						    buttons[listX[i]+listY[i]*5].setBackground(Color.GREEN);
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
