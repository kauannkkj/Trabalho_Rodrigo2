namespace Vendinha;

partial class Form1
{
    private void InitializeComponent()
    {
        txtBusca = new TextBox();
        btnNovoCliente = new Button();
        dgvClientes = new DataGridView();
        btnExcluir = new Button();
        btnAnterior = new Button();
        btnProxima = new Button();
        lblPagina = new Label();
        ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
        SuspendLayout();
        // 
        // txtBusca
        // 
        txtBusca.Location = new Point(14, 20);
        txtBusca.Name = "txtBusca";
        txtBusca.PlaceholderText = "Buscar cliente pelo nome...";
        txtBusca.Size = new Size(799, 27);
        txtBusca.TabIndex = 0;
        // 
        // btnNovoCliente
        // 
        btnNovoCliente.Location = new Point(823, 16);
        btnNovoCliente.Name = "btnNovoCliente";
        btnNovoCliente.Size = new Size(171, 40);
        btnNovoCliente.TabIndex = 1;
        btnNovoCliente.Text = "Novo Cliente";
        btnNovoCliente.UseVisualStyleBackColor = true;
        // 
        // dgvClientes
        // 
        dgvClientes.AllowUserToAddRows = false;
        dgvClientes.AllowUserToDeleteRows = false;
        dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClientes.BackgroundColor = Color.White;
        dgvClientes.BorderStyle = BorderStyle.None;
        dgvClientes.ColumnHeadersHeight = 29;
        dgvClientes.Location = new Point(14, 73);
        dgvClientes.MultiSelect = false;
        dgvClientes.Name = "dgvClientes";
        dgvClientes.ReadOnly = true;
        dgvClientes.RowHeadersWidth = 51;
        dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvClientes.Size = new Size(983, 490);
        dgvClientes.TabIndex = 2;
        // 
        // btnAnterior
        // 
        btnAnterior.Location = new Point(14, 573);
        btnAnterior.Name = "btnAnterior";
        btnAnterior.Size = new Size(110, 35);
        btnAnterior.TabIndex = 3;
        btnAnterior.Text = "◄ Anterior";
        btnAnterior.UseVisualStyleBackColor = true;
        // 
        // lblPagina
        // 
        lblPagina.Location = new Point(134, 578);
        lblPagina.Name = "lblPagina";
        lblPagina.Size = new Size(500, 25);
        lblPagina.TabIndex = 4;
        lblPagina.Text = "Página 1 de 1";
        lblPagina.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnProxima
        // 
        btnProxima.Location = new Point(644, 573);
        btnProxima.Name = "btnProxima";
        btnProxima.Size = new Size(110, 35);
        btnProxima.TabIndex = 5;
        btnProxima.Text = "Próxima ►";
        btnProxima.UseVisualStyleBackColor = true;
        // 
        // btnExcluir
        // 
        btnExcluir.BackColor = Color.FromArgb(220, 53, 69);
        btnExcluir.ForeColor = Color.White;
        btnExcluir.Location = new Point(887, 573);
        btnExcluir.Name = "btnExcluir";
        btnExcluir.Size = new Size(110, 35);
        btnExcluir.TabIndex = 6;
        btnExcluir.Text = "Excluir";
        btnExcluir.UseVisualStyleBackColor = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1010, 625);
        Controls.Add(btnExcluir);
        Controls.Add(btnProxima);
        Controls.Add(lblPagina);
        Controls.Add(btnAnterior);
        Controls.Add(dgvClientes);
        Controls.Add(btnNovoCliente);
        Controls.Add(txtBusca);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Vendinha - Controle de Contas";
        ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private TextBox txtBusca;
    private DataGridView dgvClientes;
    private Button btnNovoCliente;
    private Button btnExcluir;
    private Button btnAnterior;
    private Button btnProxima;
    private Label lblPagina;
}
