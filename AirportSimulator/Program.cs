using System;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

//
//  Bermuda Triangle : Version 16
//
public class Form1 : Form
{

    private Container components = null;
    private ButtonPanelThread p1;
    private Label lbl1, lbl2, lbl3;
    private Button btn1, btn2, btn3, btn4, btn5;
    private RadioButton rbtn0, rbtn1, rbtn2, rbtn3;
    private UltraPanelThread up1, up2, up3, uwp1, uwp2, uwp3, uwp4, uwp5, uwp6;
    private Thread thread1, thread2, thread3, thread4, thread5, thread6, thread7, thread8, thread9, thread10;
    private Semaphore semaphore, semaphore2, semaphore3, semaphore4, semaphore5, semaphore6, semaphore7, semaphore8, semaphore9;
    private Buffer buffer, buffer2, buffer3, buffer4, buffer5, buffer6, buffer7, buffer8, buffer9;
    private Thread semThread, semThread2, semThread3, semThread4, semThread5, semThread6, semThread7, semThread8, semThread9;
    private Thread buffThread, buffThread2, buffThread3, buffThread4, buffThread5, buffThread6, buffThread7, buffThread8, buffThread9;
    private Panel pnl1, pnl2, pnl3, pnl4, pnl5, pnl6, pnl7, pnl8, pnl9, pnl10, rbpnl;
  
    public Form1()
    {
        InitializeComponent();
        semaphore = new Semaphore();
        buffer = new Buffer();
        semaphore2 = new Semaphore();
        buffer2 = new Buffer();
        semaphore3 = new Semaphore();
        buffer3 = new Buffer();
        semaphore4 = new Semaphore();
        buffer4 = new Buffer();
        semaphore5 = new Semaphore();
        buffer5 = new Buffer();
        semaphore6 = new Semaphore();
        buffer6 = new Buffer();
        semaphore7 = new Semaphore();
        buffer7 = new Buffer();
        semaphore8 = new Semaphore();
        buffer8 = new Buffer();
        semaphore9 = new Semaphore();
        buffer9 = new Buffer();

        Random randomGen = new Random();
        KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        KnownColor randomColorName = names[randomGen.Next(names.Length)];
        Color randomColor = Color.FromKnownColor(randomColorName);
        if (randomColor.GetBrightness() > 0.9)
        {
            randomColorName = names[randomGen.Next(names.Length)];
            randomColor = Color.FromKnownColor(randomColorName);
        }

        up1 = new UltraPanelThread(new Point(10, 35),
                                    120, pnl1, true, true,
                                    Color.Blue, btn1, true,
                                    semaphore, buffer, semaphore4,
                                    buffer4, semaphore4, buffer4,
                                    10, 5, 1);

        up2 = new UltraPanelThread(new Point(10, 35),
                                    150, pnl2, true, true,
                                    Color.Yellow, btn2, true,
                                    semaphore2, buffer2, semaphore6,
                                    buffer6, semaphore6, buffer6,
                                    10, 4, 2);

        up3 = new UltraPanelThread(new Point(10, 35),
                                    250, pnl3, true, true,
                                    Color.Red, btn3, true,
                                    semaphore3, buffer3, semaphore5,
                                    buffer5, semaphore5, buffer5,
                                    10, 8, 3);

        p1 = new ButtonPanelThread(new Point(65, 10),
                             150, true, false, pnl10,
                             randomColor,
                             semaphore8,
                             buffer8,
                             btn4,
                             true, false, 10);

        uwp1 = new UltraPanelThread(new Point(0, 10),
                                    100, pnl4, false, false,
                                    Color.White, btn5, false,
                                    semaphore4, buffer4, semaphore5,
                                    buffer5, semaphore3, buffer3,
                                    16, 9, 4);

        uwp2 = new UltraPanelThread(new Point(0, 10),
                                   100, pnl5, false, false,
                                   Color.White, btn5, false,
                                   semaphore5, buffer5, semaphore6,
                                   buffer6, semaphore2, buffer2,
                                   16, 9, 5);

        uwp3 = new UltraPanelThread(new Point(0, 10),
                                   100, pnl6, false, false,
                                   Color.White, btn5, false,
                                   semaphore6, buffer6, semaphore7,
                                   buffer7, semaphore7, buffer7,
                                   16, 9, 6);

        uwp4 = new UltraPanelThread(new Point(10, 5),
                                   100, pnl7, true, true,
                                   Color.White, btn5, false,
                                   semaphore7, buffer7, semaphore8,
                                   buffer8, semaphore8, buffer8,
                                   15, 9, 7);

        uwp5 = new UltraPanelThread(new Point(595, 10),
                                   50, pnl9, true, false,
                                   Color.White, btn5, false,
                                   semaphore8, buffer8, semaphore9,
                                   buffer9, semaphore9, buffer9,
                                   53, 9, 10);

        uwp6 = new UltraPanelThread(new Point(10, 140),
                                   100, pnl8, false, true,
                                   Color.White, btn5, false,
                                   semaphore9, buffer9, semaphore4,
                                   buffer4, semaphore, buffer,
                                   13, 9, 8);

        semThread = new Thread(new ThreadStart(semaphore.Start));
        buffThread = new Thread(new ThreadStart(buffer.Start));
        semThread2 = new Thread(new ThreadStart(semaphore2.Start));
        buffThread2 = new Thread(new ThreadStart(buffer2.Start));
        semThread3 = new Thread(new ThreadStart(semaphore3.Start));
        buffThread3 = new Thread(new ThreadStart(buffer3.Start));
        semThread4 = new Thread(new ThreadStart(semaphore4.Start));
        buffThread4 = new Thread(new ThreadStart(buffer4.Start));
        semThread5 = new Thread(new ThreadStart(semaphore5.Start));
        buffThread5 = new Thread(new ThreadStart(buffer5.Start));
        semThread6 = new Thread(new ThreadStart(semaphore6.Start));
        buffThread6 = new Thread(new ThreadStart(buffer6.Start));
        semThread7 = new Thread(new ThreadStart(semaphore7.Start));
        buffThread7 = new Thread(new ThreadStart(buffer7.Start));
        semThread8 = new Thread(new ThreadStart(semaphore8.Start));
        buffThread8 = new Thread(new ThreadStart(buffer8.Start));
        semThread9 = new Thread(new ThreadStart(semaphore9.Start));
        buffThread9 = new Thread(new ThreadStart(buffer9.Start));
        thread1 = new Thread(new ThreadStart(up1.Start));
        thread2 = new Thread(new ThreadStart(up2.Start));
        thread3 = new Thread(new ThreadStart(up3.Start));
        thread4 = new Thread(new ThreadStart(uwp1.Start));
        thread5 = new Thread(new ThreadStart(uwp2.Start));
        thread6 = new Thread(new ThreadStart(uwp3.Start));
        thread7 = new Thread(new ThreadStart(uwp4.Start));
        thread8 = new Thread(new ThreadStart(uwp5.Start));
        thread9 = new Thread(new ThreadStart(uwp6.Start));
        thread10 = new Thread(new ThreadStart(p1.Start));
        
        this.Closing += new CancelEventHandler(this.Form1_Closing);

        semThread.Start();
        buffThread.Start();
        semThread2.Start();
        buffThread2.Start();
        semThread3.Start();
        buffThread3.Start();
        semThread4.Start();
        buffThread4.Start();
        semThread5.Start();
        buffThread5.Start();
        semThread6.Start();
        buffThread6.Start();
        semThread7.Start();
        buffThread7.Start();
        semThread8.Start();
        buffThread8.Start();
        semThread9.Start();
        buffThread9.Start();
        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();
        thread5.Start();
        thread6.Start();
        thread7.Start();
        thread8.Start();
        thread9.Start();
        thread10.Start();
       
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
                components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.pnl1 = new System.Windows.Forms.Panel();
            this.btn1 = new System.Windows.Forms.Button();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.btn2 = new System.Windows.Forms.Button();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.pnl4 = new System.Windows.Forms.Panel();
            this.pnl5 = new System.Windows.Forms.Panel();
            this.pnl6 = new System.Windows.Forms.Panel();
            this.pnl7 = new System.Windows.Forms.Panel();
            this.pnl8 = new System.Windows.Forms.Panel();
            this.pnl9 = new System.Windows.Forms.Panel();
            this.pnl10 = new System.Windows.Forms.Panel();
            this.btn4 = new System.Windows.Forms.Button();
            this.rbpnl = new System.Windows.Forms.Panel();
            this.rbtn0 = new System.Windows.Forms.RadioButton();
            this.rbtn1 = new System.Windows.Forms.RadioButton();
            this.rbtn2 = new System.Windows.Forms.RadioButton();
            this.rbtn3 = new System.Windows.Forms.RadioButton();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.pnl10.SuspendLayout();
            this.rbpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.White;
            this.pnl1.Controls.Add(this.btn1);
            this.pnl1.Location = new System.Drawing.Point(50, 50);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(30, 150);
            this.pnl1.TabIndex = 0;
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.Pink;
            this.btn1.Location = new System.Drawing.Point(0, 0);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(30, 30);
            this.btn1.TabIndex = 0;
            this.btn1.UseVisualStyleBackColor = false;
            // 
            // pnl2
            // 
            this.pnl2.BackColor = System.Drawing.Color.White;
            this.pnl2.Controls.Add(this.btn2);
            this.pnl2.Location = new System.Drawing.Point(400, 50);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(30, 150);
            this.pnl2.TabIndex = 1;
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.Pink;
            this.btn2.Location = new System.Drawing.Point(0, 0);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(30, 30);
            this.btn2.TabIndex = 0;
            this.btn2.UseVisualStyleBackColor = false;
            // 
            // pnl3
            // 
            this.pnl3.BackColor = System.Drawing.Color.White;
            this.pnl3.Controls.Add(this.btn3);
            this.pnl3.Controls.Add(this.btn5);
            this.pnl3.Location = new System.Drawing.Point(225, 50);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(30, 150);
            this.pnl3.TabIndex = 2;
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.Pink;
            this.btn3.Location = new System.Drawing.Point(0, 0);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(30, 30);
            this.btn3.TabIndex = 0;
            this.btn3.UseVisualStyleBackColor = false;
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.White;
            this.btn5.Location = new System.Drawing.Point(0, 0);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(0, 0);
            this.btn5.TabIndex = 0;
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Visible = false;
            // 
            // pnl4
            // 
            this.pnl4.BackColor = System.Drawing.Color.White;
            this.pnl4.Location = new System.Drawing.Point(50, 200);
            this.pnl4.Name = "pnl4";
            this.pnl4.Size = new System.Drawing.Size(175, 30);
            this.pnl4.TabIndex = 3;
            // 
            // pnl5
            // 
            this.pnl5.BackColor = System.Drawing.Color.White;
            this.pnl5.Location = new System.Drawing.Point(225, 200);
            this.pnl5.Name = "pnl5";
            this.pnl5.Size = new System.Drawing.Size(175, 30);
            this.pnl5.TabIndex = 4;
            // 
            // pnl6
            // 
            this.pnl6.BackColor = System.Drawing.Color.White;
            this.pnl6.Location = new System.Drawing.Point(400, 200);
            this.pnl6.Name = "pnl6";
            this.pnl6.Size = new System.Drawing.Size(175, 30);
            this.pnl6.TabIndex = 5;
            // 
            // pnl7
            // 
            this.pnl7.BackColor = System.Drawing.Color.White;
            this.pnl7.Location = new System.Drawing.Point(575, 200);
            this.pnl7.Name = "pnl7";
            this.pnl7.Size = new System.Drawing.Size(30, 175);
            this.pnl7.TabIndex = 6;
            // 
            // pnl8
            // 
            this.pnl8.BackColor = System.Drawing.Color.White;
            this.pnl8.Location = new System.Drawing.Point(50, 230);
            this.pnl8.Name = "pnl8";
            this.pnl8.Size = new System.Drawing.Size(30, 145);
            this.pnl8.TabIndex = 7;
            // 
            // pnl9
            // 
            this.pnl9.BackColor = System.Drawing.Color.White;
            this.pnl9.Location = new System.Drawing.Point(0, 375);
            this.pnl9.Name = "pnl9";
            this.pnl9.Size = new System.Drawing.Size(605, 30);
            this.pnl9.TabIndex = 8;
            // 
            // pnl10
            // 
            this.pnl10.BackColor = System.Drawing.Color.White;
            this.pnl10.Controls.Add(this.btn4);
            this.pnl10.Location = new System.Drawing.Point(605, 375);
            this.pnl10.Name = "pnl10";
            this.pnl10.Size = new System.Drawing.Size(110, 30);
            this.pnl10.TabIndex = 0;
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.Pink;
            this.btn4.Location = new System.Drawing.Point(80, 0);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(30, 30);
            this.btn4.TabIndex = 0;
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            this.btn4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn4_MouseClick);
            // 
            // rbpnl
            // 
            this.rbpnl.BackColor = System.Drawing.Color.Silver;
            this.rbpnl.Controls.Add(this.rbtn0);
            this.rbpnl.Controls.Add(this.rbtn1);
            this.rbpnl.Controls.Add(this.rbtn2);
            this.rbpnl.Controls.Add(this.rbtn3);
            this.rbpnl.Location = new System.Drawing.Point(650, 275);
            this.rbpnl.Name = "rbpnl";
            this.rbpnl.Size = new System.Drawing.Size(60, 100);
            this.rbpnl.TabIndex = 9;
            // 
            // rbtn0
            // 
            this.rbtn0.Checked = true;
            this.rbtn0.Location = new System.Drawing.Point(0, 0);
            this.rbtn0.Name = "rbtn0";
            this.rbtn0.Size = new System.Drawing.Size(104, 24);
            this.rbtn0.TabIndex = 0;
            this.rbtn0.TabStop = true;
            this.rbtn0.Text = "0";
            this.rbtn0.CheckedChanged += new System.EventHandler(this.rbtn0_CheckedChanged);
            // 
            // rbtn1
            // 
            this.rbtn1.Location = new System.Drawing.Point(0, 25);
            this.rbtn1.Name = "rbtn1";
            this.rbtn1.Size = new System.Drawing.Size(104, 24);
            this.rbtn1.TabIndex = 1;
            this.rbtn1.Text = "1";
            this.rbtn1.CheckedChanged += new System.EventHandler(this.rbtn1_CheckedChanged);
            // 
            // rbtn2
            // 
            this.rbtn2.Location = new System.Drawing.Point(0, 50);
            this.rbtn2.Name = "rbtn2";
            this.rbtn2.Size = new System.Drawing.Size(104, 24);
            this.rbtn2.TabIndex = 2;
            this.rbtn2.Text = "2";
            this.rbtn2.CheckedChanged += new System.EventHandler(this.rbtn2_CheckedChanged);
            // 
            // rbtn3
            // 
            this.rbtn3.Location = new System.Drawing.Point(0, 75);
            this.rbtn3.Name = "rbtn3";
            this.rbtn3.Size = new System.Drawing.Size(104, 24);
            this.rbtn3.TabIndex = 3;
            this.rbtn3.Text = "3";
            this.rbtn3.CheckedChanged += new System.EventHandler(this.rbtn3_CheckedChanged);
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.Silver;
            this.lbl1.Font = new System.Drawing.Font("Georgia", 16F);
            this.lbl1.Location = new System.Drawing.Point(90, 53);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(20, 30);
            this.lbl1.TabIndex = 10;
            this.lbl1.Text = "1";
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.Color.Silver;
            this.lbl2.Font = new System.Drawing.Font("Georgia", 16F);
            this.lbl2.Location = new System.Drawing.Point(265, 53);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(20, 30);
            this.lbl2.TabIndex = 11;
            this.lbl2.Text = "2";
            // 
            // lbl3
            // 
            this.lbl3.BackColor = System.Drawing.Color.Silver;
            this.lbl3.Font = new System.Drawing.Font("Georgia", 16F);
            this.lbl3.Location = new System.Drawing.Point(445, 53);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(20, 30);
            this.lbl3.TabIndex = 12;
            this.lbl3.Text = "3";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.pnl3);
            this.Controls.Add(this.pnl4);
            this.Controls.Add(this.pnl5);
            this.Controls.Add(this.pnl6);
            this.Controls.Add(this.pnl7);
            this.Controls.Add(this.pnl8);
            this.Controls.Add(this.pnl9);
            this.Controls.Add(this.pnl10);
            this.Controls.Add(this.rbpnl);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl3);
            this.Name = "Form1";
            this.Text = "ALEX IS AWESOME";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.pnl1.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.pnl3.ResumeLayout(false);
            this.pnl10.ResumeLayout(false);
            this.rbpnl.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void Form1_Closing(object sender, CancelEventArgs e)
    {
        // Environment is a System class.
        // Kill off all threads on exit.
        Environment.Exit(Environment.ExitCode);
    }

    private void NewPlane(int destination)
    {
        this.pnl10.Dispose();
        this.pnl10 = new System.Windows.Forms.Panel();
        this.btn4.Dispose();
        this.btn4 = new System.Windows.Forms.Button();
        this.SuspendLayout();

        Random randomGen = new Random();        
        KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        KnownColor randomColorName = names[randomGen.Next(names.Length)];
        Color randomColor = Color.FromKnownColor(randomColorName);
        if (randomColor.GetBrightness() > 0.9)
        {
            randomColorName = names[randomGen.Next(names.Length)];
            randomColor = Color.FromKnownColor(randomColorName);
        }
        Console.WriteLine("New plane: " + randomColor);

        p1 = new ButtonPanelThread(new Point(65, 10),
                             150, true, false, pnl10,
                             randomColor,
                             semaphore8,
                             buffer8,
                             btn4,
                             true, false, destination);

        this.pnl10.BackColor = System.Drawing.Color.White;
        this.pnl10.Controls.Add(this.btn4);
        this.pnl10.Location = new System.Drawing.Point(605, 375);
        this.pnl10.Name = "pnl10";
        this.pnl10.Size = new System.Drawing.Size(110, 30);
        this.pnl10.TabIndex = 0;

        this.btn4.BackColor = System.Drawing.Color.Pink;
        this.btn4.Location = new System.Drawing.Point(80, 0);
        this.btn4.Name = "btn4";
        this.btn4.Size = new System.Drawing.Size(30, 30);
        this.btn4.TabIndex = 0;
        this.btn4.UseVisualStyleBackColor = false;

        thread10 = new Thread(new ThreadStart(p1.Start));

        this.Controls.Add(this.pnl10);
        thread10.Start();

        this.ResumeLayout(false);

    }


    private void rbtn0_CheckedChanged(object sender, EventArgs e)
    {
        if(rbtn0.Checked == true)
            this.NewPlane(10);
    }

    private void rbtn1_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtn1.Checked == true)
            this.NewPlane(8);
    }

    private void rbtn2_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtn2.Checked == true)
            this.NewPlane(4);
    }

    private void rbtn3_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtn3.Checked == true)
            this.NewPlane(5);
    
    }

    private void btn4_Click(object sender, EventArgs e)
    {
        rbtn0.Checked = false;
        rbtn1.Checked = false;
        rbtn2.Checked = false;
        rbtn3.Checked = false;
    }

    private void btn4_MouseClick(object sender, MouseEventArgs e)
    {
        rbtn0.Checked = false;
        rbtn1.Checked = false;
        rbtn2.Checked = false;
        rbtn3.Checked = false;
    }


}// end class form1


public class Buffer
{
    private Color planeColor;
    private int destination;
    private bool empty = true;

    public void Read(ref Color planeColor, ref int destination)
    {
        lock (this)
        {
            // Check whether the buffer is empty.
            if (empty)
                Monitor.Wait(this);
            empty = true;
            planeColor = this.planeColor;
            destination = this.destination;
            Monitor.Pulse(this);
        }
    }

    public void Write(Color planeColor, int destination)
    {
        lock (this)
        {
            // Check whether the buffer is full.
            if (!empty)
                Monitor.Wait(this);
            empty = false;
            this.planeColor = planeColor;
            this.destination = destination;
            Monitor.Pulse(this);
        }
    }

    public void Start()
    {
    }

}// end class Buffer

public class Semaphore
{
    private int count = 0;

    public void Wait()
    {
        lock (this)
        {
            while (count == 0)
                Monitor.Wait(this);
            count = 0;
        }
    }

    public void Signal()
    {

        lock (this)
        {
            count = 1;
            Monitor.Pulse(this);
        }
    }

    public void Start()
    {
    }

}// end class Semaphore

public class ButtonPanelThread
{
    private Point origin;
    private int delay;
    private Panel panel;
    private bool westEast;
    private bool northSouth;
    private Color colour;
    private Point plane;
    private int xDelta;
    private int yDelta;
    private Semaphore semaphore;
    private Buffer buffer;
    private Button btn;
    private bool locked;
    private bool arriving;
    private int destination; 

    public ButtonPanelThread(Point origin,
                             int delay,
                             bool westEast,
                             bool northSouth,
                             Panel panel,
                             Color colour,
                             Semaphore semaphore,
                             Buffer buffer,
                             Button btn,
                             bool locked,
                             bool arriving,
                             int destination)
    {
        this.origin = origin;
        this.delay = delay;
        this.westEast = westEast;
        this.northSouth = northSouth;
        this.panel = panel;
        this.colour = colour;
        this.plane = origin;
        this.panel.Paint += new PaintEventHandler(this.panel_Paint);
        this.xDelta = northSouth ? 0 : (westEast ? -10 : +10);
        this.yDelta = westEast ? (northSouth ? +10 : 0) : (northSouth ? -10 : 0);
        this.semaphore = semaphore;
        this.buffer = buffer;
        this.btn = btn;
        this.btn.Click += new System.EventHandler(this.btn_Click);
        this.locked = locked;
        this.arriving = arriving;
        this.destination = destination;
    }

    private void btn_Click(object sender,
                           System.EventArgs e)
    {
        locked = !locked;
        this.btn.BackColor = locked ? Color.Pink : Color.LightGreen;
        lock (this)
        {
            if (!locked)
                Monitor.Pulse(this);
        }
    }

    public void Start()
    {
        Color signal = Color.White;
        for (int k = 1; k <= 1; k++)
        {
            this.zeroPlane();
            panel.Invalidate();
            lock (this)
            {
                while (locked)
                {
                    Monitor.Wait(this);
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                this.movePlane(xDelta, yDelta);
                Thread.Sleep(delay);
                panel.Invalidate();
            }
            if (!arriving)
            {
                semaphore.Wait();
                buffer.Write(this.colour, this.destination);
            }
            locked = true;
            this.btn.BackColor = locked ? Color.Pink : Color.LightGreen;
        }

        if (!arriving)
            this.colour = Color.White;
        panel.Invalidate();
        //NewArrival();
    }

    private void NewArrival()
    {
        
        locked = true;
        this.btn.BackColor = locked ? Color.Pink : Color.LightGreen;
        Random randomGen = new Random();
        KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        KnownColor randomColorName = names[randomGen.Next(names.Length)];
        Color randomColor = Color.FromKnownColor(randomColorName);
        if (randomColor.GetBrightness() > 0.9)
        {
            randomColorName = names[randomGen.Next(names.Length)];
            randomColor = Color.FromKnownColor(randomColorName);
        }
        this.colour = randomColor;
        this.zeroPlane();
    }

    private void zeroPlane()
    {
        plane.X = origin.X;
        plane.Y = origin.Y;
    }

    private void movePlane(int xDelta, int yDelta)
    {
        plane.X += xDelta; plane.Y += yDelta;
    }

    private void panel_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        SolidBrush brush = new SolidBrush(colour);

        g.FillRectangle(brush, plane.X, plane.Y, 10, 10);

        brush.Dispose();    //  Dispose graphics resources. 
        g.Dispose();        //  
    }

}// end class ButtonPanelThread

//public class WaitPanelThread
//{
//    private Point origin;
//    private int delay;
//    private Panel panel;
//    private bool westEast;
//    private bool southNorth;
//    private Color colour;
//    private Point plane;
//    private int xDelta;
//    private int yDelta;
//    private Semaphore semaphore;
//    private Buffer buffer;
//    private Semaphore semaphore2;
//    private Buffer buffer2;
//    private bool takeOff;
//    private int distance;


//    public WaitPanelThread(Point origin,
//                       int delay,
//                       bool westEast,
//                       bool southNorth,
//                       Panel panel,
//                       Color colour,
//                       Semaphore semaphore,
//                       Buffer buffer,
//                       Semaphore semaphore2,
//                       Buffer buffer2,
//                       bool takeOff,
//                       int distance)
//    {
//        this.origin = origin;
//        this.delay = delay;
//        this.westEast = westEast;
//        this.southNorth = southNorth;
//        this.panel = panel;
//        this.colour = colour;
//        this.plane = origin;
//        this.panel.Paint += new PaintEventHandler(this.panel_Paint);
//        this.xDelta = southNorth ? 0 : (westEast ? -10 : +10);
//        this.yDelta = westEast ? (southNorth ? +10 : 0) : (southNorth ? -10 : 0);
//        this.semaphore = semaphore;
//        this.buffer = buffer;
//        this.semaphore2 = semaphore2;
//        this.buffer2 = buffer2;
//        this.takeOff = takeOff;
//        this.distance = distance;
//    }

//    public void Start()
//    {

//        //Thread.Sleep(delay);
//        this.colour = Color.White;
//        for (int k = 1; k <= 14; k++)
//        {
//            semaphore.Signal();
//            this.zeroPlane();

//            //buffer.Read(ref this.colour);

//            for (int i = 1; i <= (takeOff ? distance + 10 : distance); i++)
//            {

//                panel.Invalidate();
//                this.movePlane(xDelta, yDelta);
//                Thread.Sleep(delay);
//            }
//            if (!takeOff)
//            {
//                semaphore2.Wait();
//                //buffer2.Write(this.colour);
//            }

//            this.colour = Color.White;
//            panel.Invalidate();
//        }
//        this.colour = Color.Gray;
//        panel.Invalidate();
//    }

//    private void zeroPlane()
//    {
//        plane.X = origin.X;
//        plane.Y = origin.Y;
//    }

//    private void movePlane(int xDelta, int yDelta)
//    {
//        plane.X += xDelta; plane.Y += yDelta;
//    }

//    private void panel_Paint(object sender, PaintEventArgs e)
//    {
//        Graphics g = e.Graphics;
//        SolidBrush brush = new SolidBrush(colour);
//        g.FillRectangle(brush, plane.X, plane.Y, 10, 10);
//        brush.Dispose();    //  Dispose graphics resources. 
//        g.Dispose();        //  
//    }
//}// end class WaitPanelThread

public class UltraPanelThread
{
    private Point cubeSpawnPoint;
    private int movementDelay;
    private Panel panel;
    private bool westEast;
    private bool southNorth;
    private Color squareColour;
    private Point plane;
    private int xDelta;
    private int yDelta;
    private Button btn;
    private Semaphore originSemaphore;
    private Buffer originBuffer;
    private Semaphore destSemaphore;
    private Buffer destBuffer;
    private Semaphore altSemaphore;
    private Buffer altBuffer;
    private int distanceToTravel;
    private int destination;
    private int panelNum;
    private bool locked;
    private TCPClient client;

    public UltraPanelThread(Point cubeSpawnPoint,
                       int movementDelay,
                       Panel panel,
                       bool westEast,
                       bool southNorth,
                       Color squareColour,
                       Button btn,
                       bool locked,
                       Semaphore originSemaphore,
                       Buffer originBuffer,
                       Semaphore destSemaphore,
                       Buffer destBuffer,
                       Semaphore altSemaphore,
                       Buffer altBuffer,
                       int distanceToTravel,
                       int destination,
                       int panelNum)
    {
        this.cubeSpawnPoint = cubeSpawnPoint;
        this.movementDelay = movementDelay;
        this.westEast = westEast;
        this.southNorth = southNorth;
        this.panel = panel;
        this.squareColour = squareColour;
        this.plane = cubeSpawnPoint;
        this.panel.Paint += new PaintEventHandler(this.panel_Paint);
        this.locked = locked;
        this.xDelta = southNorth ? 0 : (westEast ? -10 : +10);
        this.yDelta = westEast ? (southNorth ? +10 : 0) : (southNorth ? -10 : 0);
        this.originSemaphore = originSemaphore;
        this.originBuffer = originBuffer;
        this.destSemaphore = destSemaphore;
        this.destBuffer = destBuffer;
        this.altSemaphore = altSemaphore;
        this.btn = btn;
        this.btn.Click += new System.EventHandler(this.btn_Click);
        this.altBuffer = altBuffer;
        this.destination = destination;
        this.distanceToTravel = distanceToTravel;
        this.panelNum = panelNum;
    }

    private void btn_Click(object sender,
                           System.EventArgs e)
    {
        locked = !locked;
        this.btn.BackColor = locked ? Color.Pink : Color.LightGreen;
        lock (this)
        {
            if (!locked)
                Monitor.Pulse(this);
        }
    }

    public void Start()
    {
        for (int k = 1; k <= 2; k++)
        {
            //We must check if we are moving, landing, going to a hub or taking off.
            //If cube destination matches hanger/runway number then do the respective process.

            if (panelNum > 3) //If panel is a hub panel then move differently to normal
            {
                
                this.zeroPlane();
                panel.Invalidate();
                originSemaphore.Signal();
                originBuffer.Read(ref this.squareColour, ref this.destination);
                if (destination == panelNum) //At the cubes destination
                {
                    if (destination == 10) //Runway
                    {
                        client = new TCPClient();
                        panel.Invalidate();
                        for (int i = 1; i <= (distanceToTravel+10); i++)
                        {
                            panel.Invalidate();
                            this.movePlane((int)xDelta-(i/6), yDelta);
                            Thread.Sleep(movementDelay-10);
                        }
                        client.RunClient(squareColour.ToString(), 1);
                        this.squareColour = Color.White;
                        panel.Invalidate();
                    }
                    else if ((panelNum == 4) || (panelNum == 5) || (panelNum == 8)) //At the panel before the hub
                    {
                        panel.Invalidate();
                        for (int i = 1; i <= (distanceToTravel); i++)
                        {
                            panel.Invalidate();
                            this.movePlane(xDelta, yDelta);
                            Thread.Sleep(movementDelay);
                        }
                        altSemaphore.Wait(); //Send the cube to the alternate panel (ie the destination hanger)
                        altBuffer.Write(this.squareColour, this.destination); //Send the square to the destination with colour and destination
                        this.squareColour = Color.White;
                        panel.Invalidate();
                    }
                }
                else //Normal panel to panel movement
                {
                    panel.Invalidate();
                    for (int i = 1; i <= (distanceToTravel); i++) //This sets how far we want to travel
                    {
                        panel.Invalidate();
                        this.movePlane(xDelta, yDelta); //Moves the cube
                        Thread.Sleep(movementDelay); //Sets how fast it moves per loop
                    }
                    destSemaphore.Wait(); //Check if the destination panel is empty
                    destBuffer.Write(this.squareColour, this.destination); //Send the square to the destination with colour and destination
                    this.squareColour = Color.White;
                    panel.Invalidate();
                }
            }
            else //Hub movement
            {
                lock (this)
                {
                    while (locked)
                    {
                        Monitor.Wait(this);
                    }
                }

                panel.Invalidate();

                if (!locked)
                {
                    for (int i = 1; i <= distanceToTravel; i++)
                    {
                        panel.Invalidate();
                        this.movePlane(xDelta, yDelta);
                        Thread.Sleep(movementDelay);
                    }
                    destSemaphore.Wait(); //Check if the destination panel is empty
                    destBuffer.Write(this.squareColour, 10);
                    this.squareColour = Color.White;
                    panel.Invalidate();
                    locked = true;
                    this.btn.BackColor = Color.Pink;

                }

                originSemaphore.Signal();
                originBuffer.Read(ref this.squareColour, ref this.destination);
                if (locked && ((destination == 8 && panelNum == 1) || (destination == 4 && panelNum == 3) || (destination == 5 && panelNum == 2)))
                {
                    client = new TCPClient();
                    locked = false;
                    this.EnterHanger();
                    panel.Invalidate();
                    for (int i = 1; i <= (distanceToTravel); i++) //This sets how far we want to travel
                    {
                        panel.Invalidate();
                        this.movePlane(-xDelta, -yDelta); //Moves the cube
                        Thread.Sleep(movementDelay); //Sets how fast it moves per loop
                    }
                    if (destination == 8)
                        client.RunClient(squareColour.ToString(), 2);
                    if (destination == 4)
                        client.RunClient(squareColour.ToString(), 3);
                    if (destination == 5)
                        client.RunClient(squareColour.ToString(), 4);
                    panel.Invalidate();
                    locked = true;
                    this.btn.BackColor = Color.Pink;
                }
                panel.Invalidate();

            }
            panel.Invalidate();
            k--;
        }

    }

    private void EnterHanger() //Sets the cube as the base of the hanger panel
    {
        plane.X = 10;
        plane.Y = 140;
    }

    private void zeroPlane()
    {
        plane.X = cubeSpawnPoint.X;
        plane.Y = cubeSpawnPoint.Y;
    }

    private void movePlane(int xDelta, int yDelta)
    {
        plane.X += xDelta; plane.Y += yDelta;
    }

    private void panel_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        SolidBrush brush = new SolidBrush(squareColour);
        g.FillRectangle(brush, plane.X, plane.Y, 10, 10);
        brush.Dispose();    //  Dispose graphics resources. 
        g.Dispose();        //  
    }

    private void panel_Paint2(object sender, PaintEventArgs e)
    {
        Bitmap b = new Bitmap(15, 15);
        Rectangle rect;
        Rectangle sourceRect;
        Image picture;
        Graphics g;

        picture = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "dingbatPlane.jpg"));
        b.SetResolution(picture.HorizontalResolution, picture.VerticalResolution);
        g = Graphics.FromImage(b);

        rect = new Rectangle(0, 0, 15, 15);
        //  sourceRect = new Rectangle(new Point(0, 0), new Size(picture.Width, picture.Height));
        sourceRect = new Rectangle(0, 0, picture.Width, picture.Height);

        g.DrawImage(picture, rect, sourceRect, GraphicsUnit.Pixel);
        //g.Dispose();
    }
}// end class UltraPanelThread


public class TCPClient
{
   private delegate void DisplayDelegate(string message);

    private delegate void DisableInputDelegate(bool value);

    public void RunClient(string planeColour, int activity)
    {
        String server = "127.0.0.1"; // args[0]; // Server name or IP address

        // Convert input String to bytes
        byte[] byteBuffer = Encoding.ASCII.GetBytes("A plane has just taken off: " + planeColour); // Encoding.ASCII.GetBytes(args[1]);
        if (activity == 2)
        {
            byteBuffer = Encoding.ASCII.GetBytes("A plane has just arrived at HUB 1: " + planeColour); // Encoding.ASCII.GetBytes(args[1]);
        }
        else if (activity == 3)
        {
            byteBuffer = Encoding.ASCII.GetBytes("A plane has just arrived at HUB 2: " + planeColour); // Encoding.ASCII.GetBytes(args[1]);
        }
        else if (activity == 4)
        {
            byteBuffer = Encoding.ASCII.GetBytes("A plane has just arrived at HUB 3: " + planeColour); // Encoding.ASCII.GetBytes(args[1]);
        }
                   
        // Use port argument if supplied, otherwise default to 8080
        int servPort = 888;  // (args.Length == 3) ? Int32.Parse(args[2]) : 8080;//7 ;

        TcpClient client = null;
        NetworkStream netStream = null;

        try
        {
            // Create socket that is connected to server on specified port
            client = new TcpClient(server, servPort);

            Console.WriteLine("Connection to server established, sending plane colour to server");

            netStream = client.GetStream();

            // Send the encoded string to the server
            netStream.Write(byteBuffer, 0, byteBuffer.Length);

            Console.WriteLine("Sent {0} bytes to server...", byteBuffer.Length);

            int totalBytesRcvd = 0; // Total bytes received so far
            int bytesRcvd = 0; // Bytes received in last read

            // Receive the same string back from the server
            while (totalBytesRcvd < byteBuffer.Length)
            {
                if ((bytesRcvd = netStream.Read(byteBuffer, totalBytesRcvd,
                byteBuffer.Length - totalBytesRcvd)) == 0)
                {
                    Console.WriteLine("Connection closed prematurely.");
                    break;
                }
                totalBytesRcvd += bytesRcvd;
            }
            Console.WriteLine("Received {0} bytes from server: {1}", totalBytesRcvd,
            Encoding.ASCII.GetString(byteBuffer, 0, totalBytesRcvd));

        }
        catch (Exception ex)
        {
            // http://stackoverflow.com/questions/2972600/no-connection-could-be-made-because-the-target-machine-actively-refused-it
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (netStream != null)
                netStream.Close();
            if (client != null)
                client.Close();
        }
        Thread.Sleep(1000);
    }

}

public class TheOne
{
    public static void Main()//
    {

        Application.Run(new Form1());
    }
}// end class TheOne




