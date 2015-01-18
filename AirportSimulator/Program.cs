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

public class Form1 : Form
{
    private Container components = null;
    private NewPlanePanelThread p1;
    private Label lbl1, lbl2, lbl3;
    private Button btn1, btn2, btn3, btn4, btn5;
    private RadioButton rbtn0, rbtn1, rbtn2, rbtn3;
    private MovingPanelThread mp1, mp2, mp3, mp4, mp5, mp6, mp7, mp8, mp9;
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

        //Create all the necessary threads
        mp1 = new MovingPanelThread(new Point(10, 35),
                                    120, pnl1, true, true,
                                    Color.Blue, btn1, true,
                                    semaphore, buffer, semaphore4,
                                    buffer4, semaphore4, buffer4,
                                    10, 5, 1);

        mp2 = new MovingPanelThread(new Point(10, 35),
                                    120, pnl3, true, true,
                                    Color.Red, btn3, true,
                                    semaphore3, buffer3, semaphore5,
                                    buffer5, semaphore5, buffer5,
                                    10, 8, 3);

        mp3 = new MovingPanelThread(new Point(10, 35),
                                    120, pnl2, true, true,
                                    Color.Yellow, btn2, true,
                                    semaphore2, buffer2, semaphore6,
                                    buffer6, semaphore6, buffer6,
                                    10, 4, 2);

        p1 = new NewPlanePanelThread(new Point(65, 10),
                             150, true, false, pnl10,
                             newPlaneColour(),
                             semaphore8,
                             buffer8,
                             btn4,
                             true, false, 10);

        mp4 = new MovingPanelThread(new Point(0, 10),
                                    100, pnl4, false, false,
                                    Color.White, btn5, false,
                                    semaphore4, buffer4, semaphore5,
                                    buffer5, semaphore3, buffer3,
                                    16, 9, 4);

        mp5 = new MovingPanelThread(new Point(0, 10),
                                   100, pnl5, false, false,
                                   Color.White, btn5, false,
                                   semaphore5, buffer5, semaphore6,
                                   buffer6, semaphore2, buffer2,
                                   16, 9, 5);

        mp6 = new MovingPanelThread(new Point(0, 10),
                                   100, pnl6, false, false,
                                   Color.White, btn5, false,
                                   semaphore6, buffer6, semaphore7,
                                   buffer7, semaphore7, buffer7,
                                   16, 9, 6);

        mp7 = new MovingPanelThread(new Point(10, 5),
                                   100, pnl7, true, true,
                                   Color.White, btn5, false,
                                   semaphore7, buffer7, semaphore8,
                                   buffer8, semaphore8, buffer8,
                                   15, 9, 7);

        mp8 = new MovingPanelThread(new Point(595, 10),
                                   50, pnl9, true, false,
                                   Color.White, btn5, false,
                                   semaphore8, buffer8, semaphore9,
                                   buffer9, semaphore9, buffer9,
                                   53, 9, 10);

        mp9 = new MovingPanelThread(new Point(10, 140),
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

        thread1 = new Thread(new ThreadStart(mp1.Start));
        thread2 = new Thread(new ThreadStart(mp2.Start));
        thread3 = new Thread(new ThreadStart(mp3.Start));
        thread4 = new Thread(new ThreadStart(mp4.Start));
        thread5 = new Thread(new ThreadStart(mp5.Start));
        thread6 = new Thread(new ThreadStart(mp6.Start));
        thread7 = new Thread(new ThreadStart(mp7.Start));
        thread8 = new Thread(new ThreadStart(mp8.Start));
        thread9 = new Thread(new ThreadStart(mp9.Start));
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

    private Color newPlaneColour() //This function returns a random colour when called
    {
        Random randomGen = new Random();
        bool darkColour = false;
        KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        KnownColor randomColorName = names[randomGen.Next(names.Length)];
        Color randomColor = Color.FromKnownColor(randomColorName);
        while (!darkColour)
        {
            if (randomColor.GetBrightness() > 0.8) //Random colour can't be too bright because it will be 
            {                                      //invisible against the white panels
                randomColorName = names[randomGen.Next(names.Length)];
                randomColor = Color.FromKnownColor(randomColorName);
            }
            else
                darkColour = true;
        }

        return randomColor;
    }

    private void InitializeComponent() //Create all the panels, buttons and radiobuttons
    {
        this.pnl1 = new System.Windows.Forms.Panel();
        this.pnl2 = new System.Windows.Forms.Panel();
        this.pnl3 = new System.Windows.Forms.Panel();
        this.pnl4 = new System.Windows.Forms.Panel();
        this.pnl5 = new System.Windows.Forms.Panel();
        this.pnl6 = new System.Windows.Forms.Panel();
        this.pnl7 = new System.Windows.Forms.Panel();
        this.pnl8 = new System.Windows.Forms.Panel();
        this.pnl9 = new System.Windows.Forms.Panel();
        this.pnl10 = new System.Windows.Forms.Panel();

        this.btn1 = new System.Windows.Forms.Button();
        this.btn2 = new System.Windows.Forms.Button();
        this.btn3 = new System.Windows.Forms.Button();
        this.btn4 = new System.Windows.Forms.Button();
        this.btn5 = new System.Windows.Forms.Button();

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

        //pnl1
        this.pnl1.BackColor = System.Drawing.Color.WhiteSmoke;
        this.pnl1.Controls.Add(this.btn1);
        this.pnl1.Location = new System.Drawing.Point(50, 50);
        this.pnl1.Name = "pnl1";
        this.pnl1.Size = new System.Drawing.Size(30, 150);
        this.pnl1.TabIndex = 0;

        //pnl2
        this.pnl2.BackColor = System.Drawing.Color.WhiteSmoke;
        this.pnl2.Controls.Add(this.btn2);
        this.pnl2.Location = new System.Drawing.Point(400, 50);
        this.pnl2.Name = "pnl2";
        this.pnl2.Size = new System.Drawing.Size(30, 150);
        this.pnl2.TabIndex = 1;

        //pnl3
        this.pnl3.BackColor = System.Drawing.Color.WhiteSmoke;
        this.pnl3.Controls.Add(this.btn3);
        this.pnl3.Controls.Add(this.btn5);
        this.pnl3.Location = new System.Drawing.Point(225, 50);
        this.pnl3.Name = "pnl3";
        this.pnl3.Size = new System.Drawing.Size(30, 150);
        this.pnl3.TabIndex = 2;

        //pnl4
        this.pnl4.BackColor = System.Drawing.Color.White;
        this.pnl4.Location = new System.Drawing.Point(50, 200);
        this.pnl4.Name = "pnl4";
        this.pnl4.Size = new System.Drawing.Size(175, 30);
        this.pnl4.TabIndex = 3;

        //pnl5
        this.pnl5.BackColor = System.Drawing.Color.White;
        this.pnl5.Location = new System.Drawing.Point(225, 200);
        this.pnl5.Name = "pnl5";
        this.pnl5.Size = new System.Drawing.Size(175, 30);
        this.pnl5.TabIndex = 4;

        //pnl6
        this.pnl6.BackColor = System.Drawing.Color.White;
        this.pnl6.Location = new System.Drawing.Point(400, 200);
        this.pnl6.Name = "pnl6";
        this.pnl6.Size = new System.Drawing.Size(175, 30);
        this.pnl6.TabIndex = 5;

        //pnl7
        this.pnl7.BackColor = System.Drawing.Color.White;
        this.pnl7.Location = new System.Drawing.Point(575, 200);
        this.pnl7.Name = "pnl7";
        this.pnl7.Size = new System.Drawing.Size(30, 175);
        this.pnl7.TabIndex = 6;

        //pnl8
        this.pnl8.BackColor = System.Drawing.Color.White;
        this.pnl8.Location = new System.Drawing.Point(50, 230);
        this.pnl8.Name = "pnl8";
        this.pnl8.Size = new System.Drawing.Size(30, 145);
        this.pnl8.TabIndex = 7;

        //pnl9
        this.pnl9.BackColor = System.Drawing.Color.White;
        this.pnl9.Location = new System.Drawing.Point(0, 375);
        this.pnl9.Name = "pnl9";
        this.pnl9.Size = new System.Drawing.Size(605, 30);
        this.pnl9.TabIndex = 8;

        //pnl10
        this.pnl10.BackColor = System.Drawing.Color.White;
        this.pnl10.Controls.Add(this.btn4);
        this.pnl10.Location = new System.Drawing.Point(605, 375);
        this.pnl10.Name = "pnl10";
        this.pnl10.Size = new System.Drawing.Size(110, 30);
        this.pnl10.TabIndex = 0;

        //btn1
        this.btn1.BackColor = System.Drawing.Color.Pink;
        this.btn1.Location = new System.Drawing.Point(0, 0);
        this.btn1.Name = "btn1";
        this.btn1.Size = new System.Drawing.Size(30, 30);
        this.btn1.TabIndex = 0;
        this.btn1.UseVisualStyleBackColor = false;

        //btn2
        this.btn2.BackColor = System.Drawing.Color.Pink;
        this.btn2.Location = new System.Drawing.Point(0, 0);
        this.btn2.Name = "btn2";
        this.btn2.Size = new System.Drawing.Size(30, 30);
        this.btn2.TabIndex = 0;
        this.btn2.UseVisualStyleBackColor = false;

        //btn3
        this.btn3.BackColor = System.Drawing.Color.Pink;
        this.btn3.Location = new System.Drawing.Point(0, 0);
        this.btn3.Name = "btn3";
        this.btn3.Size = new System.Drawing.Size(30, 30);
        this.btn3.TabIndex = 0;
        this.btn3.UseVisualStyleBackColor = false;

        //btn4
        this.btn4.BackColor = System.Drawing.Color.Pink;
        this.btn4.Location = new System.Drawing.Point(80, 0);
        this.btn4.Name = "btn4";
        this.btn4.Size = new System.Drawing.Size(30, 30);
        this.btn4.TabIndex = 0;
        this.btn4.UseVisualStyleBackColor = false;
        this.btn4.Click += new System.EventHandler(this.btn4_Click);
        this.btn4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn4_MouseClick);

        //btn5
        this.btn5.BackColor = System.Drawing.Color.White;
        this.btn5.Location = new System.Drawing.Point(0, 0);
        this.btn5.Name = "btn5";
        this.btn5.Size = new System.Drawing.Size(0, 0);
        this.btn5.TabIndex = 0;
        this.btn5.UseVisualStyleBackColor = false;
        this.btn5.Visible = false;

        //rbpnl
        this.rbpnl.BackColor = System.Drawing.Color.Silver;
        this.rbpnl.Controls.Add(this.rbtn0);
        this.rbpnl.Controls.Add(this.rbtn1);
        this.rbpnl.Controls.Add(this.rbtn2);
        this.rbpnl.Controls.Add(this.rbtn3);
        this.rbpnl.Location = new System.Drawing.Point(650, 275);
        this.rbpnl.Name = "rbpnl";
        this.rbpnl.Size = new System.Drawing.Size(60, 100);
        this.rbpnl.TabIndex = 9;

        //rbtn0
        this.rbtn0.Checked = true;
        this.rbtn0.Location = new System.Drawing.Point(0, 0);
        this.rbtn0.Name = "rbtn0";
        this.rbtn0.Size = new System.Drawing.Size(104, 24);
        this.rbtn0.TabIndex = 0;
        this.rbtn0.TabStop = true;
        this.rbtn0.Text = "0";
        this.rbtn0.CheckedChanged += new System.EventHandler(this.rbtn0_CheckedChanged);

        //rbtn1
        this.rbtn1.Location = new System.Drawing.Point(0, 25);
        this.rbtn1.Name = "rbtn1";
        this.rbtn1.Size = new System.Drawing.Size(104, 24);
        this.rbtn1.TabIndex = 1;
        this.rbtn1.Text = "1";
        this.rbtn1.CheckedChanged += new System.EventHandler(this.rbtn1_CheckedChanged);

        //rbtn2
        this.rbtn2.Location = new System.Drawing.Point(0, 50);
        this.rbtn2.Name = "rbtn2";
        this.rbtn2.Size = new System.Drawing.Size(104, 24);
        this.rbtn2.TabIndex = 2;
        this.rbtn2.Text = "2";
        this.rbtn2.CheckedChanged += new System.EventHandler(this.rbtn2_CheckedChanged);

        //rbtn3
        this.rbtn3.Location = new System.Drawing.Point(0, 75);
        this.rbtn3.Name = "rbtn3";
        this.rbtn3.Size = new System.Drawing.Size(104, 24);
        this.rbtn3.TabIndex = 3;
        this.rbtn3.Text = "3";
        this.rbtn3.CheckedChanged += new System.EventHandler(this.rbtn3_CheckedChanged);

        //lbl1
        this.lbl1.BackColor = System.Drawing.Color.Silver;
        this.lbl1.Font = new System.Drawing.Font("Georgia", 16F);
        this.lbl1.Location = new System.Drawing.Point(90, 53);
        this.lbl1.Name = "lbl1";
        this.lbl1.Size = new System.Drawing.Size(20, 30);
        this.lbl1.TabIndex = 10;
        this.lbl1.Text = "1";

        //lbl2
        this.lbl2.BackColor = System.Drawing.Color.Silver;
        this.lbl2.Font = new System.Drawing.Font("Georgia", 16F);
        this.lbl2.Location = new System.Drawing.Point(265, 53);
        this.lbl2.Name = "lbl2";
        this.lbl2.Size = new System.Drawing.Size(20, 30);
        this.lbl2.TabIndex = 11;
        this.lbl2.Text = "2";

        //lbl3
        this.lbl3.BackColor = System.Drawing.Color.Silver;
        this.lbl3.Font = new System.Drawing.Font("Georgia", 16F);
        this.lbl3.Location = new System.Drawing.Point(445, 53);
        this.lbl3.Name = "lbl3";
        this.lbl3.Size = new System.Drawing.Size(20, 30);
        this.lbl3.TabIndex = 12;
        this.lbl3.Text = "3";

        //form1
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
        this.Text = "Airport Simulator";
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
        //Environment is a System class
        //Kill off all threads on exit
        Environment.Exit(Environment.ExitCode);
    }

    private void NewPlane(int destination) //Creates a new plane with the selected destination
    {
        this.pnl10.Dispose();
        this.pnl10 = new System.Windows.Forms.Panel();
        this.btn4.Dispose();
        this.btn4 = new System.Windows.Forms.Button();
        this.SuspendLayout();

        p1 = new NewPlanePanelThread(new Point(65, 10),
                             150, true, false, pnl10,
                             newPlaneColour(),
                             semaphore8,
                             buffer8,
                             btn4,
                             true, false, destination);

        this.btn4.BackColor = System.Drawing.Color.Pink;
        this.btn4.Location = new System.Drawing.Point(80, 0);
        this.btn4.Name = "btn4";
        this.btn4.Size = new System.Drawing.Size(30, 30);
        this.btn4.TabIndex = 0;
        this.btn4.UseVisualStyleBackColor = false;
        this.btn4.Enabled = true;

        this.pnl10.BackColor = System.Drawing.Color.White;
        this.pnl10.Controls.Add(this.btn4);
        this.pnl10.Location = new System.Drawing.Point(605, 375);
        this.pnl10.Name = "pnl10";
        this.pnl10.Size = new System.Drawing.Size(110, 30);
        this.pnl10.TabIndex = 0;

        thread10 = new Thread(new ThreadStart(p1.Start));

        this.Controls.Add(this.pnl10);
        thread10.Start();

        this.ResumeLayout(true);
    }


    private void rbtn0_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtn0.Checked == true)
            this.NewPlane(10); //Desination '10' is the runway
    }

    private void rbtn1_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtn1.Checked == true)
            this.NewPlane(8); //Desination '8' is hub 1
    }

    private void rbtn2_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtn2.Checked == true)
            this.NewPlane(4); //Desination '4' is hub 2
    }

    private void rbtn3_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtn3.Checked == true)
            this.NewPlane(5); //Desination '5' is hub 3
    }

    private void btn4_Click(object sender, EventArgs e)
    {

    }

    private void btn4_MouseClick(object sender, MouseEventArgs e)
    {

    }
}// end class form1

public class Buffer
{
    private Color planeColor;
    private int destination;
    private bool empty = true;

    public void Read(ref Color planeColor, ref int destination)
    {
        lock (this) //Each plane carries the plane colour and the destination of that plane
        {
            if (empty) //Check whether the buffer is empty
                Monitor.Wait(this);
            empty = true;
            planeColor = this.planeColor; //This data is sent from panel to panel
            destination = this.destination;
            Monitor.Pulse(this);
        }
    }

    public void Write(Color planeColor, int destination) //The buffers pass the plane data across panels
    {
        lock (this)
        {
            if (!empty) //Check whether the buffer is currently full or not
                Monitor.Wait(this);
            empty = false;
            this.planeColor = planeColor; //Send the data to the next panel
            this.destination = destination;
            Monitor.Pulse(this);
        }
    }

    public void Start()
    {
    }

} //end class Buffer

public class Semaphore //Ensures only one plane per panel
{
    private int count = 0;

    public void Wait() //Wait is called when a plane wants to enter the panel that this semaphore is set to
    {
        lock (this)
        {
            while (count == 0)
                Monitor.Wait(this);
            count = 0;
        }
    }

    public void Signal() //Signal is called when the process is finished with this panel
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

} //end class Semaphore

public class MovingPanelThread //Panel for each hub and movement panel
{
    private Point cubeSpawnPoint; //(X,Y) coords for where the cube spawns on the panel
    private int movementDelay; //Speed that the cube moves at
    private Panel panel;
    private bool westEast; //Two movement bools to enable 4 directional movement
    private bool southNorth;
    private Color squareColour; //Colour of the square currently on the panel
    private Point plane;
    private int xDelta; //Movement integers for all directions
    private int yDelta;
    private Button btn; //Button associated with the panel (only applies to the hubs)
    private Semaphore originSemaphore; //This is the semaphore/buffer ID that the current panel owns. Other panels
    private Buffer originBuffer;       //use this semaphore/buffer to travel to this panel
    private Semaphore destSemaphore; //This is this semaphore/buffer ID that this panel transfers the cube to.
    private Buffer destBuffer;       //Whichever panel has this destination match their origin will recieve this cube.
    private Semaphore altSemaphore;  //Alternate semaphore/buffers for panels which have two possible next panels.
    private Buffer altBuffer;        //Which is the runway and the panels before the 3 landing hubs.
    private int distanceToTravel; //This sets how far the cube will travel along the panel. Runway cube travels further
    private int destination; //This is the destination of the current cube on this panel. It is passed from panel to panel.
    private int panelNum; //This is used to check if the cube is at its destination. Each panel has a unique ID
    private bool locked; //Locked value applies to panels with a button. If button is clicked then locked is false.
    private TCPClient client; //Panels which create important info transmit that info to the client via TCP.
                              //(namely the 3 hubs and the runway)

    public MovingPanelThread(Point cubeSpawnPoint, int movementDelay, Panel panel, bool westEast, bool southNorth,
                             Color squareColour, Button btn, bool locked, Semaphore originSemaphore,
                             Buffer originBuffer, Semaphore destSemaphore, Buffer destBuffer, Semaphore altSemaphore,
                             Buffer altBuffer, int distanceToTravel, int destination, int panelNum)
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

    private void btn_Click(object sender, System.EventArgs e) //Button click function
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
        for (int k = 1; k <= 2; k++) //Loops infinitely to enable constant plane panel movement. Change to while loop.
        {
            if (panelNum > 3) //Panels with a panel ID below 4 are hub panels
            {
                this.zeroPlane(); //Reset the cube to the origin of the panel
                panel.Invalidate();
                originSemaphore.Signal(); //Check if this panel is empty
                originBuffer.Read(ref this.squareColour, ref this.destination); //If it is read the data and start moving the cube

                if (destination == panelNum) //If the cube has reached it's desination      
                {
                    if (destination == 10) //Destination 10 is the runway
                    {
                        client = new TCPClient(); //Initalise the client
                        panel.Invalidate();
                        panel.BackColor = Color.WhiteSmoke; //Tint the back colour slightly so that the user can see
                                                            //what panel the plane is in
                        for (int i = 1; i <= (distanceToTravel + 10); i++) //Move the cube along the runway
                        {
                            panel.Invalidate();
                            this.movePlane((int)xDelta - (i / 6), yDelta); //Increase speed gradually
                            Thread.Sleep(movementDelay - 10);
                        }

                        System.Media.SystemSounds.Asterisk.Play(); //Sound plays when plane takes off
                        panel.BackColor = Color.White;
                        client.RunClient(squareColour.ToString(), 1); //Send a message to the client saying that this colour plane has
                        this.squareColour = Color.White;              //taken off. The '1' means the message will be "Plane has taken off"
                        panel.Invalidate();
                    }
                    else if ((panelNum == 4) || (panelNum == 5) || (panelNum == 8)) //If the cube has reached the panel 
                    {                                                               //before it's destination hub
                        panel.Invalidate();
                        panel.BackColor = Color.WhiteSmoke;

                        for (int i = 1; i <= (distanceToTravel); i++)
                        {
                            panel.Invalidate();
                            this.movePlane(xDelta, yDelta);
                            Thread.Sleep(movementDelay);
                        }

                        altSemaphore.Wait(); //Send the cube to the alternate panel (ie the destination hub)
                        altBuffer.Write(this.squareColour, this.destination); //Send the square to the destination with colour and destination
                        panel.BackColor = Color.White;
                        this.squareColour = Color.White;
                        panel.Invalidate();
                    }
                }
                else //This is normal panel to panel movement (no hubs or runways)
                {
                    panel.Invalidate();
                    panel.BackColor = Color.WhiteSmoke;

                    for (int i = 1; i <= (distanceToTravel); i++) //This sets how far we want to travel
                    {
                        panel.Invalidate();
                        this.movePlane(xDelta, yDelta); //Moves the cube
                        Thread.Sleep(movementDelay); //Sets how fast it moves per loop
                    }


                    destSemaphore.Wait(); //Check if the destination panel is empty
                    destBuffer.Write(this.squareColour, this.destination); //Send the square to the destination with colour and destination
                    panel.BackColor = Color.White;
                    this.squareColour = Color.White;
                    panel.Invalidate();
                }
            }
            else //Below is for all movement in the hubs
            {
                lock (this) //Check if the button is locked or unlocked
                {
                    while (locked)
                    {
                        Monitor.Wait(this);
                    }
                }

                panel.Invalidate();
                if (!locked) //If the user has clicked the button for the plane to move (unlocked the button)
                {
                    panel.BackColor = Color.WhiteSmoke;
                    for (int i = 1; i <= distanceToTravel; i++) //Move down the hub
                    {
                        panel.Invalidate();
                        this.movePlane(xDelta, yDelta);
                        Thread.Sleep(movementDelay);
                    }

                    destSemaphore.Wait(); //Check if the destination panel is empty
                    destBuffer.Write(this.squareColour, 10);
                    panel.BackColor = Color.White;
                    this.squareColour = Color.White;
                    panel.Invalidate();
                    locked = true;
                    this.btn.BackColor = Color.Pink;
                    btn.Invoke(new MethodInvoker(delegate { btn.Enabled = false; })); //Prevent the user from clicking 
                }                                                                     //the button if the hub is empty

                originSemaphore.Signal(); //Check if the hub is empty
                originBuffer.Read(ref this.squareColour, ref this.destination); //Read in any cubes that wish to come in

                if (locked && ((destination == 8 && panelNum == 1) || (destination == 4 && panelNum == 3) || (destination == 5 && panelNum == 2)))
                {   //Make sure the cube is entering the correct hub that matches it's destination
                    client = new TCPClient();

                    this.EnterHanger();
                    panel.Invalidate();
                    panel.BackColor = Color.WhiteSmoke;
                    for (int i = 1; i <= (distanceToTravel); i++) //This sets how far we want to travel
                    {
                        panel.Invalidate();
                        this.movePlane(-xDelta, -yDelta); //Moves the cube
                        Thread.Sleep(200); //Sets how fast it moves per loop
                    }

                    System.Media.SystemSounds.Beep.Play(); //Sound plays when plane lands at HUB

                    if (destination == 8)
                        client.RunClient(squareColour.ToString(), 2); //Send messages to the clients with the appropiate
                                                                      //message ('2' means a plane has arrived in hub 2 etc)
                    if (destination == 4)
                        client.RunClient(squareColour.ToString(), 3);

                    if (destination == 5)
                        client.RunClient(squareColour.ToString(), 4);

                    panel.Invalidate();
                    locked = true;
                    btn.Invoke(new MethodInvoker(delegate { btn.Enabled = true; })); //Allow the user to click the button
                    this.btn.BackColor = Color.Pink;
                }
                panel.Invalidate();

            }
            panel.Invalidate();
            k--; //Ensure the loop continues. Change to a while loop
        }
    }

    private void EnterHanger() //Sets the cube as the base of the hub panel. Only used at HUB's
    {
        plane.X = 10;
        plane.Y = 140;
    }

    private void zeroPlane() //Sets the cube as the designated spawn point on each panel
    {
        plane.X = cubeSpawnPoint.X;
        plane.Y = cubeSpawnPoint.Y;
    }

    private void movePlane(int xDelta, int yDelta) //Moves the plane along each panel in the desired direction
    {
        plane.X += xDelta; plane.Y += yDelta;
    }

    private void panel_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        SolidBrush brush = new SolidBrush(squareColour);

        g.FillRectangle(brush, plane.X, plane.Y, 10, 10);
        brush.Dispose();    //Dispose graphics resources. 
        g.Dispose();        //  
    }

} //End class MovingPanelThread

public class NewPlanePanelThread //Panel that holds the plane that lands/spawns
{
    private Point origin; //Pretty much same data as the panel above but without the ability to recieve new planes.
    private int delay;    //This panel can spawn planes but not recieve them.
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
    private TCPClient client;

    public NewPlanePanelThread(Point origin, int delay, bool westEast, bool northSouth, Panel panel, Color colour,
                               Semaphore semaphore, Buffer buffer, Button btn, bool locked, bool arriving,
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

    private void btn_Click(object sender, System.EventArgs e)
    {
        locked = !locked;
        this.btn.BackColor = locked ? Color.Pink : Color.LightGreen;
        lock (this)
        {
            if (!locked)
                Monitor.Pulse(this);
        }
    }

    public void Start() //Purpose of this panel is to simulate planes arriving infinitely
    {
        for (int k = 1; k <= 2; k++) //Infinite loop
        {
            client = new TCPClient();
            this.colour = newPlaneColour();
            panel.BackColor = Color.WhiteSmoke;
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

            semaphore.Wait();
            buffer.Write(this.colour, this.destination);
            client.RunClient(this.colour.ToString(), 5);
            this.colour = Color.White;
            panel.BackColor = Color.White;
            locked = true;
            this.btn.BackColor = locked ? Color.Pink : Color.LightGreen;
            k--; //Loop forever. Change to while
        }
        panel.Invalidate();

    }

    private Color newPlaneColour() //This function returns a random colour which isn't too bright
    {                              //(bright colours can't be seen on the white panels)
        Random randomGen = new Random();
        bool darkColour = false;
        KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        KnownColor randomColorName = names[randomGen.Next(names.Length)];
        Color randomColor = Color.FromKnownColor(randomColorName);
        while (!darkColour)
        {
            if (randomColor.GetBrightness() > 0.8)
            {
                randomColorName = names[randomGen.Next(names.Length)];
                randomColor = Color.FromKnownColor(randomColorName);
            }
            else
                darkColour = true;
        }

        return randomColor;
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

        brush.Dispose();    //Dispose graphics resources. 
        g.Dispose();        //  
    }

} //End class NewPlanePanelThread



public class TCPClient //Client that connects with the server
{
    private delegate void DisplayDelegate(string message);

    private delegate void DisableInputDelegate(bool value);

    public void RunClient(string planeColour, int activity)
    {
        String server = "127.0.0.1"; //Server name or IP address

        //Convert string that we want to send into bytes
        byte[] byteBuffer = Encoding.ASCII.GetBytes("A plane has just taken off: " + planeColour);

        if (activity == 2)
            byteBuffer = Encoding.ASCII.GetBytes("A plane has just landed at HUB 1: " + planeColour); //HUB 1 landing
        else if (activity == 3)
            byteBuffer = Encoding.ASCII.GetBytes("A plane has just landed at HUB 2: " + planeColour); //HUB 2 landing
        else if (activity == 4)
            byteBuffer = Encoding.ASCII.GetBytes("A plane has just landed at HUB 3: " + planeColour); //HUB 3 landing
        else if (activity == 5)
            byteBuffer = Encoding.ASCII.GetBytes("A Boeing 747 has just arrived at the Airport: " + planeColour); //New plane

        int servPort = 888; //Default port is 888

        TcpClient client = null;
        NetworkStream netStream = null;

        try
        {
            //Create socket that is connected to server on specified port
            client = new TcpClient(server, servPort);

            Console.WriteLine("Connection to server established, sending plane colour to server");

            netStream = client.GetStream();

            //Send the encoded string to the server
            netStream.Write(byteBuffer, 0, byteBuffer.Length);

            Console.WriteLine("Sent {0} bytes to server...", byteBuffer.Length);

            int totalBytesRcvd = 0; //Total bytes received so far
            int bytesRcvd = 0; //Bytes received in last read

            //Receive the same string back from the server
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
        {   //Solution to a common problem where the server refuses the connection
            //http://stackoverflow.com/questions/2972600/no-connection-could-be-made-because-the-target-machine-actively-refused-it
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (netStream != null)
                netStream.Close();
            if (client != null)
                client.Close();
        }
    }
}

public class TheOne //Main
{
    public static void Main()//
    {
        Application.Run(new Form1());
    }
}// end class TheOne




