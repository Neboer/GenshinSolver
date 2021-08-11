
namespace GenshinSolver
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lb1 = new System.Windows.Forms.Label();
            this.init_state_text = new System.Windows.Forms.TextBox();
            this.change_list = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.result_text = new System.Windows.Forms.TextBox();
            this.calculate_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.modular = new System.Windows.Forms.FlowLayoutPanel();
            this.val3 = new System.Windows.Forms.RadioButton();
            this.val4 = new System.Windows.Forms.RadioButton();
            this.val5 = new System.Windows.Forms.RadioButton();
            this.nearby_button = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.modular.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(62, 37);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(53, 12);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "初始状态";
            // 
            // init_state_text
            // 
            this.init_state_text.Location = new System.Drawing.Point(138, 34);
            this.init_state_text.Name = "init_state_text";
            this.init_state_text.Size = new System.Drawing.Size(121, 21);
            this.init_state_text.TabIndex = 1;
            this.init_state_text.TextChanged += new System.EventHandler(this.init_state_text_TextChanged);
            // 
            // change_list
            // 
            this.change_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.change_list.FormattingEnabled = true;
            this.change_list.Location = new System.Drawing.Point(138, 139);
            this.change_list.Name = "change_list";
            this.change_list.Size = new System.Drawing.Size(121, 126);
            this.change_list.TabIndex = 2;
            this.change_list.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.change_list_OnKeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "可能变化";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "运算结果";
            // 
            // result_text
            // 
            this.result_text.Location = new System.Drawing.Point(138, 295);
            this.result_text.Name = "result_text";
            this.result_text.ReadOnly = true;
            this.result_text.Size = new System.Drawing.Size(121, 21);
            this.result_text.TabIndex = 5;
            // 
            // calculate_button
            // 
            this.calculate_button.Location = new System.Drawing.Point(147, 349);
            this.calculate_button.Name = "calculate_button";
            this.calculate_button.Size = new System.Drawing.Size(75, 23);
            this.calculate_button.TabIndex = 6;
            this.calculate_button.Text = "计算";
            this.calculate_button.UseVisualStyleBackColor = true;
            this.calculate_button.Click += new System.EventHandler(this.calculate_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "模数";
            // 
            // modular
            // 
            this.modular.Controls.Add(this.val3);
            this.modular.Controls.Add(this.val4);
            this.modular.Controls.Add(this.val5);
            this.modular.Location = new System.Drawing.Point(138, 84);
            this.modular.Name = "modular";
            this.modular.Size = new System.Drawing.Size(121, 22);
            this.modular.TabIndex = 8;
            // 
            // val3
            // 
            this.val3.AutoSize = true;
            this.val3.Location = new System.Drawing.Point(3, 3);
            this.val3.Name = "val3";
            this.val3.Size = new System.Drawing.Size(29, 16);
            this.val3.TabIndex = 0;
            this.val3.TabStop = true;
            this.val3.Tag = "3";
            this.val3.Text = "3";
            this.val3.UseVisualStyleBackColor = true;
            // 
            // val4
            // 
            this.val4.AutoSize = true;
            this.val4.Location = new System.Drawing.Point(38, 3);
            this.val4.Name = "val4";
            this.val4.Size = new System.Drawing.Size(29, 16);
            this.val4.TabIndex = 1;
            this.val4.TabStop = true;
            this.val4.Tag = "4";
            this.val4.Text = "4";
            this.val4.UseVisualStyleBackColor = true;
            // 
            // val5
            // 
            this.val5.AutoSize = true;
            this.val5.Location = new System.Drawing.Point(73, 3);
            this.val5.Name = "val5";
            this.val5.Size = new System.Drawing.Size(29, 16);
            this.val5.TabIndex = 2;
            this.val5.TabStop = true;
            this.val5.Tag = "5";
            this.val5.Text = "5";
            this.val5.UseVisualStyleBackColor = true;
            // 
            // nearby_button
            // 
            this.nearby_button.Location = new System.Drawing.Point(52, 169);
            this.nearby_button.Name = "nearby_button";
            this.nearby_button.Size = new System.Drawing.Size(75, 25);
            this.nearby_button.TabIndex = 9;
            this.nearby_button.Text = "邻近规则";
            this.nearby_button.UseVisualStyleBackColor = true;
            this.nearby_button.Click += new System.EventHandler(this.nearby_button_Click);
            // 
            // add
            // 
            this.add.Image = ((System.Drawing.Image)(resources.GetObject("add.Image")));
            this.add.Location = new System.Drawing.Point(265, 139);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(30, 30);
            this.add.TabIndex = 10;
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // minus
            // 
            this.minus.Image = ((System.Drawing.Image)(resources.GetObject("minus.Image")));
            this.minus.Location = new System.Drawing.Point(265, 175);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(30, 30);
            this.minus.TabIndex = 11;
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 404);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.add);
            this.Controls.Add(this.nearby_button);
            this.Controls.Add(this.modular);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calculate_button);
            this.Controls.Add(this.result_text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.change_list);
            this.Controls.Add(this.init_state_text);
            this.Controls.Add(this.lb1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "原神稻妻关灯谜题求解器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.modular.ResumeLayout(false);
            this.modular.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox init_state_text;
        private System.Windows.Forms.ComboBox change_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox result_text;
        private System.Windows.Forms.Button calculate_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel modular;
        private System.Windows.Forms.RadioButton val3;
        private System.Windows.Forms.RadioButton val4;
        private System.Windows.Forms.RadioButton val5;
        private System.Windows.Forms.Button nearby_button;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button minus;
    }
}

