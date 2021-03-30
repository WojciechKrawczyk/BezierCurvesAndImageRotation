namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSTOP = new System.Windows.Forms.Button();
            this.buttonSTART = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonRotatingAnimation = new System.Windows.Forms.RadioButton();
            this.radioButtonCurveAnimation = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonFilteringRotating = new System.Windows.Forms.RadioButton();
            this.radioButtonNaiveRotating = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.pictureBoxImageView = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonControlPoints = new System.Windows.Forms.RadioButton();
            this.radioButtonPolyline = new System.Windows.Forms.RadioButton();
            this.checkBoxPolylineVisible = new System.Windows.Forms.CheckBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxTmp = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTmp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSTOP);
            this.panel1.Controls.Add(this.buttonSTART);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(950, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 572);
            this.panel1.TabIndex = 0;
            // 
            // buttonSTOP
            // 
            this.buttonSTOP.Location = new System.Drawing.Point(157, 520);
            this.buttonSTOP.Name = "buttonSTOP";
            this.buttonSTOP.Size = new System.Drawing.Size(75, 35);
            this.buttonSTOP.TabIndex = 5;
            this.buttonSTOP.Text = "STOP";
            this.buttonSTOP.UseVisualStyleBackColor = true;
            this.buttonSTOP.Click += new System.EventHandler(this.buttonSTOP_Click);
            // 
            // buttonSTART
            // 
            this.buttonSTART.Location = new System.Drawing.Point(57, 520);
            this.buttonSTART.Name = "buttonSTART";
            this.buttonSTART.Size = new System.Drawing.Size(75, 35);
            this.buttonSTART.TabIndex = 4;
            this.buttonSTART.Text = "START";
            this.buttonSTART.UseVisualStyleBackColor = true;
            this.buttonSTART.Click += new System.EventHandler(this.buttonSTART_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonRotatingAnimation);
            this.groupBox4.Controls.Add(this.radioButtonCurveAnimation);
            this.groupBox4.Location = new System.Drawing.Point(6, 421);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(269, 93);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Animation";
            // 
            // radioButtonRotatingAnimation
            // 
            this.radioButtonRotatingAnimation.AutoSize = true;
            this.radioButtonRotatingAnimation.Location = new System.Drawing.Point(29, 60);
            this.radioButtonRotatingAnimation.Name = "radioButtonRotatingAnimation";
            this.radioButtonRotatingAnimation.Size = new System.Drawing.Size(82, 21);
            this.radioButtonRotatingAnimation.TabIndex = 1;
            this.radioButtonRotatingAnimation.TabStop = true;
            this.radioButtonRotatingAnimation.Text = "Rotating";
            this.radioButtonRotatingAnimation.UseVisualStyleBackColor = true;
            this.radioButtonRotatingAnimation.CheckedChanged += new System.EventHandler(this.radioButtonRotatingAnimation_CheckedChanged);
            // 
            // radioButtonCurveAnimation
            // 
            this.radioButtonCurveAnimation.AutoSize = true;
            this.radioButtonCurveAnimation.Location = new System.Drawing.Point(29, 32);
            this.radioButtonCurveAnimation.Name = "radioButtonCurveAnimation";
            this.radioButtonCurveAnimation.Size = new System.Drawing.Size(157, 21);
            this.radioButtonCurveAnimation.TabIndex = 0;
            this.radioButtonCurveAnimation.TabStop = true;
            this.radioButtonCurveAnimation.Text = "Moving on the curve";
            this.radioButtonCurveAnimation.UseVisualStyleBackColor = true;
            this.radioButtonCurveAnimation.CheckedChanged += new System.EventHandler(this.radioButtonCurveAnimation_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonFilteringRotating);
            this.groupBox3.Controls.Add(this.radioButtonNaiveRotating);
            this.groupBox3.Location = new System.Drawing.Point(6, 318);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 97);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rotating";
            // 
            // radioButtonFilteringRotating
            // 
            this.radioButtonFilteringRotating.AutoSize = true;
            this.radioButtonFilteringRotating.Location = new System.Drawing.Point(29, 65);
            this.radioButtonFilteringRotating.Name = "radioButtonFilteringRotating";
            this.radioButtonFilteringRotating.Size = new System.Drawing.Size(107, 21);
            this.radioButtonFilteringRotating.TabIndex = 1;
            this.radioButtonFilteringRotating.TabStop = true;
            this.radioButtonFilteringRotating.Text = "With filtering";
            this.radioButtonFilteringRotating.UseVisualStyleBackColor = true;
            this.radioButtonFilteringRotating.CheckedChanged += new System.EventHandler(this.radioButtonFilteringRotating_CheckedChanged);
            // 
            // radioButtonNaiveRotating
            // 
            this.radioButtonNaiveRotating.AutoSize = true;
            this.radioButtonNaiveRotating.Location = new System.Drawing.Point(29, 38);
            this.radioButtonNaiveRotating.Name = "radioButtonNaiveRotating";
            this.radioButtonNaiveRotating.Size = new System.Drawing.Size(65, 21);
            this.radioButtonNaiveRotating.TabIndex = 0;
            this.radioButtonNaiveRotating.TabStop = true;
            this.radioButtonNaiveRotating.Text = "Naive";
            this.radioButtonNaiveRotating.UseVisualStyleBackColor = true;
            this.radioButtonNaiveRotating.CheckedChanged += new System.EventHandler(this.radioButtonNaiveRotating_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCreate);
            this.groupBox2.Controls.Add(this.buttonLoadImage);
            this.groupBox2.Controls.Add(this.pictureBoxImageView);
            this.groupBox2.Location = new System.Drawing.Point(6, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 139);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(144, 79);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(82, 31);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(144, 30);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(82, 31);
            this.buttonLoadImage.TabIndex = 1;
            this.buttonLoadImage.Text = "Load";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // pictureBoxImageView
            // 
            this.pictureBoxImageView.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxImageView.Image")));
            this.pictureBoxImageView.Location = new System.Drawing.Point(29, 30);
            this.pictureBoxImageView.Name = "pictureBoxImageView";
            this.pictureBoxImageView.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxImageView.TabIndex = 0;
            this.pictureBoxImageView.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonControlPoints);
            this.groupBox1.Controls.Add(this.radioButtonPolyline);
            this.groupBox1.Controls.Add(this.checkBoxPolylineVisible);
            this.groupBox1.Controls.Add(this.numericUpDown);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.buttonLoad);
            this.groupBox1.Controls.Add(this.buttonGenerate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bezier\'s curve";
            // 
            // radioButtonControlPoints
            // 
            this.radioButtonControlPoints.AutoSize = true;
            this.radioButtonControlPoints.Location = new System.Drawing.Point(16, 88);
            this.radioButtonControlPoints.Name = "radioButtonControlPoints";
            this.radioButtonControlPoints.Size = new System.Drawing.Size(147, 21);
            this.radioButtonControlPoints.TabIndex = 10;
            this.radioButtonControlPoints.TabStop = true;
            this.radioButtonControlPoints.Text = "Only control points";
            this.radioButtonControlPoints.UseVisualStyleBackColor = true;
            // 
            // radioButtonPolyline
            // 
            this.radioButtonPolyline.AutoSize = true;
            this.radioButtonPolyline.Location = new System.Drawing.Point(16, 60);
            this.radioButtonPolyline.Name = "radioButtonPolyline";
            this.radioButtonPolyline.Size = new System.Drawing.Size(78, 21);
            this.radioButtonPolyline.TabIndex = 9;
            this.radioButtonPolyline.TabStop = true;
            this.radioButtonPolyline.Text = "Polyline";
            this.radioButtonPolyline.UseVisualStyleBackColor = true;
            this.radioButtonPolyline.CheckedChanged += new System.EventHandler(this.radioButtonPolyline_CheckedChanged);
            // 
            // checkBoxPolylineVisible
            // 
            this.checkBoxPolylineVisible.AutoSize = true;
            this.checkBoxPolylineVisible.Location = new System.Drawing.Point(179, 75);
            this.checkBoxPolylineVisible.Name = "checkBoxPolylineVisible";
            this.checkBoxPolylineVisible.Size = new System.Drawing.Size(71, 21);
            this.checkBoxPolylineVisible.TabIndex = 8;
            this.checkBoxPolylineVisible.Text = "Visible";
            this.checkBoxPolylineVisible.UseVisualStyleBackColor = true;
            this.checkBoxPolylineVisible.CheckedChanged += new System.EventHandler(this.checkBoxPolylineVisible_CheckedChanged);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(125, 30);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(53, 22);
            this.numericUpDown.TabIndex = 7;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(144, 123);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(118, 35);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save polyline";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(9, 123);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(117, 35);
            this.buttonLoad.TabIndex = 5;
            this.buttonLoad.Text = "Load polyline";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(179, 26);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(90, 32);
            this.buttonGenerate.TabIndex = 3;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of points:";
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.Color.White;
            this.mainPictureBox.Location = new System.Drawing.Point(12, 16);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(931, 572);
            this.mainPictureBox.TabIndex = 1;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPictureBox_Paint);
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.White;
            this.pictureBoxImage.Location = new System.Drawing.Point(59, 46);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxImage.TabIndex = 2;
            this.pictureBoxImage.TabStop = false;
            // 
            // pictureBoxTmp
            // 
            this.pictureBoxTmp.Location = new System.Drawing.Point(262, 48);
            this.pictureBoxTmp.Name = "pictureBoxTmp";
            this.pictureBoxTmp.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxTmp.TabIndex = 3;
            this.pictureBoxTmp.TabStop = false;
            this.pictureBoxTmp.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 591);
            this.Controls.Add(this.pictureBoxTmp);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.mainPictureBox);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "GK lab3";
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonSTOP;
        private System.Windows.Forms.Button buttonSTART;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonRotatingAnimation;
        private System.Windows.Forms.RadioButton radioButtonCurveAnimation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonFilteringRotating;
        private System.Windows.Forms.RadioButton radioButtonNaiveRotating;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.PictureBox pictureBoxImageView;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.RadioButton radioButtonControlPoints;
        private System.Windows.Forms.RadioButton radioButtonPolyline;
        private System.Windows.Forms.CheckBox checkBoxPolylineVisible;
        private System.Windows.Forms.PictureBox pictureBoxTmp;
        private System.Windows.Forms.Button buttonCreate;
    }
}

