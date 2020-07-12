namespace Copia_Progressbar
{
    partial class FormCopiador
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
            this.btn_Iniciar_Copia = new System.Windows.Forms.Button();
            this.txt_Path_Origem = new System.Windows.Forms.TextBox();
            this.lbl_Path_Origem = new System.Windows.Forms.Label();
            this.lbl_Path_Destino = new System.Windows.Forms.Label();
            this.prb_Copia = new System.Windows.Forms.ProgressBar();
            this.txt_Path_Destino = new System.Windows.Forms.TextBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Escolhe_Diretorio_Origem = new System.Windows.Forms.Button();
            this.btn_Escolhe_Diretorio_Destino = new System.Windows.Forms.Button();
            this.lbl_Progress_Bar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.prb_Arquivo = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Iniciar_Copia
            // 
            this.btn_Iniciar_Copia.Location = new System.Drawing.Point(27, 153);
            this.btn_Iniciar_Copia.Name = "btn_Iniciar_Copia";
            this.btn_Iniciar_Copia.Size = new System.Drawing.Size(102, 27);
            this.btn_Iniciar_Copia.TabIndex = 0;
            this.btn_Iniciar_Copia.Text = "Iniciar Copia";
            this.btn_Iniciar_Copia.UseVisualStyleBackColor = true;
            this.btn_Iniciar_Copia.Click += new System.EventHandler(this.btn_Iniciar_Copia_Click);
            // 
            // txt_Path_Origem
            // 
            this.txt_Path_Origem.Enabled = false;
            this.txt_Path_Origem.Location = new System.Drawing.Point(27, 49);
            this.txt_Path_Origem.Name = "txt_Path_Origem";
            this.txt_Path_Origem.Size = new System.Drawing.Size(214, 20);
            this.txt_Path_Origem.TabIndex = 1;
            // 
            // lbl_Path_Origem
            // 
            this.lbl_Path_Origem.AutoSize = true;
            this.lbl_Path_Origem.Location = new System.Drawing.Point(24, 30);
            this.lbl_Path_Origem.Name = "lbl_Path_Origem";
            this.lbl_Path_Origem.Size = new System.Drawing.Size(102, 13);
            this.lbl_Path_Origem.TabIndex = 2;
            this.lbl_Path_Origem.Text = "Caminho de Origem:";
            // 
            // lbl_Path_Destino
            // 
            this.lbl_Path_Destino.AutoSize = true;
            this.lbl_Path_Destino.Location = new System.Drawing.Point(24, 93);
            this.lbl_Path_Destino.Name = "lbl_Path_Destino";
            this.lbl_Path_Destino.Size = new System.Drawing.Size(105, 13);
            this.lbl_Path_Destino.TabIndex = 3;
            this.lbl_Path_Destino.Text = "Caminho de Destino:";
            // 
            // prb_Copia
            // 
            this.prb_Copia.Location = new System.Drawing.Point(291, 107);
            this.prb_Copia.Name = "prb_Copia";
            this.prb_Copia.Size = new System.Drawing.Size(208, 23);
            this.prb_Copia.Step = 1;
            this.prb_Copia.TabIndex = 4;
            // 
            // txt_Path_Destino
            // 
            this.txt_Path_Destino.Enabled = false;
            this.txt_Path_Destino.Location = new System.Drawing.Point(27, 109);
            this.txt_Path_Destino.Name = "txt_Path_Destino";
            this.txt_Path_Destino.Size = new System.Drawing.Size(214, 20);
            this.txt_Path_Destino.TabIndex = 5;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(168, 153);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(102, 27);
            this.btn_Cancelar.TabIndex = 6;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_Escolhe_Diretorio_Origem
            // 
            this.btn_Escolhe_Diretorio_Origem.Location = new System.Drawing.Point(247, 46);
            this.btn_Escolhe_Diretorio_Origem.Name = "btn_Escolhe_Diretorio_Origem";
            this.btn_Escolhe_Diretorio_Origem.Size = new System.Drawing.Size(37, 23);
            this.btn_Escolhe_Diretorio_Origem.TabIndex = 7;
            this.btn_Escolhe_Diretorio_Origem.Text = "...";
            this.btn_Escolhe_Diretorio_Origem.UseVisualStyleBackColor = true;
            this.btn_Escolhe_Diretorio_Origem.Click += new System.EventHandler(this.btn_Escolhe_Diretorio_Origem_Click);
            // 
            // btn_Escolhe_Diretorio_Destino
            // 
            this.btn_Escolhe_Diretorio_Destino.Location = new System.Drawing.Point(247, 107);
            this.btn_Escolhe_Diretorio_Destino.Name = "btn_Escolhe_Diretorio_Destino";
            this.btn_Escolhe_Diretorio_Destino.Size = new System.Drawing.Size(37, 23);
            this.btn_Escolhe_Diretorio_Destino.TabIndex = 8;
            this.btn_Escolhe_Diretorio_Destino.Text = "...";
            this.btn_Escolhe_Diretorio_Destino.UseVisualStyleBackColor = true;
            this.btn_Escolhe_Diretorio_Destino.Click += new System.EventHandler(this.btn_Escolhe_Diretorio_Destino_Click);
            // 
            // lbl_Progress_Bar
            // 
            this.lbl_Progress_Bar.AutoSize = true;
            this.lbl_Progress_Bar.Location = new System.Drawing.Point(400, 91);
            this.lbl_Progress_Bar.Name = "lbl_Progress_Bar";
            this.lbl_Progress_Bar.Size = new System.Drawing.Size(0, 13);
            this.lbl_Progress_Bar.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Progresso Geral:";
            // 
            // prb_Arquivo
            // 
            this.prb_Arquivo.Location = new System.Drawing.Point(294, 45);
            this.prb_Arquivo.Name = "prb_Arquivo";
            this.prb_Arquivo.Size = new System.Drawing.Size(205, 23);
            this.prb_Arquivo.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Progresso de Arquivo:";
            // 
            // FormCopiador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 269);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.prb_Arquivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Progress_Bar);
            this.Controls.Add(this.btn_Escolhe_Diretorio_Destino);
            this.Controls.Add(this.btn_Escolhe_Diretorio_Origem);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.txt_Path_Destino);
            this.Controls.Add(this.prb_Copia);
            this.Controls.Add(this.lbl_Path_Destino);
            this.Controls.Add(this.lbl_Path_Origem);
            this.Controls.Add(this.txt_Path_Origem);
            this.Controls.Add(this.btn_Iniciar_Copia);
            this.Name = "FormCopiador";
            this.Text = "Copiador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Iniciar_Copia;
        private System.Windows.Forms.TextBox txt_Path_Origem;
        private System.Windows.Forms.Label lbl_Path_Origem;
        private System.Windows.Forms.Label lbl_Path_Destino;
        private System.Windows.Forms.ProgressBar prb_Copia;
        private System.Windows.Forms.TextBox txt_Path_Destino;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Escolhe_Diretorio_Origem;
        private System.Windows.Forms.Button btn_Escolhe_Diretorio_Destino;
        private System.Windows.Forms.Label lbl_Progress_Bar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar prb_Arquivo;
        private System.Windows.Forms.Label label2;
    }
}

