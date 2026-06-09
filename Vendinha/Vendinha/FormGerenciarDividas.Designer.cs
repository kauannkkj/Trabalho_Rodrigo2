namespace Vendinha;

partial class FormGerenciarDividas
{
    private Label lblCliente;
    private DataGridView dgvDividas;
    private NumericUpDown numValor;
    private Button btnPendurar, btnPagar;

    private void InitializeComponent()
    {
        lblCliente = new Label();
        dgvDividas = new DataGridView();
        numValor = new NumericUpDown();
        btnPendurar = new Button();
        btnPagar = new Button();

        ((System.ComponentModel.ISupportInitialize)dgvDividas).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numValor).BeginInit();
        SuspendLayout();

        lblCliente.AutoSize = true;
        lblCliente.Location = new Point(12, 12);
        lblCliente.Name = "lblCliente";
        lblCliente.Size = new Size(300, 20);
        lblCliente.TabIndex = 0;
        lblCliente.Text = "Cliente: ";

        dgvDividas.AllowUserToAddRows = false;
        dgvDividas.AllowUserToDeleteRows = false;
        dgvDividas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDividas.BackgroundColor = Color.White;
        dgvDividas.BorderStyle = BorderStyle.None;
        dgvDividas.Location = new Point(12, 40);
        dgvDividas.MultiSelect = false;
        dgvDividas.Name = "dgvDividas";
        dgvDividas.ReadOnly = true;
        dgvDividas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDividas.Size = new Size(760, 180);
        dgvDividas.TabIndex = 1;

        numValor.Location = new Point(12, 235);
        numValor.Name = "numValor";
        numValor.Size = new Size(150, 23);
        numValor.TabIndex = 2;
        numValor.DecimalPlaces = 2;
        numValor.Maximum = 1000000;

        btnPendurar.Location = new Point(180, 230);
        btnPendurar.Name = "btnPendurar";
        btnPendurar.Size = new Size(120, 30);
        btnPendurar.TabIndex = 3;
        btnPendurar.Text = "Pendurar";
        btnPendurar.UseVisualStyleBackColor = true;

        btnPagar.Location = new Point(310, 230);
        btnPagar.Name = "btnPagar";
        btnPagar.Size = new Size(120, 30);
        btnPagar.TabIndex = 4;
        btnPagar.Text = "Pagar";
        btnPagar.UseVisualStyleBackColor = true;

        ClientSize = new Size(800, 280);
        Controls.Add(lblCliente);
        Controls.Add(dgvDividas);
        Controls.Add(numValor);
        Controls.Add(btnPendurar);
        Controls.Add(btnPagar);

        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Name = "FormGerenciarDividas";
        Text = "Gerenciar Conta";

        ((System.ComponentModel.ISupportInitialize)dgvDividas).EndInit();
        ((System.ComponentModel.ISupportInitialize)numValor).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}