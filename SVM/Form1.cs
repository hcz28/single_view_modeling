using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Util;
using Emgu.CV.Structure;

using Extreme.Mathematics;
using Extreme.Mathematics.LinearAlgebra;


namespace SVM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Image<Bgr, Byte> pic;
        Image<Bgr, Byte> pic_backup;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string name = openfile.FileName;
                pic = new Image<Bgr, Byte>(name);
                pictureBox1.Image = pic.ToBitmap();
                pic_backup = pic.Clone();
            }
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel1.Text = "X: " + e.X + " " + "Y: " + e.Y;

            if(first_click_flag==false)
            {
                pictureBox1.Image = pic.ToBitmap();
                Graphics G = Graphics.FromImage(pictureBox1.Image);
                if (xLinesToolStripMenuItem.Checked == true)
                {                    
                    Pen redPen = new Pen(Color.Red, 2);
                    G.DrawLine(redPen, Linepoint[0, 0], Linepoint[0, 1], e.X, e.Y);
                }
                else if(yLinesToolStripMenuItem.Checked==true)
                {
                    Pen redPen = new Pen(Color.Green, 2);
                    G.DrawLine(redPen, Linepoint[0, 0], Linepoint[0, 1], e.X, e.Y);
                }
                else if (zLinesToolStripMenuItem.Checked == true)
                {
                    Pen redPen = new Pen(Color.Blue, 2);
                    G.DrawLine(redPen, Linepoint[0, 0], Linepoint[0, 1], e.X, e.Y);
                }             

            }

            if (calculate3DPositionToolStripMenuItem1.Checked == true && guidelinesToolStripMenuItem.Checked==true)
            {
                pic = pic_backup.Clone();
                for (int i = 0; i < uv.Count; i++)
                {
                    Cross2DF cross = new Cross2DF(new Point((int)uv[i][0], (int)uv[i][1]), 6, 6);
                    pic.Draw(cross, new Bgr(255, 255, 255), 1);
                }
                pictureBox1.Image = pic.ToBitmap();


                var p1 = Vector.Create((double)e.X, e.Y, 1);
                var p2 = Vector.Create(ZV[0], ZV[1], 1);
                var line = p1.CrossProduct(p2);

                var v1 = Vector.Create(0.0, 0, 1);
                var v2 = Vector.Create(pic.Cols - 1, 0.0, 1);
                var v3 = Vector.Create(0.0, pic.Rows-1, 1);
                var v4 = Vector.Create(pic.Cols - 1, pic.Rows - 1, 1.0);

                var line_up = v1.CrossProduct(v2);
                var line_bottom = v3.CrossProduct(v4);

                var p3 = line.CrossProduct(line_up);
                var p4 = line.CrossProduct(line_bottom);



                Pen pen = new Pen(Color.WhiteSmoke, 1);
                Graphics G = Graphics.FromImage(pictureBox1.Image);
                G.DrawLine(pen, new Point((int)(p3[0] / p3[2]), (int)(p3[1] / p3[2])), new Point((int)(p4[0] / p4[2]), (int)(p4[1] / p4[2])));
                
            }
            if (calculate3DPositionToolStripMenuItem1.Checked == true && xGuidelinesToolStripMenuItem.Checked == true)
            {
                pic = pic_backup.Clone();
                for (int i = 0; i < uv.Count; i++)
                {
                    Cross2DF cross = new Cross2DF(new Point((int)uv[i][0], (int)uv[i][1]), 6, 6);
                    pic.Draw(cross, new Bgr(255, 255, 255), 1);
                }
                pictureBox1.Image = pic.ToBitmap();


                var p1 = Vector.Create((double)e.X, e.Y, 1);
                var p2 = Vector.Create(XV[0], XV[1], 1);
                var line = p1.CrossProduct(p2);

                var v1 = Vector.Create(0.0, 0, 1);
                var v2 = Vector.Create(pic.Cols - 1, 0.0, 1);
                var v3 = Vector.Create(0.0, pic.Rows - 1, 1);
                var v4 = Vector.Create(pic.Cols - 1, pic.Rows - 1, 1.0);

                var line_left = v1.CrossProduct(v3);
                var line_right = v2.CrossProduct(v4);

                var p3 = line.CrossProduct(line_left);
                var p4 = line.CrossProduct(line_right);



                Pen pen = new Pen(Color.WhiteSmoke, 1);
                Graphics G = Graphics.FromImage(pictureBox1.Image);
                G.DrawLine(pen, new Point((int)(p3[0] / p3[2]), (int)(p3[1] / p3[2])), new Point((int)(p4[0] / p4[2]), (int)(p4[1] / p4[2])));

            }

            if (calculate3DPositionToolStripMenuItem1.Checked == true && yGuidelineToolStripMenuItem.Checked == true)
            {
                pic = pic_backup.Clone();
                for (int i = 0; i < uv.Count; i++)
                {
                    Cross2DF cross = new Cross2DF(new Point((int)uv[i][0], (int)uv[i][1]), 6, 6);
                    pic.Draw(cross, new Bgr(255, 255, 255), 1);
                }
                pictureBox1.Image = pic.ToBitmap();


                var p1 = Vector.Create((double)e.X, e.Y, 1);
                var p2 = Vector.Create(YV[0], YV[1], 1);
                var line = p1.CrossProduct(p2);

                var v1 = Vector.Create(0.0, 0, 1);
                var v2 = Vector.Create(pic.Cols - 1, 0.0, 1);
                var v3 = Vector.Create(0.0, pic.Rows - 1, 1);
                var v4 = Vector.Create(pic.Cols - 1, pic.Rows - 1, 1.0);

                var line_left = v1.CrossProduct(v3);
                var line_right = v2.CrossProduct(v4);

                var p3 = line.CrossProduct(line_left);
                var p4 = line.CrossProduct(line_right);



                Pen pen = new Pen(Color.WhiteSmoke, 1);
                Graphics G = Graphics.FromImage(pictureBox1.Image);
                G.DrawLine(pen, new Point((int)(p3[0] / p3[2]), (int)(p3[1] / p3[2])), new Point((int)(p4[0] / p4[2]), (int)(p4[1] / p4[2])));

            }

            if (allGuidelinesToolStripMenuItem.Checked == true && calculate3DPositionToolStripMenuItem1.Checked == true)
            {
                pic = pic_backup.Clone();
                for (int i = 0; i < uv.Count; i++)
                {
                    Cross2DF cross = new Cross2DF(new Point((int)uv[i][0], (int)uv[i][1]), 6, 6);
                    pic.Draw(cross, new Bgr(255, 255, 255), 1);
                }
                pictureBox1.Image = pic.ToBitmap();

                var p1 = Vector.Create((double)e.X, e.Y, 1);
                var p2 = Vector.Create(XV[0], XV[1], 1);
                var p3 = Vector.Create(YV[0], YV[1], 1);
                var p4 = Vector.Create(ZV[0], ZV[1], 1);
                var line1 = p1.CrossProduct(p2);
                var line2 = p1.CrossProduct(p3);
                var line3 = p1.CrossProduct(p4);

                var v1 = Vector.Create(0.0, 0, 1);
                var v2 = Vector.Create(pic.Cols - 1, 0.0, 1);
                var v3 = Vector.Create(0.0, pic.Rows - 1, 1);
                var v4 = Vector.Create(pic.Cols - 1, pic.Rows - 1, 1.0);

                var line_left = v1.CrossProduct(v3);
                var line_right = v2.CrossProduct(v4);
                var line_up = v1.CrossProduct(v2);
                var line_bottom = v3.CrossProduct(v4);

                var px1 = line1.CrossProduct(line_left);
                var px2 = line1.CrossProduct(line_right);

                var py1 = line2.CrossProduct(line_left);
                var py2 = line2.CrossProduct(line_right);

                var pz1 = line3.CrossProduct(line_bottom);
                var pz2 = line3.CrossProduct(line_up);

                Pen pen = new Pen(Color.WhiteSmoke, 1);
                Graphics G = Graphics.FromImage(pictureBox1.Image);
                G.DrawLine(pen, new Point((int)(px1[0] / px1[2]), (int)(px1[1] / px1[2])), new Point((int)(px2[0] / px2[2]), (int)(px2[1] / px2[2])));
                G.DrawLine(pen, new Point((int)(py1[0] / py1[2]), (int)(py1[1] / py1[2])), new Point((int)(py2[0] / py2[2]), (int)(py2[1] / py2[2])));
                G.DrawLine(pen, new Point((int)(pz1[0] / pz1[2]), (int)(pz1[1] / pz1[2])), new Point((int)(pz2[0] / pz2[2]), (int)(pz2[1] / pz2[2])));


            }







        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void xLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            foreach (ToolStripMenuItem item in editToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            xLinesToolStripMenuItem.Checked = true;
            Console.WriteLine("Please specify lines in X direction:");
        }

        private void yLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in editToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            yLinesToolStripMenuItem.Checked = true;
            Console.WriteLine("Please specify lines in Y direction:");
        }

        private void zLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in editToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            zLinesToolStripMenuItem.Checked = true;
            Console.WriteLine("Please specify lines in Z direction:");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
        }


        // To save the line vectors
        List<double[]> Xlines = new List<double[]>();
        List<double[]> Ylines = new List<double[]>();
        List<double[]> Zlines = new List<double[]>();
        int[,] Linepoint=new int[2,2]; //save the endpoints of lines
        bool first_click_flag = true;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {            
            if (xLinesToolStripMenuItem.Checked == true)
            {
                if (first_click_flag == true)
                {
                    Linepoint[0, 0] = e.X;
                    Linepoint[0, 1] = e.Y;
                    first_click_flag = false;
                }
                else
                {
                    double[] Xvec = new double[3];
                    Linepoint[1, 0] = e.X;
                    Linepoint[1, 1] = e.Y;
                    //cross product
                    Xvec[0] = Linepoint[0, 1] - Linepoint[1, 1];
                    Xvec[1] = Linepoint[1, 0] - Linepoint[0, 0];
                    Xvec[2] = Linepoint[0, 0] * Linepoint[1, 1] - Linepoint[1, 0] * Linepoint[0, 1];
                    Xlines.Add(Xvec);
                    first_click_flag = true;  
                    //draw lines in the origin image
                    LineSegment2D line=new LineSegment2D();
                    line.P1=new Point(Linepoint[0,0],Linepoint[0,1]);
                    line.P2=new Point(Linepoint[1,0],Linepoint[1,1]);
                    pic.Draw(line, new Bgr(0, 0, 255), 1);
                    Console.WriteLine("X line vector: [ "+Xvec[0].ToString()+" "+Xvec[1].ToString()+" "+Xvec[2].ToString()+" ]");
                }                
            }
            else if(yLinesToolStripMenuItem.Checked==true)
            {
                if (first_click_flag == true)
                {
                    Linepoint[0, 0] = e.X;
                    Linepoint[0, 1] = e.Y;
                    first_click_flag = false;
                }
                else
                {
                    double[] Yvec = new double[3];
                    Linepoint[1, 0] = e.X;
                    Linepoint[1, 1] = e.Y;
                    //cross product
                    Yvec[0] = Linepoint[0, 1] - Linepoint[1, 1];
                    Yvec[1] = Linepoint[1, 0] - Linepoint[0, 0];
                    Yvec[2] = Linepoint[0, 0] * Linepoint[1, 1] - Linepoint[1, 0] * Linepoint[0, 1];
                    Ylines.Add(Yvec);
                    first_click_flag = true;
                    //draw lines in the origin image
                    LineSegment2D line = new LineSegment2D();
                    line.P1 = new Point(Linepoint[0, 0], Linepoint[0, 1]);
                    line.P2 = new Point(Linepoint[1, 0], Linepoint[1, 1]);
                    pic.Draw(line, new Bgr(0, 255, 0), 1);
                    Console.WriteLine("Y line vector: [ " + Yvec[0].ToString() + " " + Yvec[1].ToString() + " " + Yvec[2].ToString() + " ]");
                }          
            }
            else if (zLinesToolStripMenuItem.Checked == true)
            {
                if (first_click_flag == true)
                {
                    Linepoint[0, 0] = e.X;
                    Linepoint[0, 1] = e.Y;
                    first_click_flag = false;
                }
                else
                {
                    double[] Zvec = new double[3];
                    Linepoint[1, 0] = e.X;
                    Linepoint[1, 1] = e.Y;
                    //cross product
                    Zvec[0] = Linepoint[0, 1] - Linepoint[1, 1];
                    Zvec[1] = Linepoint[1, 0] - Linepoint[0, 0];
                    Zvec[2] = Linepoint[0, 0] * Linepoint[1, 1] - Linepoint[1, 0] * Linepoint[0, 1];
                    Zlines.Add(Zvec);
                    first_click_flag = true;
                    //draw lines in the origin image
                    LineSegment2D line = new LineSegment2D();
                    line.P1 = new Point(Linepoint[0, 0], Linepoint[0, 1]);
                    line.P2 = new Point(Linepoint[1, 0], Linepoint[1, 1]);
                    pic.Draw(line, new Bgr(255, 0, 0), 1);
                    Console.WriteLine("Z line vector: [ " + Zvec[0].ToString() + " " + Zvec[1].ToString() + " " + Zvec[2].ToString() + " ]");
                }
            }

            else if (pointsToolStripMenuItem.Checked==true)
            {
                double[] uv_temp = new double[2];
                double[] XYW_temp = new double[3];
                uv_temp[0] = e.X;
                uv_temp[1] = e.Y;
                uv.Add(uv_temp);
                
                //draw a point in the original image
                Cross2DF cross = new Cross2DF(new Point(e.X, e.Y), 6, 6);
                pic.Draw(cross, new Bgr(255, 255, 255), 1);
                pictureBox1.Image = pic.ToBitmap();
                
                //define the position in Z=0 plane

                Form2 form2 = new Form2(this);
                form2.ShowDialog();
                if (label1.Text != null && label2.Text != null)
                {
                    XYW_temp[0] = Double.Parse(label1.Text);
                    XYW_temp[1] = Double.Parse(label2.Text);
                    XYW_temp[2] = 1;
                    XYZ.Add(XYW_temp);
                }           
               
                Console.WriteLine("Image Point:( " + e.X + " , " + e.Y + ", 1 ) ------ Scene Point:( " + XYW_temp[0] + " , " + XYW_temp[1] + " , " + "0 , 1 )");

            }
            
            else if(refHeightPointToolStripMenuItem.Checked==true)
            {
              
                double[] uv_temp = new double[2];
                double[] XYZ_temp = new double[3];

                uv_temp[0] = e.X;
                uv_temp[1] = e.Y;
                uv.Add(uv_temp);

                //draw a point in the original image
                Cross2DF cross = new Cross2DF(new Point(e.X, e.Y), 6, 6);
                pic.Draw(cross, new Bgr(255, 255, 255), 1);
                pictureBox1.Image = pic.ToBitmap();

                //define the position in Z=0 plane

                Form2 form2 = new Form2(this);
                form2.ShowDialog();
                if (label1.Text != null && label2.Text != null &&label3.Text!=null)
                {
                    XYZ_temp[0] = Double.Parse(label1.Text);
                    XYZ_temp[1] = Double.Parse(label2.Text);
                    XYZ_temp[2] = Double.Parse(label3.Text);
                    XYZ.Add(XYZ_temp);
                }

                Console.WriteLine("Image Point:( " + e.X + " , " + e.Y + ", 1 ) ------ Scene Point:( " + XYZ_temp[0] + " , " + XYZ_temp[1] + " , " +XYZ_temp[2]+ " , 1 )");

            }

            else if(calculate3DPositionToolStripMenuItem1.Checked==true)
            {
                

                //check if there is already a point in uv
                double[] uv_temp = new double[2] { e.X, e.Y };
                bool exist_flag = false;

                if (uv.Count == 0)
                {
                    //draw a point in the original image
                    Cross2DF cross = new Cross2DF(new Point(e.X, e.Y), 6, 6);
                    pic.Draw(cross, new Bgr(255, 255, 255), 1);
                    pictureBox1.Image = pic.ToBitmap();
                    uv.Add(uv_temp);
                }
                else
                {
                    foreach (double[] item in uv)
                    {
                        if (Math.Sqrt((uv_temp[0] - item[0]) * (uv_temp[0] - item[0]) + (uv_temp[1] - item[1]) * (uv_temp[1] - item[1])) <= 5)
                        {
                            //exist
                            uv_temp[0] = item[0];
                            uv_temp[1] = item[1];
                            uv.Add(uv_temp);
                            exist_flag = true;
                            break;
                        }
                        
                    }
                    if (exist_flag == false)
                    {
                        Cross2DF cross = new Cross2DF(new Point(e.X, e.Y), 6, 6);
                        pic.Draw(cross, new Bgr(255, 255, 255), 1);
                        pictureBox1.Image = pic.ToBitmap();
                        uv.Add(uv_temp);

                    }

                }
                
                
                




                
                
                




                //calculate the scene position
                if(uv.Count==1)
                {
                    Z = 0;
                    
                }
                if (Z == 0)
                {
                    Hinv_temp = (double[])Hinv.Clone();
                }
                    

                if (radioButton1.Checked == true)
                {
                    // if the same XY with the previous point then calculate Z and H  
                    var b0 = Vector.Create(uv[uv.Count - 2][0], uv[uv.Count - 2][1],1);
                    var t0 = Vector.Create(uv_temp[0],uv_temp[1],1);
                    var b = Vector.Create(bref[0], bref[1],1);
                    var r = Vector.Create(rref[0], rref[1],1);
                    var vx=Vector.Create(XV[0],XV[1],1);
                    var vy=Vector.Create(YV[0],YV[1],1);
                    var vz = Vector.Create(ZV[0], ZV[1],1);
                    var v = b.CrossProduct(b0).CrossProduct(vx.CrossProduct(vy));
                    for (int i = 0; i < 3; i++)
                        v[i] = v[i] / v[2];
                    var t = v.CrossProduct(t0).CrossProduct(r.CrossProduct(b));
                    for (int i = 0; i < 3; i++)
                        t[i] = t[i] / t[2];

                    if (b0[0] == b[0] && b0[1] == b[1])
                    {
                        t = t0;
                    }
                    Z = (t - b).Norm() * (vz - r).Norm() / ((r - b).Norm() * (vz - t).Norm())*deltaZ;


                    
                    double[] H_temp = new double[9];
                    for (int i = 0; i < 7; i = i + 3)
                    {
                        H_temp[i] = H[i];
                        H_temp[i + 1] = H[i + 1];
                        H_temp[i + 2] = H[i + 2] + AlphaZ * vz[i / 3] * Z;
                    }

                    var h_temp = Matrix.Create(3, 3, H_temp, MatrixElementOrder.RowMajor);
                    var hinv_temp = h_temp.GetInverse();
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            Hinv_temp[i * 3 + j] = hinv_temp[i, j];

                    radioButton1.Checked = false;
                    radioButton2.Checked = true;

                }
                else
                {
                    // if Same Z plane, then use the same H and Z
                }

                double[] XYZ_temp = new double[3];
                for(int i=0;i<3;i++){
                    XYZ_temp[i]=Hinv_temp[3*i]*uv_temp[0]+Hinv_temp[3*i+1]*uv_temp[1]+Hinv_temp[3*i+2]*1;
                }
                XYZ_temp[0] = XYZ_temp[0] / XYZ_temp[2];
                XYZ_temp[1] = XYZ_temp[1] / XYZ_temp[2];
                XYZ_temp[2] = Z;

                XYZ.Add(XYZ_temp);
                Console.WriteLine("Image Point:( " + uv_temp[0] + " , " + uv_temp[1] + ", 1 ) ------ Scene Point:( " + XYZ_temp[0] + " , " + XYZ_temp[1] + " , " + XYZ_temp[2] + " , 1 )");
                
            }

            else if(polygonToolStripMenuItem.Checked==true)
            {
                //find the a point in uv which is close to the mouse click point
                double[] uv_temp = new double[2] { e.X, e.Y };
                int index=-1;
                for(int i=0;i<uv.Count;i++)
                {
                    var v1=Vector.Create(uv[i][0],uv[i][1]);
                    var v2=Vector.Create(uv_temp[0],uv_temp[1]);
                    if ((v1 - v2).Norm() < 5)
                    {
                        index = i;
                        break;
                    }
                        
                }
                if(index==-1)
                {
                    MessageBox.Show("Please respecify the point!");
                }
                else
                {
                    vertex.Add(XYZ[index]);
                    var circle = new CircleF(new Point((int)uv[index][0],(int)uv[index][1]),6);
                    //var rect=new Rectangle(new Point((int)uv[index][0],(int)uv[index][1]),new Size(6,6));
                    pic.Draw(circle
                        ,new Bgr(255,255,255),1);
                    pictureBox1.Image = pic.ToBitmap();
                    Console.WriteLine("Vertex[" + vertex.Count + "] :" + "Image Point:( " + uv[index][0] + " , " + uv[index][1] + ", 1 ) ------ Scene Point:( " + XYZ[index][0] + " , " + XYZ[index][1] + " , " + XYZ[index][2] + " , 1 )");

                }

                


            }
            

        }

        // To save position of vanishing points
        double[] XV = new double[2];
        double[] YV = new double[2];
        double[] ZV = new double[2];

        // To save the reference points && points for polygon
        List<double[]> uv = new List<double[]>();
        List<double[]> XYZ = new List<double[]>();

        
        //save the previous homography and Z height
        double[] Hinv_temp = new double[9];
        double Z;

        //save the four vertexs of polygon
        List<double[]> vertex = new List<double[]>();

        
        private void calculateVPsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Calculate X Vanishing Point
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Calculate X Vanishing Point ");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            double[] M = new double[9]{0,0,0,0,0,0,0,0,0};            
            foreach (double[] item in Xlines)
            {
                M[0] += item[0] * item[0];
                M[1] += item[0] * item[1];
                M[2] += item[0] * item[2];
                M[4] += item[1] * item[1];
                M[5] += item[1] * item[2];
                M[8] += item[2] * item[2];
            }     
            
            var A = Matrix.CreateSymmetric(3,M,
                MatrixTriangle.Upper, MatrixElementOrder.RowMajor);
            var eig = A.GetEigenvalueDecomposition();
            var L = eig.Eigenvalues;
            var X = eig.Eigenvectors;
            Console.WriteLine();
            Console.WriteLine("Eigen Values: "+Environment.NewLine+L[0]+Environment.NewLine+L[1]+Environment.NewLine+L[2]);
            Console.WriteLine();
            Console.WriteLine("Eigen Vectors: ");
            for(int i=0;i<3;i++)
            {
                Console.WriteLine(X[i, 0] + " " + X[i, 1] + " " + X[i, 2]);
            }
            int min_EV=0;
            if(L[1]<L[min_EV]) min_EV=1;
            if(L[2]<L[min_EV]) min_EV=2;
            XV[0]=X[0,min_EV]/X[2,min_EV];
            XV[1]=X[1,min_EV]/X[2,min_EV];
            Console.WriteLine();
            Console.WriteLine("X Vanishing Point Position: ( " + XV[0] + " , " + XV[1] + " )");

            // Calculate Y Vanishing Point
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Calculate Y Vanishing Point ");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            M = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (double[] item in Ylines)
            {
                M[0] += item[0] * item[0];
                M[1] += item[0] * item[1];
                M[2] += item[0] * item[2];
                M[4] += item[1] * item[1];
                M[5] += item[1] * item[2];
                M[8] += item[2] * item[2];
            }

            A = Matrix.CreateSymmetric(3, M,
                MatrixTriangle.Upper, MatrixElementOrder.RowMajor);
            eig = A.GetEigenvalueDecomposition();
            L = eig.Eigenvalues;
            X = eig.Eigenvectors;
            Console.WriteLine();
            Console.WriteLine("Eigen Values: " + Environment.NewLine + L[0] + Environment.NewLine + L[1] + Environment.NewLine + L[2]);
            Console.WriteLine();
            Console.WriteLine("Eigen Vectors: ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(X[i, 0] + " " + X[i, 1] + " " + X[i, 2]);
            }
            min_EV = 0;
            if (L[1] < L[min_EV]) min_EV = 1;
            if (L[2] < L[min_EV]) min_EV = 2;
            YV[0] = X[0, min_EV] / X[2, min_EV];
            YV[1] = X[1, min_EV] / X[2, min_EV];
            Console.WriteLine();
            Console.WriteLine("Y Vanishing Point Position: ( " + YV[0] + " , " + YV[1] + " )");

            // Calculate Z Vanishing Point
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Calculate Z Vanishing Point ");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            M = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (double[] item in Zlines)
            {
                M[0] += item[0] * item[0];
                M[1] += item[0] * item[1];
                M[2] += item[0] * item[2];
                M[4] += item[1] * item[1];
                M[5] += item[1] * item[2];
                M[8] += item[2] * item[2];
            }

            A = Matrix.CreateSymmetric(3, M,
                MatrixTriangle.Upper, MatrixElementOrder.RowMajor);
            eig = A.GetEigenvalueDecomposition();
            L = eig.Eigenvalues;
            X = eig.Eigenvectors;
            Console.WriteLine();
            Console.WriteLine("Eigen Values: " + Environment.NewLine + L[0] + Environment.NewLine + L[1] + Environment.NewLine + L[2]);
            Console.WriteLine();
            Console.WriteLine("Eigen Vectors: ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(X[i, 0] + " " + X[i, 1] + " " + X[i, 2]);
            }
            min_EV = 0;
            if (L[1] < L[min_EV]) min_EV = 1;
            if (L[2] < L[min_EV]) min_EV = 2;
            ZV[0] = X[0, min_EV] / X[2, min_EV];
            ZV[1] = X[1, min_EV] / X[2, min_EV];

            //if (ZV[1] < 0)
            //    ZV[1] = -ZV[1];

            Console.WriteLine();
            Console.WriteLine("Z Vanishing Point Position: ( " + ZV[0] + " , " + ZV[1] + " )");

            
        }

        private void saveModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string path = @"C:\Users\chou\Documents\Visual Studio 2013\Projects\SVM\Model.txt";
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save VRML Model";
            //sfd.ShowDialog();
            sfd.Filter = "TEXT FILE|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter model = File.CreateText(sfd.FileName))
                {
                    //write vanishing point
                    model.WriteLine(XV[0] + " , " + XV[1]);
                    model.WriteLine(YV[0] + " , " + YV[1]);
                    model.WriteLine(ZV[0] + " , " + ZV[1]);

                    //write homography matrix (scene to image)
                    model.WriteLine();
                    for (int i = 0; i < 8; i++)
                        model.Write(H[i] + " , ");
                    model.Write(H[8]);

                    //write homography matrix (image to scene)
                    model.WriteLine();
                    model.WriteLine();
                    for (int i = 0; i < 8; i++)
                        model.Write(Hinv[i] + " , ");
                    model.Write(Hinv[8]);

                    //write alphaZ and reference point
                    model.WriteLine();
                    model.WriteLine();
                    model.WriteLine(AlphaZ);
                    model.WriteLine(deltaZ);
                    model.WriteLine(bref[0] + " , " + bref[1]);
                    model.WriteLine(rref[0] + " , " + rref[1]);

                }
                Console.WriteLine();
                Console.WriteLine("Save model done!");
            }
            

        }

        private void loadModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string path = @"C:\Users\chou\Documents\Visual Studio 2013\Projects\SVM\Model.txt";

             OpenFileDialog openfile = new OpenFileDialog();
             if (openfile.ShowDialog() == DialogResult.OK)
             {
                 using (TextReader model = File.OpenText(openfile.FileName))
                 {
                     string line;
                     // reading vanishing point
                     line = model.ReadLine();
                     string[] bits = line.Split(',');
                     XV[0] = Double.Parse(bits[0]);
                     XV[1] = Double.Parse(bits[1]);

                     line = model.ReadLine();
                     bits = line.Split(',');
                     YV[0] = Double.Parse(bits[0]);
                     YV[1] = Double.Parse(bits[1]);

                     line = model.ReadLine();
                     bits = line.Split(',');
                     ZV[0] = Double.Parse(bits[0]);
                     ZV[1] = Double.Parse(bits[1]);

                     //reading homography matrix (scene to image)
                     line = model.ReadLine();
                     line = model.ReadLine();
                     bits = line.Split(',');
                     for (int i = 0; i < bits.Length; i++)
                         H[i] = Double.Parse(bits[i]);

                     //reading homograph matrix (image to scene)
                     line = model.ReadLine();
                     line = model.ReadLine();
                     bits = line.Split(',');
                     for (int i = 0; i < bits.Length; i++)
                         Hinv[i] = Double.Parse(bits[i]);

                     //read alphaZ and the reference height point
                     line = model.ReadLine();
                     line = model.ReadLine();
                     AlphaZ = Double.Parse(line);
                     line = model.ReadLine();
                     deltaZ = Double.Parse(line);
                     line = model.ReadLine();
                     bits = line.Split(',');
                     bref[0] = Double.Parse(bits[0]);
                     bref[1] = Double.Parse(bits[1]);
                     line = model.ReadLine();
                     bits = line.Split(',');
                     rref[0] = Double.Parse(bits[0]);
                     rref[1] = Double.Parse(bits[1]);




                 }
                 Console.WriteLine("Load model from file: ");
                 Console.WriteLine("X Vanishing Point Position: ( " + XV[0] + " , " + XV[1] + " )");
                 Console.WriteLine("Y Vanishing Point Position: ( " + YV[0] + " , " + YV[1] + " )");
                 Console.WriteLine("Z Vanishing Point Position: ( " + ZV[0] + " , " + ZV[1] + " )");
                 Console.WriteLine();
                 Console.WriteLine("Homography Matrix ( from scene to image )");
                 for (int i = 0; i < 3; i++)
                 {
                     Console.WriteLine();
                     for (int j = 0; j < 3; j++)
                         Console.Write(H[i * 3 + j] + " ");
                 }
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine("Homography Matrix ( from image to scene )");
                 for (int i = 0; i < 3; i++)
                 {
                     Console.WriteLine();
                     for (int j = 0; j < 3; j++)
                         Console.Write(Hinv[i * 3 + j] + " ");
                 }
                 Console.WriteLine();
                 Console.WriteLine();

                 Console.WriteLine("AplhaZ: " + AlphaZ);
                 Console.WriteLine("The reference height point: ( " + bref[0] + " , " + bref[1] + " )  ( " + rref[0] + " , " + rref[1] + " )");
             }
             
             

            

        }

        private void pointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in editToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            uv.Clear();
            XYZ.Clear();
            pointsToolStripMenuItem.Checked = true;
            Console.WriteLine();
            Console.WriteLine("Please specify 2 or more points on Z=0 plane which are not colinear with any vanishing point:");
            Console.WriteLine();


        }

        public void passValue(string X, string Y,string Z)
        {
            label1.Text = X;
            label2.Text = Y;
            label3.Text = Z;
        }

        //Homography matrix
        double[] H = new double[9];
        double[] Hinv = new double[9];
        double AlphaZ;
        //save the ref height points
        double[] bref = new double[2];
        double[] rref = new double[2];
        double deltaZ;//save the ref height
        //save the coordinates for vrml file
        Dictionary<string, double[]> vrml = new Dictionary<string, double[]>();

        private void homographyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Calculate Homography Matrix From Z=0 Plane to Image Plane: ");
            Console.WriteLine();

            uv.Add(new double[2] { XV[0], XV[1] });
            uv.Add(new double[2] { YV[0], YV[1] });
            XYZ.Add(new double[3] { 1, 0, 0 });
            XYZ.Add(new double[3] { 0, 1, 0 });

            // solve A*X=B
            double[] A=new double[uv.Count*2*8];
            for (int i = 0; i < uv.Count; i = i + 1)
            {
                A[i * 2 * 8 + 0] = XYZ[i][0];
                A[i * 2 * 8 + 1] = XYZ[i][1];
                A[i * 2 * 8 + 2] = XYZ[i][2];
                A[i * 2 * 8 + 3] = 0;
                A[i * 2 * 8 + 4] = 0;
                A[i * 2 * 8 + 5] = 0;
                A[i * 2 * 8 + 6] = -uv[i][0] * XYZ[i][0];
                A[i * 2 * 8 + 7] = -uv[i][0] * XYZ[i][1];

                A[i * 2 * 8 + 8 + 0] = 0;
                A[i * 2 * 8 + 8 + 1] = 0;
                A[i * 2 * 8 + 8 + 2] = 0;
                A[i * 2 * 8 + 8 + 3] = XYZ[i][0];
                A[i * 2 * 8 + 8 + 4] = XYZ[i][1];
                A[i * 2 * 8 + 8 + 5] = XYZ[i][2];
                A[i * 2 * 8 +8+ 6] = -uv[i][1] * XYZ[i][0];
                A[i * 2 * 8 +8+ 7] = -uv[i][1] * XYZ[i][1];

            }

            double[] B = new double[uv.Count*2];
            for (int i = 0; i < uv.Count; i++)
            {
                B[i * 2] = uv[i][0] * XYZ[i][2];
                B[i * 2 + 1] = uv[i][1] * XYZ[i][2];
            }

            Console.WriteLine("Solve problem A*X=B: ");
            Console.WriteLine("Matrix A: ");
            for (int i = 0; i < uv.Count * 2; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(A[i * 8 + j] + " ");
                }
            }

            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Matrix B: ");
            for (int i = 0; i < B.Length; i++)
            {
                Console.WriteLine(B[i]);
            }




            var a = Matrix.Create(uv.Count * 2, 8, A, MatrixElementOrder.RowMajor);
            var b = Vector.Create(B);
            var x = a.LeastSquaresSolve(b);
            Console.WriteLine();
            Console.WriteLine("Matrix X: ");
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i]);
            }

            //Homography Matrix ( from scene to image )            
            for (int i = 0; i < x.Length; i++)
                H[i] = x[i];
            H[8] = 1;

            Console.WriteLine();
            Console.WriteLine("Homography Matrix ( from scene to image )");
            for(int i=0;i<3;i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                    Console.Write(H[i * 3 + j] + " ");
            }

            //Homography Matrix ( from image to scene )
            var h = Matrix.Create(3, 3, H, MatrixElementOrder.RowMajor);
            var hinv = h.GetInverse();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Hinv[i * 3 + j] = hinv[i, j];

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Homography Matrix ( from image to scene )");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                    Console.Write(Hinv[i * 3 + j] + " ");
            }

        }

        private void refHeightPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in editToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            uv.Clear();
            XYZ.Clear();
            refHeightPointToolStripMenuItem.Checked = true;
            Console.WriteLine();
            Console.WriteLine("Please FIRST specify one point on Z=0 plane then specify another point off of that plane: ");
        }

        private void calculateAlphaZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Calculate AlphaZ: ");
            Console.WriteLine();
            var p1 = Vector.Create(new double[3] { H[0], H[3], H[6] });
            var p2 = Vector.Create(new double[3] { H[1], H[4], H[7] });
            var o = Vector.Create(new double[3] { H[2], H[5], H[8] });   
            var b = Vector.Create(new double[3] { uv[0][0], uv[0][1], 1 });//on plane point
            var r = Vector.Create(new double[3] { uv[1][0], uv[1][1], 1 });//off plane point
            var vz = Vector.Create(new double[3] { ZV[0], ZV[1], 1 });
            deltaZ=XYZ[1][2]-XYZ[0][2];
            double numerator = -o.DotProduct(p1.CrossProduct(p2)) * (b.CrossProduct(r).Norm());
            double denominator = deltaZ * b.DotProduct(p1.CrossProduct(p2)) * (vz.CrossProduct(r).Norm());
            AlphaZ = numerator / denominator;
            if ((r[1]-b[1])*vz[1]<0)
                AlphaZ = -Math.Abs(AlphaZ);
            else
                AlphaZ = Math.Abs(AlphaZ);
            bref[0] = uv[0][0];
            bref[1] = uv[0][1];
            rref[0] = uv[1][0];
            rref[1] = uv[1][1];
            Console.WriteLine(AlphaZ);
            
        }


        private void calculate3DPositionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in editToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            calculate3DPositionToolStripMenuItem1.Checked = true;
            
            pic = pic_backup.Clone();
            pictureBox1.Image = pic.ToBitmap();

            //draw line of the coordinate system

            uv.Clear();
            XYZ.Clear();
            Console.WriteLine("Please pick up all the points which will be used to form polygons later. Start from one point in the reference plane.");
        }

        private void polygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in editToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            pic = pic_backup.Clone();
            for (int i = 0; i < uv.Count; i++)
            {
                Cross2DF cross = new Cross2DF(new Point((int)uv[i][0], (int)uv[i][1]), 6, 6);
                pic.Draw(cross, new Bgr(255, 255, 255), 1);
            }
            pictureBox1.Image = pic.ToBitmap();      
            polygonToolStripMenuItem.Checked = true;
            vertex.Clear();
            Console.WriteLine();
            Console.WriteLine("Please select vertices to form a polygon (anticlockwise): ");
            //Console.WriteLine("Please select 4 point to form a polygon (from the left bottom point and anticlockwise): ");
        }

        private void textureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get the texture
            var vz = Vector.Create(ZV[0], ZV[1], 1);
            double[] H_temp = new double[9];
            int scale = 100;
            for (int i = 0; i < 9; i++)
            {
                H_temp[i] = H[i];               
            }

            //if (vertex.Count == 4)
            //{
            int vertex_num = vertex.Count;

            var vertex1 = Vector.Create(vertex[0][0], vertex[0][1], vertex[0][2]);
            var vertex2 = Vector.Create(vertex[1][0], vertex[1][1], vertex[1][2]);
            //var vertex3 = Vector.Create(vertex[2][0], vertex[2][1], vertex[2][2]);
            var vertex4 = Vector.Create(vertex[vertex_num-1][0], vertex[vertex_num-1][1], vertex[vertex_num-1][2]);

            
            var ex = (vertex2 - vertex1) / (vertex2 - vertex1).Norm();
            var s = (vertex4 - vertex1).DotProduct(ex) * ex;
            var t = vertex4 - vertex1 - s;
            var ey = t / t.Norm();

            //convert all the 3D points to plane coordinate
                //var uv1 = Vector.Create((vertex1 - vertex1).DotProduct(ex), (vertex1 - vertex1).DotProduct(ey));
                //var uv2 = Vector.Create((vertex2 - vertex1).DotProduct(ex), (vertex2 - vertex1).DotProduct(ey));
                //var uv3 = Vector.Create((vertex3 - vertex1).DotProduct(ex), (vertex3 - vertex1).DotProduct(ey));
                //var uv4 = Vector.Create((vertex4 - vertex1).DotProduct(ex), (vertex4 - vertex1).DotProduct(ey));

            double[,] uv = new double[vertex_num, 2];
            double u_min = 0;
            double u_max = 0;
            double v_min = 0;
            double v_max = 0;
            for (int i = 0; i < vertex_num; i++)
            {
                uv[i, 0] = (vertex[i][0] - vertex[0][0]) * ex[0] + (vertex[i][1] - vertex[0][1]) * ex[1] + (vertex[i][2] - vertex[0][2]) * ex[2];
                uv[i, 1] = (vertex[i][0] - vertex[0][0]) * ey[0] + (vertex[i][1] - vertex[0][1]) * ey[1] + (vertex[i][2] - vertex[0][2]) * ey[2];
                if (uv[i, 0] < u_min) u_min = uv[i, 0];
                if (uv[i, 0] > u_max) u_max = uv[i, 0];
                if (uv[i, 1] < v_min) v_min = uv[i, 1];
                if (uv[i, 1] > v_max) v_max = uv[i, 1];
            }


                //double u_min = Math.Min(Math.Min(uv1[0], uv2[0]), Math.Min(uv3[0], uv4[0]));
                //double u_max = Math.Max(Math.Max(uv1[0], uv2[0]), Math.Max(uv3[0], uv4[0]));
                //double v_min = Math.Min(Math.Min(uv1[1], uv2[1]), Math.Min(uv3[1], uv4[1]));
                //double v_max = Math.Max(Math.Max(uv1[1], uv2[1]), Math.Max(uv3[1], uv4[1]));


          //texture coordinate

                //double[] texture_uv1 = new double[2] { (uv1[0] - u_min) / (u_max - u_min), (uv1[1] - v_min) / (v_max - v_min) };
                //double[] texture_uv2 = new double[2] { (uv2[0] - u_min) / (u_max - u_min), (uv2[1] - v_min) / (v_max - v_min) };
                //double[] texture_uv3 = new double[2] { (uv3[0] - u_min) / (u_max - u_min), (uv3[1] - v_min) / (v_max - v_min) };
                //double[] texture_uv4 = new double[2] { (uv4[0] - u_min) / (u_max - u_min), (uv4[1] - v_min) / (v_max - v_min) };
            double[,] texture_coor = new double[vertex_num, 2];
            for (int i = 0; i < vertex_num; i++)
            {
                texture_coor[i, 0] = (uv[i, 0] - u_min) / (u_max - u_min);
                texture_coor[i, 1] = (uv[i, 1] - v_min) / (v_max - v_min);
            }


                Image<Bgra, Byte> texture = new Image<Bgra, Byte>((int)(Math.Round(u_max * scale - u_min * scale)), (int)(Math.Round(v_max * scale - v_min * scale)),new Bgra(0,0,0,255));
                Image<Gray, Byte> texture_mask = new Image<Gray, Byte>(texture.Cols, texture.Rows,new Gray(0));
                
                //specify the area

                //var point1 = new Point((int)(Math.Max(texture_uv1[0] * texture.Cols - 1, 0)), (int)(Math.Max(texture_uv1[1] * texture.Rows - 1, 0)));
                //var point2 = new Point((int)(Math.Max(texture_uv2[0] * texture.Cols - 1, 0)), (int)(Math.Max(texture_uv2[1] * texture.Rows - 1, 0)));
                //var point3 = new Point((int)(Math.Max(texture_uv3[0] * texture.Cols - 1, 0)), (int)(Math.Max(texture_uv3[1] * texture.Rows - 1, 0)));
                //var point4 = new Point((int)(Math.Max(texture_uv4[0] * texture.Cols - 1, 0)), (int)(Math.Max(texture_uv4[1] * texture.Rows - 1, 0)));

                Point[] points = new Point[vertex_num];
                for (int i = 0; i < vertex_num; i++)
                {
                    points[i] = new Point((int)(Math.Max(texture_coor[i,0] * texture.Cols - 1, 0)), (int)(Math.Max(texture_coor[i,1] * texture.Rows - 1, 0)));
                }

                    texture_mask.FillConvexPoly(points, new Gray(255));


                


                
                
                for (int row = 0; row < texture.Rows; row++)
                    for (int col = 0; col < texture.Cols; col++)
                    {
                        var uv_temp = Vector.Create((double)(col+1) / (double)texture.Cols*(u_max-u_min)+u_min, (double)(row+1) / (double)texture.Rows*v_max);

                        //if (uv2.Angle(uv) <= uv2.Angle(uv4) && (uv - uv4).Angle(uv4) >= uv4.Angle(uv3 - uv4) && uv2.Angle(uv - uv2) >= uv2.Angle(uv3 - uv2))
                        //{
                        //    var XYZ3D = uv[0] * ex + uv[1] * ey + vertex1;

                        //    for (int i = 2; i < 9; i = i + 3)
                        //    {
                        //        H_temp[i] = H[i] + AlphaZ * vz[(i - 2) / 3] * XYZ3D[2];
                        //    }
                        //    //get image position
                        //    double[] image = new double[3];
                        //    for (int i = 0; i < 3; i++)
                        //    {
                        //        image[i] = H_temp[i * 3] * XYZ3D[0] + H_temp[i * 3 + 1] * XYZ3D[1] + H_temp[i * 3 + 2] * 1;
                        //    }
                        //    image[0] = image[0] / image[2]; //col
                        //    image[1] = image[1] / image[2]; //row

                        //    double[] pixel = new double[3];
                        //    if (image[1] <= pic.Rows - 1 && image[0] <= pic.Cols - 1 && image[0] >= 0 && image[1] >= 0)
                        //    {
                        //        //for (int i = 0; i < 3; i++)
                        //        //    texture.Data[row, col, i] = pic.Data[(int)image[1], (int)image[0], i];
                        //        pixel = bilinear(image);
                        //        texture.Data[row, col, 0] = (byte)pixel[0];
                        //        texture.Data[row, col, 1] = (byte)pixel[1];
                        //        texture.Data[row, col, 2] = (byte)pixel[2];
                        //        texture.Data[row, col, 3] = 255;
                        //    }


                        //}
                        //else
                        //{
                        //    texture.Data[row, col, 0] = 0;
                        //    texture.Data[row, col, 1] = 0;
                        //    texture.Data[row, col, 2] = 0;
                        //    texture.Data[row, col, 3] = 0;
                        //}


                        if (texture_mask.Data[row, col, 0] == 255)
                        {
                            var XYZ3D = uv_temp[0] * ex + uv_temp[1] * ey + vertex1;
                            for (int i = 2; i < 9; i = i + 3)
                            {
                                H_temp[i] = H[i] + AlphaZ * vz[(i - 2) / 3] * XYZ3D[2];
                            }
                            //get image position
                            double[] image = new double[3];
                            for (int i = 0; i < 3; i++)
                            {
                                image[i] = H_temp[i * 3] * XYZ3D[0] + H_temp[i * 3 + 1] * XYZ3D[1] + H_temp[i * 3 + 2] * 1;
                            }
                            image[0] = image[0] / image[2]; //col
                            image[1] = image[1] / image[2]; //row

                            double[] pixel = new double[3];
                            if (image[1] < pic.Rows && image[0] < pic.Cols)
                            {
                                //for (int i = 0; i < 3; i++)
                                //    texture.Data[row, col, i] = pic.Data[(int)image[1], (int)image[0], i];
                                pixel = bilinear(image);
                                texture.Data[row, col, 0] = (byte)pixel[0];
                                texture.Data[row, col, 1] = (byte)pixel[1];
                                texture.Data[row, col, 2] = (byte)pixel[2];
                                texture.Data[row, col, 3] = 255;
                            }
                        }

                        else
                        {
                            texture.Data[row, col, 0] = 0;
                            texture.Data[row, col, 1] = 0;
                            texture.Data[row, col, 2] = 0;
                            texture.Data[row, col, 3] = 0;
                        }

                        




                    }



                Form3 frm = new Form3();
                texture = texture.Flip(Emgu.CV.CvEnum.FlipType.Vertical);
                frm.pictureBox1.Image = texture.ToBitmap();
                frm.ShowDialog();

                if (frm.save_flag == true)
                {
                    //vrml.Add(frm.filename, new double[]{
                    //vertex[0][0], vertex[0][1], vertex[0][2], //3D coordinate
                    //vertex[1][0], vertex[1][1], vertex[1][2],
                    //vertex[2][0], vertex[2][1], vertex[2][2],
                    //vertex[3][0], vertex[3][1], vertex[3][2],
                    //texture_uv1[0],texture_uv1[1],
                    //texture_uv2[0],texture_uv2[1],
                    //texture_uv3[0],texture_uv3[1],
                    //texture_uv4[0],texture_uv4[1]
                    double[] p = new double[vertex_num * 5];
                    for (int i = 0; i < vertex_num; i++)
                        for (int j = 0; j < 3; j++)
                        {
                            p[i * 3 + j] = vertex[i][j];
                        }
                    for(int i=0;i<vertex_num;i++)
                        for (int j = 0; j < 2; j++)
                        {
                            p[vertex_num * 3 + i * 2 + j] = texture_coor[i, j];
                        }
                    if (vrml.ContainsKey(frm.filename))
                    {
                        vrml.Remove(frm.filename);
                    }
                    vrml.Add(frm.filename, p);
                }
                


        }




        double[] bilinear(double[] pos)
        {
            Image<Bgr,Byte> img=pic_backup.Clone();
            double[] pixel = new double[3];
            int x1 = (int)Math.Floor(pos[0]);
            int x2 = (int)Math.Ceiling(pos[0]);
            int y1 = (int)Math.Floor(pos[1]);
            int y2 = (int)Math.Ceiling(pos[1]);
            


            //int[] Q11 = new int[2] { (int)Math.Floor(pos[0]), (int)Math.Floor(pos[1]) };
            //int[] Q21 = new int[2] { (int)Math.Ceiling(pos[0]), (int)Math.Floor(pos[1]) };
            //int[] Q12 = new int[2] { (int)Math.Floor(pos[0]), (int)Math.Ceiling(pos[1]) };
            //int[] Q22 = new int[2] { (int)Math.Ceiling(pos[0]), (int)Math.Ceiling(pos[1]) };
            //x1 Q11[0] y1 Q11[1]
            //x2 Q22[0] y2 Q22[1]



            for (int i = 0; i < 3; i++)
            {
                //pixel[i] = 1 / (double)((Q22[0] - Q11[0]) * (Q22[1] - Q11[1])) * (
                //    img.Data[Q11[1], Q11[0], i] * (Q22[0] - pos[0]) * (Q22[1] - pos[1]) +
                //    img.Data[Q21[1], Q21[0], i] * (pos[0] - Q11[0]) * (Q22[1] - pos[1]) +
                //    img.Data[Q12[1], Q12[0], i] * (Q22[0] - pos[0]) * (pos[1] - Q11[1]) +
                //    img.Data[Q22[1], Q22[0], i] * (pos[0] - Q11[0]) * (pos[1] - Q11[1])
                //    );
                pixel[i] = 1 / (double)((x2 - x1) * (y2 - y1)) * (
                    img.Data[y1, x1, i] * (x2 - pos[0]) * (y2 - pos[1]) +
                    img.Data[y1, x2, i] * (pos[0] - x1) * (y2 - pos[1]) +
                    img.Data[y2, x1, i] * (x2 - pos[0]) * (pos[1] - y1) +
                    img.Data[y2, x2, i] * (pos[0] - x1) * (pos[1] - y1)
                    );
            }
            return pixel;
        }

        private void saveVrmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save VRML Model";
            //sfd.ShowDialog();
            sfd.Filter = "VRML FILE|*.wrl";
            int vertex_num = 0;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter model = File.CreateText(sfd.FileName))
                {
                    model.WriteLine("#VRML V2.0 utf8");
                    model.WriteLine();
                    model.WriteLine("Collision {");
                    model.WriteLine("collide FALSE");
                    model.WriteLine("children [");
                    foreach(KeyValuePair<string,double[]> kvp in vrml)
                    {
                        vertex_num = kvp.Value.Length / 5;
                        model.WriteLine("Shape {");
                        model.WriteLine("appearance Appearance {");
                        model.WriteLine("texture ImageTexture { url \"" + kvp.Key + "\" }");
                        model.WriteLine("}");

                        model.WriteLine("geometry IndexedFaceSet {");

                        model.WriteLine("coord Coordinate {");
                        model.WriteLine("point [");
                        
                        //model.WriteLine(kvp.Value[0] + " " + kvp.Value[1] + " " + kvp.Value[2] + ",");
                        //model.WriteLine(kvp.Value[3] + " " + kvp.Value[4] + " " + kvp.Value[5] + ",");
                        //model.WriteLine(kvp.Value[6] + " " + kvp.Value[7] + " " + kvp.Value[8] + ",");
                        //model.WriteLine(kvp.Value[9] + " " + kvp.Value[10] + " " + kvp.Value[11] + ",");

                        for (int i = 0; i < vertex_num; i++)
                            model.WriteLine(kvp.Value[i * 3] + " " + kvp.Value[i * 3 + 1] + " " + kvp.Value[i * 3 + 2] + ",");

                        model.WriteLine("] }");

                        //model.WriteLine("coordIndex [ 0, 1, 2, 3, -1,]");
                        model.WriteLine("coordIndex [");
                        for (int i = 0; i < vertex_num; i++)
                            model.WriteLine(i + " , ");
                        model.WriteLine("-1 , ]");

                        model.WriteLine("texCoord TextureCoordinate {");
                        model.WriteLine("point [");

                        //model.WriteLine(kvp.Value[12] + " " + kvp.Value[13] + ",");
                        //model.WriteLine(kvp.Value[14] + " " + kvp.Value[15] + ",");
                        //model.WriteLine(kvp.Value[16] + " " + kvp.Value[17] + ",");
                        //model.WriteLine(kvp.Value[18] + " " + kvp.Value[19] + ",");
                        for (int i = 0; i < vertex_num; i++)
                            model.WriteLine(kvp.Value[vertex_num * 3 + i * 2] + " " + kvp.Value[vertex_num * 3 + i * 2 + 1] + ",");
                        
                        model.WriteLine("] }");

                        //model.WriteLine("texCoordIndex [0, 1, 2, 3, -1,]");
                        model.WriteLine("texCoordIndex [");
                        for (int i = 0; i < vertex_num; i++)
                            model.WriteLine(i + " , ");
                        model.WriteLine("-1 , ]");

                        model.WriteLine("solid FALSE");
                        model.WriteLine("}");
                        model.WriteLine("}");
                    }

                    model.WriteLine("]");
                    model.WriteLine("}");

                }
                Console.WriteLine("Save VRML Model Done!");
                

            }

        
        
        
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string name = openfile.FileName;
                pic = new Image<Bgr, Byte>(name);
                pictureBox1.Image = pic.ToBitmap();
                pic_backup = pic.Clone();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(calculate3DPositionToolStripMenuItem1.Checked==true &&uv.Count>0)
            {
                Console.WriteLine("Remove Image Point (" + uv[uv.Count - 1][0] + " , " + uv[uv.Count - 1][1] + " )");
                uv.Remove(uv[uv.Count - 1]);
                XYZ.Remove(XYZ[XYZ.Count - 1]);
                pic = pic_backup.Clone();
                foreach (double[] item in uv)
                {
                    Cross2DF cross = new Cross2DF(new Point((int)item[0], (int)item[1]), 6, 6);
                    pic.Draw(cross, new Bgr(255, 255, 255), 1);
                }
                pictureBox1.Image = pic.ToBitmap(); 
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //come back to Z=0 plane
            Z = 0;
            Console.WriteLine("Come back to Z=0 Plane.");
        }

        private void guidelinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guidelinesToolStripMenuItem.Checked == false)
            {
                foreach (ToolStripMenuItem item in editToolStripMenuItem.DropDownItems)
                {
                    //if (item != xGuidelinesToolStripMenuItem && item!=yGuidelineToolStripMenuItem)
                    
                        item.Checked = false;
                    
                    
                }
                guidelinesToolStripMenuItem.Checked = true;
                calculate3DPositionToolStripMenuItem1.Checked = true;
            }
            else
            {
                guidelinesToolStripMenuItem.Checked = false;
                pic = pic_backup.Clone();
                foreach (double[] item in uv)
                {
                    Cross2DF cross = new Cross2DF(new Point((int)item[0], (int)item[1]), 6, 6);
                    pic.Draw(cross, new Bgr(255, 255, 255), 1);
                }
                pictureBox1.Image = pic.ToBitmap(); 
            }
            
        }

        private void xGuidelinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (xGuidelinesToolStripMenuItem.Checked == false)
            {
                foreach (ToolStripMenuItem item in editToolStripMenuItem.DropDownItems)
                {
                    //if(item!= guidelinesToolStripMenuItem&& item!=yGuidelineToolStripMenuItem)
                        item.Checked = false;
                }
                xGuidelinesToolStripMenuItem.Checked = true;
                calculate3DPositionToolStripMenuItem1.Checked = true;
            }
            else
            {
                xGuidelinesToolStripMenuItem.Checked = false;
                pic = pic_backup.Clone();
                foreach (double[] item in uv)
                {
                    Cross2DF cross = new Cross2DF(new Point((int)item[0], (int)item[1]), 6, 6);
                    pic.Draw(cross, new Bgr(255, 255, 255), 1);
                }
                pictureBox1.Image = pic.ToBitmap();
            }
        }

        private void yGuidelineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yGuidelineToolStripMenuItem.Checked == false)
            {
                foreach (ToolStripMenuItem item in editToolStripMenuItem.DropDownItems)
                {
                    //if(item!=guidelinesToolStripMenuItem&& item!=xGuidelinesToolStripMenuItem)
                    item.Checked = false;
                }
                yGuidelineToolStripMenuItem.Checked = true;
                calculate3DPositionToolStripMenuItem1.Checked = true;
            }
            else
            {
                yGuidelineToolStripMenuItem.Checked = false;
                pic = pic_backup.Clone();
                foreach (double[] item in uv)
                {
                    Cross2DF cross = new Cross2DF(new Point((int)item[0], (int)item[1]), 6, 6);
                    pic.Draw(cross, new Bgr(255, 255, 255), 1);
                }
                pictureBox1.Image = pic.ToBitmap();
            }
        }

        private void allGuidelinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allGuidelinesToolStripMenuItem.Checked == false)
            {
                foreach (ToolStripMenuItem item in editToolStripMenuItem.DropDownItems)
                {
                    item.Checked = false;
                }
                allGuidelinesToolStripMenuItem.Checked = true;
                calculate3DPositionToolStripMenuItem1.Checked = true;
            }
            else
            {
                allGuidelinesToolStripMenuItem.Checked = false;
                pic = pic_backup.Clone();
                foreach (double[] item in uv)
                {
                    Cross2DF cross = new Cross2DF(new Point((int)item[0], (int)item[1]), 6, 6);
                    pic.Draw(cross, new Bgr(255, 255, 255), 1);
                }
                pictureBox1.Image = pic.ToBitmap();
            }
        }




    }
}
