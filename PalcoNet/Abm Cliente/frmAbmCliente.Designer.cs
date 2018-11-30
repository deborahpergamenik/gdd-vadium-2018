namespace PalcoNet.Abm_Cliente
{
    partial class frmAbmCliente
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbFiltroTipoDocumento = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.tBusqueda = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCuil = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ASDASD = new System.Windows.Forms.Label();
            this.txtNroPiso = new System.Windows.Forms.TextBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbAno = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbDia = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbFiltroTipoDocumento);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmbFiltro);
            this.groupBox2.Controls.Add(this.tBusqueda);
            this.groupBox2.Location = new System.Drawing.Point(775, 27);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(400, 115);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Baja o modificación de clientes";
            // 
            // cmbFiltroTipoDocumento
            // 
            this.cmbFiltroTipoDocumento.FormattingEnabled = true;
            this.cmbFiltroTipoDocumento.Location = new System.Drawing.Point(133, 62);
            this.cmbFiltroTipoDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFiltroTipoDocumento.Name = "cmbFiltroTipoDocumento";
            this.cmbFiltroTipoDocumento.Size = new System.Drawing.Size(172, 24);
            this.cmbFiltroTipoDocumento.TabIndex = 1;
            this.cmbFiltroTipoDocumento.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(315, 54);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(73, 37);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 35);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Filtrar por:";
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(12, 62);
            this.cmbFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(108, 24);
            this.cmbFiltro.TabIndex = 0;
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // tBusqueda
            // 
            this.tBusqueda.Location = new System.Drawing.Point(133, 62);
            this.tBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.tBusqueda.MaxLength = 255;
            this.tBusqueda.Name = "tBusqueda";
            this.tBusqueda.Size = new System.Drawing.Size(172, 22);
            this.tBusqueda.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 305);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 17);
            this.label12.TabIndex = 37;
            this.label12.Text = "Campos (*) obligatorios.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtCuil);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtEmail);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.btnRegistrarse);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtLocalidad);
            this.groupBox3.Controls.Add(this.cmbTipoDocumento);
            this.groupBox3.Controls.Add(this.txtNumeroDocumento);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.ASDASD);
            this.groupBox3.Controls.Add(this.txtNroPiso);
            this.groupBox3.Controls.Add(this.txtDepartamento);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.cmbAno);
            this.groupBox3.Controls.Add(this.cmbMes);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.cmbDia);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtNombre);
            this.groupBox3.Controls.Add(this.txtCodigoPostal);
            this.groupBox3.Controls.Add(this.txtApellido);
            this.groupBox3.Controls.Add(this.txtDireccion);
            this.groupBox3.Controls.Add(this.txtTelefono);
            this.groupBox3.Location = new System.Drawing.Point(13, 17);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(718, 343);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nuevo Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 38;
            this.label1.Text = "Cuil (*)";
            // 
            // txtCuil
            // 
            this.txtCuil.Location = new System.Drawing.Point(527, 42);
            this.txtCuil.Margin = new System.Windows.Forms.Padding(4);
            this.txtCuil.MaxLength = 18;
            this.txtCuil.Name = "txtCuil";
            this.txtCuil.Size = new System.Drawing.Size(176, 22);
            this.txtCuil.TabIndex = 39;
            this.txtCuil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumerico_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 118);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 17);
            this.label17.TabIndex = 4;
            this.label17.Text = "E-mail (*)";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(104, 113);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(262, 22);
            this.txtEmail.TabIndex = 7;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 44);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(88, 17);
            this.label22.TabIndex = 0;
            this.label22.Text = "Tipo Doc. (*)";
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.Location = new System.Drawing.Point(523, 295);
            this.btnRegistrarse.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(180, 37);
            this.btnRegistrarse.TabIndex = 33;
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.UseVisualStyleBackColor = true;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 203);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 17);
            this.label13.TabIndex = 14;
            this.label13.Text = "Localidad";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(206, 44);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 17);
            this.label23.TabIndex = 1;
            this.label23.Text = "Número (*)";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(104, 197);
            this.txtLocalidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocalidad.MaxLength = 18;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(262, 22);
            this.txtLocalidad.TabIndex = 3;
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(104, 41);
            this.cmbTipoDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(76, 24);
            this.cmbTipoDocumento.TabIndex = 0;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(291, 41);
            this.txtNumeroDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroDocumento.MaxLength = 18;
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(160, 22);
            this.txtNumeroDocumento.TabIndex = 1;
            this.txtNumeroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumerico_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(400, 160);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 17);
            this.label14.TabIndex = 11;
            this.label14.Text = "NroPiso";
            // 
            // ASDASD
            // 
            this.ASDASD.AutoSize = true;
            this.ASDASD.Location = new System.Drawing.Point(400, 203);
            this.ASDASD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ASDASD.Name = "ASDASD";
            this.ASDASD.Size = new System.Drawing.Size(98, 17);
            this.ASDASD.TabIndex = 12;
            this.ASDASD.Text = "Departamento";
            // 
            // txtNroPiso
            // 
            this.txtNroPiso.Location = new System.Drawing.Point(503, 157);
            this.txtNroPiso.Margin = new System.Windows.Forms.Padding(4);
            this.txtNroPiso.MaxLength = 255;
            this.txtNroPiso.Name = "txtNroPiso";
            this.txtNroPiso.Size = new System.Drawing.Size(200, 22);
            this.txtNroPiso.TabIndex = 9;
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(506, 197);
            this.txtDepartamento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDepartamento.MaxLength = 18;
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(197, 22);
            this.txtDepartamento.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 83);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 17);
            this.label15.TabIndex = 2;
            this.label15.Text = "Nombre (*)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(400, 84);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 17);
            this.label16.TabIndex = 3;
            this.label16.Text = "Apellido (*)";
            // 
            // cmbAno
            // 
            this.cmbAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAno.FormattingEnabled = true;
            this.cmbAno.Location = new System.Drawing.Point(297, 238);
            this.cmbAno.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.Size = new System.Drawing.Size(68, 24);
            this.cmbAno.TabIndex = 6;
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(236, 238);
            this.cmbMes.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(52, 24);
            this.cmbMes.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(400, 121);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 17);
            this.label18.TabIndex = 5;
            this.label18.Text = "Teléfono";
            // 
            // cmbDia
            // 
            this.cmbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDia.FormattingEnabled = true;
            this.cmbDia.Location = new System.Drawing.Point(175, 238);
            this.cmbDia.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDia.Name = "cmbDia";
            this.cmbDia.Size = new System.Drawing.Size(52, 24);
            this.cmbDia.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 160);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 17);
            this.label19.TabIndex = 6;
            this.label19.Text = "Dirección (*)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(400, 240);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(113, 17);
            this.label20.TabIndex = 7;
            this.label20.Text = "Código postal (*)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 242);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(158, 17);
            this.label21.TabIndex = 8;
            this.label21.Text = "Fecha de nacimiento (*)";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(104, 79);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.MaxLength = 255;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(262, 22);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNoNumerico_KeyPress);
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(521, 237);
            this.txtCodigoPostal.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoPostal.MaxLength = 50;
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(182, 22);
            this.txtCodigoPostal.TabIndex = 11;
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumerico_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(503, 80);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.MaxLength = 255;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 22);
            this.txtApellido.TabIndex = 1;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNoNumerico_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(104, 157);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.MaxLength = 255;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(262, 22);
            this.txtDireccion.TabIndex = 2;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(503, 115);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.MaxLength = 18;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 22);
            this.txtTelefono.TabIndex = 8;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumerico_KeyPress);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1062, 347);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(113, 37);
            this.btnLimpiar.TabIndex = 38;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(932, 347);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(113, 37);
            this.btnAtras.TabIndex = 37;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // frmAbmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 397);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmAbmCliente";
            this.Text = "frmAbmCliente";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbFiltroTipoDocumento;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.TextBox tBusqueda;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label ASDASD;
        private System.Windows.Forms.TextBox txtNroPiso;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbAno;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbDia;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCuil;
    }
}