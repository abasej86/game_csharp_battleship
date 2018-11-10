public class SelectionSet {
	public int[][] Sel;
	public int[][] Def;
	private int[][] Att;
	int tempvar;
	public SelectionSet(){
		Sel = new int[5][5];
		Def = new int[5][5];
		Att = new int[5][5];
	}
	public void AutoAddSelectionWithValue(int x, int y, int size)
	{
		switch (size)
		{
			case 1: //added smebaj 091118
				Sel[x][y]=2; //eventhough this is a score. not required this way on mobile. Instead will simply back color the bottom.
			case 2:
				Sel[x][y]=3;
				break;
			case 3:
				Sel[x][y]=5;
				break;
			case 4:
				Sel[x][y]=7;
				break;
			case 5:
				Sel[x][y]=10;
				break;
		}
	}

	public void PrintSel(){ //added for debuggin smebaj 091118
		for (int i = 0; i < 5; i++){
	                for (int j = 0; j < 5; j++){
		                //System.out.print(Sel[j][i]+"\t");
            		}
                	//System.out.println();
		}
	}

	public void ClearSelection()
	{
		this.Sel = new int[5][5];
	}




	public boolean CheckLineCoord(int[] listX, int[] listY, int step)
	{
		boolean Checked=true;
		String debug="";
		int tempListY0Value=listY[0];
		boolean vertical=false;
		int verticalInt=0;
		for (int i=0; i<listX.length; i++)
		{
			if (tempListY0Value==listY[i]) // was ==listX[i]
			{
				tempvar=0;
				vertical=true;
				verticalInt=1;
			}
			else
			{
				verticalInt=2;
			}
		}
		for (int i=0; i<listX.length; i++) // smebaj 091118 below made it less than zero instead of one
		{
			if ( 3<listX[i] || listX[i]<1 || 4<listY[i] || listY[i]<1) //first was 8<listX[i] smebaj 091118 // made them both 3 now smebaj091118.
			{
				Checked=false;
			}
			if ( listX[0] == 2 ) { // added for our grid is only 5x5 to avoid endless loop -- smebaj 091118
				Checked=false;
			} 
		}
		if (Checked==false)
		{
			//no need to continue
		}
		else
		{
			switch (verticalInt) //looks like prob here as in its unreachable
			{
				case 1:
					tempvar=0;
					tempvar=0;
					tempvar=0;
					//vertical line
					for (int i=0;i<listX.length;i++)
					{
						if (Sel[listX[i]][listY[i]]==0 )
						{
							//confirmed current button is empty
							if (listX[0] == 0)
							{
								//stacked to the left
								if (Sel[listX[i]+1][listY[i]]==0 )
								{
									if ( listY[0]==0 ||  listY[0]==4 ) //was both Y
									{
										//starting from top to bottom
										//NB smebaj 091118 workarround should be on line 197
										if (listX[0] != 4 && listX[0] != 0 ) { //smebaj 091118 workarround
											if (listX[i]+1 <5 && listY[listY.length-1]+step <5 ) { //workaround continue
												if (Sel[listX[i]+1][listY[listY.length-1]+step]==0 && Sel[listX[i]][listY[listY.length-1]+step]==0  )
													tempvar=0;
												else
												{
													Checked=false;
												}
											}
										}
									}
									else if ( listY[listY.length-1]==0 || listY[listY.length-1]==4 )
									{
										//ending at top or bottom
										if (listY[listY.length-1] != 4 && listY[listY.length-1] != 0) { //smebaj 091118 workarround
											if (Sel[listX[i]+1][listY[0]-step]==0 && Sel[listX[i]][listY[0]-step]==0  )
												tempvar=0;
											else
											{
												Checked=false;
											}
										}
									}
									else
									{
										//regular
										if (Sel[listX[i]+1][listY[listY.length-1]+step]==0 && Sel[listX[i]][listY[listY.length-1]+step]==0 && Sel[listX[i]+1][listY[0]-step]==0 && Sel[listX[i]][listY[0]-step]==0  )
											tempvar=0;
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
							else if (listX[0] == 4)
							{
								//stacked to the right
								if (Sel[listX[i]-1][listY[i]]==0 )
								{
									if ( listY[0]==0 ||  listY[0]==4 )
									{
										//starting from top or bottom
										if (Sel[listX[i]-1][listY[listY.length-1]+step]==0 && Sel[listX[i]][listY[listY.length-1]+step]==0  )
											tempvar=0;
										else
											Checked=false;
									}
									else if ( listY[listY.length-1]==0 || listY[listY.length-1]==4 )
									{
										//ending at top or bottom
										if (Sel[listX[i]-1][listY[0]-step]==0 && Sel[listX[i]][listY[0]-step]==0  )
											tempvar=0;
										else
											Checked=false;
									}
									else
									{
										//regular
										if (Sel[listX[i]-1][listY[listY.length-1]+step]==0 && Sel[listX[i]][listY[listY.length-1]+step]==0 && Sel[listX[i]-1][listY[0]-step]==0 && Sel[listX[i]][listY[0]-step]==0  )
											tempvar=0;
										else
											Checked=false;
									}
								}
								else
									Checked=false;
							}
							else
							{
								if (Sel[listX[i]-1][listY[i]]==0 && Sel[listX[i]+1][listY[i]]==0  )
								{
									if ( listY[0]==0 ||  listY[0]==4 )
									{
										//starting from top or bottom
										if (listX[0] != 4 && listX[0] != 0 ) { //smebaj 091118 workarround
											if (listX[i]+1 <5 && listY[listY.length-1]+step <5 ) { //workaround continue
												if (Sel[listX[i]-1][listY[listY.length-1]+step]==0 && Sel[listX[i]][listY[listY.length-1]+step]==0  && Sel[listX[i]+1][listY[listY.length-1]+step]==0  )
													tempvar=0;
												else
												{
													Checked=false;
													debug="not stacked";
												}
											}
										}
									}
									else if ( listY[listY.length-1]==0 || listY[listY.length-1]==4 )
									{
										//ending at top or bottom
										if (Sel[listX[i]-1][listY[0]-step]==0 )
										{
											if (  Sel[listX[i]][listY[0]-step]==0 )
											{
												if (Sel[listX[i]+1][listY[0]-step]==0)
													tempvar=0;
											}
										}
										else
											Checked=false;
									}
									else
									{
										//regular
										if (Sel[listX[i]-1][listY[listY.length-1]+step]==0 && Sel[listX[i]][listY[listY.length-1]+step]==0 && Sel[listX[i]-1][listY[0]-step]==0 && Sel[listX[i]][listY[0]-step]==0 && Sel[listX[i]+1][listY[0]-step]==0  && Sel[listX[i]+1][listY[listY.length-1]+step]==0 )
											tempvar=0;
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
					}
					break;
				case 2:
					//horizontal line
					for (int i=0;i<listX.length;i++)
					{
						//new loop - checking current buttom is empty - horizontal line - x - is fixed
						if (Sel[listX[i]][listY[i]]==0 )
						{
							//confirmed current buttom is empty
							if (listY[0] == 0)
							{
								//stacked to the top
								if (Sel[listX[i]][listY[i]+1]==0 )
								{
									if ( listX[0]==0 ||  listX[0]==4 )
									{
										tempvar=0;
										//starting from left or right
										if (Sel[listX[listX.length-1]+step][listY[i]+1]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0  )
											tempvar=0;
										else
											Checked=false;
									}
									else if ( listX[listX.length-1]==0 || listX[listX.length-1]==4 )
									{
										//ending at left or right
										if (Sel[listX[0]-step][listY[i]+1]==0 && Sel[listX[0]-step][listY[i]]==0  )
											tempvar=0;
										else
											Checked=false;
									}
									else
									{
										//regular
										if (Sel[listX[0]-step][listY[i]+1]==0 && Sel[listX[0]-step][listY[i]]==0 && Sel[listX[listX.length-1]+step][listY[i]+1]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0  )
											tempvar=0;
										else
											Checked=false;
									}
								}
								else
									Checked=false;
							}
							else if (listY[0] == 4)
							{
								//stacked to the bottom
								if (Sel[listX[i]][listY[i]-1]==0 )
								{
									if ( listX[0]==0 ||  listX[0]==4 )
									{
										//starting from left or right
										if (Sel[listX[listX.length-1]+step][listY[i]-1]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0  )
											tempvar=0;
										else
											Checked=false;
									}
									else if ( listX[listX.length-1]==0 || listX[listX.length-1]==4 )
									{
										//ending at left or right
										if (Sel[listX[0]-step][listY[i]-1]==0 && Sel[listX[0]-step][listY[i]]==0  )
											tempvar=0;
										else
											Checked=false;
									}
									else
									{
										//regular
										if (Sel[listX[0]-step][listY[i]-1]==0 && Sel[listX[0]-step][listY[i]]==0 && Sel[listX[listX.length-1]+step][listY[i]-1]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0  )
											tempvar=0;
										else
											Checked=false;
									}
								}
								else
									Checked=false;
							}
							else
							{
								//System.out.println("debug critical: listY[i]+1 less than 5? : " + (listY[i]+1)); smebaj 091118
								if (Sel[listX[i]][listY[i]-1]==0 && Sel[listX[i]][listY[i]]==0   ) //check file problematic_line340 (1 time)
								{
									if ( listX[0]==0 ||  listX[0]==4 )
									{
										if (Sel[listX[listX.length-1]+step][listY[i]-1]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0   ) //check file problematic_line340 (1 time)
											tempvar=0;
										else
											Checked=false;
									}
									else if ( listX[listX.length-1]==0 || listX[listX.length-1]==4 )
									{
										if (Sel[listX[0]-step][listY[i]-1]==0 && Sel[listX[0]-step][listY[i]]==0  && Sel[listX[0]-step][listY[i]]==0  ) //check file problematic_line340 (1 time)
											tempvar=0;
										else
											Checked=false;
									}
									else
									{
										if (Sel[listX[0]-step][listY[i]-1]==0 && Sel[listX[0]-step][listY[i]]==0 && Sel[listX[0]-step][listY[i]]==0 && Sel[listX[listX.length-1]+step][listY[i]-1]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0 )//check file problematic_line340 (2times)
											tempvar=0;
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
					}
					break;
			}
		}//ending else
		return Checked;
	}
}
