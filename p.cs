using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data.DataSetExtensions;
using System.Data.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;


namespace CSCI370Project1
{
public class CSCI370Project1Form : Form
{
	public CSCI370Project1Form()
	{
		InitializeComponent();
	}

	private void Form1_Load(object sender, EventArgs e)
	{

	}

	private void clickSavePlayer_Select(object sender, EventArgs e) // smebaj new
	{
		this.playerName = this.playerNameTextBox.Text;
		this.playerNameForm.Hide();
		FrameContext fc = new FrameContext(); //tho it should have been named Project2Context;
		TblPlayer p = new TblPlayer();
		p.frame_fk=this.playerId2;
		p.playerScore = int.Parse(this.textBox1.Text);
		p.playerName = this.playerName;
		fc.player.InsertOnSubmit(p);
		fc.SubmitChanges();
	}

	private void clickHighScoreToolStripMenuItem_Select(object sender, EventArgs e) // smebaj new
	{
		String res="";
		this.highScoreForm = new Form();
		RichTextBox ta = new RichTextBox();
		ta.Dock = DockStyle.Fill;
		ta.BackColor = Color.Pink;
		Panel p = new Panel();
		p.Dock = DockStyle.Fill;
		p.Controls.Add(ta);
		this.highScoreForm.Controls.Add(p);

		FrameContext fc = new FrameContext();
		var selectedData = (
                        from value in fc.player
			orderby value.playerScore descending
                        select new {value.playerScore, value.playerName});
                if (selectedData.Any())
			 foreach ( var element in selectedData )
			 {
				 res+= element + "\n";
			 }
		ta.Text=res;
		highScoreForm.Show();

	}
	private void clickStartToolStripMenuItem_Select(object sender, EventArgs e) // smebaj new
	{
		//################################## first tab initial load ################################################/
		//################################## first tab initial load ################################################/
		if (this.Started==false)
		{
			


			//################################## battleship location panel ################################################/
			this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1.BorderStyle = BorderStyle.FixedSingle;
			this.panel1.BackColor = Color.White;
			this.panel1.Visible=false;
			this.label1 = new System.Windows.Forms.Label();

			this.checkBoxs = new System.Windows.Forms.CheckBox[100];
			this.Selection = new SelectionSet();
			this.imageList = new System.Windows.Forms.ImageList();
			this.imageList.Images.Add(new System.Drawing.Icon("C:\\bjarmak\\Projects\\univ\\liu\\application\\project\\unchecked.ico"));
			this.imageList.Images.Add(new System.Drawing.Icon("C:\\bjarmak\\Projects\\univ\\liu\\application\\project\\checked_1.ico"));
			this.imageList.Images.Add(new System.Drawing.Icon("C:\\bjarmak\\Projects\\univ\\liu\\application\\project\\checked_2.ico"));
			this.imageList.Images.Add(new System.Drawing.Icon("C:\\bjarmak\\Projects\\univ\\liu\\application\\project\\checked_3.ico"));
			this.imageList.Images.Add(new System.Drawing.Icon("C:\\bjarmak\\Projects\\univ\\liu\\application\\project\\checked_4.ico"));
			int i;
			int j;
			string RangeName="";
			for (i=0; i < 10; i++)
			{
				for (j=0; j < 10; j++)
				{
				int temp = 10*i + j;
				this.checkBoxs[temp] = new System.Windows.Forms.CheckBox();
				this.checkBoxs[temp].AutoSize=false;
				this.checkBoxs[temp].ImageList = this.imageList;
				this.checkBoxs[temp].Appearance=Appearance.Button;
				this.checkBoxs[temp].TextImageRelation = TextImageRelation.ImageBeforeText;
				this.checkBoxs[temp].ImageIndex=0;
				this.checkBoxs[temp].ImageAlign= System.Drawing.ContentAlignment.MiddleCenter; 
				this.checkBoxs[temp].FlatStyle = FlatStyle.Flat;
				this.checkBoxs[temp].FlatAppearance.BorderSize=0;
				this.checkBoxs[temp].Padding= new System.Windows.Forms.Padding(0);
				this.checkBoxs[temp].AutoSize=true;
				this.checkBoxs[temp].BackColor=Color.Blue;
				this.checkBoxs[temp].FlatAppearance.MouseOverBackColor=Color.Transparent;
				this.checkBoxs[temp].Name=j+"#"+i;
				this.checkBoxs[temp].AutoCheck=false;

				this.panel1.Controls.Add(this.checkBoxs[temp]);
				this.panel1.Padding=new System.Windows.Forms.Padding(0);
				this.panel1.Dock=DockStyle.Fill;
				this.panel1.BackColor= System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
				this.checkBoxs[temp].CheckedChanged += new System.EventHandler(this.clickCheckBoxs_CheckedChanged);
				}
			}
			this.panel1.Visible=true;

			this.tabPanel1 = new TabControl();
			this.tabPage1 = new TabPage();
			this.tabPanel1.Size = new System.Drawing.Size(308,317);
			this.tabPanel1.Dock = DockStyle.Bottom;
			//this.tabPanel1.Width=308;
			//this.tabPanel1.Padding= new System.Windows.Forms.Padding(30);
			this.tabPage1.Dock=DockStyle.Fill;
			this.tabPage1.Text="My BattleShip location";




			//################################## battleship index and score panel ################################################/

			this.panel2 = new System.Windows.Forms.Panel();
			this.pictureBoxs = new System.Windows.Forms.PictureBox[4];
			this.labels1 = new System.Windows.Forms.Label[4];
			this.labels2 = new System.Windows.Forms.Label[4];
			for (int t=0; t<4; t++) // indexes
			{
				int tmp=t+1;
				this.pictureBoxs[t]=new System.Windows.Forms.PictureBox();
				this.labels1[t]=new System.Windows.Forms.Label();
				this.labels2[t]=new System.Windows.Forms.Label();
				this.pictureBoxs[t].Name=t+"";
				//this.pictureBoxs[t].AutoSize = true;
				this.pictureBoxs[t].Height = 16;
				this.pictureBoxs[t].SizeMode=PictureBoxSizeMode.StretchImage;
				this.pictureBoxs[t].Image = Image.FromFile("C:\\bjarmak\\Projects\\univ\\liu\\application\\project\\pic_"+tmp+".jpg");
				this.labels1[t].Font = new Font("Verdana", 9);
				this.labels2[t].Font = new Font("Verdana", 8);
				this.pictureBoxs[t].Location = new System.Drawing.Point(95,85+20*t);
				this.labels1[t].Location = new System.Drawing.Point(5,85+20*t);
				this.labels2[t].Location = new System.Drawing.Point(195,85+20*t);
				this.panel2.Controls.Add(this.pictureBoxs[t]);
				this.panel2.Controls.Add(this.labels1[t]);
				this.panel2.Controls.Add(this.labels2[t]);
			}

			this.pictureBoxs[0].Width = 100;
			this.pictureBoxs[1].Width = 80;
			this.pictureBoxs[2].Width = 60;
			this.pictureBoxs[3].Width = 40;
			this.labels1[0].Text ="BATTLESHIP";
			this.labels2[0].Text ="10 points";
			this.labels1[1].Text ="CRUISER";
			this.labels2[1].Text ="7 points";
			this.labels1[2].Text ="DESTROYER";
			this.labels2[2].Text ="5 points";
			this.labels1[3].Text ="SUBMARINE";
			this.labels2[3].Text ="3 point";
	
			//this.panel2.Size = new System.Drawing.Size(150,300);
			this.panel2.Location = new System.Drawing.Point(310,20);
			this.panel2.BorderStyle=BorderStyle.FixedSingle;
			this.panel2.Dock = DockStyle.Right;
			this.panel2.Width=250;
			//this.panel2.Width= 50;
			this.label2 = new System.Windows.Forms.Label();
			this.label2.Text ="SCORE RESULTS";
			//this.label2.Dock=DockStyle.Fill;
			//this.label2.Padding = new System.Windows.Forms.Padding(0);
			this.label2.Location = new System.Drawing.Point(30,210);
			this.label2.Font = new Font("Verdana", 16);
			this.label2.Width=200;
			this.label2.Height=40;
			this.label2.Font = new Font(this.label2.Font, FontStyle.Underline);
			this.label2.Visible=false;
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.playerId2=0;
			this.playerName="empty";
			//this.textBox1.Multiline=true;
			this.panel2.BackColor=System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(94)))));
			//this.textBox1.Dock = DockStyle.Fill;
			this.textBox1.Text = "0";
			//this.textBox1.Dock=DockStyle.Fill;
			//this.textBox1.Padding = new System.Windows.Forms.Padding(0);
			this.textBox1.Location = new System.Drawing.Point(90,250);
			this.textBox1.Height = 25;
			this.textBox1.Width = 60;
			this.textBox1.TextAlign = HorizontalAlignment.Center;
			this.textBox1.BackColor=System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(44)))));
			this.textBox1.Font = new Font("Sans-Calibiri", 22);
			this.textBox1.Font = new Font(this.textBox1.Font, FontStyle.Bold);
			this.textBox1.ForeColor=System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(81)))), ((int)(((byte)(240)))));
			this.textBox1.ReadOnly=true;
			this.textBox1.Visible=false;

			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox2.BackColor=System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(94)))));
			this.textBox2.ForeColor=Color.LightGray;
			this.textBox2.Font = new Font("Sans-Serif",12);
			this.textBox2.Font = new Font(this.textBox2.Font,FontStyle.Italic);
			this.textBox2.Text = "Remaining hits: " + this.Hit;
			this.textBox2.TextAlign = HorizontalAlignment.Center;
			this.textBox2.Location = new System.Drawing.Point(23,294);
			this.textBox2.Width = 200;
			this.textBox2.Height = 15;
			this.textBox2.BorderStyle=BorderStyle.None;
			this.textBox2.Visible=false;

			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.textBox1);
			this.panel2.Controls.Add(this.textBox2);
		//	this.tabPanel1.Position = new System.Drawing.Point(8,17);
			//this.tabPanel1.Alignment= TabAlignment.Bottom;
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage2.Dock=DockStyle.Fill;
			this.tabPage2.Text="Enemy";
			this.tabPanel1.Controls.Add(this.tabPage1);
			this.tabPanel1.Controls.Add(this.tabPage2);
			this.tabPage1.Controls.Add(this.panel1);
			this.Controls.Remove(this.panelWelcome); //removing after loading
			this.Controls.Add(this.tabPanel1);
			this.Controls.Add(this.panel2);
			this.Started=true;
		}
		else
		{
		}

		//################################## first tab values re-set ################################################/
		//################################## first tab values re-set ################################################/

		
		this.tabPanel1.SelectedTab = tabPanel1.TabPages[0];
		this.textBox2.Visible=false;//hide on consecutive plays
		this.textBox1.Visible=false;
		this.label2.Visible=false;
		this.Hit=5; //setting the hit
		this.textBox1.Text="0";
		Selection.ClearSelection();
		for (int k=0;k<100;k++)
		{

			checkBoxs[k].BackColor=Color.Blue;
			checkBoxs[k].ImageIndex=0;
			checkBoxs[k].Checked=false;
		}

		this.StartRandom(5);

		this.StartRandom(4);

		this.StartRandom(3);

		this.StartRandom(2);	
		this.StartRandom(2);	
		

		//check if tab2 alread has a grid in it and remove it.

		//if (this.tabPage2.Controls[0]=null) // i think that null only exists in java
		if (this.tabPage2.HasChildren==false)
			Console.WriteLine("");
		else
		{
			this.tabPage2.Controls.Remove(this.panel3);
			this.textBox2.ForeColor = Color.LightGray;
			this.textBox2.Text="Remaining hits: " + this.Hit;
			this.tabPage1.Controls.Add(this.panel1);	
		}




	}


	public void StartRandom(int size)
	{
		//it's actually x but line cld be either hor or ver	
		bool drawn=false;
		Hit=5; //setting the hit
		Random R = new Random();
		int x0;
		int y0;
		int pnt;

		while (drawn == false)
		{
			x0 = R.Next(1,9);
			y0 = R.Next(1,9);
			pnt = x0 + y0*10;
			int direction =R.Next(0,2); //has to be ran once
			int leftRight =R.Next(0,2); //has to be ran once
			Console.WriteLine("start.random.var.initial.point=" + pnt);
		        Console.WriteLine("start.random.var.initial.point.coordinates=[" + x0 +"," +y0 + "]");
			drawn=DrawLine(pnt,size,direction,x0,y0,leftRight);
		}
		Console.WriteLine("\ndone");
		Selection.PrintSel();
	}


	public bool DrawLine(int pnt, int size, int direction, int x0, int y0, int leftRight) //leftrightupdown
	{
		int step=1;
		bool drawn=false;
		int X=0;
		int Y=0;
		int[] listX = new int[size];
		int[] listY = new int[size];
		listX[0]=x0;
		listY[0]=y0;
		int condition=0;
		Console.WriteLine("DrawLine.intialization");

		switch (leftRight)
		{
			case 0:
				break;
			case 1:
				step=-step;
				break;

		}

		for (int i=1; i<size; i++)
		{
			if (direction==0)
			{
					listX[i] = listX[0] + (i)*step;
					listY[i] = listY[0];
			}
			else
			{
					listY[i] = listY[0] + (i)*step; //was +size
					listX[i] = listX[0];
			}
			Console.WriteLine("building.random.line /i=" + i + " /direction=" + direction + " /leftRight=" + leftRight + " /[x0,y0]=" +listX[0]+","+listY[0] + " /Size=" + size + " /arraySize=" + listX.Length + " /[Xi,Yi]=[" + listX[i] + "," + listY[i] + "]");
		}

		
		drawn=Selection.CheckLineCoord(listX,listY,step);

		if (drawn==true)
		{
			Console.WriteLine("attempting to draw");
			for (int i=0; i<size; i++)
			{
				Console.WriteLine("\nDrawLine.drawing..\n" + listX[i] +"," +listY[i]);
				Selection.AutoAddSelectionWithValue(listX[i],listY[i],size);
				switch (size) 
				{
					case 2:
						checkBoxs[listX[i]+listY[i]*10].ImageIndex=1;
						checkBoxs[listX[i]+listY[i]*10].Checked=true;
						break;
					case 3:
						checkBoxs[listX[i]+listY[i]*10].ImageIndex=2;
						checkBoxs[listX[i]+listY[i]*10].Checked=true;
						break;
					case 4:
						checkBoxs[listX[i]+listY[i]*10].ImageIndex=3;
						checkBoxs[listX[i]+listY[i]*10].Checked=true;
						break;
					case 5:
						checkBoxs[listX[i]+listY[i]*10].ImageIndex=4;
						checkBoxs[listX[i]+listY[i]*10].Checked=true;
						break;
				}
				//clickCheckBoxs_CheckedChanged(checkBoxs[listX[i]+listY[i]*10], new EventArgs());
			}
			Selection.PrintSel();
			Console.WriteLine("drawn");
		}
		return drawn;
	}

	private void clickCheckBoxs_CheckedChanged(object sender, EventArgs e)
	{
		if 	(((CheckBox)sender).Checked ^ false )
			((CheckBox)sender).BackColor=Color.Brown;

		else
			((CheckBox)sender).BackColor=Color.Blue;


		//((CheckBox)sender).ImageIndex=1;
	}

	private void clickCheckBoxs2_CheckedChanged(object sender, EventArgs e) //to be commmented out
	{
		if 	(((CheckBox)sender).Checked ^ false )
		{
			//((CheckBox)sender).ImageIndex=1;
			((CheckBox)sender).BackColor=Color.Brown;
		}
		else
		{
			((CheckBox)sender).BackColor=Color.Blue;
			Selection.PrintSel();
		}

	}





	private void selectCell_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) // smebaj play
	{
		//MessageBox.Show("sender"+sender);
		//MessageBox.Show("row indx: "+e.RowIndex.ToString());
		//MessageBox.Show("column indx: "+e.ColumnIndex.ToString());
		int x = int.Parse(e.RowIndex.ToString());
		int y = int.Parse(e.ColumnIndex.ToString());
		int ClickValue=Selection.UpdateScore(y,x);


		switch (ClickValue)
		{
			case 0:
				this.textBox2.Text = "Slash";
				this.panel3.Rows[x].Cells[y].Value="O";
				this.panel3.Rows[x].Cells[y].Style.ForeColor=Color.White;
				this.panel3.Rows[x].Cells[y].Style.BackColor=Color.Gray;
				this.panel3.Rows[x].Cells[y].Style.Alignment=DataGridViewContentAlignment.MiddleCenter;
				this.panel3.Rows[x].Cells[y].Style.Font= new Font("Verdona", 12);
				//System.Threading.Thread.Sleep(1000);
				break;
			default:
				this.textBox2.Text = "Hit";
				this.panel3.Rows[x].Cells[y].Value="X";
				textBox1.Text=((int.Parse(textBox1.Text))+ClickValue).ToString(); // this is the score
				this.panel3.Rows[x].Cells[y].Style.BackColor=Color.Gray;
				this.panel3.Rows[x].Cells[y].Style.ForeColor=Color.Red;
				this.panel3.Rows[x].Cells[y].Style.Font= new Font("Verdona", 16);
				//this.panel3.Rows[x].Cells[y].DataGridViewCellStyle.Alignment=DataGridViewCellAlignment.Center;
				this.panel3.Rows[x].Cells[y].Style.Alignment=DataGridViewContentAlignment.MiddleCenter;
				System.Media.SoundPlayer player= new System.Media.SoundPlayer("C:\\bjarmak\\Projects\\univ\\liu\\application\\project\\boom.wav");
				player.Play();//System.Media.SystemSounds.Hand.Play();//.Asterisk.
				//System.Threading.Thread.Sleep(1000);
				break;
		}
		

		if (this.Hit>1)
		{
			this.Hit=this.Hit - 1;
			this.textBox2.Text = "Remaining hits: " + this.Hit;

		}
		else
		{
			this.textBox2.Text = "Game Over";
			this.textBox2.ForeColor = Color.Red;
			this.tabPage2.Enabled=false;
			this.tabPage1.Controls.Add(this.panel1);
			System.Media.SoundPlayer player= new System.Media.SoundPlayer("C:\\bjarmak\\Projects\\univ\\liu\\application\\project\\game_over.wav");
			player.Play();//System.Media.SystemSounds.Hand.Play();//.Asterisk.
			//this.tabPanel1.SelectedTab = tabPanel1.TabPages[0];
			savePlay();
		}

	}

	private void clickCommitToolStripMenuItem_Select(object sender, EventArgs e) // smebaj game
	{



		//this.panel3=new System.Windows.Forms.FlowLayoutPanel();
		//this.panel3.CellBorderStyle=DataGridViewCellBorderStyle.None;
		//this.panel3.AutoSize=true;
		//this.DataGridViewAutoSizeColumnsMode=true;
		//this.panel3.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
		//this.panel3.Size=new System.Drawing.Size(200,200);
		//this.row.Height=15;
		//panel3.Columns[i]=new Column();
			//this.labels1[t].Font = new Font("Verdana", 9);
			/*for(int j=0;j<10;j++)
			{
				//panel3.Rows[i]=new Row();
				//panel3.Rows.Add(new string[] {"alo"});
				  panel3.Rows[j]="alo";
				//panel3.Rows[j].Name=i+10*j;
				//panel3.Rows[j].DoubleClicked += new System.EventHandler(this.clickRow_Selected);
			}*/
			//this.checkBoxs[temp].CheckedChanged += new System.EventHandler(this.clickCheckBoxs_CheckedChanged);
		//this.tabPage2.Enabled=false;
		/*for (int i=0; i < 10; i++)
		{
			//CellBorderStyle
			for (int j=0; j < 10; j++)
			{
			int temp = 10*i + j;
			this.checkBoxs2[temp] = new System.Windows.Forms.CheckBox();
			this.checkBoxs2[temp].AutoSize=false;
			//this.checkBoxs2[temp].ImageList = this.imageList;
			this.checkBoxs2[temp].Appearance=Appearance.Button;
			this.checkBoxs2[temp].TextImageRelation = TextImageRelation.ImageBeforeText;
			this.checkBoxs2[temp].ImageIndex=0;
			this.checkBoxs2[temp].ImageAlign= System.Drawing.ContentAlignment.MiddleCenter; 
			this.checkBoxs2[temp].FlatStyle = FlatStyle.Flat;
			this.checkBoxs2[temp].FlatAppearance.BorderSize=0;
			this.checkBoxs2[temp].Padding= new System.Windows.Forms.Padding(0);
			this.checkBoxs2[temp].AutoSize=true;
			this.checkBoxs2[temp].BackColor=Color.Blue;
			this.checkBoxs2[temp].FlatAppearance.MouseOverBackColor=Color.Transparent;
			this.checkBoxs2[temp].Name=j+"#"+i;
			this.checkBoxs2[temp].AutoCheck=false;

			this.panel3.Controls.Add(this.checkBoxs2[temp]);
			this.panel3.Padding=new System.Windows.Forms.Padding(0);
			this.panel3.Dock=DockStyle.Fill;
			this.panel3.BackColor= System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
			this.checkBoxs2[temp].CheckedChanged += new System.EventHandler(this.clickCheckBoxs2_CheckedChanged);
			}
		}*/
		//this.Controls.Clear();
		//this.panel1.Controls.Clear();
		//this.panel3=this.panel1;
		//this.tabPage2.Enabled=true;
		//this.tabPage2.Controls.Add(this.panel3);
		//this.tabPage2.Focus();
		//this.Controls.Add(this.panel1);
		//this.Controls.Add(this.menuStrip1);
		//this.clickStartToolStripMenuItem_Select(this,new EventArgs());

		
		this.panel3=new System.Windows.Forms.DataGridView();
		this.panel3.ColumnCount=10;
		this.panel3.Padding=new System.Windows.Forms.Padding(0);
		this.panel3.Dock=DockStyle.Fill;
		this.panel3.BackColor= System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
		this.panel3.AllowUserToResizeColumns=false;
		this.panel3.AllowUserToResizeRows=false;
		this.panel3.DefaultCellStyle.WrapMode=DataGridViewTriState.True;
		this.panel3.AlternatingRowsDefaultCellStyle.BackColor=Color.Beige;
		this.panel3.ColumnHeadersVisible=false;
		this.panel3.RowHeadersVisible=false;
		this.row = this.panel3.RowTemplate;
		this.row.DefaultCellStyle.WrapMode=DataGridViewTriState.True;
		this.row.DefaultCellStyle.BackColor=Color.Bisque;
		this.row.DefaultCellStyle.ForeColor=Color.Bisque;
		this.row.Height=27;
		for (int i=0; i< 10; i++)
		{
		panel3.Rows.Add(new string[] {"?","?","?","?","?","?","?","?","?","?"});
		panel3.Columns[i].Width=27;
		panel3.Columns[i].ReadOnly=true;
		}
		this.panel3.CellContentDoubleClick +=new System.Windows.Forms.DataGridViewCellEventHandler(this.selectCell_CellContentDoubleClick);
		this.checkBoxs2 = new System.Windows.Forms.CheckBox[100];
		this.tabPage2.Controls.Add(this.panel3);

		this.tabPage2.Enabled=true; //smebaj used in consecutive game plays
		Selection.CommitDefenderSelection();
		this.tabPage1.Controls.Remove(this.panel1);
		// take the enemy name
		this.textBox1.Visible=true;
		this.textBox2.Visible=true;
		this.label2.Visible=true;
		
		this.tabPanel1.SelectedTab = tabPanel1.TabPages[1];
		
	
		//get array
		//int pid = int.Parse(this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[0].Value.ToString());
		Console.WriteLine("accessing array");
		for (int i = 0; i < 10; i ++)
		{
			FrameContext fc = new FrameContext();
			TblFrame f = new TblFrame();
			f.frameId=1;
			f.array_y=i;
			f.array_x0=this.Selection.Sel[0,i];
			f.array_x1=this.Selection.Sel[1,i];
			f.array_x2=this.Selection.Sel[2,i];
			f.array_x3=this.Selection.Sel[3,i];
			f.array_x4=this.Selection.Sel[4,i];
			f.array_x5=this.Selection.Sel[5,i];
			f.array_x6=this.Selection.Sel[6,i];
			f.array_x7=this.Selection.Sel[7,i];
			f.array_x8=this.Selection.Sel[8,i];
			f.array_x9=this.Selection.Sel[9,i];
			fc.frame.InsertOnSubmit(f);
			fc.SubmitChanges();
		}
		//get id number to link it later to player id
		
		FrameContext fcc = new FrameContext();
		var res = (
                        from value in fcc.frame
                        select new {value.frameId} );

                Console.WriteLine("printing from DB");
                if (res.Any())
                        Console.WriteLine("max ID=" + res.Max(x=>x.frameId)); //eventhou count would work, but autoincrement is not always starting from 0
		this.playerId2 = res.Max(x=>x.frameId) - 9;

	}


	public void savePlay() {
		this.playerNameForm = new System.Windows.Forms.Form();
		System.Windows.Forms.FlowLayoutPanel thePanel = new System.Windows.Forms.FlowLayoutPanel();
		this.playerNameForm.Controls.Add(thePanel);
		thePanel.Dock = DockStyle.Fill;
		Button b = new Button();
		b.Text="enter";

		playerNameTextBox = new TextBox();
		Label l = new Label();
		l.Text="Please enter your name";
		thePanel.Controls.Add(l);
		thePanel.Controls.Add(this.playerNameTextBox);
		thePanel.Controls.Add(b);
		this.playerNameForm.Show();
		b.Click += new System.EventHandler(this.clickSavePlayer_Select);

	}


	private System.ComponentModel.IContainer components = null;
	protected override void Dispose(bool disposing)
	{
		if (disposing && ( components != null ) )
		{
			components.Dispose();
		}
		base.Dispose( disposing );
	}

	private void InitializeComponent() // smebaj start
	{
		this.Started = false;
		this.Hit = 5; // setting the hit
		this.button1 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		this.button1.Dock = DockStyle.Top;
		this.button1.AutoSize=false;
		this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.button1.BackColor = Color.Gray;
		this.button1.ForeColor = Color.Red;
		this.button1.Name = "clickButton";
		this.button1.Size = new System.Drawing.Size(60, 40);
		this.button1.TabIndex = 1;
		this.button1.TabStop = false;
		this.button1.Text = "play";

		this.openToolStripMenuItem = new ToolStripMenuItem();
		this.fileToolStripMenuItem = new ToolStripMenuItem();
		this.highScoreToolStripMenuItem = new ToolStripMenuItem();
		this.saveAsToolStripMenuItem = new ToolStripMenuItem();
		this.exitToolStripMenuItem = new ToolStripMenuItem();    
		this.playToolStripMenuItem = new ToolStripMenuItem();
    		this.commitToolStripMenuItem = new ToolStripMenuItem();
		this.startToolStripMenuItem = new ToolStripMenuItem();
		this.toolStripSeparator1 = new ToolStripSeparator();
		this.toolStripSeparator2 = new ToolStripSeparator();
		fileToolStripMenuItem.DropDownItems.AddRange
			(
        			new ToolStripItem[] 
				{
		          		openToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, highScoreToolStripMenuItem, exitToolStripMenuItem
				}
			);
		playToolStripMenuItem.DropDownItems.AddRange
			(
		        	new ToolStripItem[] 
				{
          				commitToolStripMenuItem, toolStripSeparator2, startToolStripMenuItem
				}
			);

		this.fileToolStripMenuItem.Text = "&File";
		this.saveAsToolStripMenuItem.Text = "Save &as..";
		this.highScoreToolStripMenuItem.Text = "HIGH SCORES";
		this.exitToolStripMenuItem.Text = "E&xit";    
		this.playToolStripMenuItem.Text = "&Play";
		this.commitToolStripMenuItem.Text = "c&ommit";
		this.startToolStripMenuItem.Text = "S&tart new game";
		this.openToolStripMenuItem.Text = "&Open";
		
		this.menuStrip1 = new MenuStrip();
		//this.menuStrip1.Dock=DockStyle.Top;
		menuStrip1.Items.Add(fileToolStripMenuItem);
		menuStrip1.Items.Add(playToolStripMenuItem);
		this.panelWelcome = new System.Windows.Forms.Panel();
		this.panelWelcome.Dock=DockStyle.Fill;
		this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
		this.pictureBoxWelcome.Dock=DockStyle.Fill;
		this.pictureBoxWelcome.Image=Image.FromFile("C:\\bjarmak\\Projects\\univ\\liu\\application\\project\\welcome.jpg");
		this.pictureBoxWelcome.SizeMode=PictureBoxSizeMode.StretchImage;
		this.panelWelcome.Controls.Add(this.pictureBoxWelcome);
		
		this.Controls.Add(this.menuStrip1);
		this.Controls.Add(this.panelWelcome);

		this.Name = "Form1";
		this.Text = "# BattleShip Game 2";

		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
		this.ClientSize = new System.Drawing.Size(550,340);//was 308,317
		this.StartPosition = FormStartPosition.CenterScreen;
		this.MaximizeBox=false;
		this.FormBorderStyle=FormBorderStyle.FixedSingle; //smebaj to disable resize

		this.Load += new System.EventHandler(this.Form1_Load);
		this.startToolStripMenuItem.Click += new System.EventHandler(this.clickStartToolStripMenuItem_Select);
		this.highScoreToolStripMenuItem.Click += new System.EventHandler(this.clickHighScoreToolStripMenuItem_Select);
		this.commitToolStripMenuItem.Click += new System.EventHandler(this.clickCommitToolStripMenuItem_Select);

		this.ResumeLayout(false);
		this.BackColor = Color.Gray;
	}

	private bool Started;
	private int Hit;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.FlowLayoutPanel panel1;
	private System.Windows.Forms.Panel panel2;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.CheckBox[] checkBoxs;
	private System.Windows.Forms.Button button;
	private System.Windows.Forms.ImageList imageList;
	private MenuStrip menuStrip1;
	private ToolStripMenuItem fileToolStripMenuItem, openToolStripMenuItem, saveAsToolStripMenuItem, exitToolStripMenuItem,
		playToolStripMenuItem, commitToolStripMenuItem, startToolStripMenuItem, highScoreToolStripMenuItem;
  	private ToolStripSeparator toolStripSeparator1, toolStripSeparator2;
	private SelectionSet Selection;
	private TabControl tabPanel1;
	private TabPage tabPage1;
	private TabPage tabPage2;
	private TextBox textBox1;
	private int playerId2;
	private String playerName;
	private Form playerNameForm;
	private TextBox playerNameTextBox;
	private Form highScoreForm;
	private PictureBox[] pictureBoxs;
	private Label[] labels1;
	private Label[] labels2;
	private System.Windows.Forms.DataGridView panel3;
	private System.Windows.Forms.DataGridViewRow row;
	private System.Windows.Forms.CheckBox[] checkBoxs2;
	private System.Windows.Forms.Panel panelWelcome;
	private PictureBox pictureBoxWelcome;
	private TextBox textBox2;

}




static class Program
{
	[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


	[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


	[STAThread]
		static void Main(string[] args)
		{
			Console.Title = "MyConsoleApp";
			if (args.Length > 0) 
			{
				if (args[0].StartsWith("-w"))
				{
					setConsoleWindowVisibility(false, Console.Title);
	
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault( false );
					Application.Run( new CSCI370Project1Form());
				}
			}
			else
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault( false );
				Application.Run( new CSCI370Project1Form());
			}
		}

			public static void setConsoleWindowVisibility(bool visible, string title)
			{
				IntPtr hWnd = FindWindow(null, title);

				if(hWnd != IntPtr.Zero)
				{
					if(!visible)
						ShowWindow(hWnd, 0); //0 = SW_HIDE
					else
						ShowWindow(hWnd, 1); //0 = SW_SHOWNORMA
				}
			}
}


[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="project2")]
public class FrameContext : System.Data.Linq.DataContext {

	private const string ConnectionString = @"server=.;Initial Catalog=project2;integrated security=true";
	private static System.Data.IDbConnection Icon = new System.Data.SqlClient.SqlConnection(ConnectionString);
	public FrameContext(): base(Icon){
	}
		
	public System.Data.Linq.Table<TblFrame> frame {
		get {
			return this.GetTable<TblFrame>();
		}
	}

	public System.Data.Linq.Table<TblPlayer> player {
		get {
			return this.GetTable<TblPlayer>();
		}
	}
}




[System.Data.Linq.Mapping.Table(Name = "[project2].[dbo].frame")] 
public class TblFrame
{
	[System.Data.Linq.Mapping.Column(DbType = "int not null", IsPrimaryKey = true, IsDbGenerated=true)]
	public int frameId {get; set;} 

	[System.Data.Linq.Mapping.Column]
	public int array_y {get; set;}

	[System.Data.Linq.Mapping.Column]
	public int array_x0 {get; set;}

	[System.Data.Linq.Mapping.Column]
	public int array_x1 {get; set;}

	[System.Data.Linq.Mapping.Column]
	public int array_x2 {get; set;}

	[System.Data.Linq.Mapping.Column]
	public int array_x3 {get; set;}

	[System.Data.Linq.Mapping.Column]
	public int array_x4 {get; set;}

	[System.Data.Linq.Mapping.Column]
	public int array_x5 {get; set;}

	[System.Data.Linq.Mapping.Column]
	public int array_x6 {get; set;}

	[System.Data.Linq.Mapping.Column]
	public int array_x7 {get; set;}

	[System.Data.Linq.Mapping.Column]
	public int array_x8 {get; set;}

	[System.Data.Linq.Mapping.Column]
	public int array_x9 {get; set;}

	[System.Data.Linq.Mapping.Column(DbType = "int null")]
	public int gameFK {get; set;}

}

[System.Data.Linq.Mapping.Table(Name = "[project2].[dbo].player")] 
public class TblPlayer
{
	[System.Data.Linq.Mapping.Column(DbType = "int not null", IsPrimaryKey = true, IsDbGenerated=true)]
	public int playerId {get; set;} 

	[System.Data.Linq.Mapping.Column]
	public int frame_fk {get; set;}

	[System.Data.Linq.Mapping.Column]
	public int playerScore {get; set;}

	[System.Data.Linq.Mapping.Column(DbType = "VarChar(50) null")]
	public string playerName {get; set;}
}

public class SelectionSet {

	public int[,] Sel;
	public int[,] Def;
	private int[,] Att;

	public SelectionSet(){
			Sel = new int[10,10];
			Def = new int[10,10];
			Att = new int[10,10];
	}

	public void PrintSel(){
		for (int i = 0; i < 10; i++) 
		{
            for (int j = 0; j < 10; j++) 
						{
                Console.Write(Sel[j,i]+"\t");
            }
                Console.WriteLine();
		}
	}

	public int UpdateScore(int x,int y)
	{

		return Def[x,y];
	}

	public void AddSelection(string Ranges)
	{
		int[] RangesSplit = Ranges.Split('#').Select(int.Parse).ToArray();
		Console.Clear();
		Sel[RangesSplit[0],RangesSplit[1]-1]=1;
	}

	public void ClearSelection()
	{
		this.Sel = new int[10,10];
	}

	public void AutoAddSelection(int x, int y)
	{
		Sel[x,y]=1;
	}

	public void AutoAddSelectionWithValue(int x, int y, int size)
	{
		switch (size)
		{
			case 2:
				Sel[x,y]=3;
				break;
			case 3:
				Sel[x,y]=5;
				break;
			case 4:
				Sel[x,y]=7;
				break;
			case 5:
				Sel[x,y]=10;
				break;
		}
	}

	public void RemoveSelection(string Ranges)
	{
		int[] RangesSplit = Ranges.Split('#').Select(int.Parse).ToArray();
		Console.Clear();
		Sel[RangesSplit[0],RangesSplit[1]-1]=0;
	}

	public void CommitDefenderSelection()
	{
			Def = Sel;
			//Sel = new int[10,10];
	}

	public bool CheckCoord(int x, int y, int x0, int y0)
	{
		Console.WriteLine("checkcoord.taking.parameters: [" + x + "," + y + "]"); 
		Console.WriteLine("checkcoord.points.check: down=[" + Sel[x,y-1] + "], up=[" + Sel[x,y+1] + "], left=[" + Sel[x-1,y] +
				"], right=[" + Sel[x+1,y] + "], and exception=[" + Sel[x0,y0] + "]"); 
		if (               ( Sel[x,(y-1)%10]==0 || Sel[x,(y-1)%10]==Sel[x0,y0] )
				&& ( Sel[x,(y+1)%10]==0 || Sel[x,(y+1)%10]==Sel[x0,y0] )
				&& ( Sel[(x+1)%10,y]==0 || Sel[(x+1)%10,y]==Sel[x0,y0] ) 
				&& ( Sel[(x-1)%10,y]==0 || Sel[(x-1)%10,y]==Sel[x0,y0] )   )
		{
			Console.WriteLine("checkcoord.return=true");
			return true;
		}
		else
		{
			Console.WriteLine("checkcoord.return=true");
			return false;
		}
	}
	public bool CheckCoord(int pnt)
	{
		int x=pnt%10;
		int y=(pnt-x)/10;
		if (Sel[x,y-1]==0 && Sel[x,y+1]==0 && Sel[x,y]==0 && Sel[x+1,y]==0 && Sel[x-1,y]==0)
			return true;
		else
			return false;
	}

	public bool CheckLineCoord(int[] listX, int[] listY, int step)
	{
		bool Checked=true;
		string debug="";
		int tempListY0Value=listY[0];
		bool vertical=false;
		for (int i=0; i<listX.Length; i++)
		{
			if (tempListY0Value==listY[i]) // was ==listX[i]
			{
				Console.WriteLine("its vertical");
				vertical=true;
			}
			else
			{
			}
		}
		for (int i=0; i<listX.Length; i++)
		{
			if ( 8<listX[i] || listX[i]<1 || 9<listY[i] || listY[i]<1)
			{
				Checked=false;
			}
		}

		if (Checked==false)
		{
			Console.WriteLine("no need to continue");
			//MessageBox.Show("no need to continue");
		}
		else
		{

		switch (vertical) //looks like prob here as in its unreachable
		{
			case true:
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("vertical line");
				for (int i=0;i<listX.Length;i++)
				{	
					if (Sel[listX[i],listY[i]]==0 )
					{
					Console.WriteLine("confirmed current point is empty");
						if (listX[0] == 0)
						{
							Console.WriteLine("Stacked to the left");
							if (Sel[listX[i]+1,listY[i]]==0 )
							{
								if ( listY[0]==0 ||  listY[0]==9 ) //was both Y
								{
									Console.WriteLine("Starting from top or bottom");
									if (Sel[listX[i]+1,listY[listY.Length-1]+step]==0 && Sel[listX[i],listY[listY.Length-1]+step]==0  )
										Console.WriteLine("");
									else
									{
										Checked=false;
									}
								}
								else if ( listY[listY.Length-1]==0 || listY[listY.Length-1]==9 )
								{
									Console.WriteLine("Ending at top or bottom");
									if (Sel[listX[i]+1,listY[0]-step]==0 && Sel[listX[i],listY[0]-step]==0  )
										Console.WriteLine("");
									else
									{
										Checked=false;
									}
								}
								else
								{
									Console.WriteLine("Regular");
									if (Sel[listX[i]+1,listY[listY.Length-1]+step]==0 && Sel[listX[i],listY[listY.Length-1]+step]==0 && Sel[listX[i]+1,listY[0]-step]==0 && Sel[listX[i],listY[0]-step]==0  )
										Console.WriteLine("");
									else
									{
										Checked=false;
									}
								}
							}
							else
							{
								Checked=false;
							}
						}
						else if (listX[0] == 9)
						{
							Console.WriteLine("Stacked to the right");
							if (Sel[listX[i]-1,listY[i]]==0 )
							{
								if ( listY[0]==0 ||  listY[0]==9 )
								{
									Console.WriteLine("Starting from top or bottom");
									if (Sel[listX[i]-1,listY[listY.Length-1]+step]==0 && Sel[listX[i],listY[listY.Length-1]+step]==0  )
										Console.WriteLine("");
									else
										Checked=false;
								}
								else if ( listY[listY.Length-1]==0 || listY[listY.Length-1]==9 )
								{
									Console.WriteLine("Ending at top or bottom");
									if (Sel[listX[i]-1,listY[0]-step]==0 && Sel[listX[i],listY[0]-step]==0  )
										Console.WriteLine("");
									else
										Checked=false;
								}
								else
								{
									Console.WriteLine("Regular");
									if (Sel[listX[i]-1,listY[listY.Length-1]+step]==0 && Sel[listX[i],listY[listY.Length-1]+step]==0 && Sel[listX[i]-1,listY[0]-step]==0 && Sel[listX[i],listY[0]-step]==0  )
										Console.WriteLine("");
									else
										Checked=false;
								}
							}
							else
								Checked=false;
						}
						else
						{
							if (Sel[listX[i]-1,listY[i]]==0 && Sel[listX[i]+1,listY[i]]==0  )
							{
								//MessageBox.Show("reached line nbr: 874");
								if ( listY[0]==0 ||  listY[0]==9 )
								{
									Console.WriteLine("Starting from top or bottom");
									if (Sel[listX[i]-1,listY[listY.Length-1]+step]==0 && Sel[listX[i],listY[listY.Length-1]+step]==0  && Sel[listX[i]+1,listY[listY.Length-1]+step]==0  )
										Console.WriteLine("");
									else
									{
										Checked=false;
										debug="not stacked";
									}
								}
								else if ( listY[listY.Length-1]==0 || listY[listY.Length-1]==9 )
								{
									Console.WriteLine("Ending at top or bottom");
									if (Sel[listX[i]-1,listY[0]-step]==0 )
									{
										//MessageBox.Show("p1 fine");
										if (  Sel[listX[i],listY[0]-step]==0 ) 
										{
										//MessageBox.Show("p2 fine");
											if (Sel[listX[i]+1,listY[0]-step]==0) 
												Console.WriteLine("");
											//MessageBox.Show("p3 fine");
										}
									}

									else
										Checked=false;
								}
								else
								{
									Console.WriteLine("Regular");
									if (Sel[listX[i]-1,listY[listY.Length-1]+step]==0 && Sel[listX[i],listY[listY.Length-1]+step]==0 && Sel[listX[i]-1,listY[0]-step]==0 && Sel[listX[i],listY[0]-step]==0 && Sel[listX[i]+1,listY[0]-step]==0  && Sel[listX[i]+1,listY[listY.Length-1]+step]==0 )
										Console.WriteLine("");
									else
										Checked=false;
								}
							}
							else
								Checked=false;
						}

					}
					else
						Checked=false;
					Console.WriteLine("coord.p"+i+" at debug level: " + debug);
				}
				break;
			case false:
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("horizontal line");
				for (int i=0;i<listX.Length;i++)
				{	
					Console.WriteLine("new loop - checking current point is empty - horizontal line - x is fixed");
					if (Sel[listX[i],listY[i]]==0 )
					{
					Console.WriteLine("confirmed current point is empty");
						if (listY[0] == 0)
						{
							Console.WriteLine("Stacked to the top");
							if (Sel[listX[i],listY[i]+1]==0 )
							{
								if ( listX[0]==0 ||  listX[0]==9 )
								{
									Console.WriteLine("Starting from left or right");
									if (Sel[listX[listX.Length-1]+step,listY[i]+1]==0 && Sel[listX[listX.Length-1]+step,listY[i]]==0  )
										Console.WriteLine("");
									else
										Checked=false;
								}
								else if ( listX[listX.Length-1]==0 || listX[listX.Length-1]==9 )
								{
									Console.WriteLine("ending at left or right");
									if (Sel[listX[0]-step,listY[i]+1]==0 && Sel[listX[0]-step,listY[i]]==0  )
										Console.WriteLine("");
									else
										Checked=false;
								}
								else
								{
									Console.WriteLine("regular");
									if (Sel[listX[0]-step,listY[i]+1]==0 && Sel[listX[0]-step,listY[i]]==0 && Sel[listX[listX.Length-1]+step,listY[i]+1]==0 && Sel[listX[listX.Length-1]+step,listY[i]]==0  )
										Console.WriteLine("");
									else
										Checked=false;
								}
							}
							else
								Checked=false;
						}
						else if (listY[0] == 9)
						{
							Console.WriteLine("Stacked to the bottom");
							if (Sel[listX[i],listY[i]-1]==0 )
							{
								if ( listX[0]==0 ||  listX[0]==9 )
								{
									Console.WriteLine("Starting from left or right");
									if (Sel[listX[listX.Length-1]+step,listY[i]-1]==0 && Sel[listX[listX.Length-1]+step,listY[i]]==0  )
										Console.WriteLine("");
									else
										Checked=false;
								}
								else if ( listX[listX.Length-1]==0 || listX[listX.Length-1]==9 )
								{
									Console.WriteLine("ending at left or right");
									if (Sel[listX[0]-step,listY[i]-1]==0 && Sel[listX[0]-step,listY[i]]==0  )
										Console.WriteLine("");
									else
										Checked=false;
								}
								else
								{
									Console.WriteLine("Regular");
									if (Sel[listX[0]-step,listY[i]-1]==0 && Sel[listX[0]-step,listY[i]]==0 && Sel[listX[listX.Length-1]+step,listY[i]-1]==0 && Sel[listX[listX.Length-1]+step,listY[i]]==0  )
										Console.WriteLine("");
									else
										Checked=false;
								}
							}
							else
								Checked=false;
						}
						else
						{
							if (Sel[listX[i],listY[i]-1]==0 && Sel[listX[i],listY[i]+1]==0   ) 
							{
								if ( listX[0]==0 ||  listX[0]==9 )
								{
									if (Sel[listX[listX.Length-1]+step,listY[i]-1]==0 && Sel[listX[listX.Length-1]+step,listY[i]]==0 && Sel[listX[listX.Length-1]+step,listY[i]+1]==0   )
										Console.WriteLine("");
									else
										Checked=false;
								}
								else if ( listX[listX.Length-1]==0 || listX[listX.Length-1]==9 )
								{
									if (Sel[listX[0]-step,listY[i]-1]==0 && Sel[listX[0]-step,listY[i]]==0  && Sel[listX[0]-step,listY[i]+1]==0  )
										Console.WriteLine("");
									else
										Checked=false;
								}
								else
								{
									//MessageBox.Show("problematic");
									if (Sel[listX[0]-step,listY[i]-1]==0 && Sel[listX[0]-step,listY[i]]==0 && Sel[listX[0]-step,listY[i]+1]==0 && Sel[listX[listX.Length-1]+step,listY[i]-1]==0 && Sel[listX[listX.Length-1]+step,listY[i]]==0 && Sel[listX[listX.Length-1]+step,listY[i]+1]==0 )
										Console.WriteLine("");
									else
										Checked=false;
								}
							}
							else
								Checked=false;
						}

					}
					else
						Checked=false;
					Console.WriteLine("coord.p"+i+" at debug level: " + debug);
				}
				break;
		}

		}//ending else

		//MessageBox.Show("returning: " + Checked);
		Console.WriteLine("coord.returned");
		return Checked;
	}


}
}
