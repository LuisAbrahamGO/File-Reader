
namespace Lector_de_archivos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPathBox = new System.Windows.Forms.TextBox();
            this.txtDBPathBox = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.DBConnectionBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPathBox
            // 
            this.txtPathBox.Location = new System.Drawing.Point(12, 12);
            this.txtPathBox.Name = "txtPathBox";
            this.txtPathBox.Size = new System.Drawing.Size(100, 20);
            this.txtPathBox.TabIndex = 0;
            // 
            // txtDBPathBox
            // 
            this.txtDBPathBox.Location = new System.Drawing.Point(212, 12);
            this.txtDBPathBox.Name = "txtDBPathBox";
            this.txtDBPathBox.Size = new System.Drawing.Size(100, 20);
            this.txtDBPathBox.TabIndex = 1;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(13, 39);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(99, 23);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "Leer archivos";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.Btnstart_Click);
            // 
            // DBConnectionBtn
            // 
            this.DBConnectionBtn.Location = new System.Drawing.Point(212, 38);
            this.DBConnectionBtn.Name = "DBConnectionBtn";
            this.DBConnectionBtn.Size = new System.Drawing.Size(100, 23);
            this.DBConnectionBtn.TabIndex = 3;
            this.DBConnectionBtn.Text = "Conectar a DB";
            this.DBConnectionBtn.UseVisualStyleBackColor = true;
            this.DBConnectionBtn.Click += new System.EventHandler(this.DBConnectionBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DBConnectionBtn);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.txtDBPathBox);
            this.Controls.Add(this.txtPathBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPathBox;
        private System.Windows.Forms.TextBox txtDBPathBox;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button DBConnectionBtn;
    }
}

