
namespace Sistema_Ventas_MrTec.MODULOS.Reportes.Reportes_de_Kardex.Reporte_de_inventarios_todos
{
    partial class ReportMovimientoBuscar
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Barcodes.QRCodeEncoder qrCodeEncoder1 = new Telerik.Reporting.Barcodes.QRCodeEncoder();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.TextBox11 = new Telerik.Reporting.TextBox();
            this.TextBox5 = new Telerik.Reporting.TextBox();
            this.TextBox10 = new Telerik.Reporting.TextBox();
            this.TextBox13 = new Telerik.Reporting.TextBox();
            this.TextBox12 = new Telerik.Reporting.TextBox();
            this.TextBox14 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.barcode1 = new Telerik.Reporting.Barcode();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.TextBox4 = new Telerik.Reporting.TextBox();
            this.TextBox6 = new Telerik.Reporting.TextBox();
            this.TextBox7 = new Telerik.Reporting.TextBox();
            this.TextBox8 = new Telerik.Reporting.TextBox();
            this.TextBox9 = new Telerik.Reporting.TextBox();
            this.TextBox15 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(5.5D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox1,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.TextBox11,
            this.TextBox5,
            this.TextBox10,
            this.TextBox13,
            this.TextBox12,
            this.TextBox14});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(0.45D));
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.3D), Telerik.Reporting.Drawing.Unit.Cm(1.2D));
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.3D), Telerik.Reporting.Drawing.Unit.Cm(1.6D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.4D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "=Fields.Nombre_Empresa";
            // 
            // textBox2
            // 
            this.textBox2.Format = "{0:F}";
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.1D), Telerik.Reporting.Drawing.Unit.Cm(0.45D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.4D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "=Now()";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.1D), Telerik.Reporting.Drawing.Unit.Cm(3D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(10.8D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "Reporte de Movimientos de Inventario por Producto";
            // 
            // TextBox11
            // 
            this.TextBox11.Angle = 0D;
            this.TextBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.9D), Telerik.Reporting.Drawing.Unit.Cm(4.7D));
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.TextBox11.Style.Font.Bold = true;
            this.TextBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.TextBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox11.Value = "Usuario";
            // 
            // TextBox5
            // 
            this.TextBox5.Angle = 0D;
            this.TextBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.1D), Telerik.Reporting.Drawing.Unit.Cm(4.7D));
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.TextBox5.Style.Font.Bold = true;
            this.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox5.Value = "Cantidad";
            // 
            // TextBox10
            // 
            this.TextBox10.Angle = 0D;
            this.TextBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.601D), Telerik.Reporting.Drawing.Unit.Cm(4.7D));
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.499D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.TextBox10.Style.Font.Bold = true;
            this.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.TextBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox10.Value = "Tipo";
            // 
            // TextBox13
            // 
            this.TextBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(4.7D));
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.8D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.TextBox13.Style.Font.Bold = true;
            this.TextBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.TextBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox13.Value = "Producto";
            // 
            // TextBox12
            // 
            this.TextBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.8D), Telerik.Reporting.Drawing.Unit.Cm(4.7D));
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.TextBox12.Style.Font.Bold = true;
            this.TextBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.TextBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox12.Value = "Motivo";
            // 
            // TextBox14
            // 
            this.TextBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.5D), Telerik.Reporting.Drawing.Unit.Cm(4.7D));
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.TextBox14.Style.Font.Bold = true;
            this.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox14.Value = "Fecha";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.132D);
            this.detail.Name = "detail";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(3.5D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox18,
            this.barcode1});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // textBox18
            // 
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.5D), Telerik.Reporting.Drawing.Unit.Cm(1.5D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.1D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox18.Style.Font.Bold = true;
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.Value = "Reporte generado por MrTEC";
            // 
            // barcode1
            // 
            this.barcode1.Encoder = qrCodeEncoder1;
            this.barcode1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.7D), Telerik.Reporting.Drawing.Unit.Cm(0.1D));
            this.barcode1.Name = "barcode1";
            this.barcode1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.4D), Telerik.Reporting.Drawing.Unit.Cm(3.3D));
            this.barcode1.Stretch = true;
            this.barcode1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.barcode1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.barcode1.Value = "=\"Sistema de Ventas MrTEC, para mas informacion consultar www.mistertec.net.pe/co" +
    "ntacto\"";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.9D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TextBox15,
            this.TextBox9,
            this.TextBox8,
            this.TextBox7,
            this.TextBox6,
            this.TextBox4});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // TextBox4
            // 
            this.TextBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.5D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5D), Telerik.Reporting.Drawing.Unit.Cm(0.7D));
            this.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox4.Value = "=Fields.Fecha";
            // 
            // TextBox6
            // 
            this.TextBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.8D), Telerik.Reporting.Drawing.Unit.Cm(0.7D));
            this.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.TextBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox6.Value = "=Fields.Descripcion";
            // 
            // TextBox7
            // 
            this.TextBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.8D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8D), Telerik.Reporting.Drawing.Unit.Cm(0.7D));
            this.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox7.Value = "=Fields.Movimiento";
            // 
            // TextBox8
            // 
            this.TextBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.601D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.499D), Telerik.Reporting.Drawing.Unit.Cm(0.7D));
            this.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox8.Value = "=Fields.Tipo";
            // 
            // TextBox9
            // 
            this.TextBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.1D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8D), Telerik.Reporting.Drawing.Unit.Cm(0.7D));
            this.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox9.Value = "=Fields.Cantidad";
            // 
            // TextBox15
            // 
            this.TextBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.9D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6D), Telerik.Reporting.Drawing.Unit.Cm(0.7D));
            this.TextBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.TextBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TextBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TextBox15.Value = "=Fields.Cajero";
            // 
            // ReportMovimientoBuscar
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "ReportMovimientoBuscar";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(17D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        public Telerik.Reporting.PictureBox pictureBox1;
        public Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        internal Telerik.Reporting.TextBox TextBox11;
        internal Telerik.Reporting.TextBox TextBox5;
        internal Telerik.Reporting.TextBox TextBox10;
        internal Telerik.Reporting.TextBox TextBox13;
        internal Telerik.Reporting.TextBox TextBox12;
        internal Telerik.Reporting.TextBox TextBox14;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.Barcode barcode1;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        internal Telerik.Reporting.TextBox TextBox15;
        internal Telerik.Reporting.TextBox TextBox9;
        internal Telerik.Reporting.TextBox TextBox8;
        internal Telerik.Reporting.TextBox TextBox7;
        internal Telerik.Reporting.TextBox TextBox6;
        internal Telerik.Reporting.TextBox TextBox4;
    }
}