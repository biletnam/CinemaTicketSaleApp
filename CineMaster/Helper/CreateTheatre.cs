using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineMaster.Helper
{
    public class CreateTheatre
    {
        public static void TheatreA(Form form)
        {
            Panel pnlTheatreA = new Panel();
            pnlTheatreA.Name = "pnlTheatreB";
            pnlTheatreA.Location = new Point(375, 20);
            pnlTheatreA.Size = new Size(500, 450);
            pnlTheatreA.BackColor = Color.DarkGray;
            pnlTheatreA.BorderStyle = BorderStyle.Fixed3D;

            form.Controls.Add(pnlTheatreA);

            PictureBox pcbCurtain = new PictureBox();
            pcbCurtain.Name = "pcbCurtain";
            pcbCurtain.Location = new Point(100, 0);
            pcbCurtain.Size = new Size(300, 50);
            pcbCurtain.BackgroundImage = Image.FromFile(@"curtain.jpg");
            pcbCurtain.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreA.Controls.Add(pcbCurtain);

            PictureBox pcbDoor = new PictureBox();
            pcbDoor.Name = "pcbDoor";
            pcbDoor.Location = new Point(470, 215);
            pcbDoor.Size = new Size(20, 50);
            pcbDoor.BackgroundImage = Image.FromFile(@"door.png");
            pcbDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreA.Controls.Add(pcbDoor);

            PictureBox pcbLeftDoor = new PictureBox();
            pcbLeftDoor.Name = "pcbLeftDoor";
            pcbLeftDoor.Location = new Point(0, 215);
            pcbLeftDoor.Size = new Size(20, 50);
            pcbLeftDoor.BackgroundImage = Image.FromFile(@"doorleft.png");
            pcbLeftDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreA.Controls.Add(pcbLeftDoor);

            int counter = 1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((i == 4) || (j == 3) || (i == 0 && j == 0) || (i == 0 && j == 8) || (i == 8 && j == 8) || (i == 8 && j == 0))
                    {
                        continue;
                    }
                    Button button = new Button();
                    button.Name = "button" + counter;
                    button.Text = counter.ToString();
                    button.Font = new Font(button.Font, FontStyle.Bold);
                    button.Tag = counter;
                    button.Size = new Size(35, 35);
                    button.Left = ((j * 40) + 70);
                    button.Top = ((i * 40) + 60);
                    button.BackgroundImage = Image.FromFile(@"freeSeat.png");
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.TabStop = false;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;

                    pnlTheatreA.Controls.Add(button);

                    counter++;
                }
            }
        }

        public static void TheatreB(Form form)
        {
            Panel pnlTheatreB = new Panel();
            pnlTheatreB.Name = "pnlTheatreB";
            pnlTheatreB.Location = new Point(375, 20);
            pnlTheatreB.Size = new Size(500, 480);
            pnlTheatreB.BackColor = Color.DarkGray;
            pnlTheatreB.BorderStyle = BorderStyle.Fixed3D;

            form.Controls.Add(pnlTheatreB);

            PictureBox pcbCurtain = new PictureBox();
            pcbCurtain.Name = "pcbCurtain";
            pcbCurtain.Location = new Point(100, 0);
            pcbCurtain.Size = new Size(300, 50);
            pcbCurtain.BackgroundImage = Image.FromFile(@"curtain.jpg");
            pcbCurtain.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreB.Controls.Add(pcbCurtain);

            PictureBox pcbDoor = new PictureBox();
            pcbDoor.Name = "pcbDoor";
            pcbDoor.Location = new Point(470, 250);
            pcbDoor.Size = new Size(20, 50);
            pcbDoor.BackgroundImage = Image.FromFile(@"door.png");
            pcbDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreB.Controls.Add(pcbDoor);

            PictureBox pcbLeftDoor = new PictureBox();
            pcbLeftDoor.Name = "pcbLeftDoor";
            pcbLeftDoor.Location = new Point(0, 250);
            pcbLeftDoor.Size = new Size(20, 50);
            pcbLeftDoor.BackgroundImage = Image.FromFile(@"doorleft.png");
            pcbLeftDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreB.Controls.Add(pcbLeftDoor);

            int counter = 1;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((i == 5) || (j == 2) || (i == 0 && j == 9))
                    {
                        continue;
                    }
                    Button button = new Button();
                    button.Name = "button" + counter;
                    button.Text = counter.ToString();
                    button.Font = new Font(button.Font, FontStyle.Bold);
                    button.Tag = counter;
                    button.Size = new Size(35, 35);
                    button.Left = ((j * 40) + 50);
                    button.Top = ((i * 40) + 60);
                    button.BackgroundImage = Image.FromFile(@"freeSeat.png");
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.TabStop = false;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;

                    pnlTheatreB.Controls.Add(button);

                    counter++;
                }
            }
        }

        public static void TheatreC(Form form)
        {
            Panel pnlTheatreC = new Panel();
            pnlTheatreC.Name = "pnlTheatreC";
            pnlTheatreC.Location = new Point(375, 20);
            pnlTheatreC.Size = new Size(500, 530);
            pnlTheatreC.BackColor = Color.DarkGray;
            pnlTheatreC.BorderStyle = BorderStyle.Fixed3D;

            form.Controls.Add(pnlTheatreC);

            PictureBox pcbCurtain = new PictureBox();
            pcbCurtain.Name = "pcbCurtain";
            pcbCurtain.Location = new Point(100, 0);
            pcbCurtain.Size = new Size(300, 50);
            pcbCurtain.BackgroundImage = Image.FromFile(@"curtain.jpg");
            pcbCurtain.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreC.Controls.Add(pcbCurtain);

            PictureBox pcbDoor = new PictureBox();
            pcbDoor.Name = "pcbDoor";
            pcbDoor.Location = new Point(470, 330);
            pcbDoor.Size = new Size(20, 50);
            pcbDoor.BackgroundImage = Image.FromFile(@"door.png");
            pcbDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreC.Controls.Add(pcbDoor);

            PictureBox pcbLeftDoor = new PictureBox();
            pcbLeftDoor.Name = "pcbLeftDoor";
            pcbLeftDoor.Location = new Point(0, 330);
            pcbLeftDoor.Size = new Size(20, 50);
            pcbLeftDoor.BackgroundImage = Image.FromFile(@"doorleft.png");
            pcbLeftDoor.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTheatreC.Controls.Add(pcbLeftDoor);

            int counter = 1;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if ((i == 7) || (j == 4))
                    {
                        continue;
                    }
                    Button button = new Button();
                    button.Name = "button" + counter;
                    button.Text = counter.ToString();
                    button.Font = new Font(button.Font, FontStyle.Bold);
                    button.Tag = counter;
                    button.Size = new Size(37, 35);
                    button.Left = ((j * 40) + 30);
                    button.Top = ((i * 40) + 60);
                    button.BackgroundImage = Image.FromFile(@"freeSeat.png");
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.TabStop = false;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;

                    pnlTheatreC.Controls.Add(button);

                    counter++;
                }
            }
        }
    }
}
