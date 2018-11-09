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
