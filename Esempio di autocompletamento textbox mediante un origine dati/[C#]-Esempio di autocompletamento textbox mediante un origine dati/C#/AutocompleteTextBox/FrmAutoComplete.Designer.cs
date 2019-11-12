namespace AutocompleteTextBox
{
    partial class FrmAutoComplete
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutoComplete));
            this.TxtAutoComplete = new System.Windows.Forms.TextBox();
            this.btnAutocomplete = new System.Windows.Forms.Button();
            this.paroleDataSet = new AutocompleteTextBox.ParoleDataSet();
            this.tABELLAPAROLEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tABELLAPAROLETableAdapter = new AutocompleteTextBox.ParoleDataSetTableAdapters.TABELLAPAROLETableAdapter();
            this.tableAdapterManager = new AutocompleteTextBox.ParoleDataSetTableAdapters.TableAdapterManager();
            this.tABELLAPAROLEBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tABELLAPAROLEBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.AutoCompleteDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAROLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.paroleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tABELLAPAROLEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tABELLAPAROLEBindingNavigator)).BeginInit();
            this.tABELLAPAROLEBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoCompleteDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtAutoComplete
            // 
            this.TxtAutoComplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAutoComplete.Location = new System.Drawing.Point(277, 80);
            this.TxtAutoComplete.Name = "TxtAutoComplete";
            this.TxtAutoComplete.Size = new System.Drawing.Size(366, 20);
            this.TxtAutoComplete.TabIndex = 9;
            // 
            // btnAutocomplete
            // 
            this.btnAutocomplete.Location = new System.Drawing.Point(277, 35);
            this.btnAutocomplete.Name = "btnAutocomplete";
            this.btnAutocomplete.Size = new System.Drawing.Size(75, 23);
            this.btnAutocomplete.TabIndex = 8;
            this.btnAutocomplete.Text = "Carica ";
            this.btnAutocomplete.UseVisualStyleBackColor = true;
            this.btnAutocomplete.Click += new System.EventHandler(this.btnAutocomplete_Click);
            // 
            // paroleDataSet
            // 
            this.paroleDataSet.DataSetName = "ParoleDataSet";
            this.paroleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tABELLAPAROLEBindingSource
            // 
            this.tABELLAPAROLEBindingSource.DataMember = "TABELLAPAROLE";
            this.tABELLAPAROLEBindingSource.DataSource = this.paroleDataSet;
            // 
            // tABELLAPAROLETableAdapter
            // 
            this.tABELLAPAROLETableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TABELLAPAROLETableAdapter = this.tABELLAPAROLETableAdapter;
            this.tableAdapterManager.UpdateOrder = AutocompleteTextBox.ParoleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tABELLAPAROLEBindingNavigator
            // 
            this.tABELLAPAROLEBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tABELLAPAROLEBindingNavigator.BindingSource = this.tABELLAPAROLEBindingSource;
            this.tABELLAPAROLEBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tABELLAPAROLEBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tABELLAPAROLEBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tABELLAPAROLEBindingNavigatorSaveItem});
            this.tABELLAPAROLEBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tABELLAPAROLEBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tABELLAPAROLEBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tABELLAPAROLEBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tABELLAPAROLEBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tABELLAPAROLEBindingNavigator.Name = "tABELLAPAROLEBindingNavigator";
            this.tABELLAPAROLEBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tABELLAPAROLEBindingNavigator.Size = new System.Drawing.Size(663, 25);
            this.tABELLAPAROLEBindingNavigator.TabIndex = 10;
            this.tABELLAPAROLEBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Aggiungi nuovo";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(34, 22);
            this.bindingNavigatorCountItem.Text = "di {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Numero totale di elementi";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Elimina";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Sposta in prima posizione";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Sposta indietro";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posizione";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posizione corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Sposta avanti";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Sposta in ultima posizione";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tABELLAPAROLEBindingNavigatorSaveItem
            // 
            this.tABELLAPAROLEBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tABELLAPAROLEBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tABELLAPAROLEBindingNavigatorSaveItem.Image")));
            this.tABELLAPAROLEBindingNavigatorSaveItem.Name = "tABELLAPAROLEBindingNavigatorSaveItem";
            this.tABELLAPAROLEBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.tABELLAPAROLEBindingNavigatorSaveItem.Text = "Salva dati";
            this.tABELLAPAROLEBindingNavigatorSaveItem.Click += new System.EventHandler(this.TABELLAPAROLEBindingNavigatorSaveItem_Click);
            // 
            // AutoCompleteDataGridView
            // 
            this.AutoCompleteDataGridView.AutoGenerateColumns = false;
            this.AutoCompleteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AutoCompleteDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.PAROLE});
            this.AutoCompleteDataGridView.DataSource = this.tABELLAPAROLEBindingSource;
            this.AutoCompleteDataGridView.Location = new System.Drawing.Point(12, 80);
            this.AutoCompleteDataGridView.Name = "AutoCompleteDataGridView";
            this.AutoCompleteDataGridView.Size = new System.Drawing.Size(245, 220);
            this.AutoCompleteDataGridView.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PAROLEID";
            this.dataGridViewTextBoxColumn1.HeaderText = "PAROLEID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // PAROLE
            // 
            this.PAROLE.DataPropertyName = "PAROLE";
            this.PAROLE.HeaderText = "PAROLE";
            this.PAROLE.Name = "PAROLE";
            // 
            // FrmAutoComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(663, 343);
            this.Controls.Add(this.AutoCompleteDataGridView);
            this.Controls.Add(this.tABELLAPAROLEBindingNavigator);
            this.Controls.Add(this.TxtAutoComplete);
            this.Controls.Add(this.btnAutocomplete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmAutoComplete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AUTOCOMPLETE SAMPLES";
            this.Load += new System.EventHandler(this.FrmAutoComplete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paroleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tABELLAPAROLEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tABELLAPAROLEBindingNavigator)).EndInit();
            this.tABELLAPAROLEBindingNavigator.ResumeLayout(false);
            this.tABELLAPAROLEBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoCompleteDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TxtAutoComplete;
        internal System.Windows.Forms.Button btnAutocomplete;
        private ParoleDataSet paroleDataSet;
        private System.Windows.Forms.BindingSource tABELLAPAROLEBindingSource;
        private ParoleDataSetTableAdapters.TABELLAPAROLETableAdapter tABELLAPAROLETableAdapter;
        private ParoleDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tABELLAPAROLEBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tABELLAPAROLEBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView AutoCompleteDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAROLE;

    }
}

