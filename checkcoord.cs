	public bool CheckLineCoord(int[] listX, int[] listY, int step)
	{
		bool Checked=true;
		string debug="";
		int tempListY0Value=listY[0];
		bool vertical=false;
		for (int i=0; i<listX.length; i++)
		{
			if (tempListY0Value==listY[i]) // was ==listX[i]
			{
				tempvar=0;
				vertical=true;
			}
			else
			{
			}
		}
		for (int i=0; i<listX.length; i++)
		{
			if ( 8<listX[i] || listX[i]<1 || 9<listY[i] || listY[i]<1)
			{
				Checked=false;
			}
		}

		if (Checked==false)
		{
			tempvar=0;
			//MessageBox.Show("no need to continue");
		}
		else
		{

		switch (vertical) //looks like prob here as in its unreachable
		{
			case true:
				tempvar=0;
				tempvar=0;
				tempvar=0;
				for (int i=0;i<listX.length;i++)
				{	
					if (Sel[listX[i],listY[i]]==0 )
					{
					tempvar=0;
						if (listX[0] == 0)
						{
							tempvar=0;
							if (Sel[listX[i]+1,listY[i]]==0 )
							{
								if ( listY[0]==0 ||  listY[0]==9 ) //was both Y
								{
									tempvar=0;
									if (Sel[listX[i]+1,listY[listY.length-1]+step]==0 && Sel[listX[i],listY[listY.length-1]+step]==0  )
										tempvar=0;
									else
									{
										Checked=false;
									}
								}
								else if ( listY[listY.length-1]==0 || listY[listY.length-1]==9 )
								{
									tempvar=0;
									if (Sel[listX[i]+1,listY[0]-step]==0 && Sel[listX[i],listY[0]-step]==0  )
										tempvar=0;
									else
									{
										Checked=false;
									}
								}
								else
								{
									tempvar=0;
									if (Sel[listX[i]+1,listY[listY.length-1]+step]==0 && Sel[listX[i],listY[listY.length-1]+step]==0 && Sel[listX[i]+1,listY[0]-step]==0 && Sel[listX[i],listY[0]-step]==0  )
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
						else if (listX[0] == 9)
						{
							tempvar=0;
							if (Sel[listX[i]-1,listY[i]]==0 )
							{
								if ( listY[0]==0 ||  listY[0]==9 )
								{
									tempvar=0;
									if (Sel[listX[i]-1,listY[listY.length-1]+step]==0 && Sel[listX[i],listY[listY.length-1]+step]==0  )
										tempvar=0;
									else
										Checked=false;
								}
								else if ( listY[listY.length-1]==0 || listY[listY.length-1]==9 )
								{
									tempvar=0;
									if (Sel[listX[i]-1,listY[0]-step]==0 && Sel[listX[i],listY[0]-step]==0  )
										tempvar=0;
									else
										Checked=false;
								}
								else
								{
									tempvar=0;
									if (Sel[listX[i]-1,listY[listY.length-1]+step]==0 && Sel[listX[i],listY[listY.length-1]+step]==0 && Sel[listX[i]-1,listY[0]-step]==0 && Sel[listX[i],listY[0]-step]==0  )
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
							if (Sel[listX[i]-1,listY[i]]==0 && Sel[listX[i]+1,listY[i]]==0  )
							{
								//MessageBox.Show("reached line nbr: 874");
								if ( listY[0]==0 ||  listY[0]==9 )
								{
									tempvar=0;
									if (Sel[listX[i]-1,listY[listY.length-1]+step]==0 && Sel[listX[i],listY[listY.length-1]+step]==0  && Sel[listX[i]+1,listY[listY.length-1]+step]==0  )
										tempvar=0;
									else
									{
										Checked=false;
										debug="not stacked";
									}
								}
								else if ( listY[listY.length-1]==0 || listY[listY.length-1]==9 )
								{
									tempvar=0;
									if (Sel[listX[i]-1,listY[0]-step]==0 )
									{
										//MessageBox.Show("p1 fine");
										if (  Sel[listX[i],listY[0]-step]==0 ) 
										{
										//MessageBox.Show("p2 fine");
											if (Sel[listX[i]+1,listY[0]-step]==0) 
												tempvar=0;
											//MessageBox.Show("p3 fine");
										}
									}

									else
										Checked=false;
								}
								else
								{
									tempvar=0;
									if (Sel[listX[i]-1,listY[listY.length-1]+step]==0 && Sel[listX[i],listY[listY.length-1]+step]==0 && Sel[listX[i]-1,listY[0]-step]==0 && Sel[listX[i],listY[0]-step]==0 && Sel[listX[i]+1,listY[0]-step]==0  && Sel[listX[i]+1,listY[listY.length-1]+step]==0 )
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
					tempvar=0;
				}
				break;
			case false:
				tempvar=0;
				tempvar=0;
				tempvar=0;
				for (int i=0;i<listX.length;i++)
				{	
					tempvar=0;
					if (Sel[listX[i],listY[i]]==0 )
					{
					tempvar=0;
						if (listY[0] == 0)
						{
							tempvar=0;
							if (Sel[listX[i],listY[i]+1]==0 )
							{
								if ( listX[0]==0 ||  listX[0]==9 )
								{
									tempvar=0;
									if (Sel[listX[listX.length-1]+step][listY[i]+1]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0  )
										tempvar=0;
									else
										Checked=false;
								}
								else if ( listX[listX.length-1]==0 || listX[listX.length-1]==9 )
								{
									tempvar=0;
									if (Sel[listX[0]-step][listY[i]+1]==0 && Sel[listX[0]-step][listY[i]]==0  )
										tempvar=0;
									else
										Checked=false;
								}
								else
								{
									tempvar=0;
									if (Sel[listX[0]-step][listY[i]+1]==0 && Sel[listX[0]-step][listY[i]]==0 && Sel[listX[listX.length-1]+step][listY[i]+1]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0  )
										tempvar=0;
									else
										Checked=false;
								}
							}
							else
								Checked=false;
						}
						else if (listY[0] == 9)
						{
							tempvar=0;
							if (Sel[listX[i],listY[i]-1]==0 )
							{
								if ( listX[0]==0 ||  listX[0]==9 )
								{
									tempvar=0;
									if (Sel[listX[listX.length-1]+step][listY[i]-1]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0  )
										tempvar=0;
									else
										Checked=false;
								}
								else if ( listX[listX.length-1]==0 || listX[listX.length-1]==9 )
								{
									tempvar=0;
									if (Sel[listX[0]-step][listY[i]-1]==0 && Sel[listX[0]-step][listY[i]]==0  )
										tempvar=0;
									else
										Checked=false;
								}
								else
								{
									tempvar=0;
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
							if (Sel[listX[i],listY[i]-1]==0 && Sel[listX[i],listY[i]+1]==0   ) 
							{
								if ( listX[0]==0 ||  listX[0]==9 )
								{
									if (Sel[listX[listX.length-1]+step][listY[i]-1]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0 && Sel[listX[listX.length-1]+step][listY[i]+1]==0   )
										tempvar=0;
									else
										Checked=false;
								}
								else if ( listX[listX.length-1]==0 || listX[listX.length-1]==9 )
								{
									if (Sel[listX[0]-step][listY[i]-1]==0 && Sel[listX[0]-step][listY[i]]==0  && Sel[listX[0]-step][listY[i]+1]==0  )
										tempvar=0;
									else
										Checked=false;
								}
								else
								{
									//MessageBox.Show("problematic");
									if (Sel[listX[0]-step][listY[i]-1]==0 && Sel[listX[0]-step][listY[i]]==0 && Sel[listX[0]-step][listY[i]+1]==0 && Sel[listX[listX.length-1]+step][listY[i]-1]==0 && Sel[listX[listX.length-1]+step][listY[i]]==0 && Sel[listX[listX.length-1]+step][listY[i]+1]==0 )
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
					tempvar=0;
				}
				break;
		}

		}//ending else

		//MessageBox.Show("returning: " + Checked);
		tempvar=0;
		return Checked;
	}
